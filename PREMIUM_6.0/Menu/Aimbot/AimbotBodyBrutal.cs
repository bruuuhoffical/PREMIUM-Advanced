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
    public class AimbotBodyBrutal
    {
        private Home _mainForm;

        public AimbotBodyBrutal(Home mainForm)
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
            new KeyValuePair<string, string>("dc 52 39 bd 27 c1 8b 3c c0 d0 f8 b9", "db 42 32 3e 33 c1 18 3c c2 d0 f7 b3"),

            new KeyValuePair<string, string>("63 71 b0 bd 90 98 74 bb", "cd dc 79 44 90 98 74 bb"),

            new KeyValuePair<string, string>("7b f9 6c bd 58 34 09 bb b0 60 be ba", "cd dc 79 44 58 34 09 bb b0 60 be ba"),

            new KeyValuePair<string, string>("54 1b 87 bd 90 c6 d7 ba 80 54 99 b9", "cd dc 79 44 90 c6 d7 ba 80 54 99 b9"),

            new KeyValuePair<string, string>("71 02 87 bd 90 fd d7 ba 40 18 98 39", "cd dc 79 44 90 fd d7 ba 40 18 98 39"),

            new KeyValuePair<string, string>("cc f8 6c bd 40 d2 ce b9 58 64 be 3a", "cd dc 79 44 40 d2 ce b9 58 64 be 3a"),

            new KeyValuePair<string, string>("76 fc db bc 7c 5e 8b 3a 50 8b bb 3a", "cd dc 79 44 7c 5e 8b 3a 50 8b bb 3a"),

            new KeyValuePair<string, string>( "80 13 95 bc 30 ff 37 bb 00 fd 78 3b", "cd dc 79 44 30 ff 37 bb 00 fd 78 3b"),

            new KeyValuePair<string, string>("1f 93 db bc 90 bf 84 3a 20 a6 bb ba", "cd dc 79 44 90 bf 84 3a 20 a6 bb ba"),

            new KeyValuePair<string, string>("ef a3 00 be 40 b9 92 39 20 4e 07 ba", "cd dc 79 44 40 b9 92 39 20 4e 07 ba"),

            new KeyValuePair<string, string>("bc 19 fd bd b0 e3 a9 3a 80 42 23 b9", "42 e0 56 43 b0 e3 a9 3a 80 42 23 b9"),

            new KeyValuePair<string, string>("7d 1a 89 bd 50 26 9f 3b", "00 00 70 41 00 00 70 41"),

            new KeyValuePair<string, string>( "0e e4 f2 bd cd 99 04 bc", "00 00 70 41 00 00 70 41"),
        };

        public void EnableAimbotBodyBrutal()
        {
            if (Bool.OthersMem == 0)
            {
                AimbotBodyBrutal1();
            }
            else if (Bool.OthersMem > 1)
            {
                AimbotBodyBrutal2();
            }
        }

        private async void AimbotBodyBrutal1()
        {
            Notify("Applying Aimbot Body Strong [0]", "");

            if (!memoryfast.SetProcess(new[] { "HD-Player" }))
            {
                Notify("Aimbot Body Strong Injection Failed", "600");
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
                Notify("Aimbot Body Strong Applied [0]", "400");
            else
                Notify("Aimbot Body Strong Injection Failed", "600");
        }

        public async void AimbotBodyBrutal2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator isn't running", "");
                return;
            }

            Notify("Applying Aimbot Body Strong [1]", "");
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
                Notify("Aimbot Body Strong Applied [1]", "400");
            else
                Notify("Aimbot Body Strong Injection Failed", "600");
        }
    }
}
