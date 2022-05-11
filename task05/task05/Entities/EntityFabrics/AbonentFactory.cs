using Microsoft.Data.SqlClient;
using ORM;
using ORM.Interfaces;
using System.Data;
using System.Reflection;

namespace Entities.EntityFabrics
{
    public class AbonentFactory : IEntityFabric<Abonent>
    {
        public SqlConnection Connection { get; set; }
        private string _table;

        public AbonentFactory(SqlConnection connection)
        {
            Connection = connection;
            var abonentAttribute = typeof(Abonent).GetCustomAttribute<DataTableName>() ?? new DataTableName("Abonents");
            _table = abonentAttribute.Name;
        }

        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id={id}";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
        public void Insert(Abonent entity)
        {
            string commandText = $"insert into {_table} (Name, LastName, MiddleName, Sex, BirthDate) " +
                $"values ('{entity.Name}', '{entity.LastName}', '{entity.MiddleName}', {entity.Sex}, " +
                $"'{entity.BirthDate.ToShortDateString()}')";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
        public Abonent Read(int id)
        {
            string commandString = $"select * from {_table} where Id={id}";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, Connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataRow row = dataTable.Rows[0];
            string name = row.ItemArray[1].ToString();
            string lastName = row.ItemArray[2].ToString();
            string middleName = row.ItemArray[3].ToString();
            int sex = (int)row.ItemArray[4];
            DateTime birthDate = (DateTime)row.ItemArray[5];

            Abonent abonent = new Abonent(name, lastName, middleName, sex, birthDate);
            abonent.Id = id;
            return abonent;
        }
        public void Update(int id, Abonent newEntity)
        {
            string commandText = $"update {_table} set Name='{newEntity.Name}' and LastName='{newEntity.LastName}' and " +
                $"MiddleName='{newEntity.MiddleName}' and Sex='{newEntity.Sex}' and BirthDate='{newEntity.BirthDate.ToShortDateString()}'";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
