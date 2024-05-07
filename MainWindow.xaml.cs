using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Threading;
using System.Collections.ObjectModel;

namespace CountClickKey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool _isOpenBorderActionTool = false;
        private static string _openWindow = null;

        public static string directoryFile = Path.GetFullPath("data.xml");
        public static string directory = Directory.GetCurrentDirectory();

        public static string SELECT_TYPE_KEYS = "";
        public static string SELECT_TYPE_PERIOD = "";

        public MainWindow()
        {
            InitializeComponent();

            textVersionApp.Text = SettingApp.VERSION_APP;
            _openWindow = SettingApp.NAME_PAGE_MAIN;

            SELECT_TYPE_KEYS = SettingApp.TYPE_ALL_KEYS;
            SELECT_TYPE_PERIOD = SettingApp.TYPE_ALL_TIME_PERIOD;

            if(DesignStatistics.AllKeyboard != null)
            {
                DesignStatistics.AllKeyboard.Clear();
                DesignStatistics.AllKeyboard = null;
                DesignStatistics.AllKeyboard = new ObservableCollection<StackPanel>();
            }
        }

        static MainWindow()
        {
            DataFile dataFile = new DataFile();
            dataFile.CheckExistsFile();

            StatisticsList statsList = new StatisticsList();
            statsList.CreateStaticsList();

            // Start keylogger in another thread and close GUI
            Thread keyloggerThread = new Thread(() =>
            {
                new Controller().StartMonitor();
            });
            keyloggerThread.SetApartmentState(ApartmentState.STA);
            keyloggerThread.Start();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonCloseApp_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void ButtonMinimizeApp_Click(object sender, RoutedEventArgs e) => Close();
        private void ButtonActionTool_Click(object sender, RoutedEventArgs e)
        {
            ChangeStatusActionTool();
        }
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            if (_openWindow != SettingApp.NAME_PAGE_MAIN)
            {
                _openWindow = SettingApp.NAME_PAGE_MAIN;
                OnSelectButtonWindow();

                borderVersionApp.Visibility = Visibility;
                MainContentWindow.Visibility = Visibility;

                StatsContentWindow.Visibility = Visibility.Collapsed;
                SupportContentWindow.Visibility = Visibility.Collapsed;

                if (_isOpenBorderActionTool == true)
                    ChangeStatusActionTool();
            }
        }
        private void ButtonStats_Click(object sender, RoutedEventArgs e)
        {
            if (_openWindow != SettingApp.NAME_PAGE_STATS)
            {
                _openWindow = SettingApp.NAME_PAGE_STATS;
                OnSelectButtonWindow();

                MainContentWindow.Visibility = Visibility.Collapsed;
                borderVersionApp.Visibility = Visibility.Collapsed;
                SupportContentWindow.Visibility = Visibility.Collapsed;

                StatsContentWindow.Visibility = Visibility;

                if (_isOpenBorderActionTool == true)
                    ChangeStatusActionTool();

                ShowDesignStatistics();

                ChangeColorPeriodTimeStats();
                ChangeColorTypeKeyStats();
            }
        }
        private void ButtonSupport_Click(object sender, RoutedEventArgs e)
        {
            if (_openWindow != SettingApp.NAME_PAGE_SUPPORT)
            {
                _openWindow = SettingApp.NAME_PAGE_SUPPORT;
                OnSelectButtonWindow();

                MainContentWindow.Visibility = Visibility.Collapsed;
                StatsContentWindow.Visibility = Visibility.Collapsed;

                SupportContentWindow.Visibility = Visibility.Visible;
                borderVersionApp.Visibility = Visibility;

                if (_isOpenBorderActionTool == true)
                    ChangeStatusActionTool();
            }
        }
        private void ButtonArrowAsk_Click(object sender, RoutedEventArgs e)
        {
            Style styleCloseButtonArrowAsk = FindResource("StyleButtonArrowToAsk") as Style;
            Style styleOpenButtonArrowAsk = FindResource("StyleOpenButtonArrowToAsk") as Style;

            FrameworkElement sourceFrameworkElemnt = e.Source as FrameworkElement;

            switch (sourceFrameworkElemnt.Name)
            {
                case "buttonArrowAsk1":
                    if (buttonArrowAsk1.Style == styleCloseButtonArrowAsk)
                    {
                        buttonArrowAsk1.Style = styleOpenButtonArrowAsk;
                        borderSeparatorAsk1.Visibility = Visibility.Visible;
                        textAnsverToAsk1.Visibility = Visibility.Visible;
                        borderAsk1.Height = 190;
                    }
                    else if (buttonArrowAsk1.Style == styleOpenButtonArrowAsk)
                    {
                        buttonArrowAsk1.Style = styleCloseButtonArrowAsk;
                        borderSeparatorAsk1.Visibility = Visibility.Collapsed;
                        textAnsverToAsk1.Visibility = Visibility.Collapsed;
                        borderAsk1.Height = 49;
                    }
                    break;
                case "buttonArrowAsk2":
                    if (buttonArrowAsk2.Style == styleCloseButtonArrowAsk)
                    {
                        buttonArrowAsk2.Style = styleOpenButtonArrowAsk;
                        borderSeparatorAsk2.Visibility = Visibility.Visible;
                        textAnsverToAsk2.Visibility = Visibility.Visible;
                        borderAsk2.Height = 385;
                    }
                    else if (buttonArrowAsk2.Style == styleOpenButtonArrowAsk)
                    {
                        buttonArrowAsk2.Style = styleCloseButtonArrowAsk;
                        borderSeparatorAsk2.Visibility = Visibility.Collapsed;
                        textAnsverToAsk2.Visibility = Visibility.Collapsed;
                        borderAsk2.Height = 49;
                    }
                    break;
            }
        }

        private void ButtonStatsPeriod_Click(object sender, RoutedEventArgs e)
        {
            Style styleNotSelectPeriod = FindResource("StyleButtonStatsTime") as Style;
            Style styleSelectPeriod = FindResource("StyleSelectButtonStatsTime") as Style;

            buttonStatsAllTime.Style = styleNotSelectPeriod;
            buttonStatsDay.Style = styleNotSelectPeriod;
            buttonStatsWeek.Style = styleNotSelectPeriod;
            buttonStatsMonth.Style = styleNotSelectPeriod;
            buttonStatsYear.Style = styleNotSelectPeriod;

            FrameworkElement sourceFrameworkElemnt = e.Source as FrameworkElement;

            switch (sourceFrameworkElemnt.Name)
            {
                case "buttonStatsAllTime":
                    buttonStatsAllTime.Style = styleSelectPeriod;
                    SELECT_TYPE_PERIOD = SettingApp.TYPE_ALL_TIME_PERIOD;
                    break;
                case "buttonStatsDay":
                    buttonStatsDay.Style = styleSelectPeriod;
                    SELECT_TYPE_PERIOD = SettingApp.TYPE_DAY_PERIOD;
                    break;
                case "buttonStatsWeek":
                    buttonStatsWeek.Style = styleSelectPeriod;
                    SELECT_TYPE_PERIOD = SettingApp.TYPE_WEEK_PERIOD;
                    break;
                case "buttonStatsMonth":
                    buttonStatsMonth.Style = styleSelectPeriod;
                    SELECT_TYPE_PERIOD = SettingApp.TYPE_MONTH_PERIOD;
                    break;
                case "buttonStatsYear":
                    buttonStatsYear.Style = styleSelectPeriod;
                    SELECT_TYPE_PERIOD = SettingApp.TYPE_YEAR_PERIOD;
                    break;
            }
            ShowDesignStatistics();
        }
        private void ButtonStatsType_Click(object sender, RoutedEventArgs e)
        {
            Style styleNotSelectPeriod = FindResource("StyleButtonStatsTime") as Style;
            Style styleSelectPeriod = FindResource("StyleSelectButtonStatsTime") as Style;

            buttonTypeAllKeys.Style = styleNotSelectPeriod;
            buttonTypeWriterKeys.Style = styleNotSelectPeriod;
            buttonTypeNumericKeypad.Style = styleNotSelectPeriod;
            buttonTypeFunctionalBlock.Style = styleNotSelectPeriod;

            FrameworkElement sourceFrameworkElemnt = e.Source as FrameworkElement;

            switch(sourceFrameworkElemnt.Name)
            {
                case "buttonTypeAllKeys":
                    buttonTypeAllKeys.Style = styleSelectPeriod;
                    SELECT_TYPE_KEYS = SettingApp.TYPE_ALL_KEYS;
                    break;
                case "buttonTypeWriterKeys":
                    buttonTypeWriterKeys.Style = styleSelectPeriod;
                    SELECT_TYPE_KEYS = SettingApp.TYPE_WRITER_KEYS;
                    break;
                case "buttonTypeNumericKeypad":
                    buttonTypeNumericKeypad.Style = styleSelectPeriod;
                    SELECT_TYPE_KEYS = SettingApp.TYPE_NUMERIC_KEYPAD;
                    break;
                case "buttonTypeFunctionalBlock":
                    buttonTypeFunctionalBlock.Style = styleSelectPeriod;
                    SELECT_TYPE_KEYS = SettingApp.TYPE_FUNCTION_BLOCK;
                    break;
            }

            ShowDesignStatistics();
        }

        private void ShowDesignStatistics()
        {
            DesignStatistics designStats = new DesignStatistics();
            designStats.RemoveDesighnStatistics();

            designStats.CreateDesignStatistics();
            this.DataContext = designStats;
        }
        private void ChangeStatusActionTool()
        {
            if (_isOpenBorderActionTool == false)
            {
                borderActionTool.Width = 176;
                _isOpenBorderActionTool = true;
                Canvas.SetZIndex(borderActionTool, 1);
            }
            else
            {
                borderActionTool.Width = 56;
                _isOpenBorderActionTool = false;
            }

            ChangeStyleButtonHome();

            ChangeStyleButtonStats();

            ChangeStyleButtonSupport();

            OnSelectButtonWindow();
        }
        private void OnSelectButtonWindow()
        {
            Style notSelectStackPanel = this.FindResource("NotSelectStackPanel") as Style;

            spHome.Style = notSelectStackPanel;
            spStats.Style = notSelectStackPanel;
            spSupport.Style = notSelectStackPanel;

            if (_isOpenBorderActionTool == true)
            {
                Style selectStackPanelStyle = this.FindResource("SelectStackPanel") as Style;

                if(_openWindow == SettingApp.NAME_PAGE_MAIN)
                {
                    spHome.Style = selectStackPanelStyle;
                    buttonHome.Focusable = false;
                    buttonHomeText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#B0B0B0"));
                }
                else if (_openWindow == SettingApp.NAME_PAGE_STATS)
                {
                    spStats.Style = selectStackPanelStyle;
                    buttonStats.Focusable = false;
                    buttonStatsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#B0B0B0"));
                }
                else if (_openWindow == SettingApp.NAME_PAGE_SUPPORT)
                {
                    spSupport.Style = selectStackPanelStyle;
                    buttonSupport.Focusable = false;
                    buttonSupport.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#B0B0B0"));
                }
            }
        }
        private void ChangeStyleButtonHome()
        {
            if (_isOpenBorderActionTool == true)
            {
                buttonHome.IsEnabled = false;

                buttonHomeText.Visibility = Visibility;
                buttonHomeText.IsEnabled = true;
            }
            else
            {
                buttonHome.IsEnabled = true;

                buttonHomeText.Visibility = Visibility.Hidden;
                buttonHomeText.IsEnabled = false;
            }
        }
        private void ChangeStyleButtonStats()
        {
            if (_isOpenBorderActionTool == true)
            {
                buttonStats.IsEnabled = false;

                buttonStatsText.Visibility = Visibility;
                buttonStatsText.IsEnabled = true;
            }
            else
            {
                buttonStats.IsEnabled = true;

                buttonStatsText.Visibility = Visibility.Hidden;
                buttonStatsText.IsEnabled = false;
            }
        }
        private void ChangeStyleButtonSupport()
        {
            if (_isOpenBorderActionTool == true)
            {
                buttonSupport.IsEnabled = false;

                buttonSupportText.Visibility = Visibility;
                buttonSupportText.IsEnabled = true;
            }
            else
            {
                buttonSupport.IsEnabled = true;

                buttonSupportText.Visibility = Visibility.Hidden;
                buttonSupportText.IsEnabled = false;
            }
        }
        private void ChangeColorPeriodTimeStats()
        {
            Style styleSelectPeriod = FindResource("StyleSelectButtonStatsTime") as Style;
            Style styleNotSelectPeriod = FindResource("StyleButtonStatsTime") as Style;

            buttonStatsAllTime.Style = styleNotSelectPeriod;
            buttonStatsDay.Style = styleNotSelectPeriod;
            buttonStatsWeek.Style = styleNotSelectPeriod;
            buttonStatsMonth.Style = styleNotSelectPeriod;
            buttonStatsYear.Style = styleNotSelectPeriod;

            if (SELECT_TYPE_PERIOD == SettingApp.TYPE_ALL_TIME_PERIOD)
                buttonStatsAllTime.Style = styleSelectPeriod;
            else if(SELECT_TYPE_PERIOD == SettingApp.TYPE_DAY_PERIOD)
                buttonStatsDay.Style = styleSelectPeriod;
            else if(SELECT_TYPE_PERIOD == SettingApp.TYPE_WEEK_PERIOD)
                buttonStatsWeek.Style = styleSelectPeriod;
            else if(SELECT_TYPE_PERIOD == SettingApp.TYPE_MONTH_PERIOD)
                buttonStatsMonth.Style = styleSelectPeriod;
            else if(SELECT_TYPE_PERIOD == SettingApp.TYPE_YEAR_PERIOD)
                buttonStatsYear.Style = styleSelectPeriod;
        }
        private void ChangeColorTypeKeyStats()
        {
            Style styleSelectPeriod = FindResource("StyleSelectButtonStatsTime") as Style;
            Style styleNotSelectPeriod = FindResource("StyleButtonStatsTime") as Style;

            buttonTypeAllKeys.Style = styleNotSelectPeriod;
            buttonTypeWriterKeys.Style = styleNotSelectPeriod;
            buttonTypeNumericKeypad.Style = styleNotSelectPeriod;
            buttonTypeFunctionalBlock.Style = styleNotSelectPeriod;

            if (SELECT_TYPE_KEYS == SettingApp.TYPE_ALL_KEYS)
                buttonTypeAllKeys.Style = styleSelectPeriod;
            else if (SELECT_TYPE_KEYS == SettingApp.TYPE_WRITER_KEYS)
                buttonTypeWriterKeys.Style = styleSelectPeriod;
            else if (SELECT_TYPE_PERIOD == SettingApp.TYPE_NUMERIC_KEYPAD)
                buttonTypeNumericKeypad.Style = styleSelectPeriod;
            else if (SELECT_TYPE_KEYS == SettingApp.TYPE_FUNCTION_BLOCK)
                buttonTypeFunctionalBlock.Style = styleSelectPeriod;
        }
    }

    public class SettingApp
    {
        public static readonly string VERSION_APP = "Version 1.1";

        public static readonly string NAME_PAGE_MAIN = "Main";
        public static readonly string NAME_PAGE_STATS = "Stats";
        public static readonly string NAME_PAGE_SUPPORT = "Support";

        public static readonly string TYPE_ALL_KEYS = "All keys";
        public static readonly string TYPE_WRITER_KEYS = "Writer keys";
        public static readonly string TYPE_NUMERIC_KEYPAD = "Numeric Keypad";
        public static readonly string TYPE_FUNCTION_BLOCK = "Functional block";

        public static readonly string TYPE_ALL_TIME_PERIOD = "All time";
        public static readonly string TYPE_DAY_PERIOD = "Day";
        public static readonly string TYPE_WEEK_PERIOD = "Week";
        public static readonly string TYPE_MONTH_PERIOD = "Month";
        public static readonly string TYPE_YEAR_PERIOD = "Year";
    }
}