using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows.Data;

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/globalisation", "JamSoft.Wpf.Globalization"),
           XmlnsPrefix("http://jamsoft.co.uk/wpf/globalisation", "jsglobal")]
namespace JamSoft.Wpf.Globalization
{
    public class TranslateExtension : MarkupExtension
    {
        private string _key;

        public TranslateExtension(string key)
        {
            _key = key;
        }

        [ConstructorArgument("key")]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding("Value")
            {
                Source = new TranslationData(_key)
            };
            return binding.ProvideValue(serviceProvider);
        }
    }
}
