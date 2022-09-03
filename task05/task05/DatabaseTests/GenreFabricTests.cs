using Xunit;
using Entities;
using Entities.EntityFabrics;
using Microsoft.Data.SqlClient;

namespace DatabaseTests
{
    public class GenreFabricTests
    {

        private SqlConnection _connection = new SqlConnection(DbConnection.Instance.GetConnectionString());
        [Theory]
        [InlineData("Adventure")]
        [InlineData("Detective")]
        [InlineData("Novel")]
        [InlineData("Fantastic")]
        [InlineData("Scientific")]
        public void InsertTest(string genreName)
        {
            GenreFabric genreFabric = new GenreFabric(_connection);
            
            genreFabric.Connection.Open();
            Genre genre = new Genre(genreName);
            genreFabric.Insert(genre);

            genreFabric.Dispose();
        }

        [Theory]
        [InlineData(0, "Adventure")]
        [InlineData(1, "Detective")]
        [InlineData(2, "Novel")]
        [InlineData(3, "Fantastic")]
        [InlineData(4, "Scientific")]
        public void ReadTest(int id, string genreName)
        {
            GenreFabric genreFabric = new GenreFabric(_connection);

            genreFabric.Connection.Open();

            Genre genre = genreFabric.Read(id);
            genreFabric.Dispose();
            Assert.True(genre.Name == genreName);
        }

        [Theory]
        [InlineData(0, "Adventure")]
        [InlineData(1, "Detective")]
        [InlineData(2, "Novel")]
        [InlineData(3, "Fantastic")]
        [InlineData(4, "Scientific")]
        public void UpdateTest(int id, string name)
        {
            GenreFabric genreFabric = new GenreFabric(_connection);

            genreFabric.Connection.Open();

            Genre expectedGenre = new Genre(name);
            genreFabric.Update(id, new Genre(name));

            Genre actualGenre = genreFabric.Read(id);

            genreFabric.Dispose();

            Assert.True(expectedGenre.Equals(actualGenre));
        }


    }
}
