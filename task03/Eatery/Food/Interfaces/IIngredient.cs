using Eatery.IngredientStorage;

namespace Eatery.Food.Interfaces
{
    public interface IIngredient
    {
        public string Name { get; }
        public int Price { get; set; }
        public int Weight { get; }
        public StorageType StoragePlace { get; }
    }
}
