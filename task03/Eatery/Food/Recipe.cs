using Eatery.FoodProcessing;

namespace Eatery.Food
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Processing> ListOfProcessing { get; }
        public List<ProcessedIngredient> ProcessedIngredients { get; }
        public int Price { get; }
        public Recipe(string name, params Processing[] listOfProcessing)
        {
            Name = name;
            ListOfProcessing = listOfProcessing.ToList();
            ProcessedIngredients = new List<ProcessedIngredient>();
            foreach(var process in listOfProcessing)
            {
                for(int i = 0; i < process.CountOfIngredients; i++)
                    ProcessedIngredients.Add(new ProcessedIngredient(process.Ingredient.Name, process.Ingredient.Price + (int)process.Type, process.Type));
            }
        }
    

        public List<Ingredient> GetIngridients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var item in ListOfProcessing)
                ingredients.Add(item.Ingredient);

            return ingredients;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Recipe)
                return false;
            else
            {
                var newObj = obj as Recipe;
                return newObj.Name == Name && newObj.ListOfProcessing.SequenceEqual(ListOfProcessing)
                    && Price == newObj.Price;
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + ListOfProcessing.GetHashCode() + Price.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
