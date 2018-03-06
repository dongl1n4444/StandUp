using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandUp
{
    public partial class FormSetting : Form
    {
        private const int TrackBarMinValue = 5;

        public int notifyMinutes = 45;

        Timer tickTimer = new Timer();

        public FormSetting()
        {
            InitializeComponent();
        }

        private void TickTimerProcessor(Object obj, EventArgs args)
        {
            tickTimer.Stop();

            var frmTip = new FormTip(this);
            // frmTip.TopMost = true;
            frmTip.Show();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            tickTimer.Tick += new EventHandler(TickTimerProcessor);

            tickTimer.Interval = notifyMinutes * 60 * 1000;
            tickTimer.Start();

            trackBar1.Value = (int)Math.Floor(notifyMinutes * 1.0 / TrackBarMinValue);
        }

        private void FormSetting_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                notifyIcon1.Visible = true;
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            notifyMinutes = Math.Max(1, trackBar1.Value * TrackBarMinValue);

            tickTimer.Stop();
            tickTimer.Interval = notifyMinutes * 60 * 1000;
            tickTimer.Enabled = true;
        }

        public void Resume()
        {
            tickTimer.Enabled = true;
        }
    }
}
