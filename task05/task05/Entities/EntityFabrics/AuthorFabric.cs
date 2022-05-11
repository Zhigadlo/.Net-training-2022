using Microsoft.Data.SqlClient;
using ORM;
using ORM.Interfaces;
using System.Data;
using System.Reflection;

namespace Entities.EntityFabrics
{
    public class AuthorFabric : IEntityFabric<Author>
    {
        public SqlConnection Connection { get; set; }
        private string _table = typeof(Author).GetCustomAttribute<DataTableName>().Name;
        public AuthorFabric(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id={id}";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
        public void Dispose()
        {
            Connection.Dispose();
        }
        public void Insert(Author entity)
        {
            string commandText = $"insert into {_table} (Name, LastName) values ('{entity.Name}', '{entity.LastName}')";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
        public Author Read(int id)
        {
            string commandString = $"select * from {_table} where Id={id}";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, Connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataRow row = dataTable.Rows[0];
            string name = row.ItemArray[1].ToString();
            string lastName = row.ItemArray[2].ToString();

            Author author = new Author(name, lastName);
            return author;
        }
        public void Update(int id, Author newEntity)
        {
            string commandText = $"update {_table} set Name={newEntity.Name} and LastName={newEntity.LastName} where Id={id}";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
    }
}
