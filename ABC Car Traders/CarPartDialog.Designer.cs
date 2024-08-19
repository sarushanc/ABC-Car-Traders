namespace ABC_Car_Traders
{
    partial class CarPartDialog
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
            this.clearButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.textPartName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(403, 126);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(174, 32);
            this.clearButton.TabIndex = 15;
            this.clearButton.Text = "CLEAR";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(138, 126);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(174, 32);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "SAVE";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // textPrice
            // 
            this.textPrice.Location = new System.Drawing.Point(138, 78);
            this.textPrice.Name = "textPrice";
            this.textPrice.Size = new System.Drawing.Size(439, 26);
            this.textPrice.TabIndex = 13;
            // 
            // textPartName
            // 
            this.textPartName.Location = new System.Drawing.Point(138, 29);
            this.textPartName.Name = "textPartName";
            this.textPartName.Size = new System.Drawing.Size(439, 26);
            this.textPartName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Part Name";
            // 
            // CarPartDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 192);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.textPrice);
            this.Controls.Add(this.textPartName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CarPartDialog";
            this.Text = "Add / Edit Car Part";
            this.Load += new System.EventHandler(this.CarPartDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.TextBox textPartName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}