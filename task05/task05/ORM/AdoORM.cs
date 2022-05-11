using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using ORM.Interfaces;

namespace ORM
{
    /// <summary>
    /// class for CRUD operations
    /// </summary>
    public class AdoORM : IDisposable
    {
        private string _sqlConnectionString;
        private SqlConnection _connection;
        public string Table { get; set; }
        public AdoORM(string dbname, string table)
        {
            _sqlConnectionString = $"Server=(localdb)\\mssqllocaldb;Database={dbname};Trusted_Connection=True;";
            _connection = new SqlConnection(_sqlConnectionString);
            _connection.Open();
            Table = table;
        }
        

        public void Insert<T>(T obj) where T : IEntity
        {
            Type type = obj.GetType();
            string tableName = type.GetCustomAttribute<DataTableName>().Name;
            SqlDataAdapter adapter = new SqlDataAdapter($"select * from {tableName}", _connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            
            DataRow row = dataTable.NewRow();
            
            var properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] != row.ItemArray[i+1].GetType() && row.ItemArray[i + 1].GetType() == typeof(int))
                {
                    dynamic item = properties[i].GetValue(obj);

                    Insert(item);
                    
                    //Type propertyType = properties[i].GetType();
                    //tableName = propertyType.GetCustomAttribute<DataTableName>().Name;

                    //string commandText = $"select Id from {tableName} where";
                    //foreach(var prop in properties)
                    //{
                    //    commandText += $" {prop.Name}={prop.GetValue(prop.Name)}";
                    //}
                    //SqlCommand sqlCommand = new SqlCommand(commandText);
                    //int id = (int)sqlCommand.ExecuteScalar();
                }
                else
                {
                    var value = type.GetProperty(properties[i].Name).GetValue(obj);
                    row[properties[i].Name] = value;
                }

            }
            dataTable.Rows.Add(row);
            
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            
            adapter.Update(dataSet);
        }

        public void Update<T>(int id, T newObj)
        {

        }

        public T Read<T>(int id)
        {
            string table = typeof(T).GetCustomAttribute<DataTableName>().Name;
            string commandString = $"select * from {table} where Id={id}";
               
            SqlDataAdapter adapter = new SqlDataAdapter(commandString, _connection);

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            DataTable dataTable = dataSet.Tables[0];
            int itemCount = dataTable.Columns.Count;

            var value = dataTable.Rows[0].ItemArray;

            List<Type> types = typeof(T).GetProperties().Select(x => x.PropertyType).ToList();
            List<object> parameters = new List<object>();

            for (int i = 1; i < value.Length; i++)
            {
                Type type = types[i-1].GetType();
                if (type.IsClass && value[i].GetType() == typeof(int))
                {
                    parameters.Add(ReadObjectByType(type, (int)value[i]));
                }
                else
                {
                    parameters.Add(value[i]);
                }
            }
            var constructor = typeof(T).GetConstructor(types.ToArray());

            return (T)constructor.Invoke(parameters.ToArray());
            
        }

        private object ReadObjectByType(Type type, int id)
        {
            MethodInfo method = typeof(AdoORM).GetMethod("Read").MakeGenericMethod(type);
            return method.Invoke(this, new object[] { id });
        }

        public void ReadAll<T>()
        {

        }

        public void Delete(int id)
        {
            string command = $"delete from {Table} where Id={id}";
            SqlCommandExecute(command);
        }


        private void SqlCommandExecute(string commandText)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = commandText;
            command.Connection = _connection;
            command.ExecuteNonQuery();
        }
        private object PropertyValueToSqlValue<T>(T propertyValue)
        {
            if (propertyValue.GetType() == typeof(string))
                return "'" + propertyValue.ToString() + "'";

            if (propertyValue.GetType() == typeof(DateTime))
            {
                DateTime dateTime = (DateTime)(object)propertyValue;
                return $"{dateTime.Year}-{dateTime.Month}-{dateTime.Day}";
            }

            return propertyValue;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}