using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InspireMovement
{
    struct mouseMovePoint
    {
        public int reX;
        public int reY;
        public int afX;
        public int afY;
        public bool mouse;
    }

    public partial class newBoneForm : Form
    {
        public mainForm maintoBone;
        public setControle setForm;

        public static readonly int sizeX = 110;
        public static readonly int sizeY = 60 / 2;

        Button[] dragButton = new Button[30];
        Button[] setButton = new Button[30];
        svContloleClass[] contSV = new svContloleClass[30];
        mouseMovePoint[] mp = new mouseMovePoint[30];

        public int useButton = 0;

        public string names;
        public int ports;
        public int pins;
        public int nowMouse;

        public newBoneForm()
        {
            InitializeComponent();
            for(int i = 0; i < 30; i++)
            {
                dragButton[i] = new Button();
                setButton[i] = new Button();
                contSV[i] = new svContloleClass();
            }
        }

        private void NewBoneForm_Load(object sender, EventArgs e)
        {

        }

        private void SaveBone_Click(object sender, EventArgs e)
        {
            saveBoneFile.Filter = "Bone Files (.bone)|*.bone|ALL Files (*.*)|*.*";
            DialogResult save = saveBoneFile.ShowDialog();
            if (save == System.Windows.Forms.DialogResult.OK)
            {
                Encoding encType = Encoding.GetEncoding("utf-8");
                StreamWriter writer = new StreamWriter(saveBoneFile.FileName, false, encType);
                for(int i = 0;i < useButton;i++)
                { 
                    string fileLine = contSV[i].name + "," + contSV[i].svPort.ToString() + "," + contSV[i].svPin.ToString() + "," + dragButton[i].Location.X.ToString()+ "," + dragButton[i].Location.Y.ToString();
                    writer.WriteLine(fileLine);
                }
                writer.Close();
            }
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dragButton[useButton].Text = "ドラッグ:" + useButton.ToString();
            dragButton[useButton].Size = new Size(sizeX,sizeY);
            dragButton[useButton].Location = new Point(20, 20);
            dragButton[useButton].MouseDown += new MouseEventHandler(downForMouse);
            dragButton[useButton].MouseMove += new MouseEventHandler(dragForMouse);
            dragButton[useButton].Click += new EventHandler(clickForMouse);
            this.Controls.Add(dragButton[useButton]);
            setButton[useButton].Text = "設定:" + useButton.ToString();
            setButton[useButton].Size = new Size(sizeX, sizeY);
            setButton[useButton].Location = new Point(20, 20+sizeY);
            setButton[useButton].Click += new EventHandler(setButton_Clikc);
            this.Controls.Add(setButton[useButton]);
            useButton++;
        }

        private void setButton_Clikc(object sender, EventArgs e)
        {
            Console.WriteLine("設定が押されました");
            string name = sender.ToString();
            string[] numstring = name.Split(':');
            int num = int.Parse(numstring[2]);
            setForm = new setControle(num,contSV[num].name,contSV[num].svPort,contSV[num].svPin);
            setForm.boneForm = this;
            setForm.Show();
        }

        public void settingControle(int num)
        {
            contSV[num].makeInfor(names,ports,pins);
            Console.WriteLine("コントロールネーム:" + contSV[num].name);
            Console.WriteLine("ポート:" + contSV[num].svPort.ToString());
            Console.WriteLine("ピン:" + contSV[num].svPin.ToString());
        }


        private void downForMouse(object sender, MouseEventArgs e)
        {
            Console.WriteLine("MouseDown");
            for (int i = 0; i < dragButton.Length; i++)
            {
                if (dragButton[i].Equals(sender))
                {
                    nowMouse = i;
                }
            }
            mp[nowMouse].reX = System.Windows.Forms.Cursor.Position.X;
            mp[nowMouse].reY = System.Windows.Forms.Cursor.Position.Y;
            mp[nowMouse].mouse = true;
        }



        private void dragForMouse(object sender, MouseEventArgs e)
        {
            if (mp[nowMouse].mouse == true)
            {
                mp[nowMouse].afX = System.Windows.Forms.Cursor.Position.X;
                mp[nowMouse].afY = System.Windows.Forms.Cursor.Position.Y;
                Console.WriteLine("動いた");
                dragButton[nowMouse].Location = new Point(dragButton[nowMouse].Location.X + (mp[nowMouse].afX - mp[nowMouse].reX), dragButton[nowMouse].Location.Y + (mp[nowMouse].afY - mp[nowMouse].reY));
                setButton[nowMouse].Location = new Point(dragButton[nowMouse].Location.X + (mp[nowMouse].afX - mp[nowMouse].reX), (dragButton[nowMouse].Location.Y + (mp[nowMouse].afY - mp[nowMouse].reY)) + sizeY);
                mp[nowMouse].reX = mp[nowMouse].afX;
                mp[nowMouse].reY = mp[nowMouse].afY;
            }
        }

        private void clickForMouse(object sender, EventArgs e)
        {
            mp[nowMouse].mouse = false;
            nowMouse = 0;
        }
    }
}
