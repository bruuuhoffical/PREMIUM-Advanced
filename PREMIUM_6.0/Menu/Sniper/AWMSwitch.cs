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
    public class AWMSwitch
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public AWMSwitch(Home mainForm)
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
        string search = "B4 C8 D6 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 00 3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F";
        string replace = "B4 C8 D6 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 00 3C 00 00 80 3C 00 00 00 00 04 00 00 00 00 00 80 3F";
        bool k = false;
        public void EnableAWMSwitch()
        {
            if (Bool.OthersMem == 0)
            {
                AWMSwitch1();
            }
            else if (Bool.OthersMem > 1)
            {
                AWMSwitch2();
            }
        }
        private async void AWMSwitch1()
        {
            Notify("Enabling AWM Switch", "");
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
            Notify("Enabled AWM Switch", "");
            Bool.AWMSwitch = true;
        }
        public async void AWMSwitch2()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling AWM Switch", "");
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
                    Notify("Enabled AWM Switch", "");
                    Bool.AWMSwitch = true;

                }
                else
                {
                    Notify("AWM Switch Failed", "");
                }
            }
        }
    }
}
