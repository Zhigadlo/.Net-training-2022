﻿using Xunit;
using Entities.EntityFabrics;
using Entities;
using System;
using Microsoft.Data.SqlClient;

namespace DatabaseTests
{
    public class AbonentFabricTests
    {
        private SqlConnection _connection = new SqlConnection(DbConnection.Instance.GetConnectionString());
        
        [Theory]
        [InlineData("Vladislav", "Zhogol", "Dmitrievich", true, 2003, 8, 23)]
        [InlineData("Ivan", "Andreevec", "Ivanovich", true, 2002, 9, 17)]
        public void Insert(string name, string lastName, string middleName, bool isMale, int year, int month, int day)
        {
            AbonentFabric abonentFabric = new AbonentFabric(_connection);

            abonentFabric.Connection.Open();

            DateTime birthDate = new DateTime(year, month, day);

            abonentFabric.Insert(new Abonent(name, lastName, middleName, isMale, birthDate));

            abonentFabric.Dispose();
        }

        [Theory]
        [InlineData(1, "Vladislav", "Zhogol", "Dmitrievich", true, 2003, 8, 23)]
        [InlineData(0, "Ivan", "Andreevec", "Ivanovich", true, 2002, 9, 17)]
        public void Read(int id, string name, string lastName, string middleName, bool isMale, int year, int month, int day)
        {
            AbonentFabric abonentFabric = new AbonentFabric(_connection);

            abonentFabric.Connection.Open();

            DateTime birthDate = new DateTime(year, month, day);
            Abonent expectedAbonent = new Abonent(name, lastName, middleName, isMale, birthDate);
            Abonent actualAbonent = abonentFabric.Read(id);

            abonentFabric.Dispose();
            Assert.True(expectedAbonent.Equals(actualAbonent));
        }
    }
}
