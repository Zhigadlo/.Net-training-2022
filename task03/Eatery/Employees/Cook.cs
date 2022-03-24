using Eatery.Food;
using Eatery.Employees.Interfaces;

namespace Eatery.Employees
{
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
    }
}
