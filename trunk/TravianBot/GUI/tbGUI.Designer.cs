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
			this.getPriorityBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.travianBotDataSet = new GUI.TravianBotDataSet();
			this.labelTasksBuildingID = new System.Windows.Forms.Label();
			this.comboBoxTasksBuildingIds = new System.Windows.Forms.ComboBox();
			this.getBuildIdsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.labelTasksTask = new System.Windows.Forms.Label();
			this.comboBoxTasksList = new System.Windows.Forms.ComboBox();
			this.getTasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.labelTasksVillage = new System.Windows.Forms.Label();
			this.comboBoxTasksVillages = new System.Windows.Forms.ComboBox();
			this.dataGridViewTaksList = new System.Windows.Forms.DataGridView();
			this.tabPageFarmList = new System.Windows.Forms.TabPage();
			this.labelFarmListDescription = new System.Windows.Forms.Label();
			this.textBoxFarmListDescription = new System.Windows.Forms.TextBox();
			this.textBoxFarmListNUmberOdUnits = new System.Windows.Forms.TextBox();
			this.labelFarmListNumberOfUnits = new System.Windows.Forms.Label();
			this.labelFarmListTroopList = new System.Windows.Forms.Label();
			this.comboBoxFarmListTroopType = new System.Windows.Forms.ComboBox();
			this.textBoxFarmListTroopList = new System.Windows.Forms.TextBox();
			this.labelFarmListTroopType = new System.Windows.Forms.Label();
			this.textBoxFarmListY = new System.Windows.Forms.TextBox();
			this.textBoxFarmListX = new System.Windows.Forms.TextBox();
			this.buttonFarmListAddNewFarm = new System.Windows.Forms.Button();
			this.labelFarmListY = new System.Windows.Forms.Label();
			this.labelFarmListX = new System.Windows.Forms.Label();
			this.labelFarmListTribe = new System.Windows.Forms.Label();
			this.comboBoxFarmListTribe = new System.Windows.Forms.ComboBox();
			this.labelFarmListAttackType = new System.Windows.Forms.Label();
			this.comboBoxFarmListAttackType = new System.Windows.Forms.ComboBox();
			this.labelFarmListVillages = new System.Windows.Forms.Label();
			this.comboBoxFarmListVillages = new System.Windows.Forms.ComboBox();
			this.dataGridViewFarmList = new System.Windows.Forms.DataGridView();
			this.getTaskListForGUIBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.travianBotDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getProductionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getProductionTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetProductionTableAdapter();
			this.getTaskListForGUITableAdapter = new GUI.TravianBotDataSetTableAdapters.GetTaskListForGUITableAdapter();
			this.getVillagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getVillagesTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetVillagesTableAdapter();
			this.getTasksTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetTasksTableAdapter();
			this.getBuildIdsTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetBuildIdsTableAdapter();
			this.getPriorityTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetPriorityTableAdapter();
			this.getAttackTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getAttackTypesTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetAttackTypesTableAdapter();
			this.getTribesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getTribesTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetTribesTableAdapter();
			this.getTroopTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getTroopTypesTableAdapter = new GUI.TravianBotDataSetTableAdapters.GetTroopTypesTableAdapter();
			this.tabControl.SuspendLayout();
			this.tabPageStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuildings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResources)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduction)).BeginInit();
			this.tabPageTasks.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.getPriorityBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getBuildIdsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getTasksBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaksList)).BeginInit();
			this.tabPageFarmList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFarmList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getTaskListForGUIBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getProductionBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getVillagesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getAttackTypesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getTribesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getTroopTypesBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageStatus);
			this.tabControl.Controls.Add(this.tabPageTasks);
			this.tabControl.Controls.Add(this.tabPageFarmList);
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
			this.dataGridViewBuildings.Location = new System.Drawing.Point(510, 340);
			this.dataGridViewBuildings.Name = "dataGridViewBuildings";
			this.dataGridViewBuildings.Size = new System.Drawing.Size(513, 440);
			this.dataGridViewBuildings.TabIndex = 2;
			// 
			// dataGridViewResources
			// 
			this.dataGridViewResources.AllowUserToAddRows = false;
			this.dataGridViewResources.AllowUserToDeleteRows = false;
			this.dataGridViewResources.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridViewResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewResources.Location = new System.Drawing.Point(6, 340);
			this.dataGridViewResources.Name = "dataGridViewResources";
			this.dataGridViewResources.Size = new System.Drawing.Size(498, 440);
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
			this.dataGridViewProduction.Size = new System.Drawing.Size(1017, 328);
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
			this.buttonTasksAddNew.Location = new System.Drawing.Point(642, 611);
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
			this.labelTasksBuildLevel.Location = new System.Drawing.Point(514, 595);
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
			this.comboBoxTasksBuildLevel.Location = new System.Drawing.Point(514, 614);
			this.comboBoxTasksBuildLevel.Name = "comboBoxTasksBuildLevel";
			this.comboBoxTasksBuildLevel.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTasksBuildLevel.TabIndex = 9;
			// 
			// labelTasksPriority
			// 
			this.labelTasksPriority.AutoSize = true;
			this.labelTasksPriority.Location = new System.Drawing.Point(387, 595);
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
			this.comboBoxTasksPriority.Location = new System.Drawing.Point(387, 614);
			this.comboBoxTasksPriority.Name = "comboBoxTasksPriority";
			this.comboBoxTasksPriority.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTasksPriority.TabIndex = 7;
			this.comboBoxTasksPriority.ValueMember = "PriorityLevel";
			// 
			// getPriorityBindingSource
			// 
			this.getPriorityBindingSource.DataMember = "GetPriority";
			this.getPriorityBindingSource.DataSource = this.travianBotDataSet;
			// 
			// travianBotDataSet
			// 
			this.travianBotDataSet.DataSetName = "TravianBotDataSet";
			this.travianBotDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// labelTasksBuildingID
			// 
			this.labelTasksBuildingID.AutoSize = true;
			this.labelTasksBuildingID.Location = new System.Drawing.Point(260, 595);
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
			this.comboBoxTasksBuildingIds.Location = new System.Drawing.Point(260, 614);
			this.comboBoxTasksBuildingIds.Name = "comboBoxTasksBuildingIds";
			this.comboBoxTasksBuildingIds.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTasksBuildingIds.TabIndex = 5;
			this.comboBoxTasksBuildingIds.ValueMember = "ID";
			// 
			// getBuildIdsBindingSource
			// 
			this.getBuildIdsBindingSource.DataMember = "GetBuildIds";
			this.getBuildIdsBindingSource.DataSource = this.travianBotDataSet;
			// 
			// labelTasksTask
			// 
			this.labelTasksTask.AutoSize = true;
			this.labelTasksTask.Location = new System.Drawing.Point(133, 595);
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
			this.comboBoxTasksList.Location = new System.Drawing.Point(133, 614);
			this.comboBoxTasksList.Name = "comboBoxTasksList";
			this.comboBoxTasksList.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTasksList.TabIndex = 3;
			this.comboBoxTasksList.ValueMember = "TaskId";
			// 
			// getTasksBindingSource
			// 
			this.getTasksBindingSource.DataMember = "GetTasks";
			this.getTasksBindingSource.DataSource = this.travianBotDataSet;
			// 
			// labelTasksVillage
			// 
			this.labelTasksVillage.AutoSize = true;
			this.labelTasksVillage.Location = new System.Drawing.Point(6, 595);
			this.labelTasksVillage.Name = "labelTasksVillage";
			this.labelTasksVillage.Size = new System.Drawing.Size(38, 13);
			this.labelTasksVillage.TabIndex = 2;
			this.labelTasksVillage.Text = "Village";
			// 
			// comboBoxTasksVillages
			// 
			this.comboBoxTasksVillages.FormattingEnabled = true;
			this.comboBoxTasksVillages.Location = new System.Drawing.Point(6, 614);
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
			this.dataGridViewTaksList.Size = new System.Drawing.Size(1017, 580);
			this.dataGridViewTaksList.TabIndex = 0;
			// 
			// tabPageFarmList
			// 
			this.tabPageFarmList.Controls.Add(this.labelFarmListDescription);
			this.tabPageFarmList.Controls.Add(this.textBoxFarmListDescription);
			this.tabPageFarmList.Controls.Add(this.textBoxFarmListNUmberOdUnits);
			this.tabPageFarmList.Controls.Add(this.labelFarmListNumberOfUnits);
			this.tabPageFarmList.Controls.Add(this.labelFarmListTroopList);
			this.tabPageFarmList.Controls.Add(this.comboBoxFarmListTroopType);
			this.tabPageFarmList.Controls.Add(this.textBoxFarmListTroopList);
			this.tabPageFarmList.Controls.Add(this.labelFarmListTroopType);
			this.tabPageFarmList.Controls.Add(this.textBoxFarmListY);
			this.tabPageFarmList.Controls.Add(this.textBoxFarmListX);
			this.tabPageFarmList.Controls.Add(this.buttonFarmListAddNewFarm);
			this.tabPageFarmList.Controls.Add(this.labelFarmListY);
			this.tabPageFarmList.Controls.Add(this.labelFarmListX);
			this.tabPageFarmList.Controls.Add(this.labelFarmListTribe);
			this.tabPageFarmList.Controls.Add(this.comboBoxFarmListTribe);
			this.tabPageFarmList.Controls.Add(this.labelFarmListAttackType);
			this.tabPageFarmList.Controls.Add(this.comboBoxFarmListAttackType);
			this.tabPageFarmList.Controls.Add(this.labelFarmListVillages);
			this.tabPageFarmList.Controls.Add(this.comboBoxFarmListVillages);
			this.tabPageFarmList.Controls.Add(this.dataGridViewFarmList);
			this.tabPageFarmList.Location = new System.Drawing.Point(4, 22);
			this.tabPageFarmList.Name = "tabPageFarmList";
			this.tabPageFarmList.Size = new System.Drawing.Size(1029, 786);
			this.tabPageFarmList.TabIndex = 2;
			this.tabPageFarmList.Text = "FarmList";
			this.tabPageFarmList.UseVisualStyleBackColor = true;
			// 
			// labelFarmListDescription
			// 
			this.labelFarmListDescription.AutoSize = true;
			this.labelFarmListDescription.Location = new System.Drawing.Point(3, 675);
			this.labelFarmListDescription.Name = "labelFarmListDescription";
			this.labelFarmListDescription.Size = new System.Drawing.Size(60, 13);
			this.labelFarmListDescription.TabIndex = 32;
			this.labelFarmListDescription.Text = "Description";
			// 
			// textBoxFarmListDescription
			// 
			this.textBoxFarmListDescription.Location = new System.Drawing.Point(6, 695);
			this.textBoxFarmListDescription.Name = "textBoxFarmListDescription";
			this.textBoxFarmListDescription.Size = new System.Drawing.Size(683, 20);
			this.textBoxFarmListDescription.TabIndex = 31;
			this.textBoxFarmListDescription.Text = "Player: , Village: , Alianse: , Population:";
			// 
			// textBoxFarmListNUmberOdUnits
			// 
			this.textBoxFarmListNUmberOdUnits.Location = new System.Drawing.Point(607, 606);
			this.textBoxFarmListNUmberOdUnits.Name = "textBoxFarmListNUmberOdUnits";
			this.textBoxFarmListNUmberOdUnits.Size = new System.Drawing.Size(82, 20);
			this.textBoxFarmListNUmberOdUnits.TabIndex = 30;
			this.textBoxFarmListNUmberOdUnits.Text = "20";
			// 
			// labelFarmListNumberOfUnits
			// 
			this.labelFarmListNumberOfUnits.AutoSize = true;
			this.labelFarmListNumberOfUnits.Location = new System.Drawing.Point(604, 586);
			this.labelFarmListNumberOfUnits.Name = "labelFarmListNumberOfUnits";
			this.labelFarmListNumberOfUnits.Size = new System.Drawing.Size(85, 13);
			this.labelFarmListNumberOfUnits.TabIndex = 29;
			this.labelFarmListNumberOfUnits.Text = "Number Of Units";
			// 
			// labelFarmListTroopList
			// 
			this.labelFarmListTroopList.AutoSize = true;
			this.labelFarmListTroopList.Location = new System.Drawing.Point(3, 629);
			this.labelFarmListTroopList.Name = "labelFarmListTroopList";
			this.labelFarmListTroopList.Size = new System.Drawing.Size(51, 13);
			this.labelFarmListTroopList.TabIndex = 28;
			this.labelFarmListTroopList.Text = "TroopList";
			// 
			// comboBoxFarmListTroopType
			// 
			this.comboBoxFarmListTroopType.DataSource = this.getTroopTypesBindingSource;
			this.comboBoxFarmListTroopType.DisplayMember = "TroopName";
			this.comboBoxFarmListTroopType.FormattingEnabled = true;
			this.comboBoxFarmListTroopType.Location = new System.Drawing.Point(480, 605);
			this.comboBoxFarmListTroopType.Name = "comboBoxFarmListTroopType";
			this.comboBoxFarmListTroopType.Size = new System.Drawing.Size(121, 21);
			this.comboBoxFarmListTroopType.TabIndex = 27;
			this.comboBoxFarmListTroopType.ValueMember = "TroopId";
			// 
			// textBoxFarmListTroopList
			// 
			this.textBoxFarmListTroopList.Location = new System.Drawing.Point(6, 649);
			this.textBoxFarmListTroopList.Name = "textBoxFarmListTroopList";
			this.textBoxFarmListTroopList.Size = new System.Drawing.Size(683, 20);
			this.textBoxFarmListTroopList.TabIndex = 26;
			this.textBoxFarmListTroopList.Text = "t1=20&t2=0&t3=0&t4=374&t5=0&t6=0&t7=0&t8=0&t9=0&t10=0&t11=0";
			// 
			// labelFarmListTroopType
			// 
			this.labelFarmListTroopType.AutoSize = true;
			this.labelFarmListTroopType.Location = new System.Drawing.Point(477, 586);
			this.labelFarmListTroopType.Name = "labelFarmListTroopType";
			this.labelFarmListTroopType.Size = new System.Drawing.Size(59, 13);
			this.labelFarmListTroopType.TabIndex = 25;
			this.labelFarmListTroopType.Text = "TroopType";
			// 
			// textBoxFarmListY
			// 
			this.textBoxFarmListY.Location = new System.Drawing.Point(434, 606);
			this.textBoxFarmListY.Name = "textBoxFarmListY";
			this.textBoxFarmListY.Size = new System.Drawing.Size(40, 20);
			this.textBoxFarmListY.TabIndex = 24;
			this.textBoxFarmListY.Text = "0";
			// 
			// textBoxFarmListX
			// 
			this.textBoxFarmListX.Location = new System.Drawing.Point(387, 606);
			this.textBoxFarmListX.Name = "textBoxFarmListX";
			this.textBoxFarmListX.Size = new System.Drawing.Size(40, 20);
			this.textBoxFarmListX.TabIndex = 23;
			this.textBoxFarmListX.Text = "0";
			// 
			// buttonFarmListAddNewFarm
			// 
			this.buttonFarmListAddNewFarm.Location = new System.Drawing.Point(695, 692);
			this.buttonFarmListAddNewFarm.Name = "buttonFarmListAddNewFarm";
			this.buttonFarmListAddNewFarm.Size = new System.Drawing.Size(75, 23);
			this.buttonFarmListAddNewFarm.TabIndex = 22;
			this.buttonFarmListAddNewFarm.Text = "Add Farm";
			this.buttonFarmListAddNewFarm.UseVisualStyleBackColor = true;
			this.buttonFarmListAddNewFarm.Click += new System.EventHandler(this.buttonFarmListAddNewFarm_Click);
			// 
			// labelFarmListY
			// 
			this.labelFarmListY.AutoSize = true;
			this.labelFarmListY.Location = new System.Drawing.Point(431, 586);
			this.labelFarmListY.Name = "labelFarmListY";
			this.labelFarmListY.Size = new System.Drawing.Size(26, 13);
			this.labelFarmListY.TabIndex = 21;
			this.labelFarmListY.Text = "( Y )";
			// 
			// labelFarmListX
			// 
			this.labelFarmListX.AutoSize = true;
			this.labelFarmListX.Location = new System.Drawing.Point(384, 586);
			this.labelFarmListX.Name = "labelFarmListX";
			this.labelFarmListX.Size = new System.Drawing.Size(26, 13);
			this.labelFarmListX.TabIndex = 19;
			this.labelFarmListX.Text = "( X )";
			// 
			// labelFarmListTribe
			// 
			this.labelFarmListTribe.AutoSize = true;
			this.labelFarmListTribe.Location = new System.Drawing.Point(257, 586);
			this.labelFarmListTribe.Name = "labelFarmListTribe";
			this.labelFarmListTribe.Size = new System.Drawing.Size(31, 13);
			this.labelFarmListTribe.TabIndex = 17;
			this.labelFarmListTribe.Text = "Tribe";
			// 
			// comboBoxFarmListTribe
			// 
			this.comboBoxFarmListTribe.DataSource = this.getTribesBindingSource;
			this.comboBoxFarmListTribe.DisplayMember = "TribeName";
			this.comboBoxFarmListTribe.FormattingEnabled = true;
			this.comboBoxFarmListTribe.Location = new System.Drawing.Point(257, 605);
			this.comboBoxFarmListTribe.Name = "comboBoxFarmListTribe";
			this.comboBoxFarmListTribe.Size = new System.Drawing.Size(121, 21);
			this.comboBoxFarmListTribe.TabIndex = 16;
			this.comboBoxFarmListTribe.ValueMember = "TribeId";
			// 
			// labelFarmListAttackType
			// 
			this.labelFarmListAttackType.AutoSize = true;
			this.labelFarmListAttackType.Location = new System.Drawing.Point(130, 586);
			this.labelFarmListAttackType.Name = "labelFarmListAttackType";
			this.labelFarmListAttackType.Size = new System.Drawing.Size(65, 13);
			this.labelFarmListAttackType.TabIndex = 15;
			this.labelFarmListAttackType.Text = "Attack Type";
			// 
			// comboBoxFarmListAttackType
			// 
			this.comboBoxFarmListAttackType.DataSource = this.getAttackTypesBindingSource;
			this.comboBoxFarmListAttackType.DisplayMember = "AttackName";
			this.comboBoxFarmListAttackType.FormattingEnabled = true;
			this.comboBoxFarmListAttackType.Location = new System.Drawing.Point(130, 605);
			this.comboBoxFarmListAttackType.Name = "comboBoxFarmListAttackType";
			this.comboBoxFarmListAttackType.Size = new System.Drawing.Size(121, 21);
			this.comboBoxFarmListAttackType.TabIndex = 14;
			this.comboBoxFarmListAttackType.ValueMember = "AttackId";
			// 
			// labelFarmListVillages
			// 
			this.labelFarmListVillages.AutoSize = true;
			this.labelFarmListVillages.Location = new System.Drawing.Point(3, 586);
			this.labelFarmListVillages.Name = "labelFarmListVillages";
			this.labelFarmListVillages.Size = new System.Drawing.Size(38, 13);
			this.labelFarmListVillages.TabIndex = 13;
			this.labelFarmListVillages.Text = "Village";
			// 
			// comboBoxFarmListVillages
			// 
			this.comboBoxFarmListVillages.FormattingEnabled = true;
			this.comboBoxFarmListVillages.Location = new System.Drawing.Point(3, 605);
			this.comboBoxFarmListVillages.Name = "comboBoxFarmListVillages";
			this.comboBoxFarmListVillages.Size = new System.Drawing.Size(121, 21);
			this.comboBoxFarmListVillages.TabIndex = 12;
			// 
			// dataGridViewFarmList
			// 
			this.dataGridViewFarmList.AllowUserToAddRows = false;
			this.dataGridViewFarmList.AllowUserToDeleteRows = false;
			this.dataGridViewFarmList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewFarmList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridViewFarmList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewFarmList.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewFarmList.Name = "dataGridViewFarmList";
			this.dataGridViewFarmList.Size = new System.Drawing.Size(1017, 580);
			this.dataGridViewFarmList.TabIndex = 0;
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
			// getTasksTableAdapter
			// 
			this.getTasksTableAdapter.ClearBeforeFill = true;
			// 
			// getBuildIdsTableAdapter
			// 
			this.getBuildIdsTableAdapter.ClearBeforeFill = true;
			// 
			// getPriorityTableAdapter
			// 
			this.getPriorityTableAdapter.ClearBeforeFill = true;
			// 
			// getAttackTypesBindingSource
			// 
			this.getAttackTypesBindingSource.DataMember = "GetAttackTypes";
			this.getAttackTypesBindingSource.DataSource = this.travianBotDataSet;
			// 
			// getAttackTypesTableAdapter
			// 
			this.getAttackTypesTableAdapter.ClearBeforeFill = true;
			// 
			// getTribesBindingSource
			// 
			this.getTribesBindingSource.DataMember = "GetTribes";
			this.getTribesBindingSource.DataSource = this.travianBotDataSet;
			// 
			// getTribesTableAdapter
			// 
			this.getTribesTableAdapter.ClearBeforeFill = true;
			// 
			// getTroopTypesBindingSource
			// 
			this.getTroopTypesBindingSource.DataMember = "GetTroopTypes";
			this.getTroopTypesBindingSource.DataSource = this.travianBotDataSet;
			// 
			// getTroopTypesTableAdapter
			// 
			this.getTroopTypesTableAdapter.ClearBeforeFill = true;
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
			((System.ComponentModel.ISupportInitialize)(this.getPriorityBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getBuildIdsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getTasksBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaksList)).EndInit();
			this.tabPageFarmList.ResumeLayout(false);
			this.tabPageFarmList.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFarmList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getTaskListForGUIBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.travianBotDataSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getProductionBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getVillagesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getAttackTypesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getTribesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getTroopTypesBindingSource)).EndInit();
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
		private System.Windows.Forms.TabPage tabPageFarmList;
		private System.Windows.Forms.DataGridView dataGridViewFarmList;
		private System.Windows.Forms.Button buttonFarmListAddNewFarm;
		private System.Windows.Forms.Label labelFarmListY;
		private System.Windows.Forms.Label labelFarmListX;
		private System.Windows.Forms.Label labelFarmListTribe;
		private System.Windows.Forms.ComboBox comboBoxFarmListTribe;
		private System.Windows.Forms.Label labelFarmListAttackType;
		private System.Windows.Forms.ComboBox comboBoxFarmListAttackType;
		private System.Windows.Forms.Label labelFarmListVillages;
		private System.Windows.Forms.ComboBox comboBoxFarmListVillages;
		private System.Windows.Forms.ComboBox comboBoxFarmListTroopType;
		private System.Windows.Forms.TextBox textBoxFarmListTroopList;
		private System.Windows.Forms.Label labelFarmListTroopType;
		private System.Windows.Forms.TextBox textBoxFarmListY;
		private System.Windows.Forms.TextBox textBoxFarmListX;
		private System.Windows.Forms.Label labelFarmListTroopList;
		private System.Windows.Forms.TextBox textBoxFarmListNUmberOdUnits;
		private System.Windows.Forms.Label labelFarmListNumberOfUnits;
		private System.Windows.Forms.Label labelFarmListDescription;
		private System.Windows.Forms.TextBox textBoxFarmListDescription;
		private System.Windows.Forms.BindingSource getAttackTypesBindingSource;
		private GUI.TravianBotDataSetTableAdapters.GetAttackTypesTableAdapter getAttackTypesTableAdapter;
		private System.Windows.Forms.BindingSource getTribesBindingSource;
		private GUI.TravianBotDataSetTableAdapters.GetTribesTableAdapter getTribesTableAdapter;
		private System.Windows.Forms.BindingSource getTroopTypesBindingSource;
		private GUI.TravianBotDataSetTableAdapters.GetTroopTypesTableAdapter getTroopTypesTableAdapter;
    }
}

