#region

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Library;

#endregion

namespace GUI
{
	public partial class tbGUI : Form
	{
		private const int playerId = 9500;



		public tbGUI()
		{
			InitializeComponent();
		}



		private void FillProduction()
		{
			ServerData sd = new ServerData();
			SqlCommand command = new SqlCommand("GetProduction", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = playerId;
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet ds = new DataSet();
			adapter.Fill(ds, "Production");
			dataGridViewProduction.DataSource = ds.Tables["Production"];
		}



		private void FillTasks()
		{
			ServerData sd = new ServerData();
			SqlCommand command = new SqlCommand("GetTaskListForGUI", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = playerId;
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet ds = new DataSet();
			adapter.Fill(ds, "Tasks");
			dataGridViewTaksList.DataSource = ds.Tables["Tasks"];
		}



		private void FillVillages()
		{
			ServerData sd = new ServerData();
			SqlCommand command = new SqlCommand("GetVillages", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = playerId;
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet ds = new DataSet();
			adapter.Fill(ds, "Villages");
			comboBoxTasksVillages.DataSource = ds.Tables["Villages"];
			comboBoxTasksVillages.DisplayMember = "VillageName";
			comboBoxTasksVillages.ValueMember = "VillageId";
			comboBoxFarmListVillages.DataSource = ds.Tables["Villages"];
			comboBoxFarmListVillages.DisplayMember = "VillageName";
			comboBoxFarmListVillages.ValueMember = "VillageId";
		}



		private void FillFarmList()
		{
			ServerData sd = new ServerData();
			SqlCommand command = new SqlCommand("GetFarmListForGui", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = playerId;
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet ds = new DataSet();
			adapter.Fill(ds, "FarmList");
			dataGridViewFarmList.DataSource = ds.Tables["FarmList"];
		}



		private void tbGUI_Load
			(object sender,
			 EventArgs e)
		{
			// TODO: This line of code loads data into the 'travianBotDataSet.GetTroopTypes' table. You can move, or remove it, as needed.
			getTroopTypesTableAdapter.Fill(travianBotDataSet.GetTroopTypes);
			// TODO: This line of code loads data into the 'travianBotDataSet.GetTribes' table. You can move, or remove it, as needed.
			getTribesTableAdapter.Fill(travianBotDataSet.GetTribes);
			// TODO: This line of code loads data into the 'travianBotDataSet.GetAttackTypes' table. You can move, or remove it, as needed.
			getAttackTypesTableAdapter.Fill(travianBotDataSet.GetAttackTypes);
			// TODO: This line of code loads data into the 'travianBotDataSet.GetPriority' table. You can move, or remove it, as needed.
			getPriorityTableAdapter.Fill(travianBotDataSet.GetPriority);
			// TODO: This line of code loads data into the 'travianBotDataSet.GetBuildIds' table. You can move, or remove it, as needed.
			getBuildIdsTableAdapter.Fill(travianBotDataSet.GetBuildIds);
			// TODO: This line of code loads data into the 'travianBotDataSet.GetTasks' table. You can move, or remove it, as needed.
			getTasksTableAdapter.Fill(travianBotDataSet.GetTasks);
			FillProduction();
		}



		private void tabControl_Click
			(object sender,
			 EventArgs e)
		{
			FillProduction();
			FillTasks();
			FillVillages();
			FillFarmList();
		}



		private void buttonTasksAddNew_Click
			(object sender,
			 EventArgs e)
		{
			ServerData sd = new ServerData();
			SqlCommand command = new SqlCommand("InsertNewTask", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@TaskId", SqlDbType.Int).Value = comboBoxTasksList.SelectedValue;
			command.Parameters.Add("@VillageId", SqlDbType.Int).Value = comboBoxTasksVillages.SelectedValue;
			command.Parameters.Add("@BuildId", SqlDbType.Int).Value = comboBoxTasksBuildingIds.SelectedValue;
			command.Parameters.Add("@PriorityId", SqlDbType.Int).Value = comboBoxTasksPriority.SelectedValue;
			command.Parameters.Add("@BuildLevel", SqlDbType.Int).Value = comboBoxTasksBuildLevel.SelectedItem;
			command.Parameters.Add("@NextCheck", SqlDbType.DateTime).Value = DateTime.Now;
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = playerId;
			sd.Connection.Open();
			command.ExecuteNonQuery();
			sd.Connection.Close();
			FillTasks();
		}



		private void dataGridViewProduction_Click
			(object sender,
			 EventArgs e)
		{
			if (dataGridViewProduction.SelectedRows.Count == 1)
			{
				//dataGridViewVillages.SelectedRows[0].Cells[2].Value.ToString()
				int villageId =
					Int32.Parse(dataGridViewProduction.SelectedRows[0].Cells[2].Value.ToString().Trim());
				ServerData sd = new ServerData();
				SqlCommand command = new SqlCommand("GetResources", sd.Connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Clear();
				command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = playerId;
				command.Parameters.Add("@VillageId", SqlDbType.Int).Value = villageId;
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(command);
				da.Fill(dt);
				dataGridViewResources.DataSource = dt;
			}
		}



		private void buttonFarmListAddNewFarm_Click
			(object sender,
			 EventArgs e)
		{
			ServerData sd = new ServerData();
			SqlCommand command = new SqlCommand("InsertNewFarm", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@VillageId", SqlDbType.Int).Value = comboBoxFarmListVillages.SelectedValue;
			command.Parameters.Add("@DestinationX", SqlDbType.Int).Value = Int32.Parse(textBoxFarmListX.Text.Trim());
			command.Parameters.Add("@DestinationY", SqlDbType.Int).Value = Int32.Parse(textBoxFarmListY.Text.Trim());
			command.Parameters.Add("@AttackType", SqlDbType.Int).Value = comboBoxFarmListAttackType.SelectedValue;
			command.Parameters.Add("@TroopList", SqlDbType.VarChar).Value = textBoxFarmListTroopList.Text.Trim();
			command.Parameters.Add("@TroopType", SqlDbType.Int).Value = comboBoxFarmListTroopType.SelectedValue;
			command.Parameters.Add("@TroopUnits", SqlDbType.Int).Value = Int32.Parse(textBoxFarmListNUmberOdUnits.Text.Trim());
			command.Parameters.Add("@Description", SqlDbType.VarChar).Value = textBoxFarmListDescription.Text.Trim();
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = playerId;
			command.Parameters.Add("@TribeId", SqlDbType.Int).Value = comboBoxFarmListTribe.SelectedValue;
			sd.Connection.Open();
			command.ExecuteNonQuery();
			sd.Connection.Close();
			FillFarmList();
		}
	}
}