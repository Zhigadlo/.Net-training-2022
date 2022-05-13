using Microsoft.Data.SqlClient;
using ORM;
using ORM.Interfaces;
using System.Data;
using System.Reflection;

namespace Entities.EntityFabrics
{
    public class AbonentAccountingFabric : IEntityFabric<AbonentAccounting>
    {
        public SqlConnection Connection { get; set; }
        private string _table;
        private BookFabric _bookFabric;
        private AbonentFabric _abonentFabric;
        public AbonentAccountingFabric(SqlConnection connection)
        {
            Connection = connection;
            _bookFabric = new BookFabric(Connection);
            _abonentFabric = new AbonentFabric(Connection);
            var tableAttribute = typeof(AbonentAccounting).GetCustomAttribute<DataTableName>() ?? new DataTableName("AbonentAccountings");
            _table = tableAttribute.Name;
        }

        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id={id}";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
        public void Insert(AbonentAccounting entity)
        {
            string commandText = $"insert into {_table} (AbonentId, BookId, TakeDate, IsBookReturned, BookCondition) " +
                $"values (@abonentId, @bookId, @takeDate, @isBookReturned, @bookCondition)";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter abonentId = new SqlParameter("@abonentId", entity.Abonent.Id);
            SqlParameter bookId = new SqlParameter("@bookId", entity.Book.Id);
            SqlParameter takeDate = new SqlParameter("@takeDate", entity.TakeDate);
            SqlParameter isBookReturned = new SqlParameter("@isBookReturned", entity.IsBookReturned);
            SqlParameter bookCondition = new SqlParameter("bookCondition", entity.BookCondition);
            command.Parameters.AddRange(new SqlParameter [] { abonentId, bookId, takeDate, isBookReturned, bookCondition });
            
            command.ExecuteNonQuery();
        }

        public AbonentAccounting Read(int id)
        {
            string commandString = $"select * from {_table} where Id=@id";
            SqlCommand command = new SqlCommand(commandString, Connection);
            command.Parameters.Add(new SqlParameter("@id", id));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataRow row = dataTable.Rows[0];
            int abonentId = (int)row.ItemArray[1];
            int bookId = (int)row.ItemArray[2];
            DateTime takeDate = (DateTime)row.ItemArray[3];
            bool isBookReturned = (bool)row.ItemArray[4];
            string bookCondition = row.ItemArray[5].ToString();

            AbonentAccounting abonentAccounting = new AbonentAccounting(_abonentFabric.Read(abonentId),
                _bookFabric.Read(bookId), takeDate, isBookReturned, bookCondition);

            return abonentAccounting;
        }

        public void Update(int id, AbonentAccounting newEntity)
        {
            string commandText = $"update {_table} set AbonentId=@abonentId, BookId=@bookId," +
                $"IsBookReturned=@isBookReturned, BookCondition=@bookCondition where id=@id";

            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter abonentId = new SqlParameter("@abonentId", newEntity.Abonent.Id);
            SqlParameter bookId = new SqlParameter("@bookId", newEntity.Book.Id);
            SqlParameter isBookReturned = new SqlParameter("@isBookReturned", newEntity.IsBookReturned);
            SqlParameter bookCondition = new SqlParameter("@bookCondition", newEntity.BookCondition);
            SqlParameter idParameter = new SqlParameter("@id", id);

            command.Parameters.AddRange(new SqlParameter[] { abonentId, bookId, isBookReturned, bookCondition, idParameter });
            command.ExecuteNonQuery();
        }
        public void Dispose()
        {
            Connection.Close();
        }
    }
}
