#region

using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using TravianBot.Framework;

#endregion

namespace TravianBot.Gui
{
    public partial class Gui : Form
    {
        private AlianceData alianceData;

        public Gui()
        {
            InitializeComponent();
        }

        private void Gui_Load
            (object sender,
             EventArgs e)
        {
        }

        private void FillData(AlianceData data)
        {
            dataGridViewAliance.AutoGenerateColumns = true;
            dataGridViewAliance.DataSource = data.Players;
        }

        private void buttonGetInfoUid_Click
            (object sender,
             EventArgs e)
        {
            string username = textBoxUid.Text.Length > 1 ? textBoxUid.Text : "kmet";

            ServerInfo serverInfo = new ServerInfo();
            LoginPageData loginPageData = new LoginPageData(serverInfo);

            bool logedIn = Misc.Login(serverInfo, loginPageData);

            if (logedIn)
            {
                textBoxStatus.Text += "Loged in...\r\n";
                alianceData = new AlianceData();
                GetStats(serverInfo, 1, username, alianceData);
                FillData(alianceData);
            }
            else
            {
                textBoxStatus.Text += "Not loged in...\r\n";
            }
        }

        private void GetStats
            (ServerInfo serverInfo,
             int number,
             string username,
             AlianceData data)
        {
            PlayerData playerData = new PlayerData {Number = number};

            string postData = String.Format("id=31&rang=1&spieler={0}&s1.x=38&s1.y=6&s1=ok", username);
            textBoxStatus.Text += postData + "\r\n";
            string pageSource = Http.SendData(serverInfo.StatistikAttack, postData, serverInfo.CookieContainer,
                                              serverInfo.CookieCollection);
            HtmlParser htmlParser = new HtmlParser(pageSource);
            htmlParser.ParseAttackRang(playerData, username);

            postData = String.Format("id=32&rang=1&spieler={0}&s1.x=38&s1.y=6&s1=ok", username);
            textBoxStatus.Text += postData + "\r\n";
            pageSource = Http.SendData(serverInfo.StatistikDefense, postData, serverInfo.CookieContainer,
                                       serverInfo.CookieCollection);
            htmlParser = new HtmlParser(pageSource);
            htmlParser.ParseDefenseRang(playerData, username);

            postData = String.Format("rang=1&spieler={0}&s1.x=38&s1.y=6&s1=ok", username);
            pageSource = Http.SendData(serverInfo.StatistikRang, postData, serverInfo.CookieContainer,
                                       serverInfo.CookieCollection);
            htmlParser = new HtmlParser(pageSource);
            htmlParser.ParseRang(playerData, username);

            data.AddPlayerData(playerData);
            textBoxStatus.Text += playerData + "\r\n";
        }

        private void buttonGetInfoAliance_Click
            (object sender,
             EventArgs e)
        {
            string alianceId = textBoxAlianceId.Text.Length > 1 ? textBoxAlianceId.Text : "1";
            string[] allyIds = alianceId.IndexOf(',') > -1 ? alianceId.Split(',') : new[] {alianceId};
            ServerInfo serverInfo = new ServerInfo();
            alianceData = new AlianceData();
            LoginPageData loginPageData = new LoginPageData(serverInfo);

            bool logedIn = Misc.Login(serverInfo, loginPageData);

            if (logedIn)
            {
                textBoxStatus.Text += "Loged in...\r\n";
                foreach (string allyId in allyIds)
                {
                    string pageSource = Http.SendData(serverInfo.AlianceUrl + allyId, null, serverInfo.CookieContainer,
                                                      serverInfo.CookieCollection);
                    ParseMembersStats(serverInfo, pageSource, alianceData);
                    FillData(alianceData);
                }
            }
            else
            {
                textBoxStatus.Text += "Not loged in...\r\n";
            }
        }

        private void ParseMembersStats(ServerInfo serverInfo,
                                       string pageSource,
                                       AlianceData data)
        {
            int delay = Int32.Parse(comboBoxDelay.Text);
            //<td align="right">1.</td><td class="s7"><a href="spieler.php?uid=9446">NoBody.</a></td>
            //<td align=""right"">([0-9{0,2}]).</td><td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>
            const string patternAlianceMembers =
                @"<td align=""right"">([0-9]{0,3}).</td><td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>";
            MatchCollection alianceMembersCollection =
                Regex.Matches(pageSource, patternAlianceMembers);
            int alianceMembers = alianceMembersCollection.Count;
            textBoxStatus.Text += "Found " + alianceMembers + " aliance members...\r\n";
            progressBarStatus.Maximum = alianceMembers;
            progressBarStatus.Value = progressBarStatus.Minimum;
            for (int i = 0; i < alianceMembers; i++)
            {
                int number = Int32.Parse(alianceMembersCollection[i].Groups[1].Value.Trim());
                string username = alianceMembersCollection[i].Groups[4].Value.Trim();
                GetStats(serverInfo, number, username, data);
                Thread.Sleep(delay);
                //this checking is automatically done as stated in the Ref Documentation 
                //but it does not work , BUGssssss 
                //so we have to do it shhhhh .... 
                if (progressBarStatus.Value == progressBarStatus.Maximum)
                {
                    progressBarStatus.Value = progressBarStatus.Minimum;
                }
                progressBarStatus.PerformStep();
            }
        }

        private void buttonSaveStats_Click(object sender, EventArgs e)
        {
            DateTime now = new DateTime(DateTime.Now.Ticks);
            string filename = string.Format("{0}_{1}", now.ToString("yyyyMMddHHmmss"), textBoxSaveStats.Text);
            const string piText = "type=\"text/xsl\" href=\"StatsTransform.xslt\"";
            XmlWriterSettings settings = new XmlWriterSettings {Indent = true};
            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                if (writer != null)
                {
                    writer.WriteProcessingInstruction("xml-stylesheet", piText);
                    writer.WriteStartElement("stats");
                    if (alianceData != null)
                    {
                        if (alianceData.Players != null)
                        {
                            foreach (PlayerData playerData in alianceData.Players)
                            {
                                writer.WriteStartElement("player");
                                if (playerData != null)
                                {
                                    writer.WriteElementString("name", playerData.Name);
                                    writer.WriteElementString("aliance", playerData.Aliance);
                                    writer.WriteElementString("attackpoints", playerData.AttackPoints.ToString());
                                    writer.WriteElementString("attackrang", playerData.AttackRang.ToString());
                                    writer.WriteElementString("defensepoints", playerData.DefensePoints.ToString());
                                    writer.WriteElementString("defenserang", playerData.DefenseRang.ToString());
                                    writer.WriteElementString("rang", playerData.Rang.ToString());
                                    writer.WriteElementString("population", playerData.Population.ToString());
                                    writer.WriteElementString("villagecount", playerData.VillageCount.ToString());
                                }
                                writer.WriteEndElement();
                            }
                        }
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
            }
        }
    }
}