using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bruuuh;
using MemoryAim2;

namespace BR_PREMIUM_5._0.strings
{
    public class Snipers
    {
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;
        private ParticleSystem particleSystem;
        private string RED;

        public static MemRed RedLib = new MemRed();
        public static String PID;
        Evelyn bruuuh = new Evelyn();

        private HOME _mainForm;
        private List<long> SniperAddresses = new List<long>();
        private List<long> M82BAddress = new List<long>();
        private List<long> M24Address = new List<long>();
        private List<long> VSKAddress = new List<long>();
        private List<long> sniperTrackingAddress = new List<long>();

        public Snipers(HOME mainForm)
        {
            _mainForm = mainForm;

        }
        #region SSC
        public async Task ScanSniperScope()
        {
            string search = "06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                SniperAddresses = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableSniperScope()
        {
            string replace = "06 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00";

            if (SniperAddresses.Count > 0)
            {
                bool success = false;

                foreach (var address in SniperAddresses)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("Sniper Scope Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("SSC Error", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public void ResetSniperScope()
        {
            string originalPattern = "06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00";

            if (SniperAddresses.Count > 0)
            {
                bool success = false;

                foreach (var address in SniperAddresses)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("Sniper Scope Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                    ShowMessageBox("SSC Error 101", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {

                ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }

        public async void EnableSniperScope1()
        {
            string search = "8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01";
            string replace = "8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion
        #region SS
        public async void EnableSniperSwitch()
        {
            string search = "3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F ?? ?? ?? 3F ?? ?? ?? 3F 00 00 80 3F 00 00 00 00 ?? ?? ?? 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00";
            string replace = "3F 00 00 80 3E EC 51 B8 3D";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableSniperSwitch()
        {
            string search = "3F 00 00 80 3E EC 51 B8 3D";
            string replace = "3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F ?? ?? ?? 3F ?? ?? ?? 3F 00 00 80 3F 00 00 00 00 ?? ?? ?? 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion
        #region SDF
        public async void Enablesdelayfix()
        {
            string search = "EA 00 60 A0 E3 06 00 A0 E1 18 D0 4B E2 02 8B BD EC 70 8C";
            string replace = "01 00 AF E3";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void Disablesdelayfix()
        {
            string search = "01 00 AF E3";
            string replace = "EA 00 60 A0 E3 06 00 A0 E1 18 D0 4B E2 02 8B BD EC 70 8C";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion
        #region M82BS
        public async void EnableM82BSwitch()
        {
            string search = "00 00 00 40 00 00 00 00 00 00 00 40 00 00 80 3f 00 00 80 3f 9a 99 99 3e 00 00 00 00 00 00 5c 43 00 00 28 42 00 00 b4 42 78 00 00 00 00 00 00 00 9a 99 19 3f 00 00 80 3e 00 00 00 00 04 00 00 00 00 00 80 3f 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f cd cc 4c 3f cd cc 8c 3f 00 00 80 3f 00 00 00 00 66";
            string replace = "00 00 00 40 00 00 00 00 00 00 00 40 00 00 80 3f 00 00 80 3f 9a 99 99 3e 00 00 00 00 00 00 5c 43 00 00 28 42 00 00 b4 42 78 00 00 00 00 00 00 00 9a 99 19 3c 00 00 f5 3c 00 00 00 00 04 00 00 00 00 00 80 3f 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f cd cc 4c 3f cd cc 8c 3f 00 00 80 3f 00 00 00 00 66";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableM82BSwitch()
        {
            string search = "00 00 00 40 00 00 00 00 00 00 00 40 00 00 80 3f 00 00 80 3f 9a 99 99 3e 00 00 00 00 00 00 5c 43 00 00 28 42 00 00 b4 42 78 00 00 00 00 00 00 00 9a 99 19 3c 00 00 f5 3c 00 00 00 00 04 00 00 00 00 00 80 3f 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f cd cc 4c 3f cd cc 8c 3f 00 00 80 3f 00 00 00 00 66";
            string replace = "00 00 00 40 00 00 00 00 00 00 00 40 00 00 80 3f 00 00 80 3f 9a 99 99 3e 00 00 00 00 00 00 5c 43 00 00 28 42 00 00 b4 42 78 00 00 00 00 00 00 00 9a 99 19 3f 00 00 80 3e 00 00 00 00 04 00 00 00 00 00 80 3f 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f cd cc 4c 3f cd cc 8c 3f 00 00 80 3f 00 00 00 00 66";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion
        #region AllSniper Switch
        public async Task ScanM24Switch()
        {
            string search = "";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                M24Address = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableM24Switch()
        {
            string replace = "";

            if (M24Address.Count > 0)
            {
                bool success = false;

                foreach (var address in M24Address)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("M24 Switch Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("M24 Error", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public void ResetM24Switch()
        {
            string originalPattern = "";

            if (M24Address.Count > 0)
            {
                bool success = false;

                foreach (var address in M24Address)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("M24 Switch Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("M24 Error 101", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {

                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public async Task ScanVSKSwitch()
        {
            string search = "";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                VSKAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableVSKSwitch()
        {
            string replace = "";

            if (VSKAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in VSKAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("VSK Switch Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("VSK Error", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public void ResetVSKSwitch()
        {
            string originalPattern = "";

            if (VSKAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in VSKAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("VSK Switch Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("VSK Error 101", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {

                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        #endregion
        #region SniperTracking
        public async Task ScanSniperTracking()
        {
            string search = "06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                sniperTrackingAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableSniperTracking()
        {
            string replace = "06 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 5c 01 00";

            if (sniperTrackingAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in sniperTrackingAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("Sniper Tracking Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("ST Error", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public void ResetSniperTracking()
        {
            string originalPattern = "06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00";

            if (sniperTrackingAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in sniperTrackingAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("Sniper Tracking Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("ST Error 101", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {

                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        #endregion
        private void ShowMessageBox(string message, string status, string imageKey)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.ShowMessageBox(message, status, imageKey);
            }));
        }
    }
}


