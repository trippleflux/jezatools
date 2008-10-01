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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageStatus = new System.Windows.Forms.TabPage();
			this.dataGridViewBuildings = new System.Windows.Forms.DataGridView();
			this.dataGridViewResources = new System.Windows.Forms.DataGridView();
			this.dataGridViewProduction = new System.Windows.Forms.DataGridView();
			this.tabPageTasks = new System.Windows.Forms.TabPage();
			this.buttonTasksAddNew = new System.Windows.Forms.Button();
			this.labelTasksBuildLevel = new System.Windows.Forms.Label();
			this.comboBoxTasksBuildLevel = new System.Windows.Forms.ComboBox();
			this.labelTasksPriority = new System.Windows.Forms.Label();
			this.comboBoxTasksPriority = new System.Windows.Forms.ComboBox();
			this.labelTasksBuildingID = new System.Windows.Forms.Label();
			this.comboBoxTasksBuildingIds = new System.Windows.Forms.ComboBox();
			this.labelTasksTask = new System.Windows.Forms.Label();
			this.comboBoxTasksList = new System.Windows.Forms.ComboBox();
			this.labelTasksVillage = new System.Windows.Forms.Label();
			this.comboBoxTasksVillages = new System.Windows.Forms.ComboBox();
			this.dataGridViewTaksList = new System.Windows.Forms.DataGridView();
			this.getTaskListForGUIBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.travianBotDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.travianBotDataSet = new GUI.TravianBotDataSet();
			this.getProductionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getProductionTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetProductionTableAdapter();
			this.getTaskListForGUITableAdapter = new GUI.TravianBotDataSetTableAdapters.GetTaskListForGUITableAdapter();
			this.getVillagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getVillagesTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetVillagesTableAdapter();
			this.getTasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getTasksTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetTasksTableAdapter();
			this.getBuildIdsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getBuildIdsTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetBuildIdsTableAdapter();
			this.getPriorityBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getPriorityTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetPriorityTableAdapter();
			this.tabControl.SuspendLayout();
			this.tabPageStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuildings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResources)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduction)).BeginInit();
			this.tabPageTasks.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaksList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getTaskListForGUIBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getProductionBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getVillagesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getTasksBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getBuildIdsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getPriorityBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageStatus);
			this.tabControl.Controls.Add(this.tabPageTasks);
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1037, 812);
			this.tabControl.TabIndex = 0;
			this.tabControl.Click += new System.EventHandler(this.tabControl_Click);
			// 
			// tabPageStatus
			// 
			this.tabPageStatus.Controls.Add(this.dataGridViewBuildings);
			this.tabPageStatus.Controls.Add(this.dataGridViewResources);
			this.tabPageStatus.Controls.Add(this.dataGridViewProduction);
			this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
			this.tabPageStatus.Name = "tabPageStatus";
			this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStatus.Size = new System.Drawing.Size(1029, 786);
			this.tabPageStatus.TabIndex = 0;
			this.tabPageStatus.Text = "Status";
			this.tabPageStatus.UseVisualStyleBackColor = true;
			// 
			// dataGridViewBuildings
			// 
			this.dataGridViewBuildings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewBuildings.Location = new System.Drawing.Point(510, 377);
			this.dataGridViewBuildings.Name = "dataGridViewBuildings";
			this.dataGridViewBuildings.Size = new System.Drawing.Size(513, 403);
			this.dataGridViewBuildings.TabIndex = 2;
			// 
			// dataGridViewResources
			// 
			this.dataGridViewResources.AllowUserToAddRows = false;
			this.dataGridViewResources.AllowUserToDeleteRows = false;
			this.dataGridViewResources.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridViewResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewResources.Location = new System.Drawing.Point(6, 377);
			this.dataGridViewResources.Name = "dataGridViewResources";
			this.dataGridViewResources.Size = new System.Drawing.Size(498, 403);
			this.dataGridViewResources.TabIndex = 1;
			// 
			// dataGridViewProduction
			// 
			this.dataGridViewProduction.AllowUserToAddRows = false;
			this.dataGridViewProduction.AllowUserToDeleteRows = false;
			this.dataGridViewProduction.AllowUserToResizeColumns = false;
			this.dataGridViewProduction.AllowUserToResizeRows = false;
			this.dataGridViewProduction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dataGridViewProduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewProduction.Location = new System.Drawing.Point(6, 6);
			this.dataGridViewProduction.Name = "dataGridViewProduction";
			this.dataGridViewProduction.ReadOnly = true;
			this.dataGridViewProduction.Size = new System.Drawing.Size(1017, 365);
			this.dataGridViewProduction.TabIndex = 0;
			this.dataGridViewProduction.Click += new System.EventHandler(this.dataGridViewProduction_Click);
			// 
			// tabPageTasks
			// 
			this.tabPageTasks.AutoScroll = true;
			this.tabPageTasks.Controls.Add(this.buttonTasksAddNew);
			this.tabPageTasks.Controls.Add(this.labelTasksBuildLevel);
			this.tabPageTasks.Controls.Add(this.comboBoxTasksBuildLevel);
			this.tabPageTasks.Controls.Add(this.labelTasksPriority);
			this.tabPageTasks.Controls.Add(this.comboBoxTasksPriority);
			this.tabPageTasks.Controls.Add(this.labelTasksBuildingID);
			this.tabPageTasks.Controls.Add(this.comboBoxTasksBuildingIds);
			this.tabPageTasks.Controls.Add(this.labelTasksTask);
			this.tabPageTasks.Controls.Add(this.comboBoxTasksList);
			this.tabPageTasks.Controls.Add(this.labelTasksVillage);
			this.tabPageTasks.Controls.Add(this.comboBoxTasksVillages);
			this.tabPageTasks.Controls.Add(this.dataGridViewTaksList);
			this.tabPageTasks.Location = new System.Drawing.Point(4, 22);
			this.tabPageTasks.Name = "tabPageTasks";
			this.tabPageTasks.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTasks.Size = new System.Drawing.Size(1029, 786);
			this.tabPageTasks.TabIndex = 1;
			this.tabPageTasks.Text = "Tasks";
			this.tabPageTasks.UseVisualStyleBackColor = true;
			// 
			// buttonTasksAddNew
			// 
			this.buttonTasksAddNew.Location = new System.Drawing.Point(642, 397);
			this.buttonTasksAddNew.Name = "buttonTasksAddNew";
			this.buttonTasksAddNew.Size = new System.Drawing.Size(75, 23);
			this.buttonTasksAddNew.TabIndex = 11;
			this.buttonTasksAddNew.Text = "Add Task";
			this.buttonTasksAddNew.UseVisualStyleBackColor = true;
			this.buttonTasksAddNew.Click += new System.EventHandler(this.buttonTasksAddNew_Click);
			// 
			// labelTasksBuildLevel
			// 
			this.labelTasksBuildLevel.AutoSize = true;
			this.labelTasksBuildLevel.Location = new System.Drawing.Point(514, 381);
			this.labelTasksBuildLevel.Name = "labelTasksBuildLevel";
			this.labelTasksBuildLevel.Size = new System.Drawing.Size(59, 13);
			this.labelTasksBuildLevel.TabIndex = 10;
			this.labelTasksBuildLevel.Text = "Build Level";
			// 
			// comboBoxTasksBuildLevel
			// 
			this.comboBoxTasksBuildLevel.FormattingEnabled = true;
			this.comboBoxTasksBuildLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
			this.comboBoxTasksBuildLevel.Location = new System.Drawing.Point(514, 400);
			this.comboBoxTasksBuildLevel.Name = "comboBoxTasksBuildLevel";
			this.comboBoxTasksBuildLevel.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTasksBuildLevel.TabIndex = 9;
			// 
			// labelTasksPriority
			// 
			this.labelTasksPriority.AutoSize = true;
			this.labelTasksPriority.Location = new System.Drawing.Point(387, 381);
			this.labelTasksPriority.Name = "labelTasksPriority";
			this.labelTasksPriority.Size = new System.Drawing.Size(38, 13);
			this.labelTasksPriority.TabIndex = 8;
			this.labelTasksPriority.Text = "Priority";
			// 
			// comboBoxTasksPriority
			// 
			this.comboBoxTasksPriority.DataSource = this.getPriorityBindingSource;
			this.comboBoxTasksPriority.DisplayMember = "PriorityName";
			this.comboBoxTasksPriority.FormattingEnabled = true;
			this.comboBoxTasksPriority.Location = new System.Drawing.Point(387, 400);
			this.comboBoxTasksPriority.Name = "comboBoxTasksPriority";
			this.comboBoxTasksPriority.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTasksPriority.TabIndex = 7;
			this.comboBoxTasksPriority.ValueMember = "PriorityLevel";
			// 
			// labelTasksBuildingID
			// 
			this.labelTasksBuildingID.AutoSize = true;
			this.labelTasksBuildingID.Location = new System.Drawing.Point(260, 381);
			this.labelTasksBuildingID.Name = "labelTasksBuildingID";
			this.labelTasksBuildingID.Size = new System.Drawing.Size(55, 13);
			this.labelTasksBuildingID.TabIndex = 6;
			this.labelTasksBuildingID.Text = "BuildingID";
			// 
			// comboBoxTasksBuildingIds
			// 
			this.comboBoxTasksBuildingIds.DataSource = this.getBuildIdsBindingSource;
			this.comboBoxTasksBuildingIds.DisplayMember = "BuildIdName";
			this.comboBoxTasksBuildingIds.FormattingEnabled = true;
			this.comboBoxTasksBuildingIds.Location = new System.Drawing.Point(260, 400);
			this.comboBoxTasksBuildingIds.Name = "comboBoxTasksBuildingIds";
			this.comboBoxTasksBuildingIds.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTasksBuildingIds.TabIndex = 5;
			this.comboBoxTasksBuildingIds.ValueMember = "ID";
			// 
			// labelTasksTask
			// 
			this.labelTasksTask.AutoSize = true;
			this.labelTasksTask.Location = new System.Drawing.Point(133, 381);
			this.labelTasksTask.Name = "labelTasksTask";
			this.labelTasksTask.Size = new System.Drawing.Size(31, 13);
			this.labelTasksTask.TabIndex = 4;
			this.labelTasksTask.Text = "Task";
			// 
			// comboBoxTasksList
			// 
			this.comboBoxTasksList.DataSource = this.getTasksBindingSource;
			this.comboBoxTasksList.DisplayMember = "TaskName";
			this.comboBoxTasksList.FormattingEnabled = true;
			this.comboBoxTasksList.Location = new System.Drawing.Point(133, 400);
			this.comboBoxTasksList.Name = "comboBoxTasksList";
			this.comboBoxTasksList.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTasksList.TabIndex = 3;
			this.comboBoxTasksList.ValueMember = "TaskId";
			// 
			// labelTasksVillage
			// 
			this.labelTasksVillage.AutoSize = true;
			this.labelTasksVillage.Location = new System.Drawing.Point(6, 381);
			this.labelTasksVillage.Name = "labelTasksVillage";
			this.labelTasksVillage.Size = new System.Drawing.Size(38, 13);
			this.labelTasksVillage.TabIndex = 2;
			this.labelTasksVillage.Text = "Village";
			// 
			// comboBoxTasksVillages
			// 
			this.comboBoxTasksVillages.FormattingEnabled = true;
			this.comboBoxTasksVillages.Location = new System.Drawing.Point(6, 400);
			this.comboBoxTasksVillages.Name = "comboBoxTasksVillages";
			this.comboBoxTasksVillages.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTasksVillages.TabIndex = 1;
			// 
			// dataGridViewTaksList
			// 
			this.dataGridViewTaksList.AllowUserToAddRows = false;
			this.dataGridViewTaksList.AllowUserToDeleteRows = false;
			this.dataGridViewTaksList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTaksList.Location = new System.Drawing.Point(6, 6);
			this.dataGridViewTaksList.Name = "dataGridViewTaksList";
			this.dataGridViewTaksList.ReadOnly = true;
			this.dataGridViewTaksList.Size = new System.Drawing.Size(1017, 365);
			this.dataGridViewTaksList.TabIndex = 0;
			// 
			// getTaskListForGUIBindingSource
			// 
			this.getTaskListForGUIBindingSource.DataMember = "GetTaskListForGUI";
			this.getTaskListForGUIBindingSource.DataSource = this.travianBotDataSetBindingSource;
			// 
			// travianBotDataSetBindingSource
			// 
			this.travianBotDataSetBindingSource.DataSource = this.travianBotDataSet;
			this.travianBotDataSetBindingSource.Position = 0;
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
			// getTaskListForGUITableAdapter
			// 
			this.getTaskListForGUITableAdapter.ClearBeforeFill = true;
			// 
			// getVillagesBindingSource
			// 
			this.getVillagesBindingSource.DataMember = "GetVillages";
			this.getVillagesBindingSource.DataSource = this.travianBotDataSet;
			// 
			// getVillagesTableAdapter
			// 
			this.getVillagesTableAdapter.ClearBeforeFill = true;
			// 
			// getTasksBindingSource
			// 
			this.getTasksBindingSource.DataMember = "GetTasks";
			this.getTasksBindingSource.DataSource = this.travianBotDataSet;
			// 
			// getTasksTableAdapter
			// 
			this.getTasksTableAdapter.ClearBeforeFill = true;
			// 
			// getBuildIdsBindingSource
			// 
			this.getBuildIdsBindingSource.DataMember = "GetBuildIds";
			this.getBuildIdsBindingSource.DataSource = this.travianBotDataSet;
			// 
			// getBuildIdsTableAdapter
			// 
			this.getBuildIdsTableAdapter.ClearBeforeFill = true;
			// 
			// getPriorityBindingSource
			// 
			this.getPriorityBindingSource.DataMember = "GetPriority";
			this.getPriorityBindingSource.DataSource = this.travianBotDataSet;
			// 
			// getPriorityTableAdapter
			// 
			this.getPriorityTableAdapter.ClearBeforeFill = true;
			// 
			// tbGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1061, 836);
			this.Controls.Add(this.tabControl);
			this.Name = "tbGUI";
			this.Text = "tbGUI";
			this.Load += new System.EventHandler(this.tbGUI_Load);
			this.tabControl.ResumeLayout(false);
			this.tabPageStatus.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuildings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResources)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduction)).EndInit();
			this.tabPageTasks.ResumeLayout(false);
			this.tabPageTasks.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaksList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getTaskListForGUIBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getProductionBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getVillagesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getTasksBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getBuildIdsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getPriorityBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageStatus;
		private System.Windows.Forms.TabPage tabPageTasks;
		private System.Windows.Forms.DataGridView dataGridViewBuildings;
		private System.Windows.Forms.DataGridView dataGridViewResources;
		private System.Windows.Forms.DataGridView dataGridViewProduction;
		private System.Windows.Forms.BindingSource getProductionBindingSource;
		private TravianBotDataSet travianBotDataSet;
		private GUI.TravianBotDataSetTableAdapters.GetProductionTableAdapter getProductionTableAdapter;
		private System.Windows.Forms.DataGridView dataGridViewTaksList;
		private System.Windows.Forms.BindingSource getTaskListForGUIBindingSource;
		private System.Windows.Forms.BindingSource travianBotDataSetBindingSource;
		private GUI.TravianBotDataSetTableAdapters.GetTaskListForGUITableAdapter getTaskListForGUITableAdapter;
		private System.Windows.Forms.Button buttonTasksAddNew;
		private System.Windows.Forms.Label labelTasksBuildLevel;
		private System.Windows.Forms.ComboBox comboBoxTasksBuildLevel;
		private System.Windows.Forms.Label labelTasksPriority;
		private System.Windows.Forms.ComboBox comboBoxTasksPriority;
		private System.Windows.Forms.Label labelTasksBuildingID;
		private System.Windows.Forms.ComboBox comboBoxTasksBuildingIds;
		private System.Windows.Forms.Label labelTasksTask;
		private System.Windows.Forms.ComboBox comboBoxTasksList;
		private System.Windows.Forms.Label labelTasksVillage;
		private System.Windows.Forms.ComboBox comboBoxTasksVillages;
		private System.Windows.Forms.BindingSource getVillagesBindingSource;
		private GUI.TravianBotDataSetTableAdapters.GetVillagesTableAdapter getVillagesTableAdapter;
		private System.Windows.Forms.BindingSource getTasksBindingSource;
		private GUI.TravianBotDataSetTableAdapters.GetTasksTableAdapter getTasksTableAdapter;
		private System.Windows.Forms.BindingSource getBuildIdsBindingSource;
		private GUI.TravianBotDataSetTableAdapters.GetBuildIdsTableAdapter getBuildIdsTableAdapter;
		private System.Windows.Forms.BindingSource getPriorityBindingSource;
		private GUI.TravianBotDataSetTableAdapters.GetPriorityTableAdapter getPriorityTableAdapter;
    }
}

