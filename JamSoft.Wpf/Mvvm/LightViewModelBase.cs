using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/mvvm", "JamSoft.Wpf.Mvvm"), 
           XmlnsPrefix("http://jamsoft.co.uk/wpf/windows", "jsmvvm")]
namespace JamSoft.Wpf.Mvvm
{
    /// <summary>
    /// This is the abstract base class for any object that provides property change notifications.  
    /// </summary>
    public abstract class LightViewModelBase : INotifyPropertyChanged
    {
        #region RaisePropertyChanged

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}