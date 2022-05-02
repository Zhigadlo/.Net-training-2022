namespace Entities
{
    public class Book
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public Human Author { get; set; }

        public Book(string name, string genre, Human author)
        {
            Name = name;
            Genre = genre;
            Author = author;
        }
    }
}