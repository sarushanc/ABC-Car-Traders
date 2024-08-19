namespace ABC_Car_Traders
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCarParts = new System.Windows.Forms.Button();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonorders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(338, 66);
            this.button1.TabIndex = 0;
            this.button1.Text = "CARS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCarParts
            // 
            this.buttonCarParts.Location = new System.Drawing.Point(237, 132);
            this.buttonCarParts.Name = "buttonCarParts";
            this.buttonCarParts.Size = new System.Drawing.Size(338, 66);
            this.buttonCarParts.TabIndex = 1;
            this.buttonCarParts.Text = "CAR PARTS";
            this.buttonCarParts.UseVisualStyleBackColor = true;
            this.buttonCarParts.Click += new System.EventHandler(this.buttonCarParts_Click);
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Location = new System.Drawing.Point(237, 222);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(338, 66);
            this.buttonCustomers.TabIndex = 2;
            this.buttonCustomers.Text = "CUSTOMERS";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonorders
            // 
            this.buttonorders.Location = new System.Drawing.Point(237, 313);
            this.buttonorders.Name = "buttonorders";
            this.buttonorders.Size = new System.Drawing.Size(338, 66);
            this.buttonorders.TabIndex = 3;
            this.buttonorders.Text = "ORDERS";
            this.buttonorders.UseVisualStyleBackColor = true;
            // 
            // AdiminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonorders);
            this.Controls.Add(this.buttonCustomers);
            this.Controls.Add(this.buttonCarParts);
            this.Controls.Add(this.button1);
            this.Name = "AdiminDashboard";
            this.Text = "AdiminDashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCarParts;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonorders;
    }
}