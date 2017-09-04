using JamSoft.Prism.Core;
using System.Windows.Input;

namespace JamSoft.Prism.Services
{
    public class ApplicationServices : IApplicationServices
    {
        public void RegisterForShutdownNotification(ICommand command)
        {
            GlobalCommands.ShutdownCommand.RegisterCommand(command);
        }

        public void UnRegisterForShutdownNotification(ICommand command)
        {
            GlobalCommands.ShutdownCommand.RegisterCommand(command);
        }
    }
}