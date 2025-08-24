using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Aimbot
{
    public class ScopeTracking
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public ScopeTracking(Home mainForm)
        {
            _mainForm = mainForm;

        }
        private void Notify(string message, string message1)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.Notify(message, message1);
            }));
        }



        string search2x = "c0 3f 33 33 13 40 00 00 f0 3f 00 00 80 3f";
        string replace2x = "c0 3f 33 33 13 40 00 00 f0 3f 00 00 80 4c";
        string search4x = "20 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D ?? 00 00 00 29 5C 8F 3D 00 00 00 3F 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 D0 3F 00 00 80 3F 01";
        string replace4x = "20 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D ?? 00 00 00 29 5C 8F 3D 00 00 00 3F 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 D0 3F 00 00 80 5C 01";
        bool k = false;
        public void EnableScopeTracking2X()
        {
            if (Bool.OthersMem == 0)
            {
                OnScopeTracking2Xa();
            }
            else if (Bool.OthersMem > 1)
            {
                OnScopeTracking2Xb();
            }
        }
        public void DisableScopeTracking2X()
        {
            if (Bool.OthersMem == 0)
            {
                OffScopeTracking2Xa();
            }
            else if (Bool.OthersMem > 1)
            {
                OffScopeTracking2Xb();
            }
        }

        public void EnableScopeTracking4X()
        {
            if (Bool.OthersMem == 0)
            {
                OnScopeTracking4Xa();
            }
            else if (Bool.OthersMem > 1)
            {
                OnScopeTracking4Xb();
            }
        }
        public void DisbleScopeTracking4X()
        {
            if (Bool.OthersMem == 0)
            {
                OffScopeTracking4Xa();
            }
            else if (Bool.OthersMem > 1)
            {
                OffScopeTracking4Xb();
            }
        }


        private async void OnScopeTracking2Xa()
        {
            Notify("Enabling Scope Tracking 2X [0]", "");
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(search2x);

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, replace2x);
            }
            Notify("Enabled Scope Tracking 2X [0]", "400");
        }
        private async void OnScopeTracking2Xb()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling Scope Tracking 2X [1]", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search2x, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace2x);
                    }
                    k = true;
                }
                if (k == true)
                {
                    Notify("Enabled Scope Tracking 2X [1]", "400");

                }
                else
                {
                    Notify("Scope Tracking 2X Failed [1]", "800");
                }
            }
        }
        
        private async void OffScopeTracking2Xa()
        {
            Notify("Disabling Scope Tracking 2X [0]", "");
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(replace2x);

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, search2x);
            }
            Notify("Disabled Scope Tracking 2X [0]", "400");
        }
        private async void OffScopeTracking2Xb()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Disabling Scope Tracking 2X [1]", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(replace2x, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", search2x);
                    }
                    k = true;
                }
                if (k == true)
                {
                    Notify("Disabled Scope Tracking 2X [1]", "400");

                }
                else
                {
                    Notify("Scope Tracking 2X Failed [1]", "800");
                }
            }
        }
        



        private async void OnScopeTracking4Xa()
        {
            Notify("Enabling Scope Tracking 4X [0]", "");
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(replace4x);

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, replace2x);
            }
            Notify("Enabled Scope Tracking 4x [0]", "400");
        }
        private async void OnScopeTracking4Xb()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling Scope Tracking 4X [1]", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search4x, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace4x);
                    }
                    k = true;
                }
                if (k == true)
                {
                    Notify("Enabled Scope Tracking 4x [1]", "400");

                }
                else
                {
                    Notify("Scope Tracking 4x Failed [1]", "800");
                }
            }
        }
        
        private async void OffScopeTracking4Xa()
        {
            Notify("Disabling Scope Tracking 4X [0]", "");
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(replace4x);

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, search4x);
            }
            Notify("Disabled Scope Tracking 4x [0]", "400");
        }
        private async void OffScopeTracking4Xb()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Disabling Scope Tracking 4X [1]", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(replace4x, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", search4x);
                    }
                    k = true;
                }
                if (k == true)
                {
                    Notify("Disabled Scope Tracking 4x [1]", "400");

                }
                else
                {
                    Notify("Scope Tracking 4x Failed [1]", "800");
                }
            }
        }
    }
}
