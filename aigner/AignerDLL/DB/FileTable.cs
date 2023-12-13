using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AignerDLL.DataObjects;

namespace AignerDLL.DB
{
    public class FileTable:DBBaseObject<FileData> {
        public int InsertFile(string object_FK, string tag_FK, FileInfo fi) {
            MemoryStream memStream = new MemoryStream();
            using (FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read)) {
                fs.CopyTo(memStream);
            }
            return InsertFile(object_FK,tag_FK,fi.Name,fi.Extension,memStream.GetBuffer());
        }

        public int InsertFile(string object_FK, string tag_FK, string name, string extension, byte[] data)
        {

            Hashtable ht = new Hashtable();

            ht["Object_FK"] = object_FK;
            ht["Tag_FK"] = tag_FK;
            ht["CreateUser"] = Environment.UserName;
            ht["CreateDate"] = DateTime.Now;
            ht["ModifyUser"] = Environment.UserName;
            ht["ModifyDate"] = DateTime.Now;
            ht["FileName"] = name;
            ht["Extension"] = extension;
            ht["Data"] = data;

            return Insert("TblFiles", ht, "File_PK");
        }

        public int UpdateFile(int file_PK, FileInfo fi)
        {
            MemoryStream memStream = new MemoryStream();
            using (FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read))
            {
                fs.CopyTo(memStream);
            }

            Hashtable ht = new Hashtable();
            
            ht["ModifyUser"] = Environment.UserName;
            ht["ModifyDate"] = DateTime.Now;
            ht["LockUser"] = DBNull.Value;
            ht["LockDate"] = DBNull.Value;
            ht["Data"] = memStream.GetBuffer();

            return Update("TblFiles", ht, "File_PK="+file_PK);
        }

        public int LockFile(int file_PK)
        {
            Hashtable ht = new Hashtable();

            ht["LockUser"] = Environment.UserName;
            ht["LockDate"] = DateTime.Now;            
            return Update("TblFiles", ht, "File_PK=" + file_PK);
        }

        public int UnLockFile(int file_PK)
        {
            Hashtable ht = new Hashtable();

            ht["LockUser"] = DBNull.Value;
            ht["LockDate"] = DBNull.Value;
            return Update("TblFiles", ht, "File_PK=" + file_PK);
        }


        public FileInfo GetFile(int file_PK, DirectoryInfo directoryInfo, FileAccess access) {
            DataTable dt = Select("TblFiles", "File_PK=" + file_PK);
            if (dt.Rows.Count != 1) return null;
            DataRow r = dt.Rows[0];
            string lockUser = r["LockUser"] as string;
            DateTime? lockDate = r["LockDate"] as DateTime?;
            byte[] data = r["Data"] as byte[];
            string fileName = r["FileName"] as string;
            string extension = r["Extension"] as string;

            FileInfo fi = new FileInfo(Path.Combine(directoryInfo.FullName,file_PK+"_"+fileName));
            if (access == FileAccess.Read &&
                (lockUser == null || !lockUser.Equals(Environment.UserName) ||
                 (fi.Exists && fi.LastWriteTime < lockDate)) ||
                (access == FileAccess.Write &&
                 (lockUser == null ||
                  (lockUser.Equals(Environment.UserName) && (fi.Exists && fi.LastAccessTime < lockDate))))) {
                //Überschreiben bzw. neu erstellen
                using (FileStream fs = new FileStream(fi.FullName, FileMode.Create)) {
                    fs.Write(data, 0, data.Length);
                }
            }
            else {
                //Lokale Datei ist neuer oder Jemand hat die Datei gesperrt und wir wollen bearbeiten
                if (access == FileAccess.Write && lockDate != null)
                    throw new Exception(
                        $"Der Benutzer '{lockUser}' hat die Datei {fileName} am {string.Format("{0:f}", lockDate)} zur Bearbeitung gesperrt.");
            }
            if (!fi.Exists)
                    throw new Exception(
                        $"Sollte nicht vorkommmen. Datei: {fileName}, Mode: {access}, LockDate:{lockDate}, lockuser{lockUser}");

            if (access == FileAccess.Write && lockUser == null) {
                LockFile(file_PK);
            }

            return fi;
        }
                    
    }
}
