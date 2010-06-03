#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using HtmlAgilityPack;
using jeza.Travian.Framework;
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
                    UpdateQueue(buildings, selectedVillage, comboBoxBuildQueueLevel);
                }
                SerializeActions();
                UpdateListBoxBuildQueues(listBoxBuildQueues);
            }
        }

        private void buttonBuildQueueAutoBuildResources_Click(object sender, EventArgs e)
        {
            Village selectedVillage = comboBoxBuildQueueVillages.SelectedItem as Village;
            if (selectedVillage != null)
            {
                for (int i = 0; i < 19; i++)
                {
                    Buildings buildings = comboBoxBuildQueueBuilding.Items[i] as Buildings;
                    if (buildings != null)
                    {
                        UpdateQueue(buildings, selectedVillage, comboBoxBuildQueueAutoBuildResources);
                    }
                }
                SerializeActions();
                UpdateListBoxBuildQueues(listBoxBuildQueues);
            }
        }

        private void buttonBuildQueueDelete_Click(object sender, EventArgs e)
        {
            if (listBoxBuildQueues.SelectedItems.Count > 0)
            {
                BuildQueue queue = listBoxBuildQueues.SelectedItem as BuildQueue;
                List<BuildQueue> list = new List<BuildQueue>();
                foreach (BuildQueue buildQueue in actions.BuildQueue)
                {
                    if (buildQueue != queue)
                    {
                        list.Add(buildQueue);
                    }
                }
                actions.BuildQueue.Clear();
                actions.BuildQueue.AddRange(list);
                SerializeActions();
                UpdateListBoxBuildQueues(listBoxBuildQueues);
            }
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

        private void buttonMapExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewMap.RowCount > 0)
            {
                SerializeMap(dataGridViewMap.DataSource as List<Valley>);
            }
        }

        private void buttonMapPopulate_Click(object sender, EventArgs e)
        {
            Village selectedVillage = comboBoxMapVillages.SelectedItem as Village;
            if (selectedVillage != null)
            {
                PopulateMap(selectedVillage);
            }
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

        private void buttonMarketPlaceAddTask_Click(object sender, EventArgs e)
        {
            Village sourceVillage = comboBoxMarketPlaceSourceVillage.SelectedItem as Village;
            Village destinationVillage = comboBoxMarketPlaceDestinationVillage.SelectedItem as Village;
            if (sourceVillage != null && destinationVillage != null)
            {
                if (sourceVillage.Id > -1 && destinationVillage.Id > -1)
                {
                    int destinationPercent = Misc.String2Number(textBoxMarketPlaceDestinationBellow.Text.Trim());
                    int sourcePercent = Misc.String2Number(textBoxMarketPlaceSourceOver.Text.Trim());
                    bool sendWood = checkBoxMarketPlaceWood.Checked;
                    bool sendClay = checkBoxMarketPlaceClay.Checked;
                    bool sendIron = checkBoxMarketPlaceIron.Checked;
                    bool sendCrop = checkBoxMarketPlaceCrop.Checked;
                    MarketPlaceQueue queue = new MarketPlaceQueue
                        {
                            DestinationVillage = destinationVillage,
                            SourceVillage = sourceVillage,
                            SendWood = sendWood,
                            SendClay = sendClay,
                            SendIron = sendIron,
                            SendCrop = sendCrop,
                            SendGoodsType =
                                radioButtonMarketPlaceDestinationBellow.Checked
                                    ? SendGoodsType.DestinationBellowPercent
                                    : SendGoodsType.SourceOverPercent,
                            Goods =
                                radioButtonMarketPlaceDestinationBellow.Checked
                                    ? destinationPercent
                                    : sourcePercent,
                            GoodsToSend = Misc.String2Number(textBoxMarketPlaceSourceOverSendGods.Text),
                            LastSend = new DateTime(DateTime.Now.Ticks),
                            RepeatMinutes = Misc.String2Number(comboBoxMarketPlaceCheck.Text),
                        };
                    actions.MarketPlaceQueue.Add(queue);
                    SerializeActions();
                    DeserializeActions();
                    UpdateStatus("New Market place task.");
                }
                else
                {
                    UpdateComboBoxVillages(comboBoxMarketPlaceSourceVillage);
                    UpdateComboBoxVillages(comboBoxMarketPlaceDestinationVillage);
                    UpdateComboBoxVillages(comboBoxMarketPlaceRepeatSourceVillage);
                }
            }
        }

        private void buttonMarketPlaceRepeatAddTask_Click(object sender, EventArgs e)
        {
            Village sourceVillage = comboBoxMarketPlaceRepeatSourceVillage.SelectedItem as Village;
            if (sourceVillage != null)
            {
                if (sourceVillage.Id > -1)
                {
                    bool sendWood = checkBoxMarketPlaceRepeatWood.Checked;
                    bool sendClay = checkBoxMarketPlaceRepeatClay.Checked;
                    bool sendIron = checkBoxMarketPlaceRepeatIron.Checked;
                    bool sendCrop = checkBoxMarketPlaceRepeatCrop.Checked;
                    MarketPlaceQueue queue = new MarketPlaceQueue
                        {
                            DestinationVillage = new Village
                                {
                                    CoordinateX = Misc.String2Number(textBoxMarketPlaceRepeatX.Text),
                                    CoordinateY = Misc.String2Number(textBoxMarketPlaceRepeatY.Text),
                                    Name = textBoxMarketPlaceRepeatX.Text + "|" + textBoxMarketPlaceRepeatY.Text,
                                },
                            SourceVillage = sourceVillage,
                            SendWood = sendWood,
                            SendClay = sendClay,
                            SendIron = sendIron,
                            SendCrop = sendCrop,
                            SendGoodsType = SendGoodsType.Repeat,
                            Goods = Misc.String2Number(textBoxMarketPlaceRepeatGoods.Text),
                            RepeatMinutes = Misc.String2Number(comboBoxMarketPlaceRepeatHour.Text)*60,
                            LastSend = DateTime.Now,
                        };
                    actions.MarketPlaceQueue.Add(queue);
                    SerializeActions();
                    DeserializeActions();
                    UpdateStatus("New Market place task.");
                }
                else
                {
                    UpdateComboBoxVillages(comboBoxMarketPlaceSourceVillage);
                    UpdateComboBoxVillages(comboBoxMarketPlaceDestinationVillage);
                    UpdateComboBoxVillages(comboBoxMarketPlaceRepeatSourceVillage);
                }
            }
        }

        private void buttonMarketPlaceDelete_Click(object sender, EventArgs e)
        {
            if (listBoxMarketPlaceTasks.SelectedItems.Count > 0)
            {
                MarketPlaceQueue queue = listBoxMarketPlaceTasks.SelectedItem as MarketPlaceQueue;
                List<MarketPlaceQueue> list = new List<MarketPlaceQueue>();
                foreach (MarketPlaceQueue marketPlaceQueue in actions.MarketPlaceQueue)
                {
                    if (marketPlaceQueue != queue)
                    {
                        list.Add(marketPlaceQueue);
                    }
                }
                actions.MarketPlaceQueue.Clear();
                actions.MarketPlaceQueue.AddRange(list);
                SerializeActions();
                UpdateListBoxTransportQueues(listBoxMarketPlaceTasks);
            }
        }

        private void buttonSettingsAllyDelete_Click(object sender, EventArgs e)
        {
            RemoveSettingsAlly(listBoxSettingsAlly, AllyType.Ally);
        }

        private void buttonSettingsNapDelete_Click(object sender, EventArgs e)
        {
            RemoveSettingsAlly(listBoxSettingsNap, AllyType.Nap);
        }

        private void buttonSettingsWarDelete_Click(object sender, EventArgs e)
        {
            RemoveSettingsAlly(listBoxSettingsWar, AllyType.War);
        }

        private void buttonSettingsExcludedAllyAdd_Click(object sender, EventArgs e)
        {
            InsertExcludedData(textBoxSettingsExcludedAllyId, textBoxSettingsExcludedAllyName, ExcludedType.Ally);
        }

        private void buttonSettingsExcludedUsersAdd_Click(object sender, EventArgs e)
        {
            InsertExcludedData(textBoxSettingsExcludedUserId, textBoxSettingsExcludedUserName, ExcludedType.User);
        }

        private void buttonSettingsAllyAdd_Click(object sender, EventArgs e)
        {
            InsertAllyData(textBoxSettingsAllyIdAlly, textBoxSettingsAllyNameAlly, AllyType.Ally);
            UpdateListBoxAlly(listBoxSettingsAlly, AllyType.Ally);
        }

        private void buttonSettingsNapAdd_Click(object sender, EventArgs e)
        {
            InsertAllyData(textBoxSettingsAllyIdNap, textBoxSettingsAllyNameNap, AllyType.Nap);
            UpdateListBoxAlly(listBoxSettingsNap, AllyType.Nap);
        }

        private void buttonSettingsWarAdd_Click(object sender, EventArgs e)
        {
            InsertAllyData(textBoxSettingsAllyIdWar, textBoxSettingsAllyNameWar, AllyType.War);
            UpdateListBoxAlly(listBoxSettingsWar, AllyType.War);
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

        private void dataGridViewMap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMap.Columns[e.ColumnIndex].Name.Equals(noProfitDataGridViewButtonColumn.Name))
            {
                UpdateStatus("no profit");
            }
            if (dataGridViewMap.Columns[e.ColumnIndex].Name.Equals(lowRiskDataGridViewButtonColumn.Name))
            {
                UpdateStatus("Low Risk");
            }
            if (dataGridViewMap.Columns[e.ColumnIndex].Name.Equals(middleRiskDataGridViewButtonColumn.Name))
            {
                UpdateStatus("Middle Risk");
            }
            if (dataGridViewMap.Columns[e.ColumnIndex].Name.Equals(highRiskDataGridViewButtonColumn.Name))
            {
                UpdateStatus("High Risk");
            }
        }

        private void dataGridViewMap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewMap.Columns[e.ColumnIndex].Name.Equals(noProfitDataGridViewButtonColumn.Name))
            {
                e.CellStyle.BackColor = Color.Gray;
                e.CellStyle.SelectionBackColor = Color.DarkGray;
            }
            if (dataGridViewMap.Columns[e.ColumnIndex].Name.Equals(lowRiskDataGridViewButtonColumn.Name))
            {
                e.CellStyle.BackColor = Color.Green;
                e.CellStyle.SelectionBackColor = Color.DarkGreen;
            }
            if (dataGridViewMap.Columns[e.ColumnIndex].Name.Equals(middleRiskDataGridViewButtonColumn.Name))
            {
                e.CellStyle.BackColor = Color.Blue;
                e.CellStyle.SelectionBackColor = Color.DarkBlue;
            }
            if (dataGridViewMap.Columns[e.ColumnIndex].Name.Equals(highRiskDataGridViewButtonColumn.Name))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
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
        /// Checks if there is something to build.
        /// </summary>
        private void Build()
        {
            string servername = settings.LoginData.Servername;
            string url = "";
            int level = 100;
            string status = "";
            foreach (BuildQueue buildQueue in actions.BuildQueue)
            {
                if (buildQueue.Resources.UrlParameters != null)
                {
                    int currentLevel = buildQueue.Resources.CurrentLevel;
                    if (currentLevel < level)
                    {
                        level = currentLevel;
                        url = String.Format(CultureInfo.InvariantCulture, "{0}{1}&newdid={2}", servername,
                                            buildQueue.Resources.UpgradeUrl, buildQueue.VillageId);
                        //status = buildQueue.ToString();
                        status = String.Format(CultureInfo.InvariantCulture,
                                               "Upgrading [{0}]-{1} to level {2} in Village {3}",
                                               buildQueue.BuildingId, buildQueue.Name, currentLevel + 1,
                                               buildQueue.VillageName);
                    }
                }
            }
            if (level < 100)
            {
                htmlDocument = htmlWeb.Load(url);
                UpdateStatus(status);
            }
        }

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
            listBoxMarketPlaceTasks.Items.Clear();
            UpdateListBoxTransportQueues(listBoxMarketPlaceTasks);
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
                if (settings.Ally != null)
                {
                    UpdateListBoxAlly(listBoxSettingsAlly, AllyType.Ally);
                    UpdateListBoxAlly(listBoxSettingsNap, AllyType.Nap);
                    UpdateListBoxAlly(listBoxSettingsWar, AllyType.War);
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
                ValleyType valleyType = GetValleyType(villageDetails);
                //UpdateStatus(valleyType.ToString());
                villageDetails.AddUrl(valley.VillageUrl).AddType(valleyType);
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
                                       x, y, villagesFromMap.Count, oasesFromMap.Count));
        }

        /// <summary>
        /// Gets the type of the valley.
        /// </summary>
        /// <param name="valley">The valley.</param>
        /// <returns><see cref="ValleyType"/></returns>
        private ValleyType GetValleyType(Valley valley)
        {
            foreach (Ally ally in settings.Ally)
            {
                if (ally.Id == valley.AllianceId)
                {
                    if (ally.Type == AllyType.Ally)
                    {
                        return ValleyType.AllianceAlly;
                    }
                    if (ally.Type == AllyType.Nap)
                    {
                        return ValleyType.AllianceNap;
                    }
                    return ValleyType.AllianceWar;
                }
            }
            return ValleyType.FarmLowRisk;
        }

        /// <summary>
        /// Gets the type of the valley.
        /// </summary>
        /// <param name="valley">The valley.</param>
        /// <returns><see cref="ValleyType"/></returns>
        private ValleyType GetValleyTypeNotes(Valley valley)
        {
            if (valley.ValleyType == ValleyType.FarmNoProfit ||
                valley.ValleyType == ValleyType.FarmLowRisk ||
                valley.ValleyType == ValleyType.FarmMiddleRisk ||
                valley.ValleyType == ValleyType.FarmHighRisk)
            {
                foreach (ValleyItem valleyItem in valleyTypeList.Items)
                {
                    if (valleyItem.VillageId == valley.VillageId)
                    {
                        return valleyItem.ValleyType;
                    }
                }
            }
            return valley.ValleyType;
        }

        /// <summary>
        /// Save the ally data to settings.
        /// </summary>
        /// <param name="fieldId">The field id.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="allyType">Type of the ally.</param>
        private void InsertAllyData(Control fieldId, Control fieldName, AllyType allyType)
        {
            if ((fieldName.Text.Length > 0) && (fieldId.Text.Length > 0))
            {
                Ally ally = new Ally
                    {
                        Id = Misc.String2Number(fieldId.Text.Trim()),
                        Name = fieldName.Text.Trim(),
                        Type = allyType,
                    };
                foreach (Ally list in settings.Ally)
                {
                    if (list.Id == ally.Id)
                    {
                        return;
                    }
                }
                settings.Ally.Add(ally);
                SerializeSettings();
            }
            else
            {
                MessageBox.Show("Id and Name are required!");
            }
        }

        /// <summary>
        /// Save the excluded data to settings.
        /// </summary>
        /// <param name="fieldId">The field id.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="excludedType">Type of the ally.</param>
        private void InsertExcludedData(Control fieldId, Control fieldName, ExcludedType excludedType)
        {
            if ((fieldName.Text.Length > 0) && (fieldId.Text.Length > 0))
            {
                Excluded excluded = new Excluded
                    {
                        Id = Misc.String2Number(fieldId.Text.Trim()),
                        Name = fieldName.Text.Trim(),
                        Type = excludedType,
                    };
                if (!settings.Excluded.Contains(excluded))
                {
                    settings.Excluded.Add(excluded);
                    SerializeSettings();
                }
            }
            else
            {
                MessageBox.Show("Id and Name are required!");
            }
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

        private void PopulateMap(Village village)
        {
            int centerX = village.CoordinateX;
            int centerY = village.CoordinateY;
            List<Valley> list = new List<Valley>();
            foreach (Valley valley in map.Valleys)
            {
                double distance =
                    Math.Round(Math.Sqrt(Math.Pow((valley.X - centerX), 2) + Math.Pow((valley.Y - centerY), 2)), 1);
                valley.AddDistance(distance);
                ValleyType valleyType = GetValleyTypeNotes(valley);
                valley.ValleyType = valleyType;
                if (checkBoxUnoccupiedOasis.Checked && valleyType == ValleyType.UnoccupiedOasis)
                {
                    list.Add(valley);
                }
                else if (checkBoxMapOccupiedOasis.Checked && valleyType == ValleyType.OccupiedOasis)
                {
                    list.Add(valley);
                }
                else if (checkBoxFarmsNoProfit.Checked && valleyType == ValleyType.FarmNoProfit)
                {
                    list.Add(valley);
                }
                else if (checkBoxFarmsLowRisk.Checked && valleyType == ValleyType.FarmLowRisk)
                {
                    list.Add(valley);
                }
                else if (checkBoxFarmsMiddleRisk.Checked && valleyType == ValleyType.FarmMiddleRisk)
                {
                    list.Add(valley);
                }
                else if (checkBoxFarmsHighRish.Checked && valleyType == ValleyType.FarmHighRisk)
                {
                    list.Add(valley);
                }
                else if (checkBoxAlly.Checked && valleyType == ValleyType.AllianceAlly)
                {
                    list.Add(valley);
                }
                else if (checkBoxNap.Checked && valleyType == ValleyType.AllianceNap)
                {
                    list.Add(valley);
                }
                else if (checkBoxWar.Checked && valleyType == ValleyType.AllianceWar)
                {
                    list.Add(valley);
                }
                else if (checkBoxExcludedPlayers.Checked && valleyType == ValleyType.ExcludedPlayer)
                {
                    list.Add(valley);
                }
                else if (checkBoxExcludedAlliances.Checked && valleyType == ValleyType.ExcludedAlliance)
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
            list.Sort((v1, v2) => Comparer<double>.Default.Compare(v1.Distance, v2.Distance));
            UpdateDataGridViewMap(dataGridViewMap, list);
            //if (dataGridViewMap.InvokeRequired)
            //{
            //    SetDataGridViewRallyPoint m = SetDataSource;
            //    Invoke(m, new object[] {dataGridViewMap, list});
            //}
            //else
            //{
            //    dataGridViewMap.DataSource = list;
            //}
        }

        private void PopulateRallyPoint(Village village)
        {
            Language language = languages.GetLanguage(settings.LanguageId);
            string servername = settings.LoginData.Servername;
            //http://s1.travian.com/build.php?newdid=75579&gid=16&id=39
            string url = String.Format(CultureInfo.InvariantCulture, "{0}build.php?newdid={1}&gid=16&id=39",
                                       servername, village.Id);
            htmlDocument = htmlWeb.Load(url);
            HtmlParser htmlParser = new HtmlParser(htmlDocument, language);
            List<TroopMovement> troopMovements = htmlParser.TroopMovements(village);
            //ArrayList list = new ArrayList();
            //list.AddRange(troopMovements);
            UpdateDataGridViewRallyPoint(dataGridViewRallyPoint, troopMovements);
            UpdateStatus(String.Format(CultureInfo.InvariantCulture, "Populate Rally Point in {0}", village.Name));
        }

        /// <summary>
        /// Removes the selected ally from listbox.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="type"><see cref="AllyType"/></param>
        private void RemoveSettingsAlly(ListBox field, AllyType type)
        {
            if (field.SelectedItems.Count > 0)
            {
                Ally ally = field.SelectedItem as Ally;
                if (ally != null)
                {
                    List<Ally> newList = new List<Ally>();
                    foreach (Ally oldAlly in settings.Ally)
                    {
                        if (oldAlly.Id != ally.Id)
                        {
                            newList.Add(oldAlly);
                        }
                    }
                    settings.Ally.Clear();
                    settings.Ally.AddRange(newList);
                    SerializeSettings();
                    UpdateListBoxAlly(field, type);
                }
            }
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
        /// Sends the resources ifmarketplace queue is active.
        /// </summary>
        private void SendResources()
        {
            List<MarketPlaceQueue> newQueue = new List<MarketPlaceQueue>();
            DateTime dt = new DateTime(DateTime.Now.Ticks);
            foreach (MarketPlaceQueue queue in actions.MarketPlaceQueue)
            {
                MarketPlaceCalculator calculator = new MarketPlaceCalculator(account, htmlDocument, htmlWeb, queue,
                                                                             settings, languages);
                if (queue.SendGoodsType == SendGoodsType.Repeat)
                {
                    if (calculator.TimeToSendRepeat(dt))
                    {
                        calculator.ParseUnknownDestination();
                        calculator.CalculateUnknownDestination();
                        string process = calculator.Process();
                        if (process.Length > 5)
                        {
                            UpdateStatus(process);
                        }
                        MarketPlaceQueue updated = queue;
                        updated.LastSend = dt;
                        newQueue.Add(updated);
                    }
                    else
                    {
                        newQueue.Add(queue);
                    }
                }
                else
                {
                    if (calculator.TimeToSend(dt))
                    {
                        calculator.Parse();
                        if (queue.SendGoodsType == SendGoodsType.DestinationBellowPercent)
                        {
                            calculator.Calculate();
                        }
                        if (queue.SendGoodsType == SendGoodsType.SourceOverPercent)
                        {
                            calculator.CalculateSourceOver();
                        }
                        string process = calculator.Process();
                        if (process.Length > 5)
                        {
                            UpdateStatus(process);
                            MarketPlaceQueue updated = queue;
                            updated.LastSend = dt;
                            newQueue.Add(updated);
                        }
                        else
                        {
                            newQueue.Add(queue);
                        }
                    }
                    else
                    {
                        newQueue.Add(queue);
                    }
                }
            }
            actions.MarketPlaceQueue.Clear();
            actions.MarketPlaceQueue.AddRange(newQueue);
            SerializeActions();
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
        /// Serializes the valleys that are available in datagridview.
        /// </summary>
        /// <param name="valleys">The valleys.</param>
        private void SerializeMap(IEnumerable<Valley> valleys)
        {
            using (TextWriter textWriter = new StreamWriter(ValleysXml))
            {
                using (XmlTextWriter xmlWriter = new XmlTextWriter(textWriter))
                {
                    xmlWriter.WriteProcessingInstruction(
                        "xml-stylesheet",
                        "type=\"text/xsl\" href=\"Farms.xslt\"");
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof (List<Valley>));
                    List<Valley> completeList = map.Valleys;
                    List<Valley> newList = new List<Valley>();
                    foreach (Valley valley in valleys)
                    {
                        int indexOf = completeList.IndexOf(valley);
                        if (indexOf > -1)
                        {
                            newList.Add(completeList[indexOf]);
                        }
                    }
                    xmlSerializer.Serialize(xmlWriter, newList);
                }
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

        ///// <summary>
        ///// Saves notes to XML.
        ///// </summary>
        //private void SerializeValeyTypeList()
        //{
        //    using (TextWriter textWriter = new StreamWriter(ValleyTypeListXml))
        //    {
        //        XmlSerializer xmlSerializer = new XmlSerializer(typeof (ValleyTypeList));
        //        xmlSerializer.Serialize(textWriter, valleyTypeList);
        //    }
        //}

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
                Build();
                SendResources();
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
            string servername = settings.LoginData.Servername;
            if (villages.Count == 1)
            {
                string url = String.Format(CultureInfo.InvariantCulture, "{0}karte.php", servername);
                htmlDocument = htmlWeb.Load(url);
                //<h1>Zemljevid(<span id="x">-31</span>|<span id="y">-25</span>)</h1>
                HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//h1");
                if (htmlNode != null)
                {
                    HtmlNode nodeX = htmlDocument.DocumentNode.SelectSingleNode("//span[@id='x']");
                    if (nodeX != null)
                    {
                        villages[0].CoordinateX = Misc.String2Number(nodeX.InnerText.Trim());
                    }
                    HtmlNode nodeY = htmlDocument.DocumentNode.SelectSingleNode("//span[@id='y']");
                    if (nodeY != null)
                    {
                        villages[0].CoordinateY = Misc.String2Number(nodeY.InnerText.Trim());
                    }
                }
            }
            account.UpdateVillages(villages);
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
                if (buildQueue.Level > buildQueue.Resources.CurrentLevel)
                {
                    list.Add(buildQueue);
                }
                else
                {
                    UpdateStatus("Removing " + buildQueue);
                }
            }
            actions.BuildQueue = list;
            SerializeActions();
            UpdateListBoxBuildQueues(listBoxBuildQueues);
            UpdateComboBoxVillages(comboBoxMapVillages);
            UpdateComboBoxVillages(comboBoxRallyPointVillages);
            UpdateComboBoxVillages(comboBoxBuildQueueVillages);
            UpdateComboBoxVillages(comboBoxMarketPlaceSourceVillage);
            UpdateComboBoxVillages(comboBoxMarketPlaceDestinationVillage);
            UpdateComboBoxVillages(comboBoxMarketPlaceRepeatSourceVillage);
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
            //field.SelectedItem = field.Items[0];
        }

        private void UpdateDataGridViewMap(DataGridView field, List<Valley> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetDataGridViewMap(UpdateDataGridViewMap), field, list);
                return;
            }
            field.DataSource = list;
        }

        private void UpdateDataGridViewRallyPoint(DataGridView field, List<TroopMovement> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetDataGridViewRallyPoint(UpdateDataGridViewRallyPoint), field, list);
                return;
            }
            field.DataSource = list;
        }

        private void UpdateListBoxAlly(ListBox field, AllyType type)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetListBoxStatusAlly(UpdateListBoxAlly), field, type);
                return;
            }
            field.Items.Clear();
            foreach (Ally ally in settings.Ally)
            {
                if (ally.Type == type)
                {
                    field.Items.Add(ally);
                }
            }
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

        private void UpdateListBoxTransportQueues(ListBox field)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetListBoxStatus(UpdateListBoxTransportQueues), field);
                return;
            }
            field.Items.Clear();
            foreach (MarketPlaceQueue queue in actions.MarketPlaceQueue)
            {
                field.Items.Add(queue);
            }
        }

        /// <summary>
        /// Adds item to listview of build queue.
        /// </summary>
        /// <param name="buildings">The buildings.</param>
        /// <param name="selectedVillage">The selected village.</param>
        /// <param name="level">The level.</param>
        private void UpdateQueue(Buildings buildings, Village selectedVillage, ComboBox level)
        {
            StringBuilder sb = new StringBuilder();
            string[] strings = buildings.Name.Split(' ');
            for (int i = 0; i < strings.Length - 2; i++)
            {
                sb.AppendFormat("{0} ", strings[i]);
            }
            BuildQueue buildQueue = new BuildQueue
                {
                    Level = Misc.String2Number(level.SelectedItem.ToString()),
                    Name = sb.ToString().Trim(),
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
            DateTime dt = DateTime.Now;
            textBoxStatus.Text += String.Format(CultureInfo.InvariantCulture, "{0} : {1}{2}",
                                                dt.ToString("yyyy-MM-dd HH:mm:ss"), value,
                                                Environment.NewLine);
            textBoxStatus.Select(textBoxStatus.Text.Length, 0);
            textBoxStatus.ScrollToCaret();
            labelStatus.Text = value;
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