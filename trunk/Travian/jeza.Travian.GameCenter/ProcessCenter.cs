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
            DeserializeSettings();
            languages = new Languages();
            DeserializeLanguage();
            htmlWeb.UseCookies = true;
            Timer timer = new Timer {Interval = 1000, Enabled = true};
            timer.Tick += TimerTick;
        }

        #region gui actions

        private void buttonBrowserGo_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(settings.LoginData.Servername);
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
                if (settings.LanguageId!=null)
                {
                    comboBoxSettingsLanguages.SelectedText = settings.LanguageId;
                }
            }
            else
            {
                SerializeSettings();
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
                    .AddUrl(valley.VillageUrl)
                    .AddType(ValleyType.Village);
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
                else
                {
                    if (valley.ValleyType == ValleyType.Village)
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
        /// Saves settnigs to XML.
        /// </summary>
        private void SerializeSettings()
        {
            using (FileStream fileStream = new FileStream(SettingsXml, FileMode.OpenOrCreate))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (Settings));
                xmlSerializer.Serialize(fileStream, settings);
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
            account.AddVillages(villages);
            UpdateComboBoxVillages(comboBoxMapVillages);
            UpdateComboBoxVillages(comboBoxRallyPointVillages);
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