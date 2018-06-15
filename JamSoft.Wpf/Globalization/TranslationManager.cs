using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Markup;
// ReSharper disable UnusedAutoPropertyAccessor.Global

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/globalisation", "JamSoft.Wpf.Globalization"),
           XmlnsPrefix("http://jamsoft.co.uk/wpf/globalisation", "jsglobal")]

namespace JamSoft.Wpf.Globalization
{
    public class TranslationManager
    {
        private static TranslationManager _translationManager;

        /// <summary>
        /// Gets or sets the current language.
        /// </summary>
        /// <value>
        /// The current language.
        /// </value>
        public CultureInfo CurrentLanguage
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (!Equals(value, Thread.CurrentThread.CurrentUICulture))
                {
                    Thread.CurrentThread.CurrentUICulture = value;
                    OnLanguageChanged();
                }
            }
        }

        /// <summary>
        /// Gets the languages.
        /// </summary>
        /// <value>
        /// The languages.
        /// </value>
        public IEnumerable<CultureInfo> Languages
        {
            get
            {
                if (TranslationProvider != null) return TranslationProvider.Languages;
                return Enumerable.Empty<CultureInfo>();
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static TranslationManager Instance
        {
            get
            {
                if (_translationManager == null)
                    _translationManager = new TranslationManager();
                return _translationManager;
            }
        }

        /// <summary>
        /// Gets or sets the translation provider.
        /// </summary>
        /// <value>
        /// The translation provider.
        /// </value>
        public ITranslationProvider TranslationProvider { get; set; }

        /// <summary>
        /// Occurs when [language changed].
        /// </summary>
        public event EventHandler LanguageChanged;

        /// <summary>
        /// Called when [language changed].
        /// </summary>
        private void OnLanguageChanged()
        {
            if (LanguageChanged != null) LanguageChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Translates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object Translate(string key)
        {
            if (TranslationProvider != null)
            {
                var translatedValue = TranslationProvider.Translate(key);
                if (translatedValue != null) return translatedValue;
            }

            return $"!{key}!";
        }
    }
}