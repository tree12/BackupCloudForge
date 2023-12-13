using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();    
            fileControl1.init();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            comboBox1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e) {
            /*comboBox1.SQLWhereKondition = "Firma not like '%fehr%'";
            comboBox1.LoadData();
            comboBox1.SetSize(500,500);*/
            txtBox.Text = "" + comboBox1.Value;
            // MessageBox.Show($"index: {comboBox1.SelectedIndex} - {comboBox1.SelectedItem}");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Clear();
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            fileControl1.UploadDocument("test.jpg", @"E:\Pictures\15.03.2003\IMG_3435.jpg");
        }
    }
}
