using Eatery.Employees.Interfaces;
using Eatery.Food;

namespace Eatery.Employees
{
    /// <summary>
    /// Cook has their own work place and can process ingredients
    /// </summary>
    public class Cook : IEmploye
    {
        public string Name { get; }
        public string Surname { get; }
        public WorkPlace WorkPlace { get; set; }
        public Cook(string name, string surname, WorkPlace workPlace)
        {
            Name = name;
            Surname = surname;
            WorkPlace = workPlace;
        }

        public ProcessedIngredient ProcessIngredient(Ingredient ingredient)
        {
            return new ProcessedIngredient(ingredient.Name, ingredient.Price + (int)WorkPlace.ProcessingType, WorkPlace.ProcessingType);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Cook)
                return false;
            else
            {
                var newObj = obj as Cook;
                return newObj.Name == Name && newObj.Surname == Surname && newObj.WorkPlace.Equals(WorkPlace);
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Surname.GetHashCode() + WorkPlace.GetHashCode();
        }
        public override string ToString()
        {
            return "Name: " + Name + "\nSurname: " + Surname;
        }
    }
}
