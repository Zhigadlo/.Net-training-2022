using ORM;
using ORM.Interfaces;

namespace Entities
{
    [DataTableName("Authors")]
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public Author(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public override string ToString()
        {
            return Name + " " + LastName;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + LastName.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Author)
                return false;
            else
            {
                Author newObj = obj as Author;
                return Name == newObj.Name && LastName == newObj.LastName;
            }
        }
    }
}
