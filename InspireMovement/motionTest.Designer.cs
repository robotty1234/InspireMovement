namespace InspireMovement
{
    partial class motionTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.motionStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "再生したいモーションファイルの番号を入力して「再生」をクリックしてください";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(69, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "mv";
            // 
            // fileNum
            // 
            this.fileNum.Location = new System.Drawing.Point(105, 48);
            this.fileNum.Name = "fileNum";
            this.fileNum.Size = new System.Drawing.Size(120, 25);
            this.fileNum.TabIndex = 2;
            this.fileNum.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(221, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = ".udm";
            // 
            // motionStart
            // 
            this.motionStart.Location = new System.Drawing.Point(379, 49);
            this.motionStart.Name = "motionStart";
            this.motionStart.Size = new System.Drawing.Size(167, 40);
            this.motionStart.TabIndex = 4;
            this.motionStart.Text = "再生";
            this.motionStart.UseVisualStyleBackColor = true;
            this.motionStart.Click += new System.EventHandler(this.motionStart_Click);
            // 
            // motionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 117);
            this.Controls.Add(this.motionStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fileNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "motionTest";
            this.Text = "motionTest";
            this.Load += new System.EventHandler(this.motionTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown fileNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button motionStart;
    }
}