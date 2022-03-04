using Facility.TableDetails;

namespace Facility.Interfaces
{
    public interface ITableWithAccessories
    {
        public Dictionary<TableAccessoriesType, int> TableAccessories { get; }
    }
}
