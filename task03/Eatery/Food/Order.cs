namespace Eatery.Food
{
    public class Order
    {
        public int Number { get; }
        public List<string> DishNames { get; set; }

        public Order(int number, List<string> dishNames)
        {
            Number = number;
            DishNames = dishNames;
        }
    }
}
