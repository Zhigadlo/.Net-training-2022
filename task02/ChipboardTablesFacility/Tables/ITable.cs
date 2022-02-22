using TableDetails;

namespace Tables
{
    public interface ITable
    {
        public List<TableLeg> tableLegs { get; set; }
        public TableTop tableTop { get; set; }
        public int Price { get; set; }
    }
}