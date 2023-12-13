using System.IO;

namespace ActiveX.FileControl
{
    
        public class Picture
        {
            private int picture_pk;
            private FileInfo _file;
            private int _sort;

            public Picture(int picturePk)
            {
                picture_pk = picturePk;
            }

            public int PicturePk
            {
                get => picture_pk;
                set => picture_pk = value;
            }

            public FileInfo File
            {
                get => _file;
                set => _file = value;
            }

            public int Sort
            {
                get => _sort;
                set => _sort = value;
            }
        }    
}