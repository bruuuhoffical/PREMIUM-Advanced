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
    public class Anticheat
    {
        private Home _mainForm;

        public Anticheat(Home mainForm)
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

        private readonly List<string> aobSearchPatterns = new List<string>
        {
            "00 48 2D E9 0D B0 A0 E1 68 D0 4D E2 04 C2 9F E5",
            "D0 B5 02 AF 00 28 00 F0 8D 81 04 46 41 F6 70 60",
            "D0 B5 02 AF 82 B0 08 46 0C 46 00 F0 43 F9 81 48",
            "F0 B5 03 AF 2D E9 00 0F C9 B0 04 46 30 48 78 44",
            "00 48 2D E9 0D B0 A0 E1 60 D0 4D E2 11 00 4B E2",
            "00 48 2D E9 0D B0 A0 E1 58 D0 4D E2 C8 33 9F E5"
        };

        private readonly string fixedReplacement = "00 00 A0 E3 1E FF 2F E1";

        public void EnableAnticheat()
        {
            if (Bool.OthersMem == 0)
            {
                Anticheat1();
            }
            else if (Bool.OthersMem > 1)
            {
                Anticheat2();
            }
        }

        private async void Anticheat1()
        {
            Notify("Applying Anticheat [0]", "");

            if (!memoryfast.SetProcess(new[] { "HD-Player" }))
            {
                Notify("Anticheat Injection Failed", "600");
                return;
            }

            bool anySuccess = false;
            int total = aobSearchPatterns.Count;
            int current = 1;

            foreach (var pattern in aobSearchPatterns)
            {
                Notify($"Injecting ({current}/{total})", "");

                IEnumerable<long> results = await memoryfast.AoBScan(pattern);
                if (results.Any())
                {
                    foreach (long address in results)
                    {
                        memoryfast.AobReplace(address, fixedReplacement);
                    }
                    anySuccess = true;
                }

                current++;
            }

            if (anySuccess)
                Notify("Anticheat Applied [0]", "400");
            else
                Notify("Anticheat Injection Failed", "600");
        }

        public async void Anticheat2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator isn't running", "");
                return;
            }

            Notify("Applying Anticheat [1]", "");
            bruuuh.OpenProcess("HD-Player");

            bool anySuccess = false;
            int total = aobSearchPatterns.Count;
            int current = 1;

            foreach (var pattern in aobSearchPatterns)
            {
                Notify($"Injecting ({current}/{total})", "");

                IEnumerable<long> results = await bruuuh.AoBScan(pattern, writable: true);
                if (results.Any())
                {
                    foreach (long address in results)
                    {
                        bruuuh.WriteMemory(address.ToString("X"), "bytes", fixedReplacement);
                    }
                    anySuccess = true;
                }

                current++;
            }

            if (anySuccess)
                Notify("Anticheat Applied [1]", "400");
            else
                Notify("Anticheat Injection Failed", "600");
        }
    }
}
