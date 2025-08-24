using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AIMBOTBYTANZIM;
using Bruuuh;
using Red;
using MemoryAim2;
using static Guna.UI2.WinForms.Suite.Descriptions;
//using FF;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace BR_PREMIUM_5._0.strings
{
    public class Aimbots
    {
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;
        private ParticleSystem particleSystem;
        private string RED;

        public static MemRed RedLib = new MemRed();
        public static String PID;
        Evelyn bruuuh = new Evelyn();

        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AIMBOT DATA.txt");
        private readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AIMBOT DATA .txt");
        private Thread monitorThread;
        private bool isMonitoring = true;

        private HOME _mainForm;
        public List<long> foundAddresses { get; private set; } = new List<long>();
        private int _processId;
        private List<long> AimbotHeadAddress = new List<long>();
        private List<long> AimbotHeadv2Address = new List<long>();
        private List<long> AimbotDragAddress = new List<long>();
        private List<long> AimbotNeckAddress = new List<long>();
        private List<long> AimbotExtraAddress = new List<long>();
        private List<long> AimbotBody = new List<long>();
        private List<long> AimbotValue = new List<long>();
        private List<long> AimbotDValue = new List<long>();
        private static BRUUUHAIMBOTMEM bruuuhaimbot = new BRUUUHAIMBOTMEM();


        private static BRUUUHAIM magi = new BRUUUHAIM();
        private List<long> scannedAddresses = new List<long>();
        private readonly string aobPattern = "00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";

        private readonly string replaceValueTrue = "00 00 00 00 00 00 D1 40 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";

        private readonly string replaceValueFalse = "00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";

        string AimbotScan = "A5 43 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 80 BF";
        string headoffset = "0x2A";
        string chestoffset = "0x26";

        private Dictionary<long, int> OrginalValues1 = new Dictionary<long, int>();
        private Dictionary<long, int> OrginalValues2 = new Dictionary<long, int>();
        private Dictionary<long, int> OrginalValues3 = new Dictionary<long, int>();
        private Dictionary<long, int> OrginalValues4 = new Dictionary<long, int>();


        //private static FAHIM PLAYBOX = new FAHIM();
        private string aimAOB = "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF ?? ?? ?? ?? 00 00 00 00 00 00 80 BF";
        private string readFORhead = "0x70";
        private string write = "0x6c";
        private Dictionary<long, int> originalvalues = new Dictionary<long, int>();
        private Dictionary<long, int> originallvalues = new Dictionary<long, int>();
        private Dictionary<long, int> originalvalues2 = new Dictionary<long, int>();
        private Dictionary<long, int> originallvalues2 = new Dictionary<long, int>();
        public Aimbots(HOME mainForm)
        {
            _mainForm = mainForm;

        }



        public bool scanaimheadv1 = false;
        public bool onaimheadv1 = false;
        public bool scanaimheadv2 = false;
        public bool onaimheadv2 = false;
        public bool scanaimdrag = false;
        public bool onaimdrag = false;
        public bool scanaimneck = false;
        public bool onaimneck = false;
        public bool scanaimbody = false;
        public bool onaimbody = false;



        #region Aimbots










        #region AimbotHead

        public void LoadAimbotHead()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                //throw new InvalidOperationException("Emulator not running.");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                0x0000000000010000,
                0x00007ffffffeffff,
                //65536L,
                //140737488289791L,
                "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }

            AimbotHeadAddress = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimheadv1 = true;
        }
        public void EnableAimbotHead()
        {
            #region default
            //if (AimbotAddress == null || !AimbotAddress.Any())
            //{
            //    ShowMessageBox("Error", "Enable Failed", "Run the scan first.");
            //    return;
            //}
            #endregion
            if (scanaimheadv1 == false)
            {
                ShowMessageBox("Aimbot Head Isnt Loaded", "failed", "");
            }
            else
            {
                foreach (long address in AimbotHeadAddress)
                {
                    byte[] numArray = RedLib.ReadMemory((address + 156L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 108L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                ShowMessageBox("Aimbot Head Enabled", "", "");
                onaimheadv1 = true;
            }
        }
        public void DisableAimbotHead()
        {
            if (onaimheadv1 == false)
            {
                ShowMessageBox("Aimbot Isnt Enabled", "failed", "");
            }
            else
            {

                foreach (long address in AimbotHeadAddress)
                {
                    byte[] numArray = RedLib.ReadMemory((address + 108L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 156L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }

                ShowMessageBox("Aimbot Enabled", "", "");
            }
            
        }

        #endregion
        
        
        
        
        
        #region AimbotHeadV2

        public void LoadAimbotHeadV2()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                //0x0000000000010000,
                //0x00007ffffffeffff,
                65536L,
                140737488289791L,
                "00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }

            AimbotHeadv2Address = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimheadv2 = true;
        }
        public void EnableAimbotHeadV2()
        {
            #region default
            //if (AimbotAddress == null || !AimbotAddress.Any())
            //{
            //    ShowMessageBox("Error", "Enable Failed", "Run the scan first.");
            //    return;
            //}
            #endregion
            if (scanaimheadv2 == false)
            {
                ShowMessageBox("Aimbot V2 Isnt Loaded", "failed", "");
            }
            else
            {
                foreach (long address in AimbotHeadv2Address)
                {
                    byte[] numArray = RedLib.ReadMemory((address + 0x5c).ToString("X"), 4);
                    RedLib.WriteMemory((address + 0x28).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                ShowMessageBox("Aimbot Head V2 Enabled", "", "");
                onaimheadv2 = true;
            }
        }
        public void DisableAimbotHeadV2()
        {
            if (onaimheadv2 == false)
            {
                ShowMessageBox("Aimbot Isnt Enabled", "failed", "");
            }
            else
            {

                foreach (long address in AimbotHeadv2Address)
                {
                    byte[] numArray = RedLib.ReadMemory((address + 0x28).ToString("X"), 4);
                    RedLib.WriteMemory((address + 0x5c).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }

                ShowMessageBox("Aimbot Head V2 Enabled", "", "");
            }
            
        }

        #endregion
        
        
        
        
        #region AimbotDrag

        public void LoadAimbotDrag()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                0x0000000000010000,
                0x00007ffffffeffff,
                "00 00 A5 43 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }

            AimbotDragAddress = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimdrag = true;
        }
        public void EnableAimbotDrag()
        {
            #region default
            //if (AimbotAddress == null || !AimbotAddress.Any())
            //{
            //    ShowMessageBox("Error", "Enable Failed", "Run the scan first.");
            //    return;
            //}
            #endregion
            if (scanaimdrag == false)
            {
                ShowMessageBox("Aimbot Drag Isnt Loaded", "failed", "");
            }
            else
            {
                foreach (long address in AimbotDragAddress)
                {
                    byte[] numArray = RedLib.ReadMemory((address + 92L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 40L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                ShowMessageBox("Aimbot Drag Enabled", "", "");
                onaimdrag = true;
            }
        }
        public void DisableAimbotDrag()
        {
            if (onaimdrag == false)
            {
                ShowMessageBox("Aimbot Drag Isnt Enabled", "failed", "");
            }
            else
            {

                foreach (long address in AimbotDragAddress)
                {
                    byte[] numArray = RedLib.ReadMemory((address + 40L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 92l).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }

                ShowMessageBox("Aimbot Enabled", "", "");
            }
            
        }

        #endregion
        
        
        
        #region AimbotNeck

        public void LoadAimbotNeck()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                0x0000000000010000,
                0x00007ffffffeffff,
                "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }

            AimbotNeckAddress = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimneck = true;
        }
        public void LoadAimbotExtra()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                0x0000000000010000,
                0x00007ffffffeffff,
                "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF ?? ?? ?? ?? 00 00 00 00 00 00 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }

            AimbotExtraAddress = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimneck = true;
        }
        public void EnableAimbotNeck()
        {
            #region default
            //if (AimbotAddress == null || !AimbotAddress.Any())
            //{
            //    ShowMessageBox("Error", "Enable Failed", "Run the scan first.");
            //    return;
            //}
            #endregion
            if (scanaimneck == false)
            {
                LoadAimbotNeck();
                ShowMessageBox("Aimbot Isnt Loaded", "failed", "");
            }
            else
            {
                foreach (long address in AimbotNeckAddress)
                {
                    byte[] numArray = RedLib.ReadMemory((address + 0x9C).ToString("X"), 4);
                    byte[] numArray1 = RedLib.ReadMemory((address + 0x70).ToString("X"), 4);
                    byte[] numArray2 = RedLib.ReadMemory((address + 0xa0).ToString("X"), 4);
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray1, 0).ToString());
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                ShowMessageBox("Aimbot Enabled", "", "");
                onaimneck = true;
            }
        }
        public void DisableAimbotNeck()
        {
            if (onaimneck == false)
            {
                ShowMessageBox("Aimbot Isnt Enabled", "failed", "");
            }
            else
            {

                foreach (long address in AimbotNeckAddress)
                {
                    byte[] numArray = RedLib.ReadMemory((address + 0x9C).ToString("X"), 4);
                    byte[] numArray1 = RedLib.ReadMemory((address + 0x70).ToString("X"), 4);
                    byte[] numArray2 = RedLib.ReadMemory((address + 0xa0).ToString("X"), 4);
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray1, 0).ToString());
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }

                ShowMessageBox("Aimbot Disabled", "", "");
            }
            
        }

        #endregion





        #region AimbotBody

        public async Task ScanAimbotbody()
        {
            string searchA = "DC 52 39 BD 27 C1 8B 3C C0 D0 F8 B9";
            string searchB = "63 71 B0 BD 90 98 74 BB";
            string searchC = "7B F9 6C BD 58 34 09 BB B0 60 BE BA";
            string searchD = "54 1B 87 BD 90 C6 D7 BA 80 54 99 B9";
            string searchE = "71 02 87 BD 90 FD D7 BA 40 18 98 39";
            string searchF = "CC F8 6C BD 40 D2 CE B9 58 64 BE 3A";
            string searchG = "76 FC DB BC 7C 5E 8B 3A 50 8B BB 3A";
            string searchH = "80 13 95 BC 30 FF 37 BB 00 FD 78 3B";
            string searchI = "1F 93 DB BC 90 BF 84 3A 20 A6 BB BA";
            string searchJ = "EF A3 00 BE 40 B9 92 39 20 4E 07 BA";
            string searchK = "BC 19 FD BD B0 E3 A9 3A 80 42 23 B9";
            string searchL = "72 4B 72 3D 72 83 05 3E 00 00 00 00 18 04 27 BD 00 84 A7 37 00 00 80 B1";
            string searchM = "7D 1A 89 BD 50 26 9F 3B";

            List<string> searchPatterns = new List<string>
            {
                searchA, searchB, searchC, searchD, searchE, searchF,
                searchG, searchH, searchI, searchJ, searchK, searchL, searchM
            };


            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            List<long> allFoundAddresses = new List<long>();

            foreach (var searchPattern in searchPatterns)
            {
                IEnumerable<long> foundAddresses = await bruuuh.AoBScan(searchPattern, writable: true);

                allFoundAddresses.AddRange(foundAddresses);
            }

            if (allFoundAddresses.Count > 0)
            {
                AimbotBody = allFoundAddresses.Distinct().ToList();
                ShowMessageBox("Scan Success", "", "");
                scanaimbody = true;
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                    scanaimbody = false;
                }
            }
        }


        public void EnableAimbotBody()
        {
            string replaceA = "00 00 00 3E 0A D7 23 3D D2 A5 F9 BC";
            string replaceB = "CD DC 79 44 90 98 74 BB";
            string replaceC = "CD DC 79 44 58 34 09 BB B0 60 BE BA";
            string replaceD = "CD DC 79 44 90 C6 D7 BA 80 54 99 B9";
            string replaceE = "CD DC 79 44 90 FD D7 BA 40 18 98 39";
            string replaceF = "CD DC 79 44 40 D2 CE B9 58 64 BE 3A";
            string replaceG = "CD DC 79 44 7C 5E 8B 3A 50 8B BB 3A";
            string replaceH = "CD DC 79 44 30 FF 37 BB 00 FD 78 3B";
            string replaceI = "CD DC 79 44 90 BF 84 3A 20 A6 BB BA";
            string replaceJ = "CD DC 79 44 40 B9 92 39 20 4E 07 BA";
            string replaceK = "42 E0 56 43 B0 E3 A9 3A 80 42 23 B9";
            string replaceL = "72 4B 72 3D 72 83 05 3E 00 00 00 00 23 00 00 3D 00 00 00 3D 0A D7 3E BC";
            string replaceM = "00 00 70 41 00 00 70 41";


            List<string> replacements = new List<string>
            {
                 replaceA, replaceB, replaceC, replaceD, replaceE, replaceF,
                 replaceG, replaceH, replaceI, replaceJ, replaceK, replaceL, replaceM
            };

            if (AimbotBody.Count > 0)
            {
                bool success = false;

                foreach (var address in AimbotBody)
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
                    if (_mainForm.IsCheckboxChecked())
                    {
                        
                    }
                    else
                    {
                        ShowMessageBox("Aimbot Body Enabled", "", "");
                        onaimbody = true;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {
                        
                    }
                    else
                    {
                        ShowMessageBox("AIB Error", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {
                    
                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public void ResetAimbotBody()
        {
            string replaceA = "DC 52 39 BD 27 C1 8B 3C C0 D0 F8 B9";
            string replaceB = "63 71 B0 BD 90 98 74 BB";
            string replaceC = "7B F9 6C BD 58 34 09 BB B0 60 BE BA";
            string replaceD = "54 1B 87 BD 90 C6 D7 BA 80 54 99 B9";
            string replaceE = "71 02 87 BD 90 FD D7 BA 40 18 98 39";
            string replaceF = "CC F8 6C BD 40 D2 CE B9 58 64 BE 3A";
            string replaceG = "76 FC DB BC 7C 5E 8B 3A 50 8B BB 3A";
            string replaceH = "80 13 95 BC 30 FF 37 BB 00 FD 78 3B";
            string replaceI = "1F 93 DB BC 90 BF 84 3A 20 A6 BB BA";
            string replaceJ = "EF A3 00 BE 40 B9 92 39 20 4E 07 BA";
            string replaceK = "BC 19 FD BD B0 E3 A9 3A 80 42 23 B9";
            string replaceL = "72 4B 72 3D 72 83 05 3E 00 00 00 00 18 04 27 BD 00 84 A7 37 00 00 80 B1";
            string replaceM = "7D 1A 89 BD 50 26 9F 3B";


            List<string> replacements = new List<string>
            {
                 replaceA, replaceB, replaceC, replaceD, replaceE, replaceF,
                 replaceG, replaceH, replaceI, replaceJ, replaceK, replaceL, replaceM
            };


            if (AimbotBody.Count > 0)
            {
                bool success = false;

                foreach (var address in AimbotBody)
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
                    if (_mainForm.IsCheckboxChecked())
                    {
                        
                    }
                    else
                    {
                        ShowMessageBox("Aimbot Body Disabled", "", "");
                        onaimbody = false;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {
                        
                    }
                    else
                    {
                        ShowMessageBox("AIB Error", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {
                    
                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }



        #endregion

        #region AimFov
        public async void EnableAimFov()
        {
            string search = "00 00 20 42 00 00 40 40 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
            string replace = "00 00 20 42 00 00 FF FF 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
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
                    ShowMessageBox("Aim Fov Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableAimFov()
        {
            string search = "00 00 20 42 00 00 FF FF 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
            string replace = "00 00 20 42 00 00 40 40 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
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
                    ShowMessageBox("Aimfov Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion




        #region Aimbot+Anticheat
        public void AimbotOff()
        {
            foreach (var entry in OrginalValues1)
            {
                magi.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());
            }
            foreach (var entry in OrginalValues2)
            {
                magi.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());
            }
        }
        public void AimbotOn()
        {
            foreach (var entry in OrginalValues3)
            {
                magi.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());

            }
            foreach (var entry in OrginalValues4)
            {
                magi.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());
            }
        }
        public async void EnableAimbotSecurity()
        {
            ShowMessageBox("Aimbot Secured Activating", "", "");
            OrginalValues1.Clear();
            OrginalValues2.Clear();
            OrginalValues3.Clear();
            OrginalValues4.Clear();

            Int64 readoffset = Convert.ToInt64(headoffset, 16);
            Int64 writeoffset = Convert.ToInt64(chestoffset, 16);
            Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
            magi.OpenProcess(proc);
            var result = await magi.AoBScan2(AimbotScan, true, true);
            if (result.Count() != 0)
            {
                foreach (var CurrentAddress in result)
                {
                    Int64 addressToSave = CurrentAddress + writeoffset;
                    var currentBytes = magi.readMemory(addressToSave.ToString("X"), sizeof(int));
                    int currentValue = BitConverter.ToInt32(currentBytes, 0); OrginalValues1[addressToSave] = currentValue;
                    Int64 addressToSave9 = CurrentAddress + readoffset;
                    var currentBytes9 = magi.readMemory(addressToSave9.ToString("X"), sizeof(int));
                    int currentValue9 = BitConverter.ToInt32(currentBytes9, 0); OrginalValues2[addressToSave9] = currentValue9;
                    Int64 headbytes = CurrentAddress + readoffset;
                    Int64 chestbytes = CurrentAddress + writeoffset;
                    var bytes = magi.readMemory(headbytes.ToString("X"), sizeof(int));
                    int Read = BitConverter.ToInt32(bytes, 0);
                    var bytes2 = magi.readMemory(chestbytes.ToString("X"), sizeof(int));
                    int Read2 = BitConverter.ToInt32(bytes2, 0);
                    magi.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                    magi.WriteMemory(headbytes.ToString("X"), "int", Read2.ToString());
                    Int64 addressToSave1 = CurrentAddress + writeoffset;
                    var currentBytes1 = magi.readMemory(addressToSave1.ToString("X"), sizeof(int));
                    int currentValue1 = BitConverter.ToInt32(currentBytes1, 0); OrginalValues1[addressToSave1] = currentValue1;
                    Int64 addressToSave19 = CurrentAddress + readoffset;
                    var currentBytes19 = magi.readMemory(addressToSave19.ToString("X"), sizeof(int));
                    int currentValue19 = BitConverter.ToInt32(currentBytes19, 0); OrginalValues4[addressToSave19] = currentValue19;
                    ShowMessageBox("Aimbot Secured Activated", "", "");


                }

            }
            else
            {
                ShowMessageBox("Error ASC", "", "");
            }
        }

        #endregion




        #endregion

        private void CreateOrResetFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                File.WriteAllText(filePath, "{Function = false;}");


                FileSecurity fileSecurity = new FileSecurity();
                fileSecurity.SetAccessRule(new FileSystemAccessRule(
                    "Everyone",
                    FileSystemRights.FullControl,
                    AccessControlType.Allow));

                File.SetAccessControl(filePath, fileSecurity);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating/resetting file: {ex.Message}");
            }
        }


        //private void StartMonitoring()
        //{
        //    monitorThread = new Thread(() =>
        //    {
        //        while (isMonitoring)
        //        {
        //            try
        //            {
        //                if (File.Exists(filePath))
        //                {
        //                    string content;


        //                    using (var reader = new StreamReader(filePath))
        //                    {
        //                        content = reader.ReadToEnd().Trim();
        //                    }


        //                    if (content.Equals("{Function = true;}"))
        //                    {
        //                        Invoke(new Action(() => testvoid()));
        //                    }
        //                    else if (content.Equals("{Function = false;}"))
        //                    {
        //                        Invoke(new Action(() => off()));
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Invoke(new Action(() => MessageBox.Show($"Error reading file: {ex.Message}")));
        //            }

        //            Thread.Sleep(3000);
        //        }
        //    });

        //    monitorThread.IsBackground = true;
        //    monitorThread.Start();
        //}

        private bool trigger = true;
        private bool triggeroff = false;

        public void off()
        {
            if (triggeroff)
            {
                trigger = true;
                triggeroff = false;
                MessageBox.Show("Function off!");
            }
        }

        public void testvoid()
        {
            if (trigger)
            {
                trigger = false;
                triggeroff = true;
                MessageBox.Show("Triggered!");
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isMonitoring = false;
            monitorThread?.Join();
        }


        //public async void EnableAimbotCrazy()
        //{
        //    originalvalues.Clear();
        //    originallvalues.Clear();
        //    originalvalues2.Clear();
        //    originallvalues2.Clear();
        //    //label1.Text = "Applying...";
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();

        //    Int64 readOffset = Convert.ToInt64(readFORhead, 16);
        //    Int64 writeOffset = Convert.ToInt64(write, 16);
        //    Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
        //    PLAYBOX.OpenProcess(proc);

        //    var result = await PLAYBOX.AoBScan2(aimAOB, true, true);


        //    List<long> resultList = result.ToList();


        //    using (StreamWriter writer = new StreamWriter(logFilePath, false))
        //    {
        //        writer.WriteLine($"Total Patterns Found: {resultList.Count}");
        //        writer.WriteLine("=========================================");

        //        if (resultList.Count != 0)
        //        {
        //            foreach (var CurrentAddress in resultList)
        //            {
        //                writer.WriteLine($"=========================================");
        //                writer.WriteLine($"Pattern Found at Address: 0x{CurrentAddress:X}");
        //                writer.WriteLine("=========================================");
        //                writer.WriteLine($"Full Array of Bytes:");
        //                writer.WriteLine(aimAOB);
        //                writer.WriteLine();

        //                writer.WriteLine("Replacements:");

        //                Int64 AddressToSave = CurrentAddress + writeOffset;
        //                var currentBytes = PLAYBOX.readMemory(AddressToSave.ToString("X"), sizeof(int));
        //                int currentValue = BitConverter.ToInt32(currentBytes, 0);
        //                originalvalues[AddressToSave] = currentValue;

        //                Int64 addressToSave9 = CurrentAddress + readOffset;
        //                var currentBytes9 = PLAYBOX.readMemory(addressToSave9.ToString("X"), sizeof(int));
        //                int currentValue9 = BitConverter.ToInt32(currentBytes9, 0);
        //                originallvalues[addressToSave9] = currentValue9;

        //                writer.WriteLine($"  Address: 0x{AddressToSave:X}");
        //                writer.WriteLine($"    Original Value (Dec): {currentValue}");
        //                writer.WriteLine($"    Original Value (Hex): 0x{currentValue:X}");
        //                writer.WriteLine($"    Replaced Value (Dec): {currentValue9}");
        //                writer.WriteLine($"    Replaced Value (Hex): 0x{currentValue9:X}");
        //                writer.WriteLine();


        //                PLAYBOX.WriteMemory(addressToSave9.ToString("X"), "int", currentValue.ToString());
        //                PLAYBOX.WriteMemory(AddressToSave.ToString("X"), "int", currentValue9.ToString());

        //                writer.WriteLine($"  Address: 0x{addressToSave9:X}");
        //                writer.WriteLine($"    Original Value (Dec): {currentValue9}");
        //                writer.WriteLine($"    Original Value (Hex): 0x{currentValue9:X}");
        //                writer.WriteLine($"    Replaced Value (Dec): {currentValue}");
        //                writer.WriteLine($"    Replaced Value (Hex): 0x{currentValue:X}");
        //                writer.WriteLine();
        //            }
        //        }
        //        else
        //        {
        //            writer.WriteLine("No patterns found.");
        //        }
        //    }


        //    stopwatch.Stop();
        //    double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
        //    Console.Beep();
        //    //label1.Text = $"Successful, Time: {elapsedSeconds:F2} Seconds;";
        //}

        private void ShowMessageBox(string message, string status, string imageKey)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.ShowMessageBox(message, status, imageKey);
            }));
        }
    }
}
