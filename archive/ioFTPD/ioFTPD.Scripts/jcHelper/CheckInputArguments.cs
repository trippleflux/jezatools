using System;

using log4net;
using log4net.Config;

namespace jcScripts.jcHelper
{
	/// <summary>
	/// Summary description for GetInputArgument.
	/// </summary>
	public class CheckInputArgument
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// Chose the action that should be performed.
		/// </summary>
		/// <param name="args">Input arguments</param>
		/// <returns>NUmber representing the action that should be taken.</returns>
		public static int GetType(string[] args)
		{
			short i = 0;
			foreach (string arg in args)
			{
				Log.InfoFormat("args[{0}]={1}",i, arg);
				i++;
			}

			short retValue = 100;
			
			if ( args.Length < 1 )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=" + retValue);
				Log.Info("<-");
				return retValue;
			}
			
			if ( (String.Compare(args[0].ToLower(), "dupe") == 0) && (args.Length > 1) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=0 (dupe)");
				Log.Info("<-");
				return 0;
			}
			else if ( (String.Compare(args[0].ToLower(), "undupe") == 0) && (args.Length > 1))
			{
				Log.Info("args.Length=" + args.Length + ", retValue=1 (undupe)");
				Log.Info("<-");
				return 1;
			}
			else if ( (String.Compare(args[0].ToLower(), "newdir") == 0) && (args.Length == 3) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=2 (newdir)");
				Log.Info("<-");
				return 2;
			}
			else if ( (String.Compare(args[0].ToLower(), "deldir") == 0 ) && (args.Length == 3) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=3 (deldir)");
				Log.Info("<-");
				return 3;
			}
			else if ( (String.Compare(args[0].ToLower(), "importdupe") == 0 ) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=4 (importdupe)");
				Log.Info("<-");
				return 4;
			}
			else if ( (String.Compare(args[0].ToLower(), "adddupe") == 0 ) && (args.Length == 2) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=5 (adddupe)");
				return 5;
			}
			else if ( (String.Compare(args[0].ToLower(), "adddupedirs") == 0 ) && (args.Length == 2) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=6 (adddupedirs)");
				return 6;
			}
			else if ( (String.Compare(args[0].ToLower(), "imdbtop250upload") == 0 ) && (args.Length == 4) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=7 (imdbTop250upload)");
				return 7;
			}
			else if ( (String.Compare(args[0].ToLower(), "imdbtop250complete") == 0 ) && (args.Length == 1) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=8 (imdbTop250complete)");
				return 8;
			}
			else if ( (String.Compare(args[0].ToLower(), "imdbtop250scheduler") == 0 ) && (args.Length == 1) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=9 (imdbTop250scheduler)");
				return 9;
			}
			else if ( (String.Compare(args[0].ToLower(), "imdbtop250single") == 0 ) && (args.Length == 2) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=10 (imdbTop250single)");
				return 10;
			}
			else if ( (String.Compare(args[0].ToLower(), "imdbtop250checksymlinks") == 0 ) && (args.Length == 1) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=11 (imdbTop250checksymlinks)");
				return 11;
			}
			else if ( (String.Compare(args[0].ToLower(), "hddtop250") == 0 ) && (args.Length == 1) )
			{
				Log.Info("args.Length=" + args.Length + ", retValue=12 (hddtop250)");
				return 12;
			}
			else
			{
				Log.Info("args.Length=" + args.Length + ", retValue=" + retValue);
				return retValue;
			}
		}
	}
}
