﻿using Eatery.Food.Interfaces;
using Eatery.FoodProcessing;
using Eatery.IngredientStorage;

namespace Eatery.Food
{
    /// <summary>
    /// Ingridient class with sizes, name and storage place
    /// </summary>
    public class Ingredient : IIngredient
    {
        public string Name { get; }
        public int Price { get; set; }
        public StorageType StoragePlace { get; }
        public List<ProcessingType> PossibleTypesOfProcessing { get; }
        public Ingredient(string name, int price, StorageType storagePlace, params ProcessingType[] possibleTypesOfProcessing)
        {
            Name = name;
            Price = price;
            StoragePlace = storagePlace;
            PossibleTypesOfProcessing = possibleTypesOfProcessing.ToList();
        }

        public bool IsProcessingSuitable(ProcessingType processingType)
        {
            foreach (var type in PossibleTypesOfProcessing)
                if (type == processingType)
                    return true;

            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Ingredient)
                return false;
            else
            {
                var newObj = obj as Ingredient;
                return Name == newObj.Name && Price == newObj.Price && StoragePlace == newObj.StoragePlace
                    && PossibleTypesOfProcessing.SequenceEqual(newObj.PossibleTypesOfProcessing);
            }

        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Price.GetHashCode() + StoragePlace.GetHashCode() + PossibleTypesOfProcessing.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}