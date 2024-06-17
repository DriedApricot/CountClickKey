using System.Threading;

namespace CountClickKey.Statistics
{
    /// <summary>
    /// Controlls flow of the keylogger
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Starts infinite run of the keylogger
        /// </summary>
        public void StartMonitor()
        {
            DataSource dataSource = new DataSource();
            while (true)
            {
                dataSource.GetNewPressedKeys();
                Thread.Sleep(1);
            }
        }
    }
}
