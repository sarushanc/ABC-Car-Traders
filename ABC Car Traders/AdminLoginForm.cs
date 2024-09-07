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

            textBox2.UseSystemPasswordChar = true;
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
                AdminDashboard adminDashboardForm = new AdminDashboard();
                adminDashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
