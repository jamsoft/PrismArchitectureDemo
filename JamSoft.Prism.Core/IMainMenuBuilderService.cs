using System.Collections.Generic;

namespace JamSoft.Prism.Core
{
    public interface IMainMenuBuilderService
    {
        List<MenuItemViewModel> Menu { get; set; }
        MenuItemViewModel FileMenu { get; set; }
        MenuItemViewModel EditMenu { get; set; }
        MenuItemViewModel ViewMenu { get; set; }
        MenuItemViewModel HelpMenu { get; set; }
    }
}