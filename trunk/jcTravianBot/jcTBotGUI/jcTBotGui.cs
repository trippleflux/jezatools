using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using jcTBotLibrary;

namespace jcTBotGUI
{
	public partial class jcTBotGui : Form
	{
		private static CookieCollection cColl = null;

		public jcTBotGui()
		{
			InitializeComponent();
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{
			textBoxStatus.Text = "";
		}

		private void jcTBotGui_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'jcTBotDataSet.GetBuildingsGIDsNamesAndIDs' table. You can move, or remove it, as needed.
			this.getBuildingsGIDsNamesAndIDsTableAdapter.Fill(this.jcTBotDataSet.GetBuildingsGIDsNamesAndIDs);
			// TODO: This line of code loads data into the 'jcTBotDataSet.GetTaskNamesAndIDs' table. You can move, or remove it, as needed.
			this.getTaskNamesAndIDsTableAdapter.Fill(this.jcTBotDataSet.GetTaskNamesAndIDs);
			// TODO: This line of code loads data into the 'jcTBotDataSet.GetTaskNames' table. You can move, or remove it, as needed.
			this.getTaskNamesTableAdapter.Fill(this.jcTBotDataSet.GetTaskNames);
			// TODO: This line of code loads data into the 'jcTBotDataSet.GetVillagesNamesAndIDs' table. You can move, or remove it, as needed.
			this.getVillagesNamesAndIDsTableAdapter.Fill(this.jcTBotDataSet.GetVillagesNamesAndIDs);
			// TODO: This line of code loads data into the 'jcTBotDataSet.GetVillageNames' table. You can move, or remove it, as needed.
			this.getVillageNamesTableAdapter.Fill(this.jcTBotDataSet.GetVillageNames);
			// TODO: This line of code loads data into the 'jcTBotDataSet.GetProductionForVillages' table. You can move, or remove it, as needed.
			this.getProductionForVillagesTableAdapter.Fill(this.jcTBotDataSet.GetProductionForVillages);
			// TODO: This line of code loads data into the 'jcTBotDataSet.GetTaskList' table. You can move, or remove it, as needed.
			this.getTaskListTableAdapter.Fill(this.jcTBotDataSet.GetTaskList);
		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{
			String loginName = textBoxUsername.Text.Trim();
			String password = textBoxPassword.Text.Trim();
			String loginUrl = textBoxServerName.Text.Trim() + "login.php";
			String dorf1Url = textBoxServerName.Text.Trim() + "dorf1.php";
			CookieContainer myCookieContainer = new CookieContainer();
			String loginContent = BotLibrary.GetPageContent(loginUrl, myCookieContainer);
			LoginCredentials loginC = new LoginCredentials(loginContent);
			//w=1152%3A864&login=1220770065&e4a33c4=jezonsky&eb43098=*****&e1fe1de=e697604783&s1.x=48&s1.y=8
			String content = LoginCredentials.Login(loginName, password, dorf1Url, myCookieContainer, loginC, out cColl);
			textBoxStatus.Text += "Login to '" + loginUrl + "' as '" + loginName + "' [" + password + "]" + Environment.NewLine;
            for (int i = 0; i < cColl.Count; i++)
            {
                textBoxStatus.Text += "Cookie : " + cColl[i].Value + "'" + Environment.NewLine;
            }
		    buttonConnect.Enabled = false;
			Data data = new Data(content, true, true, true, false);
			textBoxStatus.Text += "Available Villages:" + Environment.NewLine;
            SqlConnection conn =
                new SqlConnection(
                ConfigurationManager.ConnectionStrings["jcTBotGUI.Properties.Settings.jcTBotConnection"].ConnectionString);
            for (int i = 0; i < data.VillagesList.Count; i++)
			{
				String[] villageList = data.VillagesList[i].ToString().Split('|');
				String villageName = villageList[1];
				String villageId = villageList[0];
				SqlCommand command = new SqlCommand("InsertVillage", conn);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("@VillageId", SqlDbType.Int).Value = villageId;
				command.Parameters.Add("@VillageName", SqlDbType.VarChar).Value = villageName;
				conn.Open();
				command.ExecuteNonQuery();
				conn.Close();
                textBoxStatus.Text += villageName + Environment.NewLine;
                //TODO: update village names if they were changed
			}

		}

		private void buttonAddNewTask_Click(object sender, EventArgs e)
		{

		}
	}
}