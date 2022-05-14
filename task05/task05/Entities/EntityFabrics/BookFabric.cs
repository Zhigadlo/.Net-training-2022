using Microsoft.Data.SqlClient;
using ORM;
using ORM.Interfaces;
using System.Data;
using System.Reflection;

namespace Entities.EntityFabrics
{
    public class BookFabric : IEntityFabric<Book>
    {
        public SqlConnection Connection { get; set; }
        private string _table;
        private GenreFabric _genreFabric;
        private AuthorFabric _authorFabric;

        public BookFabric(SqlConnection connection)
        {
            Connection = connection;
            _genreFabric = new GenreFabric(Connection);
            _authorFabric = new AuthorFabric(Connection);
            var bookAttribute = typeof(Book).GetCustomAttribute<DataTableName>() ?? new DataTableName("Books");
            _table = bookAttribute.Name;
        }
        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id=@id";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            command.ExecuteNonQuery();
        }
        public void Dispose()
        {
            _authorFabric.Dispose();
            _genreFabric.Dispose();
            Connection?.Close();
        }
        public void Insert(Book entity)
        {
            var authorAttribute = typeof(Author).GetCustomAttribute<DataTableName>() ?? new DataTableName("Authors");
            string authorTable = authorAttribute.Name;
            var genreAttribute = typeof(Genre).GetCustomAttribute<DataTableName>() ?? new DataTableName("Genres");
            string genreTable = genreAttribute.Name;

            int genreId = entity.Genre.Id;
            int authorId = entity.Author.Id;
            string commandText = $"insert into {_table} (Name, AuthorId, GenreId) " +
                $"values (@name, @authorId, @genreId)";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter name = new SqlParameter("@name", entity.Name);
            SqlParameter authorIdParam = new SqlParameter("@authorId", authorId);
            SqlParameter genreIdParam = new SqlParameter("@genreId", genreId);
            command.Parameters.AddRange(new SqlParameter[] {name, authorIdParam, genreIdParam});
            command.ExecuteNonQuery();
        }
        public Book Read(int id)
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
            int authorId = (int)row.ItemArray[2];
            int genreId = (int)row.ItemArray[3];
            Book book = new Book(name, _genreFabric.Read(genreId), _authorFabric.Read(authorId));
            book.Id = id;

            return book;
        }
        public void Update(int id, Book newEntity)
        {
            var authorAttribute = typeof(Author).GetCustomAttribute<DataTableName>() ?? new DataTableName("Authors");
            string authorTable = authorAttribute.Name;
            var genreAttribute = typeof(Genre).GetCustomAttribute<DataTableName>() ?? new DataTableName("Genres");
            string genreTable = genreAttribute.Name;

            int genreId = newEntity.Genre.Id;
            int authorId = newEntity.Author.Id;

            string commandText = $"update {_table} set Name=@name, AuthorId=@authorId, " +
                $"GenreId=@genreId where Id=@id";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter idParam = new SqlParameter("@id", id);
            SqlParameter nameParam = new SqlParameter("@name", newEntity.Name);
            SqlParameter authorIdParam = new SqlParameter("@authorId", authorId);
            SqlParameter genreIdParam = new SqlParameter("@genreId", genreId);

            command.Parameters.AddRange(new SqlParameter[] { idParam, nameParam, authorIdParam, genreIdParam });
            command.ExecuteNonQuery();
        }
        public List<Book> ReadAll()
        {
            string commandString = $"select * from {_table}";
            SqlCommand command = new SqlCommand(commandString, Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            List<Book> books = new List<Book>();
            DataRowCollection rows = dataTable.Rows;
            foreach(DataRow row in rows)
            {
                string name = row.ItemArray[1].ToString();
                int authorId = (int)row.ItemArray[2];
                int genreId = (int)row.ItemArray[3];
                Book book = new Book(name, _genreFabric.Read(genreId), _authorFabric.Read(authorId));
                book.Id = (int)row.ItemArray[0];
                books.Add(book);
            }

            return books;
        }
    }
}
