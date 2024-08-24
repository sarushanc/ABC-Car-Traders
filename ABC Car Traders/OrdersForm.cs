using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class OrdersForm : Form
    {
        private Database database;
        private Customer customer;

        // Constructor for loading all orders
        public OrdersForm()
        {
            InitializeComponent();
            database = new Database();
            this.Load += new System.EventHandler(this.OrdersForm_Load);
        }

        // Constructor for loading orders specific to a customer
        public OrdersForm(Customer customer)
        {
            InitializeComponent();
            database = new Database();
            this.customer = customer;

            this.Load += new System.EventHandler(this.OrdersForm_Load);
        }

        // Method to load orders based on whether a customer is provided
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            List<OrderDisplay> orders;

            if (customer != null)
            {
                // Load orders for the specific customer
                orders = database.GetOrdersWithCustomerDetails(customer.Id);
            }
            else
            {
                // Load all orders
                orders = database.GetOrdersWithCustomerDetails();
            }

            dataGridView1.DataSource = orders;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle cell click events if necessary
        }

        private void aDDRECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderDialog orderDialog = new OrderDialog();
            if (orderDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Order newOrder = orderDialog.Order;
                    if (customer != null)
                    {
                        newOrder.CustomerId = customer.Id; // Ensure the order is linked to the correct customer
                    }

                    // Add the new order to the database
                    database.AddOrder(newOrder);

                    // Refresh the DataGridView with the updated list of orders
                    LoadOrders();

                    MessageBox.Show("Order added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the order. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void eDITRECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int orderId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                    // Check if orderId is valid
                    if (orderId <= 0)
                    {
                        MessageBox.Show("Invalid Order ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Order existingOrder = database.GetOrderById(orderId);

                    // Check if existingOrder was successfully retrieved
                    if (existingOrder == null)
                    {
                        MessageBox.Show("The selected order could not be found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check if the user is a customer and the order status is "Pending"
                    if (customer != null && existingOrder.Status != "Pending")
                    {
                        MessageBox.Show("You can only edit orders with a status of 'Pending'.", "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Allow editing for admin or customers with "Pending" orders
                    OrderDialog orderDialog = new OrderDialog(existingOrder);

                    if (orderDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Order updatedOrder = orderDialog.Order;

                            if (updatedOrder == null)
                            {
                                MessageBox.Show("Updated order is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (customer != null)
                            {
                                updatedOrder.CustomerId = customer.Id; // Ensure the customer ID remains the same for customers
                            }

                            database.UpdateOrder(updatedOrder);

                            // Refresh the DataGridView with the updated list of orders
                            LoadOrders();

                            MessageBox.Show("Order updated successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while updating the order. Error: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an order to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred. Error: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Deleting an order
        private void dELETERECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                Order existingOrder = database.GetOrderById(orderId);

                // Check if existingOrder was successfully retrieved
                if (existingOrder == null)
                {
                    MessageBox.Show("The selected order could not be found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the order status is "Pending"
                if (existingOrder.Status != "Pending")
                {
                    MessageBox.Show("You can only delete orders with a status of 'Pending'.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure you want to delete this order?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        database.DeleteOrder(orderId);

                        // Refresh the DataGridView with the updated list of orders
                        LoadOrders();

                        MessageBox.Show("Order deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the order. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Viewing the details of an order
        private void vIEWRECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                //Order order = database.GetOrderById(orderId);

                // Uncomment and implement the following line when you have an OrderDetailsForm
                OrderDetailsForm orderDetailsForm = new OrderDetailsForm(orderId);
                orderDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
