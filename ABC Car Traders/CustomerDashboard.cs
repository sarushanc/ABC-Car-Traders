using System;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class CustomerDashboard : Form
    {
        private Customer customer; 

        public CustomerDashboard(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            // Load customer-specific information here if needed
            labelWelcome.Text = $"Welcome, {customer.Name}!";
        }

        // Button to view car parts
        private void buttonCarParts_Click(object sender, EventArgs e)
        {
            // Assuming there's a CarPartsForm you want to show
            CarPartsForm carPartsForm = new CarPartsForm();
            carPartsForm.Show();
        }

        // Button to view or manage orders
        private void buttonorders_Click(object sender, EventArgs e)
        {
            // Assuming there's an OrdersForm you want to show
            //OrdersForm ordersForm = new OrdersForm(customer); // Pass the customer to filter their orders
            //ordersForm.Show();
        }

        // Button 1 Click - Example: Log Out or Return to Main Menu
        private void button1_Click(object sender, EventArgs e)
        {
            // This could be a log-out button or something similar
            ManageCarDetailsForm carDetailsForm = new ManageCarDetailsForm();
            carDetailsForm.Show();
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}