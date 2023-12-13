using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATom.CommonBasics.Extension;

namespace ActiveX.FileControl
{
    public partial class PictureListControl : UserControl
    {

        public event EventHandler PicturesChanged; 

        public PictureListControl()
        {
            InitializeComponent();
        }

        private FileControl _fileControl;

        public void Init(FileControl fileControl)
        {
            _fileControl = fileControl;
            CreateGui();
        }

        private void CreateGui()
        {
            layoutPanel.Controls.Clear();
            List<Picture> pictures = LoadPictures();

            int nr = 1;
            foreach (Picture picture in pictures)
            {                
                PictureControl pictureControl = new PictureControl();
                pictureControl.Picture = picture;
                pictureControl.Number = nr++;
                pictureControl.DeletePicturEventHandler += (sender, pic) =>
                {
                    DeletePicture(pic);
                    CreateGui();
                    PicturesChanged?.Invoke(this, EventArgs.Empty);
                };
                pictureControl.MovePicturEventHandler += (sender, pic) =>
                {
                    _fileControl.MovePictureTo(pic, ((PictureControl) sender).Picture);
                    CreateGui();
                };
                layoutPanel.Controls.Add(pictureControl);                
            }

            PictureControl pictureControlAdd = new PictureControl();
            pictureControlAdd.AddPicturEventHandler += (sender, args) =>
            {
                OpenFileDialog df = new OpenFileDialog();
                if (df.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in df.FileNames)
                    {
                        FileInfo file = new FileInfo(fileName);
                        if (!file.Exists) continue;
                        if (!FileControl.ALLOWED_PICTURE_EXTENSIONS.Any(_ => file.Extension.EqualsIgnoreCase(_)))
                        {
                            MessageBox.Show(
                                $"Bilder müssen GIF, JPG oder PNG sein.\n{file.Extension} ist nicht erlaubt.");
                            continue;
                        }
                        byte[] data = File.ReadAllBytes(file.FullName);
                        _fileControl.AddPicture(_fileControl.ObjectTag, _fileControl.ObjectKey, file.Name, data);
                    }
                }
                CreateGui();
                PicturesChanged?.Invoke(this,EventArgs.Empty);
                
            };
            layoutPanel.Controls.Add(pictureControlAdd);
        }

        private List<Picture> LoadPictures()
        {
            OdbcCommand command = _fileControl.Conn?.CreateCommand();
                       
            command.CommandText =
                $"select p.picture_PK, FileTableRootPath()+file_stream.GetFileNamespacePath() as picturePath,p.sort from TblPicture p inner join tblPictureFiles f on p.Picture_GUID=f.stream_id where tag_FK=? and object_FK=? order by sort";
            command.Parameters.Add("@tag_FK", OdbcType.VarChar).Value = _fileControl.ObjectTag;
            command.Parameters.Add("@object_FK", OdbcType.VarChar).Value = _fileControl.ObjectKey;            
            
            List<Picture> pictures = new List<Picture>();
                
            using (OdbcDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Picture item = ReadItem(reader, true);
                    pictures.Add(item);
                }
                reader.Close();
            }
            return pictures;
        }

        private void DeletePicture(Picture pic)
        {
            OdbcCommand command = _fileControl.Conn?.CreateCommand();
            command.CommandText =
                $"exec spPictureDelete ?";
            command.Parameters.Add("@picture_PK", OdbcType.Int).Value = pic.PicturePk;
            command.ExecuteNonQuery();
        }

        private Picture ReadItem(OdbcDataReader reader, bool readHitInfo)
        {
            Picture picture = new Picture(reader.GetInt32(0));
            picture.File = new FileInfo(reader.GetString(1));
            picture.Sort = reader.GetInt32(2);                        
            return picture;
        }

     
    }
}
