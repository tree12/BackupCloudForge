namespace TestForm
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.fileControl1 = new ActiveX.FileControl.FileControl();
            this.comboBox2 = new Aigner.ComboBox();
            this.comboBox1 = new Aigner.ComboBox();
            this.btnAddDocument = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(65, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 20);
            this.button2.TabIndex = 3;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(24, 126);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(95, 20);
            this.txtBox.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(230, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // fileControl1
            // 
            this.fileControl1.Location = new System.Drawing.Point(24, 210);
            this.fileControl1.Name = "fileControl1";
            this.fileControl1.ObjectKey = "123-1234123";
            this.fileControl1.ObjectName = "Testartikel";
            this.fileControl1.ObjectTag = "Artikel";
            this.fileControl1.Size = new System.Drawing.Size(249, 24);
            this.fileControl1.TabIndex = 5;
            this.fileControl1.Verbindungszeichenfolge = "ODBC;DRIVER={SQL Server Native Client 11.0};SERVER=localhost\\sqlexpress;DATABASE=" +
    "AignerTestSQL;UID=ccss;PWD=$ccss$";
            // 
            // comboBox2
            // 
            this.comboBox2.AngezeigteSpalten = "AuftragNr;DatumAuftrag;Firma";
            this.comboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox2.DropDownHeight = 537;
            this.comboBox2.DropDownItemCount = 30;
            this.comboBox2.DropDownWidth = 489;
            this.comboBox2.FloatProperty = 0F;
            this.comboBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.Location = new System.Drawing.Point(16, 96);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.SchluesselSpalte = "AuftragID";
            this.comboBox2.Size = new System.Drawing.Size(200, 23);
            this.comboBox2.Spaltengroessen = "60;0;400";
            this.comboBox2.SQLOrderBy = null;
            this.comboBox2.SQLWhereKondition = "Firma not like \'%aigner%\'";
            this.comboBox2.SuchSpalten = null;
            this.comboBox2.TabellenName = "qrycbauftrag";
            this.comboBox2.TabIndex = 2;
            this.comboBox2.TextSpalte = null;
            this.comboBox2.Value = ((long)(0));
            this.comboBox2.Verbindungszeichenfolge = "ODBC;DRIVER={SQL Server Native Client 11.0};SERVER=localhost\\sqlexpress;DATABASE=" +
    "AignerTestSQL;UID=ccss;PWD=$ccss$";
            // 
            // comboBox1
            // 
            this.comboBox1.AngezeigteSpalten = "AuftragID;Type;name3";
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownHeight = 537;
            this.comboBox1.DropDownItemCount = 30;
            this.comboBox1.DropDownWidth = 329;
            this.comboBox1.FloatProperty = 0F;
            this.comboBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(16, 27);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SchluesselSpalte = "AuftragID";
            this.comboBox1.Size = new System.Drawing.Size(200, 23);
            this.comboBox1.Spaltengroessen = "";
            this.comboBox1.SQLOrderBy = "name3 desc";
            this.comboBox1.SQLWhereKondition = "name3 is not null";
            this.comboBox1.SuchSpalten = "name3";
            this.comboBox1.TabellenName = "tblAuftrag";
            this.comboBox1.TabIndex = 0;
            this.comboBox1.TextSpalte = "Type";
            this.comboBox1.Value = ((long)(0));
            this.comboBox1.Verbindungszeichenfolge = "ODBC;DRIVER={SQL Server Native Client 11.0};SERVER=localhost\\sqlexpress;DATABASE=" +
    "AignerTestSQL;UID=ccss;PWD=$ccss$";
            // 
            // btnAddDocument
            // 
            this.btnAddDocument.Location = new System.Drawing.Point(88, 271);
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.Size = new System.Drawing.Size(102, 24);
            this.btnAddDocument.TabIndex = 7;
            this.btnAddDocument.Text = "AddDocument";
            this.btnAddDocument.UseVisualStyleBackColor = true;
            this.btnAddDocument.Click += new System.EventHandler(this.btnAddDocument_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 395);
            this.Controls.Add(this.btnAddDocument);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.fileControl1);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Aigner.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private Aigner.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBox;
        private ActiveX.FileControl.FileControl fileControl1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAddDocument;
    }
}

