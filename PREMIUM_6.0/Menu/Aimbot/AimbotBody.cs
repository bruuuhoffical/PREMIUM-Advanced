using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Bruuuh;
using BruuuhPie;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Aimbot
{
    public class AimbotBody
    {
        private Home _mainForm;

        public AimbotBody(Home mainForm)
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
            new KeyValuePair<string, string>("DC 52 39 BD 27 C1 8B 3C C0 D0 F8 B9", "00 00 00 3E 0A D7 23 3D D2 A5 F9 BC"),
            new KeyValuePair<string, string>("63 71 B0 BD 90 98 74 BB 00 00 80 B3", "CD DC 79 44 90 98 74 BB 00 00 80 B3"),
            new KeyValuePair<string, string>("5D C1 AB 2C 09 04 FF 18 EF E5 11 59", "CD DC 79 44 58 34 09 BB B0 60 BE BA"),
            new KeyValuePair<string, string>("7B F9 6C BD 58 34 09 BB B0 60 BE BA", "CD DC 79 44 58 34 09 BB B0 60 BE BA"),
            new KeyValuePair<string, string>("21 60 29 1C 80 A2 F4 00 C8 D1 85 DE", "CD DC 79 44 58 34 09 BB B0 60 BE BA"),
            new KeyValuePair<string, string>("13 66 CF 2C 2C 79 F9 7E 6C E1 D5 13", "CD DC 79 44 58 34 09 BB B0 60 BE BA"),
            new KeyValuePair<string, string>("7B F9 6C BD 58 34 09 BB B0 60 BE BA", "CD DC 79 44 58 34 09 BB B0 60 BE BA"),
            new KeyValuePair<string, string>("54 1B 87 BD 90 C6 D7 BA 80 54 99 B9", "CD DC 79 44 90 C6 D7 BA 80 54 99 B9"),
            new KeyValuePair<string, string>("71 02 87 BD 90 FD D7 BA 40 18 98 39", "CD DC 79 44 90 FD D7 BA 40 18 98 39"),
            new KeyValuePair<string, string>("CC F8 6C BD 40 D2 CE B9 58 64 BE 3A", "CD DC 79 44 40 D2 CE B9 58 64 BE 3A"),
            new KeyValuePair<string, string>("00 00 00 00 40 D2 CE B9 58 64 BE 3A", "CD DC 79 44 40 D2 CE B9 58 64 BE 3A"),
            new KeyValuePair<string, string>("CC F8 6C BD 40 D2 CE B9 58 64 BE 3A", "CD DC 79 44 40 D2 CE B9 58 64 BE 3A"),
            new KeyValuePair<string, string>("76 FC DB BC 7C 5E 8B 3A 50 8B BB 3A", "CD DC 79 44 7C 5E 8B 3A 50 8B BB 3A"),
            new KeyValuePair<string, string>("80 13 95 BC 30 FF 37 BB 00 FD 78 3B", "CD DC 79 44 30 FF 37 BB 00 FD 78 3B"),
            new KeyValuePair<string, string>("1F 93 DB BC 90 BF 84 3A 20 A6 BB BA", "CD DC 79 44 90 BF 84 3A 20 A6 BB BA"),
            new KeyValuePair<string, string>("EF A3 00 BE 40 B9 92 39 20 4E 07 BA", "CD DC 79 44 40 B9 92 39 20 4E 07 BA"),
            new KeyValuePair<string, string>("BC 19 FD BD B0 E3 A9 3A 80 42 23 B9", "CD DC 79 44 B0 E3 A9 3A 80 42 23 B9")
        };

        public void EnableAimbotBody()
        {
            if (Bool.OthersMem == 0)
            {
                AimbotBody1();
            }
            else if (Bool.OthersMem > 1)
            {
                AimbotBody2();
            }
        }

        private async void AimbotBody1()
        {
            Notify("Applying Aimbot Body [0]", "");

            if (!memoryfast.SetProcess(new[] { "HD-Player" }))
            {
                Notify("Aimbot Body Injection Failed", "600");
                return;
            }

            bool anySuccess = false;
            int total = aobList.Count;
            int current = 1;

            foreach (var pair in aobList)
            {
                Notify($"Injecting ({current}/{total})", "");

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
                Notify("Aimbot Body Applied [0]", "400");
            else
                Notify("Aimbot Body Injection Failed", "600");
        }

        public async void AimbotBody2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator isn't running", "800");
                return;
            }

            Notify("Applying Aimbot Body [1]", "");
            bruuuh.OpenProcess("HD-Player");

            bool anySuccess = false;
            int total = aobList.Count;
            int current = 1;

            foreach (var pair in aobList)
            {
                Notify($"Injecting ({current}/{total})", "");

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
                Notify("Aimbot Body Applied [1]", "400");
            else
                Notify("Aimbot Body Injection Failed", "600");
        }
    }
}
