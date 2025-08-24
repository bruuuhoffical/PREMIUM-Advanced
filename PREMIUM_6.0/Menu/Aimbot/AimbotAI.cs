using PREMIUM;
using PREMIUM_6._0.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace PREMIUM_6._0.Menu.Aimbot
{
    public class AimbotAI
    {
        private Home _mainForm;
        public static Action<string> NotifyAction;
        private readonly Bool Bool = new Bool();
        private static CancellationTokenSource _cts;
        private static Task _aimbotTask;

        private void Notify(string message, string message1)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.Notify(message, message1);
            }));
        }
        public AimbotAI(Home mainForm)
        {
            _mainForm = mainForm;
        }



        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        static List<IntPtr> baseAddresses = new List<IntPtr>();
        static FastMemory mem;
        static bool checkinit = false;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        internal static void Work(CancellationToken token)
        {
            const int VK_RBUTTON = 0x02;
            const int VK_LBUTTON = 0x01;

            while (!token.IsCancellationRequested)
            {
                if (!checkinit)
                {
                    Thread.Sleep(1);
                    continue;
                }

                if (Bool.AimbotAIMode == "NORMAL")
                {
                    foreach (var baseAddr in baseAddresses)
                    {
                        VisibleWrite(baseAddr);
                    }
                }
                else if (Bool.AimbotAIMode == "LEGIT")
                {
                    IntPtr foregroundWindow = GetForegroundWindow();
                    GetWindowThreadProcessId(foregroundWindow, out uint activeProcId);
                    if (Process.GetProcessesByName("HD-Player").FirstOrDefault(p => p.Id == activeProcId) == null)
                    {
                        Thread.Sleep(5);
                        continue;
                    }

                    if ((GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0)
                    {
                        foreach (var baseAddr in baseAddresses)
                        {
                            VisibleWrite(baseAddr);
                        }
                    }
                    Thread.Sleep(1);
                }
                else if (Bool.AimbotAIMode == "LEGITV2")
                {
                    IntPtr foregroundWindow = GetForegroundWindow();
                    GetWindowThreadProcessId(foregroundWindow, out uint activeProcId);
                    if (Process.GetProcessesByName("HD-Player").FirstOrDefault(p => p.Id == activeProcId) == null)
                    {
                        Thread.Sleep(5);
                        continue;
                    }

                    if ((GetAsyncKeyState(VK_LBUTTON) & 0x8000) != 0)
                    {
                        foreach (var baseAddr in baseAddresses)
                        {
                            VisibleWrite(baseAddr);
                        }
                    }
                    Thread.Sleep(1);
                }
            }
        }


        private static void VisibleWrite(IntPtr baseAddr)
        {
            if (baseAddr == IntPtr.Zero || mem == null) return; 

            uint m_HeadCollider = (uint)mem.ReadInt32((long)(baseAddr + 0x3D8));
            if (m_HeadCollider == 0) return;

            const int repeatCount = 10;
            for (int i = 0; i < repeatCount; i++)
            {
                mem.WriteInt32((long)(baseAddr + 0x50), (int)m_HeadCollider);
            }

            mem.WriteInt32((long)(baseAddr + 0x50), (int)m_HeadCollider);
        }

        public async Task InitAimbot(Home mainForm)
        {
            Notify("Initializing aimbot..." , "");

            string aob = "?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 01 00 00 00 00 00 00 00 00 00 00 00 ?? 00 00 00 ?? 00 00 00 00 00 00 00 ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? 00 00 01 00 00 00 ?? 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 FF FF FF FF ?? ?? ?? ?? 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 01 01 00 ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";

            var process = Process.GetProcessesByName("HD-Player").FirstOrDefault();
            if (process == null)
            {
                Notify("Process not found. Please start the game.", "1000");
                return;
            }
            mem = new FastMemory();
            if (!mem.OpenProcessById(process.Id))
            {
                Notify("Failed to open process. Please run the application as administrator.", "1000");
                return;
            }

            var result = await mem.FastAoBScan2(aob, readable: true, writable: true);
            baseAddresses = result.Select(r => (IntPtr)r).ToList();

            if (baseAddresses.Count == 0) { checkinit = false; }
            else { checkinit = true; }

            Notify("Aimbot AI Initialized.", "800");
            _cts = new CancellationTokenSource();
            _aimbotTask = Task.Run(() => Work(_cts.Token));
        }
        public void DisableAimbot()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _aimbotTask?.Wait(); 
                _cts.Dispose();
                _cts = null;
                _aimbotTask = null;
                checkinit = false;
                baseAddresses.Clear();
                Notify("Aimbot AI Disabled.", "800");
            }
        }

    }
}
