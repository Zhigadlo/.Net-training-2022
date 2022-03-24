using Eatery.IngredientStorage.Interfaces;
using Eatery.Food;

namespace Eatery.IngredientStorage
{
    public class StorageForProcessedIngredients : IStorage<ProcessedIngredient>
    {
        public Dictionary<ProcessedIngredient, int>  Ingredients { get; }

        public StorageForProcessedIngredients()
        {
            Ingredients = new Dictionary<ProcessedIngredient, int>();
        }
    }
}
