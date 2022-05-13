using Xunit;
using Microsoft.Data.SqlClient;
using Entities;
using Entities.EntityFabrics;
using System;

namespace DatabaseTests
{
    public class AbonentAccountingFabricTests
    {
        private SqlConnection _connection = new SqlConnection(DbConnection.Instance.GetConnectionString());

        [Theory]
        [InlineData(0, 1, 2022, 2, 12, true, "good")]
        [InlineData(1, 0, 2022, 5, 13, false, "average")]
        public void Insert(int abonentId, int bookId, int year, int month, int day, bool isBookReturned, string bookCondition)
        {
            AbonentAccountingFabric abonentAccountingFabric = new AbonentAccountingFabric(_connection);
            abonentAccountingFabric.Connection.Open();

            AbonentFabric abonentFabric = new AbonentFabric(_connection);
            Abonent abonent = abonentFabric.Read(abonentId);

            BookFabric bookFabric = new BookFabric(_connection);
            Book book = bookFabric.Read(bookId);

            DateTime takeDate = new DateTime(year, month, day);

            AbonentAccounting abonentAccounting = new AbonentAccounting(abonent, book, takeDate, isBookReturned, bookCondition);

            abonentAccountingFabric.Insert(abonentAccounting);

            abonentAccountingFabric.Dispose();
        }

        [Theory]
        [InlineData(0, 0, 1, 2022, 2, 12, true, "good")]
        [InlineData(1, 1, 0, 2022, 5, 13, false, "average")]
        public void Read(int id, int abonentId, int bookId, int year, int month, int day, bool isBookReturned, string bookCondition)
        {
            AbonentAccountingFabric abonentAccountingFabric = new AbonentAccountingFabric(_connection);
            abonentAccountingFabric.Connection.Open();

            AbonentFabric abonentFabric = new AbonentFabric(_connection);
            Abonent abonent = abonentFabric.Read(abonentId);

            BookFabric bookFabric = new BookFabric(_connection);
            Book book = bookFabric.Read(bookId);

            DateTime takeDate = new DateTime(year, month, day);

            AbonentAccounting expectedAbonentAccounting = new AbonentAccounting(abonent, book, takeDate, isBookReturned, bookCondition);

            AbonentAccounting actualAbonentAccounting = abonentAccountingFabric.Read(id);

            abonentAccountingFabric.Dispose();

            Assert.True(expectedAbonentAccounting.Equals(actualAbonentAccounting));
        }

        [Theory]
        [InlineData(1, 0, 1, 2022, 2, 12, true, "fixed")]
        [InlineData(0, 1, 0, 2022, 5, 13, false, "bad")]
        public void Update(int id, int abonentId, int bookId, int year, int month, int day, bool isBookReturned, string bookCondition)
        {
            AbonentAccountingFabric abonentAccountingFabric = new AbonentAccountingFabric(_connection);
            abonentAccountingFabric.Connection.Open();

            AbonentFabric abonentFabric = new AbonentFabric(_connection);
            Abonent abonent = abonentFabric.Read(abonentId);

            BookFabric bookFabric = new BookFabric(_connection);
            Book book = bookFabric.Read(bookId);

            DateTime takeDate = new DateTime(year, month, day);

            AbonentAccounting expectedAbonentAccounting = new AbonentAccounting(abonent, book, takeDate, isBookReturned, bookCondition);

            abonentAccountingFabric.Update(id, expectedAbonentAccounting);

            AbonentAccounting actualAbonentAccounting = abonentAccountingFabric.Read(id);

            abonentAccountingFabric.Dispose();

            Assert.True(expectedAbonentAccounting.Equals(actualAbonentAccounting));
        }
    }
}
