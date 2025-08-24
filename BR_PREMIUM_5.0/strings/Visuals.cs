using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;

namespace BR_PREMIUM_5._0.strings
{
    public class Visuals
    {
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;

        private HOME _mainForm;

        Evelyn bruuuh = new Evelyn();

        private List<long> crsGoldAddress = new List<long>();
        private List<long> crsRedAddress = new List<long>();
        private List<long> crsPurpleAddress = new List<long>();
        private List<long> crsAquaAddress = new List<long>();
        public Visuals(HOME mainForm)
        {
            _mainForm = mainForm;

        }



        #region DLL INJECTION SYSTEM
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibraryA(string lpLibFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeLibrary(IntPtr hModule);

        const uint PROCESS_CREATE_THREAD = 0x2;
        const uint PROCESS_QUERY_INFORMATION = 0x400;
        const uint PROCESS_VM_OPERATION = 0x8;
        const uint PROCESS_VM_WRITE = 0x20;
        const uint PROCESS_VM_READ = 0x10;
        const uint MEM_COMMIT = 0x1000;
        const uint PAGE_READWRITE = 4;

        private static void inject(string resourceName, string outputPath)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            using (Stream resourceStream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    throw new ArgumentException($"Resource '{resourceName}' not found.");
                }
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[resourceStream.Length];
                    resourceStream.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        #endregion
        #region Chams
        public void InjectChamsLoader()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.glew32.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "glew32.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Hooking Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Chams Hooked", "", "");
            }
        }
        public void InjectNormalChams()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.cnormal.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "cnormal.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        public void InjectNormalChamsV2()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.cnormalv2.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "cnormalv2.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        public void InjectOverlayChamsV1()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.coverlay.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "coverlay.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        public void InjectOverlayChamsV2()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.coverlayv2.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "coverlayv2.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        public void Inject3DChams()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.transparent.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "transparent.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        public void InjectRedAntenna()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.twod.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "twod.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        public void InjectRGBbox()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.boxrgb.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "boxrgb.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        public void InjectRedChams()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.ChamsRed.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "ChamsRed.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        public void InjectBlueBox()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.BlueBox.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "BlueBox.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        public void InjectChamsMoco()
        {
            string processName = "HD-Player";
            string glew = "BR_PREMIUM.Properties.moco.ll.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "moco.ll.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                ShowMessageBox("Inject Failed", "failed", "");
            }
            else
            {
                ShowMessageBox("Injected", "", "");
            }
        }
        #endregion







        #region CrossHair




        #region Gold
        public async Task ScanCRSGold()
        {
            string search = "00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                crsGoldAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableCRSGold()
        {
            string replace = "00 00 80 3F CD CC 56 3F 00 00 00 00 00 00 80 3F";

            if (crsGoldAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in crsGoldAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("Gold CrossHair Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("GCRS Error", "failed", "");
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
        public void ResetCRSGold()
        {
            string originalPattern = "00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F";

            if (crsGoldAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in crsGoldAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("Gold CrossHair Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("GCRS Error 101", "failed", "");
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






















        #region Red
        public async Task ScanCRSRed()
        {
            string search = "00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                crsRedAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableCRSRed()
        {
            string replace = "00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 3F";

            if (crsRedAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in crsRedAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("Red CrossHair Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("RCRS Error", "failed", "");
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
        public void ResetCRSRed()
        {
            string originalPattern = "00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F";

            if (crsRedAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in crsRedAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("Red CrossHair Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("RCRS Error 101", "failed", "");
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


















        #region Purple
        public async Task ScanCRSPurple()
        {
            string search = "00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                crsPurpleAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableCRSPurple()
        {
            string replace = "00 00 00 3F 00 00 00 00 00 00 00 3F 00 00 80 3F";

            if (crsPurpleAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in crsPurpleAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("Purple CrossHair Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("PCRS Error", "failed", "");
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
        public void ResetCRSPurple()
        {
            string originalPattern = "00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F";

            if (crsPurpleAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in crsPurpleAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("Purple CrossHair Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("PCRS Error 101", "failed", "");
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











        #region Aqua
        public async Task ScanCRSAqua()
        {
            string search = "00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                crsAquaAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableCRSAqua()
        {
            string replace = "00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F";

            if (crsAquaAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in crsAquaAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("Purple CrossHair Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("ACRS Error", "failed", "");
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
        public void ResetCRSAqua()
        {
            string originalPattern = "00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F";

            if (crsAquaAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in crsAquaAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("Purple CrossHair Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("ACRS Error 101", "failed", "");
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
