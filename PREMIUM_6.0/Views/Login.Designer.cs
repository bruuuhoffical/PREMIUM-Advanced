namespace PREMIUM_6._0.Views
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Exit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.borderlessform = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.logo = new System.Windows.Forms.Label();
            this.btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtKey = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.rememberme = new Guna.UI2.WinForms.Guna2CheckBox();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Exit.BorderRadius = 10;
            this.Exit.FillColor = System.Drawing.Color.Transparent;
            this.Exit.ForeColor = System.Drawing.Color.Transparent;
            this.Exit.IconColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(284, 0);
            this.Exit.Name = "Exit";
            this.Exit.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Exit.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Exit.ShadowDecoration.Depth = 40;
            this.Exit.ShadowDecoration.Enabled = true;
            this.Exit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Exit.Size = new System.Drawing.Size(35, 30);
            this.Exit.TabIndex = 0;
            this.Exit.UseTransparentBackground = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // borderlessform
            // 
            this.borderlessform.AnimateWindow = true;
            this.borderlessform.AnimationInterval = 550;
            this.borderlessform.BorderRadius = 11;
            this.borderlessform.ContainerControl = this;
            this.borderlessform.DockForm = false;
            this.borderlessform.DockIndicatorTransparencyValue = 0.6D;
            this.borderlessform.DragEndTransparencyValue = 0.9D;
            this.borderlessform.HasFormShadow = false;
            this.borderlessform.ResizeForm = false;
            this.borderlessform.ShadowColor = System.Drawing.Color.Red;
            this.borderlessform.TransparentWhileDrag = true;
            // 
            // logo
            // 
            this.logo.AutoSize = true;
            this.logo.Font = new System.Drawing.Font("Nevan RUS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logo.ForeColor = System.Drawing.Color.Silver;
            this.logo.Location = new System.Drawing.Point(66, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(189, 46);
            this.logo.TabIndex = 1;
            this.logo.Text = "BRUUUH";
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderRadius = 5;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.DarkRed;
            this.btnLogin.FillColor2 = System.Drawing.Color.Transparent;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(42, 269);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(237, 38);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtKey
            // 
            this.txtKey.AcceptsReturn = true;
            this.txtKey.AcceptsTab = true;
            this.txtKey.AllowDrop = true;
            this.txtKey.Animated = true;
            this.txtKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtKey.BorderRadius = 1;
            this.txtKey.BorderThickness = 2;
            this.txtKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKey.DefaultText = "";
            this.txtKey.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKey.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKey.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKey.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKey.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtKey.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtKey.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtKey.HoverState.BorderColor = System.Drawing.Color.Maroon;
            this.txtKey.IconRight = global::PREMIUM_6._0.Properties.Resources.key;
            this.txtKey.IconRightSize = new System.Drawing.Size(24, 22);
            this.txtKey.Location = new System.Drawing.Point(42, 206);
            this.txtKey.Name = "txtKey";
            this.txtKey.PlaceholderText = "Key";
            this.txtKey.SelectedText = "";
            this.txtKey.Size = new System.Drawing.Size(237, 40);
            this.txtKey.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtKey.TabIndex = 4;
            // 
            // txtPass
            // 
            this.txtPass.AcceptsTab = true;
            this.txtPass.AllowDrop = true;
            this.txtPass.Animated = true;
            this.txtPass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPass.BorderThickness = 2;
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.DefaultText = "";
            this.txtPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.HoverState.BorderColor = System.Drawing.Color.Maroon;
            this.txtPass.IconRight = global::PREMIUM_6._0.Properties.Resources._lock;
            this.txtPass.IconRightSize = new System.Drawing.Size(24, 22);
            this.txtPass.Location = new System.Drawing.Point(42, 141);
            this.txtPass.Name = "txtPass";
            this.txtPass.PlaceholderText = "Password";
            this.txtPass.SelectedText = "";
            this.txtPass.Size = new System.Drawing.Size(237, 40);
            this.txtPass.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.AcceptsReturn = true;
            this.txtUser.AcceptsTab = true;
            this.txtUser.AllowDrop = true;
            this.txtUser.Animated = true;
            this.txtUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUser.BorderThickness = 2;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.DefaultText = "";
            this.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUser.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.HoverState.BorderColor = System.Drawing.Color.Maroon;
            this.txtUser.IconRight = global::PREMIUM_6._0.Properties.Resources.user;
            this.txtUser.IconRightSize = new System.Drawing.Size(24, 22);
            this.txtUser.Location = new System.Drawing.Point(42, 76);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderText = "Username";
            this.txtUser.SelectedText = "";
            this.txtUser.Size = new System.Drawing.Size(237, 40);
            this.txtUser.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtUser.TabIndex = 2;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // rememberme
            // 
            this.rememberme.Animated = true;
            this.rememberme.AutoSize = true;
            this.rememberme.CheckedState.BorderRadius = 0;
            this.rememberme.CheckedState.BorderThickness = 0;
            this.rememberme.CheckedState.FillColor = System.Drawing.Color.Maroon;
            this.rememberme.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberme.ForeColor = System.Drawing.Color.Silver;
            this.rememberme.Location = new System.Drawing.Point(9, 333);
            this.rememberme.Name = "rememberme";
            this.rememberme.Size = new System.Drawing.Size(119, 20);
            this.rememberme.TabIndex = 6;
            this.rememberme.Text = "Remember Me";
            this.rememberme.UncheckedState.BorderColor = System.Drawing.Color.Maroon;
            this.rememberme.UncheckedState.BorderRadius = 0;
            this.rememberme.UncheckedState.BorderThickness = 2;
            this.rememberme.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rememberme.CheckedChanged += new System.EventHandler(this.guna2CheckBox1_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(320, 362);
            this.Controls.Add(this.rememberme);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.Exit);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox Exit;
        private Guna.UI2.WinForms.Guna2BorderlessForm borderlessform;
        private System.Windows.Forms.Label logo;
        private Guna.UI2.WinForms.Guna2TextBox txtUser;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtKey;
        private Guna.UI2.WinForms.Guna2TextBox txtPass;
        private Guna.UI2.WinForms.Guna2CheckBox rememberme;
    }
}