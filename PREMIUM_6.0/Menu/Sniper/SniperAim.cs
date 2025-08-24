using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Sniper
{
    public class SniperAim
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public SniperAim(Home mainForm)
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
        string search = "00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F F5 F4 74 3E D1 D0 50 3E 00 00 80 3F 00 00 80 3F";
        string replace = "00 C0 22 22 00 00 80 3F 00 C0 79 44 00 00 D0 3F 00 00 22 44 00 00 80 3F 00 C0 FF FF 00 00 C0 3F 00 00 80 3F";
        bool k = false;
        public void EnableSniperAim()
        {
            if (Bool.OthersMem == 0)
            {
                SniperAim1();
            }
            else if (Bool.OthersMem > 1)
            {
                SniperAim2();
            }
        }
        private async void SniperAim1()
        {
            Notify("Enabling Sniper Aim", "");
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
            Notify("Enabled Sniper Aim", "");
            Bool.SniperAim = true;
        }
        public async void SniperAim2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling Sniper Aim", "");
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
                    Notify("Enabled Sniper Aim", "");
                    Bool.SniperAim = true;

                }
                else
                {
                    Notify("Sniper Aim Failed", "");
                }
            }
        }
    }
}
