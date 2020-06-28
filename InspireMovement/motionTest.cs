using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InspireMovement
{
    public partial class motionTest : Form
    {
        public mainForm mainGUI;

        int mFileNum;
        public motionTest()
        {
            InitializeComponent();
        }

        private void motionTest_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mFileNum = decimal.ToInt32(fileNum.Value);
        }

        private void motionStart_Click(object sender, EventArgs e)
        {
            motionStart.Text = "再生中";
            motionStart.Enabled = false;
            this.mainGUI.motionTestTask(mFileNum);
            motionStart.Text = "再生";
            motionStart.Enabled = true;

        }
    }
}
