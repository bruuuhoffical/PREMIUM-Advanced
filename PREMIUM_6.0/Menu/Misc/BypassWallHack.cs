using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Misc
{
    public class BypassWallHack
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public BypassWallHack(Home mainForm)
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



        string search = "10 8D E5 00 A0 A0 E3 14 00 8D E5 09 00 A0 E1 18 10 8D E5 1C 10 8D E5 10 17 02 E3 35 FF";
        string replace = "10 8D E5 00 A0 A0 E3 14 00 8D E5 09 00 A0 E1 18 10 8D E5 1C 10 8D E5 10 17 02 E3 00";
        private List<long> WallAddress = new List<long>();
        private List<long> Wall2Address = new List<long>();
        bool k = false;

        public void EnableBypassWallHack()
        {
            if (Bool.OthersMem == 0)
            {
                LoadBypassWallHack1();
            }
            else if (Bool.OthersMem > 1)
            {
                LoadBypassWallHack2();
            }
        }


        private async Task LoadBypassWallHack1()
        {
            Notify("Bypassing Wall Hack [0]", "");

            string[] processName = { "HD-Player" };
            bool success = memoryfast.SetProcess(processName);

            if (!success)
            {
                Notify("Emulator Aint Running", "2000");
            }

            IEnumerable<long> result = await memoryfast.AoBScan(search);

            WallAddress = result.ToList();

            if (WallAddress.Count > 0)
            {
                // Notify("Wall Hack Bypassed [0]", "400");
                OnBypassWallHack1();
            }
            else
            {
                Notify("No Address Found [0]", "2000");
            }
        }
        public void OnBypassWallHack1()
        {
            int delay = Bool.WallDelay * 1000;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = delay;
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                timer.Dispose();
                foreach (long address in WallAddress)
                {
                    memoryfast.AobReplace(address, replace);
                }

                Notify("Wall Hack Bypassed [0]", "400");
            };
            timer.Start();
        }



        private async Task LoadBypassWallHack2()
        {
            string search = this.search;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            Notify("Bypassing Wall Hack [1]", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                Wall2Address = foundAddresses.ToList();
                OnBypassWallHack2();
                //Notify("Loaded Bypass Wall Hack [1]", "400");
            }
            else
            {
                Notify("Failed to Bypass Wall Hack [1]", "2000");
            }
        }
        private void OnBypassWallHack2()
        {
            string replace = this.replace;
            string search = this.search;
            bool success = false;

            foreach (var address in Wall2Address)
            {
                int delay = Bool.WallDelay * 1000;

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = delay;
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    timer.Dispose();
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                };
                timer.Start();
            }

            if (success)
            {
                Notify("Wall Hack Bypassed [1]", "400");
            }
            else
            {
                Notify("Wall Hack Bypass Failed [1]", "800");
            }

        }
    }
}
