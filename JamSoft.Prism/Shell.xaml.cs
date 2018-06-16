using System.Windows;
using JamSoft.Prism.Core;
using JamSoft.Prism.ViewModels;

namespace JamSoft.Prism
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window, IShell
    {
        public Shell(IShellViewModel viewModel)
        {
            InitializeComponent();
            
            Model = viewModel;

            Closing += (s, e) =>
            {
                if (GlobalCommands.ShutdownCommand.CanExecute(e))
                    GlobalCommands.ShutdownCommand.Execute(e);
            };
        }

        /// <summary>
        /// Sets the main shell view model instance.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public object Model
        {
            set => DataContext = value;
        }
    }
}