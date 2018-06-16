using System.Windows.Input;

// ReSharper disable ClassNeverInstantiated.Global

namespace JamSoft.Prism.Core.Services
{
    /// <summary>
    /// Manages global commands
    /// </summary>
    /// <seealso cref="IApplicationServices" />
    public class ApplicationServices : IApplicationServices
    {
        /// <summary>
        /// Registers commands for shutdown notification.
        /// </summary>
        /// <param name="command">The command.</param>
        public void RegisterForShutdownNotification(ICommand command)
        {
            GlobalCommands.ShutdownCommand.RegisterCommand(command);
        }

        /// <summary>
        /// UnRegisters command for shutdown notification.
        /// </summary>
        /// <param name="command">The command.</param>
        public void UnRegisterForShutdownNotification(ICommand command)
        {
            GlobalCommands.ShutdownCommand.RegisterCommand(command);
        }
    }
}