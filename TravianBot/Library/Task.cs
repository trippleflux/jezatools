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



		public void CheckTasks(ServerData sd)
		{
			//const tbLibrary.Tasks task = tbLibrary.Tasks.BuildResourcesNoCrop;

//SELECT [ID]
//      ,[TaskId]
//      ,[VillageId]
//      ,[BuildId]
//      ,[PriorityId]
//      ,[BuildLevel]
//      ,[NextCheck]
//      ,[Enabled]
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
					//for (int i = 0; i < reader.FieldCount; i++)
					//{
					//    Console.WriteLine("reader[{0}]={1}", i, reader[i]);
					//}
					String buildId = "build.php?id=39";
					String villageName = "";
					Int32 villageId = 0;
					for (int i = 0; i < sd.ProductionList.Count; i++)
					{
						Production p = sd.ProductionList[i] as Production;
						if (p != null)
						{
							Log.InfoFormat("p[{1}]={0}", p.ToString(), i);
							villageId = Int32.Parse(reader[2].ToString().Trim());
							if (villageId == p.VillageId)
							{
								buildId = reader[3].ToString().Trim();
								villageName = reader[8].ToString().Trim();
								break;
							}
						}
					}

					Int32 task = Int32.Parse(reader[1].ToString().Trim());
					//http://s3.travian.si/build.php?id=18?newdid=130112
					String url = sd.Servername + buildId + "&newdid=" + villageId;
					ExecuteTask(sd.Servername, url, task, villageName);
				}
			}
			sd.Connection.Close();
		}



		private static bool ExecuteTask
			(String serverName,
			String url,
			 int task,
			 String villageName)
		{
			bool foundIdForUpgrade = false;
			switch (task)
			{
				case (int) tbLibrary.Tasks.BuildResources:
				{
					break;
				}
				case (int) tbLibrary.Tasks.BuildResourcesNoCrop:
				{
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
					Browser b = new Browser();
					String pageSource = b.GetPageSource(url);
					Log.InfoFormat("TASK:{0}", pageSource);
					//Console.WriteLine("TASK:{0}", pageSource);
					Parser p = new Parser();
					Upgrade u = new Upgrade();
					p.UpgradeLink(u, pageSource);
					Console.WriteLine("Checking '{0}' in Village '{1}'", u.UpgradeFullName, villageName);
					if (u.UpgradeAVAILABLE)
					{
						b.GetPageSource(serverName + u.UpgradeUrl);
						String logStr = String.Format("Upgrading '{0}' in Village '{1}' to level {2}", u.UpgradeFullName, villageName,
						                              u.UpgradeLevel + 1);
						Console.WriteLine(logStr);
						Log.InfoFormat(logStr);
					}
					//<a href=\"(dorf[12].php\?(.*))\">((\w|\d|\s)*) [0-9]{1,3}<\/a>
					break;
				}
				default:
				{
					throw new NotImplementedException("Task not implemented!");
				}
			}
			return false;
		}
	}
}