namespace InspireMovement
{
    partial class newBoneForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.saveBone = new System.Windows.Forms.Button();
            this.saveBoneFile = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(1045, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 136);
            this.button1.TabIndex = 0;
            this.button1.Text = "コントローラー追加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // saveBone
            // 
            this.saveBone.Location = new System.Drawing.Point(1045, 148);
            this.saveBone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveBone.Name = "saveBone";
            this.saveBone.Size = new System.Drawing.Size(230, 124);
            this.saveBone.TabIndex = 1;
            this.saveBone.Text = "保存する";
            this.saveBone.UseVisualStyleBackColor = true;
            this.saveBone.Click += new System.EventHandler(this.SaveBone_Click);
            // 
            // newBoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1278, 1050);
            this.Controls.Add(this.saveBone);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "newBoneForm";
            this.Text = "新規骨格ファイル作成";
            this.Load += new System.EventHandler(this.NewBoneForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveBone;
        private System.Windows.Forms.SaveFileDialog saveBoneFile;
    }
}