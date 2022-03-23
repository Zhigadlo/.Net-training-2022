using Eatery.Food.Interfaces;
using Eatery.IngredientStorage;
using Eatery.FoodProcessing;

namespace Eatery.Food
{
    public class ProcessedIngredient : IIngredient
    {
        public string Name { get; }
        public int Price { get; set; }
        public int Weight { get; }
        public StorageType StoragePlace { get; }
        public ProcessingType TypeOfProcessing { get; }

        public ProcessedIngredient(string name, int price, int weight, ProcessingType typeOfProcessing)
        {
            Name = name;
            Price = price;
            Weight = weight;
            TypeOfProcessing = typeOfProcessing;
            StoragePlace = StorageType.Warehouse;
        }

        
    }
}
