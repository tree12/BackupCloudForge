using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ATom.CommonBasics.Extension;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Npgsql;

namespace BedarfsCheck
{
    public class Global
    {
        private static string _conn_string;

        static Global()
        {            
#if DB_MYSQL
                MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
                conn_string.Server = "localhost";
                conn_string.UserID = "dbuser";
                conn_string.Password = "dbpass";
                conn_string.Database = "bedarfsdb";
                conn_string.SslMode =MySqlSslMode.None;
                _conn_string = conn_string.ToString();
#elif DB_PGSQL
            NpgsqlConnectionStringBuilder conn_string = new NpgsqlConnectionStringBuilder();
            conn_string.Host = "127.0.0.1";
            conn_string.Port = 5432;
            conn_string.Username = "dbuser";
            conn_string.Password = "dbpass";
            conn_string.Database = "bedarfsdb";
            _conn_string = conn_string.ToString();
#else
            You HAVE to set DB_PGSQL or DB_MYSQL
#endif
        }

        static public void SetConfig()
        {
#if DB_MYSQL
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = Environment.GetEnvironmentVariable("OPENSHIFT_MYSQL_DB_HOST");
            if (conn_string.Server.IsNullOrEmpty()) conn_string.Server=Environment.GetEnvironmentVariable("MYSQL3_SERVICE_HOST");
            uint port = 0;
            string str_port = Environment.GetEnvironmentVariable("OPENSHIFT_POSTGRESQL_DB_PORT") ?? "";
            if (str_port.IsNullOrEmpty()) str_port=Environment.GetEnvironmentVariable("MYSQL3_SERVICE_PORT");
            if (str_port.NotNullOrEmpty())
            {
                if (uint.TryParse(str_port, out port))
                {
                    conn_string.Port = port;
                }
            }
            conn_string.UserID = Environment.GetEnvironmentVariable("OPENSHIFT_MYSQL_DB_USERNAME");
            if (conn_string.UserID.IsNullOrEmpty()) conn_string.UserID = "dbuser3";
            conn_string.Password = Environment.GetEnvironmentVariable("OPENSHIFT_MYSQL_DB_PASSWORD");
            if (conn_string.Password.IsNullOrEmpty()) conn_string.Password = "dbpass3";
            conn_string.Database = "bedarfsdb";
            conn_string.SslMode = MySqlSslMode.None;
            _conn_string = conn_string.ToString();
            Console.WriteLine("Mysql: " + conn_string);
#elif DB_PGSQL
            NpgsqlConnectionStringBuilder conn_string = new NpgsqlConnectionStringBuilder();
            conn_string.Host = Environment.GetEnvironmentVariable("OPENSHIFT_POSTGRESQL_DB_HOST");
            int port = 0;
            string str_port = Environment.GetEnvironmentVariable("OPENSHIFT_POSTGRESQL_DB_PORT") ?? "";
            if (str_port.NotNullOrEmpty())
            {
                if (int.TryParse(str_port, out port))
                {
                    conn_string.Port = port;
                }
            }
            conn_string.Username = Environment.GetEnvironmentVariable("OPENSHIFT_POSTGRESQL_DB_USERNAME");
            conn_string.Password = Environment.GetEnvironmentVariable("OPENSHIFT_POSTGRESQL_DB_PASSWORD");
            conn_string.Database = "bedarfsdb";
            Console.WriteLine("PostGreSQL: " + conn_string);
            _conn_string = conn_string.ToString();
#else
            You HAVE to set DB_PGSQL or DB_MYSQL
#endif
        }

        public static DbConnection Connection()
        {
            DbConnection con;
#if DB_MYSQL
            con = new MySqlConnection(_conn_string);
#elif DB_PGSQL
            con = new NpgsqlConnection(_conn_string);
#else
#endif
            con.Open();
            return con;
        }
        
    }
}
