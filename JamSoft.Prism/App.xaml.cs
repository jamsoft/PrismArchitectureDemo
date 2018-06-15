using System.Configuration;
using System.Windows;

namespace JamSoft.Prism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            var useDefaultPrismConfiguration = bool.Parse(ConfigurationManager.AppSettings["useDefaultPrismConfiguration"]);
            var bootstrapper = new JamSoftBootstrapper();
            bootstrapper.Run();
        }
    }
}