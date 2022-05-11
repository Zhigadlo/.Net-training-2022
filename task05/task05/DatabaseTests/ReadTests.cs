using Xunit;
using Entities;
using Entities.Fabrics;

namespace DatabaseTests
{
    public class ReadTests
    {
        [Theory]
        [InlineData(20, "Novel")]
        [InlineData(21, "Detective")]
        [InlineData(22, "Scientific")]
        [InlineData(23, "Fantastic")]
        [InlineData(24, "Adventure")]
        public void GenresReadTest(int id, string genreName)
        {
            GenreFabric genreFabric = new GenreFabric(DbConnection.Instance.GetConnectionString());

            genreFabric.Connection.Open();

            Genre genre = genreFabric.Read(id);
            genreFabric.Dispose();
            Assert.True(genre.Name == genreName);
        }

    }
}
