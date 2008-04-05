using System;
using System.Threading;
using System.Timers;
using mshtml;
using SHDocVw;

namespace jcTBot
{
	internal class Program
	{
		private static InternetExplorer ie = new InternetExplorerClass();

		public static int Main(string[] args)
		{
			Console.WriteLine("IE");
			object nil = null;
			String url = @"http://s3.travian.si/login.php";
			ie.Navigate(url, ref nil, ref nil, ref nil, ref nil);
			WaitForComplete(ie);

			String name = Find.TextBoxName(ie, "text");
			Console.WriteLine(name);

			String value = Find.TextBoxValue(ie, "text", name);
			Console.WriteLine(value);

			HTMLDocument myDoc;
			myDoc = (HTMLDocument)ie.Document;

			HTMLInputElement loginTextBox = (HTMLInputElement)myDoc.all.item(name, 0);
			loginTextBox.value = "Jezonsky123";

			String newValue = Find.TextBoxValue(ie, "text", name);
			Console.WriteLine(newValue);

			//Timer timer = new Timer(new TimerCallback(Tick));
			System.Timers.Timer myTimerBrowse = new System.Timers.Timer();
			myTimerBrowse.Elapsed += new ElapsedEventHandler(ChangePages);
			myTimerBrowse.Interval = 5000;
			myTimerBrowse.Start();

			int i = 0;
			do
			{
				Thread.Sleep(1000);
				i++;
			} while (i < 100);

			/*
			// google html source for the I'm Feeling Lucky Button:
			// <INPUT type=submit value="I'm Feeling Lucky" name=btnI>
			//
			HTMLInputElement btnSearch = (HTMLInputElement)myDoc.all.item("btnI", 0);
			btnSearch.click();
			 * */

			Console.WriteLine("END");
			return 0;
		}

		private static void WaitForComplete(InternetExplorer ie)
		{
			int i = 0;
			do
			{
				Console.WriteLine("-" + i++);
				Thread.Sleep(500);
			} while (ie.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE);
		}

		static void Tick(object state)
		{
			Console.WriteLine("Ticked at {0:HH:mm:ss.fff}", DateTime.Now);
		}

		private static void ChangePages(object sender, ElapsedEventArgs e)
		{
			Console.WriteLine("Ticked at {0:HH:mm:ss.fff}", DateTime.Now);
			object nil = null;
			String url = @"http://s3.travian.si/login.php";
			ie.Navigate(url, ref nil, ref nil, ref nil, ref nil);
			WaitForComplete(ie);

			String name = Find.TextBoxName(ie, "text");
			Console.WriteLine(name);

			String value = Find.TextBoxValue(ie, "text", name);
			Console.WriteLine(value);
		}
	}
}