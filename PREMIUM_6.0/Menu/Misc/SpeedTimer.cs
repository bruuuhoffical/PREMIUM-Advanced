using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Misc
{
    public class SpeedTimer
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public SpeedTimer(Home mainForm)
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



        string search = "02 2b 07 3d 02 2b 07 3d 02 2b 07 3d";
        string replace = "02 2B 90 3C";
        private List<long> SpeedAddress = new List<long>();
        private List<long> Speed2Address = new List<long>();
        bool k = false;

        public void EnableSpeedTimer()
        {
            if (Bool.OthersMem == 0)
            {
                DetermineInjection1();
            }
            else if (Bool.OthersMem > 1)
            {
                DetermineInjection2();
            }
        }
        private void DetermineInjection1()
        {
            SpeedTimer1();
        }
        private void DetermineInjection2()
        {
            SpeedTimer2();
        }



        public async Task LoadSpeedTimer1()
        {
            Notify("Loading Speed Timer [0]", "");

            string[] processName = { "HD-Player" };
            bool success = memoryfast.SetProcess(processName);

            if (!success)
            {
                Notify("Emulator Not Detected", "2000");
                Bool.isSpeedLoaded = false;
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(search);

            SpeedAddress = result.ToList();

            if (SpeedAddress.Count > 0)
            {
                Notify("Speed Timer Loaded [0]", "400");
                Bool.isSpeedLoaded = true;
            }
            else
            {
                Notify("No Address Found [0]", "2000");
                Bool.isSpeedLoaded = false;
            }
        }

        public void SpeedTimer1()
        {
            if (!Bool.isSpeedLoaded)
            {
                LoadSpeedTimer1();
            }
            else if (Bool.isSpeedLoaded)
            {
                if (!Bool.isSpeedTimerEnabled)
                {
                    OnSpeedTimer1();
                }
                else if (Bool.isSpeedTimerEnabled)
                {
                    OffSpeedTimer1();
                }
            }
        }
        public void OnSpeedTimer1()
        {
            int delay = Bool.SpeedDelay * 1000;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = delay;
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                timer.Dispose();
                foreach (long address in SpeedAddress)
                {
                    memoryfast.AobReplace(address, replace);
                }

                Notify("Enabled Speed Hack", "400");
                Bool.isSpeedTimerEnabled = true;
            };
            timer.Start();
        }

        public void OffSpeedTimer1()
        {

            foreach (long address in SpeedAddress)
            {
                memoryfast.AobReplace(address, search);
            }

            Notify("Disabled Speed Hack", "400");
            Bool.isSpeedTimerEnabled = false;
        }



        public async Task LoadSpeedTimer2()
        {
            string search = this.search;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            Notify("Loading Speed Timer [1]", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                Speed2Address = foundAddresses.ToList();
                Notify("Loaded Speed Timer [1]", "400");
                Bool.isSpeedLoaded = true;
            }
            else
            {
                Notify("Failed to Load Speed Timer [1]", "2000");
                Bool.isSpeedLoaded = false;
            }
        }
        public void SpeedTimer2()
        {
            if (!Bool.isSpeedLoaded)
            {
                LoadSpeedTimer2();
            }
            else if (Bool.isSpeedLoaded)
            {
                if (!Bool.isSpeedTimerEnabled)
                {
                    OnSpeedTimer2();
                }
                else if (Bool.isSpeedTimerEnabled)
                {
                    OffSpeedTimer2();
                }
            }
        }
        private void OnSpeedTimer2()
        {
            string replace = this.replace;
            string search = this.search;
            bool success = false;

            foreach (var address in Speed2Address)
            {
                int delay = Bool.SpeedDelay * 1000;

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
                Notify("Enabled Speed Timer [1]", "400");
                Bool.isSpeedTimerEnabled = true;
            }
            else
            {
                Notify("Speed Timer Failed [1]", "800");
                Bool.isSpeedTimerEnabled = false;
            }

        }
        private void OffSpeedTimer2()
        {
            string replace = search;
            bool success = false;

            foreach (var address in Speed2Address)
            {
                bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                if (writeResult)
                {
                    success = true;
                }
            }

            if (success)
            {
                Notify("Disabled Speed Timer [1]", "400");
                Bool.isSpeedTimerEnabled = false;
            }
            else
            {
                Notify("Speed Timer Failed [1]", "800");
                Bool.isSpeedTimerEnabled = true;
            }
        }
    }
}
