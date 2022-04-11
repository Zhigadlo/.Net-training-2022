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

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Order)
                return false;
            else
            {
                var newObj = obj as Order;
                return Number == newObj.Number && DishNames.SequenceEqual(newObj.DishNames);
            }
        }
        public override int GetHashCode()
        {
            return Number.GetHashCode() + DishNames.GetHashCode();
        }
        public override string ToString()
        {
            string dishes = "";
            foreach (var dish in DishNames)
                dishes += dish + ", ";
            return "Number of order: " + Number + "\n" + dishes;
        }
    }
}
