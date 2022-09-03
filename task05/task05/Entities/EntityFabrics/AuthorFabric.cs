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
        private string _table;
        public AuthorFabric(SqlConnection connection)
        {
            Connection = connection;
            var authorAttribute = typeof(Author).GetCustomAttribute<DataTableName>() ?? new DataTableName("Authors");
            _table = authorAttribute.Name;
        }

        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id=@id";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter idParam = new SqlParameter("@id", id);
            command.Parameters.Add(idParam);
            command.ExecuteNonQuery();
        }
        public void Dispose()
        {
            Connection.Dispose();
        }
        public void Insert(Author entity)
        {
            string commandText = $"insert into {_table} (Name, LastName) values (@name, @lastName)";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter name = new SqlParameter("@name", entity.Name);
            SqlParameter lastName = new SqlParameter("@lastName", entity.LastName);
            command.Parameters.AddRange(new SqlParameter[] { name, lastName });
            command.ExecuteNonQuery();
        }
        public Author Read(int id)
        {
            string commandString = $"select * from {_table} where Id=@id";
            SqlCommand command = new SqlCommand(commandString, Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataRow row = dataTable.Rows[0];
            string name = row.ItemArray[1].ToString();
            string lastName = row.ItemArray[2].ToString();

            Author author = new Author(name, lastName);
            author.Id = id;
            return author;
        }
        public void Update(int id, Author newEntity)
        {
            string commandText = $"update {_table} set Name=@name, LastName=@lastName where Id=@id";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter idParam = new SqlParameter("@id", id);
            SqlParameter name = new SqlParameter("@name", newEntity.Name);
            SqlParameter lastName = new SqlParameter("@lastName", newEntity.LastName);
            command.Parameters.AddRange(new SqlParameter[] { idParam, name, lastName });
            command.ExecuteNonQuery();
        }
        public List<Author> ReadAll()
        {
            string commandString = $"select * from {_table}";
            SqlCommand command = new SqlCommand(commandString, Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            List<Author> authors = new List<Author>();

            DataRowCollection rows = dataTable.Rows;
            foreach (DataRow row in rows)
            {
                string name = row.ItemArray[1].ToString();
                string lastName = row.ItemArray[2].ToString();

                Author author = new Author(name, lastName);
                author.Id = (int)row.ItemArray[0];
                authors.Add(author);
            }
            return authors;
        }
    }
}
