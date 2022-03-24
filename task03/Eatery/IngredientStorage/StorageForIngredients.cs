using Eatery.Food;
using Eatery.IngredientStorage.Interfaces;

namespace Eatery.IngredientStorage
{
    public class StorageForIngredients : IStorage<Ingredient>
    {
        public StorageType Type { get; }
        public Dictionary<Ingredient, int> Ingredients { get; set; }
        
        public StorageForIngredients(StorageType type, Dictionary<Ingredient, int> ingredients)
        {
            Type = type;
            Ingredients = ingredients;
        }
    }
}
