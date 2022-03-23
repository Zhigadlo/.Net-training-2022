using Eatery.Food;
using Eatery.IngredientStorage.Interfaces;

namespace Eatery.IngredientStorage
{
    public class StorageForIngredients : IStorage<Ingredient>
    {
        public StorageType Type { get; }
        public List<Ingredient> Ingredients { get; }
        
        public StorageForIngredients(StorageType type, List<Ingredient> ingredients)
        {
            Type = type;
            Ingredients = ingredients;
        }
    }
}
