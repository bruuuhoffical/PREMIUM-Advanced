using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universal.DearImGui.Hook
{
    public class dllmain
    {
        public static IntPtr GameHandle = IntPtr.Zero;
        public static bool Show = false;
        public static bool Logger = false;
        public static bool Runtime = true;
        public static Size Gui_Size = new System.Drawing.Size(800, 600);


        public static void Main(string[] args)
        {
            
        }

        public static void EntryPoint()
        {
            while (GameHandle.ToInt32() == 0)
            {
                GameHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            }

            if (Logger == true)
            {
                Console.WriteLine("All Logging passed. The system is ready.");
            }

            
        }
    }
}