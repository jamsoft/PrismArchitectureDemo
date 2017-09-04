using System.Windows;
using System.Windows.Controls;
using JamSoft.Prism.Core;

namespace JamSoft.Prism
{
    public class MenuItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item != null && ((MenuItemViewModel)item).IsSeparator)
            {
                return (Style)((FrameworkElement)container).FindResource("SeparatorStyle");
            }
            return base.SelectStyle(item, container);
        }
    }
}