using Facility.TableDetails;

namespace Facility.Interfaces
{
    /// <summary>
    /// Table with accessories table. Table with accessories class must inherit from ITable and this interface
    /// </summary>
    public interface ITableWithAccessories
    {
        public Dictionary<TableAccessoriesType, int> TableAccessories { get; }
    }
}
