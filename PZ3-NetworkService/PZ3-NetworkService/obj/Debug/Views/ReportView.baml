   M S B A M L   `   `   `  ����M  IPZ3-NetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:PZ3_NetworkService.ViewsPZ3_NetworkService.Views  5      K*clr-namespace:PZ3_NetworkService.ViewModelPZ3_NetworkService.ViewModel  5      C&clr-namespace:PZ3_NetworkService.ModelPZ3_NetworkService.Model  5      )    #PZ3_NetworkService.Views.ReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:PZ3_NetworkService.Views     5      @	viewModel*clr-namespace:PZ3_NetworkService.ViewModel     5      7data&clr-namespace:PZ3_NetworkService.Model     5        � DataContext  5      2   ,PZ3_NetworkService.ViewModel.ReportViewModel  5   
   .��5#      � $	��500��6   $	��Top=�6   
����+�� � RowDefinitions 5$   
   �� 5%      $
��Auto �6   �� 5&      $
��Auto �6   �� 5'      $
��Auto �6   .+�5)   
   � $��0��6   
����ح�.+�5*      ��  �� Orientation$ Vertical=�6   .+�5+      �� $��R  E  P  O  R  T��6   $��36(�64   $��Center=�6B   $��	0,0,0,-10q�6_   $
��Bold"�6r   5,      5-      � 5.   
   $��1��6   .+�50      �� -   5         ��Name$ 
labelStart��50      $��S t a r t   d a t e :��6(   $��18(�6I   $��Center=�6W   $	��Top=�6{   $��30,2,0,0q�6�   $��30��6�   $	��200��6�   $
��Left=�6�   $	��Top=�6�   $
��Bold"�6�   �� 51      -   5        $ labelEnd��51      $��E n d   d a t e :��6&   $��18(�6B   $��Center=�6P   $	��Top=�6t   $��	300,2,0,0q�6�   $��30��6�   $	��200��6�   $
��Left=�6�   $	��Top=�6�   $
��Bold"�6�   (  "System.Windows.Controls.DatePicker  52      -   5          Name$ datePicker1��52      $
��Left=�6X   $	��200��6t   $��	30,35,0,0q�6�   $��2q�6�   
���i��   SelectedDate 6.   �� *SelektovanDatum1+6�     53      -   5        $ datePicker2��53      $
��Left=�6X   $	��200��6t   $��
300,35,0,0q�6�   $��2q�6�   
���i�� 6.   �� *SelektovanDatum2+6�   �� 54      -   5         ��Name$ 
buttonShow��54      $��
S  H  O  W��6E   $��25(�6Z   $
��Bold"�6h   $��40��6z   $	��200��6�   $��550,20,10,10q�6�   ��6)   �� *	Prikazi+6�   55      � 56   
   $��2��6   .+�57      �� -   5         ��Name$ richTextBox��57   -   
����� �$	��340��6B   $	��700��6O   $��Visible=�6\   $
��Auto=�6�    �� 
IsReadOnly . $��Center=�6�   $��Center=�6�   $��10,10,10,10q�6  $��2q�6   
���i��. �58      /� .T�59      J� .*�6    .*�5:      �� �6   �� *Tekst+	 �� Mode$	 TwoWay=�5;      5<      5=      5>      5?      5@      