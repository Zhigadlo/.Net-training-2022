using ORM;

namespace Entities
{
    [DataTableName("Genres")]
    public class Genre : IEntity
    {
        public string Name { get; set; }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
