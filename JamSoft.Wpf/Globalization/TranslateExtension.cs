using System;
using System.Windows.Data;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/globalisation", "JamSoft.Wpf.Globalization"),
           XmlnsPrefix("http://jamsoft.co.uk/wpf/globalisation", "jsglobal")]
namespace JamSoft.Wpf.Globalization
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Markup.MarkupExtension" />
    public class TranslateExtension : MarkupExtension
    {
        public TranslateExtension(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [ConstructorArgument("key")]
        public string Key { get; set; }

        /// <summary>
        /// When implemented in a derived class, returns an object that is provided as the value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>
        /// The object value to set on the property where the extension is applied.
        /// </returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding("Value")
            {
                Source = new TranslationData(Key)
            };
            return binding.ProvideValue(serviceProvider);
        }
    }
}