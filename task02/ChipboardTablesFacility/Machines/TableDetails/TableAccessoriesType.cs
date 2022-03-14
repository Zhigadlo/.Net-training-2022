namespace Facility.TableDetails
{
    /// <summary>
    /// Enum for types of furniture
    /// </summary>
    public enum TableAccessoriesType
    {
        Corners = 4,
        Eurochools = 6,
        Shkants = 1,
        Ties = 3,
        BoltNut = 2
    }

    public class TableAccessory
    {
        public static TableAccessoriesType Parse(string accessory)
        {
            switch (accessory)
            {
                case "Corners":
                    return TableAccessoriesType.Corners;
                case "Eurochools":
                    return TableAccessoriesType.Eurochools;
                case "Shkants":
                    return TableAccessoriesType.Shkants;
                case "Ties":
                    return TableAccessoriesType.Ties;
                case "BoltNut":
                    return TableAccessoriesType.BoltNut;
                default:
                    throw new Exception("Wrong type of material");
            }
        }
    }
}
