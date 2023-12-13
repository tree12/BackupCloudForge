namespace AignerTest
{
    partial class Form1
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.btnUpdateFile = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.NumericUpDown();
            this.btnExecCmd = new System.Windows.Forms.Button();
            this.txtCmd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(292, 37);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(90, 23);
            this.btnChooseFile.TabIndex = 0;
            this.btnChooseFile.Text = "Datei einfügen";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(292, 87);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(89, 36);
            this.btnGetFile.TabIndex = 2;
            this.btnGetFile.Text = "Hole DAtei";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdateFile
            // 
            this.btnUpdateFile.Location = new System.Drawing.Point(292, 156);
            this.btnUpdateFile.Name = "btnUpdateFile";
            this.btnUpdateFile.Size = new System.Drawing.Size(90, 34);
            this.btnUpdateFile.TabIndex = 3;
            this.btnUpdateFile.Text = "Ändere Datei";
            this.btnUpdateFile.UseVisualStyleBackColor = true;
            this.btnUpdateFile.Click += new System.EventHandler(this.btnUpdateFile_Click);
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(133, 103);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(51, 20);
            this.txtNum.TabIndex = 4;
            this.txtNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnExecCmd
            // 
            this.btnExecCmd.Location = new System.Drawing.Point(188, 284);
            this.btnExecCmd.Name = "btnExecCmd";
            this.btnExecCmd.Size = new System.Drawing.Size(151, 55);
            this.btnExecCmd.TabIndex = 5;
            this.btnExecCmd.Text = "Kommando ausführen";
            this.btnExecCmd.UseVisualStyleBackColor = true;
            this.btnExecCmd.Click += new System.EventHandler(this.btnExecCmd_Click);
            // 
            // txtCmd
            // 
            this.txtCmd.Location = new System.Drawing.Point(25, 258);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(314, 20);
            this.txtCmd.TabIndex = 6;
            this.txtCmd.Text = "FileMgr /action open /file_PK 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 392);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.btnExecCmd);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.btnUpdateFile);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.btnChooseFile);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.txtNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.Button btnUpdateFile;
        private System.Windows.Forms.NumericUpDown txtNum;
        private System.Windows.Forms.Button btnExecCmd;
        private System.Windows.Forms.TextBox txtCmd;
    }
}

