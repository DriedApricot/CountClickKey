   M S B A M L   `   `   `  ���� H  DCountClickKey, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CountClickKeyCountClickKey  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M4clr-namespace:System.Globalization;assembly=mscorlibSystem.Globalization G(clr-namespace:CountClickKey.LocalizationCountClickKey.Localization  1&clr-namespace:System;assembly=mscorlibSystem     CountClickKey.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:CountClickKey     Nglobalization4clr-namespace:System.Globalization;assembly=mscorlib     6l(clr-namespace:CountClickKey.Localization     9system&clr-namespace:System;assembly=mscorlib     -     � Title$  CountClickKey��$	��600��$	��600��$
��1100��$
��1100�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 	Resources ��    KeyVersionString   �� Type" ��.s���2.0��.����   HeadBorderApp#���  ._��  � ColumnDefinitions �� $	��176 ��� �� $	��150 �.+��� -    ��Name$ borderActionTool��$��0��  StyleBorderActionTool#���  ._��� .+��� -   	 ��Name$	 bActionTool��  ButtonStyle#���  
������   modelActionTool#���  $��32��$��25��$
��Left=�$	��Top=�$��12, 14, 12, 0q��� -   
 ��Name$
 spHome��  NotSelectStackPanel#���   �� Orientation$ 
Horizontal=�$��0, 40, 0, 0q�.+��� -   $	 
buttonHome��
������   IsSelectIconHome#���  $��35��$��35��$��10, 5, 10, 5q�$
��Left=��� -   $	 buttonHomeText��  styleTextButtonIcon#���  $��30��$��20(�{�.  $y�Hidden=���6   0CountClickKey.Localization.LocalizationExtension  *m_ButtonHome+�� -   $
 spStats��#���  $ 
Horizontal=�$��0, 15, 0, 0q�.+��� -   $	 buttonStats��  IsSelectIconStats#���  
������ $��35��$��35��$��10, 5, 10, 5q�$
��Left=��� -	   $	 buttonStatsText��#���  $��30��$��20(�{�.  $y�Hidden=���  *m_ButtonStats+�� -
   $
 
spSettings��#���  $ 
Horizontal=�$��0, 15, 0, 0q�.+��� -   $	 buttonSettings�� 	 IsSelectIconSettings#��� 	 $��35��$��35��
������ $��10, 5, 10, 5q�$
��Left=��� -   $	 buttonSettingsText��#���  $��30��$��20(�{�.  $y�Hidden=���  *m_ButtonSettings+�� -   $
 	spSupport��#���  $ 
Horizontal=�$��0, 15, 0, 0q�.+��� -   $	 buttonSupport�� 
 IsSelectIconSupport#��� 
 
������ $��35��$��35��$��	10,5,10,5q�$
��Left=��� -   $	 buttonSupportText��#���  $��30��$��20(�$��0, -1, 0, 0q�{�.  $y�Hidden=���  *m_ButtonSupport+�� 
������   	modelIcon#���  $��42��$��42��$��7, 240, 7, 0q�$
��Left=��� $��2��$	��Top=�$��65, 14, 20, 0q�$��RightToLeft=�$��65��$��30��._��� $ 
Horizontal=�.+��� -   $	 	bCloseApp��#���  
������   modelCloseApp#���  $��24��$��24���� -   $	 bMinimizeApp��#���  
������   modelMinimizeApp#���  $��24��$��24��$��17, 0, 0, 0q��� -   $ borderVersionApp��$��2��$��Bottom=�$��LeftToRight=�$��	0,0,32,14q�$y�Visible=�._��� -    ��Name$ textVersionApp��  styleVersion#���  ��  
   Key$ 	m_Version��  VersionString   	Arguments# [ �� -   $ MainContentWindow��$��1��
������ $��45,100,50,100q�$y�Visible=�._��� -   $

 test��$ Vertical=�.+��� $ 
Horizontal=�$��Center=�.+��� -   $
 Logo��
������ $��58��$��58��$��0, 0, 10, 3q�  logotipe#���  ��   HeadNameApp#���  $��CountClickKey��$��65(��� $��1��$	��250��  modelKeyboard#���  �� -   $ StatsContentWindow��$��3��$y�	Collapsed=�._��� -   $
 spStatisticsWindow��$ Vertical=�.+��� -   $
 StackPanelTypePeriod��$ 
Horizontal=�$
��Left=�$	��Top=�$��80, 38, 0, 0q�.+��� -   $	 buttonStatsAllTime��  StyleButtonStatsTime#���  $��30��$��17(�.���� .���� $��15(�$��15, 0, 15, 0q� �� Padding$ 
0, 3, 0, 0q�$1��+pack://application:,,,/Fonts/#Baloo Paaji 2)���  *m_ButtonAllTime_Period+�� -   $	 buttonStatsDay��#���  $��30��$��
6, 0, 0, 0q�$��17(�.���� .���� $��15(�$��15, 0, 15, 0q�$ 
0, 3, 0, 0q�$1��+pack://application:,,,/Fonts/#Baloo Paaji 2)���  *m_ButtonDay_Period+�� -   $	 buttonStatsWeek��#���  $��30��$��
6, 0, 0, 0q�$��17(�.���� .���� $��15(�$��15, 0, 15, 0q�$ 
0, 3, 0, 0q�$1��+pack://application:,,,/Fonts/#Baloo Paaji 2)���  *m_ButtonWeek_Period+�� -   $	 buttonStatsMonth��#���  $��30��$��
6, 0, 0, 0q�$��17(�.���� .���� $��15(�$��15, 0, 15, 0q�$ 
0, 3, 0, 0q�$1��+pack://application:,,,/Fonts/#Baloo Paaji 2)���  *m_ButtonMonth_Period+�� -   $	 buttonStatsYear��#���  $��30��$��
6, 0, 0, 0q�$��17(�.���� .���� $��15(�$��15, 0, 15, 0q�$ 
0, 3, 0, 0q�$1��+pack://application:,,,/Fonts/#Baloo Paaji 2)���  *m_ButtonYear_Period+�� -   $
 StackPanelTypeKeys��$ 
Horizontal=�$
��Left=�$��80, 6, 0, 0q�.+��� -    $	 buttonTypeAllKeys��#���  $��30��$��17(�.���� .���� $��15(�$��15, 0, 15, 0q�$ 
0, 3, 0, 0q�$1��+pack://application:,,,/Fonts/#Baloo Paaji 2)���  *m_ButtonAllKeys_Type+�� -!   $	 buttonTypeWriterKeys��#���  $��30��$��
6, 0, 0, 0q�$��17(�.���� .���� $��15(�$��15, 0, 15, 0q�$ 
0, 3, 0, 0q�$1��+pack://application:,,,/Fonts/#Baloo Paaji 2)���  *m_ButtonWriterKeys_Type+�� -"   $	 buttonTypeNumericKeypad��#���  $��30��$��
6, 0, 0, 0q�$��17(�.���� .���� $��15(�$��15, 0, 15, 0q�$ 
0, 3, 0, 0q�$1��+pack://application:,,,/Fonts/#Baloo Paaji 2)���  *m_ButtonNumericKeypad_Type+�� -#   $	 buttonTypeFunctionalBlock��#���  $��30��$��
6, 0, 0, 0q�$��17(�.���� .���� $��15(�$��15, 0, 15, 0q�$ 
0, 3, 0, 0q�$1��+pack://application:,,,/Fonts/#Baloo Paaji 2)���  *m_ButtonFunctionalBlock_Type+�� $
��Auto��$
��Auto������ *AllKeyboard+�� -$   $ SupportContentWindow��$��3��$y�	Collapsed=�._�� $��92, 39, 0, 0q�.+��� $��35(�  styleTextSupport#���  ��  *	m_Support+�� -%   $ 
borderAsk1��  StyleBorderAsk#���  $��0, 85, 0, 0q�._��  � ShowGridLines .   �� $	��234 ���  � RowDefinitions �� $
��48.5 ��� $��1 ��� .+��� $��0��  StyleAsk#���  ��  *m_Ask1+�� -&   $	 buttonArrowAsk1��$��1��  StyleButtonArrowToAsk#���  �� -'   $ borderSeparatorAsk1��$��1��$��2��$y�	Collapsed=�  StyleSeparatorBorderAsk#���  �� $ Vertical=�$��2��$��0��.+��� -(   $ textFirstAnswerToFirstAsk��$y�	Collapsed=�  StyleAnswerToAsk#���  $��15, 18, 0, 5q���  *m_FirstAnswerToFirstAsk+�� -)   $  textSecondAnswerToFirstAsk��$y�	Collapsed=�#���  $��15, 0, 0, 5q���  *m_SecondAnswerToFirstAsk+�� -*   $ textThirdAnswerToFirstAsk��$y�	Collapsed=�#���  $��15, 0, 0, 15q���  *m_ThirdAnswerToFirstAsk+�� -+   $ 
borderAsk2��#���  $��267, 85, 0, 0q�._��  .   �� $	��234 ���  �� $
��48.5 ��� $��1 ��� .+��� $��0��#���  ��  *m_Ask2+�� -,   $	 buttonArrowAsk2��$��1��#���  �� --   $ borderSeparatorAsk2��$��1��$��2��$y�	Collapsed=�#���  �� $ Vertical=�$��2��$��0��.+��� -.   $  textFirstAnswerToSecondAsk��$y�	Collapsed=�#���  $��15, 18, 0, 5q���  *m_FirstAnswerToSecondAsk+�� -/   $! textSecondAnswerToSecondAsk��$y�	Collapsed=�#���  $��15, 0, 0, 5q���  *m_SecondAnswerToSecondAsk+�� -0   $  textThirdAnswerToSecondAsk��$y�	Collapsed=�#���  $��15, 0, 0, 5q���  *m_ThirdAnswerToSecondAsk+�� -1   $! textFourthAnswerToSecondAsk��$y�	Collapsed=�#���  $��15, 0, 0, 5q���  *m_FourthAnswerToSecondAsk+�� -2   $  textFifthAnswerToSecondAsk��$y�	Collapsed=�#���  $��15, 0, 0, 15q���  *m_FifthAnswerToSecondAsk+�� -3   $ SettingsContentWindow��$��3��$y�	Collapsed=�._�� $��	92,39,0,0q�.+��� $��35(�  styleTextSettings#���  ��  *
m_Settings+�� $ 
Horizontal=�$��0, 70, 0, 0q�.+��� $��20(�#���  ��  *
m_Language+�� -4    ��Name$ ComboBoxLanguageList��  StyleListLanguage#���  $	��Top=�$
��Left=�$��10, 6, 0, 0q����� *CultureInfos+ �� SelectedItem �� *CurrentCulture+ �� UpdateSourceTrigger$ PropertyChanged=�����  �� DataType" ��.R��� ��     
KeyBinding �� *ThreeLetterISOLanguageName+�� $ 
Horizontal=�$��0, 115, 0, 0q�.+��� $��20(�#���  ��  *	m_Theme+�� -5   $ ComboBoxThemeList��#���  $	��Top=�$
��Left=�$��10, 6, 0, 0q�.@��� 
 � Tag$ Light����  *light+�� $
 Dark����  *dark+