using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AignerDLL;
using AignerDLL.DB;

namespace AignerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        SqlConnection _conn;
        

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {            
            try
            {
                FileInfo fi = new FileInfo(openFileDialog.FileName);
                var o = InsertFile(fi);

                MessageBox.Show(this, "Datensatz mit ID=" + o + " eingefügt!", "Erfolg!");
            } catch (Exception ex)
            {
                Global.Error("Fehler bei upload von Daten", ex);
            }

        }

        private int InsertFile(FileInfo fi) {
            using (var ft = new FileTable())
            {
                return ft.InsertFile("3", "test", fi);
            }
        }


        private void button1_Click(object sender, EventArgs e) {
            using (var ft = new FileTable()) {
                ft.GetFile(Convert.ToInt32(txtNum.Value), Global.DataDir, FileAccess.Write);
            }
        }

        private void btnUpdateFile_Click(object sender, EventArgs e) {
            DialogResult r = openFileDialog.ShowDialog(this);
            if (r!=DialogResult.OK) return;
            

            using (var ft = new FileTable())
            {
                FileInfo fi = new FileInfo(openFileDialog.FileName);
                ft.UpdateFile(Convert.ToInt32(txtNum.Value), fi);
            }
        }

        private void btnExecCmd_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = txtCmd.Text,
                UseShellExecute = false,
                ErrorDialog = true
            };
            Process p = Process.Start(startInfo);
            p.WaitForExit();
            MessageBox.Show("Kommando zurück.");
        }
    }
}
