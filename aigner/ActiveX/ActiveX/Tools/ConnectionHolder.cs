using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActiveX.Tools
{
    static class ConnectionHolder
    {
        private static OdbcConnection _conn;
        
        public static OdbcConnection GetConnection(string verbindungszeichenfolge,bool waitOnReconnect=false)
        {
            
                if (_conn == null)
                {
                    try
                    {
                        _conn = new OdbcConnection(verbindungszeichenfolge.Replace("ODBC;", ""));
                        _conn.Open();
                    }
                    catch (Exception ex)
                    {
                        _conn = null;
                    }
                }
                if (_conn != null && _conn.State != ConnectionState.Open)
                {
                    _conn = null;
                    if (waitOnReconnect) Thread.Sleep(5000);
                    return GetConnection(verbindungszeichenfolge,true);
                }
                return _conn;
            }        
    }
}
