using ORM;
using ORM.Interfaces;

namespace Entities
{
    [DataTableName("Books")]
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }

        public Book(string name, Genre genre, Author author)
        {
            Name = name;
            Genre = genre;
            Author = author;
        }

        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return Author.GetHashCode() + Name.GetHashCode() + Genre.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Book)
                return false;
            else
            {
                Book newObj = obj as Book;
                return Name == newObj.Name && Genre.Equals(newObj.Genre) && Author.Equals(newObj.Author);
            }
        }
    }
}