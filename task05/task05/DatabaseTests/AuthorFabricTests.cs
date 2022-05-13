using Xunit;
using Entities;
using Entities.EntityFabrics;
using Microsoft.Data.SqlClient;

namespace DatabaseTests
{
    public class AuthorFabricTests
    {
        private SqlConnection _connection = new SqlConnection(DbConnection.Instance.GetConnectionString());
        [Theory]
        [InlineData("Lev", "Tolstoy")]
        [InlineData("Fedor", "Dostoyevkiy")]
        [InlineData("Alexander", "Pushkin")]
        public void Insert(string name, string lastName)
        {
            AuthorFabric authorFabric = new AuthorFabric(_connection);
            
            authorFabric.Connection.Open();

            authorFabric.Insert(new Author(name, lastName));

            authorFabric.Dispose();           
        }

        [Theory]
        [InlineData(0, "Fedor", "Dostoyevkiy")]
        [InlineData(1, "Alexander", "Pushkin")]
        [InlineData(2, "Lev", "Tolstoy")]
        public void Read(int id, string name, string lastName)
        {
            AuthorFabric authorFabric = new AuthorFabric(_connection);

            authorFabric.Connection.Open();

            Author expectedAuthor = new Author(name, lastName);

            Author actualAuthor =  authorFabric.Read(id);
            authorFabric.Dispose();
            
            Assert.True(expectedAuthor.Equals(actualAuthor));
        }

        [Theory]
        [InlineData(0, "Lev", "Tolstoy")]
        [InlineData(1, "Fedor", "Dostoyevkiy")]
        [InlineData(2, "Alexander", "Pushkin")]
        public void Update(int id, string name, string lastName)
        {
            AuthorFabric authorFabric = new AuthorFabric(_connection);

            authorFabric.Connection.Open();

            Author expectedAuthor = new Author(name, lastName);
            authorFabric.Update(id, expectedAuthor);

            Author actualAuthor = authorFabric.Read(id);

            authorFabric.Dispose();

            Assert.True(expectedAuthor.Equals(actualAuthor));
        }
    }
}
