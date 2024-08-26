using ClosedXML.Excel;
using System;
using System.IO;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class ManageCarDetailsForm : Form
    {
        private Database database;
        private bool isAdmin;

        public ManageCarDetailsForm(bool isAdmin)
        {
            InitializeComponent();
            database = new Database();
            this.isAdmin = isAdmin;
        }

        private void ManageCarDetailsForm_Load(object sender, EventArgs e)
        {
            // Load data into the Cars table when the form loads
            this.carsTableAdapter.Fill(this.car_traderDataSet3.Cars);
            try
            {
                // Additional loading logic if needed
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the data. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click events if needed
        }

        private void aDDRECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("Only admins can add car records.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CarDialog dialog = new CarDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var car = new Car
                    {
                        Make = dialog.make,
                        Model = dialog.model,
                        Price = decimal.Parse(dialog.price)
                    };
                    database.AddCar(car);
                    this.carsTableAdapter.Fill(this.car_traderDataSet3.Cars);
                    MessageBox.Show("Car added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the car. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dELETERECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("Only admins can delete car records.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int carId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                var confirmResult = MessageBox.Show("Are you sure to delete this car record?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        database.DeleteCar(carId);
                        this.carsTableAdapter.Fill(this.car_traderDataSet3.Cars);
                        MessageBox.Show("Car record deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the car. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a car record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void eDITRECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("Only admins can edit car records.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected car's ID
                int carId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Retrieve the car details from the database
                Car carToEdit = database.GetCarById(carId);

                // Create a new dialog for editing
                CarDialog dialog = new CarDialog();

                // Pre-fill the dialog with the car's current details using the new methods
                dialog.SetMake(carToEdit.Make);
                dialog.SetModel(carToEdit.Model);
                dialog.SetPrice(carToEdit.Price.ToString());

                // Show the dialog
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Update the car's details with the new values from the dialog
                        carToEdit.Make = dialog.make;
                        carToEdit.Model = dialog.model;
                        carToEdit.Price = decimal.Parse(dialog.price);

                        // Update the car in the database
                        database.UpdateCar(carToEdit);

                        // Refresh the DataGridView to reflect the changes
                        this.carsTableAdapter.Fill(this.car_traderDataSet3.Cars);

                        MessageBox.Show("Car record updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while updating the car. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a car record to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textSearch.Text.Trim();

            try
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    // Query the database to find cars that match the search term
                    var searchResults = database.SearchCars(searchTerm);

                    if (searchResults.Count > 0)
                    {
                        // Bind the search results to the DataGridView
                        dataGridView1.DataSource = searchResults;
                    }
                    else
                    {
                        // Clear the DataGridView if no results found
                        dataGridView1.DataSource = null;
                        MessageBox.Show("No cars found matching your search criteria.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // When search term is null or empty, reload all records
                    var allCars = database.GetAllCars(); // Method to get all cars
                    dataGridView1.DataSource = allCars;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for cars. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get all car details
                var cars = database.GetAllCars();

                if (cars.Count > 0)
                {
                    // Create a new Excel workbook
                    using (var workbook = new XLWorkbook())
                    {
                        // Add a worksheet
                        var worksheet = workbook.Worksheets.Add("Cars");

                        // Add headers
                        worksheet.Cell(1, 1).Value = "Make";
                        worksheet.Cell(1, 2).Value = "Model";
                        worksheet.Cell(1, 3).Value = "Price";

                        // Populate data
                        for (int i = 0; i < cars.Count; i++)
                        {
                            worksheet.Cell(i + 2, 1).Value = cars[i].Make;
                            worksheet.Cell(i + 2, 2).Value = cars[i].Model;
                            worksheet.Cell(i + 2, 3).Value = cars[i].Price;
                        }

                        // Save the workbook to a MemoryStream
                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            stream.Seek(0, SeekOrigin.Begin);

                            // Save the file to the user's desktop
                            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CarDetails.xlsx");
                            File.WriteAllBytes(filePath, stream.ToArray());

                            MessageBox.Show($"Car details have been successfully exported to {filePath}.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No car details available to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting car details. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
