using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using JamSoft.Wpf.Mvvm;

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/prism", "JamSoft.Prism.Core"),
           XmlnsPrefix("http://jamsoft.co.uk/wpf/prism", "jsprism")]
namespace JamSoft.Prism.Core
{
    public class MenuItemViewModel : LightViewModelBase
    {
        private ICommand _command;
        private string _header;
        private Image _icon;
        private string _inputGestureText;
        private bool _isEnabled = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"/> class.
        /// </summary>
        public MenuItemViewModel()
        {
            Children = new ObservableCollection<MenuItemViewModel>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"/> class.
        /// </summary>
        /// <param name="isSeparator">if set to <c>true</c> [is separator].</param>
        public MenuItemViewModel(bool isSeparator) : this()
        {
            IsSeparator = isSeparator;
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public ICommand Command
        {
            get => _command;
            set
            {
                _command = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public Image Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the input gesture text.
        /// </summary>
        /// <value>
        /// The input gesture text.
        /// </value>
        public string InputGestureText
        {
            get => _inputGestureText;
            set
            {
                _inputGestureText = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public ObservableCollection<MenuItemViewModel> Children { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is separator.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is separator; otherwise, <c>false</c>.
        /// </value>
        public bool IsSeparator { get; set; }
    }
}