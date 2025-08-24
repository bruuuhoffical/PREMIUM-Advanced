using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using PREMIUM_6._0.Libaries;
using System.Drawing;
using System.Drawing.Drawing2D;
using KeyAuth;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections.Generic;
using System.Web.Configuration;



namespace PREMIUM_6._0.Views
{
    public partial class Login : Form
    {
        Additional Additional = new Additional();
        private Color borderColor = Color.DarkRed;
        private int borderThickness = 2;
        private int cornerRadius = 10;


        private const string registryKey = @"Software\BRUUUH_PRIVATE";
        private const string usernameValue = "Username";
        private const string passwordValue = "Password";
        private const string autofillValue = "Autofill";

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
        public Login()
        {
            InitializeComponent();
            KeyAuthApp.init();
            //EnableBlur();
        }
        public static api KeyAuthApp = new api(
        name: "PRIVATE",
        ownerid: "dm7J81olTD",
        version: "1.1"
        );
        private void Exit_Click(object sender, EventArgs e)
        {
            Additional.exit();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(borderThickness, borderThickness, cornerRadius, cornerRadius, 180, 90); // Top-left corner
                path.AddArc(this.Width - cornerRadius - borderThickness - 1, borderThickness, cornerRadius, cornerRadius, 270, 90); // Top-right corner
                path.AddArc(this.Width - cornerRadius - borderThickness - 1, this.Height - cornerRadius - borderThickness - 1, cornerRadius, cornerRadius, 0, 90); // Bottom-right corner
                path.AddArc(borderThickness, this.Height - cornerRadius - borderThickness - 1, cornerRadius, cornerRadius, 90, 90); // Bottom-left corner
                path.CloseFigure();

                using (Pen borderPen = new Pen(borderColor, borderThickness))
                {
                    g.DrawPath(borderPen, path);
                }
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

        private void Login_Load(object sender, EventArgs e)
        {
            //CustomNotify("Welcome");
            if (IsAutofillEnabled())
            {
                txtUser.Text = GetFromRegistry(usernameValue);
                txtPass.Text = GetFromRegistry(passwordValue);
            }
        }


        private void txtUser_TextChanged(object sender, EventArgs e)
        {
        }
        private List<CustomNotification> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private CustomNotification _messageBox;
        private void CustomNotify(string message)
        {
            CustomNotification messageBox = new CustomNotification();
            this.Controls.Add(messageBox);

            Color baseColor = logo.ForeColor;

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

            Timer timer = new Timer { Interval = 3000 };
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
                    lastMessageBoxY = this.ClientSize.Height - messageBox.Height - -10;
                }

                timer.Stop();
            };
            timer.Start();
        }
        #region AutoFill
        private void SaveToRegistry(string username, string password)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryKey))
                {
                    key.SetValue(usernameValue, username);
                    key.SetValue(passwordValue, password);
                    key.SetValue(autofillValue, true);
                }
            }
            catch (Exception ex)
            {
                CustomNotify("Unable to Save");
            }
        }

        private string GetFromRegistry(string valueName)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey))
                {
                    if (key != null && key.GetValue(valueName) != null)
                    {
                        return key.GetValue(valueName).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomNotify("Unable to Read");
            }

            return string.Empty;
        }

        private bool IsAutofillEnabled()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey))
                {
                    if (key != null && key.GetValue(autofillValue) != null)
                    {
                        return Convert.ToBoolean(key.GetValue(autofillValue));
                    }
                }
            }
            catch (Exception ex)
            {
                CustomNotify("Unable to Check");
            }

            return false;
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(txtUser.Text, txtPass.Text);
            if (KeyAuthApp.response.success)
            {
                if (rememberme.Checked)
                {
                    SaveToRegistry(txtUser.Text, txtPass.Text);
                }
                Home BRUUUH = new Home();
                BRUUUH.Show();
                this.Hide();
            }
            else
            {
                //CustomNotify(KeyAuthApp.response.message);
                CustomNotify("Error");
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
