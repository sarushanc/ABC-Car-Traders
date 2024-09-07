using System;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class CustomerEntry : Form
    {
        private Database database; // Assuming you have a Database class to handle data operations

        public CustomerEntry()
        {
            InitializeComponent();
            database = new Database();
            textPassword.UseSystemPasswordChar = true;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            CustomerRegistrationForm customerRegister = new CustomerRegistrationForm();
            customerRegister.Show();
            Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textEmail.Text;
            string password = textPassword.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Attempt to log in
            Customer customer = database.GetCustomerByEmailAndPassword(email, password);
            if (customer != null)
            {
                // Login successful, redirect to CustomerDashboard
                CustomerDashboard dashboard = new CustomerDashboard(customer); // Pass the customer object to the dashboard
                dashboard.Show();
                Close();
            }
            else
            {
                // Login failed
                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
