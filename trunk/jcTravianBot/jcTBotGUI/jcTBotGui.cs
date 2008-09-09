using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
			// TODO: This line of code loads data into the 'jcTBotDataSet.GetTaskList' table. You can move, or remove it, as needed.
			this.getTaskListTableAdapter.Fill(this.jcTBotDataSet.GetTaskList);
			// TODO: This line of code loads data into the 'jcTBotDataSet.GetVillages' table. You can move, or remove it, as needed.
			this.getVillagesTableAdapter.Fill(this.jcTBotDataSet.GetVillages);
			// TODO: This line of code loads data into the 'jcTBotDataSet.Tasks' table. You can move, or remove it, as needed.
			this.tasksTableAdapter.Fill(this.jcTBotDataSet.Tasks);
			// TODO: This line of code loads data into the 'jcTBotDataSet.TaskList' table. You can move, or remove it, as needed.
			this.taskListTableAdapter.Fill(this.jcTBotDataSet.TaskList);
			// TODO: This line of code loads data into the 'jcTBotDataSet.Buildings' table. You can move, or remove it, as needed.
			this.buildingsTableAdapter.Fill(this.jcTBotDataSet.Buildings);
			// TODO: This line of code loads data into the 'jcTBotDataSet.Resources' table. You can move, or remove it, as needed.
			this.resourcesTableAdapter.Fill(this.jcTBotDataSet.Resources);
			// TODO: This line of code loads data into the 'jcTBotDataSet.Villages' table. You can move, or remove it, as needed.
			this.villagesTableAdapter.Fill(this.jcTBotDataSet.Villages);

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
			//textBoxStatus.Text += (loginC.LoginName) + Environment.NewLine;
			//textBoxStatus.Text += (loginC.PasswordName) + Environment.NewLine;
			//textBoxStatus.Text += (loginC.HiddenName) + Environment.NewLine;
			//textBoxStatus.Text += (loginC.HiddenValue) + Environment.NewLine;
			//textBoxStatus.Text += (loginC.HiddenLoginValue) + Environment.NewLine;
			//w=1152%3A864&login=1220770065&e4a33c4=jezonsky&eb43098=*****&e1fe1de=e697604783&s1.x=48&s1.y=8
			String content = LoginCredentials.Login(loginName, password, dorf1Url, myCookieContainer, loginC, out cColl);
			textBoxStatus.Text += "Login to '" + loginUrl + "' as '" + loginName + "' [" + password + "]" + Environment.NewLine;
			for (int i = 0; i < cColl.Count; i++)
				textBoxStatus.Text += "Cookie : " + cColl[i].Value + "'" + Environment.NewLine;
			Data data = new Data(content, true, false);
			for (int i = 0; i < data.VillagesList.Count; i++)
			{
				textBoxStatus.Text += (data.VillagesList[i]) + Environment.NewLine;
			}

		}
	}
}