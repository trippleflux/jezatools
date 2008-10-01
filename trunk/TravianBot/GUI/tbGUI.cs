using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Library;

namespace GUI
{
    public partial class tbGUI : Form
    {
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
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = 8226;
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
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = 8226;
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
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = 8226;
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet ds = new DataSet();
			adapter.Fill(ds, "Villages");
			comboBoxTasksVillages.DataSource = ds.Tables["Villages"];
			comboBoxTasksVillages.DisplayMember = "VillageName";
			comboBoxTasksVillages.ValueMember = "VillageId";
		}

		private void tbGUI_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'travianBotDataSet.GetPriority' table. You can move, or remove it, as needed.
			this.getPriorityTableAdapter.Fill(this.travianBotDataSet.GetPriority);
			// TODO: This line of code loads data into the 'travianBotDataSet.GetBuildIds' table. You can move, or remove it, as needed.
			this.getBuildIdsTableAdapter.Fill(this.travianBotDataSet.GetBuildIds);
			// TODO: This line of code loads data into the 'travianBotDataSet.GetTasks' table. You can move, or remove it, as needed.
			this.getTasksTableAdapter.Fill(this.travianBotDataSet.GetTasks);
			FillProduction();
		}

		private void tabControl_Click(object sender, EventArgs e)
		{
			FillProduction();
			FillTasks();
			FillVillages();
		}

		private void buttonTasksAddNew_Click(object sender, EventArgs e)
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
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = 8226;
			sd.Connection.Open();
			command.ExecuteNonQuery();
			sd.Connection.Close();
		}

		private void dataGridViewProduction_Click(object sender, EventArgs e)
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
				command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = 8226;
				command.Parameters.Add("@VillageId", SqlDbType.Int).Value = villageId;
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(command);
				da.Fill(dt);
				dataGridViewResources.DataSource = dt;
			}

		}
    }
}