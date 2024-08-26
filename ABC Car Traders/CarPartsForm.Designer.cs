namespace ABC_Car_Traders
{
    partial class CarPartsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarPartsForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aDDRECORDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITRECORDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dELETERECORDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carPartsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.car_traderDataSet4 = new ABC_Car_Traders.car_traderDataSet4();
            this.carPartsTableAdapter = new ABC_Car_Traders.car_traderDataSet4TableAdapters.CarPartsTableAdapter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carPartsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car_traderDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDDRECORDToolStripMenuItem,
            this.eDITRECORDToolStripMenuItem,
            this.dELETERECORDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 100);
            // 
            // aDDRECORDToolStripMenuItem
            // 
            this.aDDRECORDToolStripMenuItem.Name = "aDDRECORDToolStripMenuItem";
            this.aDDRECORDToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.aDDRECORDToolStripMenuItem.Text = "ADD RECORD";
            this.aDDRECORDToolStripMenuItem.Click += new System.EventHandler(this.aDDRECORDToolStripMenuItem_Click);
            // 
            // eDITRECORDToolStripMenuItem
            // 
            this.eDITRECORDToolStripMenuItem.Name = "eDITRECORDToolStripMenuItem";
            this.eDITRECORDToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.eDITRECORDToolStripMenuItem.Text = "EDIT RECORD";
            this.eDITRECORDToolStripMenuItem.Click += new System.EventHandler(this.eDITRECORDToolStripMenuItem_Click_1);
            // 
            // dELETERECORDToolStripMenuItem
            // 
            this.dELETERECORDToolStripMenuItem.Name = "dELETERECORDToolStripMenuItem";
            this.dELETERECORDToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.dELETERECORDToolStripMenuItem.Text = "DELETE RECORD";
            this.dELETERECORDToolStripMenuItem.Click += new System.EventHandler(this.dELETERECORDToolStripMenuItem_Click_1);
            // 
            // carPartsBindingSource
            // 
            this.carPartsBindingSource.DataMember = "CarParts";
            this.carPartsBindingSource.DataSource = this.car_traderDataSet4;
            // 
            // car_traderDataSet4
            // 
            this.car_traderDataSet4.DataSetName = "car_traderDataSet4";
            this.car_traderDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // carPartsTableAdapter
            // 
            this.carPartsTableAdapter.ClearBeforeFill = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.textSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 1;
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(221, 11);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(442, 26);
            this.textSearch.TabIndex = 3;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.partNameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.carPartsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(800, 400);
            this.dataGridView1.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 96.174F;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // partNameDataGridViewTextBoxColumn
            // 
            this.partNameDataGridViewTextBoxColumn.DataPropertyName = "PartName";
            this.partNameDataGridViewTextBoxColumn.FillWeight = 103.9619F;
            this.partNameDataGridViewTextBoxColumn.HeaderText = "PartName";
            this.partNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.partNameDataGridViewTextBoxColumn.Name = "partNameDataGridViewTextBoxColumn";
            this.partNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.FillWeight = 99.86414F;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(743, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 44);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CarPartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CarPartsForm";
            this.Text = "Car Parts Details";
            this.Load += new System.EventHandler(this.CarPartsForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carPartsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car_traderDataSet4)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private car_traderDataSet4 car_traderDataSet4;
        private System.Windows.Forms.BindingSource carPartsBindingSource;
        private car_traderDataSet4TableAdapters.CarPartsTableAdapter carPartsTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aDDRECORDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDITRECORDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dELETERECORDToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}