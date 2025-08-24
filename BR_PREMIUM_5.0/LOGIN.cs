using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using KeyAuth;

namespace BR_PREMIUM_5._0
{
    public partial class LOGIN : Form
    {
        private ParticleSystem particleSystem;
        private Timer animationTimer;
        private const string registryKey = @"Software\BRUUUH_PREMIUM";
        private const string usernameValue = "Username";
        private const string passwordValue = "Password";
        private const string autofillValue = "Autofill";
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;
        public LOGIN()
        {
            InitializeComponent();
            KeyAuthApp.init();
            _messageBoxes = new List<MessageBoxControl>();
            _messageBox = new MessageBoxControl
            {
                Visible = false,
                Dock = DockStyle.Bottom
            };
            this.Controls.Add(_messageBox);
            #region Particles
            particleSystem = new ParticleSystem();
            #endregion
        }
        public static api KeyAuthApp = new api(
        name: "CV_PREMIUM",
        ownerid: "JOzxAPywrc",
        version: "3.9"
        );
    #region Particles
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            particleSystem.DrawParticles(e.Graphics);
        }
        #endregion
        private void particleTimer_Tick(object sender, EventArgs e)
        {
            particleSystem.UpdateParticles();
            Invalidate();
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
                MessageBox.Show("Error saving to registry: " + ex.Message);
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
                MessageBox.Show("Error reading from registry: " + ex.Message);
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
                MessageBox.Show("Error checking registry value: " + ex.Message);
            }

            return false;
        }
        #endregion
        //private void ShowMessage(string message, string status, string imageKey)
        //{
        //    MessageBoxControl messageBox = new MessageBoxControl();
        //    this.Controls.Add(messageBox);
        //    messageBox.BringToFront();
        //    messageBox.ShowMessage(message, status, imageKey);

        //    if (_messageBoxes.Count > 0)
        //    {
        //        var lastMessageBox = _messageBoxes.Last();
        //        messageBox.Location = new Point(lastMessageBox.Left, lastMessageBox.Top - lastMessageBox.Height - 5);
        //    }
        //    else
        //    {
        //        messageBox.Location = new Point(this.ClientSize.Width - messageBox.Width - 10, this.ClientSize.Height - messageBox.Height - 10);
        //    }

        //    _messageBoxes.Add(messageBox);
        //}

        //private void ShowCustomMessage(string message, string status, string imageKey, int duration = 5000)
        //{
        //    _messageBox.ShowMessage(message, status, imageKey, duration);
        //}

        private void ShowMessageBox(string message, string status, string imageKey)
        {
            MessageBoxControl messageBox = new MessageBoxControl();
            this.Controls.Add(messageBox);

            Color baseColor = loginLogotext.ForeColor; // This can be any base color you wish

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

            // Pass the correct status color (message status determines the color)
            messageBox.ShowMessage(message, status, imageKey, baseColor);

            activeMessageBoxes++;

            Timer timer = new Timer { Interval = 5000 }; // Duration for how long the message is visible
            timer.Tick += (sender, e) =>
            {
                messageBox.HideMessage(); // Hide the message after the timer ends
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


        private void LOGIN_Load(object sender, EventArgs e)
        {
            //this.Focus();
            loginLogotext.Focus();
            ShowMessageBox("Welcome", "cool", "");
            if (IsAutofillEnabled())
            {
                username.Text = GetFromRegistry(usernameValue);
                password.Text = GetFromRegistry(passwordValue);
            }
        }

        private void autofill_Click(object sender, EventArgs e)
        {

        }

        private void discord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/bruuuhcheats");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logotimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(username.Text, password.Text);
            if (KeyAuthApp.response.success)
            {
                if (autofill.Checked)
                {
                    SaveToRegistry(username.Text, password.Text);
                }
                HOME BRUUUH = new HOME();
                BRUUUH.Show();
                this.Hide();
            }
            else
            {
                ShowMessageBox(KeyAuthApp.response.message, "failed", "failed");
            }
            loginbtn.Focus();
        }

        private void whatsapp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://wa.link/x620yy");
        }

        private void tiktok_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vm.tiktok.com/ZMkB4YAhE/");
        }

        private void autofilllabel_Click(object sender, EventArgs e)
        {
            autofilllabel.Focus();
            if (autofill.Checked)
            {
                autofill.Checked = false;
            }
            else
            {
                autofill.Checked = true;
            }
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            //this.Focus();
            loginLogotext.Focus();
        }

        private void loginLogotext_Click(object sender, EventArgs e)
        {
            loginLogotext.Focus();
        }

        private void LOGIN_Enter(object sender, EventArgs e)
        {

        }

        private void LOGIN_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.Yellow;
            int borderThickness = 3;

            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
