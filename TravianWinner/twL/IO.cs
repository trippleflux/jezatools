#region

using System;
using System.Globalization;
using System.IO;
using SHDocVw;

#endregion

namespace twL
{
	public class IO
	{
		public static bool LoadTasks
			(string tasksFile,
			 Events e,
			 InternetExplorer ie,
			 ServerInfo si)
		{
			bool taskListIsEmpty = (e.TaskList.Count == 0) ? true : false;
			if (File.Exists(tasksFile))
			{
				using (StreamReader sr = new StreamReader(tasksFile))
				{
					while (sr.Peek() >= 0)
					{
						String line = sr.ReadLine();
						if ((!line.StartsWith("#")) && (line.Length > 5))
						{
							//villageID|buildingID|wantedLevel|NextCheck|Comment
							String[] sections = line.Split('|');
							int villageId = Int32.Parse(sections[0]);
							int buildingId = Int32.Parse(sections[1]);
							int wantedLevel = Int32.Parse(sections[2]);
							string userComment = sections[4];
							//http://s4.travian.si/build.php?newdid=0&id=1
							string upgradeBuildingUrl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}&id={2}",
							                                          si.UpgradeBuildingPage, villageId, buildingId);
							BuildTask buildTask = new BuildTask
							                      {
							                      	VillageId = villageId,
							                      	BuildingId = buildingId,
							                      	WantedBuildingLevel = wantedLevel,
							                      	NextCheck = Browser.NextCheck(upgradeBuildingUrl, ie),
							                      	BuildTaskComment = userComment,
							                      };
							String consoleOut = String.Format(CultureInfo.InvariantCulture,
							                                  "TaskUpdated: VillageId={0}, BuildingId={1}, BuildingLevel={2}, NextCheck={3}",
							                                  buildTask.VillageId, buildTask.BuildingId, buildTask.WantedBuildingLevel,
							                                  buildTask.NextCheck.ToString("yyyy-MM-dd HH:mm:ss"));
							Console.WriteLine(consoleOut);
							if (taskListIsEmpty)
							{
								e.TaskList.Add(buildTask);
							}
							else
							{
								foreach (var task in e.TaskList)
								{
									BuildTask bt = task as BuildTask;
									if (bt != null)
									{
										if ((bt.VillageId != villageId) && (bt.BuildingId != buildingId))
										{
											e.TaskList.Add(buildTask);
										}
										else
										{
											bt.WantedBuildingLevel = wantedLevel;
											bt.NextCheck = buildTask.NextCheck;
										}
									}
								}
							}
						}
					}
				}
				return true;
			}
			return false;
		}
	}
}