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
    public class Guest
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public Guest(Home mainForm)
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



        string search = "10 4C 2D E9 08 B0 8D E2 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5 00 00 9F E7 00 00 90 E5 BE 21 09 EB F0 00 9F E5";
        string replace = "01 00 A0 E3 1E FF 2F E1 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5 00 00 9F E7 00 00 90 E5 BE 21 09 EB F0 00 9F E5";
        string search1 = "10 4C 2D E9 08 B0 8D E2 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5 00 00 9F E7 00 00 90 E5 BE 21 09 EB F0 00 9F E5";
        string replace1 = "01 00 A0 E3 1E FF 2F E1 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5 00 00 9F E7 00 00 90 E5 BE 21 09 EB F0 00 9F E5";
        bool k = false;
        public void EnableGuest()
        {
            if (Bool.OthersMem == 0)
            {
                Guest1();
            }
            else if (Bool.OthersMem > 1)
            {
                Guest2();
            }
        }
        private async void Guest1()
        {
            Notify("Resetting Guest", "");
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
            Notify("Guest Reset", "");
        }
        public async void Guest2()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Resetting Guest", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search1, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace1);
                    }
                    k = true;
                }
                if (k == true)
                {
                    Notify("Guest Reset", "");

                }
                else
                {
                    Notify("Failed", "");
                }
            }
        }

    }
}
