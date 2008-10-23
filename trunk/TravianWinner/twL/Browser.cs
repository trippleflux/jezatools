#region

using System;
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
            Console.WriteLine(name);
            Console.WriteLine(pass);
            return (HTMLDocument) ie.Document;
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

        public static void TryToBuild(InternetExplorer ie, BuildTask bt, ServerInfo si)
        {
            throw new NotImplementedException();
        }
    }
}