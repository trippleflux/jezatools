using System;
using System.IO;

namespace twL
{
    public class IO
    {
        public static void LoadTasks(string tasksFile, Events e)
        {
            bool taskListIsEmpty = (e.TaskList.Count == 0) ? true : false;
            DateTime dt = new DateTime(DateTime.Now.Ticks);
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

                        BuildTask buildTask = new BuildTask
                                                  {
                                                      VillageId = villageId,
                                                      BuildingId = buildingId,
                                                      WantedBuildingLevel = wantedLevel,
                                                      NextCheck = dt,
                                                      BuildTaskComment = userComment,
                                                  };

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
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}