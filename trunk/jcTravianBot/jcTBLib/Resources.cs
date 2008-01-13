using System;
using System.Text;
using System.Text.RegularExpressions;
using WatiN.Core;

namespace jcTBLib
{
	public class Resources
	{
		private Int32 woodCount = 0;
		private Int32 clayCount = 0;
		private Int32 ironCount = 0;
		private Int32 cropCount = 0;

		private Int32 warehouseMax = 800;
		private Int32 granaryMax = 800;
		private String cropRate = "0/0";

		private Int32 woodPerHour = 0;
		private Int32 clayPerHour = 0;
		private Int32 ironPerHour = 0;
		private Int32 cropPerHour = 0;

		public int CurPeople
		{
			get { return curPeople; }
			set { curPeople = value; }
		}

		public int MaxPeople
		{
			get { return maxPeople; }
			set { maxPeople = value; }
		}

		private Int32 curPeople = 0;
		private Int32 maxPeople = 0;

		public int[] WoodLandLevels
		{
			get { return woodLandLevels; }
			set { woodLandLevels = value; }
		}

		public int[] ClayLandLevels
		{
			get { return clayLandLevels; }
			set { clayLandLevels = value; }
		}

		public int[] IronLandLevels
		{
			get { return ironLandLevels; }
			set { ironLandLevels = value; }
		}

		public int[] CropLandLevels
		{
			get { return cropLandLevels; }
			set { cropLandLevels = value; }
		}

		private Int32[] woodLandLevels = {3, 1, 0, 2};
		private Int32[] clayLandLevels = {0, 0, 0, 0};
		private Int32[] ironLandLevels = {0, 0, 0, 0};
		private Int32[] cropLandLevels = {0, 0, 0, 0, 0, 0};

		public int[][] NeededResources
		{
			get { return neededResources; }
			set { neededResources = value; }
		}

		private Int32[][] neededResources;

		public int[] CurProduction
		{
			get { return curProduction; }
			set { curProduction = value; }
		}

		private Int32[] curProduction = {0, 0, 0, 0, 0};

		/// <summary>
		/// Finds All Resources.
		/// </summary>
		/// <param name="ie"><see cref="WatiN.Core.IE"/></param>
		public Resources(IE ie)
		{
			ie.GoTo(jcTBL.GetConfig("urlResources"));
			neededResources = new int[][]
				{
					new int[] { 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0 },
					new int[] { 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0 },
					new int[] { 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0 },
					new int[] { 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0 },
					new int[] { 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0 },
					new int[] { 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0 },
					new int[] { 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0 },
					new int[] { 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0 },
					new int[] { 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0 },
				};

			if (!jcTBL.isSimulation)
			{
				/*
				 * <td id=l4 title=88>251/2300</td> Wod
				 * <td id=l3 title=88>120/2300</td> Clay
				 * <td id=l2 title=88>465/2300</td> Iron
				 * <td id=l1 title=45>504/1700</td> Crop
				 */
				String woodText = ie.TableCell(Find.ById("l4")).Text;
				String clayText = ie.TableCell(Find.ById("l3")).Text;
				String ironText = ie.TableCell(Find.ById("l2")).Text;
				String cropText = ie.TableCell(Find.ById("l1")).Text;

				woodCount = curProduction[0] = Int32.Parse(woodText.Split('/')[0]);
				clayCount = curProduction[1] = Int32.Parse(clayText.Split('/')[0]);
				ironCount = curProduction[2] = Int32.Parse(ironText.Split('/')[0]);
				cropCount = curProduction[3] = Int32.Parse(cropText.Split('/')[0]);

				warehouseMax = Int32.Parse(woodText.Split('/')[1]);
				granaryMax = Int32.Parse(cropText.Split('/')[1]);

				/*
				 * <td>Les:</td><td align="right"><b>88&nbsp;</b></td><td>na uro</td>
				 * <TD>Les:</TD>\r\n<TD align=right><B>74&nbsp;</B></TD>\r\n<TD>na uro</TD></TR>
				 * <td>Glina:</td><td align="right"><b>88&nbsp;</b></td><td>na uro</td>
				 * <td>Železo:</td><td align="right"><b>88&nbsp;</b></td><td>na uro</td>
				 * <td>Žito:</td><td align="right"><b>45&nbsp;</b></td><td>na uro</td>
				 * <TD class=s7>&nbsp;<IMG class=res title=\"Poraba žita\" src=\"img/un/r/5.gif\">&nbsp;140/187</TD>
				 */
				String woodRegEx = @"<TD>Les:</TD>\r\n<TD align=right><([^>]+)>([0-9]{1,4}&nbsp;)</(\1)>";
				String clayRegEx = @"<TD>Glina:</TD>\r\n<TD align=right><([^>]+)>([0-9]{1,4}&nbsp;)</(\1)>";
				String ironRegEx = @"<TD>Železo:</TD>\r\n<TD align=right><([^>]+)>([0-9]{1,4}&nbsp;)</(\1)>";
				String cropRegEx = @"<TD>Žito:</TD>\r\n<TD align=right><([^>]+)>([0-9]{1,4}&nbsp;)</(\1)>";
				String cropRateRegEx = @">&nbsp;[0-9]{1,5}/[0-9]{1,5}<";

				String html = ie.Html;
				woodPerHour = GetResourceValue(html, woodRegEx);
				clayPerHour = GetResourceValue(html, clayRegEx);
				ironPerHour = GetResourceValue(html, ironRegEx);
				cropPerHour = GetResourceValue(html, cropRegEx);
				cropRate = GetResourceString(html, cropRateRegEx);
				
				String[] cropSplit = cropRate.Split('/');
				curPeople = Int32.Parse(cropSplit[0]);
				maxPeople = Int32.Parse(cropSplit[1]);
				curProduction[4] = (maxPeople - curPeople);

				if (curProduction[4] < jcTBL.minCropRate)
				{
					jcTBL.buildCrop = true;
				}

				Int32 areasCount = ie.Areas.Length;
				for (int i = 0; i < areasCount; i++)
				{
					for (int id = 1; id < 19; id++)
					{
						String url = String.Format("build.php?id={0}", id);
						if (ie.Areas[i].Url.EndsWith(url))
						{
							String[] resSplit = ie.Areas[i].Title.Split(' ');
							SetResourceLevels(id, resSplit, jcTBL.woodIds, WoodLandLevels);
							SetResourceLevels(id, resSplit, jcTBL.clayIds, ClayLandLevels);
							SetResourceLevels(id, resSplit, jcTBL.ironIds, IronLandLevels);
							SetResourceLevels(id, resSplit, jcTBL.cropIds, CropLandLevels);
						}
					}
				}
			}
		}

		/// <summary>
		/// Sets the level each resourceland has.
		/// </summary>
		/// <param name="id">Resource ID [1-18]</param>
		/// <param name="resSplit">Name of the Resource Land Splited by SPACE</param>
		/// <param name="resourceIDs">Array With IDs of Resource Land</param>
		/// <param name="resourceLandLevels">Array With Updated Resource Level for Land</param>
		/// 
		private static void SetResourceLevels(int id, string[] resSplit, int[] resourceIDs, int[] resourceLandLevels)
		{
			for (int index = 0; index < resourceIDs.Length; index++)
			{
				if (resourceIDs[index] == id)
				{
					resourceLandLevels[index] = Int32.Parse(resSplit[resSplit.Length - 1]);
				}
			}
		}

		/// <summary>
		/// Get the Current Production per Hour for Wanted Resource.
		/// </summary>
		/// <param name="html">Page Source</param>
		/// <param name="resourcesRegEx">Regular Expression to search for</param>
		/// <returns>Resource value</returns>
		/// 
		private static int GetResourceValue(String html, String resourcesRegEx)
		{
			MatchCollection myMatchCollection =
				Regex.Matches(html, resourcesRegEx);

			foreach (Match myMatch in myMatchCollection)
			{
				foreach (Group myGroup in myMatch.Groups)
				{
					foreach (Capture myCapture in myGroup.Captures)
					{
						// Value	"<TD>Les:</TD>\r\n<TD align=right><B>74&nbsp;</B>"	string
						String[] values = myCapture.Value.Split('<', '>');
						foreach (String tag in values)
						{
							if (tag.EndsWith("&nbsp;"))
							{
								return Int32.Parse(tag.Split('&')[0]);
							}
						}
					}
				}
			}
			return 0;
		}

		/// <summary>
		/// Get the Current Crop Rate.
		/// </summary>
		/// <param name="html">Page Source</param>
		/// <param name="resourcesRegEx">Regular Expression to search for</param>
		/// <returns>Resource String</returns>
		/// 
		private static String GetResourceString(String html, String resourcesRegEx)
		{
			MatchCollection myMatchCollection =
				Regex.Matches(html, resourcesRegEx);

			foreach (Match myMatch in myMatchCollection)
			{
				foreach (Group myGroup in myMatch.Groups)
				{
					foreach (Capture myCapture in myGroup.Captures)
					{
						// Value	"<TD>Les:</TD>\r\n<TD align=right><B>74&nbsp;</B>"	string
						String[] values = myCapture.Value.Split('<', '>');
						foreach (String tag in values)
						{
							if (tag.StartsWith("&nbsp;"))
							{
								return tag.Split(';')[1];
							}
						}
					}
				}
			}
			return "0/0";
		}

		/// <summary>
		/// Gets All needed resources for all Resource lands
		/// </summary>
		/// <param name="landURL">ur of the land</param>
		/// <param name="id">id of the resource land [1-18]</param>
		/// <param name="ie"><see cref="IE"/></param>
		/// 
		public void SetNeededResources(String landURL, Int32 id, IE ie)
		{
			if (!jcTBL.isSimulation)
			{
				ie.GoTo(landURL+id);
				if (ie.ContainsText(jcTBL.GetConfig("neededResourcesSearchString")))
				{
					//<table class="f10"><tr><td><img class="res" src="img/un/r/1.gif">520 | <img class="res" src="img/un/r/2.gif">1300 | <img class="res" src="img/un/r/3.gif">650 | <img class="res" src="img/un/r/4.gif">780 | <img class="res" src="img/un/r/5.gif">2 | <img class="clock" src="img/un/a/clock.gif" width="18" height="12"> 1:13:10</td></tr></table>
					Int32 tableCount = ie.Tables.Length;
					for (int i = 0; i < tableCount; i++)
					{
						String innerText = ie.Tables[i].Text;
						if (innerText.Contains("|"))
						{
							String[] neededResSplitter = innerText.Split('|');
							Int32 totalNeeded = 0;
							for (int j = 0; j < 5; j++)
							{
								Int32 resValue = Int32.Parse(neededResSplitter[j]);
								NeededResources[id - 1][j] = resValue;
								totalNeeded += resValue;
							}
							NeededResources[id - 1][5] = totalNeeded;
							if (jcTBL.minNeededValue > totalNeeded)
							{
								jcTBL.minNeededValue = totalNeeded;
								jcTBL.idToBuild = id;
							}
							break;
						}
					}
				}
				//AllNeededResources[id - 1] = NeededResources;
			}
		}

		/// <summary>
		/// Shows Town Status like production/hour, current resources, ...
		/// </summary>
		/// <returns></returns>
		/// 
		public override string ToString()
		{
			StringBuilder resources = new StringBuilder();
			resources.Append("\n     Current Resources\n");
			resources.AppendFormat("     Warehouse Max : {0}\n", warehouseMax);
			resources.AppendFormat("     Granary Max   : {0}\n", granaryMax);
			resources.AppendFormat("     CropRate      : {0}\n", cropRate);
			resources.AppendFormat("     Wood          : {0,-5} {1,5}/h\n", woodCount, woodPerHour);
			resources.AppendFormat("     Clay          : {0,-5} {1,5}/h\n", clayCount, clayPerHour);
			resources.AppendFormat("     Iron          : {0,-5} {1,5}/h\n", ironCount, ironPerHour);
			resources.AppendFormat("     Crop          : {0,-5} {1,5}/h\n", cropCount, cropPerHour);
			resources.AppendFormat("     WoodLevel     : [ {0}]\n", jcTBL.GetLevel2String(woodLandLevels, false));
			resources.AppendFormat("     ClayLevel     : [ {0}]\n", jcTBL.GetLevel2String(clayLandLevels, false));
			resources.AppendFormat("     IronLevel     : [ {0}]\n", jcTBL.GetLevel2String(ironLandLevels, false));
			resources.AppendFormat("     CropLevel     : [ {0}]\n", jcTBL.GetLevel2String(cropLandLevels, false));

			return resources.ToString();
		}

		/// <summary>
		/// Shows Needed Resources to Console
		/// </summary>
		/// <param name="serverName">Server name</param>
		/// <param name="resources"><see cref="Resources"/></param>
		/// <param name="ie"><see cref="IE"/></param>
		/// 
		public static void ShowNeededResources(String serverName, Resources resources, IE ie)
		{
			Console.WriteLine("     Needed Resources For Upgrade");
			Console.WriteLine("     ID  Resource   Wood   Clay   Iron   Crop People  Total\t");
			Console.WriteLine("    --------------------------------------------------------");
			UpdateNeededResources(true, ie, resources, serverName);
			Console.WriteLine();
			if (jcTBL.buildCrop)
			{
				jcTBL.idToBuild = jcTBL.FindMinimum(resources.CropLandLevels);
			}
			Console.WriteLine("     First Resource For Upgrade is Land With ID " + jcTBL.idToBuild);
			Console.WriteLine();
		}

		/// <summary>
		/// Updates Needed Resources
		/// </summary>
		/// <param name="toConsole"><c>true</c> if message should be shown to console</param>
		/// <param name="ie"><see cref="IE"/></param>
		/// <param name="resources"><see cref="Resources"/></param>
		/// <param name="serverName">Server name</param>
		/// 
		public static void UpdateNeededResources(bool toConsole, IE ie, Resources resources, string serverName)
		{
			for (int i = 1; i < 19; i++)
			{
				resources.SetNeededResources(serverName + "build.php?id=", i, ie);
				if (toConsole)
				{
					Console.WriteLine("     {0,2} {2,9}{1}", i, jcTBL.GetLevel2String(resources.NeededResources[i - 1], true),
					                  jcTBL.GetNameFromID(i));
				}
			}
			ie.GoTo(jcTBL.GetConfig("urlResources"));
		}
	}
}