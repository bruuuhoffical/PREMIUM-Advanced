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
    public class SniperDelayFix
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public SniperDelayFix(Home mainForm)
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
        string search = "EA 00 60 A0 E3 06 00 A0 E1 18 D0 4B E2 02 8B BD EC 70 8C";
        string replace = "01 00 AF E3";
        bool k = false;
        public void EnableSniperDelayFix()
        {
            if (Bool.OthersMem == 0)
            {
                SniperDelayFix1();
            }
            else if (Bool.OthersMem > 1)
            {
                SniperDelayFix2();
            }
        }
        private async void SniperDelayFix1()
        {
            Notify("Enabling Sniper Delay Fix", "");
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
            Notify("Enabled Sniper Delay Fix", "");
            Bool.SniperDelayFix = true;
        }
        public async void SniperDelayFix2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling Sniper Delay Fix", "");
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
                    Notify("Enabled Sniper Delay Fix", "");

                }
                else
                {
                    Notify("Sniper Delay Fix Failed", "");
                    Bool.SniperDelayFix = true;
                }
            }
        }
    }
}
