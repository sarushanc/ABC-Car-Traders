using System;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class CarPartsForm : Form
    {
        private Database database;
        private bool isAdmin;

        public CarPartsForm(bool isAdmin)
        {
            InitializeComponent();
            database = new Database();
            this.isAdmin = isAdmin;
            SetAdminPrivileges();
        }

        private void SetAdminPrivileges()
        {
            // Enable or disable add, edit, delete based on admin status
            aDDRECORDToolStripMenuItem.Enabled = isAdmin;
            eDITRECORDToolStripMenuItem.Enabled = isAdmin;
            dELETERECORDToolStripMenuItem.Enabled = isAdmin;
        }

        private void CarPartsForm_Load(object sender, EventArgs e)
        {
            // Load data into the CarParts table when the form loads
            this.carPartsTableAdapter.Fill(this.car_traderDataSet4.CarParts);
        }

        private void aDDRECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                CarPartDialog dialog = new CarPartDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var carPart = new CarPart
                        {
                            PartName = dialog.PartName,
                            Price = decimal.Parse(dialog.Price)
                        };
                        database.AddCarPart(carPart);
                        this.carPartsTableAdapter.Fill(this.car_traderDataSet4.CarParts);
                        MessageBox.Show("Car part added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while adding the car part. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to add car parts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dELETERECORDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int partId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                    var confirmResult = MessageBox.Show("Are you sure to delete this car part record?",
                                                         "Confirm Delete",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            database.DeleteCarPart(partId);
                            this.carPartsTableAdapter.Fill(this.car_traderDataSet4.CarParts);
                            MessageBox.Show("Car part record deleted successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while deleting the car part. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a car part record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to delete car parts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void eDITRECORDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the selected car part's ID
                    int partId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                    // Retrieve the car part details from the database
                    CarPart carPartToEdit = database.GetCarPartById(partId);

                    // Create a new dialog for editing
                    CarPartDialog dialog = new CarPartDialog(carPartToEdit);

                    // Show the dialog
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Update the car part's details with the new values from the dialog
                            carPartToEdit.PartName = dialog.PartName;
                            carPartToEdit.Price = decimal.Parse(dialog.Price);

                            // Update the car part in the database
                            database.UpdateCarPart(carPartToEdit);

                            // Refresh the DataGridView to reflect the changes
                            this.carPartsTableAdapter.Fill(this.car_traderDataSet4.CarParts);

                            MessageBox.Show("Car part record updated successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while updating the car part. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a car part record to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to edit car parts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click events if needed
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textSearch.Text.Trim();

            try
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    // Query the database to find car parts that match the search term
                    var searchResults = database.SearchCarParts(searchTerm);

                    if (searchResults.Count > 0)
                    {
                        // Bind the search results to the DataGridView
                        dataGridView1.DataSource = searchResults;
                    }
                    else
                    {
                        // If no results, clear the DataGridView
                        dataGridView1.DataSource = null;
                        MessageBox.Show("No car parts found matching your search criteria.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // When search term is null or empty, reload all records
                    var allCarParts = database.GetAllCarParts();
                    dataGridView1.DataSource = allCarParts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for car parts. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
