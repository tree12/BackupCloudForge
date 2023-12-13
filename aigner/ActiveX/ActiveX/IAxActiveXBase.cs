
using System.Data.Odbc;
using System.Runtime.InteropServices;

namespace Aigner
{    
    public interface IAxActiveXBase
    {
        bool Visible { get; set; } // Typical control property
        bool Enabled { get; set; } // Typical control property
        void SetSize(int width, int height);
        string Verbindungszeichenfolge { get; set; } // Typical control property
        OdbcConnection Conn { get; }
    }
}