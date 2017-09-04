using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using JamSoft.Wpf.Mvvm;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/prism", "JamSoft.Prism.Core"),
           XmlnsPrefix("http://jamsoft.co.uk/wpf/prism", "jsprism")]
namespace JamSoft.Prism.Core
{
    public class MenuItemViewModel : LightViewModelBase
    {
        private string _header;
        private bool _isEnabled = true;
        private ICommand _command;
        private Image _icon;
        private string _inputGestureText;
        private ObservableCollection<MenuItemViewModel> _children;

        public MenuItemViewModel()
        {
            Children = new ObservableCollection<MenuItemViewModel>();
        }

        public MenuItemViewModel(bool isSeparator) : this()
        {
            _isSeparator = isSeparator;
        }

        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                OnPropertyChanged(() => Header);
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(() => IsEnabled);
            }
        }

        public ICommand Command
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged(() => Command);
            }
        }

        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged(() => Icon);
            }
        }

        public string InputGestureText
        {
            get { return _inputGestureText; }
            set
            {
                _inputGestureText = value;
                OnPropertyChanged(() => InputGestureText);
            }
        }

        public ObservableCollection<MenuItemViewModel> Children
        {
            get { return _children; }
            set { _children = value; }
        }

        private bool _isSeparator;
        public bool IsSeparator
        {
            get { return _isSeparator; }
            set { _isSeparator = value; }
        }
    }
}