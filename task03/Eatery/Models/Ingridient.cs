namespace Eatery.Models
{
    /// <summary>
    /// Ingridient class with sizes and name
    /// </summary>
    public class Ingridient
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public int StorageTemperature { get; }
        public Ingridient(string name, int weight, int price, int storageTemperature)
        {
            Name = name;
            Weight = weight;
            Price = price;
            StorageTemperature = storageTemperature;
        }
    }
}