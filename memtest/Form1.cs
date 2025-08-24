using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BruuuhXRidx;

namespace memtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sniper Scope : Applying!");
            Console.Beep(400, 600);
            FastMem memoryfast = new FastMem();
            string[] processNames = new string[1] { "HD-Player" };
            if (!memoryfast.SetProcess(processNames))
            {
                memoryfast = (FastMem)null;
            }
            else
            {
                foreach (long address in await memoryfast.AoBScan("08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00 00 00 00 00 00 00"))
                    memoryfast.AobReplace(address, "08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00");

                MessageBox.Show("Sniper Scope : Applied!!");

                Console.Beep(400, 300);
                memoryfast = (FastMem)null;
            }
        }
    }
}
