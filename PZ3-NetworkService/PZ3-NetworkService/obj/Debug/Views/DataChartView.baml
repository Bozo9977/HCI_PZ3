   M S B A M L   `   `   `  ����M  IPZ3-NetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:PZ3_NetworkService.ViewsPZ3_NetworkService.Views  5      K*clr-namespace:PZ3_NetworkService.ViewModelPZ3_NetworkService.ViewModel  5      C&clr-namespace:PZ3_NetworkService.ModelPZ3_NetworkService.Model  5      ,    &PZ3_NetworkService.Views.DataChartView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:PZ3_NetworkService.Views     5      @	viewModel*clr-namespace:PZ3_NetworkService.ViewModel     5      7data&clr-namespace:PZ3_NetworkService.Model     5        � DataContext  5      5   /PZ3_NetworkService.ViewModel.DataChartViewModel  5   
    � 	Resources 5       �� DataType%   PZ3_NetworkService.Model.Server �� Orientation �� Path �� Mode��%)  (��       5      *, +)�� 6
   "  6   .R�5      �� $ Vertical=�6   .+�5      �� $��14(�5      $
��Wrap=�5      ��5      �� $ Id�$ OneWay=�5      �� 5      $
��Wrap=�5      ��5      �� $
 Name�$ OneWay=�5      �� 5      $
��Wrap=�5      ��5      �� $ 	IpAddress�$ OneWay=�5      �� 5      $
��Wrap=�5      ��5      �� $ Img_src�$ OneWay=�5      �� 5      $
��Wrap=�5      ��5      �� $ Value�$ OneWay=�5      5       5!      5"      .��5#      �  � RowDefinitions 5$   
   �� 5%      $
��Auto �6   �� 5&      $��* �6   .+�5(   
   � $��0��6   ���#63A8E9.+�5)      �� $ Vertical=�6   .+�5*      �� $��D A T A   C H A R T��6   $��36(�67   $
��Bold"�6E   $��Center=�6W   $��	0,0,0,-10q�6t   5+      5,      � 5-   
   $��1��6   ���#63FFE9.+�5/      ��  �� DisplayMemberPath$
 Name��6d   $
��Left=�6~   $��	80,10,0,0q�6�   $	��Top=�6�   $	��150��6�   $��50��6�   ��6   �� *ObjectsChart+ �� SelectedItem 6<   �� *SelectedObject+50      �� 51      -   5        	 ��Name$	 buttonChart��51      $��
S  H  O  W��6F   $��25(�6[   $
��Bold"�6i   $��50��6{   $��511,10,10,0q�6�   $	��Top=�6�   ��6*   �� *	Prikazi+
 � Triggers
 52      :� 53       :� RoutedEvent$ Button.Click��6$   55      57      �� 59      $��20(�6/   $
��Left=�6=   $��10,106,0,10q�6Y   $��65��6n   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6y   ��6   �� *Label1+6y   �� 5;      -   5        $��canvasChart��5;      $	��330��6)   
�������$	��710��6I   $��Right=�6U   $	��Top=�6q   $��
0,100,10,0q�6�   .+�5<      � 
���   �$��.3��6F    � Points 6   �� *Points+6F   �� 5=      ��6   �� *	RectItems+��5>      �� 5?      .R�5@      �� 5A      ��5C      �� 5D       �� 
TargetType" ��6    .�5E      ��  �� Property �@��Left �� Value 6<   �� *X+�� 5F       �@��Bottom 6>   �� *Y+5G      ��5I      �� 5J      .R�5K      �� 
����  ���6(   �� *Width+��6@   �� *Height+6Z   5M      5O      5P      �� 5Q      $
��Left=�6   $��
265,10,0,0q�63   $
��Wrap=�6G   
���  ��$��20(�6�   $	��Top=�6�   $��62��6�   $	��221��6�   ��6[   �� *Error+6�   5R      5S      5T      