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
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Visuals
{
    public class ChamsHook
    {
        private Home _ChamsHookForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public ChamsHook(Home ChamsHookForm)
        {
            _ChamsHookForm = ChamsHookForm;

        }
        private void Notify(string message, string message1)
        {
            _ChamsHookForm.Invoke(new Action(() =>
            {
                _ChamsHookForm.Notify(message, message1);
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
        #region Hook
        public void EnableChamsHook()
        {
            string processName = "HD-Player";
            string resourceName = "PREMIUM_6._0.Properties.glew32.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "glew32.dll");
            ChamsHook.inject(resourceName, glewpath);
            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                Bool.isChamsMenuReady = false;
                return;
            }
            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = ChamsHook.OpenProcess(1082U, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Hooking Failed [0]", "2000");
                Bool.isChamsMenuReady = false;
                return;
            }
            IntPtr loadLibraryAddr = ChamsHook.GetProcAddress(ChamsHook.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = ChamsHook.VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, 4096U, 4U);
            IntPtr bytesWritten;
            ChamsHook.WriteProcessMemory(hProcess, allocMemAddress, Encoding.ASCII.GetBytes(glewpath), checked((uint)glewpath.Length), out bytesWritten);
            if (ChamsHook.CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0U, IntPtr.Zero) == IntPtr.Zero)
            {
                Notify("Hooking Failed [0]", "2000");
                Bool.isChamsMenuReady = false;
                return;
            }
            else
            {
                Notify("Chams Started", "2000");
                Bool.isChamsMenuReady = true;
            }

        }
        private void InjectChamsLoader()
        {
            string processName = "HD-Player";
            string resourceName = "PREMIUM_6._0.Properties.glew32.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "glew32.dll");
            ChamsHook.inject(resourceName, glewpath);
            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }
            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = ChamsHook.OpenProcess(1082U, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Hooking Failed [0]", "2000");
                return;
            }
            IntPtr loadLibraryAddr = ChamsHook.GetProcAddress(ChamsHook.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = ChamsHook.VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, 4096U, 4U);
            IntPtr bytesWritten;
            ChamsHook.WriteProcessMemory(hProcess, allocMemAddress, Encoding.ASCII.GetBytes(glewpath), checked((uint)glewpath.Length), out bytesWritten);
            if (ChamsHook.CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0U, IntPtr.Zero) == IntPtr.Zero)
            {
                Notify("Hooking Failed [0]", "2000");
                return;
            }
            else
            {
                Notify("Chams Started", "2000");
            }
        }
        #endregion
    }
}
