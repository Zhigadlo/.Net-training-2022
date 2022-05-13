using Microsoft.Data.SqlClient;
using ORM;
using ORM.Interfaces;
using System.Data;
using System.Reflection;

namespace Entities.EntityFabrics
{
    public class AbonentFabric : IEntityFabric<Abonent>
    {
        public SqlConnection Connection { get; set; }
        private string _table;

        public AbonentFabric(SqlConnection connection)
        {
            Connection = connection;
            var abonentAttribute = typeof(Abonent).GetCustomAttribute<DataTableName>() ?? new DataTableName("Abonents");
            _table = abonentAttribute.Name;
        }

        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id=@id";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            command.ExecuteNonQuery();
        }
        public void Insert(Abonent entity)
        {
            string commandText = $"insert into {_table} (Name, LastName, MiddleName, Sex, BirthDate) " +
                $"values (@name, @lastName, @middleName, @sex, @birthDate)";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter name = new SqlParameter("@name", entity.Name);
            SqlParameter lastName = new SqlParameter("@lastName", entity.LastName);
            SqlParameter middleName = new SqlParameter("@middleName", entity.MiddleName);
            SqlParameter sex = new SqlParameter("@sex", entity.Sex);
            SqlParameter birthDate = new SqlParameter("@birthDate", entity.BirthDate);
            command.Parameters.AddRange(new SqlParameter[] { name, lastName, middleName, sex, birthDate });
            command.ExecuteNonQuery();
        }
        public Abonent Read(int id)
        {
            string commandString = $"select * from {_table} where Id=@id";
            SqlCommand command = new SqlCommand(commandString, Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            SqlDataAdapter adapter = new SqlDataAdapter(command);
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
            string commandText = $"update {_table} set Name=@name and LastName=@lastName and " +
                $"MiddleName=@middleName and Sex=@sex and BirthDate=@birthDate";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter name = new SqlParameter("@name", newEntity.Name);
            SqlParameter lastName = new SqlParameter("@lastName", newEntity.LastName);
            SqlParameter middleName = new SqlParameter("@middleName", newEntity.MiddleName);
            SqlParameter sex = new SqlParameter("@sex", newEntity.Sex);
            SqlParameter birthDate = new SqlParameter("@birthDate", newEntity.BirthDate);
            command.Parameters.AddRange(new SqlParameter[] { name, lastName, middleName, sex, birthDate});
            command.ExecuteNonQuery();
        }
        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
