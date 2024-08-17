using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class ManageCarDetailsForm : Form
    {
        private Database database;

        public ManageCarDetailsForm()
        {
            InitializeComponent();
            database = new Database();
        }

        private void ManageCarDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'car_traderDataSet3.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.car_traderDataSet3.Cars);
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the data. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click events if needed
        }

        private void aDDRECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCar dialog = new AddCar();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var car = new Car
                    {
                        Make = dialog.make,
                        Model = dialog.model,
                        Price = decimal.Parse(dialog.price)
                    };
                    database.AddCar(car);
                    this.carsTableAdapter.Fill(this.car_traderDataSet3.Cars);
                    MessageBox.Show("Car added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the car. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}