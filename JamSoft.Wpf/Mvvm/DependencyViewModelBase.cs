using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

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

        private static bool _designMode = false;
        //private static bool _osBinding = false;
        private string _name = string.Empty;
        private event PropertyChangedEventHandler _propertyChanged;

        #endregion

        #region Public methods
        /// <summary>
        /// Get or set the name of the view model
        /// </summary>
        public string Name
        {
            get { return _name; }
            set 
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        /// <summary>
        /// Event raised when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }

        /// <summary>
        /// Handle the shutting down of items in the ViewModel.
        /// </summary>
        public virtual void Shutdown()
        {
        }

        /// <summary>
        /// Get the resources associated with this ViewModel.
        /// </summary>
        /// <remarks>
        /// In order to make effective use of resources in the ViewModel, you need to install the ResXFileCodeGeneratorEx utility
        /// found <see href="http://www.codeproject.com/KB/dotnet/ResXFileCodeGeneratorEx.aspx">here</see>. This utility works 
        /// round limitations of the ResXFileCodeGenerator tool which generates the resource as internal.
        /// </remarks>
        public virtual object Resources
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region Protected methods
        /// <summary>
        /// Initializes a new instance of <see cref="ViewModelBase"/>.
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
            OnPropertyChanged("Resource");
        }

        /// <summary>
        /// Initialize the instance.
        /// </summary>
        protected virtual void OnInitialize()
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
        protected virtual void DesignData()
        {
        }

        /// <summary>
        /// Returns whether or not the control is in design mode, running inside Visual Studio or Blend.
        /// </summary>
        /// <remarks>
        /// I'd like to thank Laurent Bugnion for the design mode code. Take a look at MvvmLight for this.
        /// </remarks>
        protected bool IsInDesignMode
        {
            get
            {
                return _designMode;
            }
        }

        #region Changed handlers

        /// <summary>
        /// Call this when a property changes.
        /// </summary>
        /// <param name="expression">The expression that identifies what has changed.</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            OnPropertyChanged(expression.Name);
        }

        /// <summary>
        /// This method calls the <see cref="PropertyChangedEventHandler"/> handler.
        /// </summary>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = _propertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}