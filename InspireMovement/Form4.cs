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
    public partial class resetForm : Form
    {
        public mainForm mainGUI;
        public resetForm()
        {
            InitializeComponent();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.mainGUI.resetMotion();
            this.Close();
        }
    }
}
