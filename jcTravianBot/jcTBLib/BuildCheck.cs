using System;

namespace jcTBLib
{
	public class BuildCheck
	{
		/// <summary>
		/// Checks If The Correct Command Was Send.
		/// </summary>
		/// <param name="command">userInput</param>
		/// <param name="resources"><see cref="jcTBLib.Resources"/></param>
		/// <returns></returns>
		/// 
		public static Int32 CheckCommand(String command, Resources resources)
		{
			String[] cmdSplit = command.Split(' ');
			if ((cmdSplit.Length == 3) || (jcTBL.IsInteger(cmdSplit[2])))
			{
				jcTBL.WantedLevel = Int32.Parse(cmdSplit[2]);
				jcTBL.ResourceName = cmdSplit[1];
				if (cmdSplit[1].Equals("woodland"))
				{
					return GetBuildGo(resources.WoodLandLevels)
					       	? (int) Codes.BuildCheckCodes.buildLandWOOD
					       	: (int) Codes.BuildCheckCodes.minLevelAllreadyReached;
				}
				if (cmdSplit[1].Equals("clayland"))
				{
					return GetBuildGo(resources.ClayLandLevels)
					       	? (int) Codes.BuildCheckCodes.buildLandCLAY
					       	: (int) Codes.BuildCheckCodes.minLevelAllreadyReached;
				}
				if (cmdSplit[1].Equals("ironland"))
				{
					return GetBuildGo(resources.IronLandLevels)
					       	? (int) Codes.BuildCheckCodes.buildLandIRON
					       	: (int) Codes.BuildCheckCodes.minLevelAllreadyReached;
				}
				if (cmdSplit[1].Equals("cropland"))
				{
					return GetBuildGo(resources.CropLandLevels)
					       	? (int) Codes.BuildCheckCodes.buildLandCROP
					       	: (int) Codes.BuildCheckCodes.minLevelAllreadyReached;
				}
				else
				{
					jcTBL.ResourceName = "N/A";
					return (int) Codes.BuildCheckCodes.unknownCommand;
				}
			}
			else
			{
				return (int) Codes.BuildCheckCodes.unknownCommand;
			}
		}

		/// <summary>
		/// Checks if Wanted Resource Allready Has The Minimum Level.
		/// </summary>
		/// <param name="resources">Land Resource</param>
		/// <returns><c>false</c> if Level Allready Reached</returns>
		/// 
		private static bool GetBuildGo(Int32[] resources)
		{
			Int32 minLevel = jcTBL.FindMinimum(resources);
			if (minLevel >= jcTBL.WantedLevel)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}