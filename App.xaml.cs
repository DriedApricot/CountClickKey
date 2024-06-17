using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using System;
using CountClickKey.Localization;
using System.Threading;

namespace CountClickKey
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon notifyIcon;
        System.Threading.Mutex mutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            string mutName = "CountClickKey";
            mutex = new System.Threading.Mutex(true, mutName, out bool createNew);
            if(!createNew)
            {
                this.Shutdown();
            }

            // Hook on error before app really starts
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledEception);

            base.OnStartup(e);

            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");

            Thread.CurrentThread.CurrentUICulture = CountClickKey.Properties.Settings.Default.DefaultLanguage;
            LocalizationManager.Instance.LocalizationProvider = new ResxLocalizationProvider();
        }

        void CurrentDomain_UnhandledEception(object sender, UnhandledExceptionEventArgs e)
        {
            // Put your tracing or logging code here
            System.Windows.MessageBox.Show(e.ExceptionObject.ToString());
        }

        protected override void OnExit(ExitEventArgs e)
        {
            CountClickKey.Statistics.DataFile dataFile = new CountClickKey.Statistics.DataFile();
            dataFile.UpdateFileData();

            notifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            System.Environment.Exit(1);
            base.OnExit(e);
        }
    }
}
