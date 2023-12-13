using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMgr
{
    public partial class OpenWithForm : Form {
        private List<Tuple<String, String, Icon>> _data;

        public Tuple<String, String, Icon> SelectedValue { get; private set; }
        private bool _exitThread;

        public OpenWithForm()
        {
            InitializeComponent();
        }

        public OpenWithForm(List<Tuple<String, String, Icon>> data, bool exitThread):this() {
            _data = data;
            _exitThread = exitThread;
            lstCommand.DataSource = data;
            lstCommand.ItemHeight = 100;
            Size=new Size(200,data.Count*100);
        }

        private void lstCommand_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index < 0 || e.Index >= _data.Count) return;
            Tuple<String, String, Icon> data = _data[e.Index];
            Rectangle b = e.Bounds;
            int aktX = b.X;
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.Cornsilk,b);
            g.DrawRectangle(new Pen(Brushes.BurlyWood,3), b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            if (data.Item3 != null) {
                int icontsize = 50;
                int space = (b.Height - icontsize)/2;
                g.DrawIcon(data.Item3,new Rectangle(b.X+space, b.Y+space, icontsize, icontsize));
                aktX += icontsize+2*space;
            }
            Font font = new Font(this.Font.FontFamily,20);
            Rectangle fontRect = new Rectangle(aktX, b.Y, b.Width - aktX, b.Height);
            SizeF meassure = g.MeasureString(data.Item1, font, fontRect.Size);
            if (meassure.Height < fontRect.Height) {
                float space = (fontRect.Height - meassure.Height)/2;
                fontRect.Y +=(int) space;
                fontRect.Height -= (int)space;
            }
            g.DrawString(data.Item1,font,new SolidBrush(Color.DarkSlateBlue),fontRect);
        }
        /*
        private void lstCommand_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedValue =  lstCommand.SelectedItem as Tuple<string, string, Icon>;
           
        }*/

        private void lstCommand_MouseClick(object sender, MouseEventArgs e) {
            int i = lstCommand.IndexFromPoint(e.X, e.Y);
            if (i < 0 || i >= lstCommand.Items.Count) return;
            SelectedValue = lstCommand.Items[i] as Tuple<string, string, Icon>;
            if (_exitThread)
                Application.ExitThread();
            else
                this.Close();
        }
    }
}
