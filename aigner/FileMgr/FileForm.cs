using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AignerDLL;
using AignerDLL.DataObjects;
using AignerDLL.DB;
using AignerDLL.Service;
using FileMgr.Properties;
using Microsoft.WindowsAPICodePack.Shell;
using Outlook=Microsoft.Office.Interop.Outlook;

namespace FileMgr
{
    public partial class FileForm : Form {

        private const string FILE_NAME = "FILE_NAME";
        private const string EXTENSION = "EXTENSION";
        private const string CREATE_USER = "CREATE_USER";
        private const string CREATE_DATE = "CREATE_DATE";
        private const string MODIFY_USER = "MODIFY_USER";
        private const string MODIFY_DATE = "MODIFY_DATE";
        private const string LOCK_USER = "LOCK_USER";
        private const string LOCK_DATE = "LOCK_DATE";
        private const string COMMENT = "COMMENT";
        private const string SIZE = "SIZE";        

        private string _object_FK;
        private string _tag_FK;

        private List<FileData> _listFiles;
        private ImageList _imageListSmall=new ImageList();
        private ImageList _imageListBig = new ImageList();

        private Dictionary<string, int> _imageDict=new Dictionary<string, int>();

        private ContextMenuStrip _contextMenu;
        private ToolStripItem _menuItem_Properties;
        private ToolStripItem _menuItem_OpenWith;
        private ToolStripItem _menuItem_Unlock;

        public FileForm()
        {
            InitializeComponent();
            _lstViewFiles.LabelEdit = true;
            _lstViewFiles.View = View.Details;
            _imageListBig.ImageSize=new Size(48,48);
            _lstViewFiles.LargeImageList = _imageListBig;            
            _lstViewFiles.SmallImageList = _imageListSmall;
            _lstViewFiles.LargeImageList.TransparentColor = _lstViewFiles.BackColor;
            _lstViewFiles.SmallImageList.TransparentColor = _lstViewFiles.BackColor;

            _contextMenu=new ContextMenuStrip();
            _menuItem_OpenWith=new ToolStripMenuItem("Öffnen mit...");            
            _contextMenu.Items.Add(_menuItem_OpenWith);
            _menuItem_Unlock = new ToolStripMenuItem("Entsperren");
            _contextMenu.Items.Add(_menuItem_Unlock);
            _contextMenu.Items.Add(new ToolStripSeparator());
            _menuItem_Properties=new ToolStripMenuItem("Eigenschaften");
            _menuItem_Properties.Click += _menuItem_Properties_Click;
            _contextMenu.Items.Add(_menuItem_Properties);
            _lstViewFiles.ContextMenuStrip = _contextMenu;

        }

        private void _menuItem_Properties_Click(object sender, EventArgs e)
        {
            ListViewItem item = (ListViewItem)_contextMenu.Tag;
            if (item == null) return;
            FileData file = item.Tag as FileData;
            if (file == null) return;                
            FilePropertiesForm form = new FilePropertiesForm(file);
            if (DialogResult.OK!=form.ShowDialog(this)) return;
            file.Comment = form.Comment;
        }

        public FileForm(string objectFk, string tagFk):this() {
            _object_FK = objectFk;
            _tag_FK = tagFk;
            _lstViewFiles.StateImageList=new ImageList();
            _lstViewFiles.StateImageList.Images.Add(Resources.lock_yellow);

            Outlook.Application outlook = new Outlook.Application();           

        }

        private void FileForm_Load(object sender, EventArgs e)
        {                      
            _lstViewFiles.Columns.Add(FILE_NAME, "Dateiname",250);
            _lstViewFiles.Columns.Add(EXTENSION, ".EXT",50);
            _lstViewFiles.Columns.Add(SIZE, "Größe", 80);
            _lstViewFiles.Columns.Add(CREATE_DATE, "erstellt am",100);
            _lstViewFiles.Columns.Add(CREATE_USER, "erstellt von");
            _lstViewFiles.Columns.Add(MODIFY_DATE, "geändert am", 100);
            _lstViewFiles.Columns.Add(MODIFY_USER, "geändert von");
            _lstViewFiles.Columns.Add(LOCK_DATE, "gesperrt am", 100);
            _lstViewFiles.Columns.Add(LOCK_USER, "gesperrt von");
            _lstViewFiles.Columns.Add(COMMENT, "Kommentar",200);

            RefreshData();            
        }

        private void RefreshData() {
            FileTable fileTable = new FileTable();
            _lstViewFiles.Items.Clear();
            _listFiles = fileTable.SelectObjectsQuery($"SELECT * FROM ViewFiles where Object_FK='{_object_FK}' AND Tag_FK='{_tag_FK}'");
            foreach (FileData file in _listFiles)
            {
                _lstViewFiles.Items.Add(CreateListViewItem(file));
            }
        }

        private void AddFile(FileData file) {
            _listFiles.Add(file);
            _lstViewFiles.Items.Add(CreateListViewItem(file));
        }

        private ListViewItem CreateListViewItem(FileData fileData) {

            ListViewItem item = new ListViewItem() {
                Name = FILE_NAME,
                Text = fileData.FileName,
                Tag = fileData,                
            };

            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Name = EXTENSION,
                Text = fileData.Extension
            });

            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Name = SIZE,
                Text = ""+fileData.FileSize
            });

            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Name = CREATE_DATE,
                Text = GetDateString(fileData.CreateDate)
            });

            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Name = CREATE_USER,
                Text = fileData.CreateUser??""
            });

            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Name = MODIFY_DATE,
                Text = GetDateString(fileData.ModifyDate)
            });

            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Name = CREATE_USER,
                Text = fileData.ModifyUser??""
            });

            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Name = LOCK_DATE,
                Text = GetDateString(fileData.LockDate)
            });

            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Name = LOCK_USER,
                Text = fileData.LockUser??""
            });

            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Name = COMMENT,
                Text = fileData.Comment
            });

            if (fileData.LockDate != null) {
                item.StateImageIndex = 0;
            } else {
                item.StateImageIndex = -1;
            }

           // Icon.ExtractAssociatedIcon()
            if (!_imageDict.ContainsKey(fileData.Extension)) {
                //ShellFile file = ShellFile.FromFilePath("txt");
                FileInfo fi = new FileInfo(Path.Combine(Global.DataDir.FullName, "icon." + fileData.Extension));
                if (!fi.Exists) {
                    fi.Create();
                }

                ShellFile sf = ShellFile.FromFilePath(fi.FullName);   
                sf.Thumbnail.FormatOption=ShellThumbnailFormatOption.IconOnly;             
                _imageListSmall.Images.Add(sf.Thumbnail.Icon);                
                Icon icon = sf.Thumbnail.LargeIcon;

                _imageListBig.Images.Add(icon);
                _imageDict[fileData.Extension] = _imageListSmall.Images.Count - 1;
            }
            item.ImageIndex = _imageDict[fileData.Extension];
            return item;
        }

        private string GetDateString(DateTime? dateTime) {
            return dateTime == null ? "" : dateTime.ToString();
        }

        private void btnViewIcon_Click(object sender, EventArgs e)
        {
            _lstViewFiles.View=View.LargeIcon;
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            _lstViewFiles.View=View.Details;
        }

        private void lstViewFiles_DragDrop(object sender, DragEventArgs e) {     
            if (sender==_lstViewFiles && _possibleDragDrop!=null)        return;
            string[] files;
            string[] formats = e.Data.GetFormats(false);
            if (e.Data.GetDataPresent("FileGroupDescriptor")) {
                MemoryStream data = (MemoryStream) e.Data.GetData("FileGroupDescriptorW");
                string str = GetString(data);
                if (str.Contains((char) 0x2)) {
                    MessageBox.Show(this, "Kann nur ein Attachment verarbeiten!", "Zu viele Attachments",
                        MessageBoxButtons.OK);
                    return;
                }
                if (str.Length > 1)
                    str = str.Remove(0, 1); //erstes Zeichen ist ein Index...
                object o = e.Data.GetData("FileContents");
                data = (MemoryStream) o;

                string tempFileName = Path.Combine(Path.GetTempPath(), str);

                using (FileStream fs = new FileStream(tempFileName, FileMode.Create)) {
                    data.CopyTo(fs);
                }
                data.Close();
                data.Dispose();
                files=new string[] {tempFileName};
            } else {
                files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            }

            FileTable fileTable = new FileTable();

            foreach (string file in files) {
                FileInfo fi = new FileInfo(file);
                if (!fi.Exists) continue;
                FileData existingFile =
                    _listFiles.FirstOrDefault(_ => _.FileName.Equals(fi.Name, StringComparison.OrdinalIgnoreCase));
                FileData fileData = new FileData() {
                    FileName = GetValidFileName(fi),
                    Extension = fi.Extension,
                    CreateDate = DateTime.Now,
                    CreateUser = System.Environment.UserName,
                    Object_FK = _object_FK,
                    Tag_FK = _tag_FK,       
                    FileSize = fi.Length
                };

                using (MemoryStream memStream = new MemoryStream())
                using (FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read))
                {
                    fs.CopyTo(memStream);
                    memStream.Seek(0,SeekOrigin.Begin);
                    fileData.MD5Hash = FileService.GetMD5Hash(memStream);
                    fileData.Data = memStream.GetBuffer();
                }

                fileTable.Insert(fileData);
                AddFile(fileData);
            }
        }

        private static string GetString(MemoryStream data) {
            byte[] b = new byte[data.Length];
            data.Read(b, 0, (int) data.Length);
            string str = Encoding.UTF8.GetString(b);
            return str.Replace("\0", "");
        }

        private string GetValidFileName(FileInfo fi) {
            string filename = fi.Name;
            FileData existingFile =
                  _listFiles.FirstOrDefault(_ => _.FileName.Equals(filename, StringComparison.OrdinalIgnoreCase));
            for (int i = 1; existingFile!=null; i++) {
                filename = fi.Name;
                if (filename.EndsWith(fi.Extension))
                    filename = filename.Remove(filename.Length - fi.Extension.Length - 1, fi.Extension.Length);
                filename = $"{filename} ({i}){fi.Extension}";
                existingFile =
                   _listFiles.FirstOrDefault(_ => _.FileName.Equals(filename, StringComparison.OrdinalIgnoreCase));
            }
            return filename;
        }

        private void lstViewFiles_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
            return;
            string[] formats = e.Data.GetFormats(false);
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            else if (e.Data.GetDataPresent("FileContents")) {
                object data= e.Data.GetData("FileContents");
            }       
        }

        private void lstViewFiles_DoubleClick(object sender, EventArgs e) {
            Point pos = _lstViewFiles.PointToClient(Control.MousePosition);
            ListViewItem item= _lstViewFiles.GetItemAt(pos.X, pos.Y);
            if (item == null) return;
            FileData fileData=item.Tag as FileData;
            FileTable fileTable = new FileTable();
            if (!fileData.HasActualLocalFile) {
                fileData = fileTable.SelectObjects(fileData);
                fileData.WriteLocalFile();
            }
            bool edit = !fileData.IsLocked;
            fileData.LocalFile.IsReadOnly = fileData.IsLocked;
            if (edit) {
                fileTable.LockFile(fileData.File_PK);
                RefreshData();
            }
         
            Process proc = Program.StartOpenProcess(fileData.LocalFile,edit, true,ShowOpenWithForm);
            if (edit && proc!=null) {
                proc.WaitForExit();
                if (!fileData.HasActualLocalFile) {
                    fileData.ReadLocalFile();
                    fileTable=new FileTable();
                    fileData.ModifyDate=DateTime.Now;
                    fileData.ModifyUser = Environment.UserName;
                    fileTable.Update(fileData);
                    RefreshData();
                }
            }
        }

        private string ShowOpenWithForm(List<Tuple<string, string, Icon>> commandList)
        {            
            OpenWithForm frm = new OpenWithForm(commandList,false);
            frm.ShowDialog(this);
            Tuple<string, string, Icon> ret = frm.SelectedValue;
            if (ret == null) return null;
            return ret.Item2;
        }

        private void FileForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) {
                RefreshData();
            }
        }

        private MouseEventArgs _possibleDragDrop;
        


        private void _lstViewFiles_MouseMove(object sender, MouseEventArgs e)
        {
            if (_possibleDragDrop != null)
            {
                if (Math.Abs(e.X - _possibleDragDrop.X) > 10 || Math.Abs(e.Y - _possibleDragDrop.Y) > 10)
                {
                    _possibleDragDrop = null;
                    ListViewHitTestInfo hitTest = _lstViewFiles.HitTest(e.Location);
                    List<FileData> dragDropFiles = new List<FileData>();
                    if (hitTest.Item == null) return;
                    if (hitTest.Item.Selected)
                    {
                        foreach (ListViewItem item in _lstViewFiles.SelectedItems)
                        {
                            dragDropFiles.Add((FileData)item.Tag);
                        }
                    }
                    else
                    {
                        dragDropFiles.Add((FileData)hitTest.Item.Tag);
                    }

                    FileTable ft = new FileTable();
                    foreach (FileData data in dragDropFiles)
                    {
                        if (!data.HasActualLocalFile)
                        {
                            ft.GetFile(data.File_PK, Global.DataDir, FileAccess.Read);
                        }
                    }
                    string[] dragDropData = dragDropFiles.Select(_ => _.LocalFile.FullName).ToArray();                    
                    _lstViewFiles.DoDragDrop(new DataObject(DataFormats.FileDrop, dragDropData), DragDropEffects.Copy);
                }
            }
        }

        private void _lstViewFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _possibleDragDrop = e;
            } else if (e.Button == MouseButtons.Right) {
                ListViewHitTestInfo hitTeset = _lstViewFiles.HitTest(e.Location);
                if (hitTeset.Item == null) return;
                _lstViewFiles.ContextMenuStrip.Tag = hitTeset.Item;
                _lstViewFiles.ContextMenuStrip.Show(e.Location);
            }
        }

        private void _lstViewFiles_MouseUp(object sender, MouseEventArgs e)
        {
            _possibleDragDrop = null;
        }
    }
}

