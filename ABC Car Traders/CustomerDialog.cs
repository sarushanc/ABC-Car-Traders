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
    public partial class CustomerDialog : Form
    {
        public string CustomerName { get { return textName.Text; } set { textName.Text = value; } }
        public string CustomerEmail { get { return textEmail.Text; } set { textEmail.Text = value; } }
        public string CustomerPhone { get { return textPhone.Text; } set { textPhone.Text = value; } }
        public string CustomerPassword { get { return textPassword.Text; } set { textPassword.Text = value; } }

        public CustomerDialog()
        {
            InitializeComponent();
        }

        public CustomerDialog(Customer customer) : this()
        {
            CustomerName = customer.Name;
            CustomerEmail = customer.Email;
            CustomerPhone = customer.Phone;
            CustomerPassword = customer.Password;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
