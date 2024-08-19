using System;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class CustomersForm : Form
    {
        private Database database;

        public CustomersForm()
        {
            InitializeComponent();
            database = new Database();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            // Load data into the Customers table when the form loads
            this.customersTableAdapter.Fill(this.car_traderDataSet5.Customers);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click events if needed
        }

        private void aDDRECORDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CustomerDialog dialog = new CustomerDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var customer = new Customer
                    {
                        Name = dialog.CustomerName,
                        Email = dialog.CustomerEmail,
                        Phone = dialog.CustomerPhone,
                        Password = dialog.CustomerPassword
                    };
                    database.AddCustomer(customer);
                    this.customersTableAdapter.Fill(this.car_traderDataSet5.Customers);
                    MessageBox.Show("Customer added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the customer. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dELETERECORDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                var confirmResult = MessageBox.Show("Are you sure to delete this customer record?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        database.DeleteCustomer(customerId);
                        this.customersTableAdapter.Fill(this.car_traderDataSet5.Customers);
                        MessageBox.Show("Customer record deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the customer. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void eDITRECORDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected customer's ID
                int customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Retrieve the customer details from the database
                Customer customerToEdit = database.GetCustomerById(customerId);

                // Create a new dialog for editing
                CustomerDialog dialog = new CustomerDialog(customerToEdit);

                // Show the dialog
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Update the customer's details with the new values from the dialog
                        customerToEdit.Name = dialog.CustomerName;
                        customerToEdit.Email = dialog.CustomerEmail;
                        customerToEdit.Phone = dialog.CustomerPhone;
                        customerToEdit.Password = dialog.CustomerPassword;

                        // Update the customer in the database
                        database.UpdateCustomer(customerToEdit);

                        // Refresh the DataGridView to reflect the changes
                        this.customersTableAdapter.Fill(this.car_traderDataSet5.Customers);

                        MessageBox.Show("Customer record updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while updating the customer. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer record to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
