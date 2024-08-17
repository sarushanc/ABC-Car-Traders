using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var customer = new Customer
            {
                Id = customers.Count + 1,
                Name = txtName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };
            customers.Add(customer);
            MessageBox.Show("Registration successful");
        }
    }
}
