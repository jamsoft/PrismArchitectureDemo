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
    /// <summary>
    /// The main application bootstrapper class
    /// </summary>
    /// <seealso cref="Microsoft.Practices.Prism.UnityExtensions.UnityBootstrapper" />
    public class JamSoftBootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        /// <remarks>
        /// If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
        /// <see cref="T:Microsoft.Practices.Prism.Bootstrapper" /> will attach the default <seealso cref="T:Microsoft.Practices.Prism.Regions.IRegionManager" /> of
        /// the application in its <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty" /> attached property
        /// in order to be able to add regions by using the <seealso cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionNameProperty" />
        /// attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            if (Application.Current.MainWindow != null) Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the <see cref="T:Microsoft.Practices.Unity.IUnityContainer" />. May be overwritten in a derived class to add specific
        /// type mappings required by the application.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IApplicationServices, ApplicationServices>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IMainMenuBuilderService, MainMenuBuilderService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IShellViewModel, ShellViewModel>(new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// Creates the <see cref="T:Microsoft.Practices.Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// The base implementation returns a new ModuleCatalog.
        /// </remarks>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog{ ModulePath = "Modules" };
        }
    }
}