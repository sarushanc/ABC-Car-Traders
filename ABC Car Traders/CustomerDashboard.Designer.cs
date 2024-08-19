namespace ABC_Car_Traders
{
    partial class CustomerDashboard
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
            this.buttonorders = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(338, 66);
            this.button1.TabIndex = 4;
            this.button1.Text = "CARS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCarParts
            // 
            this.buttonCarParts.Location = new System.Drawing.Point(231, 147);
            this.buttonCarParts.Name = "buttonCarParts";
            this.buttonCarParts.Size = new System.Drawing.Size(338, 66);
            this.buttonCarParts.TabIndex = 5;
            this.buttonCarParts.Text = "CAR PARTS";
            this.buttonCarParts.UseVisualStyleBackColor = true;
            this.buttonCarParts.Click += new System.EventHandler(this.buttonCarParts_Click);
            // 
            // buttonorders
            // 
            this.buttonorders.Location = new System.Drawing.Point(231, 242);
            this.buttonorders.Name = "buttonorders";
            this.buttonorders.Size = new System.Drawing.Size(338, 66);
            this.buttonorders.TabIndex = 7;
            this.buttonorders.Text = "ORDERS";
            this.buttonorders.UseVisualStyleBackColor = true;
            this.buttonorders.Click += new System.EventHandler(this.buttonorders_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Location = new System.Drawing.Point(364, 391);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(78, 20);
            this.labelWelcome.TabIndex = 8;
            this.labelWelcome.Text = "Customer";
            this.labelWelcome.Click += new System.EventHandler(this.labelWelcome_Click);
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.buttonorders);
            this.Controls.Add(this.buttonCarParts);
            this.Controls.Add(this.button1);
            this.Name = "CustomerDashboard";
            this.Text = "CustomerDashboard";
            this.Load += new System.EventHandler(this.CustomerDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCarParts;
        private System.Windows.Forms.Button buttonorders;
        private System.Windows.Forms.Label labelWelcome;
    }
}