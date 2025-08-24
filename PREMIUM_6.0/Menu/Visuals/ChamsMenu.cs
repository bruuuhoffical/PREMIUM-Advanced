using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Visuals
{
    public class ChamsMenu
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public ChamsMenu(Home mainForm)
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
        public void EnableChamsMenu()   
        {
            if (Bool.ChamsMenu == 0)
            {
                ChamsMenuNormal();
            }
            else if (Bool.ChamsMenu == 1)
            {
                ChamsMenuNormalV2();
            }
            else if (Bool.ChamsMenu == 2)
            {
                ChamsMenuOverlay();
            }
            else if (Bool.ChamsMenu == 3)
            {
                ChamsMenuOverlayV2();
            }

        }
        #region Menu
        public void ChamsMenuNormal()
        {
            string processName = "HD-Player";
            string resourceName = "PREMIUM_6._0.Properties.cnormal.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "cnormal.dll");
            ChamsMenu.inject(resourceName, glewpath);
            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }
            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = ChamsMenu.OpenProcess(1082U, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Chams Failed [0]", "2000");
                return;
            }
            IntPtr loadLibraryAddr = ChamsMenu.GetProcAddress(ChamsMenu.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = ChamsMenu.VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, 4096U, 4U);
            IntPtr bytesWritten;
            ChamsMenu.WriteProcessMemory(hProcess, allocMemAddress, Encoding.ASCII.GetBytes(glewpath), checked((uint)glewpath.Length), out bytesWritten);
            if (ChamsMenu.CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0U, IntPtr.Zero) == IntPtr.Zero)
            {
                Notify("Chams Failed [0]", "2000");
                return;
            }
            else
            {
                Notify("Chams Menu Injected", "2000");
            }
        }
        public void ChamsMenuNormalV2()
        {
            string processName = "HD-Player";
            string resourceName = "PREMIUM_6._0.Properties.cnormalv2.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "cnormalv2.dll");
            ChamsMenu.inject(resourceName, glewpath);
            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }
            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = ChamsMenu.OpenProcess(1082U, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Chams Failed [0]", "2000");
                return;
            }
            IntPtr loadLibraryAddr = ChamsMenu.GetProcAddress(ChamsMenu.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = ChamsMenu.VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, 4096U, 4U);
            IntPtr bytesWritten;
            ChamsMenu.WriteProcessMemory(hProcess, allocMemAddress, Encoding.ASCII.GetBytes(glewpath), checked((uint)glewpath.Length), out bytesWritten);
            if (ChamsMenu.CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0U, IntPtr.Zero) == IntPtr.Zero)
            {
                Notify("Chams Failed [0]", "2000");
                return;
            }
            else
            {
                Notify("Chams Menu Injected", "2000");
            }
        }



        public void ChamsMenuOverlay()
        {
            string processName = "HD-Player";
            string resourceName = "PREMIUM_6._0.Properties.coverlay.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "coverlay.dll");
            ChamsMenu.inject(resourceName, glewpath);
            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }
            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = ChamsMenu.OpenProcess(1082U, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Chams Failed [0]", "2000");
                return;
            }
            IntPtr loadLibraryAddr = ChamsMenu.GetProcAddress(ChamsMenu.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = ChamsMenu.VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, 4096U, 4U);
            IntPtr bytesWritten;
            ChamsMenu.WriteProcessMemory(hProcess, allocMemAddress, Encoding.ASCII.GetBytes(glewpath), checked((uint)glewpath.Length), out bytesWritten);
            if (ChamsMenu.CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0U, IntPtr.Zero) == IntPtr.Zero)
            {
                Notify("Chams Failed [0]", "2000");
                return;
            }
            else
            {
                Notify("Chams Menu Injected", "2000");
            }
        }
        public void ChamsMenuOverlayV2()
        {
            string processName = "HD-Player";
            string resourceName = "PREMIUM_6._0.Properties.coverlayv2.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "coverlayv2.dll");
            ChamsMenu.inject(resourceName, glewpath);
            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }
            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = ChamsMenu.OpenProcess(1082U, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Chams Failed [0]", "2000");
                return;
            }
            IntPtr loadLibraryAddr = ChamsMenu.GetProcAddress(ChamsMenu.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = ChamsMenu.VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, 4096U, 4U);
            IntPtr bytesWritten;
            ChamsMenu.WriteProcessMemory(hProcess, allocMemAddress, Encoding.ASCII.GetBytes(glewpath), checked((uint)glewpath.Length), out bytesWritten);
            if (ChamsMenu.CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0U, IntPtr.Zero) == IntPtr.Zero)
            {
                Notify("Chams Failed [0]", "2000");
                return;
            }
            else
            {
                Notify("Chams Menu Injected", "2000");
            }
        }

        private void InjectChamsLoader()
        {
            string processName = "HD-Player";
            string resourceName = "PREMIUM_6._0.Properties.glew32.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "glew32.dll");
            ChamsMenu.inject(resourceName, glewpath);
            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }
            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = ChamsMenu.OpenProcess(1082U, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Hooking Failed [0]", "2000");
                return;
            }
            IntPtr loadLibraryAddr = ChamsMenu.GetProcAddress(ChamsMenu.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = ChamsMenu.VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, 4096U, 4U);
            IntPtr bytesWritten;
            ChamsMenu.WriteProcessMemory(hProcess, allocMemAddress, Encoding.ASCII.GetBytes(glewpath), checked((uint)glewpath.Length), out bytesWritten);
            if (ChamsMenu.CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0U, IntPtr.Zero) == IntPtr.Zero)
            {
                Notify("Hooking Failed [0]", "2000");
                return;
            }
            else
            {
                Notify("Chams Menu Injected", "2000");
            }
        }
        #endregion
    }
}
