#region

using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

#endregion

namespace MailCleaner.Gui
{
    public partial class MailCleaner : Form
    {
        private TcpClient tcpMailClient;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;

        public MailCleaner()
        {
            InitializeComponent();
        }

        private void buttonCheckMail_Click
            (object sender,
             EventArgs e)
        {
            //Thread startlogin = new Thread(new ThreadStart(ReadMail)) {IsBackground = true};
            //startlogin.Start();
            ReadMail();
        }

        private void ReadMail()
        {
            string messageFrom = null;
            string messageSubject = null;
            string messageDate = null;
            string messageContent = null;

            const string pop3MailServer = "pop.siol.net";
            const string username = "aj2506";
            const string password = "pimpek";
            try
            {
                tcpMailClient = new TcpClient(pop3MailServer, 110);
            }
            catch (SocketException)
            {
                labelStatus.Text = "Unable to connect to server";
                return;
            }

            networkStream = tcpMailClient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);

            streamReader.ReadLine(); //Get opening POP3 banner

            streamWriter.WriteLine("User " + username); //Send username
            streamWriter.Flush();

            string streamResponse = streamReader.ReadLine();
            if (streamResponse.Substring(0, 4) == "-ERR")
            {
                labelStatus.Text = "Unable to log into server";
                return;
            }

            streamWriter.WriteLine("Pass " + password); //Send password
            streamWriter.Flush();

            try
            {
                streamResponse = streamReader.ReadLine();
            }
            catch (IOException)
            {
                labelStatus.Text = "Unable to log into server";
                return;
            }
            if (streamResponse.Substring(0, 3) == "-ER")
            {
                labelStatus.Text = "Unable to log into server";
                return;
            }

            streamWriter.WriteLine("LIST"); //Send stat command to get number of messages
            streamWriter.Flush();

            streamResponse = streamReader.ReadLine();
            string[] numberOfMessages = streamResponse.Split(' ');
            int totalNumberOfMessages = Convert.ToInt16(numberOfMessages[1]);
            if (totalNumberOfMessages > 0)
            {
                labelStatus.Text = "You have " + totalNumberOfMessages + " new messages";
            }
            else
            {
                labelStatus.Text = "You have no new messages";
            }

            ListViewItem listViewItem;

            listViewStatus.Items.Clear();
            listViewStatus.BeginUpdate();

            for (int i = 1; i <= totalNumberOfMessages; i++)
            {
                //streamWriter.WriteLine("top " + i + " 0");
                string mNo = i.ToString("0");
                streamWriter.WriteLine("retr " + mNo + "\r\n");
                streamWriter.Flush();
                streamReader.ReadLine();
                string completeContent = "";

                while (true)
                {
                    streamResponse = streamReader.ReadLine();
                    completeContent = completeContent + "\r\n" + streamResponse;
                    if (streamResponse == ".")
                    {
                        break;
                    }
                    if (streamResponse.Length > 4)
                    {
                        if (streamResponse.Substring(0, 5) == "Date:")
                        {
                            messageDate = streamResponse;
                        }
                        if (streamResponse.Substring(0, 5) == "From:")
                        {
                            messageFrom = streamResponse;
                        }
                        if (streamResponse.Length > 7)
                        {
                            if (streamResponse.Substring(0, 8) == "Subject:")
                            {
                                messageSubject = streamResponse;
                            }
                        }
                    }
                }
                int nMimeVer = completeContent.ToLower().IndexOf("mime-version");
                int nFirstBlankLine = completeContent.IndexOf("\r\n\r\n");

                string MailHeader;
                string MailBody;
                if (nMimeVer >= 0 && nMimeVer > nFirstBlankLine)
                {
                    MailHeader = completeContent.Substring(0, nMimeVer);
                    MailBody = completeContent.Substring(nMimeVer);
                }
                else
                {
                    if (nFirstBlankLine > 0)
                    {
                        MailHeader = completeContent.Substring(0, nFirstBlankLine);
                        MailHeader += "\r\n\r\n";
                        MailBody = completeContent.Substring(nFirstBlankLine);
                    }
                    else
                        MailHeader = MailBody = completeContent;
                }

                listViewItem = new ListViewItem { Text = i.ToString(), Tag = MailBody};

                ListViewItem.ListViewSubItem listViewSubItem = new ListViewItem.ListViewSubItem {Text = messageFrom};
                listViewItem.SubItems.Add(listViewSubItem);

                listViewSubItem = new ListViewItem.ListViewSubItem {Text = messageSubject};
                listViewItem.SubItems.Add(listViewSubItem);

                listViewSubItem = new ListViewItem.ListViewSubItem {Text = messageDate};
                listViewItem.SubItems.Add(listViewSubItem);

                listViewStatus.Items.Add(listViewItem);
            }

            listViewStatus.EndUpdate();
            tcpMailClient.Close();
        }

        private void listViewStatus_ItemSelectionChanged
            (object sender,
             ListViewItemSelectionChangedEventArgs e)
        {
        }

        private void listViewStatus_ItemActivate
            (object sender,
             EventArgs e)
        {
            ListView listView = (ListView) sender;
            string content = listView.SelectedItems[0].Tag.ToString();
            textBoxMailMessage.Text = content;
        }
    }
}