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
        private int notifyMinutes = 45;

        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
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
            //Console.Write("val: " + trackBar1.Value);
            notifyMinutes = trackBar1.Value * TrackBarMinValue;
        }
    }
}
