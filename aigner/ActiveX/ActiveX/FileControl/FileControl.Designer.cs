namespace ActiveX.FileControl
{
    partial class FileControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenDocuments = new System.Windows.Forms.Button();
            this.btnPicture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenDocuments
            // 
            this.btnOpenDocuments.Location = new System.Drawing.Point(0, 0);
            this.btnOpenDocuments.Name = "btnOpenDocuments";
            this.btnOpenDocuments.Size = new System.Drawing.Size(117, 23);
            this.btnOpenDocuments.TabIndex = 0;
            this.btnOpenDocuments.Text = "Dokumente";
            this.btnOpenDocuments.UseVisualStyleBackColor = true;
            this.btnOpenDocuments.Click += new System.EventHandler(this.btnOpenDocuments_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(123, 0);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(121, 23);
            this.btnPicture.TabIndex = 1;
            this.btnPicture.Text = "Bilder (0)";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // FileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.btnOpenDocuments);
            this.Name = "FileControl";
            this.Size = new System.Drawing.Size(247, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenDocuments;
        private System.Windows.Forms.Button btnPicture;
    }
}
