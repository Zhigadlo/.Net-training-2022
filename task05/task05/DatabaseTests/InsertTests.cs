using Xunit;
using ORM;
using System.Collections.Generic;
using Entities;

namespace DatabaseTests
{
    public class InsertTests
    {
        private AdoORM _orm = new AdoORM("librarydb", "Genres");
        [Theory]
        [InlineData("Adventure")]
        [InlineData("Detective")]
        [InlineData("Novel")]
        [InlineData("Fantastic")]
        [InlineData("Scientific")]
        public void GenreInsert(string genre)
        {
            _orm.Table = "Genres";
            _orm.Insert(new Genre(genre));
        }

        [Theory]
        [InlineData("Lev", "Tolstoy")]
        [InlineData("Maksim", "Tank")]
        [InlineData("Nikolay", "Gogol")]
        [InlineData("Fedor", "Dostoyevskiy")]
        [InlineData("Alexandr", "Pushkin")]
        public void AuthorsInsert(string name, string lastName)
        {
            _orm.Table = "Authors";
            _orm.Insert(new Author(name, lastName));
        }


    }
}
