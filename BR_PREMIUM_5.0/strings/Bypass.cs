using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BR_PREMIUM_5._0;
using Bruuuh;

namespace BR_PREMIUM.strings
{
    public class Bypass
    {
        private HOME _mainForm;
        private List<long> SecureBypass = new List<long>();
        Evelyn bruuuh = new Evelyn();
        public Bypass(HOME mainForm)
        {
            _mainForm = mainForm;

        }
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;




        public async void EnableBypass()
        {
            string search = "E3 1C 00 85 E5 00 70 94 E5 C0 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 4C 6D D7 EB FC 50 87 E5 00 70 94 E5 C4 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 45 6D D7 EB 00 51 87 E5 00 70 94 E5 C8 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 3E 6D D7 EB 94 03 9F E5 34 51 87 E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 06 00 00 0A 70 10 90 E5 00 00 51 E3 03 00 00 1A 65 12 D7 EB 6C 03 9F E5 00 00 9F E7 00 00 90 E5 5C 00 90 E5 6D 0F D0 E5 00 00 50 E3 49 00 00 0A 54 03 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 54 12 D7 EB 00 00 A0 E3 24 3A 73 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 1B 6D D7 EB 05 00 A0 E1 00 10 A0 E3 BC 3A 73 EB 00 50 94 E5 00 70 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 12 6D D7 EB 58 50 95 E5 00 00 55 E3 01 00 00 1A 00 00 A0 E3 0D 6D D7 EB 00 00 95 E5 BA 10 D0 E5 00 00 51 E3 BF 10 D0 15 40 00 11 13 01 00 00 0A D4 85 D6 EB 00 00 95 E5 D8 20 90 E5 DC 10 90 E5 05 00 A0 E1 32 FF 2F E1 00 50 A0 E1 A8 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 28 12 D7 EB 07 00 A0 E1 05 10 A0 E1 00 20 A0 E3 59 F9 03 EB 00 50 A0 E1 70 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 19 12 D7 EB 05 00 A0 E1 00 10 A0 E3 68 12 04 EB 00 70 94 E5 13 00 00 EA 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 DD 6C D7 EB 38 00 87 E2 00 10 A0 E3 17 F3 03 EB 00 50 A0 E1 14 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 01 12 D7 EB 05 00 A0 E1 00 10 A0 E3 53 12 04 EB 00 00 57 E3 5D 00 00 0A DC 11 9F E5 28 01 87 E5 00 70 94 E5 01 10 9F E7 00 00 91 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A F0 11 D7 EB 00 00 A0 E3 D1 11 04 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 B7 6C D7 EB 05 00 A0 E1 00 10 A0 E3 D8 11 04 EB 00 50 A0 E1 00 00 57 E3 01 00 00 1A 00 00 A0 E3 AF 6C D7 EB 24 51 87 E5 00 70 94 E5 1C 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A8 6C D7 EB 2C 51 87 E5 00 70 94 E5 20 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A1 6C D7 EB 08 00 A0 E1 30 51 87 E5 92 62 00 EB 00 50 A0 E1 00 00 55 E3 0E 00 00 1A 24 01 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A C3 11 D7 EB 00 00 A0 E3 19 12 04 EB 00 50 A0 E1 00 00 55 E3 05 00 00 0A 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 87 6C D7 EB 3C";
            string replace = "E3 1D 00 85 E5 00 70 94 E5 C0 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 4C 6D D7 EB FC 50 87 E5 00 70 94 E5 C4 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 45 6D D7 EB 00 51 87 E5 00 70 94 E5 C8 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 3E 6D D7 EB 94 03 9F E5 34 51 87 E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 06 00 00 0A 70 10 90 E5 00 00 51 E3 03 00 00 1A 65 12 D7 EB 6C 03 9F E5 00 00 9F E7 00 00 90 E5 5C 00 90 E5 6D 0F D0 E5 00 00 50 E3 49 00 00 0A 54 03 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 54 12 D7 EB 00 00 A0 E3 24 3A 73 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 1B 6D D7 EB 05 00 A0 E1 00 10 A0 E3 BC 3A 73 EB 00 50 94 E5 00 70 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 12 6D D7 EB 58 50 95 E5 00 00 55 E3 01 00 00 1A 00 00 A0 E3 0D 6D D7 EB 00 00 95 E5 BA 10 D0 E5 00 00 51 E3 BF 10 D0 15 40 00 11 13 01 00 00 0A D4 85 D6 EB 00 00 95 E5 D8 20 90 E5 DC 10 90 E5 05 00 A0 E1 32 FF 2F E1 00 50 A0 E1 A8 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 30 12 D7 EB 07 00 A0 E1 05 10 A0 E1 00 20 A0 E3 59 F9 03 EB 00 50 A0 E1 70 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 19 12 D7 EB 05 00 A0 E1 00 10 A0 E3 68 12 04 EB 00 70 94 E5 13 00 00 EA 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 DD 6C D7 EB 38 00 87 E2 00 10 A0 E3 17 F3 03 EB 00 50 A0 E1 14 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 01 12 D7 EB 05 00 A0 E1 00 10 A0 E3 53 12 04 EB 00 00 57 E3 5D 00 00 0A DC 11 9F E5 30 01 87 E5 00 70 94 E5 01 10 9F E7 00 00 91 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A F0 11 D7 EB 00 00 A0 E3 D1 11 04 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 B7 6C D7 EB 05 00 A0 E1 00 10 A0 E3 D8 11 04 EB 00 50 A0 E1 00 00 57 E3 01 00 00 1A 00 00 A0 E3 AF 6C D7 EB 24 51 87 E5 00 70 94 E5 1C 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A8 6C D7 EB 2C 51 87 E5 00 70 94 E5 20 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A1 6C D7 EB 08 00 A0 E1 30 51 87 E5 92 62 00 EB 00 50 A0 E1 00 00 55 E3 0E 00 00 1A 24 01 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A C3 11 D7 EB 00 00 A0 E3 19 12 04 EB 00 50 A0 E1 00 00 55 E3 05 00 00 0A 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 87 6C D7 EB 00";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Bypassing Main....", "failed", "");
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
                    ShowMessageBox("All Bypass Success", "failed", "");
                }
                else
                {
                    ShowMessageBox("Error", "failed", "");
                }
            }
        }
        public async void DisableBypass()
        {
            string search = "E3 1D 00 85 E5 00 70 94 E5 C0 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 4C 6D D7 EB FC 50 87 E5 00 70 94 E5 C4 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 45 6D D7 EB 00 51 87 E5 00 70 94 E5 C8 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 3E 6D D7 EB 94 03 9F E5 34 51 87 E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 06 00 00 0A 70 10 90 E5 00 00 51 E3 03 00 00 1A 65 12 D7 EB 6C 03 9F E5 00 00 9F E7 00 00 90 E5 5C 00 90 E5 6D 0F D0 E5 00 00 50 E3 49 00 00 0A 54 03 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 54 12 D7 EB 00 00 A0 E3 24 3A 73 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 1B 6D D7 EB 05 00 A0 E1 00 10 A0 E3 BC 3A 73 EB 00 50 94 E5 00 70 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 12 6D D7 EB 58 50 95 E5 00 00 55 E3 01 00 00 1A 00 00 A0 E3 0D 6D D7 EB 00 00 95 E5 BA 10 D0 E5 00 00 51 E3 BF 10 D0 15 40 00 11 13 01 00 00 0A D4 85 D6 EB 00 00 95 E5 D8 20 90 E5 DC 10 90 E5 05 00 A0 E1 32 FF 2F E1 00 50 A0 E1 A8 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 30 12 D7 EB 07 00 A0 E1 05 10 A0 E1 00 20 A0 E3 59 F9 03 EB 00 50 A0 E1 70 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 19 12 D7 EB 05 00 A0 E1 00 10 A0 E3 68 12 04 EB 00 70 94 E5 13 00 00 EA 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 DD 6C D7 EB 38 00 87 E2 00 10 A0 E3 17 F3 03 EB 00 50 A0 E1 14 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 01 12 D7 EB 05 00 A0 E1 00 10 A0 E3 53 12 04 EB 00 00 57 E3 5D 00 00 0A DC 11 9F E5 30 01 87 E5 00 70 94 E5 01 10 9F E7 00 00 91 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A F0 11 D7 EB 00 00 A0 E3 D1 11 04 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 B7 6C D7 EB 05 00 A0 E1 00 10 A0 E3 D8 11 04 EB 00 50 A0 E1 00 00 57 E3 01 00 00 1A 00 00 A0 E3 AF 6C D7 EB 24 51 87 E5 00 70 94 E5 1C 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A8 6C D7 EB 2C 51 87 E5 00 70 94 E5 20 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A1 6C D7 EB 08 00 A0 E1 30 51 87 E5 92 62 00 EB 00 50 A0 E1 00 00 55 E3 0E 00 00 1A 24 01 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A C3 11 D7 EB 00 00 A0 E3 19 12 04 EB 00 50 A0 E1 00 00 55 E3 05 00 00 0A 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 87 6C D7 EB 00";
            string replace = "E3 1C 00 85 E5 00 70 94 E5 C0 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 4C 6D D7 EB FC 50 87 E5 00 70 94 E5 C4 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 45 6D D7 EB 00 51 87 E5 00 70 94 E5 C8 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 3E 6D D7 EB 94 03 9F E5 34 51 87 E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 06 00 00 0A 70 10 90 E5 00 00 51 E3 03 00 00 1A 65 12 D7 EB 6C 03 9F E5 00 00 9F E7 00 00 90 E5 5C 00 90 E5 6D 0F D0 E5 00 00 50 E3 49 00 00 0A 54 03 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 54 12 D7 EB 00 00 A0 E3 24 3A 73 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 1B 6D D7 EB 05 00 A0 E1 00 10 A0 E3 BC 3A 73 EB 00 50 94 E5 00 70 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 12 6D D7 EB 58 50 95 E5 00 00 55 E3 01 00 00 1A 00 00 A0 E3 0D 6D D7 EB 00 00 95 E5 BA 10 D0 E5 00 00 51 E3 BF 10 D0 15 40 00 11 13 01 00 00 0A D4 85 D6 EB 00 00 95 E5 D8 20 90 E5 DC 10 90 E5 05 00 A0 E1 32 FF 2F E1 00 50 A0 E1 A8 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 28 12 D7 EB 07 00 A0 E1 05 10 A0 E1 00 20 A0 E3 59 F9 03 EB 00 50 A0 E1 70 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 19 12 D7 EB 05 00 A0 E1 00 10 A0 E3 68 12 04 EB 00 70 94 E5 13 00 00 EA 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 DD 6C D7 EB 38 00 87 E2 00 10 A0 E3 17 F3 03 EB 00 50 A0 E1 14 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 01 12 D7 EB 05 00 A0 E1 00 10 A0 E3 53 12 04 EB 00 00 57 E3 5D 00 00 0A DC 11 9F E5 28 01 87 E5 00 70 94 E5 01 10 9F E7 00 00 91 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A F0 11 D7 EB 00 00 A0 E3 D1 11 04 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 B7 6C D7 EB 05 00 A0 E1 00 10 A0 E3 D8 11 04 EB 00 50 A0 E1 00 00 57 E3 01 00 00 1A 00 00 A0 E3 AF 6C D7 EB 24 51 87 E5 00 70 94 E5 1C 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A8 6C D7 EB 2C 51 87 E5 00 70 94 E5 20 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A1 6C D7 EB 08 00 A0 E1 30 51 87 E5 92 62 00 EB 00 50 A0 E1 00 00 55 E3 0E 00 00 1A 24 01 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A C3 11 D7 EB 00 00 A0 E3 19 12 04 EB 00 50 A0 E1 00 00 55 E3 05 00 00 0A 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 87 6C D7 EB 3C";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Hold on....", "failed", "");
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
                    ShowMessageBox("Restored", "failed", "");
                }
                else
                {
                    ShowMessageBox("Bypass Error", "failed", "");
                }
            }
        }

        #region SecureBypass

        public async Task ScanSecureBypass()
        {
            string searchA = "42 61 6E 6E 65 64 50 6C 61 79 65 72 41 70 70 65 61 6C";
            string searchB = "4D 61 74 63 68 4D 61 6B 69 6E 67 52 61 6E 6B 69 6E 67 42 61 6E 6E 65 64 4E 74 66";
            string searchC = "41 4E 54 49 48 41 43 4B 5F 4D 41 54 43 48 5F 42 41 4E 4E 45 44 31";
            string searchD = "41 4E 54 49 48 41 43 4B 5F 4D 41 54 43 48 5F 42 41 4E 4E 45 44 32";
            string searchE = "41 4E 54 49 48 41 43 4B 5F 4D 41 54 43 48 5F 42 41 4E 4E 45 44 33";
            string searchF = "41 43 43 4F 55 4E 54 5F 42 41 4E 4E 45 44";

            List<string> searchPatterns = new List<string> { searchA, searchB, searchC, searchD, searchE, searchF };

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Please Wait...", "failed", "");
            List<long> allFoundAddresses = new List<long>();

            foreach (var searchPattern in searchPatterns)
            {
                IEnumerable<long> foundAddresses = await bruuuh.AoBScan(searchPattern, writable: true);

                allFoundAddresses.AddRange(foundAddresses);
            }

            if (allFoundAddresses.Count > 0)
            {
                SecureBypass = allFoundAddresses.Distinct().ToList();
                ShowMessageBox("Step 1 Done", "failed", "");
                EnableSecureBypass();
            }
            else
            {
                ShowMessageBox("Step 1 Error", "failed", "");
                return;
            }
        }


        public void EnableSecureBypass()
        {
            string replaceA = "42 61 6E 6E 65 00 50 6C 61 79 65 72 00 70 70 00 00 6C";
            string replaceB = "4D 61 74 00 00 4D 61 00 00 6E 67 52 61 6E 6B 69 6E 67 42 61 6E 6E 65 64 4E 74 66";
            string replaceC = "41 4E 54 49 48 00 00 4B 5F 4D 41 54 43 48 5F 42 41 4E 4E 00 00 31";
            string replaceD = "41 4E 54 49 48 41 00 00 5F 4D 41 54 43 48 5F 42 41 4E 4E 45 00 32";
            string replaceE = "41 4E 54 49 48 41 00 00 5F 4D 41 54 43 48 5F 42 41 4E 4E 45 00 33";
            string replaceF = "41 43 43 4F 00 00 54 00 00 41 4E 4E 45 44";

            List<string> replacements = new List<string> { replaceA, replaceB, replaceC, replaceD, replaceE, replaceF };

            if (SecureBypass.Count > 0)
            {
                bool success = false;
                ShowMessageBox("Step 2, Wait...", "failed", "");

                foreach (var address in SecureBypass)
                {
                    foreach (var replace in replacements)
                    {
                        bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                        if (writeResult)
                        {
                            success = true;
                        }
                    }
                }

                if (success)
                {
                    ShowMessageBox("Step 2 Done", "failed", "");
                    EnableBypass();
                }
                else
                {

                }
            }
            else
            {

            }
        }
        public void ResetSecureBypass()
        {
            string replaceA = "42 61 6E 6E 65 64 50 6C 61 79 65 72 41 70 70 65 61 6C";
            string replaceB = "4D 61 74 63 68 4D 61 6B 69 6E 67 52 61 6E 6B 69 6E 67 42 61 6E 6E 65 64 4E 74 66";
            string replaceC = "41 4E 54 49 48 41 43 4B 5F 4D 41 54 43 48 5F 42 41 4E 4E 45 44 31";
            string replaceD = "41 4E 54 49 48 41 43 4B 5F 4D 41 54 43 48 5F 42 41 4E 4E 45 44 32";
            string replaceE = "41 4E 54 49 48 41 43 4B 5F 4D 41 54 43 48 5F 42 41 4E 4E 45 44 33";
            string replaceF = "41 43 43 4F 55 4E 54 5F 42 41 4E 4E 45 44";

            List<string> replacements = new List<string> { replaceA, replaceB, replaceC, replaceD, replaceE, replaceF };

            if (SecureBypass.Count > 0)
            {
                bool success = false;

                foreach (var address in SecureBypass)
                {
                    foreach (var replace in replacements)
                    {
                        bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                        if (writeResult)
                        {
                            success = true;
                        }
                    }
                }

                if (success)
                {

                }
                else
                {

                }
            }
            else
            {

            }
        }

        private void ShowMessageBox(string message, string status, string imageKey)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.ShowMessageBox(message, status, imageKey);
            }));
        }

        #endregion
    }
}
