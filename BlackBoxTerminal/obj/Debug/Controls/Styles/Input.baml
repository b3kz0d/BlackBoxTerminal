   M S B A M L   `   `   `  ����K  GBlackBoxTerminal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:BlackBoxTerminal.ModelBlackBoxTerminal.Model  5      I)clr-namespace:BlackBoxTerminal.ExtensionsBlackBoxTerminal.Extensions  5      E'clr-namespace:BlackBoxTerminal.ControlsBlackBoxTerminal.Controls  5      3clr-namespace:BlackBoxTerminalBlackBoxTerminal  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0897    1BlackBoxTerminal.Model.ByteArrayToStringConverter   ByteArrayToStringConverter:   4BlackBoxTerminal.Model.ByteArrayToHexStringConverter ! ByteArrayToHexStringConverter=   7BlackBoxTerminal.Model.ByteArrayToBinaryStringConverter $  ByteArrayToBinaryStringConverter8   2BlackBoxTerminal.Extensions.ScrollViewerExtensions  ScrollViewerExtensions  InputDataTemplate  �� DataType&    BlackBoxTerminal.Model.DataModel � ColumnDefinitions z� SharedSizeGroup �� Padding �� CornerRadius �� Padding �� Path  ColorConverter �� 	Converter �� ConverterParameter	 �� Orientation
 � RowDefinitions  HexBackground �� ElementName  DecBackground �� Triggers �� Value �� Binding �� RelativeSource �� AncestorType �� 
TargetName �� Property �� Value%   BlackBoxTerminal.Controls.Input �� 
TargetType �� 
TargetType ��Name d� 	IsChecked �� Mode  WindowButtonStyle   AlwaysScrollToEnd � IsSharedSizeScope �� Triggers�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .model$clr-namespace:BlackBoxTerminal.Model  5      AextensionProperties)clr-namespace:BlackBoxTerminal.Extensions  5      4controls'clr-namespace:BlackBoxTerminal.Controls  5      3blackBoxTerminalclr-namespace:BlackBoxTerminal  5      %3  &	        &	      &	 &     &	 9     &	 L     7  7   7  7  7  7  '  �    7     5      6'     5	      6+     5
      6-     5      61   �� 5      "   6-   .R�5   
   � $	��4,0q�6    5      �� 5      $
 Time��6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $ 2q�6>   $	��4,2q�6J   $��Center=�6W   $��Center=�6r   
����İ���6(   �� *Time+6�   �� 5      $��1��6   $��1,1,1,1q�6%   
��� ������#fdfbef$ 0��6i   $	��0,2q�6z   $ 1q�6�   ._�5      � .+�5      �� $
��Left=�6   $
��Auto��68   $��5��6F   $	��1,1q�6P   
�������6]   �� 5      $
��Left=�6   $
��Auto��68   $��5��6F   $	��1,1q�6P   $��1q�6]   
���   ���6�   �� $ Color�8   $ Brush���� 5      $��8,0,0,0q�6#   ��64   �� *Data+8  ��5      �� 5      .R�5   "   �� $	 
Horizontal=�6-   .+�5   &   � 
 5    *   �� 5!   .   $
��Auto �6<   �� 5"   .   $
��Auto �6<   �� 5#   .   $
��Auto �6<   �� 5$   .   $
��Auto �6<   .+�5&   *   �� $��txtAscii��6A   $��0��64   $y�	Collapsed=�6Q   $��Center=�6h   
���   ���6�   �� $ .�6�   �� 5'   *   $��txtHex��6I   $��1��61   $��1q�6>   $y�	Collapsed=�6W   8�� ._�5(   .   �� $��Center=�68   
���   �$	 2,0q�6�   ��6U   �� $
 Text�$ txtAscii��8  6�   5)   +   �� 5*   *   $��	txtBinary��6I   $��2��61   $��1q�6>   $y�	Collapsed=�6Z   8�� ._�5+   .   �� $��Center=�68   
���   �$	 2,0q�6�   ��6U   �� $
 Text�$ txtAscii��8  6�   5,   +   57   '   58   #    5:   "   �� 5;   &   $
 True��6�    62   �� $ 	ShowAscii� �� $ controls:InputL�.a�5<   *   �� $ txtAscii��61    � y�$ Visible=�6]   5=   '   �� 5>   &   $
 True��6�    62   �� $ ShowHex� �� $ controls:InputL�.a�5?   *   �� $ txtHex��61    � y�$ Visible=�6[   5@   '   �� 5A   &   $
 True��6�    62   �� $ 
ShowBinary� �� $ controls:InputL�.a�5B   *   �� $ 	txtBinary��61    � y�$ Visible=�6^   5C   '   5F      ��5H      �� 5I      .R�5J   "   �� $	 
Horizontal=�6-   $��0q�6F   5K      5M      5N      5O      5P      5Q      �� 5S      "  6   .�5T   
   ��  �@J�SnapsToDevicePixels . 60   �� 5U   
    � �� 5V      �� 5W      "  6"   .R�5X      � 
 5Y      �� 5Z      $
��Auto �6,   �� 5[      $��* �6,   .+�5]      � $��0��6   .+�5^      �� $	 
Horizontal=�6)   $
��Left=�6B   $��2q�6]   .+�5_   "   �� $ chbAscii��6+   $��2q�6=   
��� ���
��� ���$��Ascii��6q    6�   �� $ 	ShowAscii� �� *TemplatedParent+$ TwoWay=��� 5`   "   $ chbHex��6+   $��2q�6<   
����  �
����  �$	��Hex��6k    6y   �� $ ShowHex� �� *TemplatedParent+$ TwoWay=��� 5a   "   $ 	chbBinary��6+   $��2q�6>   
���2�2�
���2�2�$��Decimal��6w    6�   �� $ 
ShowBinary� �� *TemplatedParent+$ TwoWay=�5b      �� 5c      $	 
Horizontal=�6*   $��Right=�6D   .+�5d   "   �� #���  6*   $��Input��6�   $
��Save��6�   
�������$��2q�6  $��2q�6  ��6V   �� $ SaveCommand� �� $! blackBoxTerminal:MainWindowL�6  �� 5e   "   #���  6*   $��Input��6�   $��Clear��6�   
�������$��2q�6  $��2q�6  ��6W   �� $ ClearCommand� �� $! blackBoxTerminal:MainWindowL�6  5f      5g      �� 5h      $��1��6'   $
��Auto=�64   $
��Auto=�6W    . .��5i      ��  . 8��  ��5j   +   �� $ DataModelList� �� *TemplatedParent+��5n   "   �� 5o   &   .R�5p   *   �� $	 Vertical=�65   $��0q�6L   5q   '   ��5s   "   �� 5t   &   .�5u   *   ��  � ��$ 0q�6T   5v   '   5x      5y      5z       5{      5�      5�      5�      5�      