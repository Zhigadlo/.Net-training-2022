using Eatery.Employees.Interfaces;
using Eatery.Food;

namespace Eatery.Employees
{
    public class Manager : IEmploye
    {
        public string Name { get; }
        public string Surname { get; }
        public List<Order> Orders { get; set; }
        
        public Manager(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Orders = new List<Order>();
        }

        public void GetOrder(int numberOfClient, List<string> listOfDishNames)
        {
            throw new NotImplementedException();
        }
    }
}
