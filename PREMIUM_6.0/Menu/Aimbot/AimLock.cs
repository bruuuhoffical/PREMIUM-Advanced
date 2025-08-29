using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using BruuuhPie;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Aimbot
{
    public class AimLock
    {
        private Home _mainForm;
        public AimLock(Home mainForm)
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
        string search = "";
        string replace = "";

        //Disable
        string revert = "";

        bool k = false;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        PieMem piemem = new PieMem();

        public void EnableAimLock()
        {
            if (Bool.OthersMem == 0)
            {
                AimLock1();
            }
            else if (Bool.OthersMem > 1)
            {
                AimLock2();
            }
        }
        public void DisableAimLock()
        {
            if (Bool.OthersMem == 0)
            {
                DisableAimLock1();
            }
            else if (Bool.OthersMem > 1)
            {
                DisableAimLock2();
            }
        }

        private async void AimLock1()
        {
            Notify("Enabling Aim Lock", "");
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(search);

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, replace);
            }
            Notify("Aim Lock Enabled", "");
        }
        public async void AimLock2()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling Aim Lock", "");
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
                    Notify("Enabled Aim Lock", "");

                }
                else
                {
                    Notify("Failed", "");
                }
            }
        }
        private async void DisableAimLock1()
        {
            Notify("Disabling Aim Lock", "");
            string[] processname = { "HD-Player" };
            bool success = memoryfast.SetProcess(processname);

            if (!success)
            {
                Notify("Failed to attach process", "600");
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(replace); 

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, revert); 
            }

            Notify("Aim Lock Disabled", "");
        }

        private async void DisableAimLock2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isn't Running", "800");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            Notify("Disabling Aim Lock", "");

            IEnumerable<long> wl = await bruuuh.AoBScan(replace, writable: true);

            if (wl.Any())
            {
                foreach (long addr in wl)
                {
                    bruuuh.WriteMemory(addr.ToString("X"), "bytes", revert); 
                }

                Notify("Aim Lock Disabled", "");
            }
            else
            {
                Notify("Revert Failed — Signature Not Found", "600");
            }
        }

    }
}
