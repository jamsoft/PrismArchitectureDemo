using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
// ReSharper disable UnusedMember.Global

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/windows", "JamSoft.Wpf.Mvvm"), 
           XmlnsPrefix("http://jamsoft.co.uk/wpf/windows", "jsmvvm")]
namespace JamSoft.Wpf.Mvvm
{
    /// <summary>
    /// Base class for ViewModel classes in the MVVM pattern.
    /// </summary>
    public abstract class DependencyViewModelBase : DependencyObject, INotifyPropertyChanged
    {
        #region Members

        private static bool _designMode;
        private string _name = string.Empty;
        private event PropertyChangedEventHandler PrivatepropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Get or set the name of the view model
        /// </summary>
        // ReSharper disable once MemberCanBeProtected.Global
        public string Name
        {
            get => _name;
            set 
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Event raised when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add => PrivatepropertyChanged += value;
            remove => PrivatepropertyChanged -= value;
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Initializes a new instance of <see cref="DependencyViewModelBase"/>.
        /// </summary>
        protected DependencyViewModelBase()
        {
            OnInitialize();
        }

        /// <summary>
        /// Call this method when you change the culture to update the resources.
        /// </summary>
        protected void CultureChanged()
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            OnPropertyChanged("Resource");
        }

        /// <summary>
        /// Initialize the instance.
        /// </summary>
        // ReSharper disable once VirtualMemberNeverOverridden.Global
        private void OnInitialize()
        {
            _designMode = DesignerProperties.GetIsInDesignMode(new Button())
                || Application.Current == null || Application.Current.GetType() == typeof(Application);

            if (!_designMode)
            {
                var designMode = DesignerProperties.IsInDesignModeProperty;
                _designMode = (bool)DependencyPropertyDescriptor.FromProperty(designMode, typeof(FrameworkElement)).Metadata.DefaultValue;
            }

            if (_designMode)
            {
                DesignData();
            }
        }

        #endregion

        /// <summary>
        /// With this method, we can inject design time data into the view so that we can
        /// create a more Blendable application.
        /// </summary>
        // ReSharper disable once VirtualMemberNeverOverridden.Global
        protected virtual void DesignData()
        {
        }

        /// <summary>
        /// Returns whether or not the control is in design mode, running inside Visual Studio or Blend.
        /// </summary>
        /// <remarks>
        /// I'd like to thank Laurent Bugnion for the design mode code. Take a look at MvvmLight for this.
        /// </remarks>
        protected bool IsInDesignMode => _designMode;

        #region Changed handlers

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PrivatepropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}