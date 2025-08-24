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
    public class SniperSwitch
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public SniperSwitch(Home mainForm)
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
        string highsearch = "B4 42 96 00 00 00 00 00 00 00 00 00 00 ?? 00 00 80 ?? 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 8F C2 35 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F";
        string highreplace = "B4 42 96 00 00 00 00 00 00 00 00 00 00 3c 00 00 80 00 00 00 00 00 04 00 00 00 00 00 80 3F";
        string medsearch = "01 50 00 43 05 00 A0 E1 04 8B BD EC 30 88 BD E8";
        string medreplace = "00";
        string lowsearch = "CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F";
        string lowreplace = "CC 3D 06 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 33 33 13 40 00 00 B0 3F 00 00 80 4C";
        bool k = false;
        public void EnableSniperSwitch()
        {
            if (Bool.OthersMem == 0)
            {
                SniperSwitchHigh();
            }
            else if (Bool.OthersMem == 1)
            {
                SniperSwitchMed();
            }
            else if (Bool.OthersMem == 2)
            {
                SniperSwitchLow();
            }
        }
        private async void SniperSwitchHigh()
        {
            Notify("Enabling Sniper Switch", "");
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(highsearch);

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, highreplace);
            }
            Notify("Enabled Sniper Switch", "");
            Bool.SniperSwitch = true;
        }
        public async void SniperSwitchMed()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling Sniper Switch", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(medsearch, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", medreplace);
                    }
                    k = true;
                }
                if (k == true)
                {
                    Notify("Enabled Sniper Switch", "");
                    Bool.SniperSwitch = true;

                }
                else
                {
                    Notify("Sniper Switch Failed", "");
                }
            }
        }
        private async void SniperSwitchLow()
        {
            Notify("Enabling Sniper Switch", "");
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(lowsearch);

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, lowreplace);
            }
            Notify("Enabled Sniper Switch", "");
            Bool.SniperSwitch = true;
        }
    }
}
