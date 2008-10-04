#region

using System;
using System.Data;
using System.Globalization;
using log4net;

#endregion

namespace Library
{
	public class Task
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof (Task));



		public void CheckTasks(ServerData sd)
		{
			DataTable dt = SQL.GetTaskList(sd);
			foreach (DataRow row in dt.Rows)
			{
				string pageSource = GetPageSource(Int32.Parse(row[2].ToString().Trim()), sd);
				if (!BuildInProgres(pageSource, sd, row))
				{
					SelectTask(row, sd, pageSource);
				}
			}
		}



		private static bool BuildInProgres
			(string pageSource,
			 ServerData sd,
			 DataRow row)
		{
			Parser parser = new Parser();
			String timeToComplete = parser.TimeToCompleteBuilding(pageSource);
			if (timeToComplete.Equals("0:00:00"))
			{
				return false;
			}
			int taskId = Int32.Parse(row[0].ToString().Trim());
			SQL.UpdateNextCheckForTask(sd, taskId, tbLibrary.AddSecondsToTime(timeToComplete.Split(':')));
			return true;
		}



		/// <summary>
		/// Select apropriate task
		/// </summary>
		private static void SelectTask
			(DataRow row,
			 ServerData sd,
			 string pageSource)
		{
			int taskId = Int32.Parse(row[1].ToString().Trim());
			int buildLevel = Int32.Parse(row[5].ToString().Trim());

			switch (taskId)
			{
				case (int) tbLibrary.Tasks.BuildResources:
				{
					Production production = Parser.GetProductionForVillage(pageSource);
					for (int i = 0; i < 4; i++)
					{
						tbLibrary.ProductionForVillage lowestProduction = tbLibrary.GetProduction(production, i, true);
						Upgrade upgrade = Parser.GetLowestResource(pageSource, lowestProduction, sd);
						if (buildLevel > upgrade.UpgradeLevel)
						{
							UpgradeId(sd, upgrade, row);
							break;
						}
					}
					break;
				}
				case (int) tbLibrary.Tasks.BuildResourcesNoCrop:
				{
					Production production = Parser.GetProductionForVillage(pageSource);
					for (int i = 0; i < 3; i++)
					{
						tbLibrary.ProductionForVillage lowestProduction = tbLibrary.GetProduction(production, i, true);
						Upgrade upgrade = Parser.GetLowestResource(pageSource, lowestProduction, sd);
						if (buildLevel > upgrade.UpgradeLevel)
						{
							UpgradeId(sd, upgrade, row);
							break;
						}
					}
					break;
				}
				case (int) tbLibrary.Tasks.WoodLand:
				{
					Upgrade upgrade = Parser.GetLowestResource(pageSource, tbLibrary.ProductionForVillage.Wood, sd);
					if (buildLevel > upgrade.UpgradeLevel)
					{
						UpgradeId(sd, upgrade, row);
						break;
					}
					break;
				}
				case (int) tbLibrary.Tasks.ClayPit:
				{
					Upgrade upgrade = Parser.GetLowestResource(pageSource, tbLibrary.ProductionForVillage.Clay, sd);
					if (buildLevel > upgrade.UpgradeLevel)
					{
						UpgradeId(sd, upgrade, row);
						break;
					}
					break;
				}
				case (int) tbLibrary.Tasks.IronMine:
				{
					Upgrade upgrade = Parser.GetLowestResource(pageSource, tbLibrary.ProductionForVillage.Iron, sd);
					if (buildLevel > upgrade.UpgradeLevel)
					{
						UpgradeId(sd, upgrade, row);
						break;
					}
					break;
				}
				case (int) tbLibrary.Tasks.CropLand:
				{
					Upgrade upgrade = Parser.GetLowestResource(pageSource, tbLibrary.ProductionForVillage.Crop, sd);
					if (buildLevel > upgrade.UpgradeLevel)
					{
						UpgradeId(sd, upgrade, row);
						break;
					}
					break;
				}
				case (int) tbLibrary.Tasks.BuildingId:
				{
					Upgrade upgrade = new Upgrade();
					upgrade.UpgradeId = Int32.Parse(row[9].ToString().Trim());
					UpgradeId(sd, upgrade, row);
					break;
				}
				default:
				{
					Log.ErrorFormat("Task '{0}' not implemented!", taskId);
					break;
				}
			}
		}



		private static void UpgradeId
			(ServerData sd,
			 Upgrade upgrade,
			 DataRow row)
		{
			int villageId = Int32.Parse(row[2].ToString().Trim());
			String villageName = row[8].ToString().Trim();
			int taskID = Int32.Parse(row[0].ToString().Trim());
			String url = String.Format("{0}build.php?id={1}&newdid={2}", sd.Servername, upgrade.UpgradeId, villageId);
			Browser b = new Browser();
			String pageSource = b.GetPageSource(url);
			Parser parser = new Parser();
			Upgrade u = new Upgrade();
			parser.UpgradeLink(u, pageSource);
			Console.WriteLine("Checking '{0}' in Village '{1}'", u.UpgradeFullName, villageName);
			if (u.UpgradeAvailable)
			{
				string[] buildTime = parser.BuildTime(pageSource).Split(':');
				SQL.UpdateNextCheckForTask(sd, taskID, tbLibrary.AddSecondsToTime(buildTime));
				b.GetPageSource(sd.Servername + u.UpgradeUrl);
				String logStr = String.Format("Upgrading '{0}' in Village '{1}' to level {2}", u.UpgradeFullName, villageName,
				                              u.UpgradeLevel + 1);
				Console.WriteLine(logStr);
				Log.InfoFormat(logStr);
			}
			else
			{
				BuildCost bc = parser.BuildCost(pageSource);
				int wood = (bc.AvailableWood - bc.NeededWood)/bc.WoodPerHour;
				int clay = (bc.AvailableClay - bc.NeededClay)/bc.ClayPerHour;
				int iron = (bc.AvailableIron - bc.NeededIron)/bc.IronPerHour;
				int crop = (bc.AvailableCrop - bc.NeededCrop)/bc.CropPerHour;
				int[] list = {wood, clay, iron, crop};
				tbLibrary.bubble_sort_generic(list);
				DateTime dt = new DateTime(DateTime.Now.Ticks);
				SQL.UpdateNextCheckForTask(sd, taskID, dt.AddSeconds(Math.Abs(list[0]*3600)));
			}
		}



		private static string GetPageSource
			(int villageId,
			 ServerData sd)
		{
			Browser browser = new Browser();
			string pageUrl = String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php?newdid={1}", sd.Servername, villageId);
			return browser.GetPageSource(pageUrl);
		}
	}
}