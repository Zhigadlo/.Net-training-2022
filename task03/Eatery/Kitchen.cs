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
        public List<StorageForIngredients> Storages { get; set; }
        public StorageForProcessedIngredients StorageForProcessedIngredients { get; set; }
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
            StorageForProcessedIngredients = new StorageForProcessedIngredients();
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
            Recipe recipe = FindRecipeByName(name);
            Dictionary<ProcessedIngredient, int> ingredientsForDish = GetProcessedIngredientsByRecipe(recipe);
            DeleteIngredientsForStorage(ingredientsForDish, StorageForProcessedIngredients);
            return new Dish(recipe.Name, ingredientsForDish);
        }

        public List<Order> GetOrders() => Manager.Orders;

        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Kitchen)
                return false;
            else
            {
                var newObj = obj as Kitchen;
                return Storages.SequenceEqual(newObj.Storages) && Cooks.SequenceEqual(newObj.Cooks)
                    && Dishes.SequenceEqual(newObj.Dishes) && Recipes.SequenceEqual(newObj.Recipes)
                    && Chef.Equals(newObj.Chef) && Manager.Equals(newObj.Manager);
            }
        }
        public override int GetHashCode()
        {
            return Storages.GetHashCode() + Cooks.GetHashCode() + Dishes.GetHashCode() 
                + Recipes.GetHashCode() + Chef.GetHashCode() + Manager.GetHashCode();
        }
        public override string ToString()
        {
            return "Kitchen";
        }

        private Dictionary<ProcessedIngredient, int> GetProcessedIngredientsByRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
        private Recipe FindRecipeByName(string name)
        {
            foreach (var recipe in Recipes)
            {
                if (recipe.Name.ToLower() == name.ToLower())
                {
                    return recipe;
                }
            }

            throw new Exception("There is no recipe for this dish");
        }
        private void DeleteIngredientsForStorage<Ingredient, Storage>(Dictionary<Ingredient, int> ingredients, Storage storage)
        {
            throw new NotImplementedException();
        }
        private ProcessedIngredient GetProcessedIngredient(Ingredient ingredient, ProcessingType processingType)
        {
            Ingredient ingredientForProcessing = FindIngredientFromStorages(ingredient.Name, processingType);
            foreach (var cook in Cooks)
            {
                if (cook.WorkPlace.ProcessingType == processingType)
                {
                    var processedIngredient = cook.ProcessIngredient(ingredientForProcessing);
                    DeleteIngredient(ingredientForProcessing);
                    return processedIngredient;
                }
            }

            throw new Exception("There is no work place for this processing");
        }
        private Ingredient FindIngredientFromStorages(string name, ProcessingType processingType)
        {
            foreach (var storage in Storages)
            {
                foreach (var ingredient in storage.Ingredients)
                {
                    bool isProcessingExist = false;
                    foreach (var type in ingredient.Key.PossibleTypesOfProcessing)
                    {
                        if (type == processingType)
                        {
                            isProcessingExist = true;
                            break;
                        }
                    }
                    
                    if (ingredient.Key.Name.ToLower() == name.ToLower() && isProcessingExist)
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
