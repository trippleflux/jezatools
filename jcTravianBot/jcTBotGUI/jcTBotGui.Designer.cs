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
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
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
			this.buildingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.buildingsTableAdapter = new jcTBotGUI.jcTBotDataSetTableAdapters.BuildingsTableAdapter();
			this.buildingsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.buildingIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buildingNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.resourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.resourcesTableAdapter = new jcTBotGUI.jcTBotDataSetTableAdapters.ResourcesTableAdapter();
			this.resourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.resourceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.villagesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buildingsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buildingsBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
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
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(779, 434);
			this.dataGridView1.TabIndex = 0;
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
			// dataGridView3
			// 
			this.dataGridView3.AllowUserToAddRows = false;
			this.dataGridView3.AllowUserToDeleteRows = false;
			this.dataGridView3.AutoGenerateColumns = false;
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buildingIdDataGridViewTextBoxColumn1,
            this.buildingNameDataGridViewTextBoxColumn1});
			this.dataGridView3.DataSource = this.buildingsBindingSource1;
			this.dataGridView3.Location = new System.Drawing.Point(798, 452);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.ReadOnly = true;
			this.dataGridView3.Size = new System.Drawing.Size(335, 433);
			this.dataGridView3.TabIndex = 2;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(12, 460);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(74, 17);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Auto Build";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 506);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(780, 379);
			this.textBox1.TabIndex = 4;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(12, 483);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(50, 17);
			this.checkBox2.TabIndex = 5;
			this.checkBox2.Text = "????";
			this.checkBox2.UseVisualStyleBackColor = true;
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
			this.villageIdDataGridViewTextBoxColumn.HeaderText = "VillageId";
			this.villageIdDataGridViewTextBoxColumn.Name = "villageIdDataGridViewTextBoxColumn";
			this.villageIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.villageIdDataGridViewTextBoxColumn.Width = 72;
			// 
			// villageNameDataGridViewTextBoxColumn
			// 
			this.villageNameDataGridViewTextBoxColumn.DataPropertyName = "VillageName";
			this.villageNameDataGridViewTextBoxColumn.HeaderText = "VillageName";
			this.villageNameDataGridViewTextBoxColumn.Name = "villageNameDataGridViewTextBoxColumn";
			this.villageNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.villageNameDataGridViewTextBoxColumn.Width = 91;
			// 
			// warehouseCapacetyDataGridViewTextBoxColumn
			// 
			this.warehouseCapacetyDataGridViewTextBoxColumn.DataPropertyName = "WarehouseCapacety";
			this.warehouseCapacetyDataGridViewTextBoxColumn.HeaderText = "WarehouseCapacety";
			this.warehouseCapacetyDataGridViewTextBoxColumn.Name = "warehouseCapacetyDataGridViewTextBoxColumn";
			this.warehouseCapacetyDataGridViewTextBoxColumn.ReadOnly = true;
			this.warehouseCapacetyDataGridViewTextBoxColumn.Width = 132;
			// 
			// granaryCapacetyDataGridViewTextBoxColumn
			// 
			this.granaryCapacetyDataGridViewTextBoxColumn.DataPropertyName = "GranaryCapacety";
			this.granaryCapacetyDataGridViewTextBoxColumn.HeaderText = "GranaryCapacety";
			this.granaryCapacetyDataGridViewTextBoxColumn.Name = "granaryCapacetyDataGridViewTextBoxColumn";
			this.granaryCapacetyDataGridViewTextBoxColumn.ReadOnly = true;
			this.granaryCapacetyDataGridViewTextBoxColumn.Width = 114;
			// 
			// woodAvailableDataGridViewTextBoxColumn
			// 
			this.woodAvailableDataGridViewTextBoxColumn.DataPropertyName = "WoodAvailable";
			this.woodAvailableDataGridViewTextBoxColumn.HeaderText = "WoodAvailable";
			this.woodAvailableDataGridViewTextBoxColumn.Name = "woodAvailableDataGridViewTextBoxColumn";
			this.woodAvailableDataGridViewTextBoxColumn.ReadOnly = true;
			this.woodAvailableDataGridViewTextBoxColumn.Width = 104;
			// 
			// clayAvailableDataGridViewTextBoxColumn
			// 
			this.clayAvailableDataGridViewTextBoxColumn.DataPropertyName = "ClayAvailable";
			this.clayAvailableDataGridViewTextBoxColumn.HeaderText = "ClayAvailable";
			this.clayAvailableDataGridViewTextBoxColumn.Name = "clayAvailableDataGridViewTextBoxColumn";
			this.clayAvailableDataGridViewTextBoxColumn.ReadOnly = true;
			this.clayAvailableDataGridViewTextBoxColumn.Width = 95;
			// 
			// ironAvailableDataGridViewTextBoxColumn
			// 
			this.ironAvailableDataGridViewTextBoxColumn.DataPropertyName = "IronAvailable";
			this.ironAvailableDataGridViewTextBoxColumn.HeaderText = "IronAvailable";
			this.ironAvailableDataGridViewTextBoxColumn.Name = "ironAvailableDataGridViewTextBoxColumn";
			this.ironAvailableDataGridViewTextBoxColumn.ReadOnly = true;
			this.ironAvailableDataGridViewTextBoxColumn.Width = 93;
			// 
			// cropAvailableDataGridViewTextBoxColumn
			// 
			this.cropAvailableDataGridViewTextBoxColumn.DataPropertyName = "CropAvailable";
			this.cropAvailableDataGridViewTextBoxColumn.HeaderText = "CropAvailable";
			this.cropAvailableDataGridViewTextBoxColumn.Name = "cropAvailableDataGridViewTextBoxColumn";
			this.cropAvailableDataGridViewTextBoxColumn.ReadOnly = true;
			this.cropAvailableDataGridViewTextBoxColumn.Width = 97;
			// 
			// woodProductionDataGridViewTextBoxColumn
			// 
			this.woodProductionDataGridViewTextBoxColumn.DataPropertyName = "WoodProduction";
			this.woodProductionDataGridViewTextBoxColumn.HeaderText = "WoodProduction";
			this.woodProductionDataGridViewTextBoxColumn.Name = "woodProductionDataGridViewTextBoxColumn";
			this.woodProductionDataGridViewTextBoxColumn.ReadOnly = true;
			this.woodProductionDataGridViewTextBoxColumn.Width = 112;
			// 
			// clayProductionDataGridViewTextBoxColumn
			// 
			this.clayProductionDataGridViewTextBoxColumn.DataPropertyName = "ClayProduction";
			this.clayProductionDataGridViewTextBoxColumn.HeaderText = "ClayProduction";
			this.clayProductionDataGridViewTextBoxColumn.Name = "clayProductionDataGridViewTextBoxColumn";
			this.clayProductionDataGridViewTextBoxColumn.ReadOnly = true;
			this.clayProductionDataGridViewTextBoxColumn.Width = 103;
			// 
			// ironProductionDataGridViewTextBoxColumn
			// 
			this.ironProductionDataGridViewTextBoxColumn.DataPropertyName = "IronProduction";
			this.ironProductionDataGridViewTextBoxColumn.HeaderText = "IronProduction";
			this.ironProductionDataGridViewTextBoxColumn.Name = "ironProductionDataGridViewTextBoxColumn";
			this.ironProductionDataGridViewTextBoxColumn.ReadOnly = true;
			this.ironProductionDataGridViewTextBoxColumn.Width = 101;
			// 
			// cropProductionDataGridViewTextBoxColumn
			// 
			this.cropProductionDataGridViewTextBoxColumn.DataPropertyName = "CropProduction";
			this.cropProductionDataGridViewTextBoxColumn.HeaderText = "CropProduction";
			this.cropProductionDataGridViewTextBoxColumn.Name = "cropProductionDataGridViewTextBoxColumn";
			this.cropProductionDataGridViewTextBoxColumn.ReadOnly = true;
			this.cropProductionDataGridViewTextBoxColumn.Width = 105;
			// 
			// buildingsBindingSource
			// 
			this.buildingsBindingSource.DataMember = "Buildings";
			this.buildingsBindingSource.DataSource = this.jcTBotDataSet;
			// 
			// buildingsTableAdapter
			// 
			this.buildingsTableAdapter.ClearBeforeFill = true;
			// 
			// buildingsBindingSource1
			// 
			this.buildingsBindingSource1.DataMember = "Buildings";
			this.buildingsBindingSource1.DataSource = this.jcTBotDataSet;
			// 
			// buildingIdDataGridViewTextBoxColumn1
			// 
			this.buildingIdDataGridViewTextBoxColumn1.DataPropertyName = "BuildingId";
			this.buildingIdDataGridViewTextBoxColumn1.HeaderText = "BuildingId";
			this.buildingIdDataGridViewTextBoxColumn1.Name = "buildingIdDataGridViewTextBoxColumn1";
			this.buildingIdDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// buildingNameDataGridViewTextBoxColumn1
			// 
			this.buildingNameDataGridViewTextBoxColumn1.DataPropertyName = "BuildingName";
			this.buildingNameDataGridViewTextBoxColumn1.HeaderText = "BuildingName";
			this.buildingNameDataGridViewTextBoxColumn1.Name = "buildingNameDataGridViewTextBoxColumn1";
			this.buildingNameDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// resourcesBindingSource
			// 
			this.resourcesBindingSource.DataMember = "Resources";
			this.resourcesBindingSource.DataSource = this.jcTBotDataSet;
			// 
			// resourcesTableAdapter
			// 
			this.resourcesTableAdapter.ClearBeforeFill = true;
			// 
			// resourceIdDataGridViewTextBoxColumn
			// 
			this.resourceIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceId";
			this.resourceIdDataGridViewTextBoxColumn.HeaderText = "ResourceId";
			this.resourceIdDataGridViewTextBoxColumn.Name = "resourceIdDataGridViewTextBoxColumn";
			this.resourceIdDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// resourceNameDataGridViewTextBoxColumn
			// 
			this.resourceNameDataGridViewTextBoxColumn.DataPropertyName = "ResourceName";
			this.resourceNameDataGridViewTextBoxColumn.HeaderText = "ResourceName";
			this.resourceNameDataGridViewTextBoxColumn.Name = "resourceNameDataGridViewTextBoxColumn";
			this.resourceNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// jcTBotGui
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1145, 897);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.dataGridView3);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.dataGridView1);
			this.Name = "jcTBotGui";
			this.Text = "jcTBotGui";
			this.Load += new System.EventHandler(this.jcTBotGui_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.villagesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buildingsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buildingsBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridView dataGridView3;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox checkBox2;
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
		private System.Windows.Forms.BindingSource buildingsBindingSource;
		private jcTBotGUI.jcTBotDataSetTableAdapters.BuildingsTableAdapter buildingsTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn buildingIdDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn buildingNameDataGridViewTextBoxColumn1;
		private System.Windows.Forms.BindingSource buildingsBindingSource1;
		private System.Windows.Forms.BindingSource resourcesBindingSource;
		private jcTBotGUI.jcTBotDataSetTableAdapters.ResourcesTableAdapter resourcesTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn resourceNameDataGridViewTextBoxColumn;


	}
}

