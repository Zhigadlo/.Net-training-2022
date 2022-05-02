namespace Entities
{
    public class Human
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public Human(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}
