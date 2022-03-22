using Eatery.Models;
using Eatery.Employees.Interfaces;

namespace Eatery.Employees
{
    public class Cook : IEmploye
    {
        public string Name { get; }
        public string Surname { get; }

        public Cook(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Dish CookDish(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
