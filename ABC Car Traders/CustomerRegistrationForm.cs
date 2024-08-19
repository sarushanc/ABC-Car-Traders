using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class CustomerRegistrationForm : Form
    {
        private List<Customer> customers;

        public CustomerRegistrationForm()
        {
            InitializeComponent();
            customers = new List<Customer>();
        }

        private void CustomerRegistrationForm_Load(object sender, EventArgs e)
        {
            // Initialize any data or settings here if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new Customer object
            Customer newCustomer = new Customer
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Password = txtPassword.Text
            };

            // Add the customer to the list
            customers.Add(newCustomer);

            // Optionally, save to the database if you have a database connection
            // database.AddCustomer(newCustomer);

            MessageBox.Show("Customer registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear input fields after registration
            Close();
            CustomerEntry login = new CustomerEntry();
            login.Show();
        }

        // Method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Method to clear the form fields
        private void ClearForm()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
