using System;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class AdminLoginForm : Form
    {
        private Admin admin;

        public AdminLoginForm()
        {
            InitializeComponent();
            admin = new Admin { Username = "admin", Password = "password" };
        }

        private void AdminLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (admin.Login(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Login successful");
                ManageCarDetailsForm manageCarDetailsForm = new ManageCarDetailsForm();
                manageCarDetailsForm.Show();
                this.Hide(); // Hide the login form
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }
    }
}
