using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AignerDLL.DataObjects;

namespace FileMgr
{
    public partial class FilePropertiesForm : Form {
        private FileData _file;
        public FilePropertiesForm()
        {
            InitializeComponent();
        }

        public FilePropertiesForm(FileData file) :this() {
            _file = file;
            txtComment.Text = file.Comment;
        }

        public string Comment => txtComment.Text;
    }
}
