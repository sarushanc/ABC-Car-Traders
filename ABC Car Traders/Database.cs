using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

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

        public void DeleteCar(int carId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteCar = @"DELETE FROM Cars WHERE Id = @Id";
                var command = new SqlCommand(deleteCar, connection);
                command.Parameters.AddWithValue("@Id", carId);
                command.ExecuteNonQuery();
            }
        }

        public Car GetCarById(int carId)
        {
            Car car = null;

            try
            {
                // Establish a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create the SQL query to get the car by its ID
                    string query = "SELECT Id, Make, Model, Price FROM Cars WHERE Id = @CarId";

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Set the parameter value
                        command.Parameters.AddWithValue("@CarId", carId);

                        // Execute the command and read the result
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                car = new Car
                                {
                                    Id = reader.GetInt32(0),
                                    Make = reader.GetString(1),
                                    Model = reader.GetString(2),
                                    Price = reader.GetDecimal(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the car details. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return car;
        }


        public void UpdateCar(Car car)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateCar = @"UPDATE Cars SET Make = @Make, Model = @Model, Price = @Price WHERE Id = @Id";
                var command = new SqlCommand(updateCar, connection);
                command.Parameters.AddWithValue("@Make", car.Make);
                command.Parameters.AddWithValue("@Model", car.Model);
                command.Parameters.AddWithValue("@Price", car.Price);
                command.Parameters.AddWithValue("@Id", car.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
