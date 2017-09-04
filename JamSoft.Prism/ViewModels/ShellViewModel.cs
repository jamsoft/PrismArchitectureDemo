using System.Collections.ObjectModel;
using JamSoft.NET;
using JamSoft.Prism.Core;
using JamSoft.Wpf.Mvvm;
using System.Configuration;
using System.Windows;

namespace JamSoft.Prism.ViewModels
{
    public class ShellViewModel : DependencyViewModelBase, IShellViewModel
    {
        private readonly IMainMenuBuilderService _mainMenuBuilderService;

        private string _appName;
        public string AppName
        {
            get { return _appName; }
            set { _appName = value; OnPropertyChanged(() => Name); }
        }

        public ShellViewModel(IMainMenuBuilderService menuService)
        {
            AppName = string.Format("{0} v{1}", System.Windows.Forms.Application.ProductName, System.Windows.Forms.Application.ProductVersion);
            _mainMenuBuilderService = menuService;
            Menu = _mainMenuBuilderService.Menu.ToObservableCollection();
        }

        private ObservableCollection<MenuItemViewModel> _menu;
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get { return _menu; }
            set
            {
                _menu = value;
                OnPropertyChanged(() => Menu);
            }
        }
    }
}