using Microsoft.Data.SqlClient;
using ORM.Interfaces;
using ORM;
using System.Reflection;
using System.Data;

namespace Entities.EntityFabrics
{
    public class GenreFabric : IEntityFabric<Genre>
    {
        public SqlConnection Connection { get; }
        private string _table;
        public GenreFabric(SqlConnection connection)
        {
            Connection = connection;
            var genreAttribute = typeof(Genre).GetCustomAttribute<DataTableName>() ?? new DataTableName("Genres");
            _table = genreAttribute.Name;
        }
        public void Insert(Genre entity)
        {
            string commandText = $"insert into {_table} (Name) values (@name)";

            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter name = new SqlParameter("@name", entity.Name);
            command.Parameters.Add(name);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id=@id";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter idParam = new SqlParameter("@id", id);
            command.Parameters.Add(idParam);
            command.ExecuteNonQuery();
        }

        public Genre Read(int id)
        {
            string commandString = $"select * from {_table} where Id=@id";
            SqlCommand command = new SqlCommand(commandString, Connection);
            SqlParameter idParameter = new SqlParameter("@id", id);
            command.Parameters.Add(idParameter); ;
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            Genre genre = new Genre(dataTable.Rows[0].ItemArray[1].ToString());
            genre.Id = id;

            return genre;
        }

        public void Update(int id, Genre newEntity)
        {
            string commandText = $"update {_table} set Name=@name where Id=@id";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter name = new SqlParameter("@name", newEntity.Name);
            SqlParameter idParam = new SqlParameter("@id", id);
            command.Parameters.AddRange(new SqlParameter[] { name, idParam }); ;
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
