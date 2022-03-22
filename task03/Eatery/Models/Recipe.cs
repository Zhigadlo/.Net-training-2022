namespace Eatery.Models
{
    public class Recipe
    {
        public List<IngridientProcessing> ListOfProcessing { get; }
        public Recipe(params IngridientProcessing[] listOfProcessing)
        {
            ListOfProcessing = listOfProcessing.ToList();
        }

        public List<Ingridient> GetIngridients()
        {
            List<Ingridient> ingridients = new List<Ingridient>();
            foreach (var item in ListOfProcessing)
                ingridients.Add(item.IngridientForProcessing);

            return ingridients;
        }

    }
}
