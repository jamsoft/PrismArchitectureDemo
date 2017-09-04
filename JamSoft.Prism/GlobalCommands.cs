using Microsoft.Practices.Prism.Commands;

namespace JamSoft.Prism
{
    /// <summary>
    /// Contains all application wide commands exposed through the IApplicationService
    /// to the rest of the application eco-system
    /// </summary>
    internal static class GlobalCommands
    {
        internal static CompositeCommand ShutdownCommand = new CompositeCommand(true);
    }
}