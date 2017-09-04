using JamSoft.Prism.Core;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System;

namespace JamSoft.Prism.Services
{
    public class MainMenuBuilderService : IMainMenuBuilderService
    {
        private List<MenuItemViewModel> _menu;
        public List<MenuItemViewModel> Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        private MenuItemViewModel _fileMenu;
        public MenuItemViewModel FileMenu
        {
            get { return _fileMenu; }
            set { _fileMenu = value; }
        }

        private MenuItemViewModel _editMenu;
        public MenuItemViewModel EditMenu
        {
            get { return _editMenu; }
            set { _editMenu = value; }
        }

        public MenuItemViewModel _viewMenu;
        public MenuItemViewModel ViewMenu
        {
            get { return _viewMenu; }
            set { _viewMenu = value; }
        }

        private MenuItemViewModel _helpMenu;
        public MenuItemViewModel HelpMenu
        {
            get { return _helpMenu; }
            set { _helpMenu = value; }
        }

        public MainMenuBuilderService()
        {
            _menu = new List<MenuItemViewModel>();

            _fileMenu = new MenuItemViewModel { Header = "_File" };
            _fileMenu.Children.Add(new MenuItemViewModel(true));
            _fileMenu.Children.Add(new MenuItemViewModel { Header = "_New" });

            _menu.Add(_fileMenu);
            _menu.Add(_editMenu);
            _menu.Add(_viewMenu);
            _menu.Add(_helpMenu);
        }

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