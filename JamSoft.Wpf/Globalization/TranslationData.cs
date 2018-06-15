using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/globalisation", "JamSoft.Wpf.Globalization"),
           XmlnsPrefix("http://jamsoft.co.uk/wpf/globalisation", "jsglobal")]

namespace JamSoft.Wpf.Globalization
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.IWeakEventListener" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="System.IDisposable" />
    public class TranslationData : IWeakEventListener, INotifyPropertyChanged, IDisposable
    {
        private readonly string _key;

        public TranslationData(string key)
        {
            _key = key;
            LanguageChangedEventManager.AddListener(
                TranslationManager.Instance, this);
        }
        
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value => TranslationManager.Instance.Translate(_key);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Receives events from the centralized event manager.
        /// </summary>
        /// <param name="managerType">The type of the <see cref="T:System.Windows.WeakEventManager" /> calling this method.</param>
        /// <param name="sender">Object that originated the event.</param>
        /// <param name="e">Event data.</param>
        /// <returns>
        ///   <see langword="true" /> if the listener handled the event. It is considered an error by the <see cref="T:System.Windows.WeakEventManager" /> handling in WPF to register a listener for an event that the listener does not handle. Regardless, the method should return <see langword="false" /> if it receives an event that it does not recognize or handle.
        /// </returns>
        public bool ReceiveWeakEvent(Type managerType,
            object sender, EventArgs e)
        {
            if (managerType == typeof(LanguageChangedEventManager))
            {
                OnLanguageChanged(sender, e);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TranslationData"/> class.
        /// </summary>
        ~TranslationData()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                LanguageChangedEventManager.RemoveListener(
                    TranslationManager.Instance, this);
        }

        /// <summary>
        /// Called when [language changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnLanguageChanged(object sender, EventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Value"));
        }
    }
}