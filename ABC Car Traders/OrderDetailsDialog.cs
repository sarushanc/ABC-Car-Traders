using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class OrderDetailsDialog : Form
    {
        private Database database;

        public int CarId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; private set; }

        public OrderDetailsDialog()
        {
            InitializeComponent();
            database = new Database();
            InitializeDropdowns();
        }

        // Constructor to initialize dialog with existing details for editing
        public OrderDetailsDialog(int? carId, int? partId, int quantity) : this()
        {
            CarId = carId ?? 0;
            PartId = partId ?? 0;
            Quantity = quantity;

            LoadExistingDetails();
        }

        private void InitializeDropdowns()
        {
            // Populate the category dropdown with options
            comboCategory.Items.Add("Car");
            comboCategory.Items.Add("Car Part");
        }

        private void LoadExistingDetails()
        {
            // Load the appropriate category based on the existing data
            if (CarId != 0)
            {
                comboCategory.SelectedItem = "Car";
                comboCategory_SelectedIndexChanged(null, null);
                comboItem.SelectedValue = CarId;

                Car selectedCar = database.GetCarById(CarId);
                Price = selectedCar.Price;
            }
            else if (PartId != 0)
            {
                comboCategory.SelectedItem = "Car Part";
                comboCategory_SelectedIndexChanged(null, null);
                comboItem.SelectedValue = PartId;

                CarPart selectedPart = database.GetCarPartById(PartId);
                Price = selectedPart.Price;
            }

            // Set the quantity field
            textQuantity.Text = Quantity.ToString();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the items dropdown when the category changes
            comboItem.Items.Clear();

            if (comboCategory.SelectedItem.ToString() == "Car")
            {
                // Load cars into comboItem
                var cars = database.GetCars();
                comboItem.DataSource = cars;
                comboItem.DisplayMember = "Model"; // Assuming Car class has a Model property
                comboItem.ValueMember = "Id";
            }
            else if (comboCategory.SelectedItem.ToString() == "Car Part")
            {
                // Load car parts into comboItem
                var carParts = database.GetCarParts();
                comboItem.DataSource = carParts;
                comboItem.DisplayMember = "PartName"; // Assuming CarPart class has a PartName property
                comboItem.ValueMember = "Id";
            }
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the price based on the selected item
            if (comboCategory.SelectedItem.ToString() == "Car")
            {
                Car selectedCar = (Car)comboItem.SelectedItem;
                Price = selectedCar.Price;
            }
            else if (comboCategory.SelectedItem.ToString() == "Car Part")
            {
                CarPart selectedPart = (CarPart)comboItem.SelectedItem;
                Price = selectedPart.Price;
            }
        }

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {
            // Optionally, validate that quantity is a number
            if (!int.TryParse(textQuantity.Text, out _))
            {
                MessageBox.Show("Please enter a valid number for quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Validate the quantity input
            if (!int.TryParse(textQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Quantity = quantity;

            if (comboCategory.SelectedItem.ToString() == "Car")
            {
                CarId = (int)comboItem.SelectedValue;
                PartId = 0; // No part selected
            }
            else if (comboCategory.SelectedItem.ToString() == "Car Part")
            {
                PartId = (int)comboItem.SelectedValue;
                CarId = 0; // No car selected
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the form inputs
            comboCategory.SelectedIndex = -1;
            comboItem.DataSource = null;
            textQuantity.Clear();
        }
    }
}
