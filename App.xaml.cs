using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using System;

namespace CountClickKey
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon notifyIcon;

        System.Threading.Mutex mutex;
        //Thread keyloggerThread;
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

            //// Start keylogger in another thread and close GUI
            //keyloggerThread = new Thread(() =>
            //{
            //    new Controller().StartMonitor();
            //});
            //keyloggerThread.SetApartmentState(ApartmentState.STA);
            //keyloggerThread.Start();
        }

        void CurrentDomain_UnhandledEception(object sender, UnhandledExceptionEventArgs e)
        {
            // Put your tracing or logging code here
            System.Windows.MessageBox.Show(e.ExceptionObject.ToString());
        }

        protected override void OnExit(ExitEventArgs e)
        {
            DataFile dataFile = new DataFile();
            dataFile.UpdateFileData();

            notifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            //keyloggerThread.Abort();
            System.Environment.Exit(1);
            base.OnExit(e);
        }
    }
}
