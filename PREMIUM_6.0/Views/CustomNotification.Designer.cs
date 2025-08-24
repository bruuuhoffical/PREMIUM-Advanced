namespace PREMIUM_6._0.Views
{
    partial class CustomNotification
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.msg = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.BorderRadius = 3;
            this.panel.Controls.Add(this.guna2ImageButton1);
            this.panel.Controls.Add(this.msg);
            this.panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(7)))), ((int)(((byte)(0)))));
            this.panel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(7)))), ((int)(((byte)(0)))));
            this.panel.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Quality = 100;
            this.panel.Size = new System.Drawing.Size(198, 47);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.BackColor = System.Drawing.Color.Transparent;
            this.msg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg.Location = new System.Drawing.Point(42, 18);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(151, 15);
            this.msg.TabIndex = 2;
            this.msg.Text = "Main Message Goes Here";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 3;
            this.guna2Elipse1.TargetControl = this;
            // 
            // progressTimer
            // 
            this.progressTimer.Interval = 200;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2ImageButton1.Image = global::PREMIUM_6._0.Properties.Resources.cell;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2ImageButton1.Location = new System.Drawing.Point(6, 8);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2ImageButton1.Size = new System.Drawing.Size(35, 34);
            this.guna2ImageButton1.TabIndex = 3;
            // 
            // CustomNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Silver;
            this.Name = "CustomNotification";
            this.Size = new System.Drawing.Size(198, 47);
            this.Load += new System.EventHandler(this.CustomNotification_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CustomGradientPanel panel;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.Timer progressTimer;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
    }
}
