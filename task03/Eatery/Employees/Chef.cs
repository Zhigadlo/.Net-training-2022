using Eatery.Models;

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
    }
}
