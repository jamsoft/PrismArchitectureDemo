using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using JamSoft.Prism.Core;
// ReSharper disable UnusedMember.Local

namespace JamSoft.Prism.Services
{
    /// <summary>
    /// </summary>
    /// <seealso cref="JamSoft.Prism.Core.IMainMenuBuilderService" />
    public class MainMenuBuilderService : IMainMenuBuilderService
    {
        private MenuItemViewModel _viewMenu;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainMenuBuilderService" /> class.
        /// </summary>
        public MainMenuBuilderService()
        {
            Menu = new List<MenuItemViewModel>();

            FileMenu = new MenuItemViewModel {Header = "_File"};
            FileMenu.Children.Add(new MenuItemViewModel(true));
            FileMenu.Children.Add(new MenuItemViewModel {Header = "_New"});

            Menu.Add(FileMenu);
            Menu.Add(EditMenu);
            Menu.Add(_viewMenu);
            Menu.Add(HelpMenu);
        }

        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>
        /// The menu.
        /// </value>
        public List<MenuItemViewModel> Menu { get; set; }

        /// <summary>
        /// Gets or sets the file menu.
        /// </summary>
        /// <value>
        /// The file menu.
        /// </value>
        public MenuItemViewModel FileMenu { get; set; }

        /// <summary>
        /// Gets or sets the edit menu.
        /// </summary>
        /// <value>
        /// The edit menu.
        /// </value>
        public MenuItemViewModel EditMenu { get; set; }

        /// <summary>
        /// Gets or sets the view menu.
        /// </summary>
        /// <value>
        /// The view menu.
        /// </value>
        public MenuItemViewModel ViewMenu
        {
            get => _viewMenu;
            set => _viewMenu = value;
        }

        public MenuItemViewModel HelpMenu { get; set; }

        /// <summary>
        ///     Creates the image.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private static Image CreateImage(string url)
        {
            var image = new Image
            {
                Source = new BitmapImage(new Uri("Resources/" + url, UriKind.Relative)),
                Height = 16,
                Width = 16
            };
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.NearestNeighbor);
            return image;
        }
    }
}