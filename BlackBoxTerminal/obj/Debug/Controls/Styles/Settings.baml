   M S B A M L   `   `   `  ����K  GBlackBoxTerminal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BlackBoxTerminalBlackBoxTerminal  5      ?$clr-namespace:BlackBoxTerminal.ModelBlackBoxTerminal.Model  5      I)clr-namespace:BlackBoxTerminal.ExtensionsBlackBoxTerminal.Extensions  5      E'clr-namespace:BlackBoxTerminal.ControlsBlackBoxTerminal.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   SettingsTextBlock �� Property �� Value  SettingsComboBox(    "BlackBoxTerminal.Controls.Settings � ColumnDefinitions � RowDefinitions3   -BlackBoxTerminal.Extensions.ComPortsExtension �� SelectedItem �� Path �� RelativeSource3   -BlackBoxTerminal.Extensions.BitRatesExtension1   +BlackBoxTerminal.Extensions.ParityExtension3   -BlackBoxTerminal.Extensions.DataBitsExtension3   -BlackBoxTerminal.Extensions.StopBitsExtension4   .BlackBoxTerminal.Extensions.HandshakeExtension �� Triggers	 �� Value
 �� Binding �� AncestorType �� 
TargetName�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      $cclr-namespace:BlackBoxTerminal  5      .model$clr-namespace:BlackBoxTerminal.Model  5      8
extensions)clr-namespace:BlackBoxTerminal.Extensions  5      4controls'clr-namespace:BlackBoxTerminal.Controls  5      %  &	        &	 �     '   P    7   7   7   7   7   7   7   7   7   7   7   7   �� 5      "  ��6   .�5   
   ��  � ��$ 4q�6#   �� 5	   
    � ��$ Right=�60   �� 5
   
    � ��$ Center=�6.   5      �� 5      "  ��6   .�5   
   ��  � ��$ 4q�6#   �� 5   
    � ��$	 120��6"   �� 5   
    � ��$
 Left=�60   �� 5   
    � ��$ Center=�6.   5      �� 5      "    6   .�5   
   ��  �@J�SnapsToDevicePixels . 60   �� 5   
    � �� 5      �� 5      .R�5      � $��	MainPanel��6   $y�	Collapsed=�6,   .+�5      �  5      �� 5   "   $
��Auto �63   �� 5   "   $
��Auto �63   �� 5   "   $
��Auto �63   �� 5    "   $
��Auto �63   �� 5!   "   $
��Auto �63   �� 5"   "   $
��Auto �63   �� 5#   "   $
��Auto �63   �� 5$   "   $
��Auto �63    5&      �� 5'   "   $
��Auto �60   �� 5(   "   $
��Auto �60   .+�5,      �� $��0��6(   $��0��65   $��	COM Port:��6E   8��  6V   �� 5-      $��0��6'   $��1��64   ��6D      5.   #   �� $ ComPort� �� *TemplatedParent+�� 51      $��1��6(   $��0��65   $��	Bit Rate:��6E   8�� 6V   �� 52      $��1��6'   $��1��64   ��53   #      54   #   �� $ BitRate� �� *TemplatedParent+�� 57      $��0��6(   $��2��65   $��Parity:��6E   8�� 6T   �� 58      $��0��6'   $��3��64   ��59   #      5:   #   �� $ Parity� �� *TemplatedParent+�� 5>      $��1��6(   $��2��65   $��
Data Bits:��6E   8�� 6W   �� 5?      $��1��6'   $��3��64   ��5@   #      5A   #   �� $ DataBit� �� *TemplatedParent+�� 5D      $��0��6(   $��4��65   $��
Stop Bits:��6E   8�� 6W   �� 5E      $��0��6'   $��5��64   ��5F   #      5G   #   �� $ StopBits� �� *TemplatedParent+�� 5K      $��1��6(   $��4��65   $��
Handshake:��6E   8�� 6W   �� 5L      $��1��6'   $��5��5M   #   ��63      5N   #   �� $ 	Handshake� �� *TemplatedParent+5S      � 5T      $��DisabledSettings��6   $y�	Collapsed=�67   
������� 5U      �� 5V   "   $
��Auto �63   �� 5W   "   $
��Auto �63   �� 5X   "   $
��Auto �63   �� 5Y   "   $
��Auto �63   �� 5Z   "   $
��Auto �63   �� 5[   "   $
��Auto �63   �� 5\   "   $
��Auto �63   �� 5]   "   $
��Auto �63    5_      �� 5`   "   $
��Auto �60   �� 5a   "   $
��Auto �60   .+�5e      �� $��0��6(   $��0��65   $��	COM Port:��6E   8�� 6V   �� 5f      $��0��6'   $��1��64   {�.  ��6D      5g   #   �� $ ComPort� �� *TemplatedParent+�� 5j      $��1��6(   $��0��65   $��	Bit Rate:��6E   8�� 6V   �� 5k      $��1��6'   $��1��64   {�.  ��5l   #      5m   #   �� $ BitRate� �� *TemplatedParent+�� 5p      $��0��6(   $��2��65   $��Parity:��6E   8�� 6T   �� 5q      $��0��6'   $��3��64   {�.  ��5r   #      5s   #   �� $ Parity� �� *TemplatedParent+�� 5w      $��1��6(   $��2��65   $��
Data Bits:��6E   8��	 6W   �� 5x      $��1��6'   $��3��64   {�.  ��5y   #      5z   #   �� $ DataBit� �� *TemplatedParent+�� 5}      $��0��6(   $��4��65   $��
Stop Bits:��6E   8��
 6W   �� 5~      $��0��6'   $��5��64   {�.  ��5   #      5�   #   �� $ StopBits� �� *TemplatedParent+�� 5�      $��1��6(   $��4��65   $��
Handshake:��6E   8�� 6W   �� 5�      $��1��6'   {�.  $��5��5�   #   ��63      5�   #   �� $ 	Handshake� �� *TemplatedParent+5�      �� 5�      
�������$��1,0,1,1q�66   5�       5�      �� 5�      $
	 True��6   
 6&   �� $ IsConnected� �� $ WindowL�.a�5�      �� $ DisabledSettings��6%    � y�$ Visible=�6Y   5�      �� 5�      $
	 True��6�   
 6&   �� $ IsSettingsVisible� �� $ WindowL�.a�5�      �� $ 	MainPanel��6%    � y�$ Visible=�6R   5�      5�      5�      5�      5�      