using Xunit;
using ORM;
using Entities;
using Entities.Fabrics;

namespace DatabaseTests
{
    public class InsertTests
    {
        [Theory]
        [InlineData("Adventure")]
        [InlineData("Detective")]
        [InlineData("Novel")]
        [InlineData("Fantastic")]
        [InlineData("Scientific")]
        public void GenreInsert(string genreName)
        {
            GenreFabric genreFabric = new GenreFabric(DbConnection.Instance.GetConnectionString());
            
            genreFabric.Connection.Open();
            Genre genre = new Genre(genreName);
            genreFabric.Insert(genre);

            genreFabric.Dispose();
        }

        [Theory]
        [InlineData("Lev", "Tolstoy")]
        [InlineData("Maksim", "Tank")]
        [InlineData("Nikolay", "Gogol")]
        [InlineData("Fedor", "Dostoyevskiy")]
        [InlineData("Alexandr", "Pushkin")]
        public void AuthorsInsert(string name, string lastName)
        {

        }


    }
}
