using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AignerDLL.DataObjects;

namespace AignerDLL.DB
{
    public class DBBase:IDisposable {
        private SqlConnection _conn;

        public DBBase() {
            _conn = Global.Conn;
        }

        public int Insert(string tableName, Hashtable ht, string idColumn = null) {
            
            string sql= $"INSERT INTO {tableName} (";

            int i;
            sql += GetColumnList(ht);
            sql += ") ";
            if (idColumn != null) sql += " OUTPUT INSERTED." + idColumn+" ";
            sql += "VALUES (";
            sql += GetValueList(ht);
            sql += ")";

            using (var command = PrepareStmt(ht, sql)) {
                var ret = command.ExecuteScalar();
                if (ret is int) return (int) ret;
                return 0;
            }
        }     

        public int Update(string tableName, Hashtable ht, string where)
        {

            string sql = $"update {tableName} SET ";

            int i;
            sql += GetSetList(ht);            
            sql += " WHERE "+where;

            using (var command = PrepareStmt(ht, sql)) {
                var ret = command.ExecuteScalar();
                if (ret is int) return (int) ret;
                return 0;
            }
        }

        public DataTable Select(string tableName, string where)
        {

            string sql = $"SELECT * FROM {tableName} WHERE {where}";
            return Select(sql);
        }

        public DataTable Select(string sql)
        {            
            using (var command = _conn.CreateCommand())
            {
                command.CommandText = sql;
                var reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        private static SqlCommand PrepareStmt(Hashtable ht, string sql) {
            SqlCommand command = Global.Conn.CreateCommand();
            command.CommandText = sql;

            command.Prepare();
            foreach (string column in ht.Keys) {
                command.Parameters.Add(new SqlParameter(column, ht[column]));
            }
            return command;
        }

        private static string GetColumnList(Hashtable ht) {
            string sql="";            
            foreach (string column in ht.Keys) {
                if (!sql.Equals("")) sql += ", ";
                sql += $"[{column}]";
            }
            return sql;
        }

        private static string GetValueList(Hashtable ht)
        {
            string sql = "";
            foreach (string column in ht.Keys)
            {
                if (!sql.Equals("")) sql += ", ";
                sql += $"@{column}";
            }
            return sql;
        }

        private static string GetSetList(Hashtable ht)
        {
            string sql = "";
            foreach (string column in ht.Keys)
            {
                if (!sql.Equals("")) sql += ", ";
                sql += $"[{column}]=@{column}";
            }
            return sql;
        }

        public void Dispose() {
            if (_conn != null) return;
            _conn.Close();
        }
    }
}
