   M S B A M L   `   `   `  ����  WPFPractise    WPFPractise.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Foreground �� Color  Button.MouseOver.Foreground  Button.Pressed.Foreground  Button.Disabled.Foreground  
TestButton �� 
TargetType �� 
TargetType	 ��Name
 ��Name �� Triggers P� Property P� Value �� 
TargetName  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background 	 Button.Pressed.Border 
 Button.Disabled.Background  Button.Disabled.Border��%]  &	        &	 �     &	 �     &	 �     &	     &	 ?    7   7  7  7  7 	 7 
 7  7  �� 5	   
   .�5
      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   $
 true��6E   $��1��6`   #��� ��6t   5      5      5      �� 5   
   $ 	#FF34FF00��6;   �� 5   
   $ 	#FF185070��6>   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6#   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 1q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5       �� $	 border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   ._�5!      �� $
 contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5"       5#      P� 5$       �@��IsDefaulted$
 true��6=   . �5%   "   �� $ border��6@   # � ��6T    � ��5&      P� 5'       �@J�IsMouseOver$
 true��6=   . �5(   "   �� $ border��6?   8   � ��6S   �� 5)   "   $ border��6@   8   � ��6T   5*      P� 5+       � ��$
 true��6;   . �5,   "   �� $ border��6?   8   � ��6S   �� 5-   "   $ border��6@   8   � ��6T   5.      P� 5/       � {�$ false��6;   . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   �� 52   "   $ contentPresenter��6K   8   � ��6i   53      55      57      58      59      .��5:      � .+�5;   
   �� #���  6   $	��100��66   $��30��6B   $
��OK��6N   $��285,130,415,275q�6\   �� 5<   
    5=        path  pathStoryboard z� DoesRotateWithTangent z� PathGeometry g� RepeatBehavior �� 
TargetName �� TargetProperty g� Duration��%  &	       &	 O     7  B� 5>      $;��5M 10,100 C 35,0 135,0 160,100 180,190 285,200 310,100C�6,   �� 5?      .��5@      z� $
 True��5A      8   $ Forever��5C      $ ButtonMatrixTransform��5D      $ Matrix�5E      $ 0:0:5D�5F      5G      5H       � Triggers 5J      :� 5K       :� RoutedEvent$ Control.Loaded��6   .[�5L      �� #��[ 6&   5M      .+�5P      F� #��[ 5Q   	   
���   �$��1��5S   	   A� 5U      $��20��5V   	   $��20��5W   	   
���  ��z�5Y      u� 5Z      -   5        ButtonMatrixTransform��5Z   &   5\      5]      �� 5_   
    �� Orientation$ 
Horizontal=�6   .+�5`      �� $��5q�6   $��50��6#   $��50��6.   
���� ��6:   �� 5a      $��5q�6   $��50��6#   $��50��6.   
��� ���6:   �� 5b      $��5q�6   $��50��6#   $��50��6.   
��� � �6:   �� 5c      $��5q�6   $��Orientation="Vertical"��6#   $��Center=�6K   6h   5d      5e      5g      