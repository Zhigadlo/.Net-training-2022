using Eatery.Food.Interfaces;
using Eatery.IngredientStorage;
using Eatery.FoodProcessing;

namespace Eatery.Food
{
    public class ProcessedIngredient : IIngredient
    {
        public string Name { get; }
        public int Price { get; set; }
        public StorageType StoragePlace { get; }
        public ProcessingType ProcessingType { get; }

        public ProcessedIngredient(string name, int price, ProcessingType processingType)
        {
            Name = name;
            Price = price;
            ProcessingType = processingType;
            StoragePlace = StorageType.Warehouse;
        }
    }
}
