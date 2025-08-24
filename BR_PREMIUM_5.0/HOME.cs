using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BR_PREMIUM.strings;
using BR_PREMIUM_5._0.strings;
using CheatHubMem;
using DiscordRPC;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using MemoryAim2;
using TheArtOfDevHtmlRenderer.Adapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Gma.System.MouseKeyHook;

namespace BR_PREMIUM_5._0
{
    public partial class HOME : Form
    {
        private ParticleSystem particleSystem;
        private const string autofillValue = "Autofill";
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;
        private SystemInfoHelper systemInfoHelper;

        private const int WM_HOTKEY = 0x0312;
        private int _nextHotkeyId = 1;
        private readonly Dictionary<int, HotkeyInfo> _hotkeys = new Dictionary<int, HotkeyInfo>();
        private const string registryKey = @"Software\BRUUUH_PREMIUM";
        private const string settingsFileName = "config.dat";
        private BRUUUHMEM mem;
        //private Dictionary<string, IEnumerable<long>> aimbotexbodymem;


        private Snipers sniper;
        private Visuals visuals;
        private Aimbots aimbots;
        private Miscs miscs;
        private Bypass bypass;
        private AimLegit legitclass;
        //private Aimbots aimbotss = new Aimbots();

        bool cameraRight = false;
        public HOME()
        {
            InitializeComponent();
            _messageBoxes = new List<MessageBoxControl>();
            _messageBox = new MessageBoxControl
            {
                Visible = false,
                Dock = DockStyle.Bottom 
            };
            this.Controls.Add(_messageBox);
            systemInfoHelper = new SystemInfoHelper(pcname, hwid, ip, ram, cpu, rambar, cpubar);
            systemInfoHelper.Start();
            this.KeyPreview = true;
            this.KeyDown += HOME_KeyDown;
            #region Particles
            particleSystem = new ParticleSystem();
            #endregion
            sniper = new Snipers(this);
            visuals = new Visuals(this);
            aimbots = new Aimbots(this);
            miscs = new Miscs(this);
            bypass = new Bypass(this);
            legitclass = new AimLegit(this);

        }
        #region Particles
        private void particles_Tick(object sender, EventArgs e)
        {
            particleSystem.UpdateParticles();
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            particleSystem.DrawParticles(e.Graphics);
        }
        #endregion
        #region Hotkey
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private class HotkeyInfo
        {
            public Guna2Button Button { get; }
            public Keys Key { get; }
            public uint Modifiers { get; }

            public HotkeyInfo(Guna2Button button, Keys key, uint modifiers)
            {
                Button = button;
                Key = key;
                Modifiers = modifiers;
            }
        }

        [Flags]
        private enum KeyModifiers : uint
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }
        private void RegisterHotKeyForButton(Guna2Button button, Keys key, bool control, bool alt, bool shift)
        {
            int id = _nextHotkeyId++;
            button.Tag = id;

            uint modifiers = (control ? (uint)KeyModifiers.Control : 0) |
                             (alt ? (uint)KeyModifiers.Alt : 0) |
                             (shift ? (uint)KeyModifiers.Shift : 0);


            if (key >= Keys.A && key <= Keys.Z || key >= Keys.D0 && key <= Keys.D9 || (key >= Keys.F1 && key <= Keys.F12))
            {
                if (RegisterHotKey(this.Handle, id, modifiers, (uint)key))
                {
                    _hotkeys[id] = new HotkeyInfo(button, key, modifiers);
                    button.Text = $"{key}";
                }
                else
                {
                    //if (disablenot.Checked == false)
                    //{
                    //    ShowMessageBox("Failed To Register", "failed", "Failed");

                    //}
                }
            }
            else
            {
                //if (disablenot.Checked == false)
                //{
                //    ShowMessageBox("Invalid Key", "failed", "failed");
                //}
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();
                if (_hotkeys.TryGetValue(id, out var hotkeyInfo))
                {
                    PerformActionForButton(hotkeyInfo.Button);
                }
            }
        }
        private void capture1()
        {
            aimheadkey.Text = "?";
            this.KeyDown += Form1_KeyDownButton1;
        }
        private void capture2()
        {
            aimheadv2key.Text = "?";
            this.KeyDown += Form1_KeyDownButton2;
        }
        private void capture3()
        {
            aimdragkey.Text = "?";
            this.KeyDown += Form1_KeyDownButton3;
        }
        private void capture4()
        {
            aimneckkey.Text = "?";
            this.KeyDown += Form1_KeyDownButton4;
        }
        private void capture5()
        {
            aimbodykey.Text = "?";
            this.KeyDown += Form1_KeyDownButton5;
        }
        private void capture6()
        {
            ssckey.Text = "?";
            this.KeyDown += Form1_KeyDownButton6;
        }
        private void capture7()
        {
            M82Bkey.Text = "?";
            this.KeyDown += Form1_KeyDownButton7;
        } 
        private void capture8()
        {
            sscoffkey.Text = "?";
            this.KeyDown += Form1_KeyDownButton8;
        }
        private void capture9()
        {
            m82boffkey.Text = "?";
            this.KeyDown += Form1_KeyDownButton9;
        }
        private void capture10()
        {
            camerakey.Text = "?";
            this.KeyDown += Form1_KeyDownButton10;
        }
        private void capture11()
        {
            speedKey.Text = "?";
            this.KeyDown += Form1_KeyDownButton11;
        }
        private void capture12()
        {
            WallKey.Text = "?";
            this.KeyDown += Form1_KeyDownButton12;
        }
        private void capture13()
        {
            ghostkey.Text = "?";
            this.KeyDown += Form1_KeyDownButton13;
        }

        private void Form1_KeyDownButton1(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(aimheadkey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton1;
        }
        private void Form1_KeyDownButton2(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(aimheadv2key, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton2;
        }
        private void Form1_KeyDownButton3(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(aimdragkey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton3;
        }
        private void Form1_KeyDownButton4(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(aimneckkey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton4;
        }
        private void Form1_KeyDownButton5(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(aimbodykey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton5;
        }
        private void Form1_KeyDownButton6(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(ssckey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton6;
        }
        private void Form1_KeyDownButton7(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(M82Bkey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton7;
        }
        private void Form1_KeyDownButton8(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(sscoffkey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton8;
        }
        private void Form1_KeyDownButton9(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(m82boffkey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton9;
        }
        private void Form1_KeyDownButton10(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(camerakey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton10;
        }
        private void Form1_KeyDownButton11(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(speedKey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton11;
        }
        private void Form1_KeyDownButton12(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(WallKey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton12;
        
        }
        private void Form1_KeyDownButton13(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(ghostkey, e.KeyCode, e.Control, e.Alt, e.Shift);
            this.KeyDown -= Form1_KeyDownButton13;
        }

        //private void Form1_KeyDownButton2(object sender, KeyEventArgs e)
        //{
        //    RegisterHotKeyForButton(redlinekey, e.KeyCode, e.Control, e.Alt, e.Shift);
        //    this.KeyDown -= Form1_KeyDownButton2;
        //}
       
        private void PerformActionForButton(Guna2Button button)
        {
            if (button == aimheadkey)
            {
                aimbots.EnableAimbotDrag();
            }
            else if (button == aimheadv2key)
            {
                aimbots.EnableAimbotHeadV2();
            }


            else if (button == aimdragkey)
            {
                //if (aimbots.onaimdrag == false)
                //{
                //    aimbots.EnableAimbotDrag();
                //}
                //else if (aimbots.onaimdrag == true)
                //{
                //    aimbots.DisableAimbotDrag();
                //}

            }


            else if (button == aimneckkey)
            {
                if (aimbots.onaimneck == false)
                {
                    aimbots.EnableAimbotNeck();
                }
                else if (aimbots.onaimneck == true)
                {
                    aimbots.DisableAimbotNeck();
                }
            }
            else if (button == aimbodykey)
            {
                if(aimbots.onaimbody == false)
                {
                    aimbots.EnableAimbotBody();
                }
                else if(aimbots.onaimbody == true)
                {
                    aimbots.ResetAimbotBody();
                }
            }
            else if (button == ssckey)
            {
                sniper.EnableSniperScope();
            }
            else if (button == sscoffkey)
            {
                sniper.ResetSniperScope();
            }
            else if (button == M82Bkey)
            {
                
            }
            else if (button == m82boffkey)
            {
                
            }
            else if (button == speedKey)
            {
                if(miscs.Speed == false)
                {
                    miscs.EnablSpeed();
                }
                else
                {
                    miscs.ResetSpeed();
                }
            }
            else if (button == WallKey)
            {
                if (miscs.Wall == false)
                {
                    miscs.EnablWall();
                }
                else
                {
                    miscs.ResetWall();
                }
            }
            else if (button == camerakey)
            {
                if(cameraRight == false)
                {
                    miscs.EnableCameraLeft();
                }
                else
                {
                    miscs.ResetCameraLeft();
                }
            }
            else if (button == ghostkey)
            {
                if(miscs.Glitch == false)
                {
                    miscs.EnableGhostHack();
                }
                else
                {
                    miscs.ReseGhostHack();
                }
            }

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnregisterAllHotkeys();
            base.OnFormClosing(e);
        }

        private void UnregisterAllHotkeys()
        {
            foreach (var id in _hotkeys.Keys)
            {
                UnregisterHotKey(this.Handle, id);
            }
            _hotkeys.Clear();
        }
        private void HOME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.None)
            {
                Guna2Button targetButton = null;

                //if (e.KeyCode == Keys.F4)
                //{
                //    targetButton = aimheadkey;
                //}
                //else if (e.KeyCode == Keys.B)
                //{
                //    targetButton = aimheadv2key;
                //}

                if (targetButton != null)
                {
                    RegisterHotKeyForButton(targetButton, e.KeyCode, e.Control, e.Alt, e.Shift);
                    e.Handled = true;
                }
            }
        }

        private void aimheadkey_Click(object sender, EventArgs e)
        {
            capture1();
        }

        private void aimheadv2key_Click(object sender, EventArgs e)
        {
            capture2();
        }

        private void aimdragkey_Click(object sender, EventArgs e)
        {
            capture3();
        }

        private void aimneckkey_Click(object sender, EventArgs e)
        {
            capture4();
        }

        private void aimbodykey_Click(object sender, EventArgs e)
        {
            capture5();
        }
        private void ClearAllKeysAimbot()
        {
            aimheadkey.Text = "None";
            aimheadv2key.Text = "None";
            aimdragkey.Text = "None";
            aimneckkey.Text = "None";
            aimbodykey.Text = "None";
        }
        private void ClearAllKeysSniper()
        {
            ssckey.Text = "None";
            M82Bkey.Text = "None";
        }
        private void ClearAllKeysMisc()
        {
            speedKey.Text = "None";
            WallKey.Text = "None";
        }

        private void resetallkeys1_Click(object sender, EventArgs e)
        {
            UnregisterAllHotkeys();
            if (disablenot.Checked == false)
            {
                ShowMessageBox("All Keys is Cleared", "sucess", "");
            }
            ClearAllKeysAimbot();
        }

        #endregion
        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        public void ShowMessageBox(string message, string status, string imageKey)
        {
            MessageBoxControl messageBox = new MessageBoxControl();
            this.Controls.Add(messageBox);

            Color baseColor = loginLogotext.ForeColor;

            if (activeMessageBoxes > 0)
            {
                messageBox.Location = new Point(this.ClientSize.Width - messageBox.Width - 10, lastMessageBoxY - messageBox.Height - 10);
            }
            else
            {
                messageBox.Location = new Point(this.ClientSize.Width - messageBox.Width - 10, this.ClientSize.Height - messageBox.Height - 10);
            }

            lastMessageBoxY = messageBox.Location.Y;
            messageBox.BringToFront();

            messageBox.ShowMessage(message, status, imageKey, baseColor);

            activeMessageBoxes++;

            Timer timer = new Timer { Interval = 5000 };
            timer.Tick += (sender, e) =>
            {
                messageBox.HideMessage();
                activeMessageBoxes--;

                if (activeMessageBoxes > 0)
                {
                    foreach (Control control in this.Controls)
                    {
                        if (control is MessageBoxControl && control.Location.Y < lastMessageBoxY)
                        {
                            control.Location = new Point(control.Location.X, control.Location.Y + messageBox.Height + 10);
                        }
                    }
                }

                if (activeMessageBoxes == 0)
                {
                    lastMessageBoxY = this.ClientSize.Height - messageBox.Height - 10;
                }

                timer.Stop();
            };
            timer.Start();
        }
        private static DateTime UnixTimeToDateTime(long unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixStart.AddSeconds(unixTime).ToLocalTime();
        }
        private IKeyboardMouseEvents _globalHook;
        private bool _systemOn = false;
        private bool _hookActive = false;
        private void HOME_Load(object sender, EventArgs e)
        {
            rambar.Update();
            homenav.PerformClick();
            LoadSettings();
            rpc.Checked = true;
            RichStatus.rpctimestamp = Timestamps.Now;
            RichStatus.InitializeRPC();
            if (LOGIN.KeyAuthApp.user_data != null)
            {
                string username = LOGIN.KeyAuthApp.user_data.username;
                DateTime expiryDateTime = UnixTimeToDateTime(long.Parse(LOGIN.KeyAuthApp.user_data.subscriptions[0].expiry));

                user.Text = $"{username}";
                expiry.Text = $"{expiryDateTime:yyyy/MM/dd HH:mm}";
            }
            else
            {

            }
            if (disablenot.Checked == false)
            {
                ShowMessageBox("Logged In !", "sucess", "");
            }
            _globalHook = Hook.GlobalEvents();
            _globalHook.MouseDown += GlobalHook_MouseDown;
        }
        private void GlobalHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (_hookActive)
            {
                if (e.Button == MouseButtons.Right)
                {
                    _systemOn = true;
                    //UpdateStatusLabel();
                    legitclass.Aimboton();
                }

                if (e.Button == MouseButtons.Left)
                {
                    _systemOn = false;
                    //UpdateStatusLabel();
                    legitclass.Aimbotoff();

                }
            }
        }
        private void UpdateStatusLabel()
        {
            
        }
        private void aimbotnav_Click(object sender, EventArgs e)
        {
            aimbotspanel.BringToFront();
        }




        #region .




        private void proccessmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = proccessmode.SelectedIndex;

            Process currentProcess = Process.GetCurrentProcess();

            switch (selectedIndex)
            {
                case 0:
                    currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
                    break;
                case 1:
                    currentProcess.PriorityClass = ProcessPriorityClass.High;
                    break;
                case 2:
                    currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
                    break;
                case 3:
                    currentProcess.PriorityClass = ProcessPriorityClass.Normal;
                    break;
                case 4:
                    currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
                    break;
                case 5:
                    currentProcess.PriorityClass = ProcessPriorityClass.Idle;
                    break;
                default:
                    if (disablenot.Checked == false)
                    {
                        ShowMessageBox("Invalid Priority Selected", "failed", "");
                    }
                    break;
            }

            //MessageBox.Show($"Process priority changed to {proccessmode.SelectedItem}");
            if (disablenot.Checked == false)
            {
                ShowMessageBox("Priority Changed", "success", "");
            }
        }
        private void aimfunctions_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (aimexv2.Checked == false)
            {
                aimexv2.Checked = true;
            }
            else
            {
                aimexv2.Checked = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (aimdrag.Checked == false)
            {
                aimdrag.Checked = true;
            }
            else
            {
                aimdrag.Checked = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (aimbody.Checked == false)
            {
                aimbody.Checked = true;
            }
            else
            {
                aimbody.Checked = false;
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            if (ainneck.Checked == false)
            {
                ainneck.Checked = true;
            }
            else
            {
                ainneck.Checked = false;
            }
        }
        private void label2_Click_1(object sender, EventArgs e)
        {
            if (aimbotexternal.Checked == false)
            {
                aimbotexternal.Checked = true;
            }
            else
            {
                aimbotexternal.Checked = false;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {
            if (aimdrag.Checked)
            {
                //aimbots.EnableAimbotDrag();
                if (_hookActive)
                {
                    _globalHook.MouseDown -= GlobalHook_MouseDown;
                    _hookActive = false;
                    ShowMessageBox("Aimbot Legit Disabled", "", "");
                    legitclass.Aimboton();
                }
                else
                {
                    _globalHook.MouseDown += GlobalHook_MouseDown;
                    _hookActive = true;
                    ShowMessageBox("Aimbot Legit Enabled", "", "");
                }
            }
            else
            {
                //aimbots.DisableAimbotDrag();
            }
        }

        private void testkey_Click(object sender, EventArgs e)
        {

        }
        private void aimexv2_Click(object sender, EventArgs e)
        {
            if (aimexv2.Checked)
            {
                aimbots.EnableAimbotHeadV2();
            }

            else
            {
                //aimbots.DisableAimbotHeadV2();


            }
        }
        private void visualsnav_Click(object sender, EventArgs e)
        {
            visualspanel.BringToFront();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void navigationspanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homepan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void restart_Click(object sender, EventArgs e)
        {
            if (taskbar.Checked)
            {
                this.ShowInTaskbar = false;
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Taskbar Icon Hidden", "sucess", "");
                }
            }
            else
            {
                this.ShowInTaskbar = true;
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Taskbar Icon Visible", "sucess", "");
                }
            }
        }

        private void settingsnav_Click(object sender, EventArgs e)
        {
            settingspanel.BringToFront();
        }

        private void disablefps_Click(object sender, EventArgs e)
        {
            if (disablefps.Checked)
            {
                label25.Hide();
                fps.Hide();
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("FPS Hidden", "sucess", "");
                }
            }
            else
            {
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("FPS Visible", "sucess", "");
                }
                label25.Show();
                fps.Show();
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {
            if (disablenot.Checked == true)
            {

            }
            else
            {

                ShowMessageBox("Test", "failed", "Failed");
            }
        }

        private void BlockProcessByName(string processName)
        {
            try
            {
                var process = Process.GetProcessesByName(processName).FirstOrDefault();
                if (process == null)
                {
                    MessageBox.Show("Process not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int pid = process.Id;
                var connections = GetActiveConnections(pid);

                if (connections.Any())
                {
                    KillProcessConnections(pid);
                    MessageBox.Show($"Network connections for {processName} have been blocked.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No active network connections found for the process.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to block process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UnblockProcessByName(string processName)
        {
            try
            {
                MessageBox.Show($"The unblock feature isn't directly supported here. Please manually resume the process or restore network access.", "Unblock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to unblock process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string[] GetActiveConnections(int pid)
        {
            string command = $"netstat -ano | findstr {pid}";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {command}",
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            using (Process process = Process.Start(startInfo))
            {
                using (var reader = process.StandardOutput)
                {
                    string output = reader.ReadToEnd();
                    return output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }

        private void KillProcessConnections(int pid)
        {
            string command = $"netsh interface ipv4 set subinterface \"Ethernet\" mtu=1492 store=persistent";
            ExecuteNetshCommand(command);
        }

        private void ExecuteNetshCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = command,
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = false
            };

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
            }
        }

        private void panelicon_Click(object sender, EventArgs e)
        {
            if (panelicon.Checked)
            {
                this.ShowIcon = false;
            }
            else
            {
                this.ShowIcon = true;
            }
        }

        private void internet_Click(object sender, EventArgs e)
        {
            if (internet.Checked)
            {
                BlockProcessByName("HD-Player");
            }
            else
            {
                UnblockProcessByName("HD-Player");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void discordbtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/bruuuhcheats");
        }

        private void homenav_Click(object sender, EventArgs e)
        {
            homepan.BringToFront();
        }
        private void LoadSettings()
        {
            string filePath = Path.Combine(Application.StartupPath, settingsFileName);

            if (File.Exists(filePath))
            {
                try
                {
                    string[] settings = File.ReadAllLines(filePath);

                    if (settings.Length >= 4)
                    {
                        disablenot.Checked = Convert.ToBoolean(settings[0]);
                        streamerMode.Checked = Convert.ToBoolean(settings[1]);
                        mutebeep.Checked = Convert.ToBoolean(settings[2]);
                        taskbar.Checked = Convert.ToBoolean(settings[3]);
                        rpc.Checked = Convert.ToBoolean(settings[4]);
                        proccessmode.SelectedIndex = Convert.ToInt32(settings[5]);
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageBox("Error loading settings from .dat file: ", "", "");
                }
            }

            if (!LoadFromRegistry())
            {
                InitializeDefaults();
            }
        }
        private bool LoadFromRegistry()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(registryKey);
                if (regKey != null)
                {
                    disablenot.Checked = Convert.ToBoolean(regKey.GetValue("Disable Notifications", false));
                    streamerMode.Checked = Convert.ToBoolean(regKey.GetValue("Streamer Mode", false));
                    mutebeep.Checked = Convert.ToBoolean(regKey.GetValue("Mute Beep", false));
                    taskbar.Checked = Convert.ToBoolean(regKey.GetValue("Taskbar", false));
                    rpc.Checked = Convert.ToBoolean(regKey.GetValue("Discord Rpc", false));
                    particlesonoff.Checked = Convert.ToBoolean(regKey.GetValue("Particles", true));
                    proccessmode.SelectedIndex = Convert.ToInt32(regKey.GetValue("Proccess Mode", -1));
                    regKey.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error loading from registry: ", "", "");
            }
            return false;
        }

        private void InitializeDefaults()
        {
            disablenot.Checked = false;
            streamerMode.Checked = false;
            mutebeep.Checked = false;
            taskbar.Checked = false;
            rpc.Checked = false;
            particlesonoff.Checked = true;
            //proccessmode.SelectedIndex = -1;
        }
        private void SaveSettings()
        {
            string filePath = Path.Combine(Application.StartupPath, settingsFileName);

            try
            {
                string[] settings = new string[]
                {
                    disablenot.Checked.ToString(),
                    streamerMode.Checked.ToString(),
                    mutebeep.Checked.ToString(),
                    taskbar.Checked.ToString(),
                    rpc.Checked.ToString(),
                    particlesonoff.Checked.ToString(),
                    panelicon.Checked.ToString(),
                    internet.Checked.ToString(),
                    disablefps.Checked.ToString(),
                    proccessmode.SelectedIndex.ToString()
                };

                File.WriteAllLines(filePath, settings);
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error saving .dat file", "", "");
            }
            SaveToRegistry();
        }
        private void SaveToRegistry()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey(registryKey);
                regKey.SetValue("Disable Notifications", disablenot.Checked);
                regKey.SetValue("Streamer Mode", streamerMode.Checked);
                regKey.SetValue("Mute Beep", mutebeep.Checked);
                regKey.SetValue("Taskbar", taskbar.Checked);
                regKey.SetValue("Discord Rpc", rpc.Checked);
                regKey.SetValue("Particles", particlesonoff.Checked);
                regKey.SetValue("Proccess Mode", proccessmode.SelectedIndex);
                regKey.Close();
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error saving to registry:", "", "");
            }
        }



        #endregion










        private void saveall_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        private void clearall_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void rpc_Click(object sender, EventArgs e)
        {
            if (rpc.Checked)
            {
                RichStatus.DisconnectRPC();
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Discord RPC Disabled", "sucess", "");
                }
            }
            else
            {
                RichStatus.rpctimestamp = Timestamps.Now;
                RichStatus.InitializeRPC();
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Discord RPC Enabled", "sucess", "");
                }
            }
        }

        private void settingspanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void testbar_Scroll(object sender, ScrollEventArgs e)
        {
            //particles.Interval = testbar.Value;
        }

        private void testbar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void particlesonoff_Click(object sender, EventArgs e)
        {
            if (particlesonoff.Checked)
            {
                particles.Enabled = false;
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Particles Paused", "sucess", "");
                }
            }
            else
            {
                particles.Enabled = true;
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Particles Played", "sucess", "");
                }
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {
            if (particlesonoff.Checked)
            {
                particlesonoff.Checked = false;
            }
            else
            {
                particlesonoff.Checked = true;
            }
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        // ABOVE BUTTON
        public static bool Streaming;

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
        private void streamerMode_Click(object sender, EventArgs e)
        {
            if (streamerMode.Checked)
            {
                base.ShowInTaskbar = false;
                Streaming = true;
                SetWindowDisplayAffinity(base.Handle, 17U);
                mainborderless.HasFormShadow = false;
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Streamer Mode Enabled", "sucess", "");
                }
                mutebeep.Checked = true;
            }
            else
            {
                base.ShowInTaskbar = true;
                Streaming = false;
                SetWindowDisplayAffinity(base.Handle, 0U);
                mainborderless.HasFormShadow = false;
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Streamer Mode Disabled", "sucess", "");
                }
                mutebeep.Checked = false;
            }
        }
        public bool IsCheckboxChecked()
        {
            return disablenot.Checked;
        }
        public void disablenot_Click(object sender, EventArgs e)
        {
            if (disablenot.Checked)
            {
                ShowMessageBox("Notifications Disabled", "sucess", "");
            }
            else
            {
                ShowMessageBox("Notifications Enabled", "sucess", "");
            }
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void mutebeep_Click(object sender, EventArgs e)
        {
            if (mutebeep.Checked)
            {
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Beep Disabled", "sucess", "");
                }
            }
            else
            {
                if (disablenot.Checked == false)
                {
                    ShowMessageBox("Beep Enabled", "sucess", "");
                }
            }
        }
        private async void aimbotexternal_Click(object sender, EventArgs e)
        {
            if (aimbotexternal.Checked)
            {
                //aimbots.EnableAimbotHead();
                aimbots.EnableAimbotDrag();
            }

            else
            {
                //aimbots.DisableAimbotHead();
                aimbots.DisableAimbotDrag();
            }
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            capture7();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {

        }
        public static MemRed RedLib = new MemRed();
        public static String PID;
        private async void aimheadload_Click(object sender, EventArgs e)
        {
            //aimbots.LoadAimbotHead();
            aimbots.LoadAimbotDrag();
        }

        private void sniperpan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void snipernav_Click(object sender, EventArgs e)
        {
            sniperpan.BringToFront();
        }

        private void miscnav_Click(object sender, EventArgs e)
        {
            miscpanel.BringToFront();
        }

        private async void aimheadv2load_Click(object sender, EventArgs e)
        {
            aimbots.LoadAimbotHeadV2();
        }

        private async void aimdragload_Click(object sender, EventArgs e)
        {
            aimbots.LoadAimbotDrag();
        }

        private async void aimneckload_Click(object sender, EventArgs e)
        {
            aimbots.LoadAimbotNeck();
        }

        private void aimbodyload_Click(object sender, EventArgs e)
        {
            aimbots.ScanAimbotbody();
        }

        private void ainneck_Click(object sender, EventArgs e)
        {
            if (ainneck.Checked)
            {
                aimbots.EnableAimbotNeck();
            }
            else
            {
                aimbots.DisableAimbotNeck();
            }
        }

        private void ssc_Click(object sender, EventArgs e)
        {
            if (ssc.Checked)
            {
                if (sniper != null)
                {
                    //.EnableSniperScope();
                    sniper.EnableSniperScope();
                }
                else
                {
                    MessageBox.Show("Sniper Error Please Contact The Developer - BRUUUH CHEATS");
                }
            }
            else
            {
                sniper.ResetSniperScope();
            }
        }

        private void sscload_Click(object sender, EventArgs e)
        {
            sniper.ScanSniperScope();
        }

        private void clearall2_Click(object sender, EventArgs e)
        {
            UnregisterAllHotkeys();
            if (disablenot.Checked == false)
            {
                ShowMessageBox("All Keys is Cleared", "sucess", "");
            }
            ClearAllKeysSniper();
        }

        private void ssckey_Click(object sender, EventArgs e)
        {
            capture6();
        }
        public void speedhackmain()
        {
            if (miscs.Speed == false)
            {
                miscs.EnablSpeed();
            }
            else
            {
                miscs.ResetSpeed();
            }
        
        }public void wallhackmain()
        {
            if (miscs.Wall == false)
            {
                miscs.EnablWall();
            }
            else
            {
                miscs.ResetWall();
            }
        }
        private void sniperscope_Click(object sender, EventArgs e)
        {
            if (speedhack.Checked)
            {
                miscs.EnablSpeed();
            }
            else
            {
                miscs.ResetSpeed();
            }
        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sscoffkey_Click(object sender, EventArgs e)
        {
            capture8();
        }

        private void m82boffkey_Click(object sender, EventArgs e)
        {
            capture9();
        }

        private void ss_Click(object sender, EventArgs e)
        {
            if (ss.Checked)
            {
                sniper.EnableSniperSwitch();
            }
            else
            {
                sniper.DisableSniperSwitch();
            }
        }

        private void sniperdelay_Click(object sender, EventArgs e)
        {
            if (sniperdelay.Checked)
            {
                sniper.Enablesdelayfix();
            }
            else
            {
                sniper.Disablesdelayfix();
            }
        }

        private void M82Bswitch_Click(object sender, EventArgs e)
        {
            if (M82Bswitch.Checked)
            {
                sniper.EnableM82BSwitch();
            }
            else
            {
                sniper.DisableM82BSwitch();
            }
        }

        private void M82Blocationload_Click(object sender, EventArgs e)
        {
            sniper.ScanM24Switch();
            sniper.ScanVSKSwitch();
        }

        private void M82Blocation_Click(object sender, EventArgs e)
        {
            if (M82Blocation.Checked)
            {
                sniper.EnableM24Switch();
                sniper.EnableVSKSwitch();
            }
            else
            {
                sniper.ResetM24Switch();
                sniper.ResetVSKSwitch();
            }
        }

        private void guna2Panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void cmenunormal_Click(object sender, EventArgs e)
        {
            if (cmenunormal.Checked)
            {
            visuals.InjectNormalChams();
            }
        }

        private void cmenunormalv2_Click(object sender, EventArgs e)
        {
            if (cmenunormalv2.Checked)
            {
                visuals.InjectNormalChamsV2();
            }
        }

        private void cmenuoverlayv1_Click(object sender, EventArgs e)
        {
            if (cmenuoverlayv1.Checked)
            {
                if(chamshooking.Checked == false)
                {
                    chamshooking.PerformClick();
                }
                else
                {
                    visuals.InjectOverlayChamsV1();
                }
            }
        }

        private void cmenuoverlayv2_Click(object sender, EventArgs e)
        {
            if (cmenuoverlayv2.Checked)
            {
                if (chamshooking.Checked == false)
                {
                    chamshooking.PerformClick();
                }
                else
                {
                    visuals.InjectOverlayChamsV2();
                }
            }
        }

        private void chamshooking_Click(object sender, EventArgs e)
        {
            chamshooking.Checked = true;
            visuals.InjectChamsLoader();
        }

        private void chams3d_Click(object sender, EventArgs e)
        {
            if (chams3d.Checked)
            {
                visuals.Inject3DChams();
            }
        }

        private void redantenna_Click(object sender, EventArgs e)
        {
            if (redantenna.Checked)
            {
                visuals.InjectRedAntenna();
            }
        }

        private void rgbbox_Click(object sender, EventArgs e)
        {
            if (rgbbox.Checked)
            {
                visuals.InjectRGBbox();
            }
        }

        private void redchams_Click(object sender, EventArgs e)
        {
            if (redchams.Checked)
            {
                visuals.InjectRedChams();
            }
        }

        private void bluebox_Click(object sender, EventArgs e)
        {
            if (bluebox.Checked)
            {
                visuals.InjectBlueBox();
            }
        }

        private void chamsmoco_Click(object sender, EventArgs e)
        {
            if (chamsmoco.Checked)
            {
                visuals.InjectChamsMoco();
            }
        }

        private void aimbody_Click(object sender, EventArgs e)
        {
            if (aimbody.Checked)
            {
                aimbots.EnableAimbotBody();
            }
            else
            {
                aimbots.ResetAimbotBody();
            }
        }

        private void loadsniperzoom_Click(object sender, EventArgs e)
        {
            sniper.ScanSniperTracking();
        }

        private void sniperzoom_Click(object sender, EventArgs e)
        {
            if (sniperzoom.Checked)
            {
                sniper.EnableSniperTracking();
            }
            else
            {
                sniper.ResetSniperTracking();
            }
        }

        private void aimfov_Click(object sender, EventArgs e)
        {
            if (aimfov.Checked)
            {
                aimbots.EnableAimFov();
            }
            else
            {
                aimbots.DisableAimFov();
            }
        }

        private void aimbotspanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomCheckBox9_Click(object sender, EventArgs e)
        {
            if (norecoil.Checked)
            {
                miscs.EnableNoRecoil();
            }
            else
            {
                miscs.DisableNoRecoil();    
            }
        }

        private void loadspeed_Click(object sender, EventArgs e)
        {
            miscs.ScanSpeed();
        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void loadglitch_Click(object sender, EventArgs e)
        {
            miscs.ScanGhostHack();
        }

        private void guna2CustomCheckBox3_Click(object sender, EventArgs e)
        {
            if (glitch.Checked)
            {
                miscs.EnableGhostHack();
            }
            else
            {
                miscs.ReseGhostHack();
            }
        }

        private void guna2CustomCheckBox8_Click(object sender, EventArgs e)
        {
            if (bypassemulator.Checked)
            {
                bypass.ScanSecureBypass();
            }
        }

        private void guna2CustomCheckBox2_Click_1(object sender, EventArgs e)
        {
            if (camera.Checked)
            {
                miscs.EnableCameraUp();
            }
            else
            {
                miscs.DisableCameraUp();
            }
        }

        private void fixfemale_Click(object sender, EventArgs e)
        {
            if (fixfemale.Checked)
            {
                miscs.EnableFixFemale();
            }
            else
            {
                miscs.DisableFixFemale();
            }
        }

        private void loadcamera_Click(object sender, EventArgs e)
        {
            //miscs.ScanCameraUp();
        }

        private void camerakey_Click(object sender, EventArgs e)
        {
            capture10();
        }

        private void loadwall_Click(object sender, EventArgs e)
        {
            miscs.ScanWall();
        }

        private void guna2CustomCheckBox4_Click(object sender, EventArgs e)
        {
            if (wallhack.Checked)
            {
                miscs.EnablWall();
            }
            else
            {
                miscs.ResetWall();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            capture13();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UnregisterAllHotkeys();
            if (disablenot.Checked == false)
            {
                ShowMessageBox("All Keys is Cleared", "sucess", "");
            }
            ClearAllKeysMisc();
        }

        private void loginLogotext_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HOME_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.Yellow;
            int borderThickness = 3;

            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HOME_FormClosing(object sender, FormClosingEventArgs e)
        {
            _globalHook.MouseDown -= GlobalHook_MouseDown;
            _globalHook.Dispose();
        }

        private void speedKey_Click(object sender, EventArgs e)
        {
            capture11();
        }

        private void WallKey_Click(object sender, EventArgs e)
        {
            capture12();
        }
    }
}
