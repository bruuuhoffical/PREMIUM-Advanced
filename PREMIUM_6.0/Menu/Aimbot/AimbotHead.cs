using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using MemoryAim2;
using PREMIUM_6._0.Views;
using Red;
using System.Windows.Forms;


namespace PREMIUM_6._0.Menu.Aimbot
{
    public class AimbotHead
    {
        Bool Bool = new Bool();
        private Home _mainForm;
        public AimbotHead(Home mainForm)
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
        private string RED;
        public static MemRed RedLib = new MemRed();
        private static BRUUUHAIMBOTMEM bruuuhaimmem = new BRUUUHAIMBOTMEM();
        public static String PID;
        private int _processId;

        #region AimbotHead
        //string aimbotaob = "FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 A5 43";
        string aimbotaob = "FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 A5 43";
        string aimchest = "0xAA";
        string aimchest1 = "AA";
        string aimhead = "0xA6";
        string aimhead1 = "A6";
        long startRange = 0x0000000000010000;
        long stopRange = 0x00007ffffffeffff;
        bool writable = true;
        bool executable = true;
        private List<long> Type1Address = new List<long>();
        private List<long> Type2Address = new List<long>();
        private Dictionary<long, long> HeadValuesV11 = new Dictionary<long, long>();
        private Dictionary<long, long> HeadValuesV12 = new Dictionary<long, long>();
        private Dictionary<long, long> HeadValuesV13 = new Dictionary<long, long>();
        private Dictionary<long, long> HeadValuesV14 = new Dictionary<long, long>();
        

        public void EnableAimbotHead()
        {
            if (Bool.AimbotMem == 0)
            {
                EnableAimbot();
            }
            else if (Bool.AimbotMem == 1)
            {
                var processes = Process.GetProcessesByName("HD-Player");
                if (processes.Length == 0)
                {
                    Notify("Emulator Isnt Running", "800");
                }
                else
                {
                    EnableAimbot2();
                }
            }
        }
        public void DisableAimbotHead()
        {
            if (Bool.AimbotMem == 0)
            {
                DisableAimbot1();
            }
            else if (Bool.AimbotMem == 1)
            {
                DisableAimbot2();
            }
        }

        public void EnableAimbot()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                Notify("Emulator Isnt Running", "800");
                return;
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            Notify("Enabling Aimbot Head [0]", "");
            var task = RedLib.AoBScan(
                startRange,
                stopRange,
                aimbotaob,
                writable,
                executable
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                Notify("Aimbot Head Error [0]", "800");
                Bool.AimbotHead = false;
                return;
            }

            Type1Address = result.ToList();
            Notify("Load Complete [0]...", "");
            Notify("Applying Offsets [0]...", "");
            ApplyOffsets1();
            Bool.AimbotHead = true;
        }

        public void ApplyOffsets1()
        {
            int delay = Bool.AimbotDelay * 1000;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = delay;
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                timer.Dispose();
                foreach (long address in Type1Address)
                {
                    byte[] numArray = RedLib.ReadMemory((address + 170L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 166L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                Notify("Aimbot Head Enabled [0]", "400");
            };
            timer.Start();
        }


        public async void EnableAimbot2()
        {
            Notify("Enabling Aimbot [1]", "");
            long readOffset = Convert.ToInt64(aimchest1, 16);
            long writeOffset = Convert.ToInt64(aimhead1, 16);
            int delay = Bool.AimbotDelay * 1000;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            int proc = Process.GetProcessesByName("HD-Player")[0].Id;
            bruuuhaimmem.OpenProcess(proc);

            var result = await bruuuhaimmem.AoBScan2(aimbotaob, true, true);

            if (result.Count() != 0)
            {
                foreach (var CurrentAddress in result)
                {
                    Notify("Almost Done [1]","");
                    timer.Interval = delay;
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        long addressToSave = CurrentAddress + writeOffset;
                        long addressToSave9 = CurrentAddress + readOffset;

                        var currentBytes = bruuuhaimmem.readMemory(addressToSave.ToString("X"), sizeof(long));
                        HeadValuesV11[addressToSave] = BitConverter.ToInt64(currentBytes, 0);

                        var currentBytes9 = bruuuhaimmem.readMemory(addressToSave9.ToString("X"), sizeof(long));
                        HeadValuesV11[addressToSave9] = BitConverter.ToInt64(currentBytes9, 0);

                        bruuuhaimmem.WriteMemory(addressToSave9.ToString("X"), "long", HeadValuesV11[addressToSave].ToString());
                        bruuuhaimmem.WriteMemory(addressToSave.ToString("X"), "long", HeadValuesV11[addressToSave9].ToString());

                        var currentBytes19 = bruuuhaimmem.readMemory(addressToSave9.ToString("X"), sizeof(long));
                        HeadValuesV12[addressToSave9] = BitConverter.ToInt64(currentBytes19, 0);
                    };
                    timer.Start();
                }

                Notify("Aimbot Enabled [1]", "400");
            }
            else
            {
                Notify("Aimbot Failed [1]", "800");
            }
        }


        private void DisableAimbot1()
        {
            if (Type1Address == null || !Type1Address.Any())
            {
                Notify("Nothing to disable [0]", "");
                return;
            }

            Notify("Disabling Aimbot Head [0]", "");

            foreach (long address in Type1Address)
            {
                try
                {
                    byte[] originalBytes = RedLib.ReadMemory((address + 166L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 170L).ToString("X"), "int", BitConverter.ToInt32(originalBytes, 0).ToString());
                }
                catch (Exception ex)
                {
                    Notify($"Error while disabling: {ex.Message}", "600");
                }
            }

            Bool.AimbotHead = false;
            Notify("Aimbot Head Disabled [0]", "400");
        }

        private void DisableAimbot2()
        {
            Notify("Disabling Aimbot Head [1]", "");

            foreach (var pair in HeadValuesV11)
            {
                try
                {
                    long address = pair.Key;
                    long originalValue = pair.Value;
                    bruuuhaimmem.WriteMemory(address.ToString("X"), "long", originalValue.ToString());
                }
                catch (Exception ex)
                {
                    Notify($"Error restoring V11: {ex.Message}", "600");
                }
            }

            foreach (var pair in HeadValuesV12)
            {
                try
                {
                    long address = pair.Key;
                    long originalValue = pair.Value;
                    bruuuhaimmem.WriteMemory(address.ToString("X"), "long", originalValue.ToString());
                }
                catch (Exception ex)
                {
                    Notify($"Error restoring V12: {ex.Message}", "600");
                }
            }

            HeadValuesV11.Clear();
            HeadValuesV12.Clear();

            Bool.AimbotHead = false;
            Notify("Aimbot Head Disabled [1]", "400");
        }


        private void DelayTest()
        {
            int delay = Bool.AimbotDelay * 1000;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = delay;
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                timer.Dispose();
                Console.Beep();
            };

            timer.Start();
        }
        #endregion
    }
}
