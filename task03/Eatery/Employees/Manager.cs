using Eatery.Employees.Interfaces;

namespace Eatery.Employees
{
    public class Manager : IEmploye
    {
        public string Name { get; }
        public string Surname { get; }
        
        public Manager(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public void GetOrder(int numberOfClient, List<string> listOfDishNames)
        {
            throw new NotImplementedException();
        }
    }
}
