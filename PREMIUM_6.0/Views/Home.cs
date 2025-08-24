using DiscordRPC;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using PREMIUM_6._0.Libaries;
using PREMIUM_6._0.Menu.Aimbot;
using PREMIUM_6._0.Menu.Misc;
using PREMIUM_6._0.Menu.Sniper;
using PREMIUM_6._0.Menu.Visuals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PREMIUM_6._0.Views
{
    public partial class Home : Form
    {
        #region BlurEvent
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }
        internal enum WindowCompositionAttribute
        {
            WCA_ACCENT_POLICY = 19
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public int nAccentState;
            public int nFlags;
            public int nColor;
            public int nAnimationId;
        }
        #endregion
        private const string registryKey = @"Software\BRUUUH_PREMIUM";

        private List<CustomNotification> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private CustomNotification _messageBox;
        private Dictionary<Guna2GradientButton, Keys> hotkeyBindings = new Dictionary<Guna2GradientButton, Keys>();

        #region k
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int hotkeyCounter = 1000;
        private Dictionary<int, Guna2GradientButton> hotkeyIds = new Dictionary<int, Guna2GradientButton>();
        #endregion
        #region Calls
        SoundPlayer soundPlayer;
        Additional extra = new Additional();
        private AimbotAI aimbotAI;
        private AimbotHead aimbothead;
        private AimbotLegit aimbotlegit;
        private AimbotDrag aimbotdrag;
        private AimbotNeck aimbotneck;
        private AimbotBody aimbotbody;
        private AimFov aimfov;
        private Recoil recoil;
        private Guest guest;
        private ScopeTracking scope;
        private Camera camera;
        private AWMScope awmscope;
        private AWMSwitch awmswitch;
        private AWMYSwitch awmyswitch;
        private M24FastSwitch m24fastswitch;
        private M82BSwitch m82bswitch;
        private SniperAim sniperaim;
        private SniperFov sniperfov;
        private SniperDelayFix sniperdelayfix;
        private SniperScope sniperscope;
        private SniperSwitch sniperswitch;
        private SniperTracking snipertracking;
        private WallHack wallhack;
        private SpeedTimer speedtimer;
        private GlitchFire glitchfire;
        private Chams4D chams4d;
        private ChamsHook chamshook;
        private ChamsMenu chamsmenu;
        private HiddenMenu hiddenmenu;
        private FakeLag fakelag;
        private NewSniperScope newSniperScope;
        private HeadTracking headTracking;
        private ScopeXit scopeXit;
        private Chams Chams;
        private FemaleFix femaleFix;
        private AimbotBodyBrutal aimbotBodyBrutal;
        private BypassWallHack bypassWallHack;
        private NewSniperSwitch newSniperSwitch;
        private AimLock aimLock;
        private Anticheat anticheat;
        #endregion

        #region Includes

        Bool Bool = new Bool();

        #region Hotkey
        private void CaptureAimbotHead()
        {
            Kaimbothead.Text = "-";
            this.KeyDown += Form1_KeyDownButton1;
        }
        
        private void CaptureAimbotAI()
        {
            Kaimbotai.Text = "-";
            this.KeyDown += Form1_KeyDownButton11;
        }
        
        private void CaptureAimbotDrag()
        {
            Kaimdrag.Text = "-";
            this.KeyDown += Form1_KeyDownButton2;
        }
        private void CaptureAimbotNeck()
        {
            Kaimneck.Text = "-";
            this.KeyDown += Form1_KeyDownButton3;
        }
        private void CaptureSpeed()
        {
            Kspeed.Text = "-";
            this.KeyDown += Form1_KeyDownButton4;
        }
        private void CaptureWall()
        {
            Kwall.Text = "-";
            this.KeyDown += Form1_KeyDownButton5;
        }
        private void CaptureCamera()
        {
            Kcamera.Text = "-";
            this.KeyDown += Form1_KeyDownButton6;
        }
        private void CaptureCameraPostion()
        {
            Kcameraposition.Text = "-";
            this.KeyDown += Form1_KeyDownButton7;
        }
        private void CaptureAimbotLegit()
        {
            Kaimbotlegit.Text = "-";
            this.KeyDown += Form1_KeyDownButton8;
        }

        private void CaptureFakeLagA()
        {
            Klagauto.Text = "-";
            this.KeyDown += Form1_KeyDownButton9;
        }
        private void CaptureFakeLagM()
        {
            Klagmanual.Text = "-";
            this.KeyDown += Form1_KeyDownButton10;
        }
        private void Form1_KeyDownButton1(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Kaimbothead, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton1;
        }

        private void Form1_KeyDownButton2(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Kaimdrag, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton2;
        }
        private void Form1_KeyDownButton3(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Kaimneck, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton3;
        }
        private void Form1_KeyDownButton4(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Kspeed, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton4;
        }
        private void Form1_KeyDownButton5(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Kwall, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton5;
        }
        private void Form1_KeyDownButton6(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Kcamera, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton6;
        }
        private void Form1_KeyDownButton7(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Kcameraposition, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton7;
        }
        private void Form1_KeyDownButton8(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Kaimbotlegit, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton8;
        }
        private void Form1_KeyDownButton9(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Klagauto, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton9;
        }
        private void Form1_KeyDownButton10(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Klagmanual, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton10;
        }
        private void Form1_KeyDownButton11(object sender, KeyEventArgs e)
        {
            RegisterHotKeyForButton(Kaimbotai, e.KeyCode);
            this.KeyDown -= Form1_KeyDownButton11;
        }
        private void RegisterHotKeyForButton(Guna2GradientButton button, Keys key)
        {
            if (hotkeyBindings.ContainsKey(button))
            {
                int oldHotkeyId = hotkeyIds.FirstOrDefault(x => x.Value == button).Key;
                if (oldHotkeyId != 0)
                {
                    UnregisterHotKey(this.Handle, oldHotkeyId);
                    hotkeyIds.Remove(oldHotkeyId);
                }
                hotkeyBindings.Remove(button);
            }

            int hotkeyId = hotkeyCounter++;
            if (RegisterHotKey(this.Handle, hotkeyId, 0, (uint)key))
            {
                hotkeyBindings[button] = key;
                hotkeyIds[hotkeyId] = button;
                button.Text = key.ToString();
            }
            else
            {
                Notify($"Failed to register {button.Name}", "");
                button.Text = "None";
            }
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                int hotkeyId = m.WParam.ToInt32();
                if (hotkeyIds.ContainsKey(hotkeyId))
                {
                    Guna2GradientButton button = hotkeyIds[hotkeyId];

                    if (button == Kaimbotai)
                    {
                        EnableAimbotAI();
                    }
                    else if (button == Kaimbothead)
                    {
                        aimbothead.EnableAimbot2();
                    }
                    else if (button == Kaimdrag)
                    {
                        aimbotdrag.EnableAimbot2();
                    }
                    else if (button == Kaimneck)
                    {
                        aimbotneck.EnableAimbot2();
                    }
                    else if (button == Kspeed)
                    {
                        speedtimer.EnableSpeedTimer();
                    }
                    else if (button == Kwall)
                    {
                        wallhack.EnableWallHack();
                    }
                    else if (button == Kcamera)
                    {
                        camera.EnableCameraHack();
                    }
                    else if (button == Kcameraposition)
                    {
                        if (Bool.CameraPostion == 1)
                        {
                            Bool.CameraPostion = 2;
                            CameraBox.SelectedIndex = 2;
                        }
                        else if (Bool.CameraPostion == 2)
                        {
                            Bool.CameraPostion = 1;
                            CameraBox.SelectedIndex = 1;
                        }
                    }
                    else if(button == Kaimbotlegit)
                    {
                        aimbotlegit.EnableAimbotLegit();
                    }
                    else if(button == Klagauto)
                    {
                        fakelag.FakeLagA();
                    }
                    else if(button == Klagmanual)
                    {
                        fakelag.FakeLagM();
                    }
                }
            }
            base.WndProc(ref m);
        }
        #endregion





        #endregion
        public Home()
        {
            InitializeComponent();
            aimbotAI = new AimbotAI(this);
            aimbothead = new AimbotHead(this);
            aimbotlegit = new AimbotLegit(this);
            aimbotdrag = new AimbotDrag(this);
            aimbotneck = new AimbotNeck(this);
            aimbotbody = new AimbotBody(this);
            aimfov = new AimFov(this);
            recoil = new Recoil(this);
            guest = new Guest(this);
            scope = new ScopeTracking(this);
            camera = new Camera(this);
            awmscope = new AWMScope(this);
            awmswitch = new AWMSwitch(this);
            awmyswitch = new AWMYSwitch(this);
            m24fastswitch = new M24FastSwitch(this);
            m82bswitch = new M82BSwitch(this);
            sniperaim = new SniperAim(this);
            sniperdelayfix = new SniperDelayFix(this);
            sniperfov = new SniperFov(this);
            sniperscope = new SniperScope(this);
            sniperswitch = new SniperSwitch(this);
            snipertracking = new SniperTracking(this);
            wallhack = new WallHack(this);
            speedtimer = new SpeedTimer(this);
            glitchfire = new GlitchFire(this);
            chams4d = new Chams4D(this);
            chamshook = new ChamsHook(this);
            chamsmenu = new ChamsMenu(this);
            hiddenmenu = new HiddenMenu(this);
            fakelag = new FakeLag(this);
            newSniperScope = new NewSniperScope(this);
            headTracking = new HeadTracking(this);
            scopeXit = new ScopeXit(this);
            Chams = new Chams(this);
            femaleFix = new FemaleFix(this);
            aimbotBodyBrutal = new AimbotBodyBrutal(this);
            bypassWallHack = new BypassWallHack(this);
            newSniperSwitch = new NewSniperSwitch(this);
            aimLock = new AimLock(this);
            anticheat = new Anticheat(this);
            #region Normal
            //EnableBlur();
            _messageBoxes = new List<CustomNotification>();
            _messageBox = new CustomNotification
            {
                Visible = false,
                Dock = DockStyle.Bottom
            };
            this.Controls.Add(_messageBox);
            //notifyIcon = new NotifyIcon
            //{
            //    Icon = SystemIcons.Application,
            //    Visible = true
            //};
            #endregion
        }
        public enum NotifyOutput
        {
            Successful,
            Error
        }
        #region .
        private void CustomNotify(string message)
        {
            CustomNotification messageBox = new CustomNotification();
            this.Controls.Add(messageBox);

            Color baseColor = Color.FromArgb(99,7,0);

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

            messageBox.ShowMessage(message);

            activeMessageBoxes++;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2500;
            timer.Tick += (sender, e) =>
            {
                messageBox.HideMessage();
                activeMessageBoxes--;

                if (activeMessageBoxes > 0)
                {
                    foreach (Control control in this.Controls)
                    {
                        if (control is CustomNotification && control.Location.Y < lastMessageBoxY)
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
            status.Text = message;
        }
        private void WindowsNotify(string message)
        {
            //notifyIcon.ShowBalloonTip(4000, "BRUUUH CHEATS", message, ToolTipIcon.Info);
        }
        private void VadoNotify(string message)
        {
            if (message == "S")
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.activado);

                player.Play();
            }
            else if (message == "F")
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.desactivado);

                player.Play();
            }
        }
        private void BeepNotify(string message, string message1)
        {
            if (int.TryParse(message1, out int frequency))
            {
                int duration = frequency / 2;
                Console.Beep(frequency, duration);
            }
            else
            {
                CustomNotify("Invalid Beep Frequency");
            }
        }
        #endregion
        private static DateTime UnixTimeToDateTime(long unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixStart.AddSeconds(unixTime).ToLocalTime();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.Size = new Size(840, 552);
            panelAimbot.BringToFront();
            if (Bool.CanNotify)
            {
                Notify("Welcome", "400");
            }
            if (Login.KeyAuthApp.user_data != null)
            {
                string username = Login.KeyAuthApp.user_data.username;
                DateTime expiryDateTime = UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry));

                user.Text = $"{username}";
                expiry.Text = $"{expiryDateTime:yyyy/MM/dd}";
                Bool.rpc = false;
                RPC();
            }
            else
            {

            }
            LoadSettings();
        }
        private void Home_KeyDown(object sender, EventArgs e) { }
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var hotkeyId in hotkeyIds.Keys)
            {
                UnregisterHotKey(this.Handle, hotkeyId);
            }
        }
        private void EnableBlur()
        {
            var accent = new AccentPolicy()
            {
                nAccentState = (int)AccentState.ACCENT_ENABLE_BLURBEHIND,
                nFlags = 2,
                nColor = unchecked((int)0xA0000000),
                nAnimationId = 0
            };

            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData()
            {
                Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            SetWindowCompositionAttribute(this.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        internal enum AccentState
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_ENABLE_ACRYLICBLURBEHIND = 4
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #region Useless
        private void panelNavigation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userLbl_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void profilepic_Click(object sender, EventArgs e)
        {

        }
        private void guna2GradientPanel49_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel54_Paint(object sender, PaintEventArgs e)
        {

        }
        private void colorTransitionTimer_Tick(object sender, EventArgs e)
        {

        }
        private void panelKeybinds_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
        #region NavBar
        private void btnAimbotNav_Click(object sender, EventArgs e)
        {
            panelAimbot.BringToFront();
        }

        private void btnSniperNav_Click(object sender, EventArgs e)
        {
            //panelSniper.BringToFront();
            Notify("Under Update!","");
        }
        private void btnMiscNav_Click(object sender, EventArgs e)
        {
            panelMiscs.BringToFront();
            //MessageBox.Show("Under Update!", "BRUUUH CHEATS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVisualsNav_Click(object sender, EventArgs e)
        {
            panelVisuals.BringToFront();
        }
        private void btnSettingsNav_Click(object sender, EventArgs e)
        {
            panelSettings.BringToFront();

        }
        private void btnKeybindNav_Click(object sender, EventArgs e)
        {
            panelKeybinds.BringToFront();
        }
        #endregion

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region KeyBinds

        private void Kaimbothead_Click(object sender, EventArgs e)
        {
            CaptureAimbotHead();
        }

        private void Kaimdrag_Click(object sender, EventArgs e)
        {
            CaptureAimbotDrag();
        }
        private void Kaimneck_Click(object sender, EventArgs e)
        {
            CaptureAimbotNeck();
        }

        #endregion


        #region Functions
        private void Faimbothead_Click(object sender, EventArgs e)
        {
            if (Faimbothead.Checked)
                aimbothead.EnableAimbotHead();
            else
                aimbothead.DisableAimbotHead();
        }
        private void Faimbotdrag_Click(object sender, EventArgs e)
        {
            if (Faimbotdrag.Checked)
            {
                aimbotdrag.EnableAimbotDrag();
            }
            else
            {
                aimbotdrag.DisableAimbotDrag();
            }
        }

        private void Faimbotneck_Click(object sender, EventArgs e)
        {
            if (Faimbotneck.Checked)
            {
                aimbotneck.EnableAimbotNeck();
            }
            else
            {
                aimbotneck.DisableAimbotNeck();
            }
        }
        private void Faimfov_Click(object sender, EventArgs e)
        {
            if (Fscope4x.Checked)
                aimfov.EnableAimfov();
            else
                aimfov.DisableAimfov();
        }
        private void Fnorecoil_Click(object sender, EventArgs e)
        {
            if (Fnorecoil.Checked)
            {
                guest.EnableGuest();
            }
        }
        private void Fscope2x_Click(object sender, EventArgs e)
        {
            if (Fscope2x.Checked)
            {
                scope.EnableScopeTracking2X();
            }
            else
            {
                scope.DisableScopeTracking2X();
            }
        }
        #endregion

        public async void EnableAimbotAI()
        {
            await aimbotAI.InitAimbot(this);
        }
        public void DisableAimbotAI()
        {
            aimbotAI.DisableAimbot();
        }

        private void emulatorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = emulatorBox.SelectedIndex;

            switch (choice)
            {
                case 0:
                    Bool.is64Bit = false;
                    break;
                case 1:
                    Bool.is64Bit = true;
                    break;
            }
        }
        private void EnableAimbotFeature()
        {
            int selectedIndex = emulatorBox.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    Bool.is64Bit = false;
                    break;
                case 1:
                    Bool.is64Bit = true;
                    break;
                default:
                    Notify("Invalid Selection", "");
                    break;
            }
        }

        private void notifyBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Notify(string message, string message1)
        {
            int selectedIndex = notifyBox.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    if (Bool.CanNotify)
                    {
                        CustomNotify(message);
                        VadoNotify(message);
                        status.Text = message;
                    }
                    break;
                case 1:
                    if (Bool.CanNotify)
                    {
                        BeepNotify(message1, (int.Parse(message1) / 2).ToString());
                        status.Text = message;
                    }
                    break;
                case 2:
                    if (Bool.CanNotify)
                    {
                        CustomNotify(message);
                        WindowsNotify(message);
                        status.Text = message;
                    }
                    break;
                case 3:
                    if (Bool.CanNotify)
                    {
                        //CustomNotify(message);
                        //VadoNotify(message);
                        status.Text = message;
                    }
                    break;
                default:
                    if (Bool.CanNotify)
                    {
                        CustomNotify(message);
                        status.Text = message;
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Notify("Test","");
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

        }

        private void notification_Click(object sender, EventArgs e)
        {
            if (notification.Checked)
            {
                Bool.CanNotify = false;
            }
            else
            {
                Bool.CanNotify = true;
            }
        }

        private void notBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int not = notBox.SelectedIndex;

            switch (not)
            {
                case 0:
                    notification.Checked = true;
                    Bool.Strictdnd = false;
                    Bool.CanNotify = true;
                    break;

                case 1:
                    notification.Checked = true;
                    Bool.Strictdnd = true;
                    Bool.CanNotify = false;
                    break;
            }
        }

        private void othersmem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MemChoice = othersmem.SelectedIndex;

            switch (MemChoice)
            {
                case 0:
                    Bool.is64Bit = false;
                    Bool.OthersMem = 0;
                    break;
                case 1:
                    Bool.is64Bit = false;
                    Bool.OthersMem = 1;
                    break;
                case 2:
                    Bool.is64Bit = true;
                    Bool.OthersMem = 2;
                    break;
            }
        }

        private void aimmemory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MemChoice = aimmemory.SelectedIndex;

            switch (MemChoice)
            {
                case 0:
                    Bool.is64Bit = false;
                    Bool.AimbotMem = 0;
                    break;
                case 1:
                    Bool.is64Bit = false;
                    Bool.AimbotMem = 1;
                    break;
            }
        }

        private void label118_Click(object sender, EventArgs e)
        {

        }

        private void aimbotdelay_ValueChanged(object sender, EventArgs e)
        {
            if (aimbotdelay.Value < 1)
            {
                aimbotdelay.Value = 1;
            }
            else
            {
                Bool.AimbotDelay = (int)aimbotdelay.Value;
                if (aimbotdelay.Value == 1)
                {
                    aimbotdelayvalue.Text = aimbotdelay.Value.ToString() + " Second";
                }
                else if (aimbotdelay.Value > 1)
                {
                    aimbotdelayvalue.Text = aimbotdelay.Value.ToString() + " Seconds";
                }
            }

        }
        private void speeddelay_ValueChanged(object sender, EventArgs e)
        {
            if (speeddelay.Value < 1)
            {
                speeddelay.Value = 1;
            }
            else
            {

                Bool.SpeedDelay = (int)speeddelay.Value;
                if (speeddelay.Value == 1)
                {
                    speeddelayvalue.Text = speeddelay.Value.ToString() + " Second";
                }
                else if (speeddelay.Value > 1)
                {
                    speeddelayvalue.Text = speeddelay.Value.ToString() + " Seconds";
                }
            }
        }
        private void walldelay_ValueChanged(object sender, EventArgs e)
        {
            if (walldelay.Value < 1)
            {
                walldelay.Value = 1;
            }
            else
            {
                Bool.WallDelay = (int)walldelay.Value;
                if (walldelay.Value == 1)
                {
                    walldelayvalue.Text = walldelay.Value.ToString() + " Second";
                }
                else if (walldelay.Value > 1)
                {
                    walldelayvalue.Text = walldelay.Value.ToString() + " Seconds";
                }
            }
        }

        private void cameradelay_ValueChanged(object sender, EventArgs e)
        {
            if (cameradelay.Value < 1)
            {
                cameradelay.Value = 1;
            }
            else
            {
                Bool.CameraDelay = (int)cameradelay.Value;
                if (cameradelay.Value == 1)
                {
                    cameradelayvalue.Text = cameradelay.Value.ToString() + " Second";
                }
                else if (cameradelay.Value > 1)
                {
                    cameradelayvalue.Text = cameradelay.Value.ToString() + " Seconds";
                }
            }
        }

        private void speeddelayvalue_Click(object sender, EventArgs e)
        {

        }

        private void speeddelay_Load(object sender, EventArgs e)
        {

        }

        private void label105_Click(object sender, EventArgs e)
        {

        }
        #region Save
        private const string settingsFileName = "config.dat";
        private void SaveSettings()
        {
            string filePath = Path.Combine(Application.StartupPath, settingsFileName);

            try
            {
                string[] settings = new string[]
                {
                    rpc.Checked.ToString(),


                    notifyBox.SelectedIndex.ToString(),
                    emulatorBox.SelectedIndex.ToString(),
                    themeBox.SelectedIndex.ToString(),
                    aimmemory.SelectedIndex.ToString(),
                    othersmem.SelectedIndex.ToString(),
                    notBox.SelectedIndex.ToString(),


                    aimbotdelay.Value.ToString(),
                    speeddelay.Value.ToString(),
                    walldelay.Value.ToString(),
                    cameradelay.Value.ToString()
                };

                File.WriteAllLines(filePath, settings);
            }
            catch (Exception ex)
            {
                Notify("Error saving .dat file", "");
            }
            SaveToRegistry();
        }
        private void SaveToRegistry()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey(registryKey);
                regKey.SetValue("Discord RPC", rpc.Checked);

                regKey.SetValue("Notification Mode", notifyBox.SelectedIndex);
                regKey.SetValue("Emulator Mode", emulatorBox.SelectedIndex);
                regKey.SetValue("Theme Mode", themeBox.SelectedIndex);
                regKey.SetValue("Aimbot Memory", aimmemory.SelectedIndex);
                regKey.SetValue("Others Memory", othersmem.SelectedIndex);
                regKey.SetValue("Notification Type", notBox.SelectedIndex);


                regKey.SetValue("Aimbot Delay", aimbotdelay.Value);
                regKey.SetValue("Speed Delay", speeddelay.Value);
                regKey.SetValue("Wall Delay", walldelay.Value);
                regKey.SetValue("Camera Delay", cameradelay.Value);
                regKey.SetValue("Fake Lag Delay", Ffakelagtime.Value);

                regKey.Close();
            }
            catch (Exception ex)
            {
                Notify("Error saving to registry:", "");
            }
        }
        private void InitializeDefaults()
        {
            rpc.Checked = true;
            notifyBox.SelectedIndex = 0;
            emulatorBox.SelectedIndex = 0;
            themeBox.SelectedIndex = 0;
            aimmemory.SelectedIndex = 0;
            othersmem.SelectedIndex = 0;
            notBox.SelectedIndex = 0;

            aimbotdelay.Value = 1;
            speeddelay.Value = 1;
            walldelay.Value = 1;
            cameradelay.Value = 1;
            Ffakelagtime.Value = 1;
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
                        rpc.Checked = Convert.ToBoolean(settings[0]);

                        notifyBox.SelectedIndex = Convert.ToInt32(settings[1]);
                        emulatorBox.SelectedIndex = Convert.ToInt32(settings[2]);
                        themeBox.SelectedIndex = Convert.ToInt32(settings[3]);
                        aimmemory.SelectedIndex = Convert.ToInt32(settings[4]);
                        othersmem.SelectedIndex = Convert.ToInt32(settings[5]);
                        notBox.SelectedIndex = Convert.ToInt32(settings[5]);

                        aimbotdelay.Value = Convert.ToInt32(settings[6]);
                        speeddelay.Value = Convert.ToInt32(settings[7]);
                        walldelay.Value = Convert.ToInt32(settings[8]);
                        cameradelay.Value = Convert.ToInt32(settings[9]);
                        Ffakelagtime.Value = Convert.ToInt32(settings[9]);
                    }
                }
                catch (Exception ex)
                {
                    CustomNotify("Eror");
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
                    rpc.Checked = Convert.ToBoolean(regKey.GetValue("Discord RPC", false));


                    notifyBox.SelectedIndex = Convert.ToInt32(regKey.GetValue("Notification Mode", 0));
                    emulatorBox.SelectedIndex = Convert.ToInt32(regKey.GetValue("Emulator Modee", 0));
                    notifyBox.SelectedIndex = Convert.ToInt32(regKey.GetValue("Theme Mode", 0));
                    notifyBox.SelectedIndex = Convert.ToInt32(regKey.GetValue("Aimbot Memory", 0));
                    notifyBox.SelectedIndex = Convert.ToInt32(regKey.GetValue("Others Memory", 0));
                    notifyBox.SelectedIndex = Convert.ToInt32(regKey.GetValue("Notification Type", 0));

                    aimbotdelay.Value = Convert.ToInt32(regKey.GetValue("Aimbot Delay", 1));
                    speeddelay.Value = Convert.ToInt32(regKey.GetValue("Speed Delay", 1));
                    walldelay.Value = Convert.ToInt32(regKey.GetValue("Wall Delay", 1));
                    cameradelay.Value = Convert.ToInt32(regKey.GetValue("Camera Delay", 1));
                    Ffakelagtime.Value = Convert.ToInt32(regKey.GetValue("Fake Lag Delay", 1));

                    regKey.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Notify("Error loading from registry: ", "");
            }
            return false;
        }
        private void DeleteSavedSettings()
        {
            string filePath = Path.Combine(Application.StartupPath, settingsFileName);
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Notify("Settings file deleted.", "");
                }
            }
            catch (Exception ex)
            {
                Notify("Error deleting", "");
            }

            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(registryKey, writable: true);
                if (regKey != null)
                {
                    regKey.DeleteValue("Discord RPC", false);
                    regKey.DeleteValue("Notification Mode", false);
                    regKey.DeleteValue("Emulator Mode", false);
                    regKey.DeleteValue("Theme Mode", false);
                    regKey.DeleteValue("Aimbot Memory", false);
                    regKey.DeleteValue("Others Memory", false);
                    regKey.DeleteValue("Notification Type", false);
                    regKey.DeleteValue("Aimbot Delay", false);
                    regKey.DeleteValue("Speed Delay", false);
                    regKey.DeleteValue("Wall Delay", false);
                    regKey.DeleteValue("Camera Delay", false);
                    regKey.DeleteValue("Fake Lag Delay", false);

                    regKey.Close();
                    Notify("Registry values deleted.", "");
                }
            }
            catch (Exception ex)
            {
                Notify("Error deleting registry values.", ex.Message);
            }
        }
        #endregion
        #region Set
        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            extra.exit();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            extra.Restart();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            extra.discord();
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            extra.whatsapp();
        }
        #endregion

        private void saveall_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
        private bool RPC()
        {
            if (Bool.rpc)
            {
                rpc.Checked = true;
                RichStatus.rpctimestamp = Timestamps.Now;
                RichStatus.InitializeRPC();
                return true;
            }
            else
            {
                rpc.Checked = false;
                RichStatus.DisconnectRPC();
                return false;
            }
        }
        private void rpc_Click(object sender, EventArgs e)
        {
            if (rpc.Checked)
            {
                Bool.rpc = true;
                RPC();
            }
            else
            {
                Bool.rpc = false;
                RPC();
            }
        }

        private void themeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click_1(object sender, EventArgs e)
        {
            DeleteSavedSettings();
        }

        private void Home_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Kcameraposition_Click(object sender, EventArgs e)
        {
            CaptureCameraPostion();
        }
        private void BoxCamera()
        {
            int choice = CameraBox.SelectedIndex;

            switch (choice)
            {
                case 0:
                    Bool.CameraPostion = 0;
                    break;
                case 1:
                    Bool.CameraPostion = 1;
                    break;
                case 2:
                    Bool.CameraPostion = 2;
                    break;
            }
        }
        private void CameraBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = CameraBox.SelectedIndex;

            //MessageBox.Show("Selected Index: " + choice);

            switch (choice)
            {
                case 0:
                    Bool.CameraPostion = 0;
                    break;
                case 1:
                    Bool.CameraPostion = 1;
                    break;
                case 2:
                    Bool.CameraPostion = 2;
                    break;
            }

            //MessageBox.Show("CameraPostion: " + Bool.CameraPostion);
        }

        private void Fcamera_Click(object sender, EventArgs e)
        {
            if (Fcamera.Checked)
            {
                camera.EnableCameraHack();
            }
            else
            {
                camera.EnableCameraHack();
            }
        }

        private void Kreset_Click(object sender, EventArgs e)
        {
        }

        private void Kcamera_Click(object sender, EventArgs e)
        {
            CaptureCamera();
        }

        private void aimbotdelay_Load(object sender, EventArgs e)
        {

        }

        private void Fsniperscope_Click(object sender, EventArgs e)
        {
            if (Fsniperscope.Checked)
            {
                newSniperScope.LoadSniperScope();
            }
            else
            {
                newSniperScope.ClearMemory();
            }
        }

        private void Fsnipertracking_Click(object sender, EventArgs e)
        {
            if (Fsnipertracking.Checked)
            {
                snipertracking.EnableSniperTracking();
            }
        }

        private void Fsniperaim_Click(object sender, EventArgs e)
        {
            if (Fsniperaim.Checked)
            {
                sniperaim.EnableSniperAim();
            }
        }

        private void Fsniperfov_Click(object sender, EventArgs e)
        {
            if (Fsniperfov.Checked)
            {
                sniperfov.EnableSniperFov();
            }
        }

        private void Fsniperswitch_Click(object sender, EventArgs e)
        {
            if (Fsniperswitch.Checked)
            {
                if(Bool.GunSwitch == 0)
                {
                    newSniperSwitch.LoadSniperSwitch();
                }
                else if (Bool.GunSwitch == 1)
                {
                    awmswitch.EnableAWMSwitch();
                }
                else if (Bool.GunSwitch == 2)
                {
                    awmyswitch.EnableAWMYSwitch();
                }
                else if (Bool.GunSwitch == 3)
                {
                    m24fastswitch.EnableM24Switch();
                }
                else if (Bool.GunSwitch == 4)
                {
                    m82bswitch.EnableM82BSwitch();
                }
            }
        }

        private void Fsniperdelayfix_Click(object sender, EventArgs e)
        {
            if (Fsniperdelayfix.Checked)
            {
                sniperdelayfix.EnableSniperDelayFix();
            }
        }
        public void GunSwitch()
        {
            int choice = SwitchBox.SelectedIndex;
            switch (choice)
            {
                case 0:
                    Bool.GunSwitch = 0;
                    break;
                case 1:
                    Bool.GunSwitch = 1;
                    break;
                case 2:
                    Bool.GunSwitch = 2;
                    break;
            }
        }
        private void SwitchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GunSwitch();
        }
        public void WallHackType()
        {
            int choice = WallBox.SelectedIndex;
            switch (choice)
            {
                case 0:
                    Bool.WallType = 0;
                    break;
                case 1:
                    Bool.WallType = 1;
                    break;
                case 2:
                    Bool.WallType = 2;
                    break;
            }
        }
        private void WallBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WallHackType();
        }

        private void Fwall_Click(object sender, EventArgs e)
        {
            if (Fwall.Checked)
            {
                wallhack.EnableWallHack();
            }
            else
            {
            }
        }

        private void guna2GradientPanel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel40_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel57_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel58_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fspeed10x_Click(object sender, EventArgs e)
        {

        }

        private void panelMiscs_Paint(object sender, PaintEventArgs e)
        {

        }
        public void SpeedLoad()
        {
            if (Bool.OthersMem == 0)
            {
                speedtimer.LoadSpeedTimer1();
            }
            else if (Bool.OthersMem > 1)
            {
                speedtimer.LoadSpeedTimer2();
            }
        }
        private void Floadspeed_Click(object sender, EventArgs e)
        {
            if (Floadspeed.Checked)
            {
                SpeedLoad();
            }
        }

        private void Fspeedtimer_Click(object sender, EventArgs e)
        {
            if (Fspeedtimer.Checked)
            {
                speedtimer.EnableSpeedTimer();
            }
        }

        private void Fglitchfire_Click(object sender, EventArgs e)
        {
            //if(Fglitchfire.Checked)
            //{
            //    glitchfire.EnableGlitchFire();
            //}
            //else
            //{
            //    glitchfire.EnableGlitchFire();
            //}
        }

        private void Floadglicthfire_Click(object sender, EventArgs e)
        {
            //if (Floadglicthfire.Checked)
            //{
            //    glitchfire.EnableGlitchFire();
            //}
            //else
            //{
            //    glitchfire.EnableGlitchFire();
            //}
        }

        private void Faimbotlegit_Click(object sender, EventArgs e)
        {
            if(Faimbotlegit.Checked)
            {
                aimbotlegit.EnableAimbotLegit();
            }
        }

        private void Kaimbotlegit_Click(object sender, EventArgs e)
        {
            CaptureAimbotLegit();
        }

        private void panelVisuals_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fchams4d_Click(object sender, EventArgs e)
        {
            chams4d.EnableChams4D();
        }

        private void startChams_Click(object sender, EventArgs e)
        {
            if (startChams.Checked)
            {
                chamshook.EnableChamsHook();
            }
        }
        public void MenuType()
        {
            int choice = menuBox.SelectedIndex;
            switch (choice)
            {
                case 0:
                    Bool.ChamsMenu = 0;
                    break;
                case 1:
                    Bool.ChamsMenu = 1;
                    break;
                case 2:
                    Bool.ChamsMenu = 2;
                    break;
                case 3:
                    Bool.ChamsMenu = 3;
                    break;
            }
        }
        private void menuBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = menuBox.SelectedIndex;
            switch (choice)
            {
                case 0:
                    MenuType();
                    break;
                case 1:
                    MenuType();
                    break;
                case 2:
                    MenuType();
                    break;
                case 3:
                    MenuType();
                    break;
            }
        }

        private void panelAimbot_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Kspeed_Click(object sender, EventArgs e)
        {
            CaptureSpeed();
        }

        private void Kwall_Click(object sender, EventArgs e)
        {
            CaptureWall();
        }
        //Already Initialized

        //void DetermineMenu()
        //{
        //    if(Bool.ChamsMenu == 0)
        //    {

        //    }
        //    else if(Bool.ChamsMenu == 1)
        //    {

        //    }
        //    else if(Bool.ChamsMenu == 2)
        //    {

        //    }
        //    else if(Bool.ChamsMenu == 3)
        //    {

        //    }
        //}
        private void Fchamsmenu_Click(object sender, EventArgs e)
        {
            if (Fchamsmenu.Checked)
            {
                if (menuBox.SelectedIndex == 0)
                {
                    chamsmenu.ChamsMenuNormal();
                }
                else if (menuBox.SelectedIndex == 1)
                {
                    chamsmenu.ChamsMenuNormalV2();
                }
                else if (menuBox.SelectedIndex == 2)
                {
                    chamsmenu.ChamsMenuOverlay();
                }
                else if (menuBox.SelectedIndex == 3)
                {
                    chamsmenu.ChamsMenuOverlayV2();
                }
            }
        }

        private void Fchamshidden_Click(object sender, EventArgs e)
        {
            if (Fchamshidden.Checked)
            {
                //hiddenmenu.InjectMenu("PREMIUM_6._0.opengl32");
            }
        }

        private void bruuuhCustomSlider1_Load(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void cameradelay_Load(object sender, EventArgs e)
        {

        }

        private void Ffakelagtime_ValueChanged(object sender, EventArgs e)
        {
            if (Ffakelagtime.Value < 1)
            {
                Ffakelagtime.Value = 1;
            }
            else
            {
                Bool.FakeLag = (int)Ffakelagtime.Value;
                if (Ffakelagtime.Value == 1)
                {
                    lagvalue.Text = Ffakelagtime.Value.ToString() + " Second";
                }
                else if (Ffakelagtime.Value > 1)
                {
                    lagvalue.Text = Ffakelagtime.Value.ToString() + " Second";
                }
            }
        }

        private void Ffakelagauto_Click(object sender, EventArgs e)
        {
            if (Ffakelagauto.Checked)
            {
                fakelag.FakeLagA();
            }
            else
            {
                fakelag.FakeLagA();
            }
        }

        private void Ffakelagmanual_Click(object sender, EventArgs e)
        {
            if (Ffakelagmanual.Checked)
            {
                fakelag.FakeLagM();
            }
            else
            {
                fakelag.FakeLagM();
            }
        }

        private void Klagauto_Click(object sender, EventArgs e)
        {
            CaptureFakeLagA();
        }

        private void Klagmanual_Click(object sender, EventArgs e)
        {
            CaptureFakeLagM();
        }

        private void noRecoilchk_Click(object sender, EventArgs e)
        {
            if (noRecoilchk.Checked)
                recoil.EnableNoRecoil();
            else
                recoil.DisableNoRecoil();
        }

        private void aimbotBodychk_Click(object sender, EventArgs e)
        {
            if (aimbotBodychk.Checked)
            {
                aimbotbody.EnableAimbotBody();
            }
        }

        private void guna2ImageButton9_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel71_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomCheckBox7_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2GradientPanel94_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomCheckBox5_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox5.Checked)
                headTracking.EnableHeadTracking();
            else
                headTracking.DisableHeadTracking();
        }

        private void guna2CustomCheckBox7_Click_1(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox7.Checked)
                scope.EnableScopeTracking4X();
            else
                scope.DisbleScopeTracking4X();
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked)
                Chams.EnableChams4dKey();
        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox2.Checked)
                Chams.EnableChamsWukong();
        }

        private void guna2CustomCheckBox3_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox3.Checked)
                Chams.EnableChamsWukongCharacter();
        }

        private void guna2CustomCheckBox14_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox14.Checked)
                Chams.EnableChams2D();
        }

        private void guna2CustomCheckBox16_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox16.Checked)
                Chams.EnableGlow();
        }

        private void guna2CustomCheckBox15_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox15.Checked)
                Chams.EnableHDRMap();
        }

        private void guna2CustomCheckBox4_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox4.Checked)
                hiddenmenu.SetupHiddenMenu();
        }

        private void guna2CustomCheckBox17_Click(object sender, EventArgs e)
        {
            if(guna2CustomCheckBox17.Checked)
                sniperdelayfix.EnableSniperDelayFix();
        }

        private void guna2GradientPanel101_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkfemalefix_Click(object sender, EventArgs e)
        {
            if (chkfemalefix.Checked)
                femaleFix.EnableFemaleFix();
            else
                femaleFix.DisableFemaleFix();
        }

        private void guna2CustomCheckBox18_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox18.Checked)
                bypassWallHack.EnableBypassWallHack();
        }

        private void chkAimLock_Click(object sender, EventArgs e)
        {
            if (chkAimLock.Checked)
                aimLock.EnableAimLock();
            else
                aimLock.DisableAimLock();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int choice = aimbotaimode.SelectedIndex;

            switch (choice)
            {
                case 0:
                    Bool.AimbotAIMode = "NORMAL";
                    break;
                case 1:
                    Bool.AimbotAIMode = "LEGIT";
                    break;
                case 2:
                    Bool.AimbotAIMode = "LEGITV2";
                    break;
            }
        }

        private void guna2CustomCheckBox19_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox19.Checked)
                aimbotBodyBrutal.EnableAimbotBodyBrutal();
        }

        private void Kaimbotai_Click(object sender, EventArgs e)
        {
            CaptureAimbotAI();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            EnableAimbotAI();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DisableAimbotAI();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            anticheat.EnableAnticheat();
        }

        private void guna2CustomCheckBox20_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox20.Checked)
            {
                newSniperScope.LoadSniperScope();
            }
            else
            {
                newSniperScope.ClearMemory();
            }
        }
    }
}


