#region

using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TravianBot.Framework;

#endregion

namespace TravianBot.Gui
{
    public partial class Gui : Form
    {
        public Gui()
        {
            InitializeComponent();
        }

        private void Gui_Load
            (object sender,
             EventArgs e)
        {
        }

        private void FillData(AlianceData alianceData)
        {
            dataGridViewAliance.AutoGenerateColumns = true;
            dataGridViewAliance.DataSource = alianceData.Players;
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
                AlianceData alianceData = new AlianceData();
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
             AlianceData alianceData)
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

            alianceData.AddPlayerData(playerData);
            textBoxStatus.Text += playerData + "\r\n";
        }

        private void buttonGetInfoAliance_Click
            (object sender,
             EventArgs e)
        {
            string alianceId = textBoxAlianceId.Text.Length > 1 ? textBoxAlianceId.Text : "1";

            ServerInfo serverInfo = new ServerInfo();
            AlianceData alianceData = new AlianceData();
            LoginPageData loginPageData = new LoginPageData(serverInfo);

            bool logedIn = Misc.Login(serverInfo, loginPageData);

            if (logedIn)
            {
                textBoxStatus.Text += "Loged in...\r\n";
                string pageSource = Http.SendData(serverInfo.AlianceUrl + alianceId, null, serverInfo.CookieContainer,
                                                  serverInfo.CookieCollection);
                ParseMembersStats(serverInfo, pageSource, alianceData);
                FillData(alianceData);
            }
            else
            {
                textBoxStatus.Text += "Not loged in...\r\n";
            }
        }

        private void ParseMembersStats(ServerInfo serverInfo,
                                       string pageSource,
                                       AlianceData alianceData)
        {
            //<td align="right">1.</td><td class="s7"><a href="spieler.php?uid=9446">NoBody.</a></td>
            //<td align=""right"">([0-9{0,2}]).</td><td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>
            const string patternAlianceMembers = @"<td align=""right"">([0-9{0,2}]).</td><td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>";
            MatchCollection alianceMembersCollection =
                Regex.Matches(pageSource, patternAlianceMembers);
            for (int i = 0; i < alianceMembersCollection.Count; i++)
            {
                int number = Int32.Parse(alianceMembersCollection[i].Groups[1].Value.Trim());
                string username = alianceMembersCollection[i].Groups[4].Value.Trim();
                GetStats(serverInfo, number, username, alianceData);
            }
        }
    }
}