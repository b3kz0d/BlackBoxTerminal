   M S B A M L   `   `   `  ����K  GBlackBoxTerminal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BlackBoxTerminal.ControlsBlackBoxTerminal.Controls  5      ?$clr-namespace:BlackBoxTerminal.ModelBlackBoxTerminal.Model  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   DeviceItemStyle �� Property �� Value �� 
TargetType � ColumnDefinitions �� Path d� 	IsChecked �� Mode � ToolTip	 �� RelativeSource
 �� AncestorType  WindowButtonStyle �� BasedOn �� Stretch �� Mode �� Triggers P� Property P� Value �� 
TargetName ^� 
Conditions �� Binding �� Value �� ElementName&     BlackBoxTerminal.Controls.Device � RowDefinitions �� SelectedItem �� UpdateSourceTrigger�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      4controls'clr-namespace:BlackBoxTerminal.Controls  5      .model$clr-namespace:BlackBoxTerminal.Model  5      %�  &	        7  7  7  '       7   �� 5      "  ��6   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5      � $��30��6   .+�5      �� $��ItemBackground��6!   
������$��0q�6Q   
�������6e   � 5      $��DefaultTemplate��6    5      �� 5   "   $��* �63   �� 5   "   $
��Auto �63   .+�5      �� $��0��6(   $��4q�68   $��Center=�6C   ��6^   �� $
 Name��� 5      $��1��6'   
������
������ 6h   �� $ IsMaster�$ TwoWay=�5      � 5       $��SelectedTemplate��6   $y�	Collapsed=�67   
������� 5!      �� 5"   "   $��* �63   �� 5#   "   $
��Auto �63   �� 5$   "   $
��Auto �63   �� 5%   "   $
��Auto �63   .+�5'      �� $��4,0,0,0q�6(   $��Center=�69   $��0��6T   ��6d   �� $
 Name��� 5(      $��1��6'   
������
������ 6h   �� $ IsMaster�$ TwoWay=��� 5)      $��2��6&   $
 Edit��6�   
���������66   �� $ EditCommand�	 �� $
 controls:DeviceL���5*   "   �� 5+   &   8   "  ��6Y   .�5,   *   ��  � ��
 �����6G   5-   '   .��5/   "   � $��30��6'   $��30��62   $z�1,0,0,1,0,1W�6>   .+�50   &   F� �����    �����!�@���$���?
@��=�	%�� ѥ�3��g�fO�&�э>�/�Ѯ�� �/�� �� �j���Ʀ��!@�\��`���,�@�gD�+�G�@AKpe �      P?SXV���J����Z�)1|0��?ԏ��U_\5�?Q4��]�e>֢ @S+����X�"@!����� ����� ��UwD�� QGtG�  �<Z@Q�`7e�@�l�mo^ �$�����?ȡ?e �      P?	$��16��51   ;   $��16��6F   $��Center=�6R   $��Center=�6m   $ Uniform=�52   A   ��6S   �� *
Foreground+	 �� "
 ��$ FindAncestor=�53   #   54      �� 56      $��3��6&   $ Remove��6�   
���������66   �� $ RemoveCommand�	 �� $
 controls:DeviceL���57   "   �� 58   &   8  "  ��6Y   .�59   *   ��  � ��
 �����6G   5:   '   .��5<   "   � $��30��6'   $��30��62   $z�1,0,0,1,0,1W�6>   .+�5=   &   F� ����p̶� 3I�o#@�̶� B���7� B�Q�7� 3I�o#@0�C���@3I�o#@��C���@B��Y+ct�"@B�Y+ct�"@3I�o#@0�ay�ʊ@3I�o#@��ay�ʊ@B����HFs�@B���HFs�@3I�o#@p    �L��@Q�N�L��@��� 	�E�����J�?	�E0sm�|-@Rߦ����?sm�|-@����w@Q*� ����w@Q*� Rߦ����?���HFs�@    �̶�     Q̶� ����w@Q�N����w@Q�N��1��@Q    ��1��@Q    ����w@��HFs�@����w@	$��16��5>   ;   $��16��6F   $��Center=�6R   $��Center=�6m   $ Uniform=�5?   A   ��6S   �� *
Foreground+	 �� "
 ��$ FindAncestor=�5@   #   5A      5C      � 5D      $��EditTemplate��6   $y�	Collapsed=�63   
������� 5E      �� 5F   "   $��* �63   �� 5G   "   $��30 �63   �� 5H   "   $��30 �63   .+�5J      �� $��4q�6&   $��Center=�61   $��0��6L   ��6\   �� $
 Name��� 5K      $��1��6%   $ Apply��6�   
��� �|���65   �� $ EditCommand�	 �� $
 controls:DeviceL���5L   "   �� 5M   &   8  "  ��6Y   .�5N   *   ��  � ��
 � �|�6G   5O   '   .��5Q   "   � $��30��6'   $��30��62   $z�1,0,0,1,0,1W�6>   .+�5R   &   F� ����0��"`}@�����(�>�BZ'~@����ߋ���BT8@����ߋ��Zѷ$�@�����(�>ZQ�=�@@P��o@����@�(1��#@��k�~@�(�V/@��(w@�%�zY@���}p@�w�Rj@�g$<e@ A����s@�"��\@A��M�p@�E0�eN@���Lj@���d@�AJ�$@����b@�?���w7@���G�a@�E�y�C@��:�`@ �"h^�P@��w��b@��"�7�V@���5\d@��"Ȱa_@��7�ef@�g$\I`@��Wخf@�g$�Nd@����h@�g�ۦd@��h@h�Hje@���wh@h��vg@ ���f@h�d�h@���e@�����p@%�
�Z@��"�{w@�J\T�C@��"`}@�����(�>	$��16��5S   ;   $��16��6F   $��Center=�6R   $��Center=�6m   $ Uniform=�5T   A   ��6S   �� *
Foreground+	 �� "
 ��$ FindAncestor=�5U   #   5V      5W      5X       5Y      P� 5Z       �@��
IsSelected . . �5[      �� $ SelectedTemplate��6%    � y�$ Visible=�6Z   5\      P� 5]       �@J�IsMouseOver . . �5^      �� $ ItemBackground��6%    � ��$ 1q�6]   6i   5_      ^� 5`       5a      �� 5b   "    6,   �� $ 
IsEditMode�	 �� $
 controls:DeviceL� True6�   �� 5c   "    6,   �� $ SelectedTemplate��$ 
Visibility� Visible6m   .0�5e      �� $ EditTemplate��6%    � y�$ Visible=�6U   5f      5h      5j      5k      �� 5o      "    6   .�5q   
   ��  � �� 5r      �� 5s      "   6"   .R�5t      �� $��1q�6   
������._�5u      �  5v      �� 5w      $
��Auto �6,   �� 5x      $��* �6,   .+�5z      � $��0��6   
������ 5{      �� 5|   "   $��* �63   �� 5}   "   $
��Auto �63   .+�5      �� $��0��6(   $��4q�68   $
��Bold"�6C   
�������$��DeviceCollection��6h   �� 5�      $��1��6%   
�������$��Add new��6H   
������ ��6Z   �� $ 
AddCommand�	 �� $
 controls:DeviceL�5�      5�      �� 5�      $��1��6'   $
��Auto=�64   .��5�      �� $��0q�6�   8��  ��6"   �� $ DeviceCollection�	 �� *TemplatedParent+ 5�   &   �� $ SelectedDevice�	 �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=�5�      5�      5�      5�      5�      5�      5�      5�      