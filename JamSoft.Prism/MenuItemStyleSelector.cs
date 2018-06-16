using System.Windows;
using System.Windows.Controls;
using JamSoft.Prism.Core.ViewModels;

namespace JamSoft.Prism
{
    public class MenuItemStyleSelector : StyleSelector
    {
        /// <summary>
        /// When overridden in a derived class, returns a <see cref="T:System.Windows.Style" /> based on custom logic.
        /// </summary>
        /// <param name="item">The content.</param>
        /// <param name="container">The element to which the style will be applied.</param>
        /// <returns>
        /// Returns an application-specific style to apply; otherwise, <see langword="null" />.
        /// </returns>
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