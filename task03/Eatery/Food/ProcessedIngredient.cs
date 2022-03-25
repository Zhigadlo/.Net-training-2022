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

        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not ProcessedIngredient)
                return false;
            else
            {
                var newObj = obj as ProcessedIngredient;
                return Name == newObj.Name && Price == newObj.Price && 
                    ProcessingType == newObj.ProcessingType && StoragePlace == newObj.StoragePlace;
            }    
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Price.GetHashCode() +
                StoragePlace.GetHashCode() + ProcessingType.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
