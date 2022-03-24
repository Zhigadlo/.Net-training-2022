using Eatery.Food;

namespace Eatery.Employees
{
    public class Chef : Cook
    {
        public Chef(string name, string surname) : base(name, surname)
        {
        }

        public Recipe MakeNewRecipe()
        {
            throw new NotImplementedException();
        }

        public Dish MakeDish(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
