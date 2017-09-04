using System.Windows.Input;

namespace JamSoft.Prism.Core
{
    public interface IApplicationServices
    {
        void RegisterForShutdownNotification(ICommand command);
        void UnRegisterForShutdownNotification(ICommand command);
    }
}