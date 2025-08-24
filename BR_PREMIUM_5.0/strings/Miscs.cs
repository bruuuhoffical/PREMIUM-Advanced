using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;

namespace BR_PREMIUM_5._0.strings
{
    public class Miscs
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
        private int _processId;

        private HOME _mainForm;
        private List<long> CameraLeftAddress = new List<long>();
        private List<long> SpeedAddress = new List<long>();
        private List<long> GlitchAddress = new List<long>();
        private List<long> WallAddress = new List<long>();
        public Miscs(HOME mainForm)
        {
            _mainForm = mainForm;

        }
        public bool Speed = false;
        public bool Wall = false;
        public bool Glitch = false;
        public bool CameraUp = false;

        #region NoRecoil
        public async void EnableNoRecoil()
        {
            string search = "E8 00 00 7A 44 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED 08 D0 4D E2 00 50 A0 E1 10 1A 08 EE 08 40 95 E5 00 00 54 E3";
            string replace = "E8 00 00 7A 7A F0 48 2D E9 10 B0 8D E2 02 8B 2D ED 08 D0 4D E2 00 50 A0 E1 10 1A 08 EE 08 40 95 E5 00 00 54 E3";
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
                    ShowMessageBox("No Recoil Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableNoRecoil()
        {
            string search = "E8 00 00 7A 7A F0 48 2D E9 10 B0 8D E2 02 8B 2D ED 08 D0 4D E2 00 50 A0 E1 10 1A 08 EE 08 40 95 E5 00 00 54 E3";
            string replace = "E8 00 00 7A 44 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED 08 D0 4D E2 00 50 A0 E1 10 1A 08 EE 08 40 95 E5 00 00 54 E3";
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
                    ShowMessageBox("No Recoil Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion


        #region FixFemale
        public async void EnableFixFemale()
        {
            string search = "45 23 05 06 46 23 05 06 47 23 05 06 48 23 05 06 87 65 14 06 88 65 14 06 49 23 05 06 89 65 14 06 4A 23 05 06 8A 65 14 06 8B 65 14 06 4B 23 05 06 8C 65 14 06 4C 23 05 06 8D 65 14 06 4D 23 05 06 8E 65 14 06 4E 23 05 06 8F 65 14 06 50 23 05 06 90 65 14 06 4F 23 05 06 51 23 05 06 91 65 14 06 52 23 05 06 92 65 14 06 53 23 05 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 54 23 05 06 97 65 14 06 98 65 14 06 55 23 05 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 56 23 05 06 9D 65 14 06 57 23 05 06";
            string replace = "85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 8E 65 14 06 85 65 14 06 8F 65 14 06 85 65 14 06 90 65 14 06 85 65 14 06 85 65 14 06 91 65 14 06 85 65 14 06 92 65 14 06 85 65 14 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 85 65 14 06 97 65 14 06 98 65 14 06 85 65 14 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 85 65 14 06 9D 65 14 06 85 65 14 06";
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
                    ShowMessageBox("Fix Female Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableFixFemale()
        {
            string search = "85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 8E 65 14 06 85 65 14 06 8F 65 14 06 85 65 14 06 90 65 14 06 85 65 14 06 85 65 14 06 91 65 14 06 85 65 14 06 92 65 14 06 85 65 14 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 85 65 14 06 97 65 14 06 98 65 14 06 85 65 14 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 85 65 14 06 9D 65 14 06 85 65 14 06";
            string replace = "45 23 05 06 46 23 05 06 47 23 05 06 48 23 05 06 87 65 14 06 88 65 14 06 49 23 05 06 89 65 14 06 4A 23 05 06 8A 65 14 06 8B 65 14 06 4B 23 05 06 8C 65 14 06 4C 23 05 06 8D 65 14 06 4D 23 05 06 8E 65 14 06 4E 23 05 06 8F 65 14 06 50 23 05 06 90 65 14 06 4F 23 05 06 51 23 05 06 91 65 14 06 52 23 05 06 92 65 14 06 53 23 05 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 54 23 05 06 97 65 14 06 98 65 14 06 55 23 05 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 56 23 05 06 9D 65 14 06 57 23 05 06";
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
                    ShowMessageBox("Fix Female Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion


        #region FastReload
        public async void EnableFastReload()
        {
            string search = "6D 00 00 EB 00 0A B7 EE 10 0A 01 EE 00 0A 31 EE 10 5A 01 EE 00 0A 21 EE 10 0A 10 EE 30 88 BD E8 F0 48";
            string replace = "FF 02 44 E3";
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
                    ShowMessageBox("Fast Reload Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableFastReload()
        {
            string search = "FF 02 44 E3";
            string replace = "6D 00 00 EB 00 0A B7 EE 10 0A 01 EE 00 0A 31 EE 10 5A 01 EE 00 0A 21 EE 10 0A 10 EE 30 88 BD E8 F0 48";
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
                    ShowMessageBox("Fast Reload Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion


        #region BlackSky
        public async void EnableBlackSky()
        {
            string search = "A4 70 7D 3F 3A CD 13 3F 0A D7 23 3C BD 37 86 35";
            string replace = "A4 70 7D 3F 3A CD 13 3F 0A D7 23 3C 00 00 80 BF";
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
                    ShowMessageBox("Black Sky Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableBlackSky()
        {
            string search = "A4 70 7D 3F 3A CD 13 3F 0A D7 23 3C 00 00 80 BF";
            string replace = "A4 70 7D 3F 3A CD 13 3F 0A D7 23 3C BD 37 86 35";
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
                    ShowMessageBox("Black Sky Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion

        #region CameraUp
        public async void EnableCameraUp()
        {
            string search = "";
            string replace = "";
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
                    ShowMessageBox("Camera Up Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableCameraUp()
        {
            string search = "";
            string replace = "";
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
                    ShowMessageBox("Camera Up Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion


        #region CameraLeft

        public async Task ScanCameraLeft()
        {
            string search = "00 00 00 00 22 9E 93 40 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";

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
                CameraLeftAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
                CameraUp = false;
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

        public void EnableCameraLeft()
        {
            string replace = "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";

            if (CameraLeftAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in CameraLeftAddress)
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
                        ShowMessageBox("CML Location Enabled", "", "");
                        CameraUp = true;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("CML Error", "failed", "");
                        CameraUp = false;
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
        public void ResetCameraLeft()
        {
            string originalPattern = "00 00 00 00 22 9E 93 40 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";

            if (CameraLeftAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in CameraLeftAddress)
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

                        ShowMessageBox("CML Disabled", "", "");
                        CameraUp = false;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("CML Error 101", "failed", "");
                        CameraUp = true;
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


        //#region SpeedHack

        //public async Task ScanSpeedHack()
        //{
        //    string search = "01 00 00 00 02 2b 07 3d";

        //    if (Process.GetProcessesByName("HD-Player").Length == 0)
        //    {
        //        ShowMessageBox("Open Emulator", "failed", "");
        //        return;
        //    }

        //    bruuuh.OpenProcess("HD-Player");
        //    ShowMessageBox("Scanning...", "activating", "");

        //    IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

        //    if (foundAddresses.Count() > 0)
        //    {
        //        SpeedAddress = foundAddresses.ToList();
        //        ShowMessageBox("Scan Success", "", "");
        //    }
        //    else
        //    {
        //        if (_mainForm.IsCheckboxChecked())
        //        {

        //        }
        //        else
        //        {
        //            ShowMessageBox("Scan Failed", "Memory pattern not found", "");
        //        }
        //    }
        //}

        //public void EnableSpeedHck()
        //{
        //    string replace = "01 00 00 00 FF FF 84 3D";

        //    if (SpeedAddress.Count > 0)
        //    {
        //        bool success = false;

        //        foreach (var address in SpeedAddress)
        //        {
        //            bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
        //            if (writeResult)
        //            {
        //                success = true;
        //            }
        //        }

        //        if (success)
        //        {
        //            if (_mainForm.IsCheckboxChecked())
        //            {

        //            }
        //            else
        //            {
        //                ShowMessageBox("SPH Location Enabled", "", "");
        //            }
        //        }
        //        else
        //        {
        //            if (_mainForm.IsCheckboxChecked())
        //            {

        //            }
        //            else
        //            {
        //                ShowMessageBox("SPH Error", "failed", "");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (_mainForm.IsCheckboxChecked())
        //        {

        //        }
        //        else
        //        {
        //            ShowMessageBox("Please Load First !", "failed", "");
        //        }
        //    }
        //}
        //public void ResetSpeedHack()
        //{
        //    string originalPattern = "01 00 00 00 02 2b 07 3d";

        //    if (SpeedAddress.Count > 0)
        //    {
        //        bool success = false;

        //        foreach (var address in SpeedAddress)
        //        {
        //            bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
        //            if (writeResult)
        //            {
        //                success = true;
        //            }
        //        }

        //        if (success)
        //        {
        //            if (_mainForm.IsCheckboxChecked())
        //            {

        //            }
        //            else
        //            {

        //                ShowMessageBox("SPH Location Disabled", "", "");
        //            }
        //        }
        //        else
        //        {
        //            if (_mainForm.IsCheckboxChecked())
        //            {

        //            }
        //            else
        //            {

        //                ShowMessageBox("SPH Error 101", "failed", "");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (_mainForm.IsCheckboxChecked())
        //        {

        //        }
        //        else
        //        {

        //            ShowMessageBox("Please Load First !", "failed", "");
        //        }
        //    }
        //}
        //#endregion





        #region GhostHack

        public async Task ScanGhostHack()
        {
            string search = "F0 4F 2D E9 1C B0 8D E2 54 D0 4D E2 00 A0 A0 E1 48 0E 9F E5 01 50 A0 E1 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A 34 0E 9F E5 00 00 9F E7 00 00 90 E5";

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
                GlitchAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
                Glitch = false;
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

        public void EnableGhostHack()
        {
            string replace = "00 00 A0 E3 1E FF 2F E1";
            //string replace1 = "00 00 70 c1 00 00 a0 41 00 00 10 41 00 00 00 3f e6 00 00 00 00 00 b0 7e";

            if (GlitchAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in GlitchAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    //bool writeResult1 = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace1);
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
                        ShowMessageBox("GH Location Enabled", "", "");
                        Glitch = true;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("GH Error", "failed", "");
                        Glitch = false;
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
        public void ReseGhostHack()
        {
            string originalPattern = "F0 4F 2D E9 1C B0 8D E2";

            if (GlitchAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in GlitchAddress)
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

                        ShowMessageBox("GH Disabled", "", "");
                        Glitch = false;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("GH Error 101", "failed", "");
                        Glitch = true;
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


        #region SpeedHack

        public async Task ScanSpeed()
        {
            string search = "00 01 00 00 00 02 2B 07 3D 00";

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
                SpeedAddress = foundAddresses.ToList();
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
                    Speed = false;
                }
            }
        }

        public void EnablSpeed()
        {
            string replace = "00 01 00 00 00 92 E4 67 3D 00";

            if (SpeedAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in SpeedAddress)
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
                        ShowMessageBox("SP Location Enabled", "", "");
                        Speed = true;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("SP Error", "failed", "");
                        Speed = false;
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
        public void ResetSpeed()
        {
            string originalPattern = "00 01 00 00 00 02 2B 07 3D 00";

            if (SpeedAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in SpeedAddress)
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

                        ShowMessageBox("SP Location Disabled", "", "");
                        Speed = false;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("SP Error 101", "failed", "");
                        Speed = true;
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


    #region WallHack

        public async Task ScanWall()
        {
            string search = "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A B0 EE EF 0A 60 F4 43 6A F0 EE 1C 00 8A E2 43 5A F0 EE 8F 0A";

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
                WallAddress = foundAddresses.ToList();
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
                    //Wall = false;
                }
            }
        }

        public void EnablWall()
        {
            string replace = "BF AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30";

            if (WallAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in WallAddress)
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
                        ShowMessageBox("WH Location Enabled", "", "");
                        Wall = true;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("WH Error", "failed", "");
                        Wall = false;
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
                    Wall = false;
                }
            }
        }
        public void ResetWall()
        {
            string originalPattern = "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A B0 EE EF 0A 60 F4 43 6A F0 EE 1C 00 8A E2 43 5A F0 EE 8F 0A";

            if (WallAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in WallAddress)
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

                        ShowMessageBox("WH Location Disabled", "", "");
                        Wall = false;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("WH Error 101", "failed", "");
                        Wall = true;
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
                    Wall = true;
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
