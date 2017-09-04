using System.Windows;
using JamSoft.Prism.Core;
using JamSoft.Prism.Services;
using JamSoft.Prism.ViewModels;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace JamSoft.Prism
{
    public class JamSoftBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IApplicationServices, ApplicationServices>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IMainMenuBuilderService, MainMenuBuilderService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IShellViewModel, ShellViewModel>(new ContainerControlledLifetimeManager());
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog{ ModulePath = "Modules" };
        }
    }
}