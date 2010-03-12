#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using HtmlAgilityPack;
using jeza.Travian.Framework;
using jeza.Travian.Parser;
using HtmlDocument=HtmlAgilityPack.HtmlDocument;
using Timer=System.Windows.Forms.Timer;

#endregion

namespace jeza.Travian.GameCenter
{
    public partial class ProcessCenter : Form
    {
        public ProcessCenter()
        {
            InitializeComponent();
            settings = new Settings();
            account = new Account();
            map = new Map();
            map.DeserializeValleys();
            valleyTypeList = new ValleyTypeList();
            DeserializeValleyTypeList();
            DeserializeSettings();
            languages = new Languages();
            DeserializeLanguage();
            actions = new Actions();
            DeserializeActions();
            htmlWeb.UseCookies = true;
            Timer timer = new Timer {Interval = 1000, Enabled = true};
            timer.Tick += TimerTick;
        }

        #region gui actions

        private void buttonBrowserGo_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(settings.LoginData.Servername);
        }

        private void buttonBuildQueueAdd_Click(object sender, EventArgs e)
        {
            Buildings buildings = comboBoxBuildQueueBuilding.SelectedItem as Buildings;
            if (buildings != null)
            {
                Village selectedVillage = comboBoxBuildQueueVillages.SelectedItem as Village;
                if (selectedVillage != null)
                {
                    BuildQueue buildQueue = new BuildQueue
                        {
                            Level = Misc.String2Number(comboBoxBuildQueueLevel.SelectedItem.ToString()),
                            Name = buildings.Name,
                            BuildingId = buildings.Id,
                            VillageId = selectedVillage.Id,
                            VillageName = selectedVillage.Name,
                        };
                    if (!actions.BuildQueue.Contains(buildQueue))
                    {
                        UpdateStatus("New build queue: " + buildQueue);
                        actions.BuildQueue.Add(buildQueue);
                    }
                }
            }
            SerializeActions();
            UpdateListBoxBuildQueues(listBoxBuildQueues);
        }

        private void buttonBuildQueueSelect_Click(object sender, EventArgs e)
        {
            Village selectedVillage = comboBoxBuildQueueVillages.SelectedItem as Village;
            if (selectedVillage != null)
            {
                Thread t = new Thread(mapInfo => PopulateBuildQueueForVillage(selectedVillage)) {IsBackground = true};
                t.Start();
            }
        }

        private void buttonSettingsExcludedAllyAdd_Click(object sender, EventArgs e)
        {
            //TODO: todo
        }

        private void buttonSettingsExcludedUsersAdd_Click(object sender, EventArgs e)
        {
            //TODO: todo
        }

        private void buttonMapPopulate_Click(object sender, EventArgs e)
        {
            PopulateMap();
        }

        private void buttonMapUpdate_Click(object sender, EventArgs e)
        {
            Village selectedVillage = comboBoxMapVillages.SelectedItem as Village;
            if (selectedVillage != null)
            {
                Thread t = new Thread(mapInfo => GetMapInfo(selectedVillage)) {IsBackground = true};
                t.Start();
            }
        }

        private void buttonOwerviewSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void buttonSettingsAllyAdd_Click(object sender, EventArgs e)
        {
            //TODO: todo
        }

        private void buttonSettingsNapAdd_Click(object sender, EventArgs e)
        {
            //TODO: todo
        }

        private void buttonSettingsWarAdd_Click(object sender, EventArgs e)
        {
            //TODO: todo
        }

        private void buttonUpdateRallyPoint_Click(object sender, EventArgs e)
        {
            Village selectedVillage = comboBoxRallyPointVillages.SelectedItem as Village;
            if (selectedVillage != null)
            {
                Thread t = new Thread(rallyPoint => PopulateRallyPoint(selectedVillage)) {IsBackground = true};
                t.Start();
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void ProcessCenter_Load(object sender, EventArgs e)
        {
        }

        private void ProcessCenter_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //HtmlDocument htmlDocument = webBrowser.Document;
            //if (htmlDocument != null)
            //{
            //    HtmlElement htmlElement = htmlDocument.GetElementById("btn_login");
            //    if (htmlElement != null)
            //    {
            //        htmlElement.InvokeMember("click");
            //    }
            //}
            textBoxBrowserUrl.Text = webBrowser.Url.ToString();
        }

        #endregion

        #region helper methods

        /// <summary>
        /// Deserializes the actions.
        /// </summary>
        private void DeserializeActions()
        {
            using (FileStream fileStream = new FileStream(ActionsXml, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (Actions));
                actions = (Actions) xmlSerializer.Deserialize(fileStream);
            }
            listBoxBuildQueues.Items.Clear();
            UpdateListBoxBuildQueues(listBoxBuildQueues);
        }

        /// <summary>
        /// Load language settings from XML.
        /// </summary>
        private void DeserializeLanguage()
        {
            using (FileStream fileStream = new FileStream(LanguagesXml, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (Languages));
                languages = (Languages) xmlSerializer.Deserialize(fileStream);
            }
            UpdateComboBoxLanguages(comboBoxSettingsLanguages);
        }

        /// <summary>
        /// Load settings from XML.
        /// </summary>
        private void DeserializeSettings()
        {
            if (File.Exists(SettingsXml))
            {
                using (FileStream fileStream = new FileStream(SettingsXml, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof (Settings));
                    settings = (Settings) xmlSerializer.Deserialize(fileStream);
                }
                if (settings.LoginData != null)
                {
                    textBoxServer.Text = settings.LoginData.Servername;
                    textBoxUsername.Text = settings.LoginData.Username;
                    textBoxPassword.Text = settings.LoginData.Password;
                }
                if (settings.LanguageId != null)
                {
                    comboBoxSettingsLanguages.SelectedText = settings.LanguageId;
                }
            }
            else
            {
                SerializeSettings();
            }
        }

        private void DeserializeValleyTypeList()
        {
            using (FileStream fileStream = new FileStream(ValleyTypeListXml, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (ValleyTypeList));
                valleyTypeList = (ValleyTypeList) xmlSerializer.Deserialize(fileStream);
            }
        }

        private void DisableButtons()
        {
            DisableMapButtons();
            UpdateButtonStatus(buttonUpdateRallyPoint, false);
        }

        private void DisableMapButtons()
        {
            UpdateButtonStatus(buttonMapUpdate, false);
            UpdateButtonStatus(buttonMapPopulate, false);
        }

        private void EnableButtons()
        {
            EnableMapButtons();
            UpdateButtonStatus(buttonUpdateRallyPoint, true);
        }

        private void EnableMapButtons()
        {
            UpdateButtonStatus(buttonMapUpdate, true);
            UpdateButtonStatus(buttonMapPopulate, true);
        }

        private void GetMapInfo(Village selectedVillage)
        {
            DisableMapButtons();
            int x = selectedVillage.CoordinateX;
            int y = selectedVillage.CoordinateY;
            int distance = Misc.String2Number(textBoxMapDistance.Text.Trim());
            map.Valleys.Clear();
            if (distance < 2)
            {
                GetMapInfoAt(x, y);
            }
            else
            {
                for (int i = 0; i < distance; i++)
                {
                    if (i != 1)
                    {
                        continue;
                    }
                    int size = 7*i;
                    for (int j = (1 - distance); j < distance; j++)
                    {
                        for (int k = (1 - distance); k < distance; k++)
                        {
                            int distX = size*k;
                            int distY = size*j;
                            GetMapInfoAt(x + distX, y + distY);
                        }
                    }
                }
            }
            //UpdateStatus(String.Format(CultureInfo.InvariantCulture, "Valleys count: {0}", map.Valleys.Count));
            map.SerializeValleys();
            EnableMapButtons();
        }

        private void GetMapInfoAt(int x, int y)
        {
            string servername = settings.LoginData.Servername;
            string url = String.Format(CultureInfo.InvariantCulture, "{0}karte.php?xp={1}&yp={2}&s1.x=32&s1.y=11&s1=ok",
                                       servername, x, y);
            htmlDocument = htmlWeb.Load(url);
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            List<Valley> villagesFromMap = htmlParser.GetVillagesFromMap();
            List<Valley> oasesFromMap = htmlParser.GetOasesFromMap();
            List<Valley> updatedValleys = new List<Valley>();
            //List<Valley> existingValleys = map.Valleys;
            foreach (Valley valley in villagesFromMap)
            {
                url = String.Format(CultureInfo.InvariantCulture, "{0}{1}", servername, valley.VillageUrl);
                htmlDocument = htmlWeb.Load(url);
                htmlParser = new HtmlParser(htmlDocument);
                Valley villageDetails = htmlParser.GetVillageDetails();
                villageDetails
                    .AddUrl(valley.VillageUrl);
                updatedValleys.Add(villageDetails);
            }
            foreach (Valley valley in oasesFromMap)
            {
                url = String.Format(CultureInfo.InvariantCulture, "{0}{1}", servername, valley.VillageUrl);
                htmlDocument = htmlWeb.Load(url);
                htmlParser = new HtmlParser(htmlDocument);
                Valley oasesDetails = htmlParser.GetOasesDetails();
                updatedValleys.Add(oasesDetails);
            }
            map.AddVillages(updatedValleys);
            //map.AddVillages(oasesFromMap);
            UpdateStatus(String.Format(CultureInfo.InvariantCulture, "Found {2} villages and {3} oases around ({0}|{1})",
                                       x, y, updatedValleys.Count, oasesFromMap.Count));
        }

        /// <summary>
        /// Determines whether we are loged in.
        /// </summary>
        /// <param name="load">The load.</param>
        /// <returns>
        /// 	<c>true</c> if logout link was found; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsLogedIn(HtmlDocument load)
        {
            HtmlNode nodeLogout = load.DocumentNode.SelectSingleNode("//a[@href='logout.php']");
            if (nodeLogout != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Logins to the game.
        /// </summary>
        /// <returns></returns>
        private bool Login()
        {
            bool isLogedIn = false;
            htmlDocument = htmlWeb.Load(settings.LoginData.Servername + "login.php");
            //<input type="hidden" name="login" value="1267389391" />
            HtmlNode node = htmlDocument.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='login']");
            string loginValue = node.Attributes["value"].Value;
            NameValueCollection postData = new NameValueCollection(1)
                {
                    {"w", "1680%3A1050"},
                    {"login", loginValue},
                    {"name", settings.LoginData.Username},
                    {"password", settings.LoginData.Password},
                    {"s1.x", "35"},
                    {"s1.y", "9"},
                    {"s1", "login"}
                };
            htmlDocument = htmlWeb.SubmitFormValues(postData, settings.LoginData.Servername + "dorf1.php");
            if (htmlDocument != null)
            {
                isLogedIn = IsLogedIn(htmlDocument);
                UpdateStatus("Loged in...");
            }
            else
            {
                UpdateStatus("Failed to login [load]...");
            }
            return isLogedIn;
        }

        private void PopulateBuildQueueForVillage(Village village)
        {
            string servername = settings.LoginData.Servername;
            string url = String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php?newdid={1}",
                                       servername, village.Id);
            htmlDocument = htmlWeb.Load(url);
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            List<Buildings> resources = htmlParser.GetResourceBuildings();
            url = String.Format(CultureInfo.InvariantCulture, "{0}dorf2.php?newdid={1}",
                                servername, village.Id);
            htmlDocument = htmlWeb.Load(url);
            htmlParser = new HtmlParser(htmlDocument);
            List<Buildings> center = htmlParser.GetCenterBuildings(village);
            ArrayList list = new ArrayList();
            list.AddRange(resources);
            list.AddRange(center);
            UpdateComboBoxQueues(comboBoxBuildQueueBuilding, list);
        }

        private void PopulateMap()
        {
            ArrayList list = new ArrayList();
            foreach (Valley valley in map.Valleys)
            {
                if (checkBoxUnoccupiedOasis.Checked && valley.ValleyType == ValleyType.UnoccupiedOasis)
                {
                    list.Add(valley);
                }
                else if (checkBoxMapOccupiedOasis.Checked && valley.ValleyType == ValleyType.OccupiedOasis)
                {
                    list.Add(valley);
                }
                else if (checkBoxFarmsNoProfit.Checked && valley.ValleyType == ValleyType.FarmNoProfit)
                {
                    list.Add(valley);
                }
                else if (checkBoxFarmsLowRisk.Checked && valley.ValleyType == ValleyType.FarmLowRisk)
                {
                    list.Add(valley);
                }
                else if (checkBoxFarmsMiddleRisk.Checked && valley.ValleyType == ValleyType.FarmMiddleRisk)
                {
                    list.Add(valley);
                }
                else if (checkBoxFarmsHighRish.Checked && valley.ValleyType == ValleyType.FarmHighRisk)
                {
                    list.Add(valley);
                }
                else if (checkBoxAlly.Checked && valley.ValleyType == ValleyType.AllianceAlly)
                {
                    list.Add(valley);
                }
                else if (checkBoxNap.Checked && valley.ValleyType == ValleyType.AllianceNap)
                {
                    list.Add(valley);
                }
                else if (checkBoxWar.Checked && valley.ValleyType == ValleyType.AllianceWar)
                {
                    list.Add(valley);
                }
                else if (checkBoxExcludedPlayers.Checked && valley.ValleyType == ValleyType.ExcludedPlayer)
                {
                    list.Add(valley);
                }
                else if (checkBoxExcludedAlliances.Checked && valley.ValleyType == ValleyType.ExcludedAlliance)
                {
                    list.Add(valley);
                }
                else
                {
                    if (valley.ValleyType == ValleyType.UnknownType)
                    {
                        list.Add(valley);
                    }
                }
            }
            if (dataGridViewMap.InvokeRequired)
            {
                SetDataGridViewDataBind m = SetDataSource;
                Invoke(m, new object[] {dataGridViewMap, list});
            }
            else
            {
                dataGridViewMap.DataSource = list;
            }
        }

        private void PopulateRallyPoint(Village village)
        {
            string servername = settings.LoginData.Servername;
            //http://s1.travian.com/build.php?newdid=75579&gid=16&id=39
            string url = String.Format(CultureInfo.InvariantCulture, "{0}build.php?newdid={1}&gid=16&id=39",
                                       servername, village.Id);
            htmlDocument = htmlWeb.Load(url);
            Language language = languages.GetLanguage(settings.LanguageId);
            HtmlParser htmlParser = new HtmlParser(htmlDocument, language);
            List<TroopMovement> troopMovements = htmlParser.TroopMovements(village);
            ArrayList list = new ArrayList();
            list.AddRange(troopMovements);
            if (dataGridViewRallyPoint.InvokeRequired)
            {
                SetDataGridViewDataBind r = SetDataSource;
                Invoke(r, new object[] {dataGridViewRallyPoint, list});
            }
            else
            {
                dataGridViewRallyPoint.DataSource = list;
            }
            UpdateStatus(String.Format(CultureInfo.InvariantCulture, "Populate Rally Point in {0}", village.Name));
        }

        private void SaveSettings()
        {
            Login loginData = new Login
                {
                    Servername = textBoxServer.Text.Trim(),
                    Username = textBoxUsername.Text.Trim(),
                    Password = textBoxPassword.Text.Trim()
                };
            settings.LoginData = loginData;
            settings.LanguageId = comboBoxSettingsLanguages.SelectedItem.ToString().Trim();
            SerializeSettings();
        }

        /// <summary>
        /// Saves actions to XML.
        /// </summary>
        private void SerializeActions()
        {
            using (TextWriter textWriter = new StreamWriter(ActionsXml))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (Actions));
                xmlSerializer.Serialize(textWriter, actions);
            }
        }

        /// <summary>
        /// Saves settnigs to XML.
        /// </summary>
        private void SerializeSettings()
        {
            using (TextWriter textWriter = new StreamWriter(SettingsXml))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (Settings));
                xmlSerializer.Serialize(textWriter, settings);
            }
        }

        /// <summary>
        /// Saves notes to XML.
        /// </summary>
        private void SerializeValeyTypeList()
        {
            using (TextWriter textWriter = new StreamWriter(ValleyTypeListXml))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (ValleyTypeList));
                xmlSerializer.Serialize(textWriter, valleyTypeList);
            }
        }

        /// <summary>
        /// Starts the bot.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SetBotStatus(object sender, EventArgs e)
        {
            if (!botActive)
            {
                SerializeSettings();
                botActive = true;
                Thread t = new Thread(StartBot) {IsBackground = true};
                t.Start();
                buttonRun.Text = "Stop";
            }
            else
            {
                botActive = false;
                buttonRun.Text = "Start";
                DisableButtons();
                UpdateStatus("Disconnecting...");
            }
            //lock (stateLock)
            //{
            //    target = rng.Next(100);
            //}
        }

        private static void SetDataSource(DataGridView field, ArrayList list)
        {
            field.DataSource = list;
        }

        /// <summary>
        /// Starts the bot.
        /// </summary>
        private void StartBot()
        {
            UpdateStatus("Login...");
            bool isLogedIn = Login();
            while (botActive && isLogedIn)
            {
                isLogedIn = IsLogedIn(htmlDocument);
                int loginRetryCount = 0;
                if (!isLogedIn)
                {
                    Thread.Sleep(30000);
                    isLogedIn = Login();
                    if (++loginRetryCount > 3)
                    {
                        break;
                    }
                }
                UpdateAccountInfo();
                EnableButtons();

                Thread.Sleep(300000);
            }
            botActive = false;
            UpdateStatus("Idlin...");
            //    MethodInvoker updateCounterDelegate = UpdateCount;
            //    int localTarget;
            //    lock (stateLock)
            //    {
            //        localTarget = target;
            //    }
            //    UpdateStatus("Starting");

            //    lock (stateLock)
            //    {
            //        currentCount = 0;
            //    }
            //    Invoke(updateCounterDelegate);
            //    // Pause before starting
            //    Thread.Sleep(500);
            //    UpdateStatus("Counting");
            //    for (int i = 0; i < localTarget; i++)
            //    {
            //        lock (stateLock)
            //        {
            //            currentCount = i;
            //        }
            //        // Synchronously show the counter
            //        Invoke(updateCounterDelegate);
            //        Thread.Sleep(100);
            //    }
            //    UpdateStatus("Finished");
            //    Invoke(new MethodInvoker(EnableButton));
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            labelDateTime.Text = t.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Updates the account info.
        /// </summary>
        private void UpdateAccountInfo()
        {
            UpdateStatus("UpdateAccountInfo");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            List<Village> villages = htmlParser.GetAvailableVillages();
            account.UpdateVillages(villages);
            string servername = settings.LoginData.Servername;
            foreach (Village village in villages)
            {
                string url = String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php?newdid={1}",
                                           servername, village.Id);
                htmlDocument = htmlWeb.Load(url);
                htmlParser = new HtmlParser(htmlDocument);
                Production production = htmlParser.GetProduction();
                village.UpdateProduction(production);
                Troops availableTroops = htmlParser.GetAvailableTroops();
                village.UpdateTroopsInVillage(availableTroops);
            }
            List<BuildQueue> list = new List<BuildQueue>();
            foreach (BuildQueue buildQueue in actions.BuildQueue)
            {
                string url = String.Format(CultureInfo.InvariantCulture, "{0}build.php?newdid={1}&id={2}",
                                           servername, buildQueue.VillageId, buildQueue.BuildingId);
                htmlDocument = htmlWeb.Load(url);
                htmlParser = new HtmlParser(htmlDocument);
                buildQueue.Resources = htmlParser.GetResourcesForNextLevel();
                if (buildQueue.Resources.UpgradeUrl != null)
                {
                    url = String.Format(CultureInfo.InvariantCulture, "{0}{1}&newdid={2}",
                                        servername, buildQueue.Resources.UpgradeUrl, buildQueue.VillageId);
                    htmlDocument = htmlWeb.Load(url);
                    UpdateStatus(String.Format(CultureInfo.InvariantCulture, "Upgrading : {0} ({1})", buildQueue.Name, url));
                    url = String.Format(CultureInfo.InvariantCulture, "{0}build.php?newdid={1}&id={2}",
                                        servername, buildQueue.VillageId, buildQueue.BuildingId);
                    htmlDocument = htmlWeb.Load(url);
                    htmlParser = new HtmlParser(htmlDocument);
                    buildQueue.Resources = htmlParser.GetResourcesForNextLevel();
                }
                if (buildQueue.Level >= buildQueue.Resources.CurrentLevel)
                {
                    list.Add(buildQueue);
                }
            }
            actions.BuildQueue = list;
            SerializeActions();
            UpdateListBoxBuildQueues(listBoxBuildQueues);
            UpdateComboBoxVillages(comboBoxMapVillages);
            UpdateComboBoxVillages(comboBoxRallyPointVillages);
            UpdateComboBoxVillages(comboBoxBuildQueueVillages);
        }

        private void UpdateButtonStatus(Button button, bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetButtonStatus(UpdateButtonStatus), button, enabled);
                return;
            }
            button.Enabled = enabled;
        }

        private void UpdateComboBoxQueues(ComboBox field, ArrayList list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetComboBoxStatusQueues(UpdateComboBoxQueues), field, list);
                return;
            }
            field.Items.Clear();
            foreach (Buildings buildings in list)
            {
                field.Items.Add(buildings);
            }
            field.SelectedItem = field.Items[0];
        }

        private void UpdateComboBoxLanguages(ComboBox field)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetComboBoxStatus(UpdateComboBoxLanguages), field);
                return;
            }
            field.Items.Clear();
            foreach (Language language in languages.Language)
            {
                field.Items.Add(language.Id);
            }
            field.SelectedItem = field.Items[0];
        }

        private void UpdateComboBoxVillages(ComboBox field)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetComboBoxStatus(UpdateComboBoxVillages), field);
                return;
            }
            field.Items.Clear();
            foreach (Village village in account.Villages)
            {
                field.Items.Add(village);
            }
            field.SelectedItem = field.Items[0];
        }

        private void UpdateListBoxBuildQueues(ListBox field)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetListBoxStatus(UpdateListBoxBuildQueues), field);
                return;
            }
            field.Items.Clear();
            foreach (BuildQueue buildQueue in actions.BuildQueue)
            {
                field.Items.Add(buildQueue);
            }
        }

        /// <summary>
        /// Writes message to status text box.
        /// </summary>
        /// <param name="value">The value.</param>
        private void UpdateStatus(string value)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UpdateStatus), new object[] {value});
                return;
            }
            // Must be on the UI thread if we've got this far
            DateTime dt = new DateTime(DateTime.Now.Ticks);
            textBoxStatus.Text += String.Format(CultureInfo.InvariantCulture, "{0} : {1}{2}", dt.ToLocalTime(), value,
                                                Environment.NewLine);
            textBoxStatus.Select(textBoxStatus.Text.Length, 0);
            textBoxStatus.ScrollToCaret();
        }

        //private void UpdateCount()
        //{
        //    int tmpCount;
        //    lock (stateLock)
        //    {
        //        tmpCount = currentCount;
        //    }
        //    counter.Text = tmpCount.ToString();
        //}

        //private void EnableButton()
        //{
        //    button.Enabled = true;
        //}

        #endregion
    }
}