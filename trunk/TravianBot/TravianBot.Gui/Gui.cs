using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TravianBot.Framework;

namespace TravianBot.Gui
{
    public partial class Gui : Form
    {
        public Gui()
        {
            InitializeComponent();
        }

        private void Gui_Load(object sender, EventArgs e)
        {

        }

        private void FillData(AlianceData alianceData)
        {
            dataGridViewAliance.AutoGenerateColumns = true;
            dataGridViewAliance.DataSource = alianceData.Players;
        }

        private void buttonGetInfoUid_Click(object sender, EventArgs e)
        {
            string username = textBoxUid.Text.Length > 1 ? textBoxUid.Text : "kmet";

            ServerInfo serverInfo = new ServerInfo();
            LoginPageData loginPageData = new LoginPageData(serverInfo);

            bool logedIn = Misc.Login(serverInfo, loginPageData);

            if (logedIn)
            {
                textBoxStatus.Text += "Loged in...\r\n";
                string postData = String.Format("id=31&rang=1&spieler={0}&s1.x=38&s1.y=6&s1=ok", username);
                textBoxStatus.Text += postData + "\r\n";
                string pageSource = Http.SendData(serverInfo.StatistikAttack, postData, serverInfo.CookieContainer,
                                                  serverInfo.CookieCollection);
                //textBoxStatus.Text += pageSource + "\r\n";
                HtmlParser htmlParser = new HtmlParser(pageSource);
                
                PlayerData playerData = new PlayerData();
                htmlParser.ParseAttackRang(playerData, username);
                
                AlianceData alianceData = new AlianceData();
                alianceData.AddPlayerData(playerData);
                textBoxStatus.Text += playerData + "\r\n";
                
                FillData(alianceData);
            }
            else
            {
                textBoxStatus.Text += "Not loged in...\r\n";
            }
        }
    }
}
