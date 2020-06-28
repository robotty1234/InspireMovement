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
    public partial class setControle : Form
    {
        public newBoneForm boneForm;
        public int num;

        public setControle(int nums ,string n,int po,int pi)
        {
            InitializeComponent();
            Console.WriteLine("開いたのは" + num.ToString());
            num = nums;
            textBoxSet.Text = n;
            portSet.Value = po;
            pinSet.Value = pi;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void saveSet_Click(object sender, EventArgs e)
        {
            boneForm.names = textBoxSet.Text;
            boneForm.ports = Decimal.ToInt32(portSet.Value);
            boneForm.pins = Decimal.ToInt32(pinSet.Value);
            boneForm.settingControle(num);
            this.Close();
        }
    }
}
