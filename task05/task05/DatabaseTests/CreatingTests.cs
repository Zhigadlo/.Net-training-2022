using Xunit;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace DatabaseTests
{
    public class CreatingTests
    {
        [Fact]
        public async Task CreatingDB()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();   
                SqlCommand command = new SqlCommand("create database librarydb", connection);
                await command.ExecuteNonQueryAsync();
            }
        }

        [Fact]
        public async Task CreateTablesInDb()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=librarydb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                // create Authors table
                command.CommandText = "create table Authors (Id int primary key, Name varchar(20), LastName varchar(20))";
                command.ExecuteNonQuery();
                // create Genres table
                command.CommandText = "create table Genres (Id int primary key, Name varchar(20))";
                command.ExecuteNonQuery();
                // create Book conditions table
                command.CommandText = "create table BookConditions (Id int primary key, Name varchar(20))";
                command.ExecuteNonQuery();
                // create Books table
                command.CommandText = "create table Books (Id int primary key," +
                                                           "Name varchar(20), " +
                                                           "AuthorId int foreign key references Authors(Id)," +
                                                           "GenreId int foreign key references Genres(Id))";
                command.ExecuteNonQuery();
                // create Abonents table
                command.CommandText = "create table Abonents (Id int primary key," +
                                                             "Name varchar(20)," +
                                                             "LastName varchar(20)," +
                                                             "MiddleName varchar(20)," +
                                                             "Sex bit," +
                                                             "BirthDate date)";
                command.ExecuteNonQuery();

                // create AbonentAccounting table
                command.CommandText = "create table AbonentsAccounting (Id int primary key," +
                                                                       "AbonentId int foreign key references Abonents(Id)," +
                                                                       "BookId int foreign key references Books(Id)," +
                                                                       "IsBookReturned bit," +
                                                                       "BookConditionId int foreign key references BookConditions(Id))";

                command.ExecuteNonQuery();
            }
        }
    }
}