using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using mshtml;
using SHDocVw;

namespace jcAttackChecker
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Timers.Timer myTimerBrowse = new System.Timers.Timer();
			myTimerBrowse.Elapsed += new ElapsedEventHandler(CheckForAttack);
			myTimerBrowse.Interval = 5000;
			myTimerBrowse.Start();

			int i = 0;
			do
			{
				Thread.Sleep(10000);
				i++;
			} while (i < 2);
		}

		/// <summary>
		/// Wait until document loads
		/// </summary>
		/// <param name="ie"><see cref="InternetExplorer"/></param>
		/// 
		private static void WaitForComplete(InternetExplorer ie)
		{
			do
			{
				Thread.Sleep(500);
			} while (ie.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE);
		}

		/// <summary>
		/// Checks if attack is in progress
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"><see cref="ElapsedEventArgs"/></param>
		/// 
		private static void CheckForAttack(object sender, ElapsedEventArgs e)
		{
			Console.WriteLine("Check at {0:HH:mm:ss.fff}", DateTime.Now);
			InternetExplorer ie = new InternetExplorerClass();
			object nil = null;
			String url = @"http://s3.travian.si/login.php";
			ie.Navigate(url, ref nil, ref nil, ref nil, ref nil);
			WaitForComplete(ie);

			String name = "ec1235";
			name = GetName(ie, name, "text");
			String pass = "ec1235";
			pass = GetName(ie, pass, "password");

			Console.WriteLine(name);
			Console.WriteLine(pass);
			HTMLDocument myDoc;
			myDoc = (HTMLDocument)ie.Document;

			HTMLInputElement loginTextBox = (HTMLInputElement)myDoc.all.item(name, 0);
			loginTextBox.value = "jezonsky";
			HTMLInputElement passwordTextBox = (HTMLInputElement)myDoc.all.item(pass, 0);
			passwordTextBox.value = "pimpek";
			Console.WriteLine("Click Button...");
			HTMLInputElement btnLogin = (HTMLInputElement)myDoc.all.item("s1", 0);
			
			Console.WriteLine(btnLogin.type);
			btnLogin.click();
			Thread.Sleep(3000);

			IHTMLDocument3 doc3 = (IHTMLDocument3)ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName("a");
			Console.WriteLine(coll.length);
			//foreach (IHTMLElement elm in coll)
			//{
			//    Console.WriteLine(elm.title);
			//    //if (elm.getAttribute("type", 0).ToString().ToLower() == type)
			//    //{
			//    //    name = elm.getAttribute("name", 0).ToString();
			//    //    break;
			//    //}
			//}
			//IHTMLDocument2 doc2 = (IHTMLDocument2)ie.Document;
			//Console.WriteLine(doc2.body.innerText);
			//MatchCollection myMatchCollection = Regex.Matches(body, @"att1.gif");
			//if (myMatchCollection.Count > 0)
			//{
			//    Console.WriteLine("Attack!!!");
			//}
		}

		private static string GetName(InternetExplorer ie, string name, string type)
		{
			IHTMLDocument3 doc3 = (IHTMLDocument3)ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName("input");
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
	}
}
