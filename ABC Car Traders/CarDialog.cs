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
    public partial class CarDialog : Form
    {
        public string make { get { return textMake.Text; } }
        public string model { get { return textModel.Text; } }
        public string price { get { return textPrice.Text; } }

        public CarDialog()
        {
            InitializeComponent();
        }

        public void SetMake(string make)
        {
            textMake.Text = make;
        }

        public void SetModel(string model)
        {
            textModel.Text = model;
        }

        public void SetPrice(string price)
        {
            textPrice.Text = price;
        }

        public CarDialog(Car car) : this()
        {
            textMake.Text = car.Make;
            textModel.Text = car.Model;
            textPrice.Text = car.Price.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CarDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
