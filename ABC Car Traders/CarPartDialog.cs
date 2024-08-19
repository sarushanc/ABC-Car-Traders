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
    public partial class CarPartDialog : Form
    {
        public string PartName
        {
            get { return textPartName.Text; }
            set { textPartName.Text = value; }
        }

        public string Price
        {
            get { return textPrice.Text; }
            set { textPrice.Text = value; }
        }

        public CarPartDialog()
        {
            InitializeComponent();
        }

        public CarPartDialog(CarPart carPart) : this()
        {
            PartName = carPart.PartName;
            Price = carPart.Price.ToString();
        }

        // Load event handler for any form initialization
        private void CarPartDialog_Load(object sender, EventArgs e)
        {
            // This can be used to initialize any form settings or data
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
    }
}
