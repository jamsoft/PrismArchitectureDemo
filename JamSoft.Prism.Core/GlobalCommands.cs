using Prism.Commands;

namespace JamSoft.Prism.Core
{
    /// <summary>
    /// Contains all application wide commands exposed through the IApplicationService
    /// to the rest of the application eco-system
    /// </summary>
    public static class GlobalCommands
    {
        /// <summary>
        /// The shutdown command
        /// </summary>
        public static readonly CompositeCommand ShutdownCommand = new CompositeCommand(true);
    }
}