namespace InspireMovement
{
    partial class mainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.dollSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.openFiles = new System.Windows.Forms.OpenFileDialog();
            this.saveMotion = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.delayVal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.maxStep = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.stepLabel = new System.Windows.Forms.Label();
            this.stepBAR = new System.Windows.Forms.TrackBar();
            this.saveBone = new System.Windows.Forms.Button();
            this.newBone = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.ComboBox();
            this.sutchPort = new System.Windows.Forms.Button();
            this.motionSave = new System.Windows.Forms.Button();
            this.link = new System.Windows.Forms.CheckBox();
            this.homeSave = new System.Windows.Forms.Button();
            this.motionRead = new System.Windows.Forms.Button();
            this.homeRead = new System.Windows.Forms.Button();
            this.motionWrite = new System.Windows.Forms.Button();
            this.homeWrite = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.newMotion = new System.Windows.Forms.Button();
            this.motionTest = new System.Windows.Forms.Button();
            this.copyMotionBack = new System.Windows.Forms.Button();
            this.copyMotionFlont = new System.Windows.Forms.Button();
            this.backStep = new System.Windows.Forms.Button();
            this.nextStep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.delayVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepBAR)).BeginInit();
            this.SuspendLayout();
            // 
            // dollSerialPort
            // 
            this.dollSerialPort.DtrEnable = true;
            this.dollSerialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.DollSerialPort_ErrorReceived);
            this.dollSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // openFiles
            // 
            this.openFiles.FileName = "openFileDialog1";
            this.openFiles.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "動作時間(ms)";
            // 
            // delayVal
            // 
            this.delayVal.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.delayVal.Location = new System.Drawing.Point(15, 32);
            this.delayVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.delayVal.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.delayVal.Name = "delayVal";
            this.delayVal.Size = new System.Drawing.Size(150, 25);
            this.delayVal.TabIndex = 1;
            this.delayVal.ValueChanged += new System.EventHandler(this.delay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "最大ステップ数";
            // 
            // maxStep
            // 
            this.maxStep.Location = new System.Drawing.Point(320, 8);
            this.maxStep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maxStep.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.maxStep.Name = "maxStep";
            this.maxStep.Size = new System.Drawing.Size(67, 25);
            this.maxStep.TabIndex = 3;
            this.maxStep.ValueChanged += new System.EventHandler(this.maxStep_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "step：";
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.Location = new System.Drawing.Point(240, 40);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(17, 18);
            this.stepLabel.TabIndex = 5;
            this.stepLabel.Text = "0";
            // 
            // stepBAR
            // 
            this.stepBAR.Enabled = false;
            this.stepBAR.LargeChange = 1;
            this.stepBAR.Location = new System.Drawing.Point(257, 42);
            this.stepBAR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stepBAR.Maximum = 0;
            this.stepBAR.Name = "stepBAR";
            this.stepBAR.Size = new System.Drawing.Size(142, 69);
            this.stepBAR.TabIndex = 6;
            this.stepBAR.Scroll += new System.EventHandler(this.stepBAR_Scroll);
            // 
            // saveBone
            // 
            this.saveBone.Location = new System.Drawing.Point(412, 2);
            this.saveBone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveBone.Name = "saveBone";
            this.saveBone.Size = new System.Drawing.Size(268, 38);
            this.saveBone.TabIndex = 7;
            this.saveBone.Text = "骨格ファイルを読み込む(.bone)";
            this.saveBone.UseVisualStyleBackColor = true;
            this.saveBone.Click += new System.EventHandler(this.saveBone_Click);
            // 
            // newBone
            // 
            this.newBone.Location = new System.Drawing.Point(412, 42);
            this.newBone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newBone.Name = "newBone";
            this.newBone.Size = new System.Drawing.Size(268, 38);
            this.newBone.TabIndex = 8;
            this.newBone.Text = "骨格ファイルを新規で作成(.bone)";
            this.newBone.UseVisualStyleBackColor = true;
            this.newBone.Click += new System.EventHandler(this.NewBone_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1648, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "使用するシリアルポート";
            // 
            // portBox
            // 
            this.portBox.FormattingEnabled = true;
            this.portBox.Location = new System.Drawing.Point(1652, 135);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(167, 26);
            this.portBox.TabIndex = 10;
            this.portBox.SelectedIndexChanged += new System.EventHandler(this.portBox_SelectedIndexChanged);
            // 
            // sutchPort
            // 
            this.sutchPort.Location = new System.Drawing.Point(1842, 118);
            this.sutchPort.Name = "sutchPort";
            this.sutchPort.Size = new System.Drawing.Size(287, 46);
            this.sutchPort.TabIndex = 11;
            this.sutchPort.Text = "使用可能なシリアルポートを探す";
            this.sutchPort.UseVisualStyleBackColor = true;
            this.sutchPort.Click += new System.EventHandler(this.sutchPort_Click);
            // 
            // motionSave
            // 
            this.motionSave.Location = new System.Drawing.Point(1652, 290);
            this.motionSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.motionSave.Name = "motionSave";
            this.motionSave.Size = new System.Drawing.Size(250, 68);
            this.motionSave.TabIndex = 14;
            this.motionSave.Text = "モーションを保存する\r\n(.udm)";
            this.motionSave.UseVisualStyleBackColor = true;
            this.motionSave.Click += new System.EventHandler(this.motionSave_Click);
            // 
            // link
            // 
            this.link.Appearance = System.Windows.Forms.Appearance.Button;
            this.link.AutoSize = true;
            this.link.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.link.Location = new System.Drawing.Point(1652, 40);
            this.link.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(289, 34);
            this.link.TabIndex = 15;
            this.link.Text = "サーボモーターを同期させる";
            this.link.UseVisualStyleBackColor = true;
            this.link.CheckedChanged += new System.EventHandler(this.link_CheckedChanged);
            // 
            // homeSave
            // 
            this.homeSave.Location = new System.Drawing.Point(1652, 366);
            this.homeSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.homeSave.Name = "homeSave";
            this.homeSave.Size = new System.Drawing.Size(250, 68);
            this.homeSave.TabIndex = 16;
            this.homeSave.Text = "ホームポジションを保存する(.udh)";
            this.homeSave.UseVisualStyleBackColor = true;
            this.homeSave.Click += new System.EventHandler(this.homeSave_Click);
            // 
            // motionRead
            // 
            this.motionRead.Location = new System.Drawing.Point(1652, 442);
            this.motionRead.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.motionRead.Name = "motionRead";
            this.motionRead.Size = new System.Drawing.Size(250, 68);
            this.motionRead.TabIndex = 17;
            this.motionRead.Text = "モーションファイルを読み込む(.udm)";
            this.motionRead.UseVisualStyleBackColor = true;
            this.motionRead.Click += new System.EventHandler(this.motionRead_Click);
            // 
            // homeRead
            // 
            this.homeRead.Location = new System.Drawing.Point(1652, 519);
            this.homeRead.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.homeRead.Name = "homeRead";
            this.homeRead.Size = new System.Drawing.Size(250, 68);
            this.homeRead.TabIndex = 18;
            this.homeRead.Text = "ホームファイルを読み込み\r\n(.udh)\r\n";
            this.homeRead.UseVisualStyleBackColor = true;
            this.homeRead.Click += new System.EventHandler(this.homeRead_Click);
            // 
            // motionWrite
            // 
            this.motionWrite.Location = new System.Drawing.Point(1652, 651);
            this.motionWrite.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.motionWrite.Name = "motionWrite";
            this.motionWrite.Size = new System.Drawing.Size(250, 68);
            this.motionWrite.TabIndex = 19;
            this.motionWrite.Text = "モーションファイルを書き込む";
            this.motionWrite.UseVisualStyleBackColor = true;
            this.motionWrite.Click += new System.EventHandler(this.motionWrite_Click);
            // 
            // homeWrite
            // 
            this.homeWrite.Location = new System.Drawing.Point(1652, 728);
            this.homeWrite.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.homeWrite.Name = "homeWrite";
            this.homeWrite.Size = new System.Drawing.Size(250, 68);
            this.homeWrite.TabIndex = 20;
            this.homeWrite.Text = "ホームポジションを書き込む";
            this.homeWrite.UseVisualStyleBackColor = true;
            this.homeWrite.Click += new System.EventHandler(this.homeWrite_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(1652, 862);
            this.progressBar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(387, 34);
            this.progressBar.TabIndex = 21;
            // 
            // newMotion
            // 
            this.newMotion.Location = new System.Drawing.Point(688, 2);
            this.newMotion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.newMotion.Name = "newMotion";
            this.newMotion.Size = new System.Drawing.Size(208, 34);
            this.newMotion.TabIndex = 22;
            this.newMotion.Text = "モーションの新規作成";
            this.newMotion.UseVisualStyleBackColor = true;
            this.newMotion.Click += new System.EventHandler(this.newMotion_Click);
            // 
            // motionTest
            // 
            this.motionTest.Location = new System.Drawing.Point(688, 43);
            this.motionTest.Name = "motionTest";
            this.motionTest.Size = new System.Drawing.Size(208, 37);
            this.motionTest.TabIndex = 23;
            this.motionTest.Text = "モーションを再生";
            this.motionTest.UseVisualStyleBackColor = true;
            this.motionTest.Click += new System.EventHandler(this.motionTest_Click);
            // 
            // copyMotionBack
            // 
            this.copyMotionBack.Location = new System.Drawing.Point(904, 2);
            this.copyMotionBack.Name = "copyMotionBack";
            this.copyMotionBack.Size = new System.Drawing.Size(215, 34);
            this.copyMotionBack.TabIndex = 24;
            this.copyMotionBack.Text = "1つ前のモーションをコピー";
            this.copyMotionBack.UseVisualStyleBackColor = true;
            this.copyMotionBack.Click += new System.EventHandler(this.copyMotionBack_Click);
            // 
            // copyMotionFlont
            // 
            this.copyMotionFlont.Location = new System.Drawing.Point(904, 43);
            this.copyMotionFlont.Name = "copyMotionFlont";
            this.copyMotionFlont.Size = new System.Drawing.Size(215, 37);
            this.copyMotionFlont.TabIndex = 25;
            this.copyMotionFlont.Text = "1つ後のモーションをコピー";
            this.copyMotionFlont.UseVisualStyleBackColor = true;
            this.copyMotionFlont.Click += new System.EventHandler(this.copyMotionFlont_Click);
            // 
            // backStep
            // 
            this.backStep.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.backStep.Location = new System.Drawing.Point(198, 94);
            this.backStep.Name = "backStep";
            this.backStep.Size = new System.Drawing.Size(97, 27);
            this.backStep.TabIndex = 26;
            this.backStep.Text = "1つ戻る";
            this.backStep.UseVisualStyleBackColor = true;
            this.backStep.Click += new System.EventHandler(this.backStep_Click);
            // 
            // nextStep
            // 
            this.nextStep.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.nextStep.Location = new System.Drawing.Point(301, 94);
            this.nextStep.Name = "nextStep";
            this.nextStep.Size = new System.Drawing.Size(98, 27);
            this.nextStep.TabIndex = 28;
            this.nextStep.Text = "1つ進む";
            this.nextStep.UseVisualStyleBackColor = true;
            this.nextStep.Click += new System.EventHandler(this.nextStep_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.nextStep);
            this.Controls.Add(this.backStep);
            this.Controls.Add(this.copyMotionFlont);
            this.Controls.Add(this.copyMotionBack);
            this.Controls.Add(this.motionTest);
            this.Controls.Add(this.newMotion);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.homeWrite);
            this.Controls.Add(this.motionWrite);
            this.Controls.Add(this.homeRead);
            this.Controls.Add(this.motionRead);
            this.Controls.Add(this.homeSave);
            this.Controls.Add(this.link);
            this.Controls.Add(this.motionSave);
            this.Controls.Add(this.sutchPort);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.newBone);
            this.Controls.Add(this.saveBone);
            this.Controls.Add(this.stepBAR);
            this.Controls.Add(this.stepLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxStep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.delayVal);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "mainForm";
            this.Text = "InspireMovement";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.delayVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepBAR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort dollSerialPort;
        private System.Windows.Forms.OpenFileDialog openFiles;
        private System.Windows.Forms.SaveFileDialog saveMotion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown delayVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label stepLabel;
        private System.Windows.Forms.TrackBar stepBAR;
        private System.Windows.Forms.Button saveBone;
        private System.Windows.Forms.Button newBone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox portBox;
        private System.Windows.Forms.Button sutchPort;
        private System.Windows.Forms.Button motionSave;
        private System.Windows.Forms.CheckBox link;
        private System.Windows.Forms.Button homeSave;
        private System.Windows.Forms.Button motionRead;
        private System.Windows.Forms.Button homeRead;
        private System.Windows.Forms.Button motionWrite;
        private System.Windows.Forms.Button homeWrite;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button newMotion;
        private System.Windows.Forms.Button motionTest;
        private System.Windows.Forms.Button copyMotionBack;
        private System.Windows.Forms.Button copyMotionFlont;
        private System.Windows.Forms.Button backStep;
        private System.Windows.Forms.Button nextStep;
    }
}

