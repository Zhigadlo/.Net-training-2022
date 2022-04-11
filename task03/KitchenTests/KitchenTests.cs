using Eatery.Employees;
using Eatery.Food;
using Eatery.FoodProcessing;
using Eatery.IngredientStorage;
using Eatery;
using System.Collections.Generic;
using Xunit;

namespace KitchenTests
{
    public class KitchenTests
    {
        [Theory]
        [InlineData(20, 15, 10, 4, 40, 20, 7, 5, 2, 4, 1, 2, 1, 1)]
        [InlineData(13, 0, 10, 4, 5, 20, 7, 5, 3, 5, 2, 3, 2, 2)]
        [InlineData(17, 8, 1, 4, 21, 3, 7, 5, 1, 3, 1, 2, 1, 1)]
        [InlineData(13, 111111, 10, 4, 40, 20, 7, 5, 2, 4, 1, 2, 3, 3)]
        [InlineData(0, 10103, 10, 4, 40, 20, 7, 5, 2, 4, 1, 2, 2, 3)]
        public void MakeDishTest(int tomatoCount, int bananaCount, int onionCount, int porkCount, int carrotCount,
            int garlicCount, int pepperCount, int riceCount, int requiredOnionCount, int requiredCarrotCount, 
            int requiredPorkCount, int requiredPepperCount, int requiredRiceCount, int requiredGarlicCount)
        {
            var tomato = new Ingredient("Tomato", 30, StorageType.Fridge, ProcessingType.Slice, ProcessingType.Cook, ProcessingType.Pickle, ProcessingType.Stew);
            var banana = new Ingredient("Banana", 35, StorageType.Warehouse, ProcessingType.Slice, ProcessingType.Fry, ProcessingType.Stew);
            var onion = new Ingredient("Onion", 20, StorageType.Fridge, ProcessingType.Slice, ProcessingType.Fry, ProcessingType.Stew);
            var pork = new Ingredient("Pork", 70, StorageType.Freezer, ProcessingType.Bake, ProcessingType.Slice, ProcessingType.Cook, ProcessingType.Fry, ProcessingType.Stew);
            var carrot = new Ingredient("Carrot", 4, StorageType.Fridge, ProcessingType.Slice, ProcessingType.Cook, ProcessingType.Fry, ProcessingType.Stew);
            var garlic = new Ingredient("Garlic", 10, StorageType.Fridge, ProcessingType.Slice, ProcessingType.Fry, ProcessingType.Cook, ProcessingType.Stew);
            var pepper = new Ingredient("Pepper", 47, StorageType.Fridge, ProcessingType.Slice, ProcessingType.Fry);
            var rice = new Ingredient("Rice", 20, StorageType.Warehouse, ProcessingType.Cook, ProcessingType.Stew);

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>
            {
                { tomato, tomatoCount},
                { banana, bananaCount},
                { onion, onionCount },
                { pork, porkCount },
                { carrot, carrotCount},
                { garlic, garlicCount},
                { pepper, pepperCount },
                { rice, riceCount }
            };

            Cook cook1 = new Cook("Ivan", "Ivanov", new WorkPlace(5, 5, ProcessingType.Slice));
            Cook cook2 = new Cook("Jhon", "Wick", new WorkPlace(10, 20, ProcessingType.Cook));
            Cook cook3 = new Cook("Donovan", "Gold", new WorkPlace(7, 6, ProcessingType.Stew));
            Cook cook4 = new Cook("Fry", "Man", new WorkPlace(20, 4, ProcessingType.Fry));

            List<Cook> cooks = new List<Cook>
            {
                cook1,
                cook2,
                cook3,
                cook4
            };

            Processing processing1 = new Processing(ProcessingType.Slice, onion, requiredOnionCount);
            Processing processing2 = new Processing(ProcessingType.Slice, carrot, requiredCarrotCount);
            Processing processing3 = new Processing(ProcessingType.Fry, pork, requiredPorkCount);
            Processing processing4 = new Processing(ProcessingType.Slice, pepper, requiredPepperCount);
            Processing processing5 = new Processing(ProcessingType.Cook, rice, requiredRiceCount);
            Processing processing6 = new Processing(ProcessingType.Cook, garlic, requiredGarlicCount); 

            Recipe pilafRecipe = new Recipe("Pilaf", processing1, processing2, processing3, processing4, processing5, 
                processing6);
            Recipe bananaJuice = new Recipe("BananaJusice");

            List<Recipe> recipes = new List<Recipe>
            {
                pilafRecipe,
                bananaJuice
            };

            Chef chef = new Chef("ChefName", "ChefSurname", new WorkPlace(10, 20, ProcessingType.Bake));
            Manager manager = new Manager("ManagerName", "ManagerSurname");

            Kitchen kitchen = new Kitchen(ingredients, cooks, recipes, chef, manager);

            var processedOnion = new ProcessedIngredient("Onion", onion.Price + (int)ProcessingType.Slice, ProcessingType.Slice);
            var processedCarrot = new ProcessedIngredient("Carrot", carrot.Price + (int)ProcessingType.Slice, ProcessingType.Slice);
            var processedPork = new ProcessedIngredient("Pork", pork.Price + (int)ProcessingType.Fry, ProcessingType.Fry);
            var processedPepper = new ProcessedIngredient("Pepper", pepper.Price + (int)ProcessingType.Slice, ProcessingType.Slice);
            var processedRice = new ProcessedIngredient("Rice", rice.Price + (int)ProcessingType.Cook, ProcessingType.Cook);
            var processedGarlic = new ProcessedIngredient("Garlic", garlic.Price + (int)ProcessingType.Cook, ProcessingType.Cook);

            Dish actualDish = kitchen.MakeDish("pilaf");
            Dictionary<ProcessedIngredient, int> processedIngredients = new Dictionary<ProcessedIngredient, int>
            {
                { processedOnion, requiredOnionCount },
                { processedCarrot, requiredCarrotCount },
                { processedPork, requiredPorkCount },
                { processedPepper, requiredPepperCount },
                { processedRice, requiredRiceCount },
                { processedGarlic, requiredGarlicCount }
            };
            Dish expectedDish = new Dish("Pilaf", processedIngredients);

            Assert.True(actualDish.Equals(expectedDish));
            Assert.Equal(onionCount - processedIngredients[processedOnion], kitchen.Storages[1].Ingredients[onion]);
            Assert.Equal(carrotCount - processedIngredients[processedCarrot], kitchen.Storages[1].Ingredients[carrot]);
            Assert.Equal(porkCount - processedIngredients[processedPork], kitchen.Storages[0].Ingredients[pork]);
            Assert.Equal(pepperCount - processedIngredients[processedPepper], kitchen.Storages[1].Ingredients[pepper]);
            Assert.Equal(riceCount - processedIngredients[processedRice], kitchen.Storages[2].Ingredients[rice]);
            Assert.Equal(garlicCount - processedIngredients[processedGarlic], kitchen.Storages[1].Ingredients[garlic]);
        }
    }
}