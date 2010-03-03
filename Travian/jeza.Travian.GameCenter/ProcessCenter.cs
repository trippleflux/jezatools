using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using HtmlAgilityPack;
using HtmlDocument=HtmlAgilityPack.HtmlDocument;

namespace jeza.Travian.GameCenter
{
    public partial class ProcessCenter : Form
    {
        public ProcessCenter()
        {
            InitializeComponent();
            DeserializeSettings();
            FillLoginData();
            htmlWeb.UseCookies = true;
        }

        private void FillLoginData()
        {
            textBoxServer.Text = settings.LoginData.Servername;
            textBoxUsername.Text = settings.LoginData.Username;
            textBoxPassword.Text = settings.LoginData.Password;
        }

        private void DeserializeSettings()
        {
            using(FileStream fileStream = new FileStream("Settings.xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
                settings = (Settings)xmlSerializer.Deserialize(fileStream);
            }
        }

        private void SerializeSettings()
        {
            using (FileStream fileStream = new FileStream("Settings.xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
                xmlSerializer.Serialize(fileStream, settings);
            }
        }

        private void ProcessCenter_Load(object sender, EventArgs e)
        {
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

        private void buttonBrowserGo_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(textBoxServer.Text.Trim());
        }

        private void SetBotStatus(object sender, EventArgs e)
        {
            if (!botActive)
            {
                //SerializeSettings();
                botActive = true;
                Thread t = new Thread(StartBot) {IsBackground = true};
                t.Start();
                buttonRun.Text = "Stop";
                ChangeStatusOfElements(true);
            }
            else
            {
                botActive = false;
                UpdateStatus("Disconnecting...");
                buttonRun.Text = "Start";
                ChangeStatusOfElements(false);
            }
            //lock (stateLock)
            //{
            //    target = rng.Next(100);
            //}
        }

        private void ChangeStatusOfElements(bool status)
        {
            buttonMapUpdate.Enabled = status;
            textBoxServer.Enabled = status;
        }

        private void StartBot()
        {
            UpdateStatus("Login...");
            bool isLogedIn = Login();
            int count = 0;
            do
            {
                Thread.Sleep(10000);
                UpdateStatus(count++.ToString());
                //if (count>10)
                //{
                //    break;
                //}
            } while (botActive && isLogedIn);
            UpdateStatus("Finished");
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

        private bool Login()
        {
            bool isLogedIn = false;
            htmlDocument = htmlWeb.Load(textBoxServer.Text.Trim() + "login.php");
            //<input type="hidden" name="login" value="1267389391" />
            HtmlNode node = htmlDocument.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='login']");
            string loginValue = node.Attributes["value"].Value;
            NameValueCollection postData = new NameValueCollection(1)
                {
                    {"w", "1680%3A1050"},
                    {"login", loginValue},
                    {"name", textBoxUsername.Text.Trim()},
                    {"password", textBoxPassword.Text.Trim()},
                    {"s1.x", "35"},
                    {"s1.y", "9"},
                    {"s1", "login"}
                };
            HtmlDocument load = htmlWeb.SubmitFormValues(postData, textBoxServer.Text.Trim() + "dorf1.php");
            if (load != null)
            {
                HtmlNode nodeLogout = load.DocumentNode.SelectSingleNode("//a[@href='logout.php']");
                if (nodeLogout != null)
                {
                    isLogedIn = true;
                    UpdateStatus("Loged in...");
                }
                else
                {
                    UpdateStatus("Failed to login...");
                }
            }
            else
            {
                UpdateStatus("Failed to login [load]...");
            }
            return isLogedIn;
        }

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

        private void ProcessCenter_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
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
    }
}