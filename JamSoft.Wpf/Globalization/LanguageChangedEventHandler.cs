using System;
using System.Windows;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/globalisation", "JamSoft.Wpf.Globalization"),
           XmlnsPrefix("http://jamsoft.co.uk/wpf/globalisation", "jsglobal")]
namespace JamSoft.Wpf.Globalization
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.WeakEventManager" />
    public class LanguageChangedEventManager : WeakEventManager
    {
        /// <summary>
        /// Adds the listener.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="listener">The listener.</param>
        public static void AddListener(TranslationManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        /// <summary>
        /// Removes the listener.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="listener">The listener.</param>
        public static void RemoveListener(TranslationManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        /// <summary>
        /// Called when [language changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnLanguageChanged(object sender, EventArgs e)
        {
            DeliverEvent(sender, e);
        }

        /// <summary>
        /// When overridden in a derived class, starts listening for the event being managed. After the <see cref="M:System.Windows.WeakEventManager.StartListening(System.Object)" /> method is first called, the manager should be in the state of calling <see cref="M:System.Windows.WeakEventManager.DeliverEvent(System.Object,System.EventArgs)" /> or <see cref="M:System.Windows.WeakEventManager.DeliverEventToList(System.Object,System.EventArgs,System.Windows.WeakEventManager.ListenerList)" /> whenever the relevant event from the provided source is handled.
        /// </summary>
        /// <param name="source">The source to begin listening on.</param>
        protected override void StartListening(object source)
        {
            var manager = (TranslationManager)source;
            manager.LanguageChanged += OnLanguageChanged;
        }

        /// <summary>
        /// When overridden in a derived class, stops listening on the provided source for the event being managed.
        /// </summary>
        /// <param name="source">The source to stop listening on.</param>
        protected override void StopListening(Object source)
        {
            var manager = (TranslationManager)source;
            manager.LanguageChanged -= OnLanguageChanged;
        }

        /// <summary>
        /// Gets the current manager.
        /// </summary>
        /// <value>
        /// The current manager.
        /// </value>
        private static LanguageChangedEventManager CurrentManager
        {
            get
            {
                var managerType = typeof(LanguageChangedEventManager);
                var manager = (LanguageChangedEventManager)GetCurrentManager(managerType);
                if (manager != null) return manager;
                manager = new LanguageChangedEventManager();
                SetCurrentManager(managerType, manager);
                return manager;
            }
        }
    }
}