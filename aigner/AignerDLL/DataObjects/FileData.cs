using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AignerDLL.Service;

namespace AignerDLL.DataObjects
{
    [Table("TblFiles")]
    public class FileData:BaseDataObject
    {
        [AutoID]
        [Field]
        [PrimaryKey]
        public int File_PK { get; set; }
        [Field]
        public string Object_FK { get; set; }
        [Field]
        public string Tag_FK { get; set; }
        [Field]
        public DateTime? CreateDate { get; set; }
        [Field]
        public string CreateUser { get; set; }

        [Field]
        public DateTime? ModifyDate { get; set; }
        [Field]
        public string ModifyUser { get; set; }

        [Field]
        public DateTime? LockDate { get; set; }
        [Field]
        public string LockUser { get; set; }
        [Field]
        public string FileName { get; set; }
        [Field]
        public string Extension { get; set; }
        [Field]
        public string Comment { get; set; }
        [Field]
        public long FileSize { get; set; }
        [Field]
        public long MD5Hash { get; set; }
        [Field]
        public byte[] Data { get; set; }

        public FileInfo LocalFile {
            get { return new FileInfo(Path.Combine(Global.DataDir.FullName, File_PK + "_" + FileName)); }
        }

        public bool HasActualLocalFile {
            get {
                FileInfo fi = LocalFile;
                if (!fi.Exists) return false;
                long localHash = FileService.GetMD5Hash(fi);
                return (localHash == MD5Hash);
            }
        }

        public FileInfo WriteLocalFile() {
            if (Data==null) throw new Exception("Kann nicht schreiben, keine Daten...");
            FileInfo fi = LocalFile;            
                //Überschreiben bzw. neu erstellen
                using (FileStream fs = new FileStream(fi.FullName, FileMode.Create,FileAccess.ReadWrite))
                {
                    fs.Write(Data, 0, Data.Length);
                }
            return fi;        
        }

        public void ReadLocalFile() {
            using (MemoryStream memStream = new MemoryStream())
            using (FileStream fs = new FileStream(LocalFile.FullName, FileMode.Open, FileAccess.Read))
            {
                fs.CopyTo(memStream);
                Data = memStream.GetBuffer();
            }
        }

        public bool IsLocked => LockDate != null;
    }
}
