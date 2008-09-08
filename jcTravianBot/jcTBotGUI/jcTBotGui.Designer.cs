namespace jcTBotGUI
{
	partial class jcTBotGui
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
			this.jcTBotDataSet = new jcTBotGUI.jcTBotDataSet();
			this.villagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.villagesTableAdapter = new jcTBotGUI.jcTBotDataSetTableAdapters.VillagesTableAdapter();
			this.villageIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.villageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.warehouseCapacetyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.granaryCapacetyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.woodAvailableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clayAvailableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ironAvailableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cropAvailableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.woodProductionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clayProductionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ironProductionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cropProductionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.jcTBotDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.jcTBotDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.jcTBotDataSetResources = new jcTBotGUI.jcTBotDataSetResources();
			this.resourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.resourcesTableAdapter = new jcTBotGUI.jcTBotDataSetResourcesTableAdapters.ResourcesTableAdapter();
			this.resourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.resourceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			this.jcTBotDataSet1 = new jcTBotGUI.jcTBotDataSet1();
			this.buildingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.buildingsTableAdapter = new jcTBotGUI.jcTBotDataSet1TableAdapters.BuildingsTableAdapter();
			this.buildingIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buildingNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.villagesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSetBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSetResources)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buildingsBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.villageIdDataGridViewTextBoxColumn,
            this.villageNameDataGridViewTextBoxColumn,
            this.warehouseCapacetyDataGridViewTextBoxColumn,
            this.granaryCapacetyDataGridViewTextBoxColumn,
            this.woodAvailableDataGridViewTextBoxColumn,
            this.clayAvailableDataGridViewTextBoxColumn,
            this.ironAvailableDataGridViewTextBoxColumn,
            this.cropAvailableDataGridViewTextBoxColumn,
            this.woodProductionDataGridViewTextBoxColumn,
            this.clayProductionDataGridViewTextBoxColumn,
            this.ironProductionDataGridViewTextBoxColumn,
            this.cropProductionDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.villagesBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(779, 873);
			this.dataGridView1.TabIndex = 0;
			// 
			// jcTBotDataSet
			// 
			this.jcTBotDataSet.DataSetName = "jcTBotDataSet";
			this.jcTBotDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// villagesBindingSource
			// 
			this.villagesBindingSource.DataMember = "Villages";
			this.villagesBindingSource.DataSource = this.jcTBotDataSet;
			// 
			// villagesTableAdapter
			// 
			this.villagesTableAdapter.ClearBeforeFill = true;
			// 
			// villageIdDataGridViewTextBoxColumn
			// 
			this.villageIdDataGridViewTextBoxColumn.DataPropertyName = "VillageId";
			this.villageIdDataGridViewTextBoxColumn.HeaderText = "Id";
			this.villageIdDataGridViewTextBoxColumn.Name = "villageIdDataGridViewTextBoxColumn";
			this.villageIdDataGridViewTextBoxColumn.Width = 41;
			// 
			// villageNameDataGridViewTextBoxColumn
			// 
			this.villageNameDataGridViewTextBoxColumn.DataPropertyName = "VillageName";
			this.villageNameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.villageNameDataGridViewTextBoxColumn.Name = "villageNameDataGridViewTextBoxColumn";
			this.villageNameDataGridViewTextBoxColumn.Width = 60;
			// 
			// warehouseCapacetyDataGridViewTextBoxColumn
			// 
			this.warehouseCapacetyDataGridViewTextBoxColumn.DataPropertyName = "WarehouseCapacety";
			this.warehouseCapacetyDataGridViewTextBoxColumn.HeaderText = "Warehouse";
			this.warehouseCapacetyDataGridViewTextBoxColumn.Name = "warehouseCapacetyDataGridViewTextBoxColumn";
			this.warehouseCapacetyDataGridViewTextBoxColumn.Width = 87;
			// 
			// granaryCapacetyDataGridViewTextBoxColumn
			// 
			this.granaryCapacetyDataGridViewTextBoxColumn.DataPropertyName = "GranaryCapacety";
			this.granaryCapacetyDataGridViewTextBoxColumn.HeaderText = "Granary";
			this.granaryCapacetyDataGridViewTextBoxColumn.Name = "granaryCapacetyDataGridViewTextBoxColumn";
			this.granaryCapacetyDataGridViewTextBoxColumn.Width = 69;
			// 
			// woodAvailableDataGridViewTextBoxColumn
			// 
			this.woodAvailableDataGridViewTextBoxColumn.DataPropertyName = "WoodAvailable";
			this.woodAvailableDataGridViewTextBoxColumn.HeaderText = "Wood";
			this.woodAvailableDataGridViewTextBoxColumn.Name = "woodAvailableDataGridViewTextBoxColumn";
			this.woodAvailableDataGridViewTextBoxColumn.Width = 61;
			// 
			// clayAvailableDataGridViewTextBoxColumn
			// 
			this.clayAvailableDataGridViewTextBoxColumn.DataPropertyName = "ClayAvailable";
			this.clayAvailableDataGridViewTextBoxColumn.HeaderText = "Clay";
			this.clayAvailableDataGridViewTextBoxColumn.Name = "clayAvailableDataGridViewTextBoxColumn";
			this.clayAvailableDataGridViewTextBoxColumn.Width = 52;
			// 
			// ironAvailableDataGridViewTextBoxColumn
			// 
			this.ironAvailableDataGridViewTextBoxColumn.DataPropertyName = "IronAvailable";
			this.ironAvailableDataGridViewTextBoxColumn.HeaderText = "Iron";
			this.ironAvailableDataGridViewTextBoxColumn.Name = "ironAvailableDataGridViewTextBoxColumn";
			this.ironAvailableDataGridViewTextBoxColumn.Width = 50;
			// 
			// cropAvailableDataGridViewTextBoxColumn
			// 
			this.cropAvailableDataGridViewTextBoxColumn.DataPropertyName = "CropAvailable";
			this.cropAvailableDataGridViewTextBoxColumn.HeaderText = "Crop";
			this.cropAvailableDataGridViewTextBoxColumn.Name = "cropAvailableDataGridViewTextBoxColumn";
			this.cropAvailableDataGridViewTextBoxColumn.Width = 54;
			// 
			// woodProductionDataGridViewTextBoxColumn
			// 
			this.woodProductionDataGridViewTextBoxColumn.DataPropertyName = "WoodProduction";
			this.woodProductionDataGridViewTextBoxColumn.HeaderText = "Wood/h";
			this.woodProductionDataGridViewTextBoxColumn.Name = "woodProductionDataGridViewTextBoxColumn";
			this.woodProductionDataGridViewTextBoxColumn.Width = 72;
			// 
			// clayProductionDataGridViewTextBoxColumn
			// 
			this.clayProductionDataGridViewTextBoxColumn.DataPropertyName = "ClayProduction";
			this.clayProductionDataGridViewTextBoxColumn.HeaderText = "Clay/h";
			this.clayProductionDataGridViewTextBoxColumn.Name = "clayProductionDataGridViewTextBoxColumn";
			this.clayProductionDataGridViewTextBoxColumn.Width = 63;
			// 
			// ironProductionDataGridViewTextBoxColumn
			// 
			this.ironProductionDataGridViewTextBoxColumn.DataPropertyName = "IronProduction";
			this.ironProductionDataGridViewTextBoxColumn.HeaderText = "Iron/h";
			this.ironProductionDataGridViewTextBoxColumn.Name = "ironProductionDataGridViewTextBoxColumn";
			this.ironProductionDataGridViewTextBoxColumn.Width = 61;
			// 
			// cropProductionDataGridViewTextBoxColumn
			// 
			this.cropProductionDataGridViewTextBoxColumn.DataPropertyName = "CropProduction";
			this.cropProductionDataGridViewTextBoxColumn.HeaderText = "Crop/h";
			this.cropProductionDataGridViewTextBoxColumn.Name = "cropProductionDataGridViewTextBoxColumn";
			this.cropProductionDataGridViewTextBoxColumn.Width = 65;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.AutoGenerateColumns = false;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resourceIdDataGridViewTextBoxColumn,
            this.resourceNameDataGridViewTextBoxColumn});
			this.dataGridView2.DataSource = this.resourcesBindingSource;
			this.dataGridView2.Location = new System.Drawing.Point(798, 13);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.Size = new System.Drawing.Size(335, 433);
			this.dataGridView2.TabIndex = 1;
			// 
			// jcTBotDataSetBindingSource
			// 
			this.jcTBotDataSetBindingSource.DataSource = this.jcTBotDataSet;
			this.jcTBotDataSetBindingSource.Position = 0;
			// 
			// jcTBotDataSetBindingSource1
			// 
			this.jcTBotDataSetBindingSource1.DataSource = this.jcTBotDataSet;
			this.jcTBotDataSetBindingSource1.Position = 0;
			// 
			// jcTBotDataSetResources
			// 
			this.jcTBotDataSetResources.DataSetName = "jcTBotDataSetResources";
			this.jcTBotDataSetResources.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// resourcesBindingSource
			// 
			this.resourcesBindingSource.DataMember = "Resources";
			this.resourcesBindingSource.DataSource = this.jcTBotDataSetResources;
			// 
			// resourcesTableAdapter
			// 
			this.resourcesTableAdapter.ClearBeforeFill = true;
			// 
			// resourceIdDataGridViewTextBoxColumn
			// 
			this.resourceIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceId";
			this.resourceIdDataGridViewTextBoxColumn.HeaderText = "Id";
			this.resourceIdDataGridViewTextBoxColumn.Name = "resourceIdDataGridViewTextBoxColumn";
			this.resourceIdDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// resourceNameDataGridViewTextBoxColumn
			// 
			this.resourceNameDataGridViewTextBoxColumn.DataPropertyName = "ResourceName";
			this.resourceNameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.resourceNameDataGridViewTextBoxColumn.Name = "resourceNameDataGridViewTextBoxColumn";
			this.resourceNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// dataGridView3
			// 
			this.dataGridView3.AllowUserToAddRows = false;
			this.dataGridView3.AllowUserToDeleteRows = false;
			this.dataGridView3.AutoGenerateColumns = false;
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buildingIdDataGridViewTextBoxColumn,
            this.buildingNameDataGridViewTextBoxColumn});
			this.dataGridView3.DataSource = this.buildingsBindingSource;
			this.dataGridView3.Location = new System.Drawing.Point(798, 452);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.ReadOnly = true;
			this.dataGridView3.Size = new System.Drawing.Size(335, 433);
			this.dataGridView3.TabIndex = 2;
			// 
			// jcTBotDataSet1
			// 
			this.jcTBotDataSet1.DataSetName = "jcTBotDataSet1";
			this.jcTBotDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// buildingsBindingSource
			// 
			this.buildingsBindingSource.DataMember = "Buildings";
			this.buildingsBindingSource.DataSource = this.jcTBotDataSet1;
			// 
			// buildingsTableAdapter
			// 
			this.buildingsTableAdapter.ClearBeforeFill = true;
			// 
			// buildingIdDataGridViewTextBoxColumn
			// 
			this.buildingIdDataGridViewTextBoxColumn.DataPropertyName = "BuildingId";
			this.buildingIdDataGridViewTextBoxColumn.HeaderText = "Id";
			this.buildingIdDataGridViewTextBoxColumn.Name = "buildingIdDataGridViewTextBoxColumn";
			this.buildingIdDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// buildingNameDataGridViewTextBoxColumn
			// 
			this.buildingNameDataGridViewTextBoxColumn.DataPropertyName = "BuildingName";
			this.buildingNameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.buildingNameDataGridViewTextBoxColumn.Name = "buildingNameDataGridViewTextBoxColumn";
			this.buildingNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// jcTBotGui
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1145, 897);
			this.Controls.Add(this.dataGridView3);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.dataGridView1);
			this.Name = "jcTBotGui";
			this.Text = "jcTBotGui";
			this.Load += new System.EventHandler(this.jcTBotGui_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.villagesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSetBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSetResources)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buildingsBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private jcTBotDataSet jcTBotDataSet;
		private System.Windows.Forms.BindingSource villagesBindingSource;
		private jcTBotGUI.jcTBotDataSetTableAdapters.VillagesTableAdapter villagesTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn villageIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn villageNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn warehouseCapacetyDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn granaryCapacetyDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn woodAvailableDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn clayAvailableDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ironAvailableDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cropAvailableDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn woodProductionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn clayProductionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ironProductionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cropProductionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.BindingSource jcTBotDataSetBindingSource1;
		private System.Windows.Forms.BindingSource jcTBotDataSetBindingSource;
		private jcTBotDataSetResources jcTBotDataSetResources;
		private System.Windows.Forms.BindingSource resourcesBindingSource;
		private jcTBotGUI.jcTBotDataSetResourcesTableAdapters.ResourcesTableAdapter resourcesTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn resourceNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridView dataGridView3;
		private jcTBotDataSet1 jcTBotDataSet1;
		private System.Windows.Forms.BindingSource buildingsBindingSource;
		private jcTBotGUI.jcTBotDataSet1TableAdapters.BuildingsTableAdapter buildingsTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn buildingIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn buildingNameDataGridViewTextBoxColumn;


	}
}

