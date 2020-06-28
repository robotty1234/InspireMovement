namespace InspireMovement
{
    partial class setControle
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
            this.textBoxSet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portSet = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pinSet = new System.Windows.Forms.NumericUpDown();
            this.saveSet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "コントロール名";
            // 
            // textBoxSet
            // 
            this.textBoxSet.Location = new System.Drawing.Point(125, 16);
            this.textBoxSet.Name = "textBoxSet";
            this.textBoxSet.Size = new System.Drawing.Size(173, 25);
            this.textBoxSet.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ポート";
            // 
            // portSet
            // 
            this.portSet.Location = new System.Drawing.Point(71, 58);
            this.portSet.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.portSet.Name = "portSet";
            this.portSet.Size = new System.Drawing.Size(58, 25);
            this.portSet.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "ピン";
            // 
            // pinSet
            // 
            this.pinSet.Location = new System.Drawing.Point(190, 58);
            this.pinSet.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.pinSet.Name = "pinSet";
            this.pinSet.Size = new System.Drawing.Size(57, 25);
            this.pinSet.TabIndex = 5;
            // 
            // saveSet
            // 
            this.saveSet.Location = new System.Drawing.Point(253, 89);
            this.saveSet.Name = "saveSet";
            this.saveSet.Size = new System.Drawing.Size(75, 36);
            this.saveSet.TabIndex = 6;
            this.saveSet.Text = "保存";
            this.saveSet.UseVisualStyleBackColor = true;
            this.saveSet.Click += new System.EventHandler(this.saveSet_Click);
            // 
            // setControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 137);
            this.Controls.Add(this.saveSet);
            this.Controls.Add(this.pinSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSet);
            this.Controls.Add(this.label1);
            this.Name = "setControle";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown portSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown pinSet;
        private System.Windows.Forms.Button saveSet;
    }
}