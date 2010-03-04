﻿using System;
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

namespace jeza.Travian.GameCenter
{
    public partial class ProcessCenter : Form
    {
        public ProcessCenter()
        {
            InitializeComponent();
            DeserializeSettings();
            htmlWeb.UseCookies = true;
            account = new Account();
            map = new Map();
        }

        #region gui actions

        private void buttonBrowserGo_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(settings.LoginData.Servername);
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
            Login loginData = settings.LoginData;
            loginData.Servername = textBoxServer.Text.Trim();
            loginData.Username = textBoxUsername.Text.Trim();
            loginData.Password = textBoxPassword.Text.Trim();
            SerializeSettings();
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
        /// Load settings from XML.
        /// </summary>
        private void DeserializeSettings()
        {
            using (FileStream fileStream = new FileStream("Settings.xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (Settings));
                settings = (Settings) xmlSerializer.Deserialize(fileStream);
            }
        }

        private void GetMapInfo(Village selectedVillage)
        {
            map.Neighborhood.Clear();
            buttonMapUpdate.Enabled = false;
            int x = selectedVillage.CoordinateX;
            int y = selectedVillage.CoordinateY;
            int distance = Misc.String2Number(textBoxMapDistance.Text.Trim());
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
                    int size = 7 * i;
                    for (int j = (1 - distance); j < distance; j++)
                    {
                        for (int k = (1 - distance); k < distance; k++)
                        {
                            int distX = size * k;
                            int distY = size * j;
                            GetMapInfoAt(x + distX, y + distY);
                        }
                    }
                }
            }
            UpdateStatus(String.Format(CultureInfo.InvariantCulture, "Map {0}", map.Neighborhood.Count));
            ArrayList list = new ArrayList();
            list.AddRange(map.Neighborhood);
            dataGridViewMap.DataSource = list;
            buttonMapUpdate.Enabled = true;
        }

        private void GetMapInfoAt(int x, int y)
        {
            string servername = settings.LoginData.Servername;
            UpdateStatus(String.Format(CultureInfo.InvariantCulture, "Get villages around ({0}|{1})", x, y));
            string url = String.Format(CultureInfo.InvariantCulture, "{0}karte.php?xp={1}&yp={2}&s1.x=32&s1.y=11&s1=ok",
                                       servername, x, y);
            htmlDocument = htmlWeb.Load(url);
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            List<Neighborhood> neighborhood = htmlParser.GetVillagesFromMap();
            UpdateStatus(String.Format(CultureInfo.InvariantCulture, "Found {0} villages", neighborhood.Count));
            if (checkBoxOases.Checked)
            {
                List<Oases> oases = htmlParser.GetOasesFromMap();
                UpdateStatus(String.Format(CultureInfo.InvariantCulture, "Found {0} oases", oases.Count));
            }
            map.AddVillages(neighborhood);
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

        /// <summary>
        /// Saves settnigs to XML.
        /// </summary>
        private void SerializeSettings()
        {
            using (FileStream fileStream = new FileStream("Settings.xml", FileMode.Open))
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
                UpdateStatus("Disconnecting...");
                buttonRun.Text = "Start";
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
                UpdateGuiElements();
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

        /// <summary>
        /// Updates the account info.
        /// </summary>
        private void UpdateAccountInfo()
        {
            UpdateStatus("UpdateAccountInfo");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            List<Village> villages = htmlParser.GetAvailableVillages();
            account.AddVillages(villages);
        }

        /// <summary>
        /// Updates the GUI elements.
        /// </summary>
        private void UpdateGuiElements()
        {
            UpdateStatus("UpdateGuiElements");
            comboBoxMapVillages.Items.Clear();
            foreach (Village village in account.Villages)
            {
                comboBoxMapVillages.Items.Add(village);
            }
            comboBoxMapVillages.SelectedItem = comboBoxMapVillages.Items[0];
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