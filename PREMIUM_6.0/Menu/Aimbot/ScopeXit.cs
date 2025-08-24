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
    public class ScopeXit
    {
        private Home _mainForm;

        public ScopeXit(Home mainForm)
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
            new KeyValuePair<string, string>("FB 8E 03 00 EE 90 03 00 EC 90 03 00 01 00 00 00 CD CC 8C 3F 33 33 93 3F 8F C2 F5 3C CD CC CC 3D 00 00 00 00 EC 51 B8 3D 00 00 80 3F 00 00 00 00 00 00 C8 42 00 00 A0 40 33 33 13 40 00 00 08 40 00 00 80 3F", "FB 8E 03 00 EE 90 03 00 EC 90 03 00 01 00 00 00 CD CC 8C 3F 33 33 93 3F 8F C2 F5 3C CD CC CC 3D 00 00 00 00 EC 51 B8 3D 00 00 80 3F 00 00 00 00 00 00 C8 42 00 00 A0 40 33 33 FF FF FF FF 08 40 00 00 80 3F"),
            new KeyValuePair<string, string>("FD 8E 03 00 EF 90 03 00 EB 90 03 00 02 00 00 00 00 00 C0 3F 33 33 93 3F 8F C2 F5 3C CD CC CC 3D 02 00 00 00 EC 51 B8 3D CD CC 4C 3F 00 00 00 00 00 00 A0 42 00 00 C0 3F 33 33 13 40 00 00 F0 3F 00 00 80 3F", "FD 8E 03 00 EF 90 03 00 EB 90 03 00 02 00 00 00 00 00 C0 3F 33 33 93 3F 8F C2 F5 3C CD CC CC 3D 02 00 00 00 EC 51 B8 3D CD CC 4C 3F 00 00 00 00 00 00 A0 42 00 00 C0 3F 33 33 FF FF FF FF F0 3F 00 00 80 3F"),
            new KeyValuePair<string, string>("FE 8E 03 00 F0 90 03 00 EC 90 03 00 04 00 00 00 00 00 20 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 04 00 00 00 29 5C 8F 3D 00 00 00 3F 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 D0 3F 00 00 80 3F", "FE 8E 03 00 F0 90 03 00 EC 90 03 00 04 00 00 00 00 00 20 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 04 00 00 00 29 5C 8F 3D 00 00 00 3F 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 FF FF FF FF D0 3F 00 00 80 3F")
        };

        public void EnableScopeXit()
        {
            if (Bool.OthersMem == 0)
            {
                ScopeXit1();
            }
            else if (Bool.OthersMem > 1)
            {
                ScopeXit2();
            }
        }

        private async void ScopeXit1()
        {
            Notify("Applying Scope Xit [0]", "");

            if (!memoryfast.SetProcess(new[] { "HD-Player" }))
            {
                Notify("Scope Xit Injection Failed", "600");
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
                Notify("Scope Xit Applied [0]", "400");
            else
                Notify("Scope Xit Injection Failed", "600");
        }

        public async void ScopeXit2()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator isn't running", "");
                return;
            }

            Notify("Applying Scope Xit [1]", "");
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
                Notify("Scope Xit Applied [1]", "400");
            else
                Notify("Scope Xit Injection Failed", "600");
        }
    }
}
