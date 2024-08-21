using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class OrderDialog : Form
    {
        public Order Order { get; private set; }
        private Database database; // Assuming you have a Database class to interact with your database

        public OrderDialog()
        {
            InitializeComponent();
            database = new Database();  // Initialize your Database connection or context
            InitializeDropdowns();
        }

        public OrderDialog(Order existingOrder) : this()
        {
            if (existingOrder == null)
            {
                throw new ArgumentNullException(nameof(existingOrder), "Order cannot be null.");
            }

            // Initialize the form with the existing order's details
            comboBoxCustomers.SelectedValue = existingOrder.CustomerId;
            dateTimePickerOrderDate.Value = existingOrder.OrderDate;
            comboBoxStatus.SelectedItem = existingOrder.Status;

            // Set the current order object to the one being edited
            Order = existingOrder;
        }

        // Method to initialize dropdowns with data
        private void InitializeDropdowns()
        {
            // Retrieve customers from the database and bind them to the comboBoxCustomers
            List<Customer> customers = database.GetCustomers();
            comboBoxCustomers.DataSource = customers;
            comboBoxCustomers.DisplayMember = "Name";  // Show the customer names
            comboBoxCustomers.ValueMember = "Id";      // Use the customer ID as the value

            // Populate comboBoxStatus with the order statuses
            comboBoxStatus.DataSource = Enum.GetValues(typeof(OrderStatus));
        }

        // This method is triggered when the form loads
        private void OrderDialog_Load(object sender, EventArgs e)
        {
            // Optional: Additional initialization tasks can be added here
        }

        // This method handles the 'Add' button click event
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Order == null)
                {
                    Order = new Order();
                }

                // Set the Order properties based on the form inputs
                Order.CustomerId = (int)comboBoxCustomers.SelectedValue;
                Order.OrderDate = dateTimePickerOrderDate.Value;
                Order.Status = comboBoxStatus.SelectedItem.ToString();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the order. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method handles the 'Clear' button click event
        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear all fields in the form or simply close with a Cancel result
            comboBoxCustomers.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            dateTimePickerOrderDate.Value = DateTime.Now;

            DialogResult = DialogResult.Cancel;  // Close the form with a Cancel result
            Close();
        }

        public enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Canceled,
            Returned,
            Refunded,
            OnHold,
            Failed,
            AwaitingPayment
        }

        private void comboBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}