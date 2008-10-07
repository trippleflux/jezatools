#region

using System;
using log4net;

#endregion

namespace Library
{
	public class tbLibrary
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof (tbLibrary));

		#region enum

		public enum Tasks
		{
			BuildResources = 1,
			BuildResourcesNoCrop = 2,
			WoodLand = 3,
			ClayPit = 4,
			IronMine = 5,
			CropLand = 6,
			BuildingId = 7
		}

		public enum Priority
		{
			VeryHigh = 5,
			High = 4,
			Medium = 3,
			Low = 2,
			VeryLow = 1,
		}

		public enum ProductionForVillage
		{
			Wood,
			Clay,
			Iron,
			Crop
		}

		#endregion

		/// <summary>
		/// Return only numbers from string.
		/// </summary>
		/// <param name="input">Input string</param>
		/// <returns>Parsed string</returns>
		/// 
		public static string GetOnlyNumbers(string input)
		{
			String a = "";
			for (int c = 0; c < input.Length; c++)
			{
				if (IsNumber(input[c]))
				{
					a += input[c];
				}
			}

			return a;
		}



		/// <summary>
		/// Checks if specified character is number.
		/// </summary>
		/// <param name="c"><see cref="char"/></param>
		/// <returns><c>true</c> if character is number</returns>
		/// 
		private static bool IsNumber(char c)
		{
			return Char.IsNumber(c);
		}



		public static void LogBuildings(ServerData sd)
		{
			for (int i = 0; i < sd.BuildingsList.Count; i++)
			{
				VillageData villageBuildings = sd.BuildingsList[i] as VillageData;
				if (villageBuildings != null)
				{
					Building villBuildings = villageBuildings.BuildingsForVillage[0] as Building;
					if (villBuildings != null)
					{
						Log.DebugFormat("Buildings: {0}", villBuildings.ToString());
					}
				}
			}
		}



		public static void LogResources(ServerData sd)
		{
			for (int i = 0; i < sd.ResourcesList.Count; i++)
			{
				VillageData villageResources = sd.ResourcesList[i] as VillageData;
				if (villageResources != null)
				{
					Resource villResources = villageResources.ResourcesForVillage[0] as Resource;
					if (villResources != null)
					{
						Log.DebugFormat("Resources: {0}", villResources.ToString());
					}
				}
			}
		}



		public static VillageData GetResourcesForVillage
			(ServerData sd,
			 Production p)
		{
			VillageData vd = new VillageData();
			for (int i = 0; i < sd.ResourcesList.Count; i++)
			{
				VillageData villageResources = sd.ResourcesList[i] as VillageData;
				if (villageResources != null)
				{
					Resource villResources = villageResources.ResourcesForVillage[0] as Resource;
					if (villResources != null)
					{
						if (p.VillageId == villResources.VillageId)
						{
							vd.ResourcesForVillage.Add(villResources);
						}
					}
				}
			}
			return vd;
		}



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



		public static DateTime AddSecondsToTime(string[] buildTime)
		{
			DateTime dt = new DateTime(DateTime.Now.Ticks);
			double seconds = Double.Parse(buildTime[2]);
			double minutes = Double.Parse(buildTime[1]);
			double hours = Double.Parse(buildTime[0]);
			return dt.AddSeconds(seconds + 60*minutes + 60*60*hours);
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="production"></param>
		/// <param name="index"></param>
		/// <param name="noCrop"><c>true</c> if CropLand schould be excluded</param>
		/// <returns></returns>
		public static ProductionForVillage GetProduction
			(Production production,
			 int index,
			 bool noCrop)
		{
			int[] list = {production.WoodPerHour, production.ClayPerHour, production.IronPerHour};
			if (!noCrop)
			{
				list[3] = production.CropPerHour;
			}
			bubble_sort_generic(list);
			ProductionForVillage lowestproduction;
			if (list[index] == production.WoodPerHour)
			{
				lowestproduction = ProductionForVillage.Wood;
			}
			else if (list[index] == production.ClayPerHour)
			{
				lowestproduction = ProductionForVillage.Clay;
			}
			else if (list[index] == production.IronPerHour)
			{
				lowestproduction = ProductionForVillage.Iron;
			}
			else
			{
				lowestproduction = ProductionForVillage.Crop;
			}
			return lowestproduction;
		}

		public static Int32 ConvertXY2Z(Int32 x, Int32 y)
		{
			return ((x + 401) + ((400 - y) * 801));
		}
	}
}