using Eatery.Food.Interfaces;

namespace Eatery.IngredientStorage.Interfaces
{
    public interface IStorage<T>
        where T : IIngredient
    {
        public Dictionary<T, int> Ingredients { get; }
    }
}
