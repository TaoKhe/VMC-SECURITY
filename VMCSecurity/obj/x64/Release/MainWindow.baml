   M S B A M L   `   `   `  ���� F  BVMCSecurity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:VMCSecurityVMCSecurity      VMCSecurity.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:VMCSecurity     _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     �Name$  ThisMainWindow��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � Title$2 ,Phần mềm bảo mật chống truy cập ��$
��1683��$	��730�� � 
ResizeMode$ NoResize=�.��� $	��715�� � RowDefinitions �� $	��29* ��� $��1638* �.+���  �� Orientation$ 
Horizontal=�$	��715��$��2��.+��� $ Vertical=�$
��1500��$	��Top=�.+��� -   $
��btn1��$��Ổ đĩa CD/DVD��$	��150��$��40��$��5,2,5,2q�$��16(��� -   $
��btn2��$��Thiết bị lưu trữ��$	��150��$��40��$��5,2,5,2q�$��16(��� -   $
��btn3��$��Thiết bị mở rộng��$	��150��$��40��$��5,2,5,2q�$��16(��� -   $
��btn4��$��Cài đặt mạng��$	��150��$��40��$��5,2,5,2q�$��16(��� $	��Top=�.+��� -    ��Name$ 
groupBoxCD��$	��536��$	��370��$��16(�$
��Bold"�
����������� 
�������$��18(�$��Center=�$��20��$��0q�$��CD/DVD��.���� $	��Top=�.+��� $��40���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Ghi dữ liệu��$	��120��$��16(�$��Center=��� $��50���� -    ��Name$ BtnCdWriteAllow��  MaterialDesignFlatButton#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�$��Center=�.+��� $��5��'  !MaterialDesignThemes.Wpf.PackIcon  -   	  Name$	 iconCdWriteAllow��
   Kind$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -	    ��Name$ textCdWriteAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -
   $ BtnCdWriteBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -   $	 iconCdWriteBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -   $ textCdWriteBlock��$��Khóa��$��16(�$��77���� $��5���� $��10���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Đọc dữ liệu��$	��120��$��16(�$��Center=��� $��50���� -   $ BtnCdReadAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�$��Center=�.+��� $��5��  -   $	 iconCdReadAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -   $ textCdReadAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -   $ BtnCdReadBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -   $	 iconCdReadBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -   $ textCdReadBlock��$��Khóa��$��16(�$��77���� $��5���� $��10���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Quyền truy cập��$	��120��$��16(�$��Center=��� $��50���� -   $ BtnCdExcuteAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��{�. .���� $ 
Horizontal=�$��Center=�.+��� $��5��  -   $	 iconCdExcuteAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -   $ textCdExcuteAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -   $ BtnCdExcuteBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -   $	 iconCdExcuteBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -   $ textCdExcuteBlock��$��Khóa��$��16(�$��77���� $��5���� -   $ groupBoxStorageDevices��$	��536��$	��370��$��16(����� 
�������$��18(�$��Center=�$��20��$��0q�$
��Bold"�$.��(Các thiết bị lưu trữ dữ liệu��.���� $	��Top=�.+��� $��40���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Ổ cứng, USB��$	��120��$��16(�$��Center=��� $��50���� -   $ BtnRemoableAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�$��Center=�.+��� $��5��  -   $	 iconRemovableAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -   $ textRemovableAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -   $ BtnRemovableBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -   $	 iconRemovableBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -   $ textRemovableBlock��$��Khóa��$��16(�$��77���� $��5���� $��10���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Ổ đĩa mềm (FDD)��$	��140��$��16(�$��Center=��� $��30���� -    $ BtnFloppyAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�$��Center=�.+��� $��5��  -!   $	 iconFloppyAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -"   $ textFloppyAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -#   $ BtnFloppyBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -$   $	 iconFloppyBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -%   $ textFloppyBlock��$��Khóa��$��16(�$��77���� $��5���� $��10���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $"��Thiết bị cầm tay (MTP)��$	��170��$��16(�$��Center=��� $��0���� -&   $ BtnMtpAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��{�. .���� $ 
Horizontal=�$��Center=�.+��� $��5��  -'   $	 iconMtpAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -(   $ textMtpAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -)   $ BtnMtpBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -*   $	 iconMtpBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -+   $ textMtpBlock��$��Khóa��$��16(�$��77���� $��5���� -,   $ groupBoxExternalDevices��$	��536��$	��370��$��16(����� 
�������$��18(�$��Center=�$��20��$��0q�$
��Bold"�$#��Các thiết bị mở rộng��.���� $	��Top=�.+��� $��40���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Máy in��$	��120��$��16(�$��Center=��� $��50���� --   $ BtnPrinterAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�$��Center=�.+��� $��5��  -.   $	 iconPrinterAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -/   $ textPrinterAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -0   $ BtnPrinterBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -1   $	 iconPrinterBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -2   $ textPrinterBlock��$��Khóa��$��16(�$��77���� $��5���� $��10���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Ổ băng (Tape Drive)��$	��160��$��16(�$��Center=��� $��10���� -3   $ BtnTapeAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�$��Center=�.+��� $��5��  -4   $	 iconTapeAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -5   $ textTapeAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -6   $ BtnTapeBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -7   $	 iconTapeBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -8   $ textTapeBlock��$��Khóa��$��16(�$��77���� $��5���� $��10���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Webcam��$	��120��$��16(�$��Center=��� $��50���� -9   $ BtnWebcamAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��{�. .���� $ 
Horizontal=�$��Center=�.+��� $��5��  -:   $	 iconWebcamAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -;   $ textWebcamAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -<   $ BtnWebcamBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -=   $	 iconWebcamBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� ->   $ textWebcamBlock��$��Khóa��$��16(�$��77���� $��5���� $��10���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��	Bluetooth��$	��120��$��16(�$��Center=��� $��50���� -?   $ BtnBluetoothAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��{�. .���� $ 
Horizontal=�$��Center=�.+��� $��5��  -@   $	 iconBluetoothAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -A   $ textBluetoothAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -B   $ BtnBluetoothBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -C   $	 iconBluetoothBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -D   $ textBluetoothBlock��$��Khóa��$��16(�$��77���� $��5���� -E   $ groupBoxNetwork��$	��536��$	��370��$��16(����� 
�������$��18(�$��Center=�$��20��$��0q�$
��Bold"�$��Cài đặt mạng��.���� $	��Top=�.+��� $��40���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Truy cập LAN��$	��120��$��16(�$��Center=��� $��50���� -F   $ BtnLanAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��{�. .���� $ 
Horizontal=�$��Center=�.+��� $��5��  -G   $	 iconLanAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -H   $ textLanAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -I   $ BtnLanBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -J   $	 iconLanBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -K   $ textLanBlock��$��Khóa��$��16(�$��77���� $��5���� $��10���� $
��Left=�$��Center=�.���� $ 
Horizontal=�.+��� $��30���� $��Truy cập Wi-Fi��$	��120��$��16(�$��Center=��� $��50���� -L   $ BtnWifiAllow��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��{�. .���� $ 
Horizontal=�$��Center=�.+��� $��5��  -M   $	 iconWifiAllow��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -N   $ textWifiAllow��$��	Cho phép��$��16(�$��77���� $��5���� $��40���� -O   $ BtnWifiBlock��#��[ $��0q�$	��120�����	#DDFFFFFF$��35��.���� $ 
Horizontal=�.+��� $��5��  -P   $	 iconWifiBlock��$
 CheckboxBlankOutline=�
�������$��28��$��28���� $��5���� -Q   $ textWifiBlock��$��Khóa��$��16(�$��77���� $��5���� $��12���� $ 
Horizontal=�$��Center=�.+��� -R   $ BtnSave��#��[ $��0q�$	��150��
���  ��$��35�����	#FF1A45AF.���� $ 
Horizontal=�$��Center=�.+��� $��5��  -S   $	 iconSave��$
 ContentSaveAddOutline=�
�������$��28��$��28���� $��5���� -T   $ textSave��$��Lưu thay đổi��$��16(����	#DDFFFFFF�� $��5���� $��50���� -U   $ 	BtnCancel��#��[ $��0q�$	��150��
���  ��$��35��.���� $ 
Horizontal=�$��Center=�.+��� $��5��  -V   $	 
iconCancel��$
 CancelCircleOutline=�
�������$��28��$��28���� $��5���� -W   $ 
textCancel��$��Hủy thay đổi��$��16(����	#DDFFFFFF�� $��5���� $��5���� $R��LBản quyền thuộc về Tổng công ty sản xuất thiết bị Viettel��$	��562��
����������	#DDFF0000$��Italic$�$��14(�$��30���� $��5��%  MaterialDesignThemes.Wpf.Badged  $��Center=�