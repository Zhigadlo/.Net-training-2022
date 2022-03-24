using Eatery.IngredientStorage;
using Eatery.Employees;
using Eatery.Food;
using Eatery.FoodProcessing;

namespace Eatery
{
    /// <summary>
    /// Kitchen can get orders from manager and make dishes
    /// </summary>
    public class Kitchen
    {
        public List<StorageForIngredients> Storages { get; }
        public Dictionary<Ingredient, int> Ingredients { get; set; }
        public List<WorkPlace> WorkPlaces { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<Recipe> Recipes { get; set; }
        public Chef Chef { get; }
        public Manager Manager { get; }
        
        public Kitchen(Dictionary<Ingredient, int> ingredients, List<WorkPlace> workPlaces, List<Recipe> recipes, Chef chef, Manager manager)
        {
            Ingredients = ingredients;
            Chef = chef;
            Manager = manager;
            WorkPlaces = workPlaces;
            Recipes = recipes;
            Dishes = new List<Dish>();
            Storages = new List<StorageForIngredients>()
            {
                new StorageForIngredients(StorageType.Freezer, new List<Ingredient>()),
                new StorageForIngredients(StorageType.Fridge, new List<Ingredient>()),
                new StorageForIngredients(StorageType.Warehouse, new List<Ingredient>())
            };
        }

        public Dish MakeDish(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        private ProcessedIngredient GetProcessedIngredient(Ingredient ingredient, ProcessingType processingType)
        {
            throw new NotImplementedException();
        }

        private Ingredient FindIngredientFromStorages()
        {
            throw new NotImplementedException();
        }

        
    }
}
