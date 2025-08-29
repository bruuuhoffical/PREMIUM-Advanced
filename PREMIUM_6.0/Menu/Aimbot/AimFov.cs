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
    public class AimFov
    {
        private Home _mainForm;
        public AimFov(Home mainForm)
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

        public void EnableAimfov()
        {
            if (Bool.OthersMem == 0)
            {
                Aimfov1();
            }
            else if (Bool.OthersMem > 1)
            {
                Aimfov2();
            }
        }
        public void DisableAimfov()
        {
            if (Bool.OthersMem == 0)
            {
                DisableAimfov1();
            }
            else if (Bool.OthersMem > 1)
            {
                DisableAimfov2();
            }
        }

        private async void Aimfov1()
        {
            Notify("Enabling Aim Fov", "");
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
            Notify("Aim Fov Enabled", "");
        }
        public async void Aimfov2()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling Aim Fov", "");
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
                    Notify("Enabled Aim Fov", "");

                }
                else
                {
                    Notify("Failed", "");
                }
            }
        }
        private async void DisableAimfov1()
        {
            Notify("Disabling Aim Fov", "");
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

            Notify("Aim Fov Disabled", "");
        }

        private async void DisableAimfov2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isn't Running", "800");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            Notify("Disabling Aim Fov", "");

            IEnumerable<long> wl = await bruuuh.AoBScan(replace, writable: true);

            if (wl.Any())
            {
                foreach (long addr in wl)
                {
                    bruuuh.WriteMemory(addr.ToString("X"), "bytes", revert); 
                }

                Notify("Aim Fov Disabled", "");
            }
            else
            {
                Notify("Revert Failed — Signature Not Found", "600");
            }
        }

    }
}
