using Xunit;
using Entities;
using Entities.EntityFabrics;
using Microsoft.Data.SqlClient;


namespace DatabaseTests
{
    public class BookFabricTests
    {
        private SqlConnection _connection = new SqlConnection(DbConnection.Instance.GetConnectionString());
        
        [Theory]
        [InlineData("book1", 3, 2)]
        [InlineData("book2", 0, 0)]
        [InlineData("book3", 2, 2)]
        [InlineData("book4", 4, 1)]
        public void Insert(string name, int genreId, int authorId)
        { 
            BookFabric bookFabric = new BookFabric(_connection);

            bookFabric.Connection.Open();

            GenreFabric genreFabric = new GenreFabric(_connection);
            Genre genre = genreFabric.Read(genreId);

            AuthorFabric authorFabric = new AuthorFabric(_connection);
            Author author = authorFabric.Read(authorId);

            bookFabric.Insert(new Book(name, genre, author));

            bookFabric.Dispose();
        }

        [Theory]
        [InlineData(0, "book1", 3, 2)]
        [InlineData(1, "book2", 0, 0)]
        [InlineData(2, "book3", 2, 2)]
        [InlineData(3, "book4", 4, 1)]
        public void Read(int id, string name, int genreId, int authorId)
        {
            BookFabric bookFabric = new BookFabric(_connection);

            bookFabric.Connection.Open();

            GenreFabric genreFabric = new GenreFabric(_connection);
            Genre genre = genreFabric.Read(genreId);

            AuthorFabric authorFabric = new AuthorFabric(_connection);
            Author author = authorFabric.Read(authorId);

            Book expectedBook = new Book(name, genre, author);

            Book actualBook = bookFabric.Read(id);

            bookFabric.Dispose();
            
            Assert.True(expectedBook.Equals(actualBook));
        }

        [Theory]
        [InlineData(0, "book1", 3, 2)]
        [InlineData(1, "book2", 0, 0)]
        [InlineData(2, "book3", 2, 2)]
        [InlineData(3, "book4", 4, 1)]
        public void Update(int id, string name, int genreId, int authorId)
        {
            BookFabric bookFabric = new BookFabric(_connection);

            bookFabric.Connection.Open();

            GenreFabric genreFabric = new GenreFabric(_connection);
            Genre genre = genreFabric.Read(genreId);

            AuthorFabric authorFabric = new AuthorFabric(_connection);
            Author author = authorFabric.Read(authorId);

            Book expectedBook = new Book(name, genre, author);

            bookFabric.Update(id, expectedBook);

            Book actualBook = bookFabric.Read(id);

            bookFabric.Dispose();

            Assert.True(expectedBook.Equals(actualBook));
        }
    }
}
