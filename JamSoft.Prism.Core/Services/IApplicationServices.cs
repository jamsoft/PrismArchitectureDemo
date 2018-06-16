using System.Windows.Input;

namespace JamSoft.Prism.Core.Services
{
    public interface IApplicationServices
    {
        /// <summary>
        /// Registers commands for shutdown notification.
        /// </summary>
        /// <param name="command">The command.</param>
        void RegisterForShutdownNotification(ICommand command);

        /// <summary>
        /// UnRegisters command for shutdown notification.
        /// </summary>
        /// <param name="command">The command.</param>
        void UnRegisterForShutdownNotification(ICommand command);
    }
}