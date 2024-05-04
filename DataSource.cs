using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows;

namespace CountClickKey
{
    /// <summary>
    /// This class serves as a data source for keylogger. It provides method to get what we want.
    /// </summary>
    public class DataSource
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        private HashSet<Key> PressedKeys = new HashSet<Key>();

        public static int ValueClickedKeyboard = 0;
        private static readonly int VALUE_FOR_SAVE_KEYBOARD = 100;

        /// <summary>
        /// This functions scans currently pressed keys and returns them. Every key is returned just once. If the key is still pressed during second
        /// method call, it is not returned. It's returned again after the key is released and pressed again.
        /// </summary>
        /// <returns>List of keys which were just pressed</returns>
        public void GetNewPressedKeys()
        {
            List<Key> newPressedKeys = new List<Key>(10);

            // Get state of every key we know
            foreach (Key key in Utils.GetEnumValues<Key>().Where(x => x != Key.None))
            {
                // Is it pressed?
                bool down = Keyboard.IsKeyDown(key);

                // It's not pressed, but it was - we consider this key as released
                if (!down && PressedKeys.Contains(key))
                {
                    PressedKeys.Remove(key);
                }
                else if (down && !PressedKeys.Contains(key)) // The key is pressed, but wasn't pressed before - it will be returned
                {
                    foreach (var data in StatisticsList.StatisticsKeyboard)
                    {
                        if (data.KeyID == key)
                        {
                            data.DataCountClicked.CountAllTimeClickedKey++; // Stats clicked all time
                            data.DataCountClicked.DataDayClicked.CountDayClicked++; // Stats clicked day
                            data.DataCountClicked.DataWeekClicked.CountWeekClicked++; // Stats clicked week
                            data.DataCountClicked.DataMonthClicked.CountMonthClicked++; // Stats clicked month
                            data.DataCountClicked.DataYearClicked.CountYearClicked++; // Stats clicked year

                            ValueClickedKeyboard++;

                            if(ValueClickedKeyboard == VALUE_FOR_SAVE_KEYBOARD)
                            {
                                DataFile dataFile = new DataFile();
                                dataFile.UpdateFileData();
                                ValueClickedKeyboard = 0;
                            }
                        }
                    }
                    PressedKeys.Add(key);
                }
            }
        }

        /// <summary>
        /// Search for currently active window (focused) and returns name of the process of that window.
        /// So if user is using Chrome right now, 'chrome' string will be returned.
        /// </summary>
        /// <returns>Name of the process who is tied to currently active window</returns>
        public string GetActiveWindowProcessName()
        {
            IntPtr windowHandle = GetForegroundWindow();
            GetWindowThreadProcessId(windowHandle, out uint processId);
            Process process = Process.GetProcessById((int)processId);

            return process.ProcessName;
        }
    }
}
