   M S B A M L   `   `   `  ���� E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  a ]PresentationFramework.Aero, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  	umk_shell   UMKShell_v1.frm_main   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    >d2http://schemas.microsoft.com/expression/blend/2008    8l,clr-namespace:UIControls;assembly=UIControls    Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    mMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero    :Custom-http://schemas.microsoft.com/wpf/2008/toolkit  +Custom1http://kent.boogaart/controls  -     �Name$  Window�� � Title$ frm_main��$	��640��$	��480��$	��640��$	��480�� � Icon$ images\umk_shell.ico�� � DataContext ��  �� RelativeSource �� *Self+ � 	Resources    
lbl_button �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name J� SnapsToDevicePixels �� Padding �� Triggers P� Property P� Value �� 
TargetName  TextBoxBorder �� EndPoint �� 
StartPoint � MappingMode � Color � Offset  	SearchBox �� BasedOn,  &Microsoft.Windows.Themes.ListBoxChrome  Name   
Background   BorderBrush   BorderThickness J� IsKeyboardFocusWithin   RenderFocused J� IsMouseOver   RenderMouseOver ��Name  link_labels  ��Name! O� 	GlowColor" O� Opacity��%   &	        &	 �    &	 Q    7  &	     �� " ��.���  � ��# � ����  � ��
 ���� ��  � ��$ 5q���  � ��$
 Left=���  � ��$	 Top=���  � �� �� "	 ��.R��� $
 border�� . #��z��# z��$��2,2,2,2q�._��� # z #��z��#��z����.  P�  �@J�IsMouseOver . . ��� $ border�� �@��CornerRadius$ 1,0,0,0���� $ border�� � �� �	#FF000000�� $ border�� � ��$ 1,1,1,1q�P�  � {� .  . ��� # � �� � ���� $
 0,20&�$	 0,0&�$ Absolute=�.��� $ #ABADB3��$
 0.05Q�� $ #E2E3EA��$
 0.07Q�� $ #E3E9EF��$ 1Q��� " �� Z� .���  � ��# � ����  � ��# � ����  � ��8   ��  � ��$ 1q���  � ��$ 1q���  �@J�	AllowDrop . ��  �@�FocusVisualStyle Z� ��  � �� �� "	 ��.R�  $ Bd�� . # z��# z��# z��# z # z ._��� $ PART_ContentHost��# z  P�  �@J�IsMouseOver . P�  � {� .  . ��� $ Bd��# � �� �@ 
Background�� # � �� � ���� " ��.���  � ��# � ����  � ��
 ���� ��  � ��$ 5q���  � ��$
 Left=���  � ��$	 Top=���  � �� �� "	 ��.R��� $
 border�� . #��z��#��z��# z��._��� $  contentPresenter��# z #��z��#��z����.  P�  �@J�IsMouseOver . . ���  � �� �#5e96b9�� $ border�� � �� �	#FF000000�� $ contentPresenter�� �@J�BitmapEffect O� $! #148fdd��$" 0.825Q�P�  � {� .  . ��� # � �� � ��.��� -   # �Name$# 
LayoutRoot��$ � RowDefinitions$ �� $
��120* ��� $
��322* ��� $��0* �% � ColumnDefinitions% �� $��* �.+��� -   & ��Name$& header_back��$��52��$��-3,-2.5,-3,0q�$	��Top=�
���   ����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFC6B5B5��$ 0Q�� $ White��$ 1Q��� -   $	& rec��$��	0,52,0,25q�$��2��
��������� -   ' ��Name$' 	gb_header��$	��Top=�$��48��.+��� -   ( ��Name$( img_left��$��42��$
��Fill=�$��images\btn_left.png��) � ToolTip$+) %Предыдущая страница��{�. $
��42.5��* �� Left$* 7��
+ �� Top$+ 3��, J� BitmapEffect, O� $! 	#FF16140B��]� $��28����.  $	��342��$
* 53.5��$+ 12��.+��� -   - ��Name$- lbl_edu��$��	Condensed&�$
��Bold"�$��4,2,3,0q�$��71��$��23.221��$��Обучение��#���   $��Tahoma)�$q) kВ данном разделе вы найдёте необходимые учебные материалы��$��10.667(�$
��Left=�$��
0,0.01,0,0q�$	��Top=�, O� . O� GlowSize$. 8Q�$	" 0.7Q�$! White���� -   $- lbl_control��$��	Condensed&�$
��Bold"�$��4,2,3,0q�$��70��$��23.221��$��Контроль��#���   $��Tahoma)�$��10.667(�$w) qВ данном разделе вы сможете протестировать полученные знания��$
��Left=�$	��Top=�, O� $. 8Q�$	" 0.7Q�$! White���� -	   $- lbl_inst��$��10.667(�$��	Condensed&�$
��Bold"�$��4,2,3,0q�$��	Инст.��$��52��$
��Left=�#���   $��23.221��$��Tahoma)�$_) YРаздел содержит информацию об учебном заведении��/ J� RenderTransformOrigin$/ 0.423,0.474&�$��
0,0.01,0,0q�$	��Top=�, O� $. 8Q�$	" 0.7Q�$! White���� -
   $- 	lbl_other��$��1,1,1,1q�$��10.667(�$��	Condensed&�$
��Bold"�$��4,2,3,0q�$	��105��$��23.221��$ ��Дополнительно��$
��Left=�#���   $��Tahoma)�$	��Top=���Z� , O� $. 8Q�$	" 0.7Q�$! White��   UIControls.SearchTextBox  -   0  Name$0 txt_search_box��1 �� TextWrapping$
1 Wrap=�$��Right=�$��0,14.261,8,0q�$	��Top=�$��209.96��$��2q�$5) /Наберите текст для поиска�����	#FF848484$��23.96���� $
��Left=�$��73,74.211,0,0q�$	��545��$��images\grad_back.jpg��$
��Fill=�$y�Hidden=�$��2���� -   $( image1��$
��Left=�$	��618��$��images\white_bg.jpg��$
��Fill=�$y�Hidden=�$��35.197��$��Bottom=�$��1��(  "System.Windows.Controls.WebBrowser  -   2  Name$2 web_browser��3 J� IsHitTestVisible3 . $��0,52.5,0,25q�$��2���� -   $( 
img_splash��$��	8,49,8,25q�$y�Hidden=�$/ 0.5,0.5&�$��2��z�V� .~��� 4 �� ScaleX$4 1Q�5 �� ScaleY$5 1Q��� 6 �� AngleX$6 0Q�7 �� AngleY$7 0Q��� 8 �� Angle$8 0Q�T� 9 T� X$9 0Q�: T� Y$: 0Q�� -   $# 	gb_search��$��	0,54,0,25q�$y�Hidden=�$��2��.+��� -   ; ��Name$	; lst��$��8,9,29,8q����� .R��� $��3q�.+�]� .+��� $
��Bold"�$�� ��$
��Left=�$��0,0,10,0q��� $�� ���� 
��� � �$
��Bold"����� *
Found_Name+]� .+��� $
��Bold"�$�� ��
��� ���$
��Left=�$��5,0,5,0q��� ���� *
Found_type+�� $��, ���� ���� *
Found_path+.@��� �� -   < ��Name$< btn_close_search��$��Right=�$	��Top=�$��19��$��19.789��$��X��$
��Bold"�$��0,0,0,0q�$) Закрыть поиск�����	#FF979797���	#FF000000$��0,0,0,0q�$y�Visible=�$��0,9,6,0q����� $	 0,1&�$	 0,0&�.��� $ 	#FFF3F3F3��$ 0Q�� $ 	#FFEBEBEB��$	 0.5Q�� $ 	#FFDDDDDD��$	 0.5Q�� $ 	#FF686464��$ 1Q��� -   $' 	gb_footer��$��0,0,0,0.221q�$��Bottom=�$��24.779��$��1��.+��� -   $( 	img_about��$��17��$��images\umk_shell.png��$
��Fill=�$��15.779��$* 4��$+ 4��$) О программе��, F� = F� 	Direction$	= 256Q�> F� ShadowDepth$> 0Q�? F� Opacity$? 0.285Q��� -   $- 
lbl_status��$��5,0,5,0q�$	��576��$��16.779��$��Label��$* 28��$+ 3��$��Calibri)�$��13.333(��� $��Right=�$��0,0,1,2q�@ � IsSharedSizeScope@ . $��19��$��Right=�$��Bottom=�$��17��$��1��� -   A �Name$A pop_up1��$
��Left=�$	��Top=�B � AllowsTransparencyB . $��Slide=�$��41,10.912,0,0q�$
��85.4��$��1��$	��112��.��� $��80��$��0,2.7q�.+��� $��1,1,1,1q�C �� CornerRadius$C 0,0,0,0�����	#FF000000
�������$��1,0,0,0q��� -   $- 
lbl_author��$��1,1,1,1q�$��10.667(�$��	Condensed&�$
��Bold"�$��4,2,3,0q�$��О программе��#���   $��0,5,-75.353,0q�$	��Top=�$��23.221��$��Tahoma)���Z� �� -   $- lbl_help��$��1,1,1,1q�$��10.667(�$��	Condensed&�$
��Bold"�$��4,2,3,0q�$��Помощь��#���   $��0,30.221,-75.353,0q�$	��Top=�$��23.221��$��Tahoma)���Z� �� -   $- lbl_feedback��$��1,1,1,1q�$��10.667(�$
��Bold"�$��2,2,3,0q�$#��Отправить отзыв��#���   $��0,53.442,-75.353,0q�$	��Top=�$��23.221��$��Tahoma)�$��	Condensed&���Z� 