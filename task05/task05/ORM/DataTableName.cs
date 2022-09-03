namespace ORM
{
    public class DataTableName : Attribute
    {
        public string Name { get; }

        public DataTableName(string name)
        {
            Name = name;
        }
    }
}
