   M S B A M L   `   `   `  ����K  GBlackBoxTerminal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:BlackBoxTerminal.ModelBlackBoxTerminal.Model  5      I)clr-namespace:BlackBoxTerminal.ExtensionsBlackBoxTerminal.Extensions  5      E'clr-namespace:BlackBoxTerminal.ControlsBlackBoxTerminal.Controls  5      3clr-namespace:BlackBoxTerminalBlackBoxTerminal  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e357    1BlackBoxTerminal.Model.ByteArrayToStringConverter   ByteArrayToStringConverter:   4BlackBoxTerminal.Model.ByteArrayToHexStringConverter ! ByteArrayToHexStringConverter=   7BlackBoxTerminal.Model.ByteArrayToBinaryStringConverter $  ByteArrayToBinaryStringConverter+   %BlackBoxTerminal.Model.ColorConverter  ColorConverter.   (BlackBoxTerminal.Model.DateTimeConverter  DateTimeConverter8   2BlackBoxTerminal.Extensions.ScrollViewerExtensions  ScrollViewerExtensions  HexBackground  �� Color �� Opacity  DecBackground  OutDataTemplate �� DataType&    BlackBoxTerminal.Model.DataModel � ColumnDefinitions z� SharedSizeGroup �� Padding �� CornerRadius �� Padding �� Path	 �� 	Converter
 �� ConverterParameter �� Orientation � RowDefinitions �� ElementName �� Triggers �� Value �� Binding �� RelativeSource �� AncestorType �� 
TargetName �� Property �� Value&   BlackBoxTerminal.Controls.Output �� 
TargetType ��Name d� 	IsChecked �� Mode 	 WindowButtonStyle �� SelectedValue1   +BlackBoxTerminal.Controls.DataTypeExtension � DataContextO Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5t   A    �� 	Resources 
 Key j� 
AlignmentX j� 
AlignmentY j� Stretch  !� Visual! �� Triggers" P� Property# �� Empty$ P� Value  CueBannerBrush% J� InputBindings& �� Gesture' �� CommandParameter( �� Command) �� Stretch* J� RenderTransformOrigin+ �� Angle, �� ScaleX- �� ScaleY.   AlwaysScrollToEnd/ � IsSharedSizeScope�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .model$clr-namespace:BlackBoxTerminal.Model  5      AextensionProperties)clr-namespace:BlackBoxTerminal.Extensions  5      4controls'clr-namespace:BlackBoxTerminal.Controls  5      3blackBoxTerminalclr-namespace:BlackBoxTerminal  5      Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      %  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     7  7   7  7  7  7  '  �    7  7  7     5	      6'     5
      6+     5      6-     5      6     5      6     5      61   �� 5      $
  Blue��6,   $	 0.2Q�69   �� 5      $  	LimeGreen��6,   $	 0.2Q�6>   �� 5      "  6+   .R�5   
   � $	��4,0q�6    5      �� 5      $
 Time��6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $ 2q�6>   $	��4,2q�6J   $��Center=�6W   $��Center=�6r   
����İ���6(   �� *Time+6�   �� 5      $��1��6   $��1,1,1,1q�6%   
��� ������#fdfbef$ 0��6i   $	��0,2q�6z   $ 1q�6�   ._�5      � .+�5      �� $
��Left=�6   $
��Auto��68   $��5��6F   $	��1,1q�6P   $��1q�6]   
���   ���6�   �� $ Color�8	   $
 Brush���� 5      $��8,0,0,0q�6#   ��64   �� *Data+8	  ��5      �� 5       .R�5!   "   �� $ 
Horizontal=�6-   .+�5"   &   �  5#   *   �� 5$   .   $
��Auto �6<   �� 5%   .   $
��Auto �6<   �� 5&   .   $
��Auto �6<   �� 5'   .   $
��Auto �6<   .+�5)   *   �� $��txtAscii��6A   $��0��64   $y�	Collapsed=�6Q   $��Center=�6h   
���   ���6�   �� $ .�6�   �� 5*   *   $��txtHex��6I   $��1��61   $��1q�6>   $y�	Collapsed=�6W   8�� ._�5+   .   �� $��Center=�68   
���   �$	 2,0q�6�   ��6U   �� $
 Text�$ txtAscii��8	  6�   5,   +   �� 5-   *   $��	txtBinary��6I   $��2��61   $��1q�6>   $y�	Collapsed=�6Z   8�� ._�5.   .   �� $��Center=�68   
���   �$	 2,0q�6�   ��6U   �� $
 Text�$ txtAscii��8	  6�   5/   +   50   '   51   #    53   "   �� 54   &   $
 True��6�    62   �� $ 	ShowAscii� �� $ controls:OutputL�.a�55   *   �� $ txtAscii��61    � y�$ Visible=�6]   56   '   �� 57   &   $
 True��6�    62   �� $ ShowHex� �� $ controls:OutputL�.a�58   *   �� $ txtHex��61    � y�$ Visible=�6[   59   '   �� 5:   &   $
 True��6�    62   �� $ 
ShowBinary� �� $ controls:OutputL�.a�5;   *   �� $ 	txtBinary��61    � y�$ Visible=�6^   5<   '   5?      ��5A      �� 5B      .R�5C   "   �� $ 
Horizontal=�6-   $��0q�6F   5D      5F      5G      5H      5I      5J      �� 5L      "  6   .�5M   
   ��  �@J�SnapsToDevicePixels . 60   �� 5N   
    � �� 5O      �� 5P      .R�5Q      �  5R      �� 5S      $
��Auto �6,   �� 5T      $
��Auto �6,   �� 5U      $��* �6,   .+�5W      � $��0��6    5X      �� 5Y   "   $��* �63   �� 5Z   "   $
��Auto �63   .+�5\      �� $��0��6)   $ 
Horizontal=�69   $
��Left=�6R   $��2q�6m   .+�5]   "   �� $ chbAscii��6+   $��2q�6=   
��� ���
��� ���$��Ascii��6q    6�   �� $ 	ShowAscii� �� *TemplatedParent+$ TwoWay=��� 5^   "   $ chbHex��6+   $��2q�6<   
����  �
����  �$	��Hex��6k    6y   �� $ ShowHex� �� *TemplatedParent+$ TwoWay=��� 5_   "   $ 	chbBinary��6+   $��2q�6>   
���2�2�
���2�2�$��Decimal��6w    6�   �� $ 
ShowBinary� �� *TemplatedParent+$ TwoWay=�5`      �� 5a      $��1��6%   #��� 	 66   $��Output��6�   $��Clear��6�   
�������$��2q�6  $��2q�6  ��6b   �� $ ClearCommand� �� " �6  5b      � 5c      $��1��6    5d      �� 5e   "   $
��Auto �63   �� 5f   "   $��* �63   �� 5g   "   $
��Auto �63   .+�5i      �� $��0��6'    67   �� *
DataType+��6Z     5p      �� 5r      $��
txtCommand��6N   $��1��6`   $��2q�6p   
������ $��0,0,0,0q�6�   $��2q�6�    6&   �� *TextBoxTemplate+.��6�   ��5s   "   �� 5t   &   .sys&clr-namespace:System;assembly=mscorlib  6A   " ��6,    5u   *   ��!� 5v   .   CueBannerBrush
 $
 Left=�6Q   $ Center=�6c   $
 None=�6w     5w   2   �� 5x   6   $��Enter command here��6<   
�������6Y   5z   /   5{   +   ! 5|   *   P� 5}   .   " � ��#$ Z# 6F   . �5~   2   ��  � ��8   6O   5   /   P� 5�   .   " � ��$ 6F   Z� . �5�   2   ��  � ��8  6O   5�   /   P� 5�   .   " �@J�IsKeyboardFocused$ . . �5�   2   ��  � ��
 �����6O   5�   /   5�   '   .��5�   1   % 5�   "   �� 5�   &   $& Enter��61   ' 5�   9   �� $ 
txtCommand��( 5�   *   �� 5�   .   $ SendCommand�66    6I   �� " �5�   '   .��5�   9   5�      �� 5�      $��2��6%   $��28��65   $��28��6@   #��� 	 6M   
�������$��2q�6%  $��2q�60  ��6y   �� $ SendCommand� �� " ���6�   �� $ 
txtCommand��.��5�   "   F� ����pY�R��� @ѻ1�Jx~�Y�c`�Y�����Y����i=3]o�6� c`��J]��#@�"$2� :�� Y�;�� �        ы}}    Q�}}���}ҷ@Q�}}Y��zҷ @Q��=Y��zҷ @Q��=���}ҷ@1��,�@���}ҷ@�1��,�@Y6����=Y6����=!p}ы}}!p}ы}}Y6�ы}}������=����    ����    Y6�Q    ���}ҷ@	$) Uniform=�6  
���2�2�$��18��6?  $��18��6J  $��0,0,0,0q�6V  $* 0.5,0.5&�6g  z�5�   &   V� 5�   *   ~�5�   2   �� $+ 0Q�6B   �� 5�   2   $, 1Q�6A   $- 1Q�6L   5�   +   5�   #   5�      5�      �� 5�      $��2��6'   $
��Auto=�64   $
��Auto=�6W   . . .��5�      �� / . 8�� ��6I   �� $ DataModelList� �� *TemplatedParent+��5�   "   �� 5�   &   .R�5�   *   �� $ Vertical=�65   $��0q�6L   5�   '   ��5�   "   �� 5�   &   .�5�   *   ��  � ��$ 0q�6T   5�   '   5�      5�      5�      5�      5�      5�      5�      