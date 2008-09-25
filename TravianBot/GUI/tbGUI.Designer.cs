namespace GUI
{
    partial class tbGUI
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			this.travianBotDataSet = new GUI.TravianBotDataSet();
			this.getProductionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getProductionTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetProductionTableAdapter();
			this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.villageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.villageIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.warehouseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.granaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.woodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ironDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cropDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.woodPerHourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clayPerHourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ironPerHourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cropPerHourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.playerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getProductionBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(999, 812);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dataGridView3);
			this.tabPage1.Controls.Add(this.dataGridView2);
			this.tabPage1.Controls.Add(this.dataGridView1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(991, 786);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(192, 74);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.villageNameDataGridViewTextBoxColumn,
            this.villageIdDataGridViewTextBoxColumn,
            this.warehouseDataGridViewTextBoxColumn,
            this.granaryDataGridViewTextBoxColumn,
            this.woodDataGridViewTextBoxColumn,
            this.clayDataGridViewTextBoxColumn,
            this.ironDataGridViewTextBoxColumn,
            this.cropDataGridViewTextBoxColumn,
            this.woodPerHourDataGridViewTextBoxColumn,
            this.clayPerHourDataGridViewTextBoxColumn,
            this.ironPerHourDataGridViewTextBoxColumn,
            this.cropPerHourDataGridViewTextBoxColumn,
            this.playerNameDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.getProductionBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(6, 6);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(979, 365);
			this.dataGridView1.TabIndex = 0;
			// 
			// dataGridView2
			// 
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(6, 377);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.Size = new System.Drawing.Size(472, 403);
			this.dataGridView2.TabIndex = 1;
			// 
			// dataGridView3
			// 
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Location = new System.Drawing.Point(484, 377);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.Size = new System.Drawing.Size(501, 403);
			this.dataGridView3.TabIndex = 2;
			// 
			// travianBotDataSet
			// 
			this.travianBotDataSet.DataSetName = "TravianBotDataSet";
			this.travianBotDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// getProductionBindingSource
			// 
			this.getProductionBindingSource.DataMember = "GetProduction";
			this.getProductionBindingSource.DataSource = this.travianBotDataSet;
			// 
			// getProductionTableAdapter
			// 
			this.getProductionTableAdapter.ClearBeforeFill = true;
			// 
			// iDDataGridViewTextBoxColumn
			// 
			this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
			this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
			this.iDDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// villageNameDataGridViewTextBoxColumn
			// 
			this.villageNameDataGridViewTextBoxColumn.DataPropertyName = "VillageName";
			this.villageNameDataGridViewTextBoxColumn.HeaderText = "VillageName";
			this.villageNameDataGridViewTextBoxColumn.Name = "villageNameDataGridViewTextBoxColumn";
			this.villageNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// villageIdDataGridViewTextBoxColumn
			// 
			this.villageIdDataGridViewTextBoxColumn.DataPropertyName = "VillageId";
			this.villageIdDataGridViewTextBoxColumn.HeaderText = "VillageId";
			this.villageIdDataGridViewTextBoxColumn.Name = "villageIdDataGridViewTextBoxColumn";
			this.villageIdDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// warehouseDataGridViewTextBoxColumn
			// 
			this.warehouseDataGridViewTextBoxColumn.DataPropertyName = "Warehouse";
			this.warehouseDataGridViewTextBoxColumn.HeaderText = "Warehouse";
			this.warehouseDataGridViewTextBoxColumn.Name = "warehouseDataGridViewTextBoxColumn";
			this.warehouseDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// granaryDataGridViewTextBoxColumn
			// 
			this.granaryDataGridViewTextBoxColumn.DataPropertyName = "Granary";
			this.granaryDataGridViewTextBoxColumn.HeaderText = "Granary";
			this.granaryDataGridViewTextBoxColumn.Name = "granaryDataGridViewTextBoxColumn";
			this.granaryDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// woodDataGridViewTextBoxColumn
			// 
			this.woodDataGridViewTextBoxColumn.DataPropertyName = "Wood";
			this.woodDataGridViewTextBoxColumn.HeaderText = "Wood";
			this.woodDataGridViewTextBoxColumn.Name = "woodDataGridViewTextBoxColumn";
			this.woodDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// clayDataGridViewTextBoxColumn
			// 
			this.clayDataGridViewTextBoxColumn.DataPropertyName = "Clay";
			this.clayDataGridViewTextBoxColumn.HeaderText = "Clay";
			this.clayDataGridViewTextBoxColumn.Name = "clayDataGridViewTextBoxColumn";
			this.clayDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// ironDataGridViewTextBoxColumn
			// 
			this.ironDataGridViewTextBoxColumn.DataPropertyName = "Iron";
			this.ironDataGridViewTextBoxColumn.HeaderText = "Iron";
			this.ironDataGridViewTextBoxColumn.Name = "ironDataGridViewTextBoxColumn";
			this.ironDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// cropDataGridViewTextBoxColumn
			// 
			this.cropDataGridViewTextBoxColumn.DataPropertyName = "Crop";
			this.cropDataGridViewTextBoxColumn.HeaderText = "Crop";
			this.cropDataGridViewTextBoxColumn.Name = "cropDataGridViewTextBoxColumn";
			this.cropDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// woodPerHourDataGridViewTextBoxColumn
			// 
			this.woodPerHourDataGridViewTextBoxColumn.DataPropertyName = "WoodPerHour";
			this.woodPerHourDataGridViewTextBoxColumn.HeaderText = "WoodPerHour";
			this.woodPerHourDataGridViewTextBoxColumn.Name = "woodPerHourDataGridViewTextBoxColumn";
			this.woodPerHourDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// clayPerHourDataGridViewTextBoxColumn
			// 
			this.clayPerHourDataGridViewTextBoxColumn.DataPropertyName = "ClayPerHour";
			this.clayPerHourDataGridViewTextBoxColumn.HeaderText = "ClayPerHour";
			this.clayPerHourDataGridViewTextBoxColumn.Name = "clayPerHourDataGridViewTextBoxColumn";
			this.clayPerHourDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// ironPerHourDataGridViewTextBoxColumn
			// 
			this.ironPerHourDataGridViewTextBoxColumn.DataPropertyName = "IronPerHour";
			this.ironPerHourDataGridViewTextBoxColumn.HeaderText = "IronPerHour";
			this.ironPerHourDataGridViewTextBoxColumn.Name = "ironPerHourDataGridViewTextBoxColumn";
			this.ironPerHourDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// cropPerHourDataGridViewTextBoxColumn
			// 
			this.cropPerHourDataGridViewTextBoxColumn.DataPropertyName = "CropPerHour";
			this.cropPerHourDataGridViewTextBoxColumn.HeaderText = "CropPerHour";
			this.cropPerHourDataGridViewTextBoxColumn.Name = "cropPerHourDataGridViewTextBoxColumn";
			this.cropPerHourDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// playerNameDataGridViewTextBoxColumn
			// 
			this.playerNameDataGridViewTextBoxColumn.DataPropertyName = "PlayerName";
			this.playerNameDataGridViewTextBoxColumn.HeaderText = "PlayerName";
			this.playerNameDataGridViewTextBoxColumn.Name = "playerNameDataGridViewTextBoxColumn";
			this.playerNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// tbGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1023, 836);
			this.Controls.Add(this.tabControl1);
			this.Name = "tbGUI";
			this.Text = "tbBUI";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getProductionBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGridView dataGridView3;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn villageNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn villageIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn warehouseDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn granaryDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn woodDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn clayDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ironDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cropDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn woodPerHourDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn clayPerHourDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ironPerHourDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cropPerHourDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn playerNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource getProductionBindingSource;
		private TravianBotDataSet travianBotDataSet;
		private GUI.TravianBotDataSetTableAdapters.GetProductionTableAdapter getProductionTableAdapter;
    }
}

