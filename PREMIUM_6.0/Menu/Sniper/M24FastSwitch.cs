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
    public class M24FastSwitch
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public M24FastSwitch(Home mainForm)
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
        string search = "00 00 00 3F 00 00 80 3E 00 00 00 00 06 00 00 00 CD CC 4C 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 66 66 66 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 33 33 93 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 80 3E 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80";
        string replace = "00 00 3C 00 00 80 3C 00 00 00 00 04 06 00 00 00 CD CC 4C 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 66 66 66 3F";
        bool k = false;
        public void EnableM24Switch()
        {
            if (Bool.OthersMem == 0)
            {
                M24Switch1();
            }
            else if (Bool.OthersMem > 1)
            {
                M24Switch2();
            }
        }
        private async void M24Switch1()
        {
            Notify("Enabling M24 Switch", "");
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
            Notify("Enabled M24 Switch", "");
            Bool.M24Switch = true;
        }
        public async void M24Switch2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling M24 Switch", "");
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
                    Notify("Enabled M24 Switch", "");
                    Bool.M24Switch = true;

                }
                else
                {
                    Notify("M24 Switch Failed", "");
                }
            }
        }
    }
}
