using JamSoft.Prism.Core;
using JamSoft.Prism.ViewModels;

namespace JamSoft.Prism
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : IShell
    {
        public Shell(IShellViewModel viewModel)
        {
            InitializeComponent();
            this.Model = viewModel;

            Closing += (s, e) =>
            {
                if (GlobalCommands.ShutdownCommand.CanExecute(e))
                    GlobalCommands.ShutdownCommand.Execute(e);
            };
        }

        public object Model
        {
            set => DataContext = value;
        }
    }
}