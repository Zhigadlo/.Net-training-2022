using Microsoft.Data.SqlClient;
using ORM;
using ORM.Interfaces;
using System.Data;
using System.Reflection;

namespace Entities.EntityFabrics
{
    public class BookFacility : IEntityFabric<Book>
    {
        public SqlConnection Connection { get; set; }
        private string _table;
        private GenreFabric _genreFabric;
        private AuthorFabric _authorFabric;

        public BookFacility(SqlConnection connection)
        {
            Connection = connection;
            _genreFabric = new GenreFabric(Connection);
            _authorFabric = new AuthorFabric(Connection);
            var bookAttribute = typeof(Book).GetCustomAttribute<DataTableName>() ?? new DataTableName("Books");
            _table = bookAttribute.Name;
        }
        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id={id}";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
        public void Dispose()
        {
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
            string commandText = $"insert into ({_table} inner join {authorTable} on {authorTable}.Id={_table}.AuthorId) " +
                $"inner join {genreTable} on {_table}.GenreId={genreTable}.Id (Name, AuthorId, GenreId) values ('{entity.Name}'," +
                $"{authorId}, {genreId})";
        }
        public Book Read(int id)
        {
            string commandString = $"select * from {_table} where Id={id}";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, Connection);
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

            string commandText = $"update ({_table} inner join {authorTable} on {authorTable}.Id={_table}.AuthorId) " +
                $"inner join {genreTable} on {_table}.GenreId={genreTable}.Id set Name='{newEntity.Name}' and AuthorId={authorId} " +
                $"and GenreId={genreId} where Id={id}";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
    }
}
