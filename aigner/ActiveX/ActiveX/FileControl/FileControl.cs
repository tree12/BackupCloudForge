using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aigner;
using ATom.CommonBasics.Extension;

namespace ActiveX.FileControl
{
    /// <summary>
    /// AxCSActiveXCtrl describes the COM interface of the coclass 
    /// </summary>
    [Guid("7BE9B906-2984-4012-B713-4919D7AF4388")]
    //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    //[ComVisible(true)]
    public interface AxFileControl
    {
        void SetSize(int width, int height);

        string ObjectTag { get; set; }
        string ObjectKey { get; set; }
        string ObjectName { get; set; }

        void init();

        bool Visible { get; set; } // Typical control property
        bool Enabled { get; set; } // Typical control property

        void OpenDocuments();
        string GetDocumentDirectory(string objectTag, string objectKey, string objectName = null);
        string DocumentDirectory { get; }
        void OpenPictures();

        void UploadDocument(string name, string file);

        string Verbindungszeichenfolge { get; set; } // Typical control property
    }

    /// <summary>
    /// AxCSActiveXCtrlEvents describes the events the coclass can sink
    /// </summary>
    [Guid("A2546B0B-8B6B-4EAE-8894-E42BB68D3F57")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    //[ComVisible(true)]
    // The public interface describing the events of the control
    public interface AxFileControlEvents
    {
        #region Events

        // Must explicitly define DISPID for each event, otherwise, the 
        // callback address cannot be found when the event is fired.
        [DispId(23)]
        void Click();

        [DispId(24)]
        void InitPicture();

        [DispId(25)]
        void DocumentCountChanged(int count);

        [DispId(26)]
        void PictureCountChanged(int count);

        #endregion
    }

    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(AxFileControlEvents))]
    //[ComVisible(true)]
    [Guid("02D7005B-14C6-4085-AC8E-80777DEE69F8")]
    public partial class FileControl : ActiveXBase, AxFileControl, IAxActiveXBase
    {
        public FileControl()
        {
            InitializeComponent();
        }

        #region ActiveX Control Registration

        [ComVisible(false)]
        public delegate void EventHandler();

        public event EventHandler InitPicture = null;

        // These routines perform the additional COM registration needed by 
        // ActiveX controls

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComRegisterFunction()]
        public static void Register(Type t)
        {
            try
            {
                ActiveXCtrlHelper.RegasmRegisterControl(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the error
                throw; // Re-throw the exception
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComUnregisterFunction()]
        public static void Unregister(Type t)
        {
            try
            {
                ActiveXCtrlHelper.RegasmUnregisterControl(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the error
                throw; // Re-throw the exception
            }
        }

        #endregion ActiveX Control Registration

        private void Query()
        {
            OdbcCommand command = Conn?.CreateCommand();
            if (command == null) return;
            string where = "";


            command.CommandText = "";
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
            }
            reader.Close();
        }

        public void UploadDocument(string name, string file)
        {
            try
            {
                string objectName = ObjectName;
                if (objectName == null) objectName = MakeStringFileSystemValid(ObjectKey);

                FileInfo fileInfo = new FileInfo(file);
                if (!fileInfo.Exists)
                {
                    MessageBox.Show($"Die Datei {fileInfo.FullName} exisitert nicht!", "Fehler", MessageBoxButtons.OK);
                    return;
                }

                byte[] data = File.ReadAllBytes(fileInfo.FullName);

                OdbcCommand cmd = Conn?.CreateCommand();
                if (cmd == null) return;

                string extension = name.Substring(name.LastIndexOf('.'), name.Length - name.LastIndexOf('.'));

                //string fileName = $"{tag}_{MakeStringFileSystemValid(objectKey)}_{Guid.NewGuid().ToString("D")}{extension}";

                cmd.CommandText = "exec dbo.spDocumentAdd ?,?,?,?,?";
                cmd.Parameters.Add("@tag", OdbcType.VarChar).Value = ObjectTag;
                cmd.Parameters.Add("@objectKey", OdbcType.VarChar).Value = ObjectKey;
                cmd.Parameters.Add("@name", OdbcType.VarChar).Value = objectName;
                cmd.Parameters.Add("@fileName", OdbcType.VarChar).Value = name;
                cmd.Parameters.Add("@data", OdbcType.VarBinary).Value = data;

                /*cmd.CommandText = $"insert into tblDocumentFiles(file_stream, is_directory,[name]{(parentHierachy==null?"":", path_locator")}) values(?, {(data==null?"1":"0")}, ?{(parentHierachy == null ? "" : $", {pathLocator}")});";

                if (data == null) cmd.Parameters.Add("@file_stream", OdbcType.VarBinary).Value = DBNull.Value;
                else cmd.Parameters.Add("@file_stream", OdbcType.VarBinary).Value = data;
                cmd.Parameters.Add("@name", OdbcType.VarChar).Value = name;*/

                cmd.ExecuteNonQuery();

                int docCount = GetDocumentCount(ObjectTag, ObjectKey);
                btnOpenDocuments.Text = $"Dokumente ({docCount})";
                DocumentCountChanged?.Invoke(docCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler");
            }
        }


        public void OpenDocuments()
        {
            try
            {
                btnOpenDocuments_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ActiveXCtrlHelper.HandleError("Fehler bei OpenDocuments!", ex);
            }
        }

        public string DocumentDirectory => GetDocumentDirectory(ObjectTag, ObjectKey, ObjectName);

        public void OpenPictures()
        {
            btnPicture_Click(this, EventArgs.Empty);
        }

        [ComVisible(false)]
        public delegate void CountChangedHandler(int count);

        public new event CountChangedHandler DocumentCountChanged = null;

        public new event CountChangedHandler PictureCountChanged = null;


        private void btnOpenDocuments_Click(object sender, EventArgs e)
        {
            //InsertFile("program",null,null);
            string path = GetDocumentDirectory(ObjectTag, ObjectKey, ObjectName);
            Process.Start(path);
        }

        public string ObjectTag { get; set; }
        public string ObjectKey { get; set; }
        public string ObjectName { get; set; }

        public void init()
        {
            try
            {
                int docCount = GetDocumentCount(ObjectTag, ObjectKey);
                btnOpenDocuments.Text = $"Dokumente ({docCount})";
                try
                {
                    DocumentCountChanged?.Invoke(docCount);
                }
                catch (Exception ex)
                {
                    ActiveXCtrlHelper.HandleError("Fehler bei Ereignis DocumentCountChanged", ex);                    
                }
                try{
                    UpdatePictureCount();
                }
                catch (Exception ex)
                {
                    ActiveXCtrlHelper.HandleError("Fehler bei Ereignis UpdatePictureCount", ex);                    
                }
                try
                {
                    InitPicture?.Invoke();
                }
                catch (Exception ex)
                {
                    ActiveXCtrlHelper.HandleError("Fehler bei Ereignis InitPicture",ex);                 
                }
            }
            catch (Exception ex)
            {
                ActiveXCtrlHelper.HandleError("Fehler bei Init!", ex);
                throw;
            }
        }

        private void UpdatePictureCount()
        {
            int picCount = GetPictureCount(ObjectTag, ObjectKey);
            btnPicture.Text = $"Bilder ({picCount})";
            PictureCountChanged?.Invoke(picCount);
        }

        private string MakeStringFileSystemValid(string str)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            str = r.Replace(str, "");
            if (str.Length > 100) str = str.Substring(0, 100);
            return str;
        }

        public void AddPicture(string tag, string objectKey, string name, byte[] data)
        {
            OdbcCommand cmd = Conn?.CreateCommand();
            if (cmd == null) return;

            string extension = name.Substring(name.LastIndexOf('.'), name.Length - name.LastIndexOf('.'));

            string fileName = $"{tag}_{MakeStringFileSystemValid(objectKey)}_{Guid.NewGuid().ToString("D")}{extension}";

            cmd.CommandText = "exec dbo.spPictureAdd ?,?,?,?";
            cmd.Parameters.Add("@tag", OdbcType.VarChar).Value = tag;
            cmd.Parameters.Add("@objectKey", OdbcType.VarChar).Value = objectKey;
            cmd.Parameters.Add("@name", OdbcType.VarChar).Value = fileName;
            cmd.Parameters.Add("@data", OdbcType.VarBinary).Value = data;

            /*cmd.CommandText = $"insert into tblDocumentFiles(file_stream, is_directory,[name]{(parentHierachy==null?"":", path_locator")}) values(?, {(data==null?"1":"0")}, ?{(parentHierachy == null ? "" : $", {pathLocator}")});";

            if (data == null) cmd.Parameters.Add("@file_stream", OdbcType.VarBinary).Value = DBNull.Value;
            else cmd.Parameters.Add("@file_stream", OdbcType.VarBinary).Value = data;
            cmd.Parameters.Add("@name", OdbcType.VarChar).Value = name;*/
            cmd.ExecuteNonQuery();
        }

        public string GetDocumentDirectory(string tag, string objectKey, string name = null)
        {
            try
            {
                if (name == null) name = objectKey;
                name = MakeStringFileSystemValid(name);
                using (OdbcCommand cmd = Conn?.CreateCommand())
                {
                    if (cmd == null) return "C:\\";
                    cmd.CommandText = "exec dbo.spDocumentDirectory ?,?,?";
                    cmd.Parameters.Add("@tag", OdbcType.VarChar).Value = tag;
                    cmd.Parameters.Add("@objectKey", OdbcType.VarChar).Value = objectKey;
                    cmd.Parameters.Add("@name", OdbcType.VarChar).Value = name;
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        string path = reader.GetString(0);
                        return path;
                    }
                }
            }
            catch (Exception ex)
            {
                ActiveXCtrlHelper.HandleError("Error in GetDocumentCount", ex);
                throw;
            }
        }

        private int GetDocumentCount(string tag, string objectKey)
        {
            try
            {
                using (OdbcCommand cmd = Conn?.CreateCommand())
                {
                    if (cmd == null) return 0;
                    cmd.CommandText = "exec dbo.spDocumentCount ?,?";
                    cmd.Parameters.Add("@tag", OdbcType.VarChar).Value = tag;
                    cmd.Parameters.Add("@objectKey", OdbcType.VarChar).Value = objectKey;
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                ActiveXCtrlHelper.HandleError("Error in GetDocumentCount", ex);
                throw;
            }
        }

        public void MovePictureTo(Picture srcPicture, Picture dstPicture)
        {
            using (OdbcCommand cmd = Conn?.CreateCommand())
            {
                if (cmd == null) return;
                cmd.CommandText = "exec dbo.spPictureMoveTo ?,?";
                cmd.Parameters.Add("@pictureSrc_pk", OdbcType.VarChar).Value = srcPicture.PicturePk;
                cmd.Parameters.Add("@pictureDest_pk", OdbcType.VarChar).Value = dstPicture.PicturePk;
                cmd.ExecuteNonQuery();
            }
        }

        private int GetPictureCount(string tag, string objectKey)
        {
            using (OdbcCommand cmd = Conn?.CreateCommand())
            {
                if (cmd == null) return 0;
                cmd.CommandText = "exec dbo.spPictureCount ?,?";
                cmd.Parameters.Add("@tag", OdbcType.VarChar).Value = tag;
                cmd.Parameters.Add("@objectKey", OdbcType.VarChar).Value = objectKey;
                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
        }

        public static string[] ALLOWED_PICTURE_EXTENSIONS = new[] {".JPG", ".GIF", ".PNG"};

        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                PictureForm f = new PictureForm();
                f.Init(this);
                f.PictureListControl.PicturesChanged += (o, args) =>
                {
                    UpdatePictureCount();
                    InitPicture?.Invoke();
                };

                f.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ActiveXCtrlHelper.HandleError("Fehler bei OpenPicture!", ex);
                throw;
            }
        }
    }
}