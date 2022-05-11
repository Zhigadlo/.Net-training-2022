using ORM;

namespace Entities
{
    [DataTableName("Books")]
    public class Book : IEntity
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public Author Author { get; set; }

        public Book(string name, string genre, Author author)
        {
            Name = name;
            Genre = genre;
            Author = author;
        }
    }
}