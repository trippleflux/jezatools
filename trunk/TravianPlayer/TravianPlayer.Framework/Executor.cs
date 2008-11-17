#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

#endregion

namespace TravianPlayer.Framework
{
	public class Executor : IActionParser
	{
		public Executor(Game gameInfo)
		{
			this.gameInfo = gameInfo;
		}

		public Game GameInfo
		{
			get { return gameInfo; }
		}

		public TaskList Parse()
		{
			TaskList taskList = null;
			DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\attacks");

			FileInfo[] attackFiles = di.GetFiles("*.xml");
			Console.WriteLine("Found {0} Files in {1}", attackFiles.Length, di.Name);
			foreach (FileInfo attackFile in attackFiles)
			{
				StreamReader sr = new StreamReader(attackFile.FullName);
				string content = sr.ReadToEnd();
				sr.Close();
				sr.Dispose();
				XmlSendTroopsParser xmlSendTroopsParser = new XmlSendTroopsParser(content);
				taskList = xmlSendTroopsParser.Parse();
				foreach (KeyValuePair<int, Action> keyValuePair in taskList.ActionList)
				{
					int actionId = keyValuePair.Key;
					int villageId = keyValuePair.Value.GetActionParameters(actionId).VillageId;
					string unitName = keyValuePair.Value.GetActionParameters(actionId).AttackUnitName;
					int attackUnits = keyValuePair.Value.GetActionParameters(actionId).AttackUnit;
					string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", gameInfo.GetUrl("resourcesUrl"),
					                           villageId);
					string pageSource = Http.SendData(url, null, gameInfo.CookieContainer,
					                                  gameInfo.CookieCollection);
					HtmlParser htmlParser = new HtmlParser(pageSource);
					Game gameResources = htmlParser.ParseResourcesPage();
					int availableUnits = gameResources.GetVillageData(villageId).GetUnitCount(unitName);
					if (availableUnits >= attackUnits)
					{
						DateTime now = new DateTime(DateTime.Now.Ticks);
						string comment = keyValuePair.Value.GetActionParameters(actionId).Comment;
						int troopCount = keyValuePair.Value.GetActionParameters(actionId).TroopCount;
						Console.WriteLine("{2} We have {0} {1}. Attacking '{3}' with {4} {1}!",
										  availableUnits, unitName, now.ToString("yyyy-MM-dd HH:mm:ss"), comment, troopCount);

						Random rnd = new Random();
						Int32 parA = rnd.Next(10001, 99999);
						StringBuilder troops = new StringBuilder();
						int unitId = keyValuePair.Value.GetActionParameters(actionId).AttackUnit;
						for (int t = 0; t < 11; t++)
						{
							troops.AppendFormat("&t{0}={1}", (t + 1), t == unitId ? troopCount : 0);
						}
						String buttonId =
							String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19));
						int attackType = keyValuePair.Value.GetActionParameters(actionId).AttackType;
						int destinationX = keyValuePair.Value.GetActionParameters(actionId).CoordX;
						int destinationY = keyValuePair.Value.GetActionParameters(actionId).CoordY;
						String postData = String.Format(CultureInfo.InvariantCulture,
							              "id=39&a={0}&c={1}&kid={2}{3}{4}",
							              parA,
							              attackType,
							              Misc.ConvertXY(destinationX, destinationY),
							              troops,
							              buttonId);

						string attackurl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", gameInfo.GetUrl("sendUnitsUrl"),
						   villageId);
						Http.SendData(attackurl, postData, gameInfo.CookieContainer, gameInfo.CookieCollection);

					}
					Thread.Sleep(2000);
				}
			}
			return taskList;
		}

		private readonly Game gameInfo;
	}
}