namespace FileMgr
{
    partial class OpenWithForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenWithForm));
            this.lstCommand = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstCommand
            // 
            this.lstCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCommand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstCommand.FormattingEnabled = true;
            this.lstCommand.Location = new System.Drawing.Point(0, 0);
            this.lstCommand.Name = "lstCommand";
            this.lstCommand.Size = new System.Drawing.Size(284, 261);
            this.lstCommand.TabIndex = 0;
            this.lstCommand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstCommand_MouseClick);
            this.lstCommand.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstCommand_DrawItem);            
            // 
            // OpenWithForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lstCommand);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenWithForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datei öffnen";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCommand;
    }
}

