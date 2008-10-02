#region

using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

#endregion

namespace Library
{
	public class Task
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof (Task));
		private String buildId = "build.php?id=39";



		public void CheckTasks(ServerData sd)
		{
			SqlCommand command = new SqlCommand("GetTaskList", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = sd.PlayerUID;
			command.Parameters.Add("@NextCheck", SqlDbType.DateTime).Value = DateTime.Now;
			sd.Connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			if (reader != null)
			{
				while (reader.Read())
				{
					if (Int32.Parse(reader[7].ToString().Trim()) != 1)
					{
						continue;
					}
					buildId = "build.php?id=39";
					Production p = null;
					for (int i = 0; i < sd.ProductionList.Count; i++)
					{
						p = sd.ProductionList[i] as Production;
						if (p != null)
						{
							Log.DebugFormat("p[{1}]={0}", p.ToString(), i);
							Int32 villageId = Int32.Parse(reader[2].ToString().Trim());
							if (villageId == p.VillageId)
							{
								buildId = reader[3].ToString().Trim();
								break;
							}
						}
					}

					Int32 task = Int32.Parse(reader[1].ToString().Trim());
					if (p != null)
					{
						String url = String.Format("{0}dorf1.php?newdid={1}", sd.Servername, p.VillageId);
						Browser b = new Browser();
						String pageSource = b.GetPageSource(url);
						Parser parser = new Parser();
						string timeToComplete = parser.TimeToNextCheck(pageSource);
						//Console.WriteLine("*** " + timeToComplete);
						int taskID = Int32.Parse(reader[0].ToString().Trim());
						if (timeToComplete == "0:00:00")
						{
							ExecuteTask(sd, p, task, taskID);
						}
						else
						{
							string[] buildTime = timeToComplete.Split(':');
							//SQL.UpdateNextCheckForTask(sd, taskID, tbLibrary.GetDt(buildTime));
							//SqlCommand sqlCommand = new SqlCommand("UpdateNextCheckForTask", sd.Connection);
							//sqlCommand.CommandType = CommandType.StoredProcedure;
							//sqlCommand.Parameters.Clear();
							//sqlCommand.Parameters.Add("@TaskId", SqlDbType.Int).Value = taskID;
							//sqlCommand.Parameters.Add("@NextCheck", SqlDbType.DateTime).Value = tbLibrary.GetDt(buildTime);
							//sqlCommand.ExecuteNonQuery();
						}
					}
				}
			}
			sd.Connection.Close();
		}



		private void ExecuteTask
			(ServerData sd,
			 Production p,
			 int task,
			 int taskID)
		{
			switch (task)
			{
				case (int) tbLibrary.Tasks.BuildResources:
				{
					//String url = sd.Servername + buildId + "&newdid=" + p.VillageId;
					int wood = p.WoodPerHour;
					int clay = p.ClayPerHour;
					int iron = p.IronPerHour;
					int crop = p.CropPerHour;
					int[] list = {wood, clay, iron, crop};
					tbLibrary.bubble_sort_generic(list);
					AutoUpgradeResource(sd, p, wood, clay, iron, list, taskID);
					break;
				}
				case (int) tbLibrary.Tasks.BuildResourcesNoCrop:
				{
					//String url = sd.Servername + buildId + "&newdid=" + p.VillageId;
					int wood = p.WoodPerHour;
					int clay = p.ClayPerHour;
					int iron = p.IronPerHour;
					int[] list = {wood, clay, iron};
					tbLibrary.bubble_sort_generic(list);
					//for (int i = 0; i < list.Length; i++)
					//{
					//    Console.WriteLine("wood={0}, clay={1}, iron={2}, list[{3}]={4}", wood, clay, iron, i, list[i]);
					//}
					AutoUpgradeResource(sd, p, wood, clay, iron, list, taskID);
					break;
				}
				case (int) tbLibrary.Tasks.WoodLand:
				{
					break;
				}
				case (int) tbLibrary.Tasks.ClayPit:
				{
					break;
				}
				case (int) tbLibrary.Tasks.IronMine:
				{
					break;
				}
				case (int) tbLibrary.Tasks.CropLand:
				{
					break;
				}
				case (int) tbLibrary.Tasks.BuildingId:
				{
					String url = sd.Servername + buildId + "&newdid=" + p.VillageId;
					Upgrade(p, sd, url, taskID);
					break;
				}
				default:
				{
					throw new NotImplementedException("Task not implemented!");
				}
			}
		}



		private static void AutoUpgradeResource
			(ServerData sd,
			 Production p,
			 int wood,
			 int clay,
			 int iron,
			 int[] list,
			 int taskID)
		{
			VillageData vd = tbLibrary.GetResourcesForVillage(sd, p);
			for (int i = 0; i < list.Length; i++)
			{
				int resourceForBuild = list[i];
				string landName;
				if (resourceForBuild == wood)
				{
					landName = sd.WoodlandName;
				}
				else if (resourceForBuild == clay)
				{
					landName = sd.ClaypitName;
				}
				else
				{
					landName = resourceForBuild == iron ? sd.IronmineName : sd.CroplandName;
				}

				int minLevel = 101;
				String url = String.Format("{0}build.php?id={1}&newdid={2}", sd.Servername, 1, p.VillageId);
				for (int v = 0; v < vd.ResourcesForVillage.Count; v++)
				{
					Resource resource = vd.ResourcesForVillage[v] as Resource;
					if (resource != null)
					{
						if ((resource.ResourceName.Trim()).Equals(landName))
						{
							if (resource.ResourceLevel < minLevel)
							{
								minLevel = resource.ResourceLevel;
								url = String.Format("{0}build.php?id={1}&newdid={2}", sd.Servername, resource.ResourceId, p.VillageId);
							}
						}
					}
				}

				//Console.WriteLine("wood={0}, clay={1}, iron={2}, list[{3}]={4}", wood, clay, iron, i, list[i]);
				//Console.WriteLine("landName={0}, resourceForBuild={1}", landName, resourceForBuild);
				//Console.WriteLine("url={0}", url);

				if (Upgrade(p, sd, url, taskID))
				{
					break;
				}
			}
		}



		private static bool Upgrade
			(Production p,
			 ServerData sd,
			 string url,
			 int taskID)
		{
			Browser b = new Browser();
			String pageSource = b.GetPageSource(url);
			Log.DebugFormat("Upgrade:{0}", pageSource);
			Parser parser = new Parser();
			Upgrade u = new Upgrade();
			parser.UpgradeLink(u, pageSource);
			Console.WriteLine("Checking '{0}' in Village '{1}'", u.UpgradeFullName, p.VillageName);
			if (u.UpgradeAVAILABLE)
			{
				string[] buildTime = parser.BuildTime(pageSource).Split(':');
				//SQL.UpdateNextCheckForTask(sd, taskID, tbLibrary.GetDt(buildTime));
				b.GetPageSource(sd.Servername + u.UpgradeUrl);
				String logStr = String.Format("Upgrading '{0}' in Village '{1}' to level {2}", u.UpgradeFullName, p.VillageName,
				                              u.UpgradeLevel + 1);
				Console.WriteLine(logStr);
				Log.InfoFormat(logStr);
				return true;
			}
			return false;
		}
	}
}