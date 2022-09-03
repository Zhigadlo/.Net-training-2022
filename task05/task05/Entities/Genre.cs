using ORM;
using ORM.Interfaces;

namespace Entities
{
    [DataTableName("Genres")]
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Genre)
                return false;
            else
            {
                Genre newObj = obj as Genre;
                return Name == newObj.Name;
            }
        }
    }
}
