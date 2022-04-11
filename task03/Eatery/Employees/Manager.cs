using Eatery.Employees.Interfaces;
using Eatery.Food;

namespace Eatery.Employees
{
    /// <summary>
    /// Manager can get orders
    /// </summary>
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
            Orders.Add(new Order(numberOfClient, listOfDishNames));
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Manager)
                return false;
            else
            {
                var newObj = obj as Manager;
                return newObj.Name == Name && newObj.Surname == Surname && newObj.Orders.SequenceEqual(Orders);
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Surname.GetHashCode() + Orders.GetHashCode();
        }
        public override string ToString()
        {
            return "Name: " + Name + "\nSurname: " + Surname;
        }
    }
}
