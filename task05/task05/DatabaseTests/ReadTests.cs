using Xunit;
using ORM;
using Entities;

namespace DatabaseTests
{
    public class ReadTests
    {
        [Fact]
        public void ReadTest()
        {
            AdoORM adoORM = new AdoORM("librarydb", "Genres");

            Genre genre = adoORM.Read<Genre>(6);

            Assert.True(genre.Name == "Detective");
        }

    }
}
