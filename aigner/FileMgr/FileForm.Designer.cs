namespace FileMgr
{
    partial class FileForm
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
            this._lstViewFiles = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.grpViewType = new System.Windows.Forms.GroupBox();
            this.btnViewIcon = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.grpViewType.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lstViewFiles
            // 
            this._lstViewFiles.AllowDrop = true;
            this._lstViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lstViewFiles.Location = new System.Drawing.Point(-1, 0);
            this._lstViewFiles.Name = "_lstViewFiles";
            this._lstViewFiles.Size = new System.Drawing.Size(871, 318);
            this._lstViewFiles.TabIndex = 0;
            this._lstViewFiles.UseCompatibleStateImageBehavior = false;
            this._lstViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstViewFiles_DragDrop);
            this._lstViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstViewFiles_DragEnter);
            this._lstViewFiles.DoubleClick += new System.EventHandler(this.lstViewFiles_DoubleClick);
            this._lstViewFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this._lstViewFiles_MouseDown);
            this._lstViewFiles.MouseMove += new System.Windows.Forms.MouseEventHandler(this._lstViewFiles_MouseMove);
            this._lstViewFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this._lstViewFiles_MouseUp);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(613, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // grpViewType
            // 
            this.grpViewType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpViewType.Controls.Add(this.btnViewIcon);
            this.grpViewType.Controls.Add(this.btnViewDetail);
            this.grpViewType.Location = new System.Drawing.Point(-1, 324);
            this.grpViewType.Name = "grpViewType";
            this.grpViewType.Size = new System.Drawing.Size(177, 76);
            this.grpViewType.TabIndex = 2;
            this.grpViewType.TabStop = false;
            this.grpViewType.Text = "Ansicht";
            // 
            // btnViewIcon
            // 
            this.btnViewIcon.Image = global::FileMgr.Properties.Resources.windows_view_icon;
            this.btnViewIcon.Location = new System.Drawing.Point(88, 19);
            this.btnViewIcon.Name = "btnViewIcon";
            this.btnViewIcon.Size = new System.Drawing.Size(85, 51);
            this.btnViewIcon.TabIndex = 1;
            this.btnViewIcon.UseVisualStyleBackColor = true;
            this.btnViewIcon.Click += new System.EventHandler(this.btnViewIcon_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnViewDetail.Image = global::FileMgr.Properties.Resources.windows_view_detail;
            this.btnViewDetail.Location = new System.Drawing.Point(6, 19);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(76, 51);
            this.btnViewDetail.TabIndex = 0;
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 431);
            this.Controls.Add(this.grpViewType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._lstViewFiles);
            this.Name = "FileForm";
            this.Text = "FileForm";
            this.Load += new System.EventHandler(this.FileForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileForm_KeyDown);
            this.grpViewType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _lstViewFiles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpViewType;
        private System.Windows.Forms.Button btnViewIcon;
        private System.Windows.Forms.Button btnViewDetail;
    }
}