using Microsoft.Data.SqlClient;
using ORM.Interfaces;
using ORM;
using System.Reflection;
using System.Data;

namespace Entities.Fabrics
{
    public class GenreFabric : IEntityFabric<Genre>
    {
        public SqlConnection Connection { get; }
        private string _table = typeof(Genre).GetCustomAttribute<DataTableName>().Name;
        public GenreFabric(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }
        public void Insert(Genre entity)
        {
            string commandText = $"insert into {_table} (Name) values ('{entity.Name}')";
            SqlCommand command = new SqlCommand();
            command.CommandText = commandText;
            command.Connection = Connection;
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id={id}";
            SqlCommand command = new SqlCommand();
            command.CommandText = commandText;
            command.Connection = Connection;
            command.ExecuteNonQuery();
        }

        public Genre Read(int id)
        {
            string commandString = $"select * from {_table} where Id={id}";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, Connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            Genre genre = new Genre(dataTable.Rows[0].ItemArray[1].ToString());
            genre.Id = id;

            return genre;
        }

        public void Update(int id, Genre newEntity)
        {
            string commandText = $"update {_table} set Name='{newEntity.Name}' where Id={id}";
            SqlCommand command = new SqlCommand();
            command.CommandText = commandText;
            command.Connection = Connection;
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
