using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveX.FileControl
{
    public partial class PictureControl : UserControl
    {

        public EventHandler<Picture> DeletePicturEventHandler;
        public EventHandler<Picture> MovePicturEventHandler;
        public EventHandler AddPicturEventHandler;

        public PictureControl()
        {
            InitializeComponent();
            pictureBox.Visible = false;
            picDelete.Visible = false;
            pictureBox.AllowDrop = true;
        }

        private Picture _picture;
        private int? _number;

        public int? Number
        {
            get => _number;
            set => _number = value;
        }       
   
        public Picture Picture
        {
            get => _picture;
            set
            {
                picDelete.Visible = true;
                pictureAdd.Visible = false;
                pictureBox.Visible = true;
                _picture = value;
                pictureBox.ImageLocation = _picture.File.FullName;
            }
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            DeletePicturEventHandler?.Invoke(this,_picture);
        }

        private void pictureAdd_Click(object sender, EventArgs e)
        {
            AddPicturEventHandler?.Invoke(this,EventArgs.Empty);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {

            if (_number != null)
            {
                if (IsDragOver)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(151,151,185,222)),0,0,Width,Height);
                }
                
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                Point pos = new Point(10, 10);                
                SizeF s=e.Graphics.MeasureString("" + _number, Font);
                Rectangle rect = new Rectangle(pos.X,pos.Y,(int)s.Width,(int)s.Height);
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, 100, 100, 100)), rect.X-2,rect.Y-2,rect.Width+4,rect.Height+4);
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(200, 200, 200, 200)),rect);
                e.Graphics.DrawString("" + _number, Font, new SolidBrush(Color.FromArgb(100, 100, 100, 100)), pos);
            }            
        }

        private PictureControl _dragDropPictureControl;
                      

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                                
                Parent.DoDragDrop(this, DragDropEffects.Move);
            }
        }


        private bool _isDragOver = false;

        public bool IsDragOver
        {
            get => _isDragOver;
            set
            {
                if (_isDragOver==value) return;                
                _isDragOver = value;
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            PictureControl control = e.Data.GetData(typeof(PictureControl)) as PictureControl;
            if (control!=null && control != this && Number!=null)
            {
                IsDragOver = true;
                e.Effect = DragDropEffects.Move;
            }

        }

        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            IsDragOver = false;
            PictureControl control = e.Data.GetData(typeof(PictureControl)) as PictureControl;
            MovePicturEventHandler?.Invoke(this,control.Picture);
        }

        private void pictureBox_DragLeave(object sender, EventArgs e)
        {
            IsDragOver = false;
        }
    }
}
