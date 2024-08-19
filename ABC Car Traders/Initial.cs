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
    public partial class Initial : Form
    {
        public Initial()
        {
            InitializeComponent();
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            AdminLoginForm adminLoginFormForm = new AdminLoginForm();
            adminLoginFormForm.Show();
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            CustomerEntry loginForm = new CustomerEntry();
            loginForm.Show();
        }
    }
}
