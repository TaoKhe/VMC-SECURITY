using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.MessageBox;
using ProgressBar = System.Windows.Controls.ProgressBar;

namespace VMCSecurity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private bool isEnableCdWrite;
        private bool isEnableCdRead;
        private bool isEnableCdExcute;
        private bool isEnableRemovalbeDevice;
        private bool isEnableFloppyDevice;
        private bool isEnableMtpDevice;
        private bool isEnablePrinterDevice;
        private bool isEnableTapeDevice;
        private bool isEnableWebcamDevice;
        private bool isEnableBluetoothDevice;
        private bool isEnableLanDevice;
        private bool isEnableWifiDevice;
        public MainWindow()
        {
            InitializeComponent();
            groupBoxCD.Visibility = Visibility.Visible;
            groupBoxStorageDevices.Visibility = Visibility.Collapsed;
            groupBoxExternalDevices.Visibility = Visibility.Collapsed;
            groupBoxNetwork.Visibility = Visibility.Collapsed;

            btn1.Background = Brushes.Red;
            btn1.BorderBrush = Brushes.Red;
            btn2.Background = Brushes.Gray;
            btn2.BorderBrush = Brushes.Gray;
            btn3.Background = Brushes.Gray;
            btn3.BorderBrush = Brushes.Gray;
            btn4.Background = Brushes.Gray;
            btn4.BorderBrush = Brushes.Gray;

            btn2.Foreground = Brushes.White;
            btn1.Foreground = Brushes.White;
            btn3.Foreground = Brushes.White;
            btn4.Foreground = Brushes.White;
            
            //set size
            ThisMainWindow.Height = 485;

            //load info
            ReadCDRom();
            ReadStorageDevices();
            ReadExternalDevices();
            ReadNetwork();
            SetPrimaryColor(Colors.Red);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;            
        }
        private void SetPrimaryColor(Color color)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();
            theme.SetPrimaryColor(color);
            paletteHelper.SetTheme(theme);
        }
        private void ReadCDRom()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f56308-b6bf-11d0-94f2-00a0c91efb8b}", true))
                {
                    if (key != null)
                    {
                        var obj = key.GetValue("Deny_Read");
                        if (obj == null)
                        {
                            setButton(iconCdReadAllow, textCdReadAllow, iconCdReadBlock, textCdReadBlock, ref isEnableCdRead, true);
    }
                        else
                        {
                            string sStart = obj.ToString();
                            if (sStart == "1")
                            {
                                setButton(iconCdReadAllow, textCdReadAllow, iconCdReadBlock, textCdReadBlock, ref isEnableCdRead, false);
                            }
                            else if (sStart == "0")
                            {
                                setButton(iconCdReadAllow, textCdReadAllow, iconCdReadBlock, textCdReadBlock, ref isEnableCdRead, true);
                            }
                            else
                            {
                                MessageBox.Show("Error detect value CD-Rom", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }

            //Deny_Write
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f56308-b6bf-11d0-94f2-00a0c91efb8b}", true))
                {
                    if (key != null)
                    {
                        var obj = key.GetValue("Deny_Write");
                        if (obj == null)
                        {
                            setButton(iconCdWriteAllow, textCdWriteAllow, iconCdWriteBlock, textCdWriteBlock, ref isEnableCdWrite, true);
                        }
                        else
                        {
                            string sStart = obj.ToString();
                            if (sStart == "1")
                            {
                                setButton(iconCdWriteAllow, textCdWriteAllow, iconCdWriteBlock, textCdWriteBlock, ref isEnableCdWrite, false);
                            }
                            else if (sStart == "0")
                            {
                                setButton(iconCdWriteAllow, textCdWriteAllow, iconCdWriteBlock, textCdWriteBlock, ref isEnableCdWrite, true);
                            }
                            else
                            {
                                MessageBox.Show("Error detect value CD-Rom", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }

            //Deny_Execute
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f56308-b6bf-11d0-94f2-00a0c91efb8b}", true))
                {
                    if (key != null)
                    {
                        var obj = key.GetValue("Deny_Execute");
                        if (obj == null)
                        {
                            setButton(iconCdExcuteAllow, textCdExcuteAllow, iconCdExcuteBlock, textCdExcuteBlock, ref isEnableCdExcute, true);
                        }
                        else
                        {
                            string sStart = obj.ToString();
                            if (sStart == "1")
                            {
                                setButton(iconCdExcuteAllow, textCdExcuteAllow, iconCdExcuteBlock, textCdExcuteBlock, ref isEnableCdExcute, false);
                            }
                            else if (sStart == "0")
                            {
                                setButton(iconCdExcuteAllow, textCdExcuteAllow, iconCdExcuteBlock, textCdExcuteBlock, ref isEnableCdExcute, true);
                            }
                            else
                            {
                                MessageBox.Show("Error detect value CD-Rom", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }

        }
        private void ReadStorageDevices()
        {
            //read removable devices
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f5630d-b6bf-11d0-94f2-00a0c91efb8b}", true))
                {
                    if (key != null)
                    {
                        var obj = key.GetValue("Deny_Read");
                        if (obj == null)
                        {
                            setButton(iconRemovableAllow, textRemovableAllow, iconRemovableBlock, textRemovableBlock, ref isEnableRemovalbeDevice, true);
                        }
                        else
                        {
                            string sStart = obj.ToString();
                            if (sStart == "1")
                            {
                                setButton(iconRemovableAllow, textRemovableAllow, iconRemovableBlock, textRemovableBlock, ref isEnableRemovalbeDevice, false);
                            }
                            else if (sStart == "0")
                            {
                                setButton(iconRemovableAllow, textRemovableAllow, iconRemovableBlock, textRemovableBlock, ref isEnableRemovalbeDevice, true);
                            }
                            else
                            {
                                MessageBox.Show("Error detect value all device", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }

            //read floppy disks
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f56311-b6bf-11d0-94f2-00a0c91efb8b}", true))
                {
                    if (key != null)
                    {
                        var obj = key.GetValue("Deny_Read");
                        if (obj == null)
                        {
                            setButton(iconFloppyAllow, textFloppyAllow, iconFloppyBlock, textFloppyBlock, ref isEnableFloppyDevice, true);
                        }
                        else
                        {
                            string sStart = obj.ToString();
                            if (sStart == "1")
                            {
                                setButton(iconFloppyAllow, textFloppyAllow, iconFloppyBlock, textFloppyBlock, ref isEnableFloppyDevice, false);
                            }
                            else if (sStart == "0")
                            {
                                setButton(iconFloppyAllow, textFloppyAllow, iconFloppyBlock, textFloppyBlock, ref isEnableFloppyDevice, true);
                            }
                            else
                            {
                                MessageBox.Show("Error detect value all device", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }

            //read MTP devices
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{6AC27878-A6FA-4155-BA85-F98F491D4F33}", true))
                {
                    if (key != null)
                    {
                        var obj = key.GetValue("Deny_Read");
                        if (obj == null)
                        {
                            setButton(iconMtpAllow, textMtpAllow, iconMtpBlock, textMtpBlock, ref isEnableMtpDevice, true);
                        }
                        else
                        {
                            string sStart = obj.ToString();
                            if (sStart == "1")
                            {
                                setButton(iconMtpAllow, textMtpAllow, iconMtpBlock, textMtpBlock, ref isEnableMtpDevice, false);
                            }
                            else if (sStart == "0")
                            {
                                setButton(iconMtpAllow, textMtpAllow, iconMtpBlock, textMtpBlock, ref isEnableMtpDevice, true);
                            }
                            else
                            {
                                MessageBox.Show("Error detect value all device", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }

        }
        private void ReadExternalDevices()
        {
            ReadPrintServices();
            ReadTapeDevices();
            ReadCamera();
            ReadBluetooth();
        }
        private void ReadNetwork()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.Name.Contains("Ethernet"))//is Ethernet Adapter
                {
                    setButton(iconLanAllow, textLanAllow, iconLanBlock, textLanBlock, ref isEnableLanDevice, true);
                    break;
                }
                else
                {
                    setButton(iconLanAllow, textLanAllow, iconLanBlock, textLanBlock, ref isEnableLanDevice, false);
                }
            }
            ReadWifiServices();
        }
       
        //read wifi
        private void ReadWifiServices()
        {
            //read printer services
            try
            {
                //printer enable
                ServiceController controller = new ServiceController("WlanSvc");
                ServiceControllerStatus status = controller.Status;
                ServiceStartMode startType = controller.StartType;
                if (status == ServiceControllerStatus.Running)
                {
                    setButton(iconWifiAllow, textWifiAllow, iconWifiBlock, textWifiBlock, ref isEnableWifiDevice, true);
                }
                else
                {
                    setButton(iconWifiAllow, textWifiAllow, iconWifiBlock, textWifiBlock, ref isEnableWifiDevice, false);
                }
            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }
        }
        private void ReadPrintServices()
        {
            //read printer services
            try
            {
                //printer enable
                ServiceController controller = new ServiceController("Spooler");
                ServiceControllerStatus status = controller.Status;
                ServiceStartMode startType = controller.StartType;

                if (status == ServiceControllerStatus.Running)
                {
                    setButton(iconPrinterAllow, textPrinterAllow, iconPrinterBlock, textPrinterBlock, ref isEnablePrinterDevice, true);
                }
                else
                {
                    setButton(iconPrinterAllow, textPrinterAllow, iconPrinterBlock, textPrinterBlock, ref isEnablePrinterDevice, false);
                }

            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }
        }
        private void ReadTapeDevices()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f5630b-b6bf-11d0-94f2-00a0c91efb8b}", true))
                {
                    if (key != null)
                    {
                        var obj = key.GetValue("Deny_Read");
                        if (obj == null)
                        {
                            setButton(iconTapeAllow, textTapeAllow, iconTapeBlock, textTapeBlock, ref isEnableTapeDevice, true);
                        }
                        else
                        {
                            string sStart = obj.ToString();
                            if (sStart == "1")
                            {
                                setButton(iconTapeAllow, textTapeAllow, iconTapeBlock, textTapeBlock, ref isEnableTapeDevice, false);
                            }
                            else if (sStart == "0")
                            {
                                setButton(iconTapeAllow, textTapeAllow, iconTapeBlock, textTapeBlock, ref isEnableTapeDevice, true);
                            }
                            else
                            {
                                MessageBox.Show("Error detect value tape devices", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }
        }

        /************************************************************************************************************/
        private void ReadCamera()
        {
            // Đọc trạng thái sử dụng camera của người dùng local
            int cameraAccessValue = GetCameraAccessValue();
            if (cameraAccessValue == 1)
                setButton(iconWebcamAllow, textWebcamAllow, iconWebcamBlock, textWebcamBlock, ref isEnableWebcamDevice, true);
            else if (cameraAccessValue == 2)
                setButton(iconWebcamAllow, textWebcamAllow, iconWebcamBlock, textWebcamBlock, ref isEnableWebcamDevice, false);
            else
                MessageBox.Show("Không thể đọc trạng thái Camera Access.");
        }
        static int GetCameraAccessValue()
        {
            // Đọc giá trị từ registry để xác định trạng thái sử dụng camera của người dùng local
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\AppPrivacy", false))
            {
                if (key != null)
                {
                    return (int)key.GetValue("LetAppsAccessCamera", 0); // Trạng thái mặc định là 0
                }
            }
            return 0; // Trả về 0 nếu không tìm thấy giá trị
        }

        /************************************************************************************************************/

        private void ReadBluetooth()
        {
            try
            {
                int registryValue = GetBluetoothRegistryValue();
                string configurationStatus = GetConfigurationStatusString2(registryValue);
                if (configurationStatus == "Allow")
                {
                    setButton(iconBluetoothAllow, textBluetoothAllow, iconBluetoothBlock, textBluetoothBlock, ref isEnableBluetoothDevice, true); // Bluetooth connection allowed
                }
                else if (configurationStatus == "Block")
                {
                    setButton(iconBluetoothAllow, textBluetoothAllow, iconBluetoothBlock, textBluetoothBlock, ref isEnableBluetoothDevice, false); // Bluetooth connection blocked
                }
                else
                {
                    MessageBox.Show("Unknown Bluetooth connection status", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading Bluetooth status: {ex.Message}");
            }
        }

        private string GetConfigurationStatusString2(int value)
        {
            switch (value)
            {
                case 0:
                    return "Block";
                case 2:
                    return "Allow";
                default:
                    return "Unknown";
            }
        }
        /**************************************************************************************************/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //CD
            if (isEnableCdWrite)
            {
                EnableCDRomWrite(true);
            }
            else
            {
                EnableCDRomWrite(false);
            }
            if (isEnableCdRead)
            {
                EnableCDRomRead(true);
            }
            else
            {
                EnableCDRomRead(false);
            }
            if (isEnableCdExcute)
            {
                EnableCDRomExcute(true);
            }
            else
            {
                EnableCDRomExcute(false);
            }
            if (isEnableRemovalbeDevice)
            {
                EnableRemovableDevices(true);
            }
            else
            {
                EnableRemovableDevices(false);
            }

            if (isEnableFloppyDevice)
            {
                EnableFloppyDrives(true);
            }
            else
            {
                EnableFloppyDrives(false);
            }

            if (isEnableMtpDevice)
            {
                EnableWPDDevices(true);
            }
            else
            {
                EnableWPDDevices(false);
            }
            if (isEnablePrinterDevice)
            {
                EnablePrinterServices();
            }
            else
            {
                DisablePrinterServices();
            }

            if (isEnableTapeDevice)
            {
                EnableTapeDrives(true);
            }
            else
            {
                EnableTapeDrives(false);
            }

            if (isEnableWebcamDevice)
            {
                // Cho phép người dùng local sử dụng camera
                SetCameraAccessValue(1);
            }
            else
            {
                // Chặn người dùng local sử dụng camera
                SetCameraAccessValue(2);
            }

            if (isEnableBluetoothDevice)
            {
                // Bật Bluetooth
                EnableBluetooth(true);
            }
            else
            {
                // Tắt Bluetooth
                EnableBluetooth(false);
            }
            if (isEnableLanDevice)
            {
                EnalbeAccessLAN(true);
            }
            else
            {
                EnalbeAccessLAN(false);
            }

            if (isEnableWifiDevice)
            {
                EnableWifiService();
            }
            else
            {
                DisableWifiServices();
            }
            //run update & display progress bar 
            UpdateGroupPolicy2();
            return;
        }

        private void EnalbeAccessLAN(bool isEnable = true)
        {
            string interfaceName = "Ethernet";
            string control;
            if (isEnable)
            {
                control = "enable";
            }
            else
            {
                control = "disable";
            }
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" " + control);
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
        }
        private void EnablePrinterServices()
        {
            //printer enable
            //set startType
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "CMD.EXE",
                Arguments = string.Format("/C sc {0} {1} {2}", "config", "Spooler", "start=auto"),
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                if (!process.Start())
                {
                    return;
                }
                process.WaitForExit();
            }

            //start
            ServiceController controller = new ServiceController("Spooler");
            if (controller.Status != ServiceControllerStatus.Running)
            {
                controller.Start();
            }
        }
        private void DisablePrinterServices()
        {
            //printer disable
            //stop service
            ServiceController controller = new ServiceController("Spooler");
            if (controller.Status == ServiceControllerStatus.Running)
            {
                controller.Stop();
            }

            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "CMD.EXE",
                Arguments = string.Format("/C sc {0} {1} {2}", "config", "Spooler", "start=disabled"),
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                if (!process.Start())
                {
                    return;
                }
                process.WaitForExit();
            }
        }
        private void EnableWifiService()
        {
            // Set start type to automatic
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "CMD.EXE",
                Arguments = string.Format("/C sc {0} {1} {2}", "config", "WlanSvc", "start=auto"),
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                if (!process.Start())
                {
                    return;
                }
                process.WaitForExit();
            }
            // Start the service if it's not already running
            ServiceController controller = new ServiceController("WlanSvc");
            if (controller.Status != ServiceControllerStatus.Running)
            {
                controller.Start();
            }
        }
        private void DisableWifiServices()
        {
            //stop service
            ServiceController controller = new ServiceController("WlanSvc");
            if (controller.Status == ServiceControllerStatus.Running)
            {
                controller.Stop();
                controller.WaitForStatus(ServiceControllerStatus.Stopped);
            }

            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "CMD.EXE",
                Arguments = string.Format("/C sc {0} {1} {2}", "config", "WlanSvc", "start=disabled"),
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                if (!process.Start())
                {
                    return;
                }
                process.WaitForExit();
            }
        }
        /****************************************************************************/
        private void EnableBluetooth(bool value)
        {
            if (value) // Allow
            {
                try
                {
                    SetBluetoothRegistryValue(2); // Set giá trị là 2 để cho phép Bluetooth
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error enabling Bluetooth USB devices: {ex.Message}");
                }
            }
            else // Block
            {
                try
                {
                    SetBluetoothRegistryValue(0); // Set giá trị là 0 để chặn Bluetooth
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error disabling Bluetooth USB devices: {ex.Message}");
                }
            }
        }

        private int GetBluetoothRegistryValue()
        {
            try
            {
                object registryValue = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PolicyManager\default\Connectivity\AllowBluetooth", "value", null);

                if (registryValue != null && registryValue is int value)
                {
                    return value;
                }

                return -1; // Giá trị mặc định nếu không thể đọc được hoặc không tồn tại
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting Bluetooth registry value: {ex.Message}");
            }
        }

        private void SetBluetoothRegistryValue(int value)
        {
            try
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PolicyManager\default\Connectivity\AllowBluetooth", "value", value, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error setting Bluetooth registry value: {ex.Message}");
            }
        }

        /**************************************************************************/
        static void SetCameraAccessValue(int value)
        {
            // Thiết lập giá trị trong registry để chặn hoặc cho phép sử dụng camera của người dùng local
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows\AppPrivacy", RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue("LetAppsAccessCamera", value, RegistryValueKind.DWord);
            }
        }

        /***********************************************************************/
        private void EnableTapeDrives(bool value)
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f5630b-b6bf-11d0-94f2-00a0c91efb8b}", true);
            if (value)
            {
                key.SetValue("Deny_Read", 0, RegistryValueKind.DWord);
                key.SetValue("Deny_Write", 0, RegistryValueKind.DWord);
                key.SetValue("Deny_Execute", 0, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("Deny_Read", 1, RegistryValueKind.DWord);
                key.SetValue("Deny_Write", 1, RegistryValueKind.DWord);
                key.SetValue("Deny_Execute", 1, RegistryValueKind.DWord);
            }
            key.Close();
        }
        private void EnableRemovableDevices(bool value)
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f5630d-b6bf-11d0-94f2-00a0c91efb8b}", true);
            if (value)
            {
                key.SetValue("Deny_Read", 0, RegistryValueKind.DWord);
                key.SetValue("Deny_Write", 0, RegistryValueKind.DWord);
                key.SetValue("Deny_Execute", 0, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("Deny_Read", 1, RegistryValueKind.DWord);
                key.SetValue("Deny_Write", 1, RegistryValueKind.DWord);
                key.SetValue("Deny_Execute", 1, RegistryValueKind.DWord);
            }
            key.Close();
        }
        private void EnableFloppyDrives(bool value)
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f56311-b6bf-11d0-94f2-00a0c91efb8b}", true);
            if (value)
            {
                key.SetValue("Deny_Read", 0, RegistryValueKind.DWord);
                key.SetValue("Deny_Write", 0, RegistryValueKind.DWord);
                key.SetValue("Deny_Execute", 0, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("Deny_Read", 1, RegistryValueKind.DWord);
                key.SetValue("Deny_Write", 1, RegistryValueKind.DWord);
                key.SetValue("Deny_Execute", 1, RegistryValueKind.DWord);
            }
            key.Close();
        }
        private void EnableWPDDevices(bool value)
        {
            RegistryKey key1 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{6AC27878-A6FA-4155-BA85-F98F491D4F33}", true);
            RegistryKey key2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{F33FDC04-D1AC-4E8E-9A30-19BBD4B108AE}", true);
            if (value)
            {
                key1.SetValue("Deny_Read", 0, RegistryValueKind.DWord);
                key1.SetValue("Deny_Write", 0, RegistryValueKind.DWord);
                key2.SetValue("Deny_Read", 0, RegistryValueKind.DWord);
                key2.SetValue("Deny_Write", 0, RegistryValueKind.DWord);
            }
            else
            {
                key1.SetValue("Deny_Read", 1, RegistryValueKind.DWord);
                key1.SetValue("Deny_Write", 1, RegistryValueKind.DWord);
                key2.SetValue("Deny_Read", 1, RegistryValueKind.DWord);
                key2.SetValue("Deny_Write", 1, RegistryValueKind.DWord);
            }
            key1.Close();
            key2.Close();
        }
        private void EnableCDRomRead(bool value)
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f56308-b6bf-11d0-94f2-00a0c91efb8b}", true);
            if (value)
            {
                key.SetValue("Deny_Read", 0, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("Deny_Read", 1, RegistryValueKind.DWord);
            }
            key.Close();
        }
        private void EnableCDRomWrite(bool value)
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f56308-b6bf-11d0-94f2-00a0c91efb8b}", true);
            if (value)
            {
                key.SetValue("Deny_Write", 0, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("Deny_Write", 1, RegistryValueKind.DWord);
            }
            key.Close();
        }
        private void EnableCDRomExcute(bool value)
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices\\{53f56308-b6bf-11d0-94f2-00a0c91efb8b}", true);
            if (value)
            {
                key.SetValue("Deny_Execute", 0, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("Deny_Execute", 1, RegistryValueKind.DWord);
            }
            key.Close();
        }

        //progress bar
        private async void UpdateGroupPolicy2()
        {
            BtnSave.IsEnabled = false;
            BtnCancel.IsEnabled = false;
            var progressBar = new ProgressBar
            {
                IsIndeterminate = true,
                Minimum = 0,
                Maximum = 100,
                Width = 200,
                Height = 20,
                Margin = new Thickness(10)
            };
            var progressText = new TextBlock
            {
                Text = "Đang xử lý ...",
                FontSize = 16,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            };
            var stackPanel = new StackPanel
            {
                Children = { progressBar, progressText },
                Margin = new Thickness(10)
            };
            var window = new System.Windows.Window
            {
                Title = "Updating Group Policy",
                Content = stackPanel,
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStyle = WindowStyle.None,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            window.Show();

            await Task.Run(() =>
            {
                // Tạo ProcessStartInfo
                ProcessStartInfo psi = new ProcessStartInfo("gpupdate.exe");
                psi.Arguments = "/force";
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.UseShellExecute = false; // Tắt sử dụng shell execute để tránh lỗ hổng Command Injection
                psi.RedirectStandardOutput = true; // Chỉ định để nhận kết quả từ lệnh
                psi.CreateNoWindow = true; // Tắt việc tạo cửa sổ cho tiến trình

                // Tạo Process và thực thi lệnh
                Process process = new Process();
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();
            });


            // Display a success message
            BtnSave.IsEnabled = true;
            BtnCancel.IsEnabled = true;
            window.Close();
            MessageBoxResult result = MessageBox.Show("Cấu hình thành công! Bạn cần reset máy tính để thiết lập. Bạn có muốn reset ngay?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            
            // Nếu người dùng chọn Yes, thực hiện reset máy tính
            if (result == MessageBoxResult.Yes)
            {
                ResetComputer();
            }
        }

        private void ResetComputer()
        {
            // Gọi lệnh hệ thống shutdown để reset máy tính
            System.Diagnostics.Process.Start("shutdown", "/r /t 0");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            groupBoxCD.Visibility = Visibility.Visible;
            groupBoxStorageDevices.Visibility = Visibility.Collapsed;
            groupBoxExternalDevices.Visibility = Visibility.Collapsed;
            groupBoxNetwork.Visibility = Visibility.Collapsed;
            btn1.Background = Brushes.Red;
            btn1.BorderBrush = Brushes.Red;
            btn2.Background = Brushes.Gray;
            btn2.BorderBrush = Brushes.Gray;
            btn3.Background = Brushes.Gray;
            btn3.BorderBrush = Brushes.Gray;
            btn4.Background = Brushes.Gray;
            btn4.BorderBrush = Brushes.Gray;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            groupBoxCD.Visibility = Visibility.Collapsed;
            groupBoxStorageDevices.Visibility = Visibility.Visible;
            groupBoxExternalDevices.Visibility = Visibility.Collapsed;
            groupBoxNetwork.Visibility = Visibility.Collapsed;
            btn2.Background = Brushes.Red;
            btn2.BorderBrush = Brushes.Red;
            btn1.Background = Brushes.Gray;
            btn1.BorderBrush = Brushes.Gray;
            btn3.Background = Brushes.Gray;
            btn3.BorderBrush = Brushes.Gray;
            btn4.Background = Brushes.Gray;
            btn4.BorderBrush = Brushes.Gray;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            groupBoxCD.Visibility = Visibility.Collapsed;
            groupBoxStorageDevices.Visibility = Visibility.Collapsed;
            groupBoxExternalDevices.Visibility = Visibility.Visible;
            groupBoxNetwork.Visibility = Visibility.Collapsed;
            btn3.Background = Brushes.Red;
            btn3.BorderBrush = Brushes.Red;
            btn2.Background = Brushes.Gray;
            btn2.BorderBrush = Brushes.Gray;
            btn1.Background = Brushes.Gray;
            btn1.BorderBrush = Brushes.Gray;
            btn4.Background = Brushes.Gray;
            btn4.BorderBrush = Brushes.Gray;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            groupBoxCD.Visibility = Visibility.Collapsed;
            groupBoxStorageDevices.Visibility = Visibility.Collapsed;
            groupBoxExternalDevices.Visibility = Visibility.Collapsed;
            groupBoxNetwork.Visibility = Visibility.Visible;
            btn4.Background = Brushes.Red;
            btn4.BorderBrush = Brushes.Red;
            btn2.Background = Brushes.Gray;
            btn2.BorderBrush = Brushes.Gray;
            btn3.Background = Brushes.Gray;
            btn3.BorderBrush = Brushes.Gray;
            btn1.Background = Brushes.Gray;
            btn1.BorderBrush = Brushes.Gray;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            //reload info
            ReadCDRom();
            ReadStorageDevices();
            ReadExternalDevices();
            ReadNetwork();
        }
        private void BtnCdWriteAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconCdWriteAllow, textCdWriteAllow, iconCdWriteBlock, textCdWriteBlock, ref isEnableCdWrite, true);
        }
        private void BtnCdWriteBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconCdWriteAllow, textCdWriteAllow, iconCdWriteBlock, textCdWriteBlock, ref isEnableCdWrite, false);
        }
        private void BtnCdReadAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconCdReadAllow, textCdReadAllow, iconCdReadBlock, textCdReadBlock, ref isEnableCdRead, true);
        }
        private void BtnCdReadBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconCdReadAllow, textCdReadAllow, iconCdReadBlock, textCdReadBlock, ref isEnableCdRead, false);
        }
        private void BtnCdExcuteAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconCdExcuteAllow, textCdExcuteAllow, iconCdExcuteBlock, textCdExcuteBlock, ref isEnableCdExcute, true);
        }
        private void BtnCdExcuteBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconCdExcuteAllow, textCdExcuteAllow, iconCdExcuteBlock, textCdExcuteBlock, ref isEnableCdExcute, false);
        }
        private void setButton(PackIcon packIcon1, Label label1, PackIcon packIcon2, Label label2, ref bool nameValue, bool value)
        {
            if (true == value)
            {
                packIcon1.Kind = PackIconKind.CheckboxOutline;
                packIcon1.Foreground = Brushes.Green;
                label1.FontWeight = FontWeights.Bold;

                packIcon2.Kind = PackIconKind.CheckboxBlankOutline;
                packIcon2.Foreground = Brushes.Wheat;
                label2.FontWeight = FontWeights.Normal;
            }
            else
            {
                packIcon1.Kind = PackIconKind.CheckboxBlankOutline;
                packIcon1.Foreground = Brushes.Wheat;
                label1.FontWeight = FontWeights.Normal;

                packIcon2.Kind = PackIconKind.AlphabetXBoxOutline;
                packIcon2.Foreground = Brushes.Red;
                label2.FontWeight = FontWeights.Bold;
            }
            //set value to bool
            nameValue = value;
        }
        private void BtnRemovableAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconRemovableAllow, textRemovableAllow, iconRemovableBlock, textRemovableBlock, ref isEnableRemovalbeDevice, true);
        }
        private void BtnRemovableBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconRemovableAllow, textRemovableAllow, iconRemovableBlock, textRemovableBlock, ref isEnableRemovalbeDevice, false);
        }
        private void BtnFloppyAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconFloppyAllow, textFloppyAllow, iconFloppyBlock, textFloppyBlock, ref isEnableFloppyDevice, true);
        }
        private void BtnFloppyBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconFloppyAllow, textFloppyAllow, iconFloppyBlock, textFloppyBlock, ref isEnableFloppyDevice, false);
        }
        private void BtnMtpAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconMtpAllow, textMtpAllow, iconMtpBlock, textMtpBlock, ref isEnableMtpDevice, true);
        }
        private void BtnMtpBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconMtpAllow, textMtpAllow, iconMtpBlock, textMtpBlock, ref isEnableMtpDevice, false);
        }
        private void BtnPrinterAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconPrinterAllow, textPrinterAllow, iconPrinterBlock, textPrinterBlock, ref isEnablePrinterDevice, true);
        }
        private void BtnPrinterBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconPrinterAllow, textPrinterAllow, iconPrinterBlock, textPrinterBlock, ref isEnablePrinterDevice, false);
        }
        private void BtnTapeAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconTapeAllow, textTapeAllow, iconTapeBlock, textTapeBlock, ref isEnableTapeDevice, true);
        }
        private void BtnTapeBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconTapeAllow, textTapeAllow, iconTapeBlock, textTapeBlock, ref isEnableTapeDevice, false);
        }
        private void BtnWebcamAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconWebcamAllow, textWebcamAllow, iconWebcamBlock, textWebcamBlock, ref isEnableWebcamDevice, true);
        }
        private void BtnWebcamBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconWebcamAllow, textWebcamAllow, iconWebcamBlock, textWebcamBlock, ref isEnableWebcamDevice, false);
        }
        private void BtnBluetoothAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconBluetoothAllow, textBluetoothAllow, iconBluetoothBlock, textBluetoothBlock, ref isEnableBluetoothDevice, true);
        }
        private void BtnBluetoothBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconBluetoothAllow, textBluetoothAllow, iconBluetoothBlock, textBluetoothBlock, ref isEnableBluetoothDevice, false);
        }
        private void BtnLanAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconLanAllow, textLanAllow, iconLanBlock, textLanBlock, ref isEnableLanDevice, true);
        }
        private void BtnLanBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconLanAllow, textLanAllow, iconLanBlock, textLanBlock, ref isEnableLanDevice, false);
        }
        private void BtnWifiAllow_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconWifiAllow, textWifiAllow, iconWifiBlock, textWifiBlock, ref isEnableWifiDevice, true);
        }
        private void BtnWifiBlock_Click(object sender, RoutedEventArgs e)
        {
            setButton(iconWifiAllow, textWifiAllow, iconWifiBlock, textWifiBlock, ref isEnableWifiDevice, false);
        }
    }
}
