   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   C ?apptest1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:apptest1apptest1 5   	      apptest1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9system&clr-namespace:System;assembly=mscorlib     5   	   (localclr-namespace:apptest1     5   	   -   5          �Name$  window��5   	    � Title$ testApp��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ Manual=�5   	    � ShowInTaskbar .   � Topmost .  J� 	AllowDrop .  � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������ 	 � 	Resources	 5      
 �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   "
 ��6   .�5      ��  �@��BitmapScalingMode$ HighQuality=�6@   6V   �� 5        � ��$ Uniform=�6(   6:   5!      5#      .��5%      � -   5        $��
ParentGrid��5%   $   
������  .    FocusVisual#���   6G   $	��Top=�6m   $��Center=�6�    � RowDefinitions 5&   
   �� 5'      $��1* �6   6*   �� 5(      $��1* �6   6*   .+�5*   
   �� -   5        $��MainGridBorder��5*       �� CornerRadius$ 0,0,5,5��6'   
���  ��$��6q�6P    J� Effect 5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,         
BlurRadius$ 20Q�6#      Opacity$	 0.2Q�63   ._�5.      A� -   5         A�Name$ MainGrid��5.   /    A� Columns$ 2��6    A� Rows$ 1��6&   
������� . $	��Top=�6e   .+�5/      �� -   5         ��Name$ SettingsButton��5/      $��48��6}    . ��6H   �� *Height+ �� ElementName$ SettingsButton��.��50      �� $��/Icons/Settings.ico��6   $��Right=�69   6W   51      52      53      �� 54   
   -   5        $��TestTextBlock��54   4   $��2��6   
�������$
��Wrap=�6I   $��	TextBlock��6]    J� RenderTransformOrigin$ 0.5,0.5&�6n   $��Center=�6�   55      57      