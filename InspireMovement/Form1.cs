using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InspireMovement
{
    public partial class mainForm : Form
    {
        public static readonly int STEPMAX = 20;
        public static readonly int PORTMAX = 5;
        public static readonly int PINMAX = 6;
        public static readonly int[] labelSize = { 105, 18 };
        public static readonly int[] numericSize = { 105, 25 };
        public static readonly int[] trackSize = { 105, 69 };
        public static readonly int[] contlorSize = { 26, 25 };

        Label[] servoLabel = new Label[30];
        Button[] minusX = new Button[30];
        TextBox[] servoBox = new TextBox[30];
        Button[] plusX = new Button[30];
        Button[] minus = new Button[30];
        ProgressBar[] servoBar = new ProgressBar[30];
        Button[] plus = new Button[30];


        public newBoneForm boneForm;
        public writingMotion writeForm;
        public resetForm reForm;
        public motionTest moTest;

        svContloleClass[] servoTask = new svContloleClass[30];
        public int maxStepValue;//最大ステップ数
        public int step;//現在何ステップ目なのかを保存する変数
        public int [,,] posDeg = new int[STEPMAX, PORTMAX, PINMAX];//角度を保持する変数
        public int [] delays = new int[STEPMAX];//動作時間を保存する変数
        public int [,] homePos = new int[PORTMAX, PINMAX];//ホームポジションを保存する変数 
        public int useServo = 0;//使用するサーボの数を保持する変数
        public bool connect = false;//アプリとロボがリンクさせているかさせてないかを判断させる変数
        public bool[] farstStep = new bool[STEPMAX];
        public bool writFlug = false;//相手が受信したかを確認

        public mainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 30; i++)
            {
                servoTask[i] = new svContloleClass();
                servoLabel[i] = new Label();
                minusX[i] = new Button();
                servoBox[i] = new TextBox();
                plusX[i] = new Button();
                minus[i] = new Button();
                servoBar[i] = new ProgressBar();
                plus[i] = new Button();
            }
            for (int i = 0; i < PORTMAX; i++)
            {
                for (int j = 0; j < PINMAX; j++)
                {
                    homePos[i, j] = 90;
                }
            }
            resetMotion();
            resurtchPorts();
        }

        public void resetMotion()
        {
            for (int s = 0; s < STEPMAX; s++)
            {
                for (int i = 0; i < PORTMAX; i++)
                {
                    for (int j = 0; j < PINMAX; j++)
                    {
                        posDeg[s, i, j] = homePos[i,j];
                    }
                }
                farstStep[s] = false;
                delays[s] = 0;
            }
            step = 0;
            maxStepValue = 0;
            stepBAR.Maximum = maxStepValue;
            displayAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void delay_ValueChanged(object sender, EventArgs e)
        {
            delays[step] = decimal.ToInt32(delayVal.Value);
        }

        private void maxStep_ValueChanged(object sender, EventArgs e)
        {
            maxStepValue = Decimal.ToInt32(maxStep.Value);
            stepBAR.Maximum = maxStepValue;
        }

        private void stepBAR_Scroll(object sender, EventArgs e)
        {
            if (stepBAR.Maximum != 0)
            {
                step = stepBAR.Value;
                stepLabel.Text = stepBAR.Value.ToString();
                if (farstStep[step] == false)
                {
                    for (int i = 0; i < useServo; i++)
                    {
                        posDeg[step, servoTask[i].svPort, servoTask[i].svPin] = posDeg[step - 1, servoTask[i].svPort, servoTask[i].svPin];
                    }
                }
                displayAll();
            }
        }

        private void displayAll()//すべての表示されているカーソルに値を反映させる
        {
            for(int i = 0; i < useServo; i++)
            {
                servoBox[i].Enabled = false;
                minusX[i].Enabled = false;
                plusX[i].Enabled = false;
                minus[i].Enabled = false;
                plus[i].Enabled = false;
                int deg = posDeg[step, servoTask[i].svPort, servoTask[i].svPin];
                servoBar[i].Value = deg;
                servoBox[i].Text = deg.ToString();
                if (connect == true)
                {
                    moveServo(servoTask[i].svPort, servoTask[i].svPin, posDeg[step, servoTask[i].svPort, servoTask[i].svPin]);
                }
                servoBox[i].Enabled = true;
                minusX[i].Enabled = true;
                plusX[i].Enabled = true;
                minus[i].Enabled = true;
                plus[i].Enabled = true;
            }
            delayVal.Value = delays[step];
            stepBAR.Value = step;
            maxStep.Value = maxStepValue;
            stepLabel.Text = step.ToString();
        }

        private void displayAllHome()//ホームポジションの値を反映
        {
            for (int i = 0; i < useServo; i++)
            {
                servoBar[i].Value = homePos[servoTask[i].svPort, servoTask[i].svPin];
                servoBox[i].Text = (homePos[servoTask[i].svPort, servoTask[i].svPin]).ToString();
            }
        }

        private void NewBone_Click(object sender, EventArgs e)
        { 
            boneForm = new newBoneForm();
            boneForm.maintoBone = this;
            boneForm.Show();
        }

        private void makeFiles(char type)//変数から保存するファイルを作る
        {
            if (type == 'p')
            {
                saveMotion.Filter = "Mostion Files (.udm)|*.udm|HomePostion Files (.udh)|*.udh|Bone Files (.bone)|*.bone|ALL Files (*.*)|*.*";
            }
            else if (type == 'h')
            {
                saveMotion.Filter = "HomePostion Files (.udh)|*.udh|Mostion Files (.udm)|*.udm|Bone Files (.bone)|*.bone|ALL Files (*.*)|*.*";
            }
            DialogResult save = saveMotion.ShowDialog();
            if (save == System.Windows.Forms.DialogResult.OK)
            {
                Encoding encType = Encoding.GetEncoding("utf-8");
                StreamWriter writer = new StreamWriter(saveMotion.FileName, false, encType);
                if (type == 'p')
                {
                    for (int s = 0; s <= stepBAR.Maximum; s++)
                    {
                        for (int i = 0; i < PORTMAX; i++)
                        {
                            for (int j = 0; j < PINMAX; j++)
                            {
                                writer.Write(homePos[i, j] - posDeg[s, i, j] + ",");
                            }
                            writer.Write("|");
                        }
                        writer.WriteLine(delays[s]);
                    }
                }
                if (type == 'h')
                {
                    for (int i = 0; i < PORTMAX; i++)
                    {
                        for (int j = 0; j < PINMAX; j++)
                        {
                            writer.Write(homePos[i, j] + ",");
                        }
                        writer.WriteLine("");
                    }
                }
                writer.Close();
            }
        }

        private void saveBone_Click(object sender, EventArgs e)
        {
            openFiles.Filter = "Bone Files (.bone)|*.bone|HomePostion Files (.udh)|*.udh|Mostion Files (.udm)|*.udm|ALL Files (*.*)|*.*";
            DialogResult open = openFiles.ShowDialog();
            string[] cotroleInfor;
            if (open == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFiles.FileName;
                string fileName = Path.GetFileName(filePath);
                Console.WriteLine(fileName);
                for(int i = 0; i < useServo; i++)
                {
                    this.Controls.Remove(servoLabel[i]);
                    this.Controls.Remove(servoBox[i]);
                    this.Controls.Remove(servoBar[i]);
                    Console.WriteLine("i=" + i.ToString());
                }
                //ファイルからモータの角度、時間情報を取得
                useServo = 0;
                using (System.IO.StreamReader bfile = new System.IO.StreamReader(filePath))
                {
                    while (!bfile.EndOfStream)
                    {
                        string mData = bfile.ReadLine();
                        cotroleInfor = mData.Split(',');
                        servoTask[useServo].name = cotroleInfor[0];
                        servoTask[useServo].svPort = int.Parse(cotroleInfor[1]);
                        servoTask[useServo].svPin = int.Parse(cotroleInfor[2]);
                        Console.WriteLine("port=" + servoTask[useServo].svPort.ToString () + ",pin=" + servoTask[useServo].svPin.ToString());
                        servoTask[useServo].cPosX = int.Parse(cotroleInfor[3]);
                        servoTask[useServo].cPosY = int.Parse(cotroleInfor[4]);
                        servoLabel[useServo].Text = servoTask[useServo].name;
                        servoLabel[useServo].Location = new Point(servoTask[useServo].cPosX, servoTask[useServo].cPosY);
                        servoLabel[useServo].Size = new Size(labelSize[0],labelSize[1]);
                        minusX[useServo].Location = new Point(servoTask[useServo].cPosX, servoTask[useServo].cPosY + labelSize[1]);
                        minusX[useServo].Size = new Size(30, 21);
                        minusX[useServo].Text = "-10";
                        minusX[useServo].Font = new System.Drawing.Font("MS UI Gothic", 7);
                        minusX[useServo].Click += new EventHandler(this.minusToX);
                        plusX[useServo].Location = new Point(servoTask[useServo].cPosX + 75, servoTask[useServo].cPosY + labelSize[1]);
                        plusX[useServo].Size = new Size(30, 21);
                        plusX[useServo].Text = "+10";
                        plusX[useServo].Font = new System.Drawing.Font("MS UI Gothic", 7);
                        plusX[useServo].Click += new EventHandler(this.plusToX);
                        minus[useServo].Location = new Point(servoTask[useServo].cPosX, servoTask[useServo].cPosY + labelSize[1] + 20);
                        minus[useServo].Size = new Size(26, 21);
                        minus[useServo].Text = "-";
                        minus[useServo].Font = new System.Drawing.Font("MS UI Gothic", 7);
                        minus[useServo].Click += new EventHandler(this.minusTo);
                        plus[useServo].Location = new Point(servoTask[useServo].cPosX + 79, servoTask[useServo].cPosY + labelSize[1] + 20);
                        plus[useServo].Size = new Size(26, 21);
                        plus[useServo].Text = "+";
                        plus[useServo].Font = new System.Drawing.Font("MS UI Gothic", 7);
                        plus[useServo].Click += new EventHandler(this.plusTo);
                        servoBox[useServo].Location = new Point(servoTask[useServo].cPosX + 30, servoTask[useServo].cPosY + labelSize[1] + 1);
                        servoBox[useServo].Text = "90";
                        servoBox[useServo].Size = new Size(45,25);
                        servoBox[useServo].KeyPress += new KeyPressEventHandler(this.servoBox_ValueChanged);
                        servoBar[useServo].Location = new Point(servoTask[useServo].cPosX + 20, servoTask[useServo].cPosY + labelSize[1] + 21);
                        servoBar[useServo].Size = new Size(59, 19);
                        servoBar[useServo].Maximum = 180;
                        servoBar[useServo].Minimum = 0;
                        servoBar[useServo].Value = 90;
                        this.Controls.Add(servoLabel[useServo]);
                        this.Controls.Add(minusX[useServo]);
                        this.Controls.Add(plusX[useServo]);
                        this.Controls.Add(minus[useServo]);
                        this.Controls.Add(plus[useServo]);
                        this.Controls.Add(servoBox[useServo]);
                        this.Controls.Add(servoBar[useServo]);
                        useServo++;
                    }
                }
                displayAll();
            }
        }

        private void minusToX(object sender, EventArgs e)//押されたら角度を-10する関数
        {
            int index = 0;
            for (int i = 0; i < minusX.Length; i++)
            {
                if (minusX[i].Equals(sender))
                {
                    index = i;
                }
            }
            minusX[index].Enabled = false;
            plusX[index].Enabled = false;
            minus[index].Enabled = false;
            plus[index].Enabled = false;
            servoBox[index].Enabled = false;
            int value = servoBar[index].Value - 10;
            if (value > 180)
            {
                value = 180;
            }
            else if (value < 0)
            {
                value = 0;
            }
            servoBar[index].Value = value;
            servoBox[index].Text = value.ToString();
            posDeg[step, servoTask[index].svPort, servoTask[index].svPin] = value;
            if (connect == true)
            {
                moveServo(servoTask[index].svPort, servoTask[index].svPin, posDeg[step, servoTask[index].svPort, servoTask[index].svPin]);
            }
            minusX[index].Enabled = true;
            plusX[index].Enabled = true;
            minus[index].Enabled = true;
            plus[index].Enabled = true;
            servoBox[index].Enabled = true;
        }

        private void plusToX(object sender, EventArgs e)//押されたら角度を+10する関数
        {
            int index = 0;
            for (int i = 0; i < plusX.Length; i++)
            {
                if (plusX[i].Equals(sender))
                {
                    index = i;
                }
            }
            minusX[index].Enabled = false;
            plusX[index].Enabled = false;
            minus[index].Enabled = false;
            plus[index].Enabled = false;
            servoBox[index].Enabled = false;
            int value = servoBar[index].Value + 10;
            if (value > 180)
            {
                value = 180;
            }
            else if (value < 0)
            {
                value = 0;
            }
            servoBar[index].Value = value;
            servoBox[index].Text = value.ToString();
            posDeg[step, servoTask[index].svPort, servoTask[index].svPin] = value;
            if (connect == true)
            {
                moveServo(servoTask[index].svPort, servoTask[index].svPin, posDeg[step, servoTask[index].svPort, servoTask[index].svPin]);
            }
            minusX[index].Enabled = true;
            plusX[index].Enabled = true;
            minus[index].Enabled = true;
            plus[index].Enabled = true;
            servoBox[index].Enabled = true;
        }

        private void minusTo(object sender, EventArgs e)//押されたら角度を-1する関数
        {
            int index = 0;
            for (int i = 0; i < minus.Length; i++)
            {
                if (minus[i].Equals(sender))
                {
                    index = i;
                }
            }
            minusX[index].Enabled = false;
            plusX[index].Enabled = false;
            minus[index].Enabled = false;
            plus[index].Enabled = false;
            servoBox[index].Enabled = false;
            int value = servoBar[index].Value - 1;
            if (value > 180)
            {
                value = 180;
            }
            else if (value < 0)
            {
                value = 0;
            }
            servoBar[index].Value = value;
            servoBox[index].Text = value.ToString();
            posDeg[step, servoTask[index].svPort, servoTask[index].svPin] = value;
            if (connect == true)
            {
                moveServo(servoTask[index].svPort, servoTask[index].svPin, posDeg[step, servoTask[index].svPort, servoTask[index].svPin]);
            }
            minusX[index].Enabled = true;
            plusX[index].Enabled = true;
            minus[index].Enabled = true;
            plus[index].Enabled = true;
            servoBox[index].Enabled = true;
        }

        private void plusTo(object sender, EventArgs e)//押されたら角度を+1する関数
        {
            int index = 0;
            for (int i = 0; i < plus.Length; i++)
            {
                if (plus[i].Equals(sender))
                {
                    index = i;
                }
            }
            minusX[index].Enabled = false;
            plusX[index].Enabled = false;
            minus[index].Enabled = false;
            plus[index].Enabled = false;
            servoBox[index].Enabled = false;
            int value = servoBar[index].Value + 1;
            if (value > 180)
            {
                value = 180;
            }
            else if (value < 0)
            {
                value = 0;
            }
            servoBar[index].Value = value;
            servoBox[index].Text = value.ToString();
            posDeg[step, servoTask[index].svPort, servoTask[index].svPin] = value;
            if (connect == true)
            {
                moveServo(servoTask[index].svPort, servoTask[index].svPin, posDeg[step, servoTask[index].svPort, servoTask[index].svPin]);
            }
            minusX[index].Enabled = true;
            plusX[index].Enabled = true;
            minus[index].Enabled = true;
            plus[index].Enabled = true;
            servoBox[index].Enabled = true;
        }

        private void servoBox_ValueChanged(object sender, KeyPressEventArgs e)
        {
            int index = 0;
            for (int i = 0; i < servoBox.Length; i++)
            {
                if (servoBox[i].Equals(sender))
                {
                    index = i;
                }
            }
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("数字を入力してください");
                Console.WriteLine(e.KeyChar);
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                minusX[index].Enabled = false;
                plusX[index].Enabled = false;
                minus[index].Enabled = false;
                plus[index].Enabled = false;
                servoBox[index].Enabled = false;
                int value = int.Parse(servoBox[index].Text);
                if (value > 180)
                {
                    value = 180;
                }
                else if (value < 0)
                {
                    value = 0;
                }
                servoBar[index].Value = value;
                servoBox[index].Text = value.ToString();
                posDeg[step, servoTask[index].svPort, servoTask[index].svPin] = value;
                if (connect == true)
                {
                    moveServo(servoTask[index].svPort, servoTask[index].svPin, posDeg[step, servoTask[index].svPort, servoTask[index].svPin]);
                }
            }
            minusX[index].Enabled = true;
            plusX[index].Enabled = true;
            minus[index].Enabled = true;
            plus[index].Enabled = true;
            servoBox[index].Enabled = true;
        }

        private void resurtchPorts()//シリアルポートを探してコンボボックスに入れる関数
        {
            portBox.Items.Clear();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                portBox.Items.Add(port);
            }
        }

        private bool SerialBegin()//シリアルポートを開く関数
        {
            dollSerialPort.Close();
            if (portBox.SelectedIndex != -1)
            {
                dollSerialPort.PortName = portBox.SelectedItem.ToString();  // 選択されたCOMをポート名に設定
                dollSerialPort.BaudRate = 9600;
                dollSerialPort.Open();  // ポートを開く
                dollSerialPort.DtrEnable = true;
                Thread.Sleep(2000);
                dollSerialPort.DtrEnable = false;
                return true;
            }
            else
            {
                MessageBox.Show("通信ポートが設定されていません");
                dollSerialPort.Close();
                return false;
            }

        }

        private void sutchPort_Click(object sender, EventArgs e)
        {
            resurtchPorts();
        }

        private void motionSave_Click(object sender, EventArgs e)
        {
            makeFiles('p');
        }

        private void homeSave_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < useServo; i++)
            {
                int port = servoTask[i].svPort;
                int pin = servoTask[i].svPin;
                homePos[port, pin] = posDeg[step, port, pin];
            }
            makeFiles('h');
            displayAll();
        }

        private void motionRead_Click(object sender, EventArgs e)
        {
            resetMotion();
            openFiles.Filter = "Mostion Files (.udm)|*.udm|HomePostion Files (.udh)|*.udh|ALL Files (*.*)|*.*";
            DialogResult open = openFiles.ShowDialog();
            if (open == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFiles.FileName;
                string fileName = Path.GetFileName(filePath);
                //ファイルからモータの角度、時間情報を取得
                int times = 0;
                using (System.IO.StreamReader mfile = new System.IO.StreamReader(filePath))
                {
                    while (!mfile.EndOfStream)
                    {
                        string mData = mfile.ReadLine();
                        string[] portSp = mData.Split('|');
                        for (int i = 0; i < portSp.Length - 2; i++)
                        {
                            string[] pinSp = portSp[i].Split(',');
                            for (int j = 0; j < pinSp.Length - 1; j++)
                            {
                                int deg = homePos[i, j] + Int32.Parse(pinSp[j]);
                                if(deg > 180)
                                {
                                    deg = 180;
                                }else if(deg < 0)
                                {
                                    deg = 0;
                                }
                                posDeg[times, i, j] = deg;
                                farstStep[times] = true;
                            }
                        }
                        delays[times] = Int32.Parse(portSp[portSp.Length - 1]);
                        times++;
                    }
                    maxStepValue = times - 1;
                    stepBAR.Maximum = maxStepValue;
                    maxStep.Value = maxStepValue;
                    Console.WriteLine("ステップ数" + step);
                    displayAll();
                    mfile.Close();
                }
            }
        }

        private void link_CheckedChanged(object sender, EventArgs e)
        {
            link.Enabled = false;
            bool serialBool = SerialBegin();
            link.Enabled = true;
            {
                CheckBox chkBox = (CheckBox)sender;

                if (chkBox.Checked && serialBool == true)
                {
                    connect = true;
                    Console.WriteLine("Link Start");
                    for (int i = 0; i < useServo; i++)
                    {
                        Console.WriteLine("moveServo:" + i.ToString());
                        moveServo(servoTask[i].svPort, servoTask[i].svPin, posDeg[step, servoTask[i].svPort, servoTask[i].svPin]);
                    }
                    Console.WriteLine("Link Finish");
                }
                else
                {
                    connect = false;
                    dollSerialPort.Close();
                }
            }
        }

        private void moveServo(int port, int pin, int deg)//サーボを動かす関数
        {
            int moveDegs = deg;
            int sum = port + pin + moveDegs;
            String svString = port.ToString() + "," + pin.ToString() + "," + moveDegs.ToString() + "," + sum.ToString() + "/";
            dollSerialPort.WriteLine("w");
            serialFlush();
            dollSerialPort.WriteLine(port.ToString());
            serialFlush();
            dollSerialPort.WriteLine(pin.ToString());
            serialFlush();
            dollSerialPort.WriteLine(moveDegs.ToString());
            serialFlush();
            dollSerialPort.WriteLine(sum.ToString());
            serialFlush();
            dollSerialPort.WriteLine("f");
            serialFlush();
            Console.WriteLine(svString);
        }

        private void homeRead_Click(object sender, EventArgs e)//ホームポジションファイルを読み込む
        {
            openFiles.Filter = "HomePostion Files (.udh)|*.udh|Mostion Files (.udm)|*.udm|ALL Files (*.*)|*.*";
            DialogResult open = openFiles.ShowDialog();
            if (open == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFiles.FileName;
                string fileName = Path.GetFileName(filePath);
                int port = 0;
                //ファイルからモータの角度、時間情報を取得
                using (System.IO.StreamReader mfile = new System.IO.StreamReader(filePath))
                {
                    while (!mfile.EndOfStream)
                    {
                        string mData = mfile.ReadLine();
                        string[] datas = mData.Split(',');
                        Console.WriteLine("配列の数" + datas.Length);
                        for (int i = 0; i < datas.Length - 1; i++)
                        {
                            homePos[port, i] = int.Parse(datas[i]);
                            posDeg[step, port, i] = homePos[port, i];
                        }
                        port++;
                    }
                    mfile.Close();
                }
            }
            Console.WriteLine("connect=" + connect.ToString());
            if (connect == true)
            {
                for (int i = 0; i < useServo; i++)
                {
                    moveServo(servoTask[i].svPort, servoTask[i].svPin, posDeg[step, servoTask[i].svPort, servoTask[i].svPin]);
                }
            }
            displayAllHome();
        }

        private void homeWrite_Click(object sender, EventArgs e)
        {
            homeWrite.Enabled = false;
            progressBar.Enabled = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = 4 * PINMAX * PORTMAX;
            progressBar.Value = 0;
            string svString;
            if (SerialBegin() == true)
            {
                for (int i = 0; i < PORTMAX; i++)
                {
                    svString = "";
                    for (int j = 0; j < PINMAX; j++)
                    {
                        svString = svString + homePos[i, j].ToString() + ",";

                    }
                    dollSerialPort.WriteLine("h");
                    serialFlush();
                    dollSerialPort.WriteLine(svString);
                    for (int d = 0; d < svString.Length; d++)
                    {
                        Thread.Sleep(2);
                        progressBar.Value++;
                    }
                    dollSerialPort.WriteLine(i.ToString());
                    serialFlush();
                    dollSerialPort.WriteLine("f");
                    serialFlush();
                    Console.WriteLine(svString);
                }
            }
            dollSerialPort.Close();
            homeWrite.Enabled = true;
            progressBar.Value = 0;
            progressBar.Enabled = false;
            displayAllHome();
        }

        private void motionWrite_Click(object sender, EventArgs e)
        {
            writeForm = new writingMotion();
            writeForm.mainGUI = this;
            writeForm.Show();
        }

        public void defineMotion(int num)//モーションファイルを書き込む関数
        {
            Console.WriteLine("モーションファイル:motion" + num.ToString());
            motionWrite.Enabled = false;
            progressBar.Enabled = true;
            progressBar.Minimum = 0;
            Console.WriteLine("stepBAR.Maximum=" + stepBAR.Maximum.ToString());
            Console.WriteLine("PORTMAX=" + PORTMAX.ToString());
            int maximum = (stepBAR.Maximum + 1) * (PORTMAX * 5 + 5);
            Console.WriteLine("maximum=" + maximum.ToString());
            progressBar.Maximum = maximum;
            Console.WriteLine("progressBar.Maximum=" + progressBar.Maximum.ToString());
            progressBar.Value = 0;
            String svString;
            SerialBegin();
            for (int s = 0; s <= stepBAR.Maximum; s++)
            {
                svString = "";
                for (int i = 0; i < PORTMAX; i++)
                {
                    svString = "";
                    for (int j = 0; j < PINMAX; j++)
                    {
                        svString = svString + (posDeg[s, i, j] - homePos[i,j]).ToString() + ",";
                    }
                    svString = svString + "|";
                    dollSerialPort.WriteLine("m");
                    serialFlush();
                    progressBar.Value++;
                    dollSerialPort.WriteLine(svString);
                    Console.WriteLine("svString:" + svString);
                    serialFlush();
                    progressBar.Value++;
                    dollSerialPort.WriteLine(((s * PORTMAX) + i).ToString());
                    serialFlush();
                    progressBar.Value++;
                    dollSerialPort.WriteLine(num.ToString());
                    serialFlush();
                    progressBar.Value++;
                    dollSerialPort.WriteLine("f");
                    serialFlush();
                    progressBar.Value++;

                }
                svString = delays[s].ToString();
                dollSerialPort.WriteLine("m");
                serialFlush();
                progressBar.Value++;
                dollSerialPort.WriteLine(svString);
                Console.WriteLine("svString" + svString);
                serialFlush();
                progressBar.Value++;
                dollSerialPort.WriteLine(((s * PORTMAX) + PORTMAX).ToString());
                serialFlush();
                progressBar.Value++;
                dollSerialPort.WriteLine(num.ToString());
                serialFlush();
                progressBar.Value++;
                dollSerialPort.WriteLine("f");
                serialFlush();
                progressBar.Value++;
            }
            dollSerialPort.Close();
            motionWrite.Enabled = true;
            progressBar.Value = 0;
            progressBar.Enabled = false;
        }

        private void newMotion_Click(object sender, EventArgs e)
        {
            reForm = new resetForm();
            reForm.mainGUI = this;
            reForm.Show();
        }

        private void DollSerialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            dollSerialPort.Close();
            MessageBox.Show("通信エラーが発生しました");
        }

        private void motionTest_Click(object sender, EventArgs e)//モーション再生ウィンドを開く
        {
            moTest = new motionTest();
            moTest.mainGUI = this;
            moTest.Show();
        }

        public void motionTestTask(int fnum)//モーションを実際に再生する関数
        {
            Console.WriteLine("mv" + fnum + ":モーション再生開始");
            if (SerialBegin() == true)
            {
                dollSerialPort.WriteLine("t");
                serialFlush();
                dollSerialPort.WriteLine(fnum.ToString());
                serialFlush();
                dollSerialPort.WriteLine("f");
                serialFlush();
            }
            else
            {
                MessageBox.Show("シリアルポートが開けませんでした");
            }
        }

        private void copyMotionBack_Click(object sender, EventArgs e)//1つ前のモーションをコピー
        {
            if (step > 0)
            {
                for (int i = 0; i < useServo; i++)
                {
                    posDeg[step, servoTask[i].svPort, servoTask[i].svPin] = posDeg[step - 1, servoTask[i].svPort, servoTask[i].svPin];
                }
                displayAll();
            }
            else//現在のステップが0以下
            {
                MessageBox.Show("1つ前のステップが存在しません");
            }
        }

        private void copyMotionFlont_Click(object sender, EventArgs e)
        {
            if (step < maxStepValue)
            {
                for (int i = 0; i < useServo; i++)
                {
                    posDeg[step, servoTask[i].svPort, servoTask[i].svPin] = posDeg[step + 1, servoTask[i].svPort, servoTask[i].svPin];
                }
                displayAll();
            }
            else//現在のステップが最大ステップ数以上
            {
                MessageBox.Show("1つ後のステップが存在しません");
            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String readChar = dollSerialPort.ReadLine();
            writeConsole(readChar);
        }

        private void writeConsole(String line)
        {
            char keys = line[0];
            if (keys == '@')
            {
                writFlug = true;
            }
        }

        private void serialFlush()
        {
            int val = 0;
            while (writFlug == false)
            {
                Thread.Sleep(5);
                val++;
            }
            writFlug = false;
            Thread.Sleep(10);
        }

        private void backStep_Click(object sender, EventArgs e)
        {
            if (step > 0)
            {
                nextStep.Enabled = false;
                backStep.Enabled = false;
                step = step - 1;
                stepLabel.Text = stepBAR.Value.ToString();
                if (farstStep[step] == false)
                {
                    for (int i = 0; i < useServo; i++)
                    {
                        posDeg[step, servoTask[i].svPort, servoTask[i].svPin] = posDeg[step - 1, servoTask[i].svPort, servoTask[i].svPin];
                    }
                }
                displayAll();
                nextStep.Enabled = true;
                backStep.Enabled = true;
            }
        }

        private void nextStep_Click(object sender, EventArgs e)
        {
            if (step <  maxStepValue)
            {
                nextStep.Enabled = false;
                backStep.Enabled = false;
                step = step + 1;
                stepLabel.Text = stepBAR.Value.ToString();
                if (farstStep[step] == false)
                {
                    for (int i = 0; i < useServo; i++)
                    {
                        posDeg[step, servoTask[i].svPort, servoTask[i].svPin] = posDeg[step - 1, servoTask[i].svPort, servoTask[i].svPin];
                    }
                }
                displayAll();
                nextStep.Enabled = true;
                backStep.Enabled = true;
            }
        }

        private void portBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
