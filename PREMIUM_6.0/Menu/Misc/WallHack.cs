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
    public class WallHack
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public WallHack(Home mainForm)
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



        string search = "3F AE 47 81 3F AE 47 81 3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A B0 EE EF 0A 60 F4 43 6A F0 EE 1C 00 8A E2 43 5A F0 EE 8F 0A 48 F4 43 2A F0 EE 43 7A B0 EE 8F 0A 40 F4 41 AA B0 EE FE 05 A0 E3 41 1A F0 EE 2C 00 8A E5 10";
        //string search = "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30";
        string replace = "3F AE 47 81 3F AE 47 81 BF AE 47 81 3F AE 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A B0 EE EF 0A 60 F4 43 6A F0 EE 1C 00 8A E2 43 5A F0 EE 8F 0A 48 F4 43 2A F0 EE 43 7A B0 EE 8F 0A 40 F4 41 AA B0 EE FE 05 A0 E3 41 1A F0 EE 2C 00 8A E5 10";
        //string replace = "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30";
        private List<long> WallAddress = new List<long>();
        private List<long> Wall2Address = new List<long>();
        bool k = false;

        public void EnableWallHack()
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
            if (Bool.WallType == 0)
            {
                LoadWallHack1();
            }
            else if (Bool.WallType == 1)
            {
                CheckWall1();
            }
            else if (Bool.WallType == 2)
            {

            }
        }
        private void DetermineInjection2()
        {
            if (Bool.WallType == 0)
            {
                LoadWallHack2();
            }
            else if (Bool.WallType == 1)
            {
                CheckWall2();
            }
            else if (Bool.WallType == 2)
            {

            }
        }



        private async Task LoadWallHack1()
        {
            Notify("Loading Wall Hack [0]", "");

            string[] processName = { "HD-Player" };
            bool success = memoryfast.SetProcess(processName);

            if (!success)
            {
                Notify("", "2000");
                Bool.isWallHack1Loaded = false;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(search);

            WallAddress = result.ToList();

            if (WallAddress.Count > 0)
            {
                Notify("Wall Hack Loaded [0]", "400");
                Bool.isWallHack1Loaded = true;
            }
            else
            {
                Notify("No Address Found [0]", "2000");
                Bool.isWallHack1Loaded = false;
            }
        }
        private async void CheckWall1()
        {
            if(!Bool.isWallHack1Loaded)
            {
                await LoadWallHack1();
            }
            else if (Bool.isWallHack1Loaded)
            {
                if (!Bool.isWallHack1Enabled)
                {
                    OnWallHack1();
                }
                else
                {
                    OffWallHack1();
                }
            }
        }
        public void OnWallHack1()
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

                Notify("Enabled Wall Hack", "400");
                Bool.isWallHack1Enabled = true;
            };
            timer.Start();
        }

        public void OffWallHack1()
        {

            foreach (long address in WallAddress)
            {
                memoryfast.AobReplace(address, search);
            }

            Notify("Disabled Wall Hack", "400");
            Bool.isWallHack1Enabled = false;
        }











        public async void WallHack2()
        {
            if (Bool.isWallHack1Loaded == false)
            {
                await LoadWallHack2();
            }
            else if (Bool.isWallHack2Enabled == true)
            {
                CheckWall2();
            }
        }
        private async Task LoadWallHack2()
        {
            string search = this.search;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            Notify("Loading Wall Hack [1]", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                Wall2Address = foundAddresses.ToList();
                Notify("Loaded Wall Hack [1]", "400");
                Bool.isWallHack2Enabled = true;
            }
            else
            {
                Notify("Failed to Load Wall Hack [1]", "2000");
            }
        }
        void CheckWall2()
        {
            if (!Bool.isWallHack1Loaded)
            {
                LoadWallHack2();
            }
            else if (Bool.isWallHack1Loaded)
            {
                if (!Bool.isWallHack1Enabled)
                {
                    OnWallHack2();
                }
                else if (Bool.isWallHack1Enabled)
                {
                    OffWallHack2();
                }
            }
        }
        private void OnWallHack2()
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
                Notify("Enabled Wall Hack [1]", "400");
                Bool.isWallHack1Enabled = true;
            }
            else
            {
                Notify("Wall Hack Failed [1]", "800");
                Bool.isWallHack1Enabled = false;
            }

        }
        private void OffWallHack2()
        {
            string replace = search;
            bool success = false;

            foreach (var address in Wall2Address)
            {
                bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                if (writeResult)
                {
                    success = true;
                }
            }

            if (success)
            {
                Notify("Disabled Wall Hack [1]", "400");
                Bool.isWallHack1Enabled = false;
            }
            else
            {
                Notify("Wall Hack Failed [1]", "800");
                Bool.isWallHack1Enabled = true;
            }

        }
    }
}
