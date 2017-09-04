using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace JamSoft.NET
{
    public sealed class Locator
    {
        private readonly Locator instance = new Locator();

        public static readonly FileInfo ExeFileInfo;
        public static readonly string AppInstallLocation;
        public static readonly string MachineDataDirectory;
        public static readonly string CompanyDataDirectory;
        public static readonly string ApplicationDataDirectory;

        static Locator() 
        {
            AppInstallLocation = Assembly.GetExecutingAssembly().Location;
            MachineDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            CompanyDataDirectory = Path.Combine(MachineDataDirectory, Application.CompanyName);
            ApplicationDataDirectory = Path.Combine(CompanyDataDirectory, Application.ProductName);
        }

        Locator() { }
    }
}