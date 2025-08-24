namespace BR_PREMIUM_5._0
{
    partial class MessageBoxControl
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
            this.msgelispe = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel = new Guna.UI2.WinForms.Guna2Panel();
            this.testbar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.msglbl = new System.Windows.Forms.Label();
            this.sep1 = new Guna.UI2.WinForms.Guna2Separator();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgelispe
            // 
            this.msgelispe.BorderRadius = 5;
            this.msgelispe.TargetControl = this;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.BorderColor = System.Drawing.Color.White;
            this.panel.BorderRadius = 5;
            this.panel.BorderThickness = 1;
            this.panel.Controls.Add(this.testbar);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.msglbl);
            this.panel.Controls.Add(this.sep1);
            this.panel.ForeColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(221, 81);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // testbar
            // 
            this.testbar.FillColor = System.Drawing.Color.Black;
            this.testbar.ForeColor = System.Drawing.Color.Black;
            this.testbar.Location = new System.Drawing.Point(3, 78);
            this.testbar.Maximum = 5;
            this.testbar.Name = "testbar";
            this.testbar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            this.testbar.ProgressColor = System.Drawing.Color.Yellow;
            this.testbar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.testbar.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.testbar.Size = new System.Drawing.Size(221, 2);
            this.testbar.TabIndex = 1;
            this.testbar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.testbar.Value = 5;
            this.testbar.ValueChanged += new System.EventHandler(this.testbar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(202, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nevan RUS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "BRUUUH CHEATS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // msglbl
            // 
            this.msglbl.AutoSize = true;
            this.msglbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msglbl.ForeColor = System.Drawing.Color.Yellow;
            this.msglbl.Location = new System.Drawing.Point(18, 48);
            this.msglbl.Name = "msglbl";
            this.msglbl.Size = new System.Drawing.Size(32, 16);
            this.msglbl.TabIndex = 7;
            this.msglbl.Text = "Null";
            this.msglbl.Click += new System.EventHandler(this.msglbl_Click);
            // 
            // sep1
            // 
            this.sep1.FillColor = System.Drawing.Color.White;
            this.sep1.FillThickness = 3;
            this.sep1.Location = new System.Drawing.Point(17, 35);
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(191, 10);
            this.sep1.TabIndex = 6;
            this.sep1.Click += new System.EventHandler(this.sep1_Click);
            // 
            // progressTimer
            // 
            this.progressTimer.Enabled = true;
            this.progressTimer.Interval = 200;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // MessageBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "MessageBoxControl";
            this.Size = new System.Drawing.Size(224, 82);
            this.Load += new System.EventHandler(this.MessageBoxControl_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse msgelispe;
        private Guna.UI2.WinForms.Guna2Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label msglbl;
        private Guna.UI2.WinForms.Guna2Separator sep1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer progressTimer;
        private Guna.UI2.WinForms.Guna2ProgressBar testbar;
    }
}
