using System.Collections.Generic;

namespace JamSoft.Prism.Core
{
    /// <summary>
    /// Allows the building of the application menu
    /// </summary>
    public interface IMainMenuBuilderService
    {
        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>
        /// The menu.
        /// </value>
        List<MenuItemViewModel> Menu { get; set; }

        /// <summary>
        /// Gets or sets the file menu.
        /// </summary>
        /// <value>
        /// The file menu.
        /// </value>
        MenuItemViewModel FileMenu { get; set; }

        /// <summary>
        /// Gets or sets the edit menu.
        /// </summary>
        /// <value>
        /// The edit menu.
        /// </value>
        MenuItemViewModel EditMenu { get; set; }

        /// <summary>
        /// Gets or sets the view menu.
        /// </summary>
        /// <value>
        /// The view menu.
        /// </value>
        MenuItemViewModel ViewMenu { get; set; }

        /// <summary>
        /// Gets or sets the help menu.
        /// </summary>
        /// <value>
        /// The help menu.
        /// </value>
        MenuItemViewModel HelpMenu { get; set; }
    }
}