namespace ABC_Car_Traders
{
    partial class ManageCarDetailsForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aDDRECORDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITRECORDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dELETERECORDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.car_traderDataSet3 = new ABC_Car_Traders.car_traderDataSet3();
            this.carsTableAdapter = new ABC_Car_Traders.car_traderDataSet3TableAdapters.CarsTableAdapter();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.makeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car_traderDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.makeDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.carsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(800, 449);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDDRECORDToolStripMenuItem,
            this.eDITRECORDToolStripMenuItem,
            this.dELETERECORDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 133);
            // 
            // aDDRECORDToolStripMenuItem
            // 
            this.aDDRECORDToolStripMenuItem.Name = "aDDRECORDToolStripMenuItem";
            this.aDDRECORDToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.aDDRECORDToolStripMenuItem.Text = "ADD RECORD";
            this.aDDRECORDToolStripMenuItem.Click += new System.EventHandler(this.aDDRECORDToolStripMenuItem_Click);
            // 
            // eDITRECORDToolStripMenuItem
            // 
            this.eDITRECORDToolStripMenuItem.Name = "eDITRECORDToolStripMenuItem";
            this.eDITRECORDToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.eDITRECORDToolStripMenuItem.Text = "EDIT RECORD";
            this.eDITRECORDToolStripMenuItem.Click += new System.EventHandler(this.eDITRECORDToolStripMenuItem_Click);
            // 
            // dELETERECORDToolStripMenuItem
            // 
            this.dELETERECORDToolStripMenuItem.Name = "dELETERECORDToolStripMenuItem";
            this.dELETERECORDToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.dELETERECORDToolStripMenuItem.Text = "DELETE RECORD";
            this.dELETERECORDToolStripMenuItem.Click += new System.EventHandler(this.dELETERECORDToolStripMenuItem_Click);
            // 
            // carsBindingSource
            // 
            this.carsBindingSource.DataMember = "Cars";
            this.carsBindingSource.DataSource = this.car_traderDataSet3;
            // 
            // car_traderDataSet3
            // 
            this.car_traderDataSet3.DataSetName = "car_traderDataSet3";
            this.car_traderDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // carsTableAdapter
            // 
            this.carsTableAdapter.ClearBeforeFill = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // makeDataGridViewTextBoxColumn
            // 
            this.makeDataGridViewTextBoxColumn.DataPropertyName = "Make";
            this.makeDataGridViewTextBoxColumn.HeaderText = "Make";
            this.makeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.makeDataGridViewTextBoxColumn.Name = "makeDataGridViewTextBoxColumn";
            this.makeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            this.modelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ManageCarDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ManageCarDetailsForm";
            this.Text = "ManageCarDetailsForm";
            this.Load += new System.EventHandler(this.ManageCarDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car_traderDataSet3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private car_traderDataSet3 car_traderDataSet3;
        private System.Windows.Forms.BindingSource carsBindingSource;
        private car_traderDataSet3TableAdapters.CarsTableAdapter carsTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aDDRECORDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDITRECORDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dELETERECORDToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn makeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    }
}