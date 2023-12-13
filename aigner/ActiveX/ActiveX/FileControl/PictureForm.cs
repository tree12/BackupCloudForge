using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveX.FileControl
{
    public partial class PictureForm : Form
    {
        public PictureForm()
        {
            InitializeComponent();
        }

        private FileControl _fileControl;

        public void Init(FileControl fileControl)
        {
            _fileControl = fileControl;
            _pictureListControl.Init(_fileControl);
        }

        public PictureListControl PictureListControl => _pictureListControl;
      
    }
}
