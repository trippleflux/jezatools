using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using jcTBotLibrary;

namespace jcTBotGUI
{
    public partial class jcTBotGui : Form
    {
        private static CookieCollection cColl;

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
            getBuildingsGIDsNamesAndIDsTableAdapter.Fill(jcTBotDataSet.GetBuildingsGIDsNamesAndIDs);
            // TODO: This line of code loads data into the 'jcTBotDataSet.GetTaskNamesAndIDs' table. You can move, or remove it, as needed.
            getTaskNamesAndIDsTableAdapter.Fill(jcTBotDataSet.GetTaskNamesAndIDs);
            // TODO: This line of code loads data into the 'jcTBotDataSet.GetTaskNames' table. You can move, or remove it, as needed.
            getTaskNamesTableAdapter.Fill(jcTBotDataSet.GetTaskNames);
            // TODO: This line of code loads data into the 'jcTBotDataSet.GetVillagesNamesAndIDs' table. You can move, or remove it, as needed.
            getVillagesNamesAndIDsTableAdapter.Fill(jcTBotDataSet.GetVillagesNamesAndIDs);
            // TODO: This line of code loads data into the 'jcTBotDataSet.GetVillageNames' table. You can move, or remove it, as needed.
            getVillageNamesTableAdapter.Fill(jcTBotDataSet.GetVillageNames);
            // TODO: This line of code loads data into the 'jcTBotDataSet.GetProductionForVillages' table. You can move, or remove it, as needed.
            getProductionForVillagesTableAdapter.Fill(jcTBotDataSet.GetProductionForVillages);
            // TODO: This line of code loads data into the 'jcTBotDataSet.GetTaskList' table. You can move, or remove it, as needed.
            getTaskListTableAdapter.Fill(jcTBotDataSet.GetTaskList);
        }

        private static string GetPageSource(string pageUrl)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(pageUrl);
            httpWebRequest.Method = "GET";
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.CookieContainer.Add(new Uri(pageUrl), cColl);
            HttpWebResponse webResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            StreamReader loginReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
            return loginReader.ReadToEnd();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            String loginName = textBoxUsername.Text.Trim();
            String password = textBoxPassword.Text.Trim();
            String serverName = textBoxServerName.Text.Trim();
            String loginUrl = serverName + "login.php";
            String dorf1Url = serverName + "dorf1.php";
            CookieContainer myCookieContainer = new CookieContainer();
            String loginContent = BotLibrary.GetPageContent(loginUrl, myCookieContainer, out cColl);
            LoginCredentials loginC = new LoginCredentials(loginContent);
            //w=1152%3A864&login=1220770065&e4a33c4=jezonsky&eb43098=*****&e1fe1de=e697604783&s1.x=48&s1.y=8
            String content = LoginCredentials.Login(loginName, password, dorf1Url, myCookieContainer, loginC, out cColl);
            //textBoxStatus.Text += "Login to '" + loginUrl + "' as '" + loginName + "' [" + password + "]" + Environment.NewLine;
            textBoxStatus.Text += "Login to '" + loginUrl + "' as '" + loginName + "'" + Environment.NewLine;
            for (int i = 0; i < cColl.Count; i++)
            {
                textBoxStatus.Text += "Cookie : " + cColl[i].Value + "'" + Environment.NewLine;
            }
            Data data = new Data(content, false, true, false, false, false);
            int villagesCount = data.VillagesList.Count;
            if (villagesCount > 0)
            {
                textBoxStatus.Text += "Available Villages:" + Environment.NewLine;
                buttonConnect.Enabled = false;
                SqlConnection conn =
                    new SqlConnection(
                        ConfigurationManager.ConnectionStrings["jcTBotGUI.Properties.Settings.jcTBotConnection"].
                            ConnectionString);
                ClearProductionTable(conn);
                ClearResourcesTable(conn);
                foreach (Village v in data.VillagesList)
                {
                    InsertVillage2DB(conn, v);
                    String villageUrl = serverName + "dorf1.php?newdid=" + v.VillageId;
                    String villageContent = GetPageSource(villageUrl);
                    Data productionOfVillage = new Data(villageContent, false, false, true, false, true);
                    InsertProductionForVillage(v, conn, productionOfVillage);
                    InsertResourcesForVillage(v, conn, productionOfVillage);
                }
                //String karte = GetPageSource(serverName + "karte.php");
                //textBoxStatus.Text += "production: " + data.ProductionList.Count + Environment.NewLine;
                //Production p = data.ProductionList[0] as Production;
                //textBoxStatus.Text += p.Clay + Environment.NewLine;
                //textBoxStatus.Text += p.ClayPerHour + Environment.NewLine;
            }
            else
            {
                buttonConnect.Enabled = true;
                textBoxStatus.Text += "Not connected!!!" + Environment.NewLine;
            }
        }

        private static void ClearProductionTable(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand("DeleteAllFromProduction", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        private static void ClearResourcesTable(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand("DeleteAllFromResources", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        private static void InsertResourcesForVillage(Village v, SqlConnection conn, Data productionOfVillage)
        {
            for (int i = 0; i < productionOfVillage.ResourcesList.Count; i++)
            {
                ResourcesId rId = productionOfVillage.ResourcesList[i] as ResourcesId;
                Resources r = rId.ResourcesVillageId[0] as Resources;
                SqlCommand command = new SqlCommand("InsertResources", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add("@VillageId", SqlDbType.Int).Value = v.VillageId;
                command.Parameters.Add("@ResourcesId", SqlDbType.Int).Value = r.ResourceId;
                command.Parameters.Add("@ResourcesName", SqlDbType.VarChar).Value = r.ResourceName;
                command.Parameters.Add("@ResourcesLevel", SqlDbType.Int).Value = r.ResourceLevel;
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            //Resources r = productionOfVillage.ResourcesList[0] as Resources;
        }

        private void InsertProductionForVillage(Village v, SqlConnection conn, Data productionOfVillage)
        {
            Production p = productionOfVillage.ProductionList[0] as Production;
            SqlCommand command = new SqlCommand("InsertProduction", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.Add("@VillageId", SqlDbType.Int).Value = v.VillageId;
            command.Parameters.Add("@Warehouse", SqlDbType.Int).Value = p.WarehouseKapacity;
            command.Parameters.Add("@Granary", SqlDbType.Int).Value = p.GranaryKapacity;
            command.Parameters.Add("@Wood", SqlDbType.Int).Value = p.Wood;
            command.Parameters.Add("@Clay", SqlDbType.Int).Value = p.Clay;
            command.Parameters.Add("@Iron", SqlDbType.Int).Value = p.Iron;
            command.Parameters.Add("@Crop", SqlDbType.Int).Value = p.Crop;
            command.Parameters.Add("@WoodPerHour", SqlDbType.Int).Value = p.WoodPerHour;
            command.Parameters.Add("@ClayPerHour", SqlDbType.Int).Value = p.ClayPerHour;
            command.Parameters.Add("@IronPerHour", SqlDbType.Int).Value = p.IronPerHour;
            command.Parameters.Add("@CropPerHour", SqlDbType.Int).Value = p.CropPerHour;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

            textBoxStatus.Text += v.VillageName + "(" + v.VillageId + ") ";
            textBoxStatus.Text += "Wood:" + p.Wood + "/" + p.WarehouseKapacity + "(" + p.WoodPerHour + ")";
            textBoxStatus.Text += "Clay:" + p.Clay + "/" + p.WarehouseKapacity + "(" + p.ClayPerHour + ")";
            textBoxStatus.Text += "Iron:" + p.Iron + "/" + p.WarehouseKapacity + "(" + p.IronPerHour + ")";
            textBoxStatus.Text += "Crop:" + p.Crop + "/" + p.GranaryKapacity + "(" + p.CropPerHour + ")" +
                                  Environment.NewLine;
        }

        private static string InsertVillage2DB(SqlConnection conn, Village v)
        {
            String villageName = v.VillageName;
            String villageId = v.VillageId;
            SqlCommand command = new SqlCommand("InsertVillage", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.Add("@VillageId", SqlDbType.Int).Value = villageId;
            command.Parameters.Add("@VillageName", SqlDbType.VarChar).Value = villageName;
            conn.Open();
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            command = new SqlCommand("UpdateVillageName", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VillageId", SqlDbType.Int).Value = villageId;
            command.Parameters.Add("@VillageName", SqlDbType.VarChar).Value = villageName;
            command.ExecuteNonQuery();
            conn.Close();
            return villageName;
        }

        private void buttonAddNewTask_Click(object sender, EventArgs e)
        {
        }

        private void dataGridViewVillages_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("AAAAAAAAA");
            //dataGridViewVillages.SelectedRows[0].ToString()
        }

        private void dataGridViewVillages_Click(object sender, EventArgs e)
        {
            if (dataGridViewVillages.SelectedRows.Count == 1)
            {
                //dataGridViewVillages.SelectedRows[0].Cells[2].Value.ToString()
                int villageId = 
                    Int32.Parse(dataGridViewVillages.SelectedRows[0].Cells[2].Value.ToString().Trim());
                SqlConnection conn =
                    new SqlConnection(
                        ConfigurationManager.ConnectionStrings["jcTBotGUI.Properties.Settings.jcTBotConnection"].
                            ConnectionString);
                SqlCommand command = new SqlCommand("GetResourcesForVillage", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add("@VillageId", SqlDbType.Int).Value = villageId;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                dataGridViewResources.DataSource = dt;
            }
        }
    }
}