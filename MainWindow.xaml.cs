using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

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

            for (int i = 0; i < ComboBoxLanguageList.Items.Count; i++)
            {
                if (((ComboBoxItem)ComboBoxLanguageList.Items.GetItemAt(i)).Tag == Properties.Settings.Default.DefaultLanguage)
                    ComboBoxLanguageList.SelectedIndex = i;
            }

            List<string> styleTheme = new List<string> { "Light", "Dark" };
            ComboBoxThemeList.SelectionChanged += ThemeChange;
            for(int i = 0; i < ComboBoxThemeList.Items.Count; i++)
            {
                if (((ComboBoxItem)ComboBoxThemeList.Items.GetItemAt(i)).Tag.ToString() == Properties.Settings.Default.DefaultTheme)
                    ComboBoxThemeList.SelectedIndex = i;
            }

            _openWindow = SettingApp.NAME_PAGE_MAIN;

            SELECT_TYPE_KEYS = SettingApp.TYPE_ALL_KEYS;
            SELECT_TYPE_PERIOD = SettingApp.TYPE_ALL_TIME_PERIOD;

            if(CountClickKey.Statistics.DesignStatistics.AllKeyboard != null)
            {
                CountClickKey.Statistics.DesignStatistics.AllKeyboard.Clear();
                CountClickKey.Statistics.DesignStatistics.AllKeyboard = null;
                CountClickKey.Statistics.DesignStatistics.AllKeyboard = new ObservableCollection<StackPanel>();
            }
            DataContext = new MainViewModel();

            OnSelectButtonWindow();
        }

        static MainWindow()
        {
            CountClickKey.Statistics.DataFile dataFile = new CountClickKey.Statistics.DataFile();
            dataFile.CheckExistsFile();

            CountClickKey.Statistics.StatisticsList statsList = new CountClickKey.Statistics.StatisticsList();
            statsList.CreateStaticsList();

            // Start keylogger in another thread and close GUI
            Thread keyloggerThread = new Thread(() =>
            {
                new CountClickKey.Statistics.Controller().StartMonitor();
            });
            keyloggerThread.SetApartmentState(ApartmentState.STA);
            keyloggerThread.Start();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = ((ComboBoxItem)ComboBoxThemeList.Items.GetItemAt(ComboBoxThemeList.SelectedIndex)).Tag.ToString();

            if (style != null)
            {
                string themeFile = style.ToLower();

                var uri = new Uri("Resources/" + themeFile + "Theme" + ".xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

                Properties.Settings.Default.DefaultTheme = style;
                Properties.Settings.Default.Save();
            }
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
                SettingsContentWindow.Visibility = Visibility.Collapsed;

                if (_isOpenBorderActionTool == true)
                    ChangeStatusActionTool();

                DataContext = new MainViewModel();
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
                SettingsContentWindow.Visibility = Visibility.Collapsed;

                StatsContentWindow.Visibility = Visibility;

                if (_isOpenBorderActionTool == true)
                    ChangeStatusActionTool();

                ShowDesignStatistics();

                ChangeColorPeriodTimeStats();
                ChangeColorTypeKeyStats();
            }
        }
        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            if (_openWindow != SettingApp.NAME_PAGE_SETTINGS)
            {
                _openWindow = SettingApp.NAME_PAGE_SETTINGS;
                OnSelectButtonWindow();

                MainContentWindow.Visibility = Visibility.Collapsed;
                StatsContentWindow.Visibility = Visibility.Collapsed;
                SupportContentWindow.Visibility = Visibility.Collapsed;

                SettingsContentWindow.Visibility = Visibility;
                borderVersionApp.Visibility = Visibility;

                if (_isOpenBorderActionTool == true)
                    ChangeStatusActionTool();

                DataContext = new MainViewModel();
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
                SettingsContentWindow.Visibility = Visibility.Collapsed;

                SupportContentWindow.Visibility = Visibility.Visible;
                borderVersionApp.Visibility = Visibility;

                if (_isOpenBorderActionTool == true)
                    ChangeStatusActionTool();

                DataContext = new MainViewModel();
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
                        textFirstAnswerToFirstAsk.Visibility = Visibility.Visible;
                        textSecondAnswerToFirstAsk.Visibility = Visibility.Visible;
                        textThirdAnswerToFirstAsk.Visibility = Visibility.Visible;
                    }
                    else if (buttonArrowAsk1.Style == styleOpenButtonArrowAsk)
                    {
                        buttonArrowAsk1.Style = styleCloseButtonArrowAsk;
                        borderSeparatorAsk1.Visibility = Visibility.Collapsed;
                        textFirstAnswerToFirstAsk.Visibility = Visibility.Collapsed;
                        textSecondAnswerToFirstAsk.Visibility = Visibility.Collapsed;
                        textThirdAnswerToFirstAsk.Visibility = Visibility.Collapsed;
                    }
                    break;
                case "buttonArrowAsk2":
                    if (buttonArrowAsk2.Style == styleCloseButtonArrowAsk)
                    {
                        buttonArrowAsk2.Style = styleOpenButtonArrowAsk;
                        borderSeparatorAsk2.Visibility = Visibility.Visible;
                        textFirstAnswerToSecondAsk.Visibility = Visibility.Visible;
                        textSecondAnswerToSecondAsk.Visibility = Visibility.Visible;
                        textThirdAnswerToSecondAsk.Visibility = Visibility.Visible;
                        textFourthAnswerToSecondAsk.Visibility = Visibility.Visible;
                        textFifthAnswerToSecondAsk.Visibility = Visibility.Visible;
                    }
                    else if (buttonArrowAsk2.Style == styleOpenButtonArrowAsk)
                    {
                        buttonArrowAsk2.Style = styleCloseButtonArrowAsk;
                        borderSeparatorAsk2.Visibility = Visibility.Collapsed;
                        textFirstAnswerToSecondAsk.Visibility = Visibility.Collapsed;
                        textSecondAnswerToSecondAsk.Visibility = Visibility.Collapsed;
                        textThirdAnswerToSecondAsk.Visibility = Visibility.Collapsed;
                        textFourthAnswerToSecondAsk.Visibility = Visibility.Collapsed;
                        textFifthAnswerToSecondAsk.Visibility = Visibility.Collapsed;
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
            CountClickKey.Statistics.DesignStatistics designStats = new CountClickKey.Statistics.DesignStatistics();
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

            ChangeStyleButtonSettings();

            ChangeStyleButtonSupport();

            OnSelectButtonWindow();
        }
        private void ChangeColorIconActionTool()
        {
            buttonHome.Focusable = false;
            if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Light")
                buttonHomeText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#A09F9F"));
            else if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Dark")
                buttonHomeText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#818080"));

            buttonStats.Focusable = false;
            if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Light")
                buttonStatsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#A09F9F"));
            else if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Dark")
                buttonStatsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#818080"));

            buttonSettings.Focusable = false;
            if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Light")
                buttonSettingsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#A09F9F"));
            else if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Dark")
                buttonSettingsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#818080"));

            buttonSupport.Focusable = false;
            if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Light")
                buttonStatsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#A09F9F"));
            else if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Dark")
                buttonSupportText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#818080"));
        }
        private void OnSelectButtonWindow()
        {
            Style notSelectStackPanel = this.FindResource("NotSelectStackPanel") as Style;

            spHome.Style = notSelectStackPanel;
            spStats.Style = notSelectStackPanel;
            spSupport.Style = notSelectStackPanel;
            spSettings.Style = notSelectStackPanel;

            ChangeColorIconActionTool();

            if (_isOpenBorderActionTool == true)
            {
                Style selectStackPanelStyle = this.FindResource("SelectStackPanel") as Style;

                if (_openWindow == SettingApp.NAME_PAGE_MAIN)
                {
                    spHome.Style = selectStackPanelStyle;
                    buttonHome.Focusable = true;
                    if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Light")
                        buttonHomeText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#B0B0B0"));
                    else if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Dark")
                        buttonHomeText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#D0D0D0"));
                }
                else if (_openWindow == SettingApp.NAME_PAGE_STATS)
                {
                    spStats.Style = selectStackPanelStyle;
                    buttonStats.Focusable = true;
                    if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Light")
                        buttonStatsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#B0B0B0"));
                    else if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Dark")
                        buttonStatsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#D0D0D0"));
                }
                else if(_openWindow == SettingApp.NAME_PAGE_SETTINGS)
                {
                    spSettings.Style = selectStackPanelStyle;
                    buttonSettings.Focusable = true;
                    if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Light")
                        buttonSettingsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#B0B0B0"));
                    else if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Dark")
                        buttonSettingsText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#D0D0D0"));
                }
                else if (_openWindow == SettingApp.NAME_PAGE_SUPPORT)
                {
                    spSupport.Style = selectStackPanelStyle;
                    buttonSupport.Focusable = true;
                    if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Light")
                        buttonSupportText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#B0B0B0"));
                    else if (CountClickKey.Properties.Settings.Default.DefaultTheme.ToString() == "Dark")
                        buttonSupportText.Foreground = (System.Windows.Media.Brush)(new BrushConverter().ConvertFrom("#D0D0D0"));
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
        private void ChangeStyleButtonSettings()
        {
            if(_isOpenBorderActionTool == true)
            {
                buttonSettings.IsEnabled = false;

                buttonSettingsText.Visibility = Visibility.Visible;
                buttonSettingsText.IsEnabled = true;
            }
            else
            {
                buttonSettings.IsEnabled = true;

                buttonSettingsText.Visibility = Visibility.Hidden;
                buttonSettingsText.IsEnabled = false;
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
        public static readonly string NAME_PAGE_MAIN = "Main";
        public static readonly string NAME_PAGE_STATS = "Stats";
        public static readonly string NAME_PAGE_SETTINGS = "Settings";
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