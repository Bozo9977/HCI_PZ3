   M S B A M L   `   `   `  ����M  IPZ3-NetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:PZ3_NetworkService.ViewsPZ3_NetworkService.Views  5      K*clr-namespace:PZ3_NetworkService.ViewModelPZ3_NetworkService.ViewModel  5      C&clr-namespace:PZ3_NetworkService.ModelPZ3_NetworkService.Model  5      .    (PZ3_NetworkService.Views.NetworkDataView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:PZ3_NetworkService.Views     5      @	viewModel*clr-namespace:PZ3_NetworkService.ViewModel     5      7data&clr-namespace:PZ3_NetworkService.Model     5        � DataContext  5      7   1PZ3_NetworkService.ViewModel.NetworkDataViewModel  5   
   .��5&      � $	��500��6   $��	0,0,0,-50q�6   $	��Top=�6+    � RowDefinitions 5'   
   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $
��313* �6   .+�5,   
   � $��0��6   
����ح�.+�5-      ��  �� Orientation$ Vertical=�6   .+�5.      �� $��N E T W O R K   D A T A��6   $��36(�6;   $
��Bold"�6I   $��Center=�6[   $��	0,0,0,-10q�6x   5/      50      � 51   
   $��1��6   ���#93FF51.+�52      �� -   5         ��Name$ ID��52      $	��ID:��6$   $��30(�6/   $��DemiBold"�6=    �� TextAlignment$ Center=�6T   $��0,10,733,10q�6k   �� 53      -   5         ��Name$ textBoxSearch��53      $��30(�6-    �� TextAlignment$ Center=�6;   
����� �$��97,10,631,10q�6d   ��6z   ��  �� Path$ TekstZaPretragu� �� Mode$ TwoWay=�.��6�   54      �� 55      -   5        	 ��Name$	 FilterBy��55      
 �� SelectedValuePath$
 Id��59   %   $��268,10,368,10q�5;      ��57      �� *	Filters+$ TwoWay=� �� Text 58   %   �� *PomID+$ TwoWay=� �� SelectedValue 5:   %   �� *SelectedValue+5;      �� 5=      $��F i l t e r��6   $��30(�6,   
����ح�$
��Bold"�6Q   $��457,10,186,10q�6c   ��6z   �� *Filter+�� 5>      -   5        $ ID_Copy��5>      $
��Per:��6)   $��30(�65   $��DemiBold"�6C   $ Center=�6Z   $��190,10,537,10q�6q   �� 5?      $��R e f r e s h��6   $��30(�6.   
����ح�$
��Bold"�6S   $��628,10,10,10q�6e   ��6{   �� *	Refresh+5@      � 5A   
   $��2��6   
������$	��376��64   $	��Top=�6A   $��2��6Y   .+�5B      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5B         SelectionMode$ Single=�6Z      
IsReadOnly . $	��Top=�6�      AutoGenerateColumns .  $	��235��6�   $��10,10,249,0q�6�   ��6)   �� *FilterLista+$ TwoWay=� �� SelectedItem 6q   �� *SelektovanServer+   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5E      $
 NAME��6)   $	 130 6P    67   �� *Name+6P     5F      $ 	IPADDRESS��6)   $	 120 6Z    6<   �� *	IpAddress+6Z     5G      $ VALUE��6)   $ 80 6R    68   �� *Value+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5H      $ IMAGE��6-      CellTemplate 5I      �� 5J      .R�5K   "   �� $��50��6C   $	��120��6O   ��6(   �� *	Img_src+6O   5L      5N      5P      �� 5Q      $��A d d��6   $��26(�6%   $
��Bold"�63   $��556,260,4,65q�6c   $��Stretch=�6y   
����p����6E   �� *	AddServer+6�   �� 5R      $��D e l e t e��6   $��26(�6+   $
��Bold"�69   $��556,199,4,131q�6l   $��Stretch=�6�   
����p����6K   �� *DeleteServer+6�   � 5S      
����� �$��Stretch=�6&   $��10,260,260,10q�6D    � ColumnDefinitions 5T      �� 5U      $	��11* �6'   �� 5V      $	��42* �6'   .+�5X      �� -   5        $ textBlockId��5X      $	��Id:��61   $��22(�6<   
��� d �$��
10,5,30,70q�6a   �� 5Y      -   5        $ 	textBoxId��5Y      $��100,5,245,70q�6Q   $��2��6g   ��6-   �� *IdAdd+$ TwoWay=�6g   �� 5Z      -   5        $ textBlockName��5Z      $��Name:��63   $��22(�6@   
��� d �$��10,40,30,35q�6e   �� 5[      -	   5        $ textBoxName��5[      $��100,40,245,35q�6U   $��2��6l   ��6/   �� *	NameAdd+$ TwoWay=�6l   �� 5\      -
   5        $ textBlockIP��5\      $	��IP:��61   $��22(�6<   
��� d �$��
10,75,30,0q�6a   �� 5]      -   5        $ 	textBoxIP��5]      $��100,75,245,0q�6Q   $��2��6g   ��6-   �� *IpAdd+$ TwoWay=�6g   �� 5^      
���  ��$��1��6I   $
��Left=�6Y   $��	189,5,0,0q�6t   $	��Top=�6�   $��31��6�   $	��221��6�   ��6   �� *
LabelIDErr+6�   �� 5_      
���  ��$��1��6K   $
��Left=�6[   $��
189,40,0,0q�6v   $	��Top=�6�   $��31��6�   $	��221��6�   ��6   �� *LabelNameErr+6�   �� 5`      
���  ��$��1��6I   $
��Left=�6Y   $��
189,75,0,0q�6t   $	��Top=�6�   $��31��6�   $	��221��6�   ��6   �� *
LabelIPErr+6�   5a      �� 5b      $��B r o w s e��6   $��26(�6+   $
��Bold"�69   $��556,316,4,9q�6f   $��Stretch=�6{   
����p����6K   �� *Browse+6�   5d      5e      5f      