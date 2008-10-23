#region

using System;
using System.Text.RegularExpressions;
using System.Threading;
using mshtml;
using SHDocVw;

#endregion

namespace twL
{
    public class Browser
    {
        public static HTMLDocument GetPageSource
            (String url,
             IWebBrowser2 ie)
        {
            object nullRef = null;
            ie.Navigate(url, ref nullRef, ref nullRef, ref nullRef, ref nullRef);
            WaitForComplete(ie);
            return (HTMLDocument) ie.Document;
        }


        public static HTMLDocument Login(ServerInfo si, PlayerInfo pi, InternetExplorer ie)
        {
            string name = NameFromTagAndType(ie, "input", "text");
            string pass = NameFromTagAndType(ie, "input", "password");
            //Console.WriteLine(name);
            //Console.WriteLine(pass);
            if (name == String.Empty || pass == String.Empty)
            {
                return null;
            }
            HTMLDocument myDoc = (HTMLDocument)ie.Document;
            HTMLInputElement loginUsernameTextBox = (HTMLInputElement)myDoc.all.item(name, 0);
            loginUsernameTextBox.value = pi.Username;
            HTMLInputElement loginPasswordTextBox = (HTMLInputElement)myDoc.all.item(pass, 0);
            loginPasswordTextBox.value = pi.Password;
            String loginImageButtonName = NameFromTagAndType(ie, "input", "image");
            HTMLInputElement loginImageButton = (HTMLInputElement)myDoc.all.item(loginImageButtonName, 0);
            loginImageButton.click();
            WaitForComplete(ie);
            return myDoc;
        }


        public static void WaitForComplete(IWebBrowser2 ieWAIT)
        {
            do
            {
                Thread.Sleep(500);
            } while (ieWAIT.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ie"></param>
        /// <param name="tag"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string NameFromTagAndType
            (IWebBrowser2 ie,
             string tag,
             string type)
        {
            String name = String.Empty;
            IHTMLDocument3 doc3 = (IHTMLDocument3) ie.Document;
            IHTMLElementCollection coll = doc3.getElementsByTagName(tag);
            foreach (IHTMLElement elm in coll)
            {
                if (elm.getAttribute("type", 0).ToString().ToLower() == type)
                {
                    name = elm.getAttribute("name", 0).ToString();
                    break;
                }
            }
            return name;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ie"></param>
        /// <param name="tag"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// 
        private static string ValueFromTagTypeAndName
            (IWebBrowser2 ie,
             string tag,
             string type,
             string name)
        {
            String value = String.Empty;
            IHTMLDocument3 doc3 = (IHTMLDocument3) ie.Document;
            IHTMLElementCollection coll = doc3.getElementsByTagName(tag);
            foreach (IHTMLElement elm in coll)
            {
                if (elm.getAttribute("type", 0).ToString().ToLower() == type)
                {
                    if (elm.getAttribute("name", 0).ToString() == name)
                    {
                        value = elm.getAttribute("value", 0).ToString();
                        break;
                    }
                }
            }
            return value;
        }

        public static DateTime TryToBuild(InternetExplorer ie, BuildTask bt, ServerInfo si)
        {
            throw new NotImplementedException();
        }

        public static bool IsLogenIn(HTMLDocument source, PlayerInfo pi)
        {
            pi.Uid = -1;
            Regex regPlayerID = new Regex(@"<a href=""spieler.php.uid=([0-9]{0,6})"">");
            if (regPlayerID.IsMatch(source.body.innerHTML))
            {
                Match Mc = regPlayerID.Matches(source.body.innerHTML)[0];
                pi.Uid = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
            return pi.Uid > -1 ? true : false;
        }
    }
}