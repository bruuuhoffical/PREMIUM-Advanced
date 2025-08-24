using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BR_PREMIUM_5._0
{
    public partial class MessageBoxControl : UserControl
    {
        private Timer _slideTimer;
        private Timer _messageTimer;
        private int _remainingTime;
        private bool _isSlidingIn;
        private const int SlideSpeed = 15;

        private double progress = 5;
        public MessageBoxControl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _slideTimer = new Timer { Interval = 30 };
            _slideTimer.Tick += SlideTimer_Tick;

            _messageTimer = new Timer { Interval = 1000 };
            _messageTimer.Tick += MessageTimer_Tick;

            this.Visible = false;
        }
        //private void InitializeParticles()
        //{
        //    for (int i = 0; i < ParticleCount; i++)
        //    {
        //        ResetParticle(i);
        //    }
        //}

        //private void ResetParticle(int i)
        //{
        //    _particlePositions[i] = new PointF(this.Width / 2, this.Height / 2);
        //    float angle = (float)(_random.NextDouble() * Math.PI * 2);
        //    float speed = (float)(_random.NextDouble() * 5 + 2);

        //    _particleVelocities[i] = new PointF((float)Math.Cos(angle) * speed, (float)Math.Sin(angle) * speed);
        //    _particleSizes[i] = (float)(_random.NextDouble() * 2 + 1);
        //    _particleLifetimes[i] = _random.Next(30, 100);
        //}

        //private void UpdateParticles()
        //{
        //    for (int i = 0; i < ParticleCount; i++)
        //    {
        //        _particlePositions[i] = new PointF(
        //            _particlePositions[i].X + _particleVelocities[i].X,
        //            _particlePositions[i].Y + _particleVelocities[i].Y
        //        );

        //        _particleLifetimes[i]--;
        //        if (_particleLifetimes[i] <= 0)
        //        {
        //            ResetParticle(i);
        //        }
        //    }
        //}


        //private void SlideTimer_Tick(object sender, EventArgs e)
        //{
        //    if (_isSlidingIn)
        //    {
        //        if (this.Left > this.Parent.ClientSize.Width - this.Width - 10)
        //        {
        //            this.Left -= 10; 
        //        }
        //        else
        //        {
        //            _slideTimer.Stop();
        //            _messageTimer.Start();
        //        }
        //    }
        //    else
        //    {
        //        if (this.Left < this.Parent.ClientSize.Width)
        //        {
        //            this.Left += 10; 
        //        }
        //        else
        //        {
        //            _slideTimer.Stop();
        //            this.Visible = false;
        //        }
        //    }
        //}

        //private void MessageTimer_Tick(object sender, EventArgs e)
        //{
        //    _remainingTime -= 1000;
        //    //prgrs.Value = (_duration - _remainingTime) / 100;

        //    if (_remainingTime <= 0)
        //    {
        //        _messageTimer.Stop(); 
        //        HideMessage(); 
        //    }
        //}

        //public void ShowMessage(string message, string status, string imageKey)
        //{
        //    msglbl.Text = message;
        //    stslbl.Text = status;
        //    picstatus.Image = GetImageForStatus(imageKey);
        //    _remainingTime = _duration;
        //    //prgrs.Maximum = _duration / 1000;
        //    //prgrs.Value = 0;

        //    this.Visible = true;
        //    _isSlidingIn = true;
        //    _slideTimer.Start();
        //}

        //private Image GetImageForStatus(string imageKey)
        //{
        //    switch (imageKey.ToLower())
        //    {
        //        case "success":
        //            return Properties.Resources.check;
        //        case "error":
        //            return Properties.Resources.cross;
        //        case "loading":
        //            return Properties.Resources.loading;
        //        default:
        //            return Properties.Resources.brlogored;
        //    }
        //}

        //public void HideMessage()
        //{
        //    _isSlidingIn = false;
        //    _slideTimer.Start();
        //}
        //private void MessageBoxControl_Load(object sender, EventArgs e)
        //{

        //}

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            _remainingTime -= 1000;
            if (_remainingTime <= 0)
            {
                _messageTimer.Stop();
                HideMessage();
            }
        }

        public void ShowMessage(string message, string status, string imageKey, Color baseColor, int duration = 5000)
        {
            msglbl.Text = message;
            msglbl.ForeColor = GetColorForStatus(status);

            sep1.FillColor = baseColor;
            panel.BorderColor = baseColor;
            label1.ForeColor = baseColor;

            _remainingTime = duration;
            this.Visible = true;

            this.Left = this.Parent.ClientSize.Width - this.Width;
            this.Top = this.Parent.ClientSize.Height; 





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
        private void StartDecreasingProgressBar()
        {
            progress = 5;
            testbar.Value = 5;
            progressTimer.Start();
        }
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            if (_isSlidingIn)
            {
                if (this.Left > this.Parent.ClientSize.Width - this.Width - 10)
                {
                    this.Left -= SlideSpeed;
                }

                if (this.Top > this.Parent.ClientSize.Height - this.Height - 10)
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

        private Image GetImageForStatus(string imageKey)
        {
            switch (imageKey.ToLower())
            {
                case "success": return BR_PREMIUM.Properties.Resources.check;
                case "error": return BR_PREMIUM.Properties.Resources.cross;
                case "loading": return BR_PREMIUM.Properties.Resources.loading;
                default: return BR_PREMIUM.Properties.Resources.brlogored;
            }
        }

        public void HideMessage()
        {
            _isSlidingIn = false;
            _slideTimer.Start();
        }

        private void MessageBoxControl_Load(object sender, EventArgs e) { }

        private void sep1_Click(object sender, EventArgs e)
        {
            //HideMessage();
        }

        private void msglbl_Click(object sender, EventArgs e)
        {
            //HideMessage();
        }

        private void msgparticle_Tick(object sender, EventArgs e)
        {
            
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            //HideMessage();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //HideMessage();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            progress -= 0.1;
            testbar.Value = (int)progress;

            if (progress <= 0)
            {
                progressTimer.Stop();
            }
        }

        private void testbar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
