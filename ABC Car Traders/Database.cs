using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public class Database
    {
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

                // Create Cars table
                string createCarTable = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cars' AND xtype='U')
                                          CREATE TABLE Cars (
                                            Id INT IDENTITY(1,1) PRIMARY KEY,
                                            Make NVARCHAR(100),
                                            Model NVARCHAR(100),
                                            Price DECIMAL(18,2))";
                var command = new SqlCommand(createCarTable, connection);
                command.ExecuteNonQuery();

                // Create Customers table
                string createCustomerTable = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customers' AND xtype='U')
                                                CREATE TABLE Customers (
                                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                                Name NVARCHAR(100),
                                                Email NVARCHAR(100),
                                                Phone NVARCHAR(20),
                                                Password NVARCHAR(100))";
                command = new SqlCommand(createCustomerTable, connection);
                command.ExecuteNonQuery();

                // Create CarParts table
                string createCarPartsTable = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CarParts' AND xtype='U')
                                               CREATE TABLE CarParts (
                                               Id INT IDENTITY(1,1) PRIMARY KEY,
                                               PartName NVARCHAR(100),
                                               Price DECIMAL(18,2))";
                command = new SqlCommand(createCarPartsTable, connection);
                command.ExecuteNonQuery();

                // Create Admins table
                string createAdminsTable = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Admins' AND xtype='U')
                                             CREATE TABLE Admins (
                                             Id INT IDENTITY(1,1) PRIMARY KEY,
                                             UserName NVARCHAR(100),
                                             Password NVARCHAR(100))";
                command = new SqlCommand(createAdminsTable, connection);
                command.ExecuteNonQuery();

                // Create Orders table
                string createOrdersTable = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' AND xtype='U')
                                             CREATE TABLE Orders (
                                             Id INT IDENTITY(1,1) PRIMARY KEY,
                                             CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
                                             OrderDate DATETIME,
                                             Status NVARCHAR(50))";
                command = new SqlCommand(createOrdersTable, connection);
                command.ExecuteNonQuery();

                // Create OrderDetails table
                string createOrderDetailsTable = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OrderDetails' AND xtype='U')
                                                   CREATE TABLE OrderDetails (
                                                   Id INT IDENTITY(1,1) PRIMARY KEY,
                                                   OrderId INT FOREIGN KEY REFERENCES Orders(Id),
                                                   CarId INT FOREIGN KEY REFERENCES Cars(Id),
                                                   PartId INT FOREIGN KEY REFERENCES CarParts(Id),
                                                   Quantity INT)";
                command = new SqlCommand(createOrderDetailsTable, connection);
                command.ExecuteNonQuery();
            }
        }

        // ------------------ CRUD Operations for Cars ------------------
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Make, Model, Price FROM Cars WHERE Id = @CarId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarId", carId);
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

        // ------------------ CRUD Operations for Customers ------------------
        public void AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertCustomer = @"INSERT INTO Customers (Name, Email, Phone, Password) VALUES (@Name, @Email, @Phone, @Password)";
                var command = new SqlCommand(insertCustomer, connection);
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Password", customer.Password);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteCustomer = @"DELETE FROM Customers WHERE Id = @Id";
                var command = new SqlCommand(deleteCustomer, connection);
                command.Parameters.AddWithValue("@Id", customerId);
                command.ExecuteNonQuery();
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, Email, Phone, Password FROM Customers WHERE Id = @CustomerId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Password = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateCustomer = @"UPDATE Customers SET Name = @Name, Email = @Email, Phone = @Phone, Password = @Password WHERE Id = @Id";
                var command = new SqlCommand(updateCustomer, connection);
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Password", customer.Password);
                command.Parameters.AddWithValue("@Id", customer.Id);
                command.ExecuteNonQuery();
            }
        }

        // ------------------ CRUD Operations for CarParts ------------------
        public void AddCarPart(CarPart carPart)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertCarPart = @"INSERT INTO CarParts (PartName, Price) VALUES (@PartName, @Price)";
                var command = new SqlCommand(insertCarPart, connection);
                command.Parameters.AddWithValue("@PartName", carPart.PartName);
                command.Parameters.AddWithValue("@Price", carPart.Price);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCarPart(int partId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteCarPart = @"DELETE FROM CarParts WHERE Id = @Id";
                var command = new SqlCommand(deleteCarPart, connection);
                command.Parameters.AddWithValue("@Id", partId);
                command.ExecuteNonQuery();
            }
        }

        public CarPart GetCarPartById(int partId)
        {
            CarPart carPart = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, PartName, Price FROM CarParts WHERE Id = @PartId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PartId", partId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            carPart = new CarPart
                            {
                                Id = reader.GetInt32(0),
                                PartName = reader.GetString(1),
                                Price = Convert.ToDecimal(reader.GetDouble(2))
                            };
                        }
                    }
                }
            }
            return carPart;
        }

        public void UpdateCarPart(CarPart carPart)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateCarPart = @"UPDATE CarParts SET PartName = @PartName, Price = @Price WHERE Id = @Id";
                var command = new SqlCommand(updateCarPart, connection);
                command.Parameters.AddWithValue("@PartName", carPart.PartName);
                command.Parameters.AddWithValue("@Price", carPart.Price);
                command.Parameters.AddWithValue("@Id", carPart.Id);
                command.ExecuteNonQuery();
            }
        }

        // ------------------ CRUD Operations for Orders ------------------
        public void AddOrder(Order order)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertOrder = @"INSERT INTO Orders (CustomerId, OrderDate, Status) VALUES (@CustomerId, @OrderDate, @Status)";
                var command = new SqlCommand(insertOrder, connection);
                command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@Status", order.Status);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteOrder = @"DELETE FROM Orders WHERE Id = @Id";
                var command = new SqlCommand(deleteOrder, connection);
                command.Parameters.AddWithValue("@Id", orderId);
                command.ExecuteNonQuery();
            }
        }

        public Order GetOrderById(int orderId)
        {
            Order order = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Id, CustomerId, OrderDate, Status FROM Orders WHERE Id = @OrderId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new Order
                            {
                                Id = reader.GetInt32(0),
                                CustomerId = reader.GetInt32(1),
                                OrderDate = reader.GetDateTime(2),
                                Status = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return order;
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateOrder = @"UPDATE Orders SET CustomerId = @CustomerId, OrderDate = @OrderDate, Status = @Status WHERE Id = @Id";
                var command = new SqlCommand(updateOrder, connection);
                command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@Status", order.Status);
                command.Parameters.AddWithValue("@Id", order.Id);
                command.ExecuteNonQuery();
            }
        }

        public Customer GetCustomerByEmailAndPassword(string email, string password)
        {
            Customer customer = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, Email, Phone, Password FROM Customers WHERE Email = @Email AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Password = reader.GetString(4)
                            };
                        }
                    }
                }
            }

            return customer;
        }

        public List<OrderDisplay> GetOrdersWithCustomerDetails()
        {
            var orders = new List<OrderDisplay>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT o.Id, c.Name, o.OrderDate, 
                   (SELECT SUM(od.Quantity * cp.Price) 
                    FROM OrderDetails od
                    JOIN CarParts cp ON od.PartId = cp.Id
                    WHERE od.OrderId = o.Id) AS Total, 
                   o.Status
            FROM Orders o
            JOIN Customers c ON o.CustomerId = c.Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new OrderDisplay
                            {
                                Id = reader.GetInt32(0),
                                CustomerName = reader.GetString(1),
                                OrderDate = reader.GetDateTime(2),
                                Total = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                                Status = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return orders;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name FROM Customers"; // Adjust based on your table structure

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return customers;
        }

        public List<OrderDisplay> GetOrdersWithCustomerDetails(int customerId)
        {
            List<OrderDisplay> orders = new List<OrderDisplay>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query to get the orders and their details for a specific customer
                string query = @"
            SELECT o.Id, c.Name, o.OrderDate, 
                   (SELECT SUM(od.Quantity * cp.Price) 
                    FROM OrderDetails od
                    JOIN CarParts cp ON od.PartId = cp.Id
                    WHERE od.OrderId = o.Id) AS Total, 
                   o.Status
            FROM Orders o
            JOIN Customers c ON o.CustomerId = c.Id
            WHERE o.CustomerId = @CustomerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new OrderDisplay
                            {
                                Id = reader.GetInt32(0),
                                CustomerName = reader.GetString(1),
                                OrderDate = reader.GetDateTime(2),
                                Total = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                                Status = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return orders;
        }

        public List<OrderDetailDisplay> GetOrderDetailsDisplayByOrderId(int orderId)
        {
            List<OrderDetailDisplay> orderDetails = new List<OrderDetailDisplay>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query for car items
                string queryCars = @"
            SELECT od.Id, c.Make + ' ' + c.Model AS Item, od.Quantity, c.Price
            FROM OrderDetails od
            JOIN Cars c ON od.CarId = c.Id
            WHERE od.OrderId = @OrderId AND od.CarId IS NOT NULL";

                using (SqlCommand command = new SqlCommand(queryCars, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderDetails.Add(new OrderDetailDisplay
                            {
                                Id = reader.GetInt32(0), // Retrieve the Id from OrderDetails
                                Item = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                Price = reader.GetDecimal(3)
                            });
                        }
                    }
                }

                // Query for car part items
                string queryParts = @"
            SELECT od.Id, cp.PartName AS Item, od.Quantity, cp.Price
            FROM OrderDetails od
            JOIN CarParts cp ON od.PartId = cp.Id
            WHERE od.OrderId = @OrderId AND od.PartId IS NOT NULL";

                using (SqlCommand command = new SqlCommand(queryParts, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderDetails.Add(new OrderDetailDisplay
                            {
                                Id = reader.GetInt32(0), // Retrieve the Id from OrderDetails
                                Item = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                Price = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }

            return orderDetails;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO OrderDetails (OrderId, CarId, PartId, Quantity) VALUES (@OrderId, @CarId, @PartId, @Quantity)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
                command.Parameters.AddWithValue("@CarId", orderDetail.CarId == 0 ? (object)DBNull.Value : orderDetail.CarId);
                command.Parameters.AddWithValue("@PartId", orderDetail.PartId == 0 ? (object)DBNull.Value : orderDetail.PartId);
                command.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                command.ExecuteNonQuery();
            }
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM OrderDetails WHERE Id = @Id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new OrderDetail
                        {
                            Id = reader.GetInt32(0),
                            OrderId = reader.GetInt32(1),
                            CarId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            PartId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            Quantity = reader.GetInt32(4),
                        };
                    }
                }
            }
            return null;
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE OrderDetails SET CarId = @CarId, PartId = @PartId, Quantity = @Quantity WHERE Id = @Id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CarId", orderDetail.CarId == 0 ? (object)DBNull.Value : orderDetail.CarId);
                command.Parameters.AddWithValue("@PartId", orderDetail.PartId == 0 ? (object)DBNull.Value : orderDetail.PartId);
                command.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                command.Parameters.AddWithValue("@Id", orderDetail.Id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrderDetail(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM OrderDetails WHERE Id = @Id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Make, Model, Price FROM Cars";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Car car = new Car
                            {
                                Id = reader.GetInt32(0),
                                Make = reader.GetString(1),
                                Model = reader.GetString(2),
                                Price = reader.GetDecimal(3)
                            };
                            cars.Add(car);
                        }
                    }
                }
            }

            return cars;
        }

        public List<CarPart> GetCarParts()
        {
            List<CarPart> carParts = new List<CarPart>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, PartName, Price FROM CarParts";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarPart carPart = new CarPart
                            {
                                Id = reader.GetInt32(0),
                                PartName = reader.GetString(1),
                                Price = reader.GetDecimal(2)
                            };
                            carParts.Add(carPart);
                        }
                    }
                }
            }

            return carParts;
        }

        public List<Car> SearchCars(string searchTerm)
        {
            List<Car> cars = new List<Car>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT Id, Make, Model, Price
            FROM Cars
            WHERE Make LIKE @SearchTerm OR Model LIKE @SearchTerm";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                Id = reader.GetInt32(0),
                                Make = reader.GetString(1),
                                Model = reader.GetString(2),
                                Price = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }

            return cars;
        }

        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Make, Model, Price FROM Cars";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                Id = reader.GetInt32(0),
                                Make = reader.GetString(1),
                                Model = reader.GetString(2),
                                Price = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }

            return cars;
        }

        public List<CarPart> SearchCarParts(string searchTerm)
        {
            List<CarPart> carParts = new List<CarPart>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT Id, PartName, Price 
            FROM CarParts 
            WHERE PartName LIKE @SearchTerm";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            carParts.Add(new CarPart
                            {
                                Id = reader.GetInt32(0),
                                PartName = reader.GetString(1),
                                Price = Convert.ToDecimal(reader.GetDouble(2))
                            });
                        }
                    }
                }
            }

            return carParts;
        }

        public List<CarPart> GetAllCarParts()
        {
            List<CarPart> carParts = new List<CarPart>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, PartName, Price FROM CarParts";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarPart carPart = new CarPart();

                            carPart.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            carPart.PartName = reader.GetString(reader.GetOrdinal("PartName"));

                            // Handle potential casting issues for the Price column
                            if (!reader.IsDBNull(reader.GetOrdinal("Price")))
                            {
                                try
                                {
                                    carPart.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                                }
                                catch (InvalidCastException)
                                {
                                    // Handle cases where Price might be stored as a different type in the database
                                    carPart.Price = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("Price")));
                                }
                            }
                            else
                            {
                                carPart.Price = 0; // Handle null or default value for Price
                            }

                            carParts.Add(carPart);
                        }
                    }
                }
            }

            return carParts;
        }
    }
}
