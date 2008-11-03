using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace twL
{
    public class Misc
    {
        public static void bubble_sort_generic<T>(T[] array) where T : IComparable
        {
            long right_border = array.Length - 1;

            do
            {
                long last_exchange = 0;

                for (long i = 0; i < right_border; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;

                        last_exchange = i;
                    }
                }

                right_border = last_exchange;
            } while (right_border > 0);
        }

        public static string GetConfigValue(string configKey)
        {
            string configValue = String.Empty;
            try
            {
                configValue = ConfigurationManager.AppSettings[configKey];
            }
            catch (Exception)
            {
                Console.WriteLine("Key '{0}' Not Found!!!", configKey);
            }
            return configValue;
        }



    	public static int[] GetUpgradeList
    		(VillageInfo vi,
    		 UpgradeCosts upgradeCosts)
    	{
    		int wood = ((vi.WoodAvailable - upgradeCosts.BuildingWoodCost)*3600)/vi.WoodPerHour;
    		int clay = ((vi.ClayAvailable - upgradeCosts.BuildingClayCost)*3600)/vi.ClayPerHour;
    		int iron = ((vi.IronAvailable - upgradeCosts.BuildingIronCost)*3600)/vi.IronPerHour;
    		int crop = ((vi.CropAvailable - upgradeCosts.BuildingCropCost)*3600)/vi.CropPerHour;
			//Console.WriteLine("Wood: {0}, Clay: {1}, Iron: {2}, Crop: {3}", wood, clay, iron, crop);
    		int[] list = {wood, clay, iron, crop};
    		bubble_sort_generic(list);
    		return list;
    	}



		/// <summary>
		/// Adds buildTime seconds to current time
		/// </summary>
		/// <param name="buildTime">Formated time H:MM:SS</param>
		/// <example>0:10:01 will add 601 seconds to current time</example>
		/// <returns><see cref="DateTime"/></returns>
		/// 
		public static DateTime AddSecondsToTime(string[] buildTime)
		{
			DateTime dt = new DateTime(DateTime.Now.Ticks);
			double seconds = Double.Parse(buildTime[2]);
			double minutes = Double.Parse(buildTime[1]);
			double hours = Double.Parse(buildTime[0]);
			return dt.AddSeconds(seconds + 60 * minutes + 60 * 60 * hours);
		}



		/// <summary>
		/// Returns time until building is complete.
		/// </summary>
		/// <param name="pageSource">Page source</param>
		/// <returns>time when building is complete ni format h:MM:SS</returns>
		/// 
		public static string TimeToCompleteBuilding(String pageSource)
		{
			string endTime = "0:00:00";
			MatchCollection buildTimeCollection =
				Regex.Matches(pageSource, @"<span id=timer[12]>([0-9]{0,3}.[0-9]{0,3}.[0-9]{0,3})<\/span>");
			for (int i = 0; i < buildTimeCollection.Count; i++)
			{
				endTime = buildTimeCollection[i].Groups[1].Value.Trim();
			}
			return endTime;
		}



        /// <summary>
        /// Returns <c>true</c> if we are building in village.
        /// </summary>
        /// <param name="pageSource">Page source</param>
        /// <returns><c>true</c> if building</returns>
        /// 
        public static bool IsBuildInProgress(String pageSource)
        {
            MatchCollection buildTimeCollection =
                Regex.Matches(pageSource, @"<span id=timer[12]>([0-9]{0,3}.[0-9]{0,3}.[0-9]{0,3})<\/span>");
            return (buildTimeCollection.Count > 0) ? true : false;
        }
    }
}