namespace ActiveX.FileControl
{
    partial class PictureForm
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
            this._pictureListControl = new ActiveX.FileControl.PictureListControl();
            this.SuspendLayout();
            // 
            // _pictureListControl
            // 
            this._pictureListControl.AutoSize = true;
            this._pictureListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pictureListControl.Location = new System.Drawing.Point(0, 0);
            this._pictureListControl.Name = "_pictureListControl";
            this._pictureListControl.Size = new System.Drawing.Size(1067, 458);
            this._pictureListControl.TabIndex = 0;
            // 
            // PictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 458);
            this.Controls.Add(this._pictureListControl);
            this.Name = "PictureForm";
            this.Text = "Bilder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureListControl _pictureListControl;
    }
}