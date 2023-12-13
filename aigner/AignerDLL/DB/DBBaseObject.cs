using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AignerDLL.DataObjects;
using AignerDLL.Extensions;

namespace AignerDLL.DB
{
    public class DBBaseObject<T>:DBBase where T:BaseDataObject {
        private static TableAttribute _tableAttribute;
        private static List<FieldInternal> _fieldList;
        private static FieldInternal _autoIdField;

        static DBBaseObject() {            
            _tableAttribute = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            if (_tableAttribute==null) throw new Exception($"{typeof(T).FullName} is missing the TableAttribute");
            _fieldList=new List<FieldInternal>();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties()) {
                FieldAttribute fieldAttribute =
                    (FieldAttribute)
                        propertyInfo.GetCustomAttributes(typeof (FieldAttribute), true)
                            .Cast<FieldAttribute>()
                            .SingleOrDefault();                
                AutoIDAttribute autoIdAttribute = propertyInfo.GetCustomAttributes(typeof(AutoIDAttribute), true).SingleOrDefault() as AutoIDAttribute;
                PrimaryKeyAttribute primaryKeyAttribute = propertyInfo.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).SingleOrDefault() as PrimaryKeyAttribute;
                if (fieldAttribute == null) {
                    if (autoIdAttribute != null) {
                        throw new Exception(
                            $"{typeof (T).FullName} has AutoIDAttribute for property {propertyInfo.Name} but missing the FieldAttribute");
                    }
                    if (primaryKeyAttribute != null)
                    {
                        throw new Exception(
                            $"{typeof(T).FullName} has PrimaryKeyAttribute for property {propertyInfo.Name} but missing the FieldAttribute");
                    }
                    continue;
                }
                FieldInternal field = new FieldInternal(propertyInfo, fieldAttribute,primaryKeyAttribute, autoIdAttribute);
                if (autoIdAttribute != null) {
                    if (_autoIdField!=null) throw new Exception($"{typeof(T).FullName} has more than one AutoIdAttribute. At least {_autoIdField.PropertyInfo.Name} and {propertyInfo.Name}");
                    _autoIdField = field;
                }                
                _fieldList.Add(field);
            }
            if (_fieldList == null || !_fieldList.Any()) throw new Exception($"{typeof(T).FullName} is missing properties with the FieldAttribute");
        } 
        

        public T Insert(T obj) {
            int autoId=Insert(_tableAttribute.TableName, CreateHashtable(obj), _autoIdField?.DBName);
            if (_autoIdField != null) {
                _autoIdField.PropertyInfo.GetSetMethod().Invoke(obj, new object[] {autoId});            
            }
            return obj;
        }

        public int Update(T obj, string where = null) {
            return Update(_tableAttribute.TableName, CreateHashtable(obj), where??GetWhereFor(obj));            
        }

        public T SelectObjects(T obj)
        {
            DataTable dt = Select(_tableAttribute.TableName, GetWhereFor(obj));
            List<T> result =FillFromDataTable(dt);
            if (result == null || !result.Any()) return null;
            return result[0];
        }

        public List<T> SelectObjects(string where) {
            DataTable dt = Select(_tableAttribute.TableName, where);
            return FillFromDataTable(dt);
        }

        public List<T> SelectObjectsQuery(string sqlQuery)
        {
            DataTable dt = Select(sqlQuery);
            return FillFromDataTable(dt);
        }

        public List<T> FillFromDataTable(DataTable dt) {
            List<T> result = new List<T>();            
            foreach (DataRow row in dt.Rows) {
                T o = Activator.CreateInstance<T>();
                foreach (DataColumn column in dt.Columns) {
                    FieldInternal field =
                        _fieldList.FirstOrDefault(
                            _ => _.DBName.Equals(column.ColumnName, StringComparison.OrdinalIgnoreCase));
                    if (field==null) continue;
                        //Todo log warning
                        //throw new Exception($"Could not assing Column {column.ColumnName} to Object of type {typeof(T).FullName}");
                    object value = row[column.ColumnName];
                    if (value is DBNull) value = null;
                    field.PropertyInfo.SetMethod.Invoke(o, new object[] {value});
                }                
                result.Add(o);
            }
            return result;
        }

        public string GetWhereFor(BaseDataObject obj) {
            string where = "";
            foreach (FieldInternal primaryField in PrimaryFields) {
                if (where != "") where += " AND ";
                where += primaryField.DBName;
                object value = primaryField.PropertyInfo.GetMethod.Invoke(obj, null);
                if (value == null) where += " IS ";
                else where += "=";
                where += GetSQLString(value);
            }
            return where;
        }

        private static IEnumerable<FieldInternal> PrimaryFields => _fieldList.Where(_ => _.IsPrimaryKey);

        public Hashtable CreateHashtable(BaseDataObject obj)
        {
            Hashtable ht = new Hashtable();
            foreach (FieldInternal field in _fieldList) {
                if (field.AutoIdAttribute!=null) continue;
                ht[field.DBName] = GetDBValue(field.PropertyInfo.GetMethod.Invoke(obj, null));
            }
            return ht;
        }

        private object GetSQLString(object o) {
            if (o == null) return "NULL";
            Type t = o.GetType();
            if (o is Nullable) {
                t=t.UnderlyingSystemType;
                throw new NotImplementedException("Nullable auslesen implementieren!");                
            }
            if (t.IsNumeric()) return "" + o;
            if (t.IsSubclassOf(typeof (bool))) {
                if (Convert.ToBoolean(o)) return 1;
                return 0;
            }
            if (t.IsSubclassOf(typeof (string))) return "'" + o.ToString() + "'";            
            throw new NotImplementedException($"{t.FullName} Typ nicht implementiert in GetSQLString");
        }

        private object GetDBValue(object o) {
            if (o == null) return DBNull.Value;
            return o;
        }

        private class FieldInternal {
            private FieldAttribute _fieldAttribute;
            private AutoIDAttribute _autoIdAttribute;
            private PropertyInfo _propertyInfo;
            private PrimaryKeyAttribute _primaryKeyAttribute;

            public FieldInternal(PropertyInfo propertyInfo, FieldAttribute fieldAttribute, PrimaryKeyAttribute primaryKeyAttribute, AutoIDAttribute autoIdAttribute) {
                _propertyInfo = propertyInfo;
                _fieldAttribute = fieldAttribute;
                _primaryKeyAttribute = primaryKeyAttribute;
                _autoIdAttribute = autoIdAttribute;
            }

            public FieldAttribute FieldAttribute {
                get { return _fieldAttribute; }
            }

            public AutoIDAttribute AutoIdAttribute {
                get { return _autoIdAttribute; }
            }

            public PrimaryKeyAttribute PrimaryKeyAttribute {
                get { return _primaryKeyAttribute; }
            }

            public PropertyInfo PropertyInfo {
                get { return _propertyInfo; }
            }

            public string DBName => PropertyInfo.Name;
            public bool IsPrimaryKey => _primaryKeyAttribute != null;

            public bool CanWriteToDB => AutoIdAttribute == null;


        }
    }
  
}
