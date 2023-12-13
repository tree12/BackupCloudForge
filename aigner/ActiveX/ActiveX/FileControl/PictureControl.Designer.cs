namespace ActiveX.FileControl
{
    partial class PictureControl
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
            this.pictureAdd = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureAdd
            // 
            this.pictureAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureAdd.Image = global::ActiveX.Properties.Resources.add;
            this.pictureAdd.Location = new System.Drawing.Point(0, 0);
            this.pictureAdd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pictureAdd.Name = "pictureAdd";
            this.pictureAdd.Size = new System.Drawing.Size(289, 193);
            this.pictureAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureAdd.TabIndex = 2;
            this.pictureAdd.TabStop = false;
            this.pictureAdd.Click += new System.EventHandler(this.pictureAdd_Click);
            // 
            // picDelete
            // 
            this.picDelete.BackColor = System.Drawing.Color.Transparent;
            this.picDelete.Image = global::ActiveX.Properties.Resources.delete_pic;
            this.picDelete.Location = new System.Drawing.Point(219, 129);
            this.picDelete.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(64, 58);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDelete.TabIndex = 1;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.ImageLocation = "E:\\Pictures\\24.05.2004\\IMG_4698.JPG";
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(289, 193);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragDrop);
            this.pictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragEnter);
            this.pictureBox.DragLeave += new System.EventHandler(this.pictureBox_DragLeave);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            // 
            // PictureControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.pictureAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "PictureControl";
            this.Size = new System.Drawing.Size(289, 193);
            ((System.ComponentModel.ISupportInitialize)(this.pictureAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.PictureBox pictureAdd;
    }
}
