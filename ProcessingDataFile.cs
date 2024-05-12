using System;
using System.IO;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Input;

namespace CountClickKey
{
    public class DataFile
    {
        public static readonly string TYPE_KEY_WRITER = "Writer keys";
        public static readonly string TYPE_KEY_NUMERIC_KEYPAD = "Numeric keypad";
        public static readonly string TYPE_KEY_FUNCTIONAL_BLOCK = "Functional block";
        public static readonly string TYPE_KEY_COURCOR_CONTROL_KEYS = "Courcor control keys";
        public static readonly string TYPE_KEY_SYSTEM_KEYS = "System keys";
        public static readonly string TYPE_KEY_OTHER_KEYS = "Other keys";

        public void CheckExistsFile()
        {
            Data[] data = new Data[]
            {
                new Data("ESC", TYPE_KEY_OTHER_KEYS, Key.Escape), new Data("F1", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F1), new Data("F2", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F2),
                new Data("F3", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F3), new Data("F4", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F4), new Data("F5", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F5),
                new Data("F6", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F6), new Data("F7", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F7), new Data("F8", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F8),
                new Data("F9", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F9), new Data("F10", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F10), new Data("F11", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F11),
                new Data("F12", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F12), new Data("Ps", TYPE_KEY_FUNCTIONAL_BLOCK, Key.PrintScreen), new Data("Sl", TYPE_KEY_FUNCTIONAL_BLOCK, Key.Scroll),
                new Data("Pb", TYPE_KEY_FUNCTIONAL_BLOCK, Key.Pause),

                new Data("~", TYPE_KEY_WRITER, Key.OemTilde), new Data("1", TYPE_KEY_WRITER, Key.D1), new Data("2", TYPE_KEY_WRITER, Key.D2),
                new Data("3", TYPE_KEY_WRITER, Key.D3), new Data("4", TYPE_KEY_WRITER, Key.D4), new Data("5", TYPE_KEY_WRITER, Key.D5),
                new Data("6", TYPE_KEY_WRITER, Key.D6), new Data("7", TYPE_KEY_WRITER, Key.D7), new Data("8", TYPE_KEY_WRITER, Key.D8),
                new Data("9", TYPE_KEY_WRITER, Key.D9), new Data("0", TYPE_KEY_WRITER, Key.D0), new Data("-", TYPE_KEY_WRITER, Key.OemMinus),
                new Data("=", TYPE_KEY_WRITER, Key.OemPlus),  new Data("Backspace", TYPE_KEY_FUNCTIONAL_BLOCK, Key.Back), new Data("Ins", TYPE_KEY_FUNCTIONAL_BLOCK, Key.Insert),
                new Data("Hm", TYPE_KEY_FUNCTIONAL_BLOCK, Key.Home), new Data("Pu", TYPE_KEY_FUNCTIONAL_BLOCK, Key.PageUp),

                new Data("TAB", TYPE_KEY_FUNCTIONAL_BLOCK, Key.Tab), new Data("Q", TYPE_KEY_WRITER, Key.Q), new Data("W", TYPE_KEY_WRITER, Key.W),
                new Data("E", TYPE_KEY_WRITER, Key.E), new Data("R", TYPE_KEY_WRITER, Key.R), new Data("T", TYPE_KEY_WRITER, Key.T),
                new Data("Y", TYPE_KEY_WRITER, Key.Y), new Data("U", TYPE_KEY_WRITER, Key.U), new Data("I", TYPE_KEY_WRITER, Key.I),
                new Data("O", TYPE_KEY_WRITER, Key.O), new Data("P", TYPE_KEY_WRITER, Key.P), new Data("[", TYPE_KEY_WRITER, Key.OemOpenBrackets),
                new Data("]", TYPE_KEY_WRITER, Key.OemCloseBrackets), new Data("|", TYPE_KEY_WRITER, Key.OemBackslash), new Data("Del", TYPE_KEY_FUNCTIONAL_BLOCK, Key.Delete),
                new Data("End", TYPE_KEY_FUNCTIONAL_BLOCK, Key.End), new Data("Pd", TYPE_KEY_FUNCTIONAL_BLOCK, Key.PageDown),

                new Data("CAPS", TYPE_KEY_FUNCTIONAL_BLOCK, Key.CapsLock), new Data("A", TYPE_KEY_WRITER, Key.A), new Data("S", TYPE_KEY_WRITER, Key.S),
                new Data("D", TYPE_KEY_WRITER, Key.D), new Data("F", TYPE_KEY_WRITER, Key.F), new Data("G", TYPE_KEY_WRITER, Key.G),
                new Data("H", TYPE_KEY_WRITER, Key.H), new Data("J", TYPE_KEY_WRITER, Key.J), new Data("K", TYPE_KEY_WRITER, Key.K),
                new Data("L", TYPE_KEY_WRITER, Key.L), new Data(";", TYPE_KEY_WRITER, Key.OemSemicolon), new Data("'", TYPE_KEY_WRITER, Key.OemQuotes),
                new Data("Enter", TYPE_KEY_FUNCTIONAL_BLOCK, Key.Enter),

                new Data("SHIFT", TYPE_KEY_FUNCTIONAL_BLOCK, Key.LeftShift), new Data("Z", TYPE_KEY_WRITER, Key.Z),  new Data("X", TYPE_KEY_WRITER, Key.X),
                new Data("C", TYPE_KEY_WRITER, Key.C), new Data("V", TYPE_KEY_WRITER, Key.V), new Data("B", TYPE_KEY_WRITER, Key.B),
                new Data("N", TYPE_KEY_WRITER, Key.N), new Data("M", TYPE_KEY_WRITER, Key.M), new Data("<", TYPE_KEY_WRITER, Key.OemComma),
                new Data(">", TYPE_KEY_WRITER, Key.OemPeriod), new Data("/", TYPE_KEY_WRITER, Key.OemQuestion), new Data("UpArrow", TYPE_KEY_COURCOR_CONTROL_KEYS, Key.Up),

                new Data("CTRL", TYPE_KEY_FUNCTIONAL_BLOCK, Key.LeftCtrl), new Data("L.WIN", TYPE_KEY_SYSTEM_KEYS, Key.LWin), new Data("ALT", TYPE_KEY_FUNCTIONAL_BLOCK, Key.LeftAlt),
                new Data("SPACE", TYPE_KEY_FUNCTIONAL_BLOCK, Key.Space), new Data("DownArrow", TYPE_KEY_COURCOR_CONTROL_KEYS, Key.Down),
                new Data("LeftArrow", TYPE_KEY_COURCOR_CONTROL_KEYS, Key.Left), new Data("RightArrow", TYPE_KEY_COURCOR_CONTROL_KEYS, Key.Right),

                new Data("NumLock", TYPE_KEY_NUMERIC_KEYPAD, Key.NumLock), new Data("Num /", TYPE_KEY_NUMERIC_KEYPAD, Key.Divide), new Data("Num *", TYPE_KEY_NUMERIC_KEYPAD, Key.Multiply), 
                new Data("Num -", TYPE_KEY_NUMERIC_KEYPAD, Key.Subtract), new Data("Num 7", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad7), new Data("Num 8", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad8),
                new Data("Num 9", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad9), new Data("Num +", TYPE_KEY_NUMERIC_KEYPAD, Key.Add), new Data("Num 4", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad4),  
                new Data("Num 5", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad5), new Data("Num 6", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad6), new Data("Num 1", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad1),
                new Data("Num 2", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad2), new Data("Num 3", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad3), new Data("Num Enter", TYPE_KEY_NUMERIC_KEYPAD, Key.Enter),
                new Data("Num 0", TYPE_KEY_NUMERIC_KEYPAD, Key.NumPad0), new Data("Num .", TYPE_KEY_NUMERIC_KEYPAD, Key.Decimal),

                new Data("Right Win", TYPE_KEY_SYSTEM_KEYS, Key.RWin), new Data("Right Shift", TYPE_KEY_FUNCTIONAL_BLOCK, Key.RightShift),
                new Data("Right Ctrl", TYPE_KEY_FUNCTIONAL_BLOCK, Key.RightCtrl), new Data("Right Alt", TYPE_KEY_FUNCTIONAL_BLOCK, Key.RightAlt),
                new Data("F13", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F13), new Data("F14", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F14), new Data("F15", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F15),
                new Data("F16", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F15), new Data("F17", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F17), new Data("F18", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F18),
                new Data("F19", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F19), new Data("F20", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F20), new Data("F21", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F21),
                new Data("F22", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F22), new Data("F23", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F23), new Data("F24", TYPE_KEY_FUNCTIONAL_BLOCK, Key.F24)
            };

            try
            {
                if (!Directory.Exists(MainWindow.directory))
                    Directory.CreateDirectory(MainWindow.directory);
                
                if(!File.Exists(MainWindow.directoryFile))
                    SaveToXml(MainWindow.directoryFile, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex}");
            }
        }
        public void UpdateFileData()
        {
            DataFile dataFile = new DataFile();
            var fileData = dataFile.LoadFileData(MainWindow.directoryFile);

            foreach (var data in fileData)
            {
                foreach (var statsList in StatisticsList.StatisticsKeyboard)
                {
                    if (data.KeyID == statsList.KeyID)
                    {
                        // All time stats
                        data.DataCountClicked.CountAllTimeClickedKey = statsList.DataCountClicked.CountAllTimeClickedKey;

                        // Day stats
                        var dayUpdateFile = data.DataCountClicked.DataDayClicked.DayNumber;
                        var monthUpdateFile = data.DataCountClicked.DataDayClicked.MonthNumber;
                        var yearUpdateFile = data.DataCountClicked.DataDayClicked.YearNumber;

                        DateTime dateUpdateFile = new DateTime(int.Parse(yearUpdateFile), int.Parse(monthUpdateFile), int.Parse(dayUpdateFile));
                        DateTime dateNow = DateTime.Today;

                        //if (dayUpdateFile != DateTime.Today.ToString("dd") ||
                        //    (dayUpdateFile == DateTime.Today.ToString("dd") && (monthUpdateFile != DateTime.Today.ToString("MM") || (monthUpdateFile == DateTime.Today.ToString("MM") && yearUpdateFile != DateTime.Today.ToString("yyy")))))
                        if(dateUpdateFile != dateNow)
                        {
                            data.DataCountClicked.DataDayClicked.YearNumber = DateTime.Today.ToString("yyy");
                            data.DataCountClicked.DataDayClicked.MonthNumber = DateTime.Today.ToString("MM");
                            data.DataCountClicked.DataDayClicked.DayNumber = DateTime.Today.ToString("dd");
                            data.DataCountClicked.DataDayClicked.CountDayClicked = 0;
                        }
                        else
                            data.DataCountClicked.DataDayClicked.CountDayClicked = statsList.DataCountClicked.DataDayClicked.CountDayClicked;

                        // Week stats
                        DateTime dateTime = DateTime.Now;
                        data.DataCountClicked.DataWeekClicked.DayOfWeek = (int)dateTime.DayOfWeek;

                        DateTime dateLastMonday;
                        if(dateTime.DayOfWeek == DayOfWeek.Sunday)
                            dateLastMonday = dateTime.AddDays(-((int)dateTime.DayOfWeek+6));
                        else
                            dateLastMonday = dateTime.AddDays(-(int)dateTime.DayOfWeek+1);

                        dateLastMonday = dateLastMonday.AddHours(-dateTime.Hour);
                        dateLastMonday = dateLastMonday.AddMinutes(-dateTime.Minute);
                        dateLastMonday = dateLastMonday.AddSeconds(-dateTime.Second);

                        var weekDayUpdateFile = data.DataCountClicked.DataWeekClicked.LastDayUpdate;
                        var weekMonthUpdateFile = data.DataCountClicked.DataWeekClicked.LastMonthUpdate;
                        var weekYearUpdateFile = data.DataCountClicked.DataWeekClicked.LastYearUpdate;

                        DateTime dateMondayFile = new DateTime(int.Parse(weekYearUpdateFile), int.Parse(weekMonthUpdateFile), int.Parse(weekDayUpdateFile));

                        DateTime[] dateWeekLastMonday = { new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime() };
                        const int DAY_IN_WEEK = 7;
                        for (int i = 0; i < DAY_IN_WEEK; i++)
                        {
                            if (i != 0)
                                dateLastMonday = dateLastMonday.AddDays(1);

                            dateWeekLastMonday[i] = new DateTime(dateLastMonday.Year, dateLastMonday.Month, dateLastMonday.Day);
                        }

                        for (int i = 0; i < dateWeekLastMonday.Length; i++)
                        {
                            if(dateMondayFile != dateWeekLastMonday[i] && i == DAY_IN_WEEK-1)
                            {
                                data.DataCountClicked.DataWeekClicked.LastYearUpdate = dateLastMonday.ToString("yyy");
                                data.DataCountClicked.DataWeekClicked.LastMonthUpdate = dateLastMonday.ToString("MM");
                                data.DataCountClicked.DataWeekClicked.LastDayUpdate = dateLastMonday.ToString("dd");
                                data.DataCountClicked.DataWeekClicked.CountWeekClicked = 0;
                                break;
                            }
                            else if(dateMondayFile == dateWeekLastMonday[i])
                            {
                                data.DataCountClicked.DataWeekClicked.CountWeekClicked = statsList.DataCountClicked.DataWeekClicked.CountWeekClicked;
                                break;
                            }
                        }

                        // Month stats
                        var valueMonthUpdateFile = data.DataCountClicked.DataMonthClicked.MonthNumber;
                        var valueYearUpdateFile = data.DataCountClicked.DataMonthClicked.YearNumber;

                        if(valueMonthUpdateFile != DateTime.Today.ToString("MM") || (valueMonthUpdateFile == DateTime.Today.ToString("MM") && valueYearUpdateFile != DateTime.Today.ToString("yyy")))
                        {
                            data.DataCountClicked.DataMonthClicked.YearNumber = DateTime.Today.ToString("yyy");
                            data.DataCountClicked.DataMonthClicked.MonthNumber = DateTime.Today.ToString("MM");
                            data.DataCountClicked.DataMonthClicked.CountMonthClicked = 0;
                        }   
                        else
                            data.DataCountClicked.DataMonthClicked.CountMonthClicked = statsList.DataCountClicked.DataMonthClicked.CountMonthClicked;

                        // Year stats
                        if (data.DataCountClicked.DataYearClicked.YearNumber != DateTime.Today.ToString("yyy"))
                        {
                            data.DataCountClicked.DataYearClicked.YearNumber = DateTime.Today.ToString("yyy");
                            data.DataCountClicked.DataYearClicked.CountYearClicked = 0;
                        }
                        else
                            data.DataCountClicked.DataYearClicked.CountYearClicked = statsList.DataCountClicked.DataYearClicked.CountYearClicked;
                    }
                }
            }
            SaveToXml(MainWindow.directoryFile, fileData);
        }

        public void SaveToXml<T>(string fileName, T serializableObject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(textWriter, serializableObject);
            }
        }
        public T LoadXml<T>(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StreamReader(fileName))
            {
                return (T)serializer.Deserialize(textReader);
            }
        }

        public Data[] LoadFileData(in string file)
        {
            if (File.Exists(file))
                return LoadXml<Data[]>(file);
            else
                return null;
        }
    }
    public class Data
    {
        public string NameKey { get; set; }
        public DataCountClickKey DataCountClicked { get; set; } = new DataCountClickKey();
        public string TypeKey { get; set; }
        public Key KeyID { get; set; }

        public Data() { }
        public Data(string nameKey, string typeKey, Key keyID)
        {
            NameKey = nameKey;
            
            // Stats for the all time
            DataCountClicked.CountAllTimeClickedKey = 0;

            // Stats for the day
            DataCountClicked.DataDayClicked.YearNumber = DateTime.Today.ToString("yyy");
            DataCountClicked.DataDayClicked.MonthNumber = DateTime.Today.ToString("MM");
            DataCountClicked.DataDayClicked.DayNumber = DateTime.Today.ToString("dd");
            DataCountClicked.DataDayClicked.CountDayClicked = 0;

            // Stats for the week
            DateTime dateTime = DateTime.Now;
            var dateMonday = dateTime.AddDays(-(int)dateTime.DayOfWeek + 1);

            DataCountClicked.DataWeekClicked.DayOfWeek = (int) dateTime.DayOfWeek;
            DataCountClicked.DataWeekClicked.LastYearUpdate = dateMonday.ToString("yyy");
            DataCountClicked.DataWeekClicked.LastMonthUpdate = dateMonday.ToString("MM");
            DataCountClicked.DataWeekClicked.LastDayUpdate = dateMonday.ToString("dd");
            DataCountClicked.DataWeekClicked.CountWeekClicked = 0;

            // Stats for the month
            DataCountClicked.DataMonthClicked.YearNumber = DateTime.Today.ToString("yyy");
            DataCountClicked.DataMonthClicked.MonthNumber = DateTime.Today.ToString("MM");
            DataCountClicked.DataMonthClicked.CountMonthClicked = 0;

            // Stats for the year
            DataCountClicked.DataYearClicked.YearNumber = DateTime.Today.ToString("yyy");
            DataCountClicked.DataYearClicked.CountYearClicked = 0;

            TypeKey = typeKey;
            KeyID = keyID;
        }
    }

    public class DataCountClickKey
    {
        public int CountAllTimeClickedKey { get; set; } = 0;
        public DataDayCountClicked DataDayClicked { get; set; } = new DataDayCountClicked();
        public DataWeekCountClicked DataWeekClicked { get; set; } = new DataWeekCountClicked();
        public DataMonthCountClicked DataMonthClicked { get; set; } = new DataMonthCountClicked();
        public DataYearCountClicked DataYearClicked { get; set; } = new DataYearCountClicked();
    }
    public class DataDayCountClicked
    {
        public string YearNumber { get; set; }
        public string MonthNumber { get; set; }
        public string DayNumber { get; set; }
        public int CountDayClicked { get; set; } = 0;
    }
    public class DataWeekCountClicked
    {
        public int DayOfWeek { get; set; }
        public string LastDayUpdate { get; set; }
        public string LastMonthUpdate { get; set; }
        public string LastYearUpdate { get; set; }
        public int CountWeekClicked { get; set; } = 0;
    }
    public class DataMonthCountClicked
    {
        public string YearNumber { get; set; }
        public string MonthNumber { get; set; }
        public int CountMonthClicked { get; set; } = 0;
    }
    public class DataYearCountClicked
    {
        public string YearNumber { get; set; }
        public int CountYearClicked { get; set; } = 0;
    }
}
