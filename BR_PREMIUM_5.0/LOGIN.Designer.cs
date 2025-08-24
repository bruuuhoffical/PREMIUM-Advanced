namespace BR_PREMIUM_5._0
{
    partial class LOGIN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            this.loginLogotext = new System.Windows.Forms.Label();
            this.particleTimer = new System.Windows.Forms.Timer(this.components);
            this.loginbtn = new Guna.UI2.WinForms.Guna2Button();
            this.autofill = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.autofilllabel = new System.Windows.Forms.Label();
            this.exit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.minimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.loginborderless = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.tiktok = new Guna.UI2.WinForms.Guna2ImageButton();
            this.youtube = new Guna.UI2.WinForms.Guna2ImageButton();
            this.whatsapp = new Guna.UI2.WinForms.Guna2ImageButton();
            this.discord = new Guna.UI2.WinForms.Guna2ImageButton();
            this.key = new Guna.UI2.WinForms.Guna2TextBox();
            this.password = new Guna.UI2.WinForms.Guna2TextBox();
            this.username = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // loginLogotext
            // 
            this.loginLogotext.AutoSize = true;
            this.loginLogotext.BackColor = System.Drawing.Color.Transparent;
            this.loginLogotext.Font = new System.Drawing.Font("Nevan RUS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLogotext.ForeColor = System.Drawing.Color.Yellow;
            this.loginLogotext.Location = new System.Drawing.Point(119, 24);
            this.loginLogotext.Name = "loginLogotext";
            this.loginLogotext.Size = new System.Drawing.Size(612, 83);
            this.loginLogotext.TabIndex = 0;
            this.loginLogotext.Text = "BRUUUH CHEATS";
            this.loginLogotext.Click += new System.EventHandler(this.loginLogotext_Click);
            // 
            // particleTimer
            // 
            this.particleTimer.Enabled = true;
            this.particleTimer.Interval = 2;
            this.particleTimer.Tick += new System.EventHandler(this.particleTimer_Tick);
            // 
            // loginbtn
            // 
            this.loginbtn.Animated = true;
            this.loginbtn.BackColor = System.Drawing.Color.Transparent;
            this.loginbtn.BorderRadius = 5;
            this.loginbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.loginbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.loginbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.loginbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.loginbtn.FillColor = System.Drawing.Color.Yellow;
            this.loginbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.loginbtn.ForeColor = System.Drawing.Color.DimGray;
            this.loginbtn.Location = new System.Drawing.Point(257, 348);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(326, 38);
            this.loginbtn.TabIndex = 4;
            this.loginbtn.Text = "Login";
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // autofill
            // 
            this.autofill.Animated = true;
            this.autofill.BackColor = System.Drawing.Color.Transparent;
            this.autofill.CheckedState.BorderRadius = 2;
            this.autofill.CheckedState.BorderThickness = 0;
            this.autofill.CheckedState.FillColor = System.Drawing.Color.Yellow;
            this.autofill.Location = new System.Drawing.Point(257, 404);
            this.autofill.Name = "autofill";
            this.autofill.Size = new System.Drawing.Size(20, 20);
            this.autofill.TabIndex = 9;
            this.autofill.UncheckedState.BorderRadius = 2;
            this.autofill.UncheckedState.BorderThickness = 0;
            this.autofill.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.autofill.UseTransparentBackground = true;
            this.autofill.Click += new System.EventHandler(this.autofill_Click);
            // 
            // autofilllabel
            // 
            this.autofilllabel.AutoSize = true;
            this.autofilllabel.BackColor = System.Drawing.Color.Transparent;
            this.autofilllabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autofilllabel.Location = new System.Drawing.Point(283, 406);
            this.autofilllabel.Name = "autofilllabel";
            this.autofilllabel.Size = new System.Drawing.Size(63, 16);
            this.autofilllabel.TabIndex = 10;
            this.autofilllabel.Text = "Auto Fill";
            this.autofilllabel.Click += new System.EventHandler(this.autofilllabel_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.Animated = true;
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.FillColor = System.Drawing.Color.Transparent;
            this.exit.IconColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(810, 3);
            this.exit.Name = "exit";
            this.exit.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.exit.Size = new System.Drawing.Size(33, 30);
            this.exit.TabIndex = 11;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // minimize
            // 
            this.minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimize.Animated = true;
            this.minimize.BackColor = System.Drawing.Color.Transparent;
            this.minimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.minimize.FillColor = System.Drawing.Color.Transparent;
            this.minimize.IconColor = System.Drawing.Color.White;
            this.minimize.Location = new System.Drawing.Point(771, 3);
            this.minimize.Name = "minimize";
            this.minimize.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.minimize.Size = new System.Drawing.Size(33, 30);
            this.minimize.TabIndex = 12;
            // 
            // loginborderless
            // 
            this.loginborderless.AnimateWindow = true;
            this.loginborderless.BorderRadius = 10;
            this.loginborderless.ContainerControl = this;
            this.loginborderless.DockForm = false;
            this.loginborderless.DockIndicatorTransparencyValue = 0.6D;
            this.loginborderless.DragStartTransparencyValue = 1D;
            this.loginborderless.HasFormShadow = false;
            this.loginborderless.ResizeForm = false;
            this.loginborderless.ShadowColor = System.Drawing.Color.Yellow;
            this.loginborderless.TransparentWhileDrag = true;
            // 
            // tiktok
            // 
            this.tiktok.BackColor = System.Drawing.Color.Transparent;
            this.tiktok.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.tiktok.HoverState.ImageSize = new System.Drawing.Size(32, 32);
            this.tiktok.Image = ((System.Drawing.Image)(resources.GetObject("tiktok.Image")));
            this.tiktok.ImageOffset = new System.Drawing.Point(0, 0);
            this.tiktok.ImageRotate = 0F;
            this.tiktok.ImageSize = new System.Drawing.Size(20, 20);
            this.tiktok.Location = new System.Drawing.Point(801, 492);
            this.tiktok.Name = "tiktok";
            this.tiktok.PressedState.ImageSize = new System.Drawing.Size(32, 32);
            this.tiktok.Size = new System.Drawing.Size(37, 32);
            this.tiktok.TabIndex = 8;
            this.tiktok.Visible = false;
            this.tiktok.Click += new System.EventHandler(this.tiktok_Click);
            // 
            // youtube
            // 
            this.youtube.BackColor = System.Drawing.Color.Transparent;
            this.youtube.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.youtube.HoverState.ImageSize = new System.Drawing.Size(32, 32);
            this.youtube.Image = ((System.Drawing.Image)(resources.GetObject("youtube.Image")));
            this.youtube.ImageOffset = new System.Drawing.Point(0, 0);
            this.youtube.ImageRotate = 0F;
            this.youtube.ImageSize = new System.Drawing.Size(20, 20);
            this.youtube.Location = new System.Drawing.Point(758, 492);
            this.youtube.Name = "youtube";
            this.youtube.PressedState.ImageSize = new System.Drawing.Size(32, 32);
            this.youtube.Size = new System.Drawing.Size(37, 32);
            this.youtube.TabIndex = 7;
            this.youtube.Visible = false;
            // 
            // whatsapp
            // 
            this.whatsapp.BackColor = System.Drawing.Color.Transparent;
            this.whatsapp.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.whatsapp.HoverState.ImageSize = new System.Drawing.Size(32, 32);
            this.whatsapp.Image = ((System.Drawing.Image)(resources.GetObject("whatsapp.Image")));
            this.whatsapp.ImageOffset = new System.Drawing.Point(0, 0);
            this.whatsapp.ImageRotate = 0F;
            this.whatsapp.ImageSize = new System.Drawing.Size(20, 20);
            this.whatsapp.Location = new System.Drawing.Point(55, 492);
            this.whatsapp.Name = "whatsapp";
            this.whatsapp.PressedState.ImageSize = new System.Drawing.Size(32, 32);
            this.whatsapp.Size = new System.Drawing.Size(37, 32);
            this.whatsapp.TabIndex = 6;
            this.whatsapp.Visible = false;
            this.whatsapp.Click += new System.EventHandler(this.whatsapp_Click);
            // 
            // discord
            // 
            this.discord.BackColor = System.Drawing.Color.Transparent;
            this.discord.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.discord.HoverState.ImageSize = new System.Drawing.Size(32, 32);
            this.discord.Image = ((System.Drawing.Image)(resources.GetObject("discord.Image")));
            this.discord.ImageOffset = new System.Drawing.Point(0, 0);
            this.discord.ImageRotate = 0F;
            this.discord.ImageSize = new System.Drawing.Size(20, 20);
            this.discord.Location = new System.Drawing.Point(12, 492);
            this.discord.Name = "discord";
            this.discord.PressedState.ImageSize = new System.Drawing.Size(32, 32);
            this.discord.Size = new System.Drawing.Size(37, 32);
            this.discord.TabIndex = 5;
            this.discord.Visible = false;
            this.discord.Click += new System.EventHandler(this.discord_Click);
            // 
            // key
            // 
            this.key.Animated = true;
            this.key.BackColor = System.Drawing.Color.Transparent;
            this.key.BorderColor = System.Drawing.Color.Yellow;
            this.key.BorderRadius = 4;
            this.key.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.key.DefaultText = "";
            this.key.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.key.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.key.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.key.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.key.FillColor = System.Drawing.Color.Transparent;
            this.key.FocusedState.BorderColor = System.Drawing.Color.Yellow;
            this.key.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.key.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.key.IconRight = global::BR_PREMIUM.Properties.Resources.keyyelloe;
            this.key.Location = new System.Drawing.Point(257, 287);
            this.key.Name = "key";
            this.key.PasswordChar = '\0';
            this.key.PlaceholderText = "License";
            this.key.SelectedText = "";
            this.key.Size = new System.Drawing.Size(326, 38);
            this.key.TabIndex = 3;
            this.key.Enter += new System.EventHandler(this.LOGIN_Enter);
            // 
            // password
            // 
            this.password.Animated = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.BorderColor = System.Drawing.Color.Yellow;
            this.password.BorderRadius = 4;
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.DefaultText = "";
            this.password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.FillColor = System.Drawing.Color.Transparent;
            this.password.FocusedState.BorderColor = System.Drawing.Color.Yellow;
            this.password.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.password.IconRight = global::BR_PREMIUM.Properties.Resources.padlockyellow;
            this.password.Location = new System.Drawing.Point(257, 236);
            this.password.Name = "password";
            this.password.PasswordChar = '\0';
            this.password.PlaceholderText = "Password";
            this.password.SelectedText = "";
            this.password.Size = new System.Drawing.Size(326, 38);
            this.password.TabIndex = 2;
            this.password.Enter += new System.EventHandler(this.LOGIN_Enter);
            // 
            // username
            // 
            this.username.Animated = true;
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.BorderColor = System.Drawing.Color.Yellow;
            this.username.BorderRadius = 4;
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.DefaultText = "";
            this.username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.FillColor = System.Drawing.Color.Transparent;
            this.username.FocusedState.BorderColor = System.Drawing.Color.Yellow;
            this.username.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.username.IconRight = global::BR_PREMIUM.Properties.Resources.useryellow;
            this.username.Location = new System.Drawing.Point(257, 185);
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PlaceholderText = "Username";
            this.username.SelectedText = "";
            this.username.Size = new System.Drawing.Size(326, 38);
            this.username.TabIndex = 1;
            this.username.Enter += new System.EventHandler(this.LOGIN_Enter);
            // 
            // LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(851, 536);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.autofilllabel);
            this.Controls.Add(this.autofill);
            this.Controls.Add(this.tiktok);
            this.Controls.Add(this.youtube);
            this.Controls.Add(this.whatsapp);
            this.Controls.Add(this.discord);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.key);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.loginLogotext);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOGIN";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRUUUH LOGIN";
            this.Load += new System.EventHandler(this.LOGIN_Load);
            this.Click += new System.EventHandler(this.LOGIN_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LOGIN_Paint);
            this.Enter += new System.EventHandler(this.LOGIN_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLogotext;
        private System.Windows.Forms.Timer particleTimer;
        private Guna.UI2.WinForms.Guna2TextBox username;
        private Guna.UI2.WinForms.Guna2TextBox password;
        private Guna.UI2.WinForms.Guna2TextBox key;
        private Guna.UI2.WinForms.Guna2Button loginbtn;
        private Guna.UI2.WinForms.Guna2ImageButton discord;
        private Guna.UI2.WinForms.Guna2ImageButton whatsapp;
        private Guna.UI2.WinForms.Guna2ImageButton youtube;
        private Guna.UI2.WinForms.Guna2ImageButton tiktok;
        private Guna.UI2.WinForms.Guna2CustomCheckBox autofill;
        private System.Windows.Forms.Label autofilllabel;
        private Guna.UI2.WinForms.Guna2ControlBox exit;
        private Guna.UI2.WinForms.Guna2ControlBox minimize;
        private Guna.UI2.WinForms.Guna2BorderlessForm loginborderless;
    }
}

