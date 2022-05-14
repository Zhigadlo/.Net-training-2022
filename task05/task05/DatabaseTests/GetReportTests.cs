using Xunit;
using Microsoft.Data.SqlClient;
using Entities;
using Entities.EntityFabrics;
using System.Collections.Generic;

namespace DatabaseTests
{
    public class GetReportTests
    {
        private SqlConnection _connection = new SqlConnection(DbConnection.Instance.GetConnectionString());
        [Fact]
        public void GetTextReport()
        {
            AbonentAccountingFabric abonentAccountingFabric = new AbonentAccountingFabric(_connection);
            abonentAccountingFabric.Connection.Open();

            abonentAccountingFabric.GetTextReport(new System.DateTime(2020, 12, 14), new System.DateTime(2022, 2, 13));

            abonentAccountingFabric.Dispose();
        }

        [Fact]
        public void GetExcelReport()
        {
            AbonentAccountingFabric abonentAccountingFabric = new AbonentAccountingFabric(_connection);
            abonentAccountingFabric.Connection.Open();

            abonentAccountingFabric.GetExcelReport(new System.DateTime(2020, 12, 14), new System.DateTime(2022, 2, 13));

            abonentAccountingFabric.Dispose();
        }

        [Fact]
        public void GetPdfReport()
        {
            AbonentAccountingFabric abonentAccountingFabric = new AbonentAccountingFabric(_connection);
            abonentAccountingFabric.Connection.Open();

            abonentAccountingFabric.GetPdfReport(new System.DateTime(2020, 12, 14), new System.DateTime(2022, 2, 13));


            abonentAccountingFabric.Dispose();

        }
    }
}
