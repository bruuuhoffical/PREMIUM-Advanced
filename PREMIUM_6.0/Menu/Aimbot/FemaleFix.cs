using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bruuuh;
using BruuuhPie;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Aimbot
{
    public class FemaleFix
    {
        private Home _mainForm;

        public FemaleFix(Home mainForm)
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

        private readonly Bool Bool = new Bool();
        private readonly Evelyn bruuuh = new Evelyn();
        private readonly AobMem2 memoryfast = new AobMem2();

        private List<KeyValuePair<string, string>> aobList = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("41 23 05 06 45 23 05 06 47 23 05 06 48 23 05 06 49 23 05 06 4A 23 05 06 4C 23 05 06 4D 23 05 06 4E 23 05 06 50 23 05 06 51 23 05 06 52 23 05 06 53 23 05 06 54 23 05 06 55 23 05 06 56 23 05 06 58 23 05 06 59 23 05 06 5A 23 05 06 5B 23 05 06 5C 23 05 06 84 65 14 06 86 65 14 06 87 65 14 06 88 65 14 06 89 65 14 06 8A 65 14 06 8B 65 14 06 8D 65 14 06 8E 65 14 06 91 65 14 06 92 65 14 06 93 65 14 06 95 65 14 06 96 65 14 06 97 65 14 06 98 65 14 06 99 65 14 06 9A 65 14 06 9C 65 14 06 9D 65 14 06 9E 65 14 06 9F 65 14 06 A0 65 14 06 A1 65 14 06 A2 65 14 06 A3 65 14 06 A4 65 14 06 A5 65 14 06 A6 65 14 06 A7 65 14 06 A8 65 14 06 C2", "85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 84 65 14 06 86 65 14 06 87 65 14 06 88 65 14 06 89 65 14 06 8A 65 14 06 8B 65 14 06 8D 65 14 06 8E 65 14 06 91 65 14 06 92 65 14 06 93 65 14 06 95 65 14 06 96 65 14 06 97 65 14 06 98 65 14 06 99 65 14 06 9A 65 14 06 9C 65 14 06 9D 65 14 06 9E 65 14 06 9F 65 14 06 A0 65 14 06 A1 65 14 06 A2 65 14 06 A3 65 14 06 A4 65 14 06 A5 65 14 06 A6 65 14 06 A7 65 14 06 A8 65 14 06 C2"),
            new KeyValuePair<string, string>("45 23 05 06 46 23 05 06 47 23 05 06 48 23 05 06 87 65 14 06 88 65 14 06 49 23 05 06 89 65 14 06 4A 23 05 06 8A 65 14 06 8B 65 14 06 4B 23 05 06 8C 65 14 06 4C 23 05 06 8D 65 14 06 4D 23 05 06 8E 65 14 06 4E 23 05 06 8F 65 14 06 50 23 05 06 90 65 14 06 4F 23 05 06 51 23 05 06 91 65 14 06 52 23 05 06 92 65 14 06 53 23 05 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 54 23 05 06 97 65 14 06 98 65 14 06 55 23 05 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 56 23 05 06 9D 65 14 06 57 23 05 06", "85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 8E 65 14 06 85 65 14 06 8F 65 14 06 85 65 14 06 90 65 14 06 85 65 14 06 85 65 14 06 91 65 14 06 85 65 14 06 92 65 14 06 85 65 14 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 85 65 14 06 97 65 14 06 98 65 14 06 85 65 14 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 85 65 14 06 9D 65 14 06 85 65 14 06"),
            new KeyValuePair<string, string>("71 23 05 06 72 23 05 06 B3 65 14 06 46 23 05 06 4F 23 05 06 85 65 14 06 9B 65 14 06 4B 23 05 06 57 23 05 06 8C 65 14 06 94 65 14 06 8F 65 14 06 AB 65 14 06 90 65 14 06 AA 65 14 06", "85 65 14 06 85 65 14 06 B3 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 9B 65 14 06 85 65 14 06 85 65 14 06 8C 65 14 06 94 65 14 06 8F 65 14 06 AB 65 14 06 90 65 14 06 AA 65 14 06")
        };

        public void EnableFemaleFix()
        {
            if (Bool.OthersMem == 0)
            {
                OnFemaleFix1();
            }
            else if (Bool.OthersMem > 1)
            {
                OnFemaleFix2();
            }
        }
        public void DisableFemaleFix()
        {
            if (Bool.OthersMem == 0)
            {
                OffFemaleFix1();
            }
            else if (Bool.OthersMem > 1)
            {
                OffFemaleFix2();
            }
        }


        private async void OnFemaleFix1()
        {
            Notify("Enabling Female To Male [0]", "");

            if (!memoryfast.SetProcess(new[] { "HD-Player" }))
            {
                Notify("Female To Male Failed", "600");
                return;
            }

            bool anySuccess = false;
            int total = aobList.Count;
            int current = 1;

            foreach (var pair in aobList)
            {
                Notify($"Enabling ({current}/{total})", "");

                IEnumerable<long> results = await memoryfast.AoBScan(pair.Key);
                if (results.Any())
                {
                    foreach (long address in results)
                    {
                        memoryfast.AobReplace(address, pair.Value);
                    }
                    anySuccess = true;
                }

                current++;
            }

            if (anySuccess)
                Notify("Female To Male Enabled [0]", "400");
            else
                Notify("Female To Male Failed", "600");
        }
        private async void OnFemaleFix2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator isn't running", "");
                return;
            }

            Notify("Enabling Female To Male [1]", "");
            bruuuh.OpenProcess("HD-Player");
            bool anySuccess = false;
            int total = aobList.Count;
            int current = 1;

            foreach (var pair in aobList)
            {
                Notify($"Enabling ({current}/{total})", "");

                IEnumerable<long> results = await bruuuh.AoBScan(pair.Key, writable: true);
                if (results.Any())
                {
                    foreach (long address in results)
                    {
                        bruuuh.WriteMemory(address.ToString("X"), "bytes", pair.Value);
                    }
                    anySuccess = true;
                }

                current++;
            }

            if (anySuccess)
                Notify("Female To Male Enabled [1]", "400");
            else
                Notify("Female To Male Failed", "600");
        }

        private List<KeyValuePair<string, string>> aobListReverse =>
        aobList.Select(pair => new KeyValuePair<string, string>(pair.Value, pair.Key)).ToList();

        private async void OffFemaleFix1()
        {
            Notify("Disabling Female To Male [0]", "");

            if (!memoryfast.SetProcess(new[] { "HD-Player" }))
            {
                Notify("Disable Female To Male Failed", "600");
                return;
            }

            bool anySuccess = false;
            int total = aobListReverse.Count;
            int current = 1;

            foreach (var pair in aobListReverse)
            {
                Notify($"Disabling ({current}/{total})", "");

                IEnumerable<long> results = await memoryfast.AoBScan(pair.Key);
                if (results.Any())
                {
                    foreach (long address in results)
                    {
                        memoryfast.AobReplace(address, pair.Value);
                    }
                    anySuccess = true;
                }

                current++;
            }

            if (anySuccess)
                Notify("Female To Male Disabled [0]", "400");
            else
                Notify("Disable Female To Male Failed", "600");
        }



        private async void OffFemaleFix2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator isn't running", "");
                return;
            }

            Notify("Disabling Female To Male [1]", "");
            bruuuh.OpenProcess("HD-Player");

            bool anySuccess = false;
            int total = aobListReverse.Count;
            int current = 1;

            foreach (var pair in aobListReverse)
            {
                Notify($"Disabling ({current}/{total})", "");

                IEnumerable<long> results = await bruuuh.AoBScan(pair.Key, writable: true);
                if (results.Any())
                {
                    foreach (long address in results)
                    {
                        bruuuh.WriteMemory(address.ToString("X"), "bytes", pair.Value);
                    }
                    anySuccess = true;
                }

                current++;
            }

            if (anySuccess)
                Notify("Female To Male Disabled [1]", "400");
            else
                Notify("Disable Female To Male Failed", "600");
        }

    }
}
