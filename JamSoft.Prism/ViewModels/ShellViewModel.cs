using System.Collections.ObjectModel;
using System.Windows.Forms;
using JamSoft.NET;
using JamSoft.Prism.Core;
using JamSoft.Prism.Core.Services;
using JamSoft.Wpf.Mvvm;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace JamSoft.Prism.ViewModels
{
    /// <summary>
    /// The main application shell view model
    /// </summary>
    /// <seealso cref="JamSoft.Wpf.Mvvm.DependencyViewModelBase" />
    /// <seealso cref="JamSoft.Prism.ViewModels.IShellViewModel" />
    public class ShellViewModel : DependencyViewModelBase, IShellViewModel
    {
        private string _appName;

        private ObservableCollection<MenuItemViewModel> _menu;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        /// <param name="menuService">The menu service.</param>
        public ShellViewModel(IMainMenuBuilderService menuService)
        {
            AppName = $"{Application.ProductName} v{Application.ProductVersion}";
            Menu = menuService.Menu.ToObservableCollection();
        }

        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        /// <value>
        /// The name of the application.
        /// </value>
        public string AppName
        {
            get => _appName;
            set
            {
                _appName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>
        /// The menu.
        /// </value>
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get => _menu;
            set
            {
                _menu = value;
                OnPropertyChanged();
            }
        }
    }
}