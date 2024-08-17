using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ABC_Car_Traders
{
    public class Database
    {
        // Connection string for SQL Server
        private string connectionString = @"Data Source=SALES-PC-DGM\SQLEXPRESS;Initial Catalog=car_trader;Integrated Security=True;";

        public Database()
        {
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createCarTable = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cars' AND xtype='U')
                                          CREATE TABLE Cars (
                                            Id INT IDENTITY(1,1) PRIMARY KEY,
                                            Make NVARCHAR(100),
                                            Model NVARCHAR(100),
                                            Price DECIMAL(18,2))";
                var command = new SqlCommand(createCarTable, connection);
                command.ExecuteNonQuery();

                string createCustomerTable = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customers' AND xtype='U')
                                                CREATE TABLE Customers (
                                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                                Name NVARCHAR(100),
                                                Email NVARCHAR(100),
                                                Password NVARCHAR(100))";
                command = new SqlCommand(createCustomerTable, connection);
                command.ExecuteNonQuery();
            }
        }

        public void AddCar(Car car)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertCar = @"INSERT INTO Cars (Make, Model, Price) VALUES (@Make, @Model, @Price)";
                var command = new SqlCommand(insertCar, connection);
                command.Parameters.AddWithValue("@Make", car.Make);
                command.Parameters.AddWithValue("@Model", car.Model);
                command.Parameters.AddWithValue("@Price", car.Price);
                command.ExecuteNonQuery();
            }
        }
    }
}
