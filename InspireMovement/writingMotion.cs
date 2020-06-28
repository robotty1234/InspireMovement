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
    public partial class writingMotion : Form
    {
        Label motion = new Label();
        NumericUpDown motionNum = new NumericUpDown();
        Button writing = new Button();
        public mainForm mainGUI;
        public int fileNum = 0;

        public writingMotion()
        {
            InitializeComponent();
            int[] labelSize = { 39, 12 };
            int[] buttonSize = { 110, 23 };
            int[] numUpDownSize = { 53, 19 };
            motion.Text = "motion";
            motion.Location = new Point((this.Width / 2) - labelSize[0] * 2 + 10, (this.Height / 2) - labelSize[1] - 20);
            motion.Size = new Size(labelSize[0], labelSize[1]);
            motionNum.Location = new Point((this.Width / 2) + labelSize[0] - numUpDownSize[0] - 10, (this.Height / 2) - labelSize[1] - 20);
            motionNum.Size = new Size(numUpDownSize[0], numUpDownSize[1]);
            motionNum.Maximum = 50;
            writing.Text = "書き込み開始";
            writing.Size = new Size(buttonSize[0], buttonSize[1]);
            writing.Location = new Point((this.Width / 2) - (buttonSize[0] / 2) - 5, (this.Height / 2) + (buttonSize[1] / 2) - 15);
            writing.Click += new EventHandler(writing_Click);
            this.Controls.Add(motion);
            this.Controls.Add(motionNum);
            this.Controls.Add(writing);
        }

        private void writingMotion_Load(object sender, EventArgs e)
        {

        }

        private void writing_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(motion);
            this.Controls.Remove(motionNum);
            writing.Text = "書き込み中";
            writing.Enabled = false;
            Decimal num = motionNum.Value;
            Console.WriteLine("tabNum=" + num.ToString());
            this.mainGUI.defineMotion(Decimal.ToInt32(num));
            Console.WriteLine("終了");
            this.Close();
        }
    }
}
