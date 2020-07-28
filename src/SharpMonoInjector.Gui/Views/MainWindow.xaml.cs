using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows;

namespace SharpMonoInjector.Gui.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            bool IsElevated = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            
            if (!IsElevated)
            {
                string exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                System.Diagnostics.Process.Start(startInfo);
                AppDomain.Unload(AppDomain.CurrentDomain);
            }

            InitializeComponent();
        }

    }
}
