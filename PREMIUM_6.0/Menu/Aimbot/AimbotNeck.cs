using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryAim2;
using PREMIUM_6._0.Views;
using Red;

namespace PREMIUM_6._0.Menu.Aimbot
{
    public class AimbotNeck
    {
        private Home _mainForm;
        public AimbotNeck(Home mainForm)
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

        Bool Bool = new Bool();

        private string RED;
        public static MemRed RedLib = new MemRed();
        private static BRUUUHAIMBOTMEM bruuuhaimmem = new BRUUUHAIMBOTMEM();
        public static String PID;
        private int _processId;

        #region AimbotNeck
        string aimbotaob = "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 A5 43";
        string aimchest = "0x80";
        string aimchest1 = "80";
        string aimNeck = "0X7C";
        string aimNeck1 = "7C";
        long startRange = 0x0000000000010000;
        long stopRange = 0x00007ffffffeffff;
        bool writable = true;
        bool executable = true;
        private List<long> Type1Address = new List<long>();
        private List<long> Type2Address = new List<long>();
        private Dictionary<long, long> NeckValuesV11 = new Dictionary<long, long>();
        private Dictionary<long, long> NeckValuesV12 = new Dictionary<long, long>();
        private Dictionary<long, long> NeckValuesV13 = new Dictionary<long, long>();
        private Dictionary<long, long> NeckValuesV14 = new Dictionary<long, long>();

        public void EnableAimbotNeck()
        {
            if (Bool.AimbotMem == 0)
            {
                EnableAimbot();
            }
            else if (Bool.AimbotMem > 0)
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
        public void DisableAimbotNeck()
        {
            if (Bool.AimbotMem == 0)
            {
                DisableAimbot0();
            }
            else
            {
                DisableAimbot1();
            }
        }

        public void EnableAimbot()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                Notify("Emulator Isnt Running", "800");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            Notify("Enabling Aimbot Neck [0]", "");
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
                Notify("Aimbot Neck Error [0]", "800");
                Bool.AimbotNeck = false;
                return;
            }

            Type1Address = result.ToList();
            Notify("Load Complete [0]...", "");
            Notify("Applying Offsets [0]...", "");
            ApplyOffsets1();
            Bool.AimbotNeck = true;
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
                    byte[] numArray = RedLib.ReadMemory((address + 128L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 124L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                Notify("Aimbot Neck V2 Enabled", "");
                Bool.AimbotNeck = true;
            };
            timer.Start();
        }


        public async void EnableAimbot2()
        {
            Notify("Enabling Aimbot [1]", "");
            long readOffset = Convert.ToInt64(aimchest1.Trim(), 16);
            long writeOffset = Convert.ToInt64(aimNeck1.Trim(), 16);
            int delay = Bool.AimbotDelay * 1000;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            int proc = Process.GetProcessesByName("HD-Player")[0].Id;
            bruuuhaimmem.OpenProcess(proc);

            var result = await bruuuhaimmem.AoBScan2(aimbotaob, true, true);

            if (result.Count() != 0)
            {
                foreach (var CurrentAddress in result)
                {
                    Notify("Almost Done [1]", "");
                    timer.Interval = delay;
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        long addressToSave = CurrentAddress + writeOffset;
                        long addressToSave9 = CurrentAddress + readOffset;

                        var currentBytes = bruuuhaimmem.readMemory(addressToSave.ToString("X"), sizeof(long));
                        NeckValuesV11[addressToSave] = BitConverter.ToInt64(currentBytes, 0);

                        var currentBytes9 = bruuuhaimmem.readMemory(addressToSave9.ToString("X"), sizeof(long));
                        NeckValuesV11[addressToSave9] = BitConverter.ToInt64(currentBytes9, 0);

                        bruuuhaimmem.WriteMemory(addressToSave9.ToString("X"), "long", NeckValuesV11[addressToSave].ToString());
                        bruuuhaimmem.WriteMemory(addressToSave.ToString("X"), "long", NeckValuesV11[addressToSave9].ToString());

                        var currentBytes19 = bruuuhaimmem.readMemory(addressToSave9.ToString("X"), sizeof(long));
                        NeckValuesV12[addressToSave9] = BitConverter.ToInt64(currentBytes19, 0);
                    };
                    timer.Start();
                }
                Bool.AimbotNeck = true;
                Notify("Aimbot Enabled [1]", "400");
            }
            else
            {
                Notify("Aimbot Failed [1]", "800");
                Bool.AimbotNeck = false;
            }
        }

        private void DisableAimbot0()
        {
            if (Type1Address == null || !Type1Address.Any())
            {
                Notify("No addresses found for Aimbot Neck [0]", "");
                return;
            }

            Notify("Disabling Aimbot Neck [0]", "");

            foreach (long address in Type1Address)
            {
                try
                {
                    byte[] originalBytes = RedLib.ReadMemory((address + 124L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 128L).ToString("X"), "int", BitConverter.ToInt32(originalBytes, 0).ToString());
                }
                catch (Exception ex)
                {
                    Notify($"Error restoring address [{address:X}]: {ex.Message}", "600");
                }
            }

            Bool.AimbotNeck = false;
            Notify("Aimbot Neck Disabled [0]", "400");
        }

        private void DisableAimbot1()
        {
            Notify("Disabling Aimbot Neck [1]", "");

            foreach (var kvp in NeckValuesV11)
            {
                try
                {
                    bruuuhaimmem.WriteMemory(kvp.Key.ToString("X"), "long", kvp.Value.ToString());
                }
                catch (Exception ex)
                {
                    Notify($"Restore V11 failed at [{kvp.Key:X}]: {ex.Message}", "600");
                }
            }

            foreach (var kvp in NeckValuesV12)
            {
                try
                {
                    bruuuhaimmem.WriteMemory(kvp.Key.ToString("X"), "long", kvp.Value.ToString());
                }
                catch (Exception ex)
                {
                    Notify($"Restore V12 failed at [{kvp.Key:X}]: {ex.Message}", "600");
                }
            }

            NeckValuesV11.Clear();
            NeckValuesV12.Clear();

            Bool.AimbotNeck = false;
            Notify("Aimbot Neck Disabled [1]", "400");
        }

        #endregion
    }
}
