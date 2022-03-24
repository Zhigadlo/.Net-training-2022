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
        public List<Cook> Cooks { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<Recipe> Recipes { get; set; }
        public Chef Chef { get; }
        public Manager Manager { get; }
        
        public Kitchen(Dictionary<Ingredient, int> ingredients, List<Cook> cooks, List<Recipe> recipes, Chef chef, Manager manager)
        {
            Chef = chef;
            Manager = manager;
            Cooks = cooks;
            Recipes = recipes;
            Dishes = new List<Dish>();
            Storages = new List<StorageForIngredients>()
            {
                new StorageForIngredients(StorageType.Freezer, new Dictionary<Ingredient, int>()),
                new StorageForIngredients(StorageType.Fridge, new Dictionary<Ingredient, int>()),
                new StorageForIngredients(StorageType.Warehouse, new Dictionary<Ingredient, int>())
            };

            foreach (var ingredient in ingredients)
            {
                switch (ingredient.Key.StoragePlace)
                { 
                    case StorageType.Freezer:
                        Storages[0].Ingredients.Add(ingredient.Key, ingredient.Value);
                        break;
                    case StorageType.Fridge:
                        Storages[1].Ingredients.Add(ingredient.Key, ingredient.Value);
                        break;
                    case StorageType.Warehouse:
                        Storages[2].Ingredients.Add(ingredient.Key, ingredient.Value);
                        break;
                    default:
                        throw new Exception("There is no place for " + ingredient.Key.Name);
                }
            }
        }

        public Dish MakeDish(string name)
        {
            foreach (var recipe in Recipes)
            {
                if (recipe.Name.ToLower() == name.ToLower())
                {
                    return new Dish(recipe);
                }
            }
            
            throw new Exception("There is no recipe for this dish");
        }

        public List<Order> GetOrders() => Manager.Orders;

        private ProcessedIngredient GetProcessedIngredient(Ingredient ingredient, ProcessingType processingType)
        {
            Ingredient ingredientForProcessing = FindIngredientFromStorages(ingredient.Name);
            foreach (var cook in Cooks)
            {
                if (cook.WorkPlace.ProcessingType == processingType)
                {
                    DeleteIngredient(ingredientForProcessing);
                    return cook.ProcessIngredient(ingredientForProcessing);
                }
            }

            throw new Exception("There is no work place for this processing");
        }

        private Ingredient FindIngredientFromStorages(string name)
        {
            foreach (var storage in Storages)
            {
                foreach(var ingredient in storage.Ingredients)
                {
                    if(ingredient.Key.Name.ToLower() == name.ToLower())
                        return ingredient.Key;
                }
            }

            throw new Exception("There is no required ingredient in storages");
        }

        private void DeleteIngredient(Ingredient ingredientForDelete)
        {
            foreach (var storage in Storages)
            {
                foreach (var ingredient in storage.Ingredients)
                {
                    if (ingredient.Key.Equals(ingredientForDelete))
                    {
                        if (storage.Ingredients[ingredient.Key] > 0)
                            storage.Ingredients[ingredient.Key] -= 1;
                        else
                            throw new Exception("There is no such ingredient");
                    }
                }
            }
        }
    }
}
