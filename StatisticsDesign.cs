using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;

namespace CountClickKey
{
    public class DesignStatistics
    {
        public static ObservableCollection<StackPanel> AllKeyboard { get; set; } = new ObservableCollection<StackPanel>();

        public void CreateDesignStatistics()
        {
            const int MAX_ALL_KEY_STACKPANEL = 6;
            const int MAX_ALL_KEY_IN_STACKPANEL_FIRST = 16; // 13
            const int MAX_ALL_KEY_IN_STACKPANEL_SECOND_AND_THIRD = 17; // 14
            const int MAX_ALL_KEY_IN_STACKPANEL_FOURTH = 13; // 14
            const int MAX_ALL_KEY_IN_STACKPANEL_FIFTH = 12; // 11
            const int MAX_ALL_KEY_IN_STACKPANEL_SIXTH = 7; // 4

            const int MAX_WRITER_KEY_STACKPANEL = 5;
            const int MAX_WRITER_KEY_STACKPANEL_FIRST_AND_SECOND = 13;
            const int MAX_WRITER_KEY_STACKPANEL_THIRD = 11;
            const int MAX_WRITER_KEY_STACKPANEL_FOURTH = 10;

            const int MAX_NUMPAD_STACKPANEL = 5;
            const int MAX_NUMPAD_STACKPANEL_FIRST_AND_SECOND = 4;
            const int MAX_NUMPAD_STACKPANEL_THIRD = 3;
            const int MAX_NUMPAD_STACKPANEL_FOURTH = 4;
            const int MAX_NUMPAD_STACKPANEL_FIFTH = 2;

            const int MAX_FUNCTIONAL_KEY_STACKPANEL = 4;
            const int MAX_FUNCTION_KEY_STACKPANEL_FIRST = 12;
            const int MAX_FUNCTION_KEY_STACKPANEL_SECOND = 12;
            const int MAX_FUNCTION_KEY_STACKPANEL_THIRD = 11;
            const int MAX_FUNCTION_KEY_STACKPANEL_FOURTH = 9;

            StackPanel StackPanelKeyboardFirst = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(80, 14, 0, 0) };
            StackPanel StackPanelKeyboardSecond = new StackPanel { VerticalAlignment = VerticalAlignment.Top, Orientation = Orientation.Horizontal, Margin = new Thickness(80, 5, 0, 0) };
            StackPanel StackPanelKeyboardThird = new StackPanel { VerticalAlignment = VerticalAlignment.Top, Orientation = Orientation.Horizontal, Margin = new Thickness(80, 5, 0, 0) };
            StackPanel StackPanelKeyboardFourth = new StackPanel { VerticalAlignment = VerticalAlignment.Top, Orientation = Orientation.Horizontal, Margin = new Thickness(80, 5, 0, 0) };
            StackPanel StackPanelKeyboardFifth = new StackPanel { VerticalAlignment = VerticalAlignment.Top, Orientation = Orientation.Horizontal, Margin = new Thickness(80, 5, 0, 0) };
            StackPanel StackPanelKeyboardSixth = new StackPanel { VerticalAlignment = VerticalAlignment.Top, Orientation = Orientation.Horizontal, Margin = new Thickness(80, 5, 0, 0) };

            Grid numpadGrid = CreateGridForNumpad();

            int _selectValueStackPanel = 1;
            int _selectValueKey = 1;

            foreach (var key in StatisticsList.StatisticsKeyboard)
            {
                if (MainWindow.SELECT_TYPE_KEYS == SettingApp.TYPE_ALL_KEYS)
                {
                    if (_selectValueStackPanel == MAX_ALL_KEY_STACKPANEL + 1)
                        break;

                    Border borderHeadKey = CreateKey(key, _selectValueKey, _selectValueStackPanel, MainWindow.SELECT_TYPE_PERIOD, MainWindow.SELECT_TYPE_KEYS);

                    if (_selectValueStackPanel == 1 && _selectValueKey <= MAX_ALL_KEY_IN_STACKPANEL_FIRST)
                    {
                        StackPanelKeyboardFirst.Children.Add(borderHeadKey);
                        AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_ALL_KEY_IN_STACKPANEL_FIRST, StackPanelKeyboardFirst);
                    }
                    else if ((_selectValueStackPanel == 2 || _selectValueStackPanel == 3) && _selectValueKey <= MAX_ALL_KEY_IN_STACKPANEL_SECOND_AND_THIRD)
                    {
                        if (_selectValueStackPanel == 2)
                        {
                            StackPanelKeyboardSecond.Children.Add(borderHeadKey);
                            AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_ALL_KEY_IN_STACKPANEL_SECOND_AND_THIRD, StackPanelKeyboardSecond);
                        }
                        else if (_selectValueStackPanel == 3)
                        {
                            StackPanelKeyboardThird.Children.Add(borderHeadKey);
                            AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_ALL_KEY_IN_STACKPANEL_SECOND_AND_THIRD, StackPanelKeyboardThird);
                        }
                    }
                    else if (_selectValueStackPanel == 4 && _selectValueKey <= MAX_ALL_KEY_IN_STACKPANEL_FOURTH)
                    {
                        StackPanelKeyboardFourth.Children.Add(borderHeadKey);
                        AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_ALL_KEY_IN_STACKPANEL_FOURTH, StackPanelKeyboardFourth);
                    }
                    else if (_selectValueStackPanel == 5 && _selectValueKey <= MAX_ALL_KEY_IN_STACKPANEL_FIFTH)
                    {
                        StackPanelKeyboardFifth.Children.Add(borderHeadKey);
                        AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_ALL_KEY_IN_STACKPANEL_FIFTH, StackPanelKeyboardFifth);
                    }
                    else if (_selectValueStackPanel == 6 && _selectValueKey <= MAX_ALL_KEY_IN_STACKPANEL_SIXTH)
                    {
                        StackPanelKeyboardSixth.Children.Add(borderHeadKey);
                        AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_ALL_KEY_IN_STACKPANEL_SIXTH, StackPanelKeyboardSixth);
                    }
                }
                else if (MainWindow.SELECT_TYPE_KEYS == SettingApp.TYPE_WRITER_KEYS)
                {
                    if (key.TypeKeys == DataFile.TYPE_KEY_WRITER)
                    {
                        if (_selectValueStackPanel == MAX_WRITER_KEY_STACKPANEL + 1)
                            break;

                        Border borderHeadKey = CreateKey(key, _selectValueKey, _selectValueStackPanel, MainWindow.SELECT_TYPE_PERIOD, MainWindow.SELECT_TYPE_KEYS);

                        if ((_selectValueStackPanel == 1 || _selectValueStackPanel == 2) && _selectValueKey <= MAX_WRITER_KEY_STACKPANEL_FIRST_AND_SECOND)
                        {
                            if (_selectValueStackPanel == 1)
                            {
                                StackPanelKeyboardFirst.Children.Add(borderHeadKey);
                                AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_WRITER_KEY_STACKPANEL_FIRST_AND_SECOND, StackPanelKeyboardFirst);
                            }
                            else if (_selectValueStackPanel == 2)
                            {
                                StackPanelKeyboardSecond.Children.Add(borderHeadKey);
                                AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_WRITER_KEY_STACKPANEL_FIRST_AND_SECOND, StackPanelKeyboardSecond);
                            }
                        }
                        else if (_selectValueStackPanel == 3 && _selectValueKey <= MAX_WRITER_KEY_STACKPANEL_THIRD)
                        {
                            StackPanelKeyboardThird.Children.Add(borderHeadKey);
                            AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_WRITER_KEY_STACKPANEL_THIRD, StackPanelKeyboardThird);
                        }
                        else if (_selectValueStackPanel == 4 && _selectValueKey <= MAX_WRITER_KEY_STACKPANEL_FOURTH)
                        {
                            StackPanelKeyboardFourth.Children.Add(borderHeadKey);
                            AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_WRITER_KEY_STACKPANEL_FOURTH, StackPanelKeyboardFourth);
                        }
                    }
                }
                else if (MainWindow.SELECT_TYPE_KEYS == SettingApp.TYPE_NUMERIC_KEYPAD)
                {
                    if (key.TypeKeys == DataFile.TYPE_KEY_NUMERIC_KEYPAD)
                    {
                        if (_selectValueStackPanel == MAX_NUMPAD_STACKPANEL + 1)
                            break;

                        Border borderHeadKey = CreateKey(key, _selectValueKey, _selectValueStackPanel, MainWindow.SELECT_TYPE_PERIOD, MainWindow.SELECT_TYPE_KEYS);

                        borderHeadKey.Margin = new Thickness(0, 0, 0, 0);
                        borderHeadKey.HorizontalAlignment = HorizontalAlignment.Left;
                        borderHeadKey.VerticalAlignment = VerticalAlignment.Top;

                        if (key.KeyID == Key.Enter || key.KeyID == Key.Add)
                        {
                            Grid.SetRow(borderHeadKey, _selectValueStackPanel - 1);
                            Grid.SetRowSpan(borderHeadKey, 2);
                            Grid.SetColumn(borderHeadKey, _selectValueKey - 1);
                        }
                        else if (key.KeyID == Key.NumPad0)
                        {
                            Grid.SetRow(borderHeadKey, _selectValueStackPanel - 1);
                            Grid.SetColumn(borderHeadKey, _selectValueKey - 1);
                            Grid.SetColumnSpan(borderHeadKey, 2);
                        }
                        else if (key.KeyID == Key.Decimal)
                        {
                            Grid.SetRow(borderHeadKey, _selectValueStackPanel - 1);
                            Grid.SetColumn(borderHeadKey, _selectValueKey);
                        }
                        else
                        {
                            Grid.SetRow(borderHeadKey, _selectValueStackPanel - 1);
                            Grid.SetColumn(borderHeadKey, _selectValueKey - 1);
                        }

                        numpadGrid.Children.Add(borderHeadKey);

                        if ((_selectValueStackPanel == 1 || _selectValueStackPanel == 2) && _selectValueKey <= MAX_NUMPAD_STACKPANEL_FIRST_AND_SECOND)
                        {
                            if (_selectValueKey == MAX_NUMPAD_STACKPANEL_FIRST_AND_SECOND)
                            {
                                _selectValueKey = 1;
                                _selectValueStackPanel++;
                            }
                            else
                                _selectValueKey++;
                        }
                        else if (_selectValueStackPanel == 3 && _selectValueKey <= MAX_NUMPAD_STACKPANEL_THIRD)
                        {
                            if (_selectValueKey == MAX_NUMPAD_STACKPANEL_THIRD)
                            {
                                _selectValueKey = 1;
                                _selectValueStackPanel++;
                            }
                            else
                                _selectValueKey++;
                        }
                        else if (_selectValueStackPanel == 4 && _selectValueKey <= MAX_NUMPAD_STACKPANEL_FOURTH)
                        {
                            if (_selectValueKey == MAX_NUMPAD_STACKPANEL_FOURTH)
                            {
                                _selectValueKey = 1;
                                _selectValueStackPanel++;
                            }
                            else
                                _selectValueKey++;
                        }
                        else if (_selectValueStackPanel == 5 && _selectValueKey <= MAX_NUMPAD_STACKPANEL_FIFTH)
                        {
                            if (_selectValueKey == MAX_NUMPAD_STACKPANEL_FIFTH)
                            {
                                _selectValueKey = 1;
                                _selectValueStackPanel++;

                                StackPanelKeyboardFirst.Children.Add(numpadGrid);
                                AllKeyboard.Add(StackPanelKeyboardFirst);
                            }
                            else
                                _selectValueKey++;
                        }
                    }
                }
                else if (MainWindow.SELECT_TYPE_KEYS == SettingApp.TYPE_FUNCTION_BLOCK)
                {
                    if (key.TypeKeys == DataFile.TYPE_KEY_FUNCTIONAL_BLOCK)
                    {
                        if (_selectValueStackPanel == MAX_FUNCTIONAL_KEY_STACKPANEL + 1)
                            break;

                        if (_selectValueStackPanel == 1 && _selectValueKey <= MAX_FUNCTION_KEY_STACKPANEL_FIRST)
                        {
                            Border borderHeadKey = CreateKey(key, _selectValueKey, _selectValueStackPanel, MainWindow.SELECT_TYPE_PERIOD, MainWindow.SELECT_TYPE_KEYS);
                            StackPanelKeyboardFirst.Children.Add(borderHeadKey);
                            AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_FUNCTION_KEY_STACKPANEL_FIRST, StackPanelKeyboardFirst);
                        }
                        if (IsFromF13ToF24(key.KeyID))
                        {
                            if (_selectValueStackPanel != 2)
                                _selectValueKey = 1;

                            Border borderHeadKey = CreateKey(key, _selectValueKey, _selectValueStackPanel, MainWindow.SELECT_TYPE_PERIOD, MainWindow.SELECT_TYPE_KEYS);

                            _selectValueStackPanel = 2;
                            _selectValueKey++;

                            StackPanelKeyboardSecond.Children.Add(borderHeadKey);
                        }
                        else if (key.KeyID == Key.Tab || key.KeyID == Key.Back || key.KeyID == Key.CapsLock || key.KeyID == Key.Enter || key.KeyID == Key.LeftShift || key.KeyID == Key.RightShift || key.KeyID == Key.LeftCtrl || key.KeyID == Key.RightCtrl
                                || key.KeyID == Key.LeftAlt || key.KeyID == Key.RightAlt || key.KeyID == Key.Space)
                        {
                            if (_selectValueStackPanel != 3)
                                _selectValueKey = 1;

                            Border borderHeadKey = CreateKey(key, _selectValueKey, _selectValueStackPanel, MainWindow.SELECT_TYPE_PERIOD, MainWindow.SELECT_TYPE_KEYS);

                            _selectValueStackPanel = 3;
                            _selectValueKey++;

                            StackPanelKeyboardThird.Children.Add(borderHeadKey);
                        }
                        else if (key.KeyID == Key.PrintScreen || key.KeyID == Key.Scroll || key.KeyID == Key.Pause || key.KeyID == Key.Insert || key.KeyID == Key.Home || key.KeyID == Key.PageUp || key.KeyID == Key.Delete || key.KeyID == Key.End ||
                                key.KeyID == Key.PageDown)
                        {
                            if (_selectValueStackPanel != 4)
                                _selectValueKey = 1;

                            Border borderHeadKey = CreateKey(key, _selectValueKey, _selectValueStackPanel, MainWindow.SELECT_TYPE_PERIOD, MainWindow.SELECT_TYPE_KEYS);

                            _selectValueStackPanel = 4;
                            _selectValueKey++;

                            StackPanelKeyboardFourth.Children.Add(borderHeadKey);
                        }

                        if (StackPanelKeyboardSecond.Children.Count == MAX_FUNCTION_KEY_STACKPANEL_SECOND && StackPanelKeyboardThird.Children.Count == MAX_FUNCTION_KEY_STACKPANEL_THIRD &&
                            StackPanelKeyboardFourth.Children.Count == MAX_FUNCTION_KEY_STACKPANEL_FOURTH)
                        {
                            _selectValueStackPanel = 2;
                            _selectValueKey = MAX_FUNCTION_KEY_STACKPANEL_SECOND;

                            AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_FUNCTION_KEY_STACKPANEL_SECOND, StackPanelKeyboardSecond);

                            _selectValueStackPanel = 3;
                            _selectValueKey = MAX_FUNCTION_KEY_STACKPANEL_THIRD;

                            AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_FUNCTION_KEY_STACKPANEL_THIRD, StackPanelKeyboardThird);

                            _selectValueStackPanel = 4;
                            _selectValueKey = MAX_FUNCTION_KEY_STACKPANEL_FOURTH;

                            AttachedBorderToPanel(ref _selectValueStackPanel, ref _selectValueKey, MAX_FUNCTION_KEY_STACKPANEL_FOURTH, StackPanelKeyboardFourth);
                        }
                    }
                }
                else
                    break;
            }
        }
        public void RemoveDesighnStatistics()
        {
            AllKeyboard.Clear();
        }

        private void AttachedBorderToPanel(ref int selectValueStackPanel, ref int selectValueKey, int maxKeyInStackPanel, StackPanel selectStackPanel)
        {
            if (selectValueStackPanel == 1 && selectValueKey <= maxKeyInStackPanel)
            {
                if (selectValueKey == maxKeyInStackPanel)
                {
                    try { AllKeyboard.Add(selectStackPanel); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex}");
                    }

                    selectValueStackPanel++;
                    selectValueKey = 1;
                }
                else
                    selectValueKey++;
            }
            else if (selectValueStackPanel == 2 && selectValueKey <= maxKeyInStackPanel)
            {
                if (selectValueKey == maxKeyInStackPanel)
                {
                    try { AllKeyboard.Add(selectStackPanel); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex}");
                    }

                    selectValueStackPanel++;
                    selectValueKey = 1;
                }
                else
                    selectValueKey++;
            }
            else if(selectValueStackPanel == 3 && selectValueKey <= maxKeyInStackPanel)
            {
                if (selectValueKey == maxKeyInStackPanel)
                {
                    try { AllKeyboard.Add(selectStackPanel); }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex}"); }

                    selectValueStackPanel++;
                    selectValueKey = 1;
                }
                else
                    selectValueKey++;
            }
            else if(selectValueStackPanel == 4 && selectValueKey <= maxKeyInStackPanel)
            {
                if (selectValueKey == maxKeyInStackPanel)
                {
                    try { AllKeyboard.Add(selectStackPanel); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex}");
                    }

                    selectValueStackPanel++;
                    selectValueKey = 1;
                }
                else
                    selectValueKey++;
            }
            else if(selectValueStackPanel == 5 && selectValueKey <= maxKeyInStackPanel)
            {
                if (selectValueKey == maxKeyInStackPanel)
                {
                    try { AllKeyboard.Add(selectStackPanel); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex}");
                    }
                    selectValueStackPanel++;
                    selectValueKey = 1;
                }
                else
                    selectValueKey++;
            }
            else if(selectValueStackPanel == 6 && selectValueKey <= maxKeyInStackPanel)
            {
                if (selectValueKey == maxKeyInStackPanel)
                {
                    try { AllKeyboard.Add(selectStackPanel); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex}");
                    }
                    selectValueStackPanel++;
                    selectValueKey = 1;
                }
                else
                    selectValueKey++;
            }
        }
        private Border CreateKey(DataKeyboard key, int selectValueKey, int selectValueStackPanel, string selectPeriod, string selectTypeKey)
        {
            Style styleHeadBorderKey = Application.Current.MainWindow.FindResource("StyleHeadBorderKey") as Style;
            Style styleBorderKey = Application.Current.MainWindow.FindResource("StyleBorderKey") as Style;
            Style styleTextNameKey = Application.Current.MainWindow.FindResource("StyleTextKey") as Style;
            Style styleTextCountClick = Application.Current.MainWindow.FindResource("StyleTextCountClickKey") as Style;
            Style styleTextClickedKey = Application.Current.MainWindow.FindResource("StyleTextClickedKey") as Style;

            Border borderHeadKey = CreateBorderHeadKey(styleHeadBorderKey, selectValueKey, selectValueStackPanel, key.KeyID, key.TypeKeys, selectTypeKey);
            Grid grid = new Grid();
            Border borderKey = CreateBorderKey(styleBorderKey, key.KeyID, key.TypeKeys, selectTypeKey);

            if (IsKeyCreateSVG(key.NameKey))
            {
                borderKey.Background = CreateSVGKey(key.NameKey);
                grid.Children.Add(borderKey);
            }
            else
            {
                TextBlock textNameKey = CreateTextNameKey(key.KeyID, key.TypeKeys, key.NameKey, styleTextNameKey);
                borderKey.Child = textNameKey;
                grid.Children.Add(borderKey);
            }

            TextBlock textCountClickKey = new TextBlock() { Text = "0" };
            if (selectPeriod == SettingApp.TYPE_ALL_TIME_PERIOD)
                textCountClickKey = CreateTextCountClickKey(key.DataCountClicked.CountAllTimeClickedKey, styleTextCountClick, key.KeyID, key.TypeKeys);
            else if (selectPeriod == SettingApp.TYPE_DAY_PERIOD)
                textCountClickKey = CreateTextCountClickKey(key.DataCountClicked.DataDayClicked.CountDayClicked, styleTextCountClick, key.KeyID, key.TypeKeys);
            else if (selectPeriod == SettingApp.TYPE_WEEK_PERIOD)
                textCountClickKey = CreateTextCountClickKey(key.DataCountClicked.DataWeekClicked.CountWeekClicked, styleTextCountClick, key.KeyID, key.TypeKeys);
            else if (selectPeriod == SettingApp.TYPE_MONTH_PERIOD)
                textCountClickKey = CreateTextCountClickKey(key.DataCountClicked.DataMonthClicked.CountMonthClicked, styleTextCountClick, key.KeyID, key.TypeKeys);
            else if (selectPeriod == SettingApp.TYPE_YEAR_PERIOD)
                textCountClickKey = CreateTextCountClickKey(key.DataCountClicked.DataYearClicked.CountYearClicked, styleTextCountClick, key.KeyID, key.TypeKeys);

            TextBlock textClicked = new TextBlock
            {
                Text = "clicked",
                Style = styleTextClickedKey
            };

            if(key.KeyID == Key.Add || (key.KeyID == Key.Enter && key.TypeKeys == DataFile.TYPE_KEY_NUMERIC_KEYPAD))
            {
                textClicked.Margin = new Thickness(0, 136, 0, 0);
            }

            grid.Children.Add(textCountClickKey);
            grid.Children.Add(textClicked);

            borderHeadKey.Child = grid;

            return borderHeadKey;
        }
        private DrawingBrush CreateSVGKey(string keyName)
        {
            PathGeometry pathGeom = new PathGeometry { FillRule = FillRule.Nonzero };

            PathFigure pathFigure = null;
            LineSegment ls = null;
            LineSegment lsTwo = null;
            LineSegment lsThree = null;
            LineSegment lsFour = null;
            LineSegment lsFive = null;
            LineSegment lsSix = null;
            LineSegment lsSeven = null;

            if (keyName == "Backspace")
            {
                pathFigure = new PathFigure { StartPoint = new System.Windows.Point(0, 4.0032) };

                ls = new LineSegment { Point = new System.Windows.Point(6.93333, 8.00533) };
                lsTwo = new LineSegment { Point = new System.Windows.Point(6.93333, 4.69653) };
                lsThree = new LineSegment { Point = new System.Windows.Point(21.3333, 4.69653) };
                lsFour = new LineSegment { Point = new System.Windows.Point(21.3333, 3.3088) };
                lsFive = new LineSegment { Point = new System.Windows.Point(6.93333, 3.3088) };
                lsSix = new LineSegment { Point = new System.Windows.Point(6.93333, -3.8147e-006) };
                lsSeven = new LineSegment { Point = new System.Windows.Point(0, 4.0032) };
            }
            else if (keyName == "UpArrow")
            {
                pathFigure = new PathFigure { StartPoint = new System.Windows.Point(4.86288, 0) };

                ls = new LineSegment { Point = new System.Windows.Point(-5.96046e-008, 8.42102) };
                lsTwo = new LineSegment { Point = new System.Windows.Point(4.01965, 8.42102) };
                lsThree = new LineSegment { Point = new System.Windows.Point(4.01965, 21.3333) };
                lsFour = new LineSegment { Point = new System.Windows.Point(5.70498, 21.3333) };
                lsFive = new LineSegment { Point = new System.Windows.Point(5.70498, 8.42102) };
                lsSix = new LineSegment { Point = new System.Windows.Point(9.72463, 8.42102) };
                lsSeven = new LineSegment { Point = new System.Windows.Point(4.86288, 0) };
            }
            else if (keyName == "DownArrow")
            {
                pathFigure = new PathFigure { StartPoint = new System.Windows.Point(0, 4.39868) };

                ls = new LineSegment { Point = new System.Windows.Point(7.61905, 8.79846) };
                lsTwo = new LineSegment { Point = new System.Windows.Point(7.61905, 5.16162) };
                lsThree = new LineSegment { Point = new System.Windows.Point(21.3333, 5.16162) };
                lsFour = new LineSegment { Point = new System.Windows.Point(21.3333, 3.63678) };
                lsFive = new LineSegment { Point = new System.Windows.Point(7.61905, 3.63678) };
                lsSix = new LineSegment { Point = new System.Windows.Point(7.61905, 0) };
                lsSeven = new LineSegment { Point = new System.Windows.Point(0, 4.39868) };
            }
            else if (keyName == "LeftArrow")
            {
                pathFigure = new PathFigure { StartPoint = new System.Windows.Point(3.63683, -6.10352e-005) };

                ls = new LineSegment { Point = new System.Windows.Point(3.63683, 13.7142) };
                lsTwo = new LineSegment { Point = new System.Windows.Point(-1.19209e-007, 13.7142) };
                lsThree = new LineSegment { Point = new System.Windows.Point(4.39975, 21.3333) };
                lsFour = new LineSegment { Point = new System.Windows.Point(8.79848, 13.7142) };
                lsFive = new LineSegment { Point = new System.Windows.Point(5.16064, 13.7142) };
                lsSix = new LineSegment { Point = new System.Windows.Point(5.16064, -6.10352e-005) };
                lsSeven = new LineSegment { Point = new System.Windows.Point(3.63683, -6.10352e-005) };
            }
            else if (keyName == "RightArrow")
            {
                pathFigure = new PathFigure { StartPoint = new System.Windows.Point(13.7143, 3.63678) };

                ls = new LineSegment { Point = new System.Windows.Point(0, 3.63678) };
                lsTwo = new LineSegment { Point = new System.Windows.Point(0, 5.16058) };
                lsThree = new LineSegment { Point = new System.Windows.Point(13.7143, 5.16058) };
                lsFour = new LineSegment { Point = new System.Windows.Point(13.7143, 8.79846) };
                lsFive = new LineSegment { Point = new System.Windows.Point(21.3333, 4.39868) };
                lsSix = new LineSegment { Point = new System.Windows.Point(13.7143, 0) };
                lsSeven = new LineSegment { Point = new System.Windows.Point(13.7143, 3.63678) };
            }

            pathFigure.Segments.Add(ls);
            pathFigure.Segments.Add(lsTwo);
            pathFigure.Segments.Add(lsThree);
            pathFigure.Segments.Add(lsFour);
            pathFigure.Segments.Add(lsFive);
            pathFigure.Segments.Add(lsSix);
            pathFigure.Segments.Add(lsSeven);
            pathFigure.IsClosed = true;

            pathGeom.Figures.Add(pathFigure);

            GeometryDrawing aGeometryDrawing = new GeometryDrawing() { Geometry = pathGeom, Brush = System.Windows.Media.Brushes.Black };

            DrawingBrush drawingBrush = new DrawingBrush { Stretch = Stretch.None, Drawing = aGeometryDrawing };

            return drawingBrush;
        }
        private Grid CreateGridForNumpad()
        {
            Grid newGrid = new Grid() { Width = 232, Height = 385, HorizontalAlignment = HorizontalAlignment.Left};

            ColumnDefinition colummOneGrid = new ColumnDefinition();
            ColumnDefinition colummTwoGrid = new ColumnDefinition();
            ColumnDefinition colummThreeGrid = new ColumnDefinition();
            ColumnDefinition colummFourGrid = new ColumnDefinition();

            RowDefinition rowOneGrid = new RowDefinition();
            RowDefinition rowTwoGrid = new RowDefinition();
            RowDefinition rowThreeGrid = new RowDefinition();
            RowDefinition rowFourGrid = new RowDefinition();
            RowDefinition rowFiveGrid = new RowDefinition();

            newGrid.ColumnDefinitions.Add(colummOneGrid);
            newGrid.ColumnDefinitions.Add(colummTwoGrid);
            newGrid.ColumnDefinitions.Add(colummThreeGrid);
            newGrid.ColumnDefinitions.Add(colummFourGrid);

            newGrid.RowDefinitions.Add(rowOneGrid);
            newGrid.RowDefinitions.Add(rowTwoGrid);
            newGrid.RowDefinitions.Add(rowThreeGrid);
            newGrid.RowDefinitions.Add(rowFourGrid);
            newGrid.RowDefinitions.Add(rowFiveGrid);

            return newGrid;
        }
        private Border CreateBorderHeadKey(Style styleBorder, int selectValueKey, int selectValueStackPanel, Key keyID, string typeKey, string selectTypeKey)
        {
            Border borderHeadKey = new Border { Style = styleBorder };
            if (selectValueKey == 14 && selectValueStackPanel == 1)
                borderHeadKey.Margin = new Thickness(80, 0, 0, 0);
            else if (selectValueKey == 15 && (selectValueStackPanel == 2 || selectValueStackPanel == 3))
                borderHeadKey.Margin = new Thickness(22, 0, 0, 0);
            else if (selectValueKey == 12 && selectValueStackPanel == 5)
                borderHeadKey.Margin = new Thickness(254, 0, 0, 0);
            else if (selectValueKey == 5 && selectValueStackPanel == 6)
                borderHeadKey.Margin = new Thickness(305, 0, 0, 0);
            else if (selectValueKey != 1)
                borderHeadKey.Margin = new Thickness(5, 0, 0, 0);

            if (keyID == Key.Space && selectTypeKey != DataFile.TYPE_KEY_FUNCTIONAL_BLOCK)
            {
                borderHeadKey.Width = 350;
                borderHeadKey.Height = 72;
            }
            else if ((keyID == Key.Add && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD) || (keyID == Key.Enter && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD))
                borderHeadKey.Height = 149;
            else if (keyID == Key.NumPad0)
                borderHeadKey.Width = 111;

            return borderHeadKey;
        }
        private Border CreateBorderKey(Style styleBorder, Key keyID, string typeKey, string selectTypeKey)
        {
            Border borderKey = new Border
            {
                Style = styleBorder,
                Margin = new Thickness(5, 5, 5, 20)
            };

            if (keyID == Key.Space && selectTypeKey != DataFile.TYPE_KEY_FUNCTIONAL_BLOCK)
                borderKey.Width = 340;
            else if ((keyID == Key.Add && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD) || (keyID == Key.Enter && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD))
                borderKey.Height = 122;
            else if (keyID == Key.NumPad0)
                borderKey.Width = 101;

            return borderKey;
        }
        private TextBlock CreateTextNameKey(Key keyID, string typeKey, string nameKey, Style styleText)
        {
            TextBlock textNameKey = new TextBlock {
                Style = styleText,
                TextAlignment = TextAlignment.Center
            };

            if (keyID == Key.NumLock)
                textNameKey.Text = "Num\nLock";
            else if (keyID == Key.Divide && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD)
                textNameKey.Text = "Num\n/";
            else if (keyID == Key.Multiply && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD)
                textNameKey.Text = "Num\n*";
            else if (keyID == Key.Subtract && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD)
                textNameKey.Text = "Num\n-";
            else if (keyID == Key.Enter && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD)
                textNameKey.Text = "Enter";
            else if (keyID == Key.Decimal && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD)
                textNameKey.Text = "Num\n.";
            else
                textNameKey.Text = nameKey;

            return textNameKey;
        }
        private TextBlock CreateTextCountClickKey(int valueCkicked, Style styleText, Key keyID, string typeKey)
        {
            TextBlock textCountClickKey = new TextBlock
            {
                Text = Convert.ToString(valueCkicked),
                Style = styleText
            };

            if(keyID == Key.Add || (keyID == Key.Enter && typeKey == DataFile.TYPE_KEY_NUMERIC_KEYPAD))
            {
                textCountClickKey.Margin = new Thickness(0, 126, 0, 0);
            }

            return textCountClickKey;
        }
        private bool IsKeyCreateSVG(string nameKey)
        {
            if (nameKey == "Backspace" || nameKey == "UpArrow" || nameKey == "DownArrow" || nameKey == "LeftArrow" || nameKey == "RightArrow")
                return true;
            else
                return false;
        }
        private bool IsFromF13ToF24(Key keyID)
        {
            switch(keyID)
            {
                case Key.F13:
                    return true;
                case Key.F14:
                    return true;
                case Key.F15:
                    return true;
                case Key.F16:
                    return true;
                case Key.F17:
                    return true;
                case Key.F18:
                    return true;
                case Key.F19:
                    return true;
                case Key.F20:
                    return true;
                case Key.F21:
                    return true;
                case Key.F22:
                    return true;
                case Key.F23:
                    return true;
                case Key.F24:
                    return true;
                default:
                    return false;
            }
        }
    }
}
