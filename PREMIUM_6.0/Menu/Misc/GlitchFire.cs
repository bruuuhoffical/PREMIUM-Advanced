using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Misc
{
    public class GlitchFire
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public GlitchFire(Home mainForm)
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



        string search = "C0 3F 00 00 00 3F 00 00 80 3F 00 00 00 40";
        string replace = "00 00 00 00 00 F8 00 00 80 00 00 00 00 40";
        private List<long> GlitchAddress = new List<long>();
        private List<long> Glitch2Address = new List<long>();
        bool k = false;

        public void EnableGlitchFire()
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
            if (Bool.isGlitchFireLoaded == false)
            {
                LoadGlitchFire1();
            }
            else if (Bool.isGlitchFireLoaded == true)
            {
                GlitchFire1();
            }
        }
        private void DetermineInjection2()
        {
            if (Bool.isGlitchFireLoaded == false)
            {
                LoadGlitchFire2();
            }
            else if (Bool.isGlitchFireLoaded == true)
            {
                GlitchFire2();
            }
        }



        private async Task LoadGlitchFire1()
        {
            Notify("Loading Glitch Hack [0]", "");

            string[] processName = { "HD-Player" };
            bool success = memoryfast.SetProcess(processName);

            if (!success)
            {
                Notify("", "2000");
                Bool.isGlitchFireEnabled = false;
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(search);

            GlitchAddress = result.ToList();

            if (GlitchAddress.Count > 0)
            {
                Notify("Glitch Hack Loaded [0]", "400");
                Bool.isGlitchFireEnabled = false;
            }
            else
            {
                Notify("No Address Found [0]", "2000");
                Bool.isGlitchFireEnabled = false;
            }
        }

        public void GlitchFire1()
        {
            if (Bool.isGlitchFireEnabled == false)
            {
                OnGlitchFire1();
            }
            else if (Bool.isGlitchFireEnabled == true)
            {
                OffGlitchFire1();
            }
        }
        public void OnGlitchFire1()
        {
            if (GlitchAddress.Count == 0)
            {
                Notify("Glitch Hack Isnt Loaded", "2000");
                Bool.isGlitchFireEnabled = false;
                return;
            }
            foreach (long address in GlitchAddress)
            {
                memoryfast.AobReplace(address, replace);
            }

            Notify("Enabled Glitch Hack", "400");
            Bool.isGlitchFireEnabled = true;
        }

        public void OffGlitchFire1()
        {
            if (GlitchAddress.Count == 0)
            {
                Notify("Glitch Hack Isnt Loaded", "2000");
                Bool.isGlitchFireEnabled = true;
                return;
            }

            foreach (long address in GlitchAddress)
            {
                memoryfast.AobReplace(address, search);
            }

            Notify("Disabled Glitch Hack", "400");
            Bool.isGlitchFireEnabled = false;
        }



        private async Task LoadGlitchFire2()
        {
            string search = this.search;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            Notify("Loading Glitch Hack [1]", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                Glitch2Address = foundAddresses.ToList();
                Notify("Loaded Glitch Hack [1]", "400");
            }
            else
            {
                Notify("Failed to Load Glitch Hack [1]", "2000");
            }
        }
        public void GlitchFire2()
        {
            if (Bool.isGlitchFireEnabled == false)
            {
                OnGlitchFire2();
            }
            else if (Bool.isGlitchFireEnabled == true)
            {
                OffGlitchFire2();
            }
        }
        private void OnGlitchFire2()
        {
            string replace = this.replace;
            string search = this.search;
            if (Glitch2Address.Count > 0)
            {
                bool success = false;

                foreach (var address in Glitch2Address)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    Notify("Enabled Glitch Hack [1]", "400");
                    Bool.isGlitchFireEnabled = true;
                }
                else
                {
                    Notify("Glitch Hack Failed [1]", "800");
                    Bool.isGlitchFireEnabled = false;
                }
            }
            else
            {
                Notify("Glitch Hack Isnt Loaded [1]", "800");
            }

        }
        private void OffGlitchFire2()
        {
            string replace = search;
            if (Glitch2Address.Count > 0)
            {
                bool success = false;

                foreach (var address in Glitch2Address)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    Notify("Disabled Glitch Hack [1]", "400");
                    Bool.isGlitchFireEnabled = true;
                }
                else
                {
                    Notify("Glitch Hack Failed [1]", "800");
                }
            }
            else
            {
                Notify("Glitch Hack Isnt Loaded [1]", "800");
            }

        }
    }
}
