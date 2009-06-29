#define jcSQLite

using System;
using jcScripts.jcHelper;
using jcScripts.jcDupe;
using jcScripts.jcIMDB;

using log4net;

namespace jcScripts
{
	/// <summary>
	/// Summary description for ArgCheck.
	/// </summary>
	public class ArgCheck
	{
		public static readonly ILog Log = LogManager.GetLogger(typeof(ArgCheck));

		/// <summary>
		/// Proccess With Script.
		/// </summary>
		/// <param name="args">Input arguments</param>
		/// <returns><c>true</c> on success</returns>
		public static bool CheckArgs(string[] args)
		{
			bool SUCCESS = true;
			bool FAILURE = false;
			bool RETURN = SUCCESS;

#if jcSQLite
	Log.Debug("Check SQLite ");
	SQLiteCheck.CheckDupeDB("dbDupeDir");
#endif

			switch ( CheckInputArgument.GetType(args) )
			{
					
#if jcSQLite
				/*
				 * dupe
				 * */
				case 0:
				{
					Dupe.ShowDupes(args);
					break;
				}

				/*
				* undupe
				* */
				case 1:
				{
					UnDupe.UnDupeDir(args);
					break;
				}

				/*
				 * newdir
				 * return false when dir is a dupe
				 * */
				case 2:
				{
					if ( NewDir.CheckDupeNewDir(args) )
					{
						RETURN = FAILURE;
					}
						
					break;
				}

				/*
				 * deldir
				 * */
				case 3:
				{
					DelDir.CheckDupeDelDir(args);
						
					break;
				}

				/*
				 * import dupes from jScripts DB file
				 * */
				case 4:
				{
					ImportDupes.ImportFromjScripts();
					break;
				}

				/*
				 * add dupe to DB
				 * */
				case 5:
				{
					AddDupe.AddUpdateDupe(args);	
					break;
				}

				/*
				 * add all dirs to DB
				 * */
				case 6:
				{
					AddDupeDirs.AddUpdateDupeDirs(args);
					break;
				}
#endif
				/*
				 * Check imdbTop250 on UPLOAD
				 * */
				case 7:
				{
					Upload.CheckUpload(args);
					break;
				}

				/*
				 * Checks all dirs for imdbTop250
				 * */
				case 8:
				{
					Complete.CheckComplete(true);
					break;
				}

				/*
				* Checks all dirs for imdbTop250 With Scheduled Task
				* */
				case 9:
				{
					Complete.CheckComplete(false);	
					break;
				}

				/*
				 * Checks Single Release For imdbTop250
				 * */
				case 10:
				{
					jcIMDB.Single.CheckSingle(args);
					break;
				}

				/*
				 * Checks If All Symlinks Points To Correct Dir
				 * */
				case 11:
				{
					Symlink.CheckSymlink(true);
					break;
				}

				/*
				 * hddtop250
				 * */
				case 12:
				{
					HDDs.CheckImdb();
					break;
				}

				default:
				{
					Log.Warn("Unknown Input Argument Passed ");
					break;
				}
			}

			return RETURN;

		}
	}
}
