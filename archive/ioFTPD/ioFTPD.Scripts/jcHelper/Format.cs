using System;
using System.Globalization;

using log4net;
using log4net.Config;

namespace jcScripts.jcHelper
{
	/// <summary>
	/// Summary description for Format.
	/// </summary>
	public class Format
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// Formats the input string.
		/// arguments for formating must be posted as 'format|list|count'
		/// </summary>
		/// <example>
		/// blabla {0} hulaba {1} beee|argument1 argument2|2
		/// after format it looks like this 'blabla argument1 hulaba argument2 beee'
		/// </example>
		/// <example>
		/// blabla {0} hulaba beee|argument1 |1
		/// after format it looks like this 'blabla argument1 hulaba beee'
		/// </example>
		/// <remarks>max number of arguments to process is <c>9</c></remarks>
		/// <param name="input">input string to be formated</param>
		/// <param name="pos">here if i need it :)</param>
		/// <returns>Formated String</returns>
		public static string FormatStr1ng(string input, int pos, params object[] arg5)
		{
			Log.InfoFormat("input = >{0}<", input);

			if (input.Length < 2)
			{
				return "";
			}

			string[] spliter = input.Split('|');
			string what = spliter[0];
			string[] args = spliter[1].Split(' ');
			int count = args.Length;
			
			for ( int i = 0 ; i < count ; i++ )
			{
				if		( String.Compare(args[i], "pwd") == 0 )						{ args[i] = Global.pwd; }
				else if	( String.Compare(args[i], "path") == 0 )					{ args[i] = Global.path; }
				else if	( String.Compare(args[i], "user") == 0 )					{ args[i] = Global.user; }
				else if	( String.Compare(args[i], "group") == 0 )					{ args[i] = Global.group; }

				else if	( String.Compare(args[i], "dupe_pwd") == 0 )				{ args[i] = Global.dupe_pwd; }
				else if	( String.Compare(args[i], "dupe_creator") == 0 )			{ args[i] = Global.dupe_creator; }
				else if	( String.Compare(args[i], "dupe_tryer") == 0 )				{ args[i] = Global.dupe_tryer; }
				else if	( String.Compare(args[i], "dupe_timeago") == 0 )			{ args[i] = Global.dupe_timeago; }
				else if	( String.Compare(args[i], "dupe_datetime") == 0 )			{ args[i] = Global.dupe_datetime; }
				else if	( String.Compare(args[i], "dupe_name") == 0 )				{ args[i] = Global.dupe_name; }
					
				else if	( String.Compare(args[i], "dupe_listsearch") == 0 )			{ args[i] = Global.dupe_listsearch; }
				else if	( String.Compare(args[i], "dupe_listdatetime") == 0 )		{ args[i] = Global.dupe_listdatetime; }
				else if	( String.Compare(args[i], "dupe_listpwd") == 0 )			{ args[i] = Global.dupe_listpwd; }
				else if	( String.Compare(args[i], "dupe_listfound") == 0 )			{ args[i] = Global.dupe_listfound; }
				else if	( String.Compare(args[i], "dupe_listtotal") == 0 )			{ args[i] = Global.dupe_listtotal; }
				else if	( String.Compare(args[i], "dupe_total") == 0 )				{ args[i] = Global.dupe_total; }

				else if	( String.Compare(args[i], "undupe_dir") == 0 )				{ args[i] = Global.undupe_dir; }

				else if	( String.Compare(args[i], "reqstats_date") == 0 )			{ args[i] = Global.reqstats_date; }
				else if	( String.Compare(args[i], "reqstats_name") == 0 )			{ args[i] = Global.reqstats_name; }

				else if	( String.Compare(args[i], "imdbtop250_rank") == 0 )			{ args[i] = Global.imdbtop250_rank; }
				else if	( String.Compare(args[i], "imdbtop250_dirname") == 0 )		{ args[i] = Global.imdbtop250_dirname; }
				else if	( String.Compare(args[i], "imdbtop250_filename") == 0 )		{ args[i] = Global.imdbtop250_filename; }
				else if	( String.Compare(args[i], "imdbtop250_dircount") == 0 )		{ args[i] = Global.imdbtop250_dircount; }
				
				else if	( String.Compare(args[i], "imdbinfo_link") == 0 )			{ args[i] = Global.imdbinfo_link; }
				else if	( String.Compare(args[i], "imdbinfo_title") == 0 )			{ args[i] = Global.imdbinfo_title; }
				else if	( String.Compare(args[i], "imdbinfo_director") == 0 )		{ args[i] = Global.imdbinfo_director; }
				else if	( String.Compare(args[i], "imdbinfo_genre") == 0 )			{ args[i] = Global.imdbinfo_genre; }
				else if	( String.Compare(args[i], "imdbinfo_rating") == 0 )			{ args[i] = Global.imdbinfo_rating; }
				else if	( String.Compare(args[i], "imdbinfo_votes") == 0 )			{ args[i] = Global.imdbinfo_votes; }
				else if	( String.Compare(args[i], "imdbinfo_top250") == 0 )			{ args[i] = Global.imdbinfo_top250; }
				else if	( String.Compare(args[i], "imdbinfo_tagline") == 0 )		{ args[i] = Global.imdbinfo_tagline; }
				else if	( String.Compare(args[i], "imdbinfo_plot") == 0 )			{ args[i] = Global.imdbinfo_plot; }
				else if	( String.Compare(args[i], "imdbinfo_runtime") == 0 )		{ args[i] = Global.imdbinfo_runtime; }
				else if	( String.Compare(args[i], "imdbinfo_country") == 0 )		{ args[i] = Global.imdbinfo_country; }
				else if	( String.Compare(args[i], "imdbinfo_language") == 0 )		{ args[i] = Global.imdbinfo_language; }
//				else if	( String.Compare(args[i], "imdbinfo_color") == 0 )			{ args[i] = Global.imdbinfo_color; }
//				else if	( String.Compare(args[i], "imdbinfo_soundmix") == 0 )		{ args[i] = Global.imdbinfo_soundmix; }
//				else if	( String.Compare(args[i], "imdbinfo_awards") == 0 )			{ args[i] = Global.imdbinfo_awards; }
				else if	( String.Compare(args[i], "url") == 0 )						{ args[i] = Global.url; }

				else	{ Log.Warn("Unknown Argument in String Format! '" + args[i] + "'"); }
			}
			
			what = String.Format(CultureInfo.InvariantCulture, what, args);
			
			Log.Info("Formated String = >" + what + "<");

			return what;
		}
	}
}
