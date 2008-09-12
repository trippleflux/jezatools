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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.Login = new System.Windows.Forms.TabPage();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxServerName = new System.Windows.Forms.TextBox();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.labelUsername = new System.Windows.Forms.Label();
			this.labelServerName = new System.Windows.Forms.Label();
			this.Villages = new System.Windows.Forms.TabPage();
			this.dataGridViewBuildings = new System.Windows.Forms.DataGridView();
			this.dataGridViewResources = new System.Windows.Forms.DataGridView();
			this.dataGridViewVillages = new System.Windows.Forms.DataGridView();
			this.Attacks = new System.Windows.Forms.TabPage();
			this.Tasks = new System.Windows.Forms.TabPage();
			this.buttonAddTask = new System.Windows.Forms.Button();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBoxBuildingLevel = new System.Windows.Forms.ComboBox();
			this.dataGridViewTaskList = new System.Windows.Forms.DataGridView();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Map = new System.Windows.Forms.TabPage();
			this.Reports = new System.Windows.Forms.TabPage();
			this.Messages = new System.Windows.Forms.TabPage();
			this.Status = new System.Windows.Forms.TabPage();
			this.buttonClear = new System.Windows.Forms.Button();
			this.textBoxStatus = new System.Windows.Forms.TextBox();
			this.tabPageSendResources = new System.Windows.Forms.TabPage();
			this.jcTBotDataSet = new jcTBotGUI.jcTBotDataSet();
			this.getTaskListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getTaskListTableAdapter = new jcTBotGUI.jcTBotDataSetTableAdapters.GetTaskListTableAdapter();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.villageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.taskNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buildLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nextCheckDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.getProductionForVillagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getProductionForVillagesTableAdapter = new jcTBotGUI.jcTBotDataSetTableAdapters.GetProductionForVillagesTableAdapter();
			this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.villageNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.tabControl.SuspendLayout();
			this.Login.SuspendLayout();
			this.Villages.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuildings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResources)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewVillages)).BeginInit();
			this.Tasks.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.Status.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getTaskListBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getProductionForVillagesBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.Login);
			this.tabControl.Controls.Add(this.Villages);
			this.tabControl.Controls.Add(this.Attacks);
			this.tabControl.Controls.Add(this.Tasks);
			this.tabControl.Controls.Add(this.Map);
			this.tabControl.Controls.Add(this.Reports);
			this.tabControl.Controls.Add(this.Messages);
			this.tabControl.Controls.Add(this.Status);
			this.tabControl.Controls.Add(this.tabPageSendResources);
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(826, 624);
			this.tabControl.TabIndex = 0;
			// 
			// Login
			// 
			this.Login.Controls.Add(this.buttonConnect);
			this.Login.Controls.Add(this.labelPassword);
			this.Login.Controls.Add(this.textBoxPassword);
			this.Login.Controls.Add(this.textBoxServerName);
			this.Login.Controls.Add(this.textBoxUsername);
			this.Login.Controls.Add(this.labelUsername);
			this.Login.Controls.Add(this.labelServerName);
			this.Login.Location = new System.Drawing.Point(4, 22);
			this.Login.Name = "Login";
			this.Login.Padding = new System.Windows.Forms.Padding(3);
			this.Login.Size = new System.Drawing.Size(818, 598);
			this.Login.TabIndex = 0;
			this.Login.Text = "Login";
			this.Login.UseVisualStyleBackColor = true;
			// 
			// buttonConnect
			// 
			this.buttonConnect.Location = new System.Drawing.Point(372, 10);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(75, 23);
			this.buttonConnect.TabIndex = 5;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(24, 100);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(53, 13);
			this.labelPassword.TabIndex = 2;
			this.labelPassword.Text = "Password";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(110, 93);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(183, 20);
			this.textBoxPassword.TabIndex = 4;
			this.textBoxPassword.Text = "kepek";
			// 
			// textBoxServerName
			// 
			this.textBoxServerName.Location = new System.Drawing.Point(110, 13);
			this.textBoxServerName.Name = "textBoxServerName";
			this.textBoxServerName.Size = new System.Drawing.Size(183, 20);
			this.textBoxServerName.TabIndex = 3;
			this.textBoxServerName.Text = "http://s3.travian.si/";
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(110, 53);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(183, 20);
			this.textBoxUsername.TabIndex = 2;
			this.textBoxUsername.Text = "jezonsky";
			// 
			// labelUsername
			// 
			this.labelUsername.AutoSize = true;
			this.labelUsername.Location = new System.Drawing.Point(24, 60);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(55, 13);
			this.labelUsername.TabIndex = 1;
			this.labelUsername.Text = "Username";
			// 
			// labelServerName
			// 
			this.labelServerName.AutoSize = true;
			this.labelServerName.Location = new System.Drawing.Point(24, 20);
			this.labelServerName.Name = "labelServerName";
			this.labelServerName.Size = new System.Drawing.Size(69, 13);
			this.labelServerName.TabIndex = 0;
			this.labelServerName.Text = "Server Name";
			// 
			// Villages
			// 
			this.Villages.Controls.Add(this.dataGridViewBuildings);
			this.Villages.Controls.Add(this.dataGridViewResources);
			this.Villages.Controls.Add(this.dataGridViewVillages);
			this.Villages.Location = new System.Drawing.Point(4, 22);
			this.Villages.Name = "Villages";
			this.Villages.Padding = new System.Windows.Forms.Padding(3);
			this.Villages.Size = new System.Drawing.Size(818, 598);
			this.Villages.TabIndex = 1;
			this.Villages.Text = "Villages";
			this.Villages.UseVisualStyleBackColor = true;
			// 
			// dataGridViewBuildings
			// 
			this.dataGridViewBuildings.AllowUserToAddRows = false;
			this.dataGridViewBuildings.AllowUserToDeleteRows = false;
			this.dataGridViewBuildings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewBuildings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewBuildings.Location = new System.Drawing.Point(409, 261);
			this.dataGridViewBuildings.Name = "dataGridViewBuildings";
			this.dataGridViewBuildings.ReadOnly = true;
			this.dataGridViewBuildings.Size = new System.Drawing.Size(400, 310);
			this.dataGridViewBuildings.TabIndex = 2;
			// 
			// dataGridViewResources
			// 
			this.dataGridViewResources.AllowUserToAddRows = false;
			this.dataGridViewResources.AllowUserToDeleteRows = false;
			this.dataGridViewResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewResources.Location = new System.Drawing.Point(8, 261);
			this.dataGridViewResources.Name = "dataGridViewResources";
			this.dataGridViewResources.ReadOnly = true;
			this.dataGridViewResources.Size = new System.Drawing.Size(395, 310);
			this.dataGridViewResources.TabIndex = 1;
			// 
			// dataGridViewVillages
			// 
			this.dataGridViewVillages.AllowUserToAddRows = false;
			this.dataGridViewVillages.AllowUserToDeleteRows = false;
			this.dataGridViewVillages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewVillages.AutoGenerateColumns = false;
			this.dataGridViewVillages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewVillages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.villageNameDataGridViewTextBoxColumn1,
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
            this.cropPerHourDataGridViewTextBoxColumn});
			this.dataGridViewVillages.DataSource = this.getProductionForVillagesBindingSource;
			this.dataGridViewVillages.Location = new System.Drawing.Point(8, 8);
			this.dataGridViewVillages.Name = "dataGridViewVillages";
			this.dataGridViewVillages.ReadOnly = true;
			this.dataGridViewVillages.Size = new System.Drawing.Size(801, 247);
			this.dataGridViewVillages.TabIndex = 0;
			// 
			// Attacks
			// 
			this.Attacks.Location = new System.Drawing.Point(4, 22);
			this.Attacks.Name = "Attacks";
			this.Attacks.Size = new System.Drawing.Size(818, 598);
			this.Attacks.TabIndex = 2;
			this.Attacks.Text = "Attacks";
			this.Attacks.UseVisualStyleBackColor = true;
			// 
			// Tasks
			// 
			this.Tasks.Controls.Add(this.buttonAddTask);
			this.Tasks.Controls.Add(this.comboBox3);
			this.Tasks.Controls.Add(this.comboBox2);
			this.Tasks.Controls.Add(this.comboBoxBuildingLevel);
			this.Tasks.Controls.Add(this.dataGridViewTaskList);
			this.Tasks.Controls.Add(this.dataGridView1);
			this.Tasks.Location = new System.Drawing.Point(4, 22);
			this.Tasks.Name = "Tasks";
			this.Tasks.Size = new System.Drawing.Size(818, 598);
			this.Tasks.TabIndex = 3;
			this.Tasks.Text = "Tasks";
			this.Tasks.UseVisualStyleBackColor = true;
			// 
			// buttonAddTask
			// 
			this.buttonAddTask.Location = new System.Drawing.Point(555, 307);
			this.buttonAddTask.Name = "buttonAddTask";
			this.buttonAddTask.Size = new System.Drawing.Size(75, 23);
			this.buttonAddTask.TabIndex = 5;
			this.buttonAddTask.Text = "Add Task";
			this.buttonAddTask.UseVisualStyleBackColor = true;
			// 
			// comboBox3
			// 
			this.comboBox3.DisplayMember = "Id";
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(190, 310);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 21);
			this.comboBox3.TabIndex = 4;
			this.comboBox3.ValueMember = "Id";
			// 
			// comboBox2
			// 
			this.comboBox2.DisplayMember = "VillageId";
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(8, 310);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 3;
			this.comboBox2.ValueMember = "VillageId";
			// 
			// comboBoxBuildingLevel
			// 
			this.comboBoxBuildingLevel.AllowDrop = true;
			this.comboBoxBuildingLevel.FormattingEnabled = true;
			this.comboBoxBuildingLevel.Items.AddRange(new object[] {
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
			this.comboBoxBuildingLevel.Location = new System.Drawing.Point(379, 310);
			this.comboBoxBuildingLevel.Name = "comboBoxBuildingLevel";
			this.comboBoxBuildingLevel.Size = new System.Drawing.Size(121, 21);
			this.comboBoxBuildingLevel.TabIndex = 2;
			this.comboBoxBuildingLevel.Text = "10";
			// 
			// dataGridViewTaskList
			// 
			this.dataGridViewTaskList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewTaskList.AutoGenerateColumns = false;
			this.dataGridViewTaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTaskList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.villageNameDataGridViewTextBoxColumn,
            this.taskNameDataGridViewTextBoxColumn,
            this.buildLevelDataGridViewTextBoxColumn,
            this.nextCheckDataGridViewTextBoxColumn});
			this.dataGridViewTaskList.DataSource = this.getTaskListBindingSource;
			this.dataGridViewTaskList.Location = new System.Drawing.Point(8, 3);
			this.dataGridViewTaskList.Name = "dataGridViewTaskList";
			this.dataGridViewTaskList.Size = new System.Drawing.Size(801, 260);
			this.dataGridViewTaskList.TabIndex = 1;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(8, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(801, 260);
			this.dataGridView1.TabIndex = 0;
			// 
			// Map
			// 
			this.Map.Location = new System.Drawing.Point(4, 22);
			this.Map.Name = "Map";
			this.Map.Size = new System.Drawing.Size(818, 598);
			this.Map.TabIndex = 4;
			this.Map.Text = "Map";
			this.Map.UseVisualStyleBackColor = true;
			// 
			// Reports
			// 
			this.Reports.Location = new System.Drawing.Point(4, 22);
			this.Reports.Name = "Reports";
			this.Reports.Size = new System.Drawing.Size(818, 598);
			this.Reports.TabIndex = 5;
			this.Reports.Text = "Reports";
			this.Reports.UseVisualStyleBackColor = true;
			// 
			// Messages
			// 
			this.Messages.Location = new System.Drawing.Point(4, 22);
			this.Messages.Name = "Messages";
			this.Messages.Size = new System.Drawing.Size(818, 598);
			this.Messages.TabIndex = 6;
			this.Messages.Text = "Messages";
			this.Messages.UseVisualStyleBackColor = true;
			// 
			// Status
			// 
			this.Status.Controls.Add(this.buttonClear);
			this.Status.Controls.Add(this.textBoxStatus);
			this.Status.Location = new System.Drawing.Point(4, 22);
			this.Status.Name = "Status";
			this.Status.Size = new System.Drawing.Size(818, 598);
			this.Status.TabIndex = 7;
			this.Status.Text = "Status";
			this.Status.UseVisualStyleBackColor = true;
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(8, 6);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(124, 23);
			this.buttonClear.TabIndex = 1;
			this.buttonClear.Text = "Clear";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// textBoxStatus
			// 
			this.textBoxStatus.Location = new System.Drawing.Point(8, 35);
			this.textBoxStatus.Multiline = true;
			this.textBoxStatus.Name = "textBoxStatus";
			this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxStatus.Size = new System.Drawing.Size(801, 560);
			this.textBoxStatus.TabIndex = 0;
			// 
			// tabPageSendResources
			// 
			this.tabPageSendResources.Location = new System.Drawing.Point(4, 22);
			this.tabPageSendResources.Name = "tabPageSendResources";
			this.tabPageSendResources.Size = new System.Drawing.Size(818, 598);
			this.tabPageSendResources.TabIndex = 8;
			this.tabPageSendResources.Text = "SendResources";
			this.tabPageSendResources.UseVisualStyleBackColor = true;
			// 
			// jcTBotDataSet
			// 
			this.jcTBotDataSet.DataSetName = "jcTBotDataSet";
			this.jcTBotDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// getTaskListBindingSource
			// 
			this.getTaskListBindingSource.DataMember = "GetTaskList";
			this.getTaskListBindingSource.DataSource = this.jcTBotDataSet;
			// 
			// getTaskListTableAdapter
			// 
			this.getTaskListTableAdapter.ClearBeforeFill = true;
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// villageNameDataGridViewTextBoxColumn
			// 
			this.villageNameDataGridViewTextBoxColumn.DataPropertyName = "VillageName";
			this.villageNameDataGridViewTextBoxColumn.HeaderText = "VillageName";
			this.villageNameDataGridViewTextBoxColumn.Name = "villageNameDataGridViewTextBoxColumn";
			this.villageNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// taskNameDataGridViewTextBoxColumn
			// 
			this.taskNameDataGridViewTextBoxColumn.DataPropertyName = "TaskName";
			this.taskNameDataGridViewTextBoxColumn.HeaderText = "TaskName";
			this.taskNameDataGridViewTextBoxColumn.Name = "taskNameDataGridViewTextBoxColumn";
			this.taskNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// buildLevelDataGridViewTextBoxColumn
			// 
			this.buildLevelDataGridViewTextBoxColumn.DataPropertyName = "BuildLevel";
			this.buildLevelDataGridViewTextBoxColumn.HeaderText = "BuildLevel";
			this.buildLevelDataGridViewTextBoxColumn.Name = "buildLevelDataGridViewTextBoxColumn";
			// 
			// nextCheckDataGridViewTextBoxColumn
			// 
			this.nextCheckDataGridViewTextBoxColumn.DataPropertyName = "NextCheck";
			this.nextCheckDataGridViewTextBoxColumn.HeaderText = "NextCheck";
			this.nextCheckDataGridViewTextBoxColumn.Name = "nextCheckDataGridViewTextBoxColumn";
			// 
			// getProductionForVillagesBindingSource
			// 
			this.getProductionForVillagesBindingSource.DataMember = "GetProductionForVillages";
			this.getProductionForVillagesBindingSource.DataSource = this.jcTBotDataSet;
			// 
			// getProductionForVillagesTableAdapter
			// 
			this.getProductionForVillagesTableAdapter.ClearBeforeFill = true;
			// 
			// idDataGridViewTextBoxColumn1
			// 
			this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
			this.idDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// villageNameDataGridViewTextBoxColumn1
			// 
			this.villageNameDataGridViewTextBoxColumn1.DataPropertyName = "VillageName";
			this.villageNameDataGridViewTextBoxColumn1.HeaderText = "VillageName";
			this.villageNameDataGridViewTextBoxColumn1.Name = "villageNameDataGridViewTextBoxColumn1";
			this.villageNameDataGridViewTextBoxColumn1.ReadOnly = true;
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
			// jcTBotGui
			// 
			this.ClientSize = new System.Drawing.Size(825, 646);
			this.Controls.Add(this.tabControl);
			this.Name = "jcTBotGui";
			this.Load += new System.EventHandler(this.jcTBotGui_Load);
			this.tabControl.ResumeLayout(false);
			this.Login.ResumeLayout(false);
			this.Login.PerformLayout();
			this.Villages.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuildings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResources)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewVillages)).EndInit();
			this.Tasks.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.Status.ResumeLayout(false);
			this.Status.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.jcTBotDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getTaskListBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getProductionForVillagesBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage Login;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.Label labelServerName;
		private System.Windows.Forms.TabPage Villages;
		private System.Windows.Forms.TabPage Attacks;
		private System.Windows.Forms.TabPage Tasks;
		private System.Windows.Forms.TabPage Map;
		private System.Windows.Forms.TabPage Reports;
		private System.Windows.Forms.TabPage Messages;
		private System.Windows.Forms.TabPage Status;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.TextBox textBoxServerName;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.DataGridView dataGridViewResources;
		private System.Windows.Forms.DataGridView dataGridViewVillages;
		private System.Windows.Forms.DataGridView dataGridViewBuildings;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.TextBox textBoxStatus;
		private jcTBotDataSet jcTBotDataSet;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.TabPage tabPageSendResources;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridView dataGridViewTaskList;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBoxBuildingLevel;
		private System.Windows.Forms.Button buttonAddTask;
		private System.Windows.Forms.BindingSource getTaskListBindingSource;
		private jcTBotGUI.jcTBotDataSetTableAdapters.GetTaskListTableAdapter getTaskListTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn villageNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn taskNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn buildLevelDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nextCheckDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource getProductionForVillagesBindingSource;
		private jcTBotGUI.jcTBotDataSetTableAdapters.GetProductionForVillagesTableAdapter getProductionForVillagesTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn villageNameDataGridViewTextBoxColumn1;
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

	}
}

