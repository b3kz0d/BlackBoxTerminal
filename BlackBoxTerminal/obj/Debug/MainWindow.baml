   M S B A M L   `   `   `  ����K  GBlackBoxTerminal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BlackBoxTerminalBlackBoxTerminal  5   	   ?$clr-namespace:BlackBoxTerminal.ModelBlackBoxTerminal.Model  5   	   E'clr-namespace:BlackBoxTerminal.ControlsBlackBoxTerminal.Controls  5   	   !    BlackBoxTerminal.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,cclr-namespace:BlackBoxTerminal     5   	   6model$clr-namespace:BlackBoxTerminal.Model     5   	   <controls'clr-namespace:BlackBoxTerminal.Controls     5   	      WindowMetroStyle#���   5   	     � WindowState$  	Maximized=�5   	    � Title$ BlackBox Terminal��5	   	   $	��500��6#   $	��900��63    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$@ :/BlackBoxTerminal;component/Resources/BlackBoxTerminal.ico��5   	    � FocusVisualStyle 5
   	   Z� .��5      � .+�5   
   �� $��4q�6   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      � $��0��6   .+�5      �� 
�������$��0,0,0,1q�62   $��Bottom=�6L   +   %BlackBoxTerminal.Controls.ContextMenu  5      $
��Left=�6L      Items 6+   ��  �� Path$ 	MenuItems�6L   5      � 5      $��1��6   $y�Visible=�6$   .+�5      (   "BlackBoxTerminal.Controls.Settings  5      � 5       $��2��6   .+�5!      �  � ColumnDefinitions 5"      �� 5#      $��* �6/   �� 5$      $��* �6/    5&      �� 5'      $��* �6,   �� 5(      $��* �6,   .+�5*      �� $��0��6!   $��0��61   $��1q�6>   
�������
������ $��0,2,1,1q�6�   ._�5+      &   BlackBoxTerminal.Controls.Output  	   DataModelList	 6/   �� $ 
OutputList�
 �� RelativeSource
 ��  �� AncestorType" �5,      �� 5-      $��1��6!   $��0��61   $��0q�6>   $��1,2,0,1q�6R   ._�5.      &    BlackBoxTerminal.Controls.Device  -   5          Name$ DeviceControl��5.   .      DeviceCollection 6E   �� $ DeviceCollection�
 �� " �5/      �� 50      $��0��6!   $��1��61   $��1q�6>   
�������$��0,1,1,0q�6j   ._�51      %   BlackBoxTerminal.Controls.Input     DataModelList 6-   �� $ 	InputList�
 �� " �52      �� 53      $��1��6!   $��1��61   $��0q�6>   $��1,1,0,0q�6R   ._�54      $   BlackBoxTerminal.Controls.Rule     Device 6,   �� $ SelectedDevice� �� ElementName$ DeviceControl�� �� Mode$ TwoWay=�55      56      57      � 58      $��2��6   
���   �$y�	Collapsed=�67    J� Opacity$	 0.2Q�6N   6^   � 59      $��3��6   .+�5:      �� ��6   �� *
SampleByte+5;      5=      5>      5?      5@      