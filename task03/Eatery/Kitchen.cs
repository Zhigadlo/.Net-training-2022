using Eatery.IngredientStorage;
using Eatery.Employees;
using Eatery.Food;

namespace Eatery
{
    public class Kitchen
    {
        public List<StorageForIngredients> Storages { get; }
        public List<Cook> Cooks { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<Recipe> Recipes { get; set; }
        
        public Kitchen(List<Cook> cooks, List<Recipe> recipes)
        {
            Cooks = cooks;
            Recipes = recipes;
            Dishes = new List<Dish>();
            Storages = new List<StorageForIngredients>()
            {
                new StorageForIngredients(StorageType.Freezer, new List<Ingredient>()),
                new StorageForIngredients(StorageType.Fridge, new List<Ingredient>()),
                new StorageForIngredients(StorageType.Warehouse, new List<Ingredient>())
            };
        }

        public Dish GetDish(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
