using ORM;

namespace Entities
{
    [DataTableName("Authors")]
    public class Author : IEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public Author(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}
