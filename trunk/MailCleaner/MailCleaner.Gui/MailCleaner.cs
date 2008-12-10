using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MailCleaner.Gui
{
	public partial class MailCleaner : Form
	{
        private TcpClient mailclient;
        private NetworkStream ns;
        private StreamReader sr;
        private StreamWriter sw;

        public MailCleaner()
		{
			InitializeComponent();
		}

        private void buttonCheckMail_Click(object sender, EventArgs e)
        {
            //Thread startlogin = new Thread(new ThreadStart(loginandretr)) {IsBackground = true};
            //startlogin.Start();
            loginandretr();
        }

	    private void loginandretr()
	    {
            string response;
            string from = null;
            string subject = null;
            string date = null;
            int totmessages;

            try
            {
                mailclient = new TcpClient("pop.siol.net", 110);
            }
            catch (SocketException)
            {
                labelStatus.Text = "Unable to connect to server";
                return;
            }

            ns = mailclient.GetStream();
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);

            response = sr.ReadLine(); //Get opening POP3 banner

            sw.WriteLine("User " + "aj2506"); //Send username
            sw.Flush();

            response = sr.ReadLine();
            if (response.Substring(0, 4) == "-ERR")
            {
                labelStatus.Text = "Unable to log into server";
                return;
            }

            sw.WriteLine("Pass " + "pimpek");  //Send password
            sw.Flush();

            try
            {
                response = sr.ReadLine();
            }
            catch (IOException)
            {
                labelStatus.Text = "Unable to log into server";
                return;
            }
            if (response.Substring(0, 3) == "-ER")
            {
                labelStatus.Text = "Unable to log into server";
                return;
            }

            sw.WriteLine("LIST"); //Send stat command to get number of messages
            sw.Flush();

            response = sr.ReadLine();
            string[] nummess = response.Split(' ');
            totmessages = Convert.ToInt16(nummess[1]);
            if (totmessages > 0)
            {
                labelStatus.Text = "you have " + totmessages + " messages";
            }
            else
            {
                labelStatus.Text = "You have no messages";
            }

            ListViewItem lvi;
            ListViewItem.ListViewSubItem lvsi;
            
            listViewStatus.Items.Clear();
            listViewStatus.BeginUpdate();

            for (int i = 1; i <= totmessages; i++)
            {
                sw.WriteLine("top " + i + " 0"); //read header of each message
                sw.Flush();
                response = sr.ReadLine();

                while (true)
                {
                    response = sr.ReadLine();
                    if (response == ".")
                        break;
                    if (response.Length > 4)
                    {
                        if (response.Substring(0, 5) == "Date:")
                            date = response;
                        if (response.Substring(0, 5) == "From:")
                            from = response;
                        if (response.Length > 7)
                        {
                            if (response.Substring(0, 8) == "Subject:")
                                subject = response;
                        }
                    }
                }
                lvi = new ListViewItem();
                lvi.Text = i.ToString();
                
                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = from;
                lvi.SubItems.Add(lvsi);
                
                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = subject;
                lvi.SubItems.Add(lvsi);
                
                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = date;
                lvi.SubItems.Add(lvsi);
                
                listViewStatus.Items.Add(lvi);
            }
            listViewStatus.EndUpdate();
	    }
	}
}
