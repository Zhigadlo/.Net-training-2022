namespace Facility.Materials
{
    /// <summary>
    /// Enum with materials and their prices
    /// </summary>
    public enum MaterialType
    {
        ConstructionChipboard = 8,
        GeneralPurposeChipboard = 6,
        SpecialChipboard = 10,
        Metal = 12
    }
    public class Material
    {
        /// <summary>
        /// Parsing method from string to MaterialType
        /// </summary>
        /// <param name="str">String with name of material type</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static MaterialType Parse(string str)
        {
            switch (str)
            {
                case "Metal":
                    return MaterialType.Metal;
                case "ConstructionChipboard":
                    return MaterialType.ConstructionChipboard;
                case "GeneralPurposeChipboard":
                    return MaterialType.GeneralPurposeChipboard;
                case "SpecialChipboard":
                    return MaterialType.SpecialChipboard;
                default:
                    throw new Exception("Wrong type of material");
            }
        }
    }
}
