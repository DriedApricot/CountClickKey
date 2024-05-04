using System.Collections.Generic;
using System.Windows.Input;

namespace CountClickKey
{
    public class StatisticsList
    {
        public static List<DataKeyboard> StatisticsKeyboard = null;

        public void CreateStaticsList()
        {
            DataFile dataFile = new DataFile();

            Data[] fileData = dataFile.LoadFileData(in MainWindow.directoryFile);

            StatisticsKeyboard = new List<DataKeyboard>();

            foreach (var data in fileData)
            {
                StatisticsKeyboard.Add(new DataKeyboard(data));
            }

            dataFile.UpdateFileData();
            UpdateStatisticsList();
        }

        public void UpdateStatisticsList()
        {
            DataFile dataFile = new DataFile();

            Data[] fileData = dataFile.LoadFileData(in MainWindow.directoryFile);

            foreach (var data in fileData)
            {
                foreach (var statsList in StatisticsKeyboard)
                {
                    if(data.KeyID == statsList.KeyID)
                    {
                        // All time stats
                        statsList.DataCountClicked.CountAllTimeClickedKey = data.DataCountClicked.CountAllTimeClickedKey;

                        // Day stats
                        statsList.DataCountClicked.DataDayClicked.CountDayClicked = data.DataCountClicked.DataDayClicked.CountDayClicked;
                        statsList.DataCountClicked.DataDayClicked.YearNumber = data.DataCountClicked.DataDayClicked.YearNumber;
                        statsList.DataCountClicked.DataDayClicked.MonthNumber = data.DataCountClicked.DataDayClicked.MonthNumber;
                        statsList.DataCountClicked.DataDayClicked.DayNumber = data.DataCountClicked.DataDayClicked.DayNumber;

                        // Week stats
                        statsList.DataCountClicked.DataWeekClicked.CountWeekClicked = data.DataCountClicked.DataWeekClicked.CountWeekClicked;
                        statsList.DataCountClicked.DataWeekClicked.DayOfWeek = data.DataCountClicked.DataWeekClicked.DayOfWeek;
                        statsList.DataCountClicked.DataWeekClicked.LastYearUpdate = data.DataCountClicked.DataWeekClicked.LastYearUpdate;
                        statsList.DataCountClicked.DataWeekClicked.LastMonthUpdate = data.DataCountClicked.DataWeekClicked.LastMonthUpdate;
                        statsList.DataCountClicked.DataWeekClicked.LastDayUpdate = data.DataCountClicked.DataWeekClicked.LastDayUpdate;
                        statsList.DataCountClicked.DataWeekClicked.CountWeekClicked = data.DataCountClicked.DataWeekClicked.CountWeekClicked;

                        // Month stats
                        statsList.DataCountClicked.DataMonthClicked.CountMonthClicked = data.DataCountClicked.DataMonthClicked.CountMonthClicked;
                        statsList.DataCountClicked.DataMonthClicked.YearNumber = data.DataCountClicked.DataMonthClicked.YearNumber;
                        statsList.DataCountClicked.DataMonthClicked.MonthNumber = data.DataCountClicked.DataMonthClicked.MonthNumber;

                        // Year stats
                        statsList.DataCountClicked.DataYearClicked.CountYearClicked = data.DataCountClicked.DataYearClicked.CountYearClicked;
                        statsList.DataCountClicked.DataYearClicked.YearNumber = data.DataCountClicked.DataYearClicked.YearNumber;
                    }
                }
            }
        }
    }

    public class DataKeyboard
    {
        public string NameKey { get; set; }
        public DataCountClickKey DataCountClicked { get; set; } = new DataCountClickKey();
        public string TypeKeys { get; set; }
        public Key KeyID { get; set; }

        public DataKeyboard() { }
        public DataKeyboard(Data data)
        {
            NameKey = data.NameKey;
            TypeKeys = data.TypeKey;
            KeyID = data.KeyID;

            // Stats for the all time
            this.DataCountClicked.CountAllTimeClickedKey = data.DataCountClicked.CountAllTimeClickedKey;

            // Stats for the day
            this.DataCountClicked.DataDayClicked.YearNumber = data.DataCountClicked.DataDayClicked.YearNumber;
            this.DataCountClicked.DataDayClicked.MonthNumber = data.DataCountClicked.DataDayClicked.MonthNumber;
            this.DataCountClicked.DataDayClicked.DayNumber = data.DataCountClicked.DataDayClicked.DayNumber;
            this.DataCountClicked.DataDayClicked.CountDayClicked = data.DataCountClicked.DataDayClicked.CountDayClicked;

            // Stats for the week
            this.DataCountClicked.DataWeekClicked.DayOfWeek = data.DataCountClicked.DataWeekClicked.DayOfWeek;
            this.DataCountClicked.DataWeekClicked.LastYearUpdate = data.DataCountClicked.DataWeekClicked.LastYearUpdate;
            this.DataCountClicked.DataWeekClicked.LastMonthUpdate = data.DataCountClicked.DataWeekClicked.LastMonthUpdate;
            this.DataCountClicked.DataWeekClicked.LastDayUpdate = data.DataCountClicked.DataWeekClicked.LastDayUpdate;
            this.DataCountClicked.DataWeekClicked.CountWeekClicked = data.DataCountClicked.DataWeekClicked.CountWeekClicked;

            // Stats for the month
            this.DataCountClicked.DataMonthClicked.YearNumber = data.DataCountClicked.DataMonthClicked.YearNumber;
            this.DataCountClicked.DataMonthClicked.MonthNumber = data.DataCountClicked.DataMonthClicked.MonthNumber;
            this.DataCountClicked.DataMonthClicked.CountMonthClicked = data.DataCountClicked.DataMonthClicked.CountMonthClicked;

            // Stats for the year
            this.DataCountClicked.DataYearClicked.YearNumber = data.DataCountClicked.DataYearClicked.YearNumber;
            this.DataCountClicked.DataYearClicked.CountYearClicked = data.DataCountClicked.DataYearClicked.CountYearClicked;
        }
    }
}
