using System;
using System.Configuration;
using System.Text;

namespace jcTBLib
{
	public class jcTBL
	{
		public static bool isSimulation = false;

		/// <summary>
		/// If CropRate (maxPpl - currPpl) is below this value, Crop land will be build first.
		/// </summary>
		public static Int32 minCropRate = Int32.Parse(jcTBL.GetConfig("minCropRate"));

		/// <summary>
		/// if NOT <see cref="minCropRate"/> set this to true and build cropland.
		/// </summary>
		public static bool buildCrop = false;

		/// <summary>
		/// ID of resource that should be build as next
		/// </summary>
		public static Int32 idToBuild = 1;

		/// <summary>
		/// Count of all resources needed for build
		/// </summary>
		public static Int32 minNeededValue = 999999;

		public static int WantedLevel
		{
			get { return wantedLevel; }
			set { wantedLevel = value; }
		}

		private static Int32 wantedLevel = 0;

		public static string ResourceName
		{
			get { return resourceName; }
			set { resourceName = value; }
		}

		private static String resourceName = "N/A";

		public static Int32[] woodIds = {1, 3, 14, 17};
		public static Int32[] clayIds = {5, 6, 16, 18};
		public static Int32[] ironIds = {4, 7, 10, 11};
		public static Int32[] cropIds = {2, 8, 9, 12, 13, 15};

		public static int BuildThreadIndex
		{
			get { return buildThreadIndex; }
			set { buildThreadIndex = value; }
		}

		/// <summary>
		/// Thread Index (job)
		/// </summary>
		public static Int32 buildThreadIndex = 0;

		/// <summary>
		/// Shows Help
		/// </summary>
		/// <returns>Formated String With Help</returns>
		/// 
		public static String ShowHelp()
		{
			StringBuilder helpMessage = new StringBuilder();
			//helpMessage.Append("Commands:\n");
			helpMessage.Append("help               - Shows This Message\n");
			helpMessage.Append("resources          - Show Current Resources\n");
			helpMessage.Append("jobs               - Show Current Jobs\n");
			helpMessage.Append("build <resland> #  - Builds Specified Resource Land until It Reaches the Wanted Number\n");
			helpMessage.Append("                     <resland> Can Be :\n");
			helpMessage.Append("                     woodland For Wood\n");
			helpMessage.Append("                     clayland For Clay\n");
			helpMessage.Append("                     ironland For Iron\n");
			helpMessage.Append("                     cropland For Crop\n");
			helpMessage.Append("Example:\n");
			helpMessage.Append("build cropland 3   - Builds CropLandsUntil All Have Level 3\n\n");
			//helpMessage.Append("build fastest      - Builds A Resource Land That Have Lowest Build Time\n");
			//helpMessage.Append("build min          - Builds A Resource Land That Needs A Minumumofotal Resources NeededFor Build\n");
			helpMessage.Append("quit               - Exit Program\n");
			helpMessage.Append("exit               - Exit Program\n");
			return helpMessage.ToString();
		}

		/// <summary>
		/// Reads key value from Config File
		/// </summary>
		/// <param name="cnfgValue">key from App.config</param>
		/// <returns>value for key or <c>null</c> if not found</returns>
		public static string GetConfig(string cnfgValue)
		{
			string valueName = ConfigurationManager.AppSettings.Get(cnfgValue);
			if (valueName == null)
			{
				return null;
			}
			else
			{
				return valueName;
			}
		}

		/// <summary>
		/// Checks If Its Integer
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsInteger(object value)
		{
			try
			{
				Int32 number = Int32.Parse(value.ToString(), System.Globalization.NumberStyles.Any);
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}

		/// <summary>
		/// Finds Minimum Value in Array of Integers
		/// </summary>
		/// <param name="levels">Int32[] Array</param>
		/// <returns>Minimum Value</returns>
		/// 
		public static Int32 FindMinimum(Int32[] levels)
		{
			Int32 min = levels[0];
			for (int i = 1; i<levels.Length;i++ )
			{
				if (levels[i] < min)
				{
					min = levels[i];
				}
			}
			return min;
		}

		/// <summary>
		/// Finds Maximum Value in Array of Integers
		/// </summary>
		/// <param name="levels">Int32[] Array</param>
		/// <returns>Maximum Value</returns>
		/// 
		public static Int32 FindMaximum(Int32[] levels)
		{
			Int32 max = 0;
			for (int i = 0; i < levels.Length; i++)
			{
				if (levels[i] > max)
				{
					max = levels[i];
				}
			}
			return max;
		}

		/// <summary>
		/// Finds The Index of Minimum Value in Array of Integers
		/// </summary>
		/// <param name="levels">Int32[] Array</param>
		/// <returns>Index Of Minimum Value</returns>
		/// 
		public static Int32 FindIndexOfMinimum(Int32[] levels)
		{
			Int32 min = levels[0];
			Int32 index = 0;
			for (int i = 1; i < levels.Length; i++)
			{
				if (levels[i] < min)
				{
					min = levels[i];
					index = i;
				}
			}
			return index;
		}

		/// <summary>
		/// Conversts Array of Integers to String
		/// </summary>
		/// <param name="resLand">Int32[] Array</param>
		/// <param name="lineUp"><c>true</c> if it should be formated</param>
		/// <returns>String of Integers</returns>
		/// 
		public static StringBuilder GetLevel2String(Int32[] resLand, bool lineUp)
		{
			StringBuilder level2String = new StringBuilder();
			for (int i = 0; i < resLand.Length; i++)
			{
				if (lineUp)
				{
					level2String.AppendFormat("{0,7}", resLand[i]);
				}
				else
				{
					level2String.AppendFormat("{0} ", resLand[i]);
				}
			}
			return level2String;
		}

		/// <summary>
		/// Returns The Array of Wanted Resource Land.
		/// </summary>
		/// <param name="resCode"><see cref="Codes.ResourceCodes"/></param>
		/// <param name="resources"><see cref="Resources"/></param>
		/// <returns>The Array of Wanted Resource Land</returns>
		/// 
		public static Int32[] GetWantedResourceLand(Codes.ResourceCodes resCode, Resources resources)
		{
			Int32[] res = {0, 0, 0, 0};
			switch(resCode)
			{
				case Codes.ResourceCodes.WOOD:
					{
						res = resources.WoodLandLevels;
						break;
					}

				case Codes.ResourceCodes.CLAY:
					{
						res = resources.ClayLandLevels;
						break;
					}

				case Codes.ResourceCodes.IRON:
					{
						res = resources.IronLandLevels;
						break;
					}

				case Codes.ResourceCodes.CROP:
					{
						res = resources.CropLandLevels;
						break;
					}

				default:
					{
						break;
					}
			}
			return res;
		}

		/// <summary>
		/// Returns The Array of Wanted Resource IDs.
		/// </summary>
		/// <param name="resCode"><see cref="Codes.ResourceCodes"/></param>
		/// <returns>The Array of Wanted Resource IDsd</returns>
		/// 
		public static Int32[] GetWantedResourceId(Codes.ResourceCodes resCode)
		{
			Int32[] res = { 0, 0, 0, 0 };
			switch (resCode)
			{
				case Codes.ResourceCodes.WOOD:
					{
						res = woodIds;
						break;
					}

				case Codes.ResourceCodes.CLAY:
					{
						res = clayIds;
						break;
					}

				case Codes.ResourceCodes.IRON:
					{
						res = ironIds;
						break;
					}

				case Codes.ResourceCodes.CROP:
					{
						res = cropIds;
						break;
					}

				default:
					{
						break;
					}
			}
			return res;
		}

		/// <summary>
		/// Gets the name of the resource land from its ID
		/// </summary>
		/// <param name="id">resource and ID</param>
		/// <returns>Name</returns>
		/// 
		public static String GetNameFromID(Int32 id)
		{
			if (CheckForIDInList(id, woodIds))
				return "WOOD";
			if (CheckForIDInList(id, clayIds))
				return "CLAY";
			if (CheckForIDInList(id, ironIds))
				return "IRON";
			else
				return "CROP";
		}

		/// <summary>
		/// Checks if ID is in Array
		/// </summary>
		/// <param name="id"></param>
		/// <param name="resIDs"></param>
		/// <returns></returns>
		private static bool CheckForIDInList(Int32 id, Int32[] resIDs)
		{
			bool isThere = false;
			for (int i = 0; i < resIDs.Length; i++)
			{
				if (id == resIDs[i])
				{
					isThere = true;
					break;
				}
			}
			return isThere;
		}

		/// <summary>
		/// Checks If We Can Build Resource
		/// </summary>
		/// <param name="res"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		/// 
		public static bool CanWeBuild(Resources res, Int32 id)
		{
			bool canBuild = true;
			for (int i = 0; i < res.CurProduction.Length; i++)
			{
				if (res.NeededResources[id-1][i] > res.CurProduction[i])
				{
					canBuild = false;
					break;
				}
			}
			return canBuild;
		}
	}
}
