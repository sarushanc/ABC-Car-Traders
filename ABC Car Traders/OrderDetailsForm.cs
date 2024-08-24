using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class OrderDetailsForm : Form
    {
        private Database database;
        private int orderId;

        public OrderDetailsForm(int orderId)
        {
            InitializeComponent();
            database = new Database();
            this.orderId = orderId;

            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                // Retrieve order details from the database
                List<OrderDetailDisplay> orderDetails = database.GetOrderDetailsDisplayByOrderId(orderId);

                // Bind the data to the DataGridView
                dataGridView1.DataSource = orderDetails;

                // Optional: Set columns to be more user-friendly, if needed
                // e.g., dataGridView1.Columns["Price"].DefaultCellStyle.Format = "C2"; // Format as currency
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aDDRECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OrderDetailsDialog orderDetailsDialog = new OrderDetailsDialog())
            {
                if (orderDetailsDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var orderDetail = new OrderDetail
                        {
                            OrderId = orderId,
                            CarId = orderDetailsDialog.CarId,
                            PartId = orderDetailsDialog.PartId,
                            Quantity = orderDetailsDialog.Quantity
                        };

                        database.AddOrderDetail(orderDetail);
                        LoadOrderDetails();
                        MessageBox.Show("Order detail added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while adding the order detail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //private void eDITRECORDToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count > 0)
        //    {
        //        // Get the selected order detail's ID
        //        object cellValue = dataGridView1.SelectedRows[0].Cells["Id"].Value;

        //        if (cellValue != null && int.TryParse(cellValue.ToString(), out int orderDetailId))
        //        {
        //            OrderDetail existingDetail = database.GetOrderDetailById(orderDetailId);

        //            if (existingDetail != null)
        //            {
        //                using (OrderDetailsDialog orderDetailsDialog = new OrderDetailsDialog(
        //                    existingDetail.CarId,
        //                    existingDetail.PartId,
        //                    existingDetail.Quantity))
        //                {
        //                    if (orderDetailsDialog.ShowDialog() == DialogResult.OK)
        //                    {
        //                        try
        //                        {
        //                            // Get the updated values from the dialog
        //                            existingDetail.CarId = orderDetailsDialog.CarId;
        //                            existingDetail.PartId = orderDetailsDialog.PartId;
        //                            existingDetail.Quantity = orderDetailsDialog.Quantity;

        //                            // Update the database with the new details
        //                            database.UpdateOrderDetail(existingDetail);
        //                            LoadOrderDetails();
        //                            MessageBox.Show("Order detail updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            MessageBox.Show($"An error occurred while updating the order detail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("The selected order detail could not be found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid Order Detail ID. Please select a valid record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an order detail to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        private void dELETERECORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                object cellValue = dataGridView1.SelectedRows[0].Cells["Id"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int orderDetailId))
                {
                    var confirmResult = MessageBox.Show("Are you sure you want to delete this order detail?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            database.DeleteOrderDetail(orderDetailId);
                            LoadOrderDetails();
                            MessageBox.Show("Order detail deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting the order detail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Order Detail ID. Please select a valid record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an order detail to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle cell click events if necessary
        }
    }
}
