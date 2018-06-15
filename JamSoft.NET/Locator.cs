using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
// ReSharper disable NotAccessedField.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace JamSoft.NET
{
    /// <summary>
    /// Basic application directory structure
    /// </summary>
    public sealed class Locator
    {
        public static readonly FileInfo ExeFileInfo;
        public static readonly string AppInstallLocation;
        public static readonly string MachineDataDirectory;
        public static readonly string CompanyDataDirectory;
        public static readonly string ApplicationDataDirectory;

        /// <summary>
        /// Initializes the <see cref="Locator"/> class.
        /// </summary>
        static Locator() 
        {
            AppInstallLocation = Assembly.GetExecutingAssembly().Location;
            MachineDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            CompanyDataDirectory = Path.Combine(MachineDataDirectory, Application.CompanyName);
            ApplicationDataDirectory = Path.Combine(CompanyDataDirectory, Application.ProductName);
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Locator"/> class from being created.
        /// </summary>
        Locator() { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Locator Instance { get; } = new Locator();
    }
}