using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BR_PREMIUM_5._0;
using Gma.System.MouseKeyHook;
using KeyAuth;
using Legit;

namespace BR_PREMIUM.strings
{
    public  class AimLegit
    {
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;
        private ParticleSystem particleSystem;
        private HOME _mainForm;

        public AimLegit(HOME mainForm)
        {
            _mainForm = mainForm;

        }

        private void ShowMessageBox(string message, string status, string imageKey)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.ShowMessageBox(message, status, imageKey);
            }));
        }






        // MAIN AIMBOT LEGIT PART


        private IKeyboardMouseEvents _globalHook;
        private bool _systemOn = false;
        private bool _hookActive = false;

        private static LEGITMEM AIMLEGIT = new LEGITMEM();
        string AimbotScan = "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ??";
        string headoffset = "0x70";
        string chestoffset = "0x6C";

        private Dictionary<long, int> OrginalValues1 = new Dictionary<long, int>();
        private Dictionary<long, int> OrginalValues2 = new Dictionary<long, int>();
        private Dictionary<long, int> OrginalValues3 = new Dictionary<long, int>();
        private Dictionary<long, int> OrgianlValues4 = new Dictionary<long, int>();

        public async void HookAimbotLegit()
        {
            var process = Process.GetProcessesByName("HD-Player").FirstOrDefault();
            if (process == null)
            {
                ShowMessageBox("Emulator Not Found !", "failed", "");
                return;
            }

            OrginalValues2.Clear();
            OrginalValues1.Clear();
            OrginalValues3.Clear();
            OrgianlValues4.Clear();
            ShowMessageBox("Applying..", "activating", "");


            Int64 readOffset = Convert.ToInt64(headoffset, 16);
            Int64 writeOffset = Convert.ToInt64(chestoffset, 16);
            Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
            AIMLEGIT.OpenProcess(proc);
            var result = await AIMLEGIT.AoBScan2(AimbotScan, true, true);
            if (result.Count() != 0)
            {
                foreach (var CurrentAddress in result)
                {
                    Int64 addressToSave = CurrentAddress + writeOffset;
                    var currentBytes = AIMLEGIT.readMemory(addressToSave.ToString("X"), sizeof(int));
                    int currentValue = BitConverter.ToInt32(currentBytes, 0); OrginalValues1[addressToSave] = currentValue;
                    Int64 addressToSave9 = CurrentAddress + readOffset;
                    var currentBytes9 = AIMLEGIT.readMemory(addressToSave9.ToString("X"), sizeof(int));
                    int currentValue9 = BitConverter.ToInt32(currentBytes9, 0); OrginalValues2[addressToSave9] = currentValue9;
                    Int64 headbytes = CurrentAddress + readOffset;
                    Int64 chestbytes = CurrentAddress + writeOffset;
                    var bytes = AIMLEGIT.readMemory(headbytes.ToString("X"), sizeof(int));
                    int Read = BitConverter.ToInt32(bytes, 0);
                    var bytes2 = AIMLEGIT.readMemory(chestbytes.ToString("X"), sizeof(int));
                    int Read2 = BitConverter.ToInt32(bytes2, 0);
                    AIMLEGIT.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                    AIMLEGIT.WriteMemory(headbytes.ToString("x"), "int", Read2.ToString());
                    Int64 addressToSave1 = CurrentAddress + writeOffset;
                    var currentBytes1 = AIMLEGIT.readMemory(addressToSave1.ToString("X"), sizeof(int));
                    int currentValue1 = BitConverter.ToInt32(currentBytes1, 0); OrginalValues3[addressToSave1] = currentValue1;
                    Int64 addressToSave19 = CurrentAddress + readOffset;
                    var currentBytes19 = AIMLEGIT.readMemory(addressToSave19.ToString("X"), sizeof(int));
                    int currentValue19 = BitConverter.ToInt32(currentBytes19, 0); OrgianlValues4[addressToSave19] = currentValue19;

                    ShowMessageBox("Aimbot Legit Hooked", "activated", "");
                }


            }
            else
            {
                ShowMessageBox("Error Occured ABL", "failed", "");
            }
        }

        public void Aimbotoff()
        {
            foreach (var entry in OrginalValues1)
            {
                AIMLEGIT.WriteMemory(entry.Key.ToString("x"), "int", entry.Value.ToString());
            }

            foreach (var entry in OrginalValues2)
            {
                AIMLEGIT.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());
            }

        }


        public void Aimboton()
        {
            foreach (var entry in OrginalValues3)
            {
                AIMLEGIT.WriteMemory(entry.Key.ToString("x"), "int", entry.Value.ToString());
            }

            foreach (var entry in OrgianlValues4)
            {
                AIMLEGIT.WriteMemory(entry.Key.ToString("x"), "int", entry.Value.ToString());
            }
        }
    }
}
