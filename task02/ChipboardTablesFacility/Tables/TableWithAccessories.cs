using TableDetails;

namespace Tables
{
    public class TableWithAccessories : ITable
    {
        public List<TableLeg> tableLegs { get; set; }
        public TableTop tableTop { get; set; }
        public int Price { get; set; }

        private int _priceForProcessing = 7;
        private int _priceForAccessories = 10;

        public TableWithAccessories(TableLeg leg, int countOfLegs, TableTop top)
        {
            tableLegs = new List<TableLeg>();
            for (int i = 0; i < countOfLegs; i++)
                tableLegs.Add(leg);

            tableTop = top;
            Price = top.Price + leg.Price * countOfLegs + _priceForProcessing + _priceForAccessories;

        }
    }
}
