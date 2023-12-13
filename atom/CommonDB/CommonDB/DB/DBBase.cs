using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Npgsql;
using NpgsqlTypes;


namespace ATom.CommonDB.DB
{
    public class DBBase:IDisposable {
        private DbConnection _conn;

        public delegate DbConnection CreateConnection();

        public DBBase(CreateConnection createConnectionDelegate) {
            _conn = createConnectionDelegate();
        }

        private DbProviderFactory _dbProviderFactory;

        protected DbProviderFactory DBProviderFactory
        {
            get
            {
                if (_dbProviderFactory == null)
                {
                    _dbProviderFactory=DbProviderFactories.GetFactory(_conn);
                }
                return _dbProviderFactory;
            }
        }
#if NETCOREAPP2_0
        protected static class DbProviderFactories
        {
            private static DbProviderFactory _factory;
            static public DbProviderFactory GetFactory(DbConnection conn)
            {
                return new DbProviderFactory(conn);                
            }
        }

        protected class DbProviderFactory
        {
            private DbConnection _conn;

            public DbProviderFactory(DbConnection conn)
            {
                _conn = conn;
            }

            public DbCommand CreateCommand()
            {
                return _conn.CreateCommand();
            }

            public DbDataAdapter CreateDataAdapter()
            {
#if DB_PGSQL                
                return new NpgsqlDataAdapter();
#elif DB_MYSQL
                throw new NotImplementedException("not available for mysql");
#else
                throw new NotImplementedException();
#endif
            }

            public DbParameter CreateParameter()
            {
#if DB_PGSQL
                return new NpgsqlParameter();
#elif DB_MYSQL

                return new MySqlParameter();
#else
                throw new NotImplementedException();
#endif
            }
            
        }
#endif

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

        public int ExecuteNonQuery(string stmt)
        {
            var c = _conn.CreateCommand();
            c.CommandText = stmt;
            return c.ExecuteNonQuery();
        }

        public DataTable Select(string tableName, string where)
        {

            string sql = $"SELECT * FROM {tableName}";
            if (where  !=null) sql+=$" WHERE {where}";
            return Select(sql);
        }

        public DataTable Select(string sql)
        {
#if DB_MYSQL
            using (var command = _conn.CreateCommand())
            {
                command.CommandText = sql;
                
                var reader = command.ExecuteReader();

                DataTable dt=new DataTable();

                for (int i=0;i<reader.FieldCount;i++)
                {
                    dt.Columns.Add(new DataColumn(reader.GetName(i)));
                }

                object[] data = null;

                while (reader.Read())
                {
                    data = new object[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        data[i] = reader.GetValue(i);
                    }
                    dt.Rows.Add(data);                    
                }
                                
                return dt;
            }
#else


            using (DbDataAdapter dataAdapter = DBProviderFactory.CreateDataAdapter())
            {
                DbCommand cmd=DBProviderFactory.CreateCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                dataAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
#endif
        }

        private IDbCommand PrepareStmt(Hashtable ht, string sql) {
            IDbCommand command = _conn.CreateCommand();
            command.CommandText = sql;
            
            foreach (string column in ht.Keys)
            {
                object value = ht[column];
                if (command is NpgsqlCommand)
                {
                    NpgsqlCommand npgCommand = (NpgsqlCommand) command;

                    NpgsqlDbType npgType;

                    if (value == System.DBNull.Value || value==null) npgType = NpgsqlDbType.Text;                    
                    else if (value is string) npgType = NpgsqlDbType.Text;
                    else if (value is int) npgType = NpgsqlDbType.Integer;
                    else npgType = NpgsqlDbType.Text;

                    npgCommand.Parameters.AddWithValue(column, npgType, value);

                }
                else
                {
                    DbParameter param = DBProviderFactory.CreateParameter();
                    param.ParameterName = column;
                    param.Value = value;
                    param.DbType = GetDBType(ht[column]);
                    if (param.DbType == DbType.Int32) param.Size = 4;
                    if (param.DbType == DbType.String) param.Size = 255;
                    command.Parameters.Add(param);
                }
                
            }
            command.Prepare(); //PostgreSQL macht prepare nach setzen der Paramater.
            return command;
        }

        private DbType GetDBType(object value)
        {
            if (value == System.DBNull.Value) return DbType.Object;
            if (value == null) return DbType.Object;
            if (value is string) return DbType.String;
            if (value is int) return DbType.Int32;
            if (value is long) return DbType.Int64;
            throw new NotImplementedException("Missing DB-Type implementation!");
        }

        private static string GetColumnList(Hashtable ht) {
            string sql="";            
            foreach (string column in ht.Keys) {
                if (!sql.Equals("")) sql += ", ";
                sql += $"{column}";
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
                sql += $"{column}=@{column}";
            }
            return sql;
        }

        public void Dispose() {
            if (_conn != null) return;
            _conn.Close();
        }
    }
}
