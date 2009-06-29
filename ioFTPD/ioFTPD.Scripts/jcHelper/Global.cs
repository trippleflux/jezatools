using System;
using System.Reflection;

namespace jcScripts.jcHelper
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global
	{
		public static string pwd					= Environment.GetEnvironmentVariable("VIRTUALPATH");
		public static string path					= Environment.GetEnvironmentVariable("PATH");
		public static string user					= Environment.GetEnvironmentVariable("USER");
		public static string group					= Environment.GetEnvironmentVariable("GROUP");

		public static string dupe_pwd				= "";
		public static string dupe_creator			= "";
		public static string dupe_tryer				= "";
		public static string dupe_timeago			= "";
		public static string dupe_datetime			= "";
		public static string dupe_name				= "";

		public static string dupe_listsearch		= "";
		public static string dupe_listdatetime		= "";
		public static string dupe_listpwd			= "";
		public static string dupe_listfound			= "";
		public static string dupe_listtotal			= ConfigReader.GetConfig("countListDupes");
		public static string dupe_total				= "";

		public static string undupe_dir				= "";
		
		public static string reqstats_date			= "";
		public static string reqstats_name			= "";

		public static string imdbtop250_rank		= "";
		public static string imdbtop250_dirname		= "";
		public static string imdbtop250_filename	= "";
		public static string imdbtop250_dircount	= "";

		public static string imdbinfo_link			= "N/A";
		public static string imdbinfo_title			= "N/A";
		public static string imdbinfo_director		= "N/A";
		public static string imdbinfo_genre			= "N/A";
		public static string imdbinfo_rating		= "N/A";
		public static string imdbinfo_votes			= "N/A";
		public static string imdbinfo_top250		= "N/A";
		public static string imdbinfo_tagline		= "N/A";
		public static string imdbinfo_plot			= "N/A";
		public static string imdbinfo_runtime		= "N/A";
		public static string imdbinfo_country		= "N/A";
		public static string imdbinfo_language		= "N/A";
//		public static string imdbinfo_color			= "N/A";
//		public static string imdbinfo_soundmix		= "N/A";
//		public static string imdbinfo_awards		= "N/A";
		public static string url					= "N/A";

		public static string imdbLinkHead			= "http://www.imdb.com";

	}
}
