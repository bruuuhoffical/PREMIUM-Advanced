using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PREMIUM_6._0.Views
{
    public partial class CustomNotification: UserControl
    {
        private Timer _slideTimer;
        private Timer _messageTimer;
        private int _remainingTime;
        private bool _isSlidingIn;
        private const int SlideSpeed = 15;

        private double progress = 5;
        public CustomNotification()
        {
            InitializeComponent();
            _slideTimer = new Timer { Interval = 10 };
            _slideTimer.Tick += SlideTimer_Tick;

            _messageTimer = new Timer { Interval = 3000 };
            _messageTimer.Tick += MessageTimer_Tick;

            this.Visible = false;
        }
        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            _remainingTime -= 5000;
            if (_remainingTime <= 0)
            {
                _messageTimer.Stop();
                HideMessage();
            }
        }

        public void ShowMessage(string message)
        {
            msg.Text = message;

            this.Left = this.Parent.ClientSize.Width - this.Width;
            this.Top = this.Parent.ClientSize.Height;

            this.Visible = true;




            _isSlidingIn = true;
            _slideTimer.Start();
        }
        private Color GetColorForStatus(string status)
        {
            switch (status.ToLower())
            {
                case "cool": return Color.Yellow;
                case "activating": return Color.Yellow;
                case "activated": return Color.Green;
                case "failed": return Color.Red;
                default: return Color.White;
            }
        }
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            if (_isSlidingIn)
            {
                if (this.Left > this.Parent.ClientSize.Width - this.Width - -10)
                {
                    this.Left -= SlideSpeed;
                }
                if (this.Top > this.Parent.ClientSize.Height - this.Height - -10)
                {
                    this.Top -= SlideSpeed;
                }
                else
                {
                    _slideTimer.Stop();
                    _messageTimer.Start();
                }
            }
            else
            {
                if (this.Top < this.Parent.ClientSize.Height)
                {
                    this.Top += SlideSpeed;
                }

                if (this.Left < this.Parent.ClientSize.Width - this.Width)
                {
                    this.Left += SlideSpeed;
                }
                else
                {
                    _slideTimer.Stop();
                    this.Visible = false;
                }
            }
        }
        public void HideMessage()
        {
            _isSlidingIn = false;
            _slideTimer.Start();
        }
        private void msgtype_Click(object sender, EventArgs e)
        {

        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            //progress -= 0.1;
            //testbar.Value = (int)progress;

            //if (progress <= 0)
            //{
            //    progressTimer.Stop();
            //}
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomNotification_Load(object sender, EventArgs e)
        {

        }
    }
}
