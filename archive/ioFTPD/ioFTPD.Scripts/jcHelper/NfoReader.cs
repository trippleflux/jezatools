using System;
using System.IO;

using log4net;

namespace jcScripts.jcHelper
{
	/// <summary>
	/// Summary description for NfoReader.
	/// </summary>
	public class NfoReader
	{
		public static readonly ILog Log = LogManager.GetLogger(typeof(NfoReader));

		/// <summary>
		/// finds the imdb link in .nfo file is present.
		/// </summary>
		/// <param name="fileName">file name</param>
		/// <returns>imdb link or <c>empty</c> if not found</returns>
		public static string GetImdbLink(string fileName)
		{
			
			StreamReader SR = File.OpenText(fileName);;
			string imdbLink = "empty";
			string[] spliter;
			bool found = false;
			string S = SR.ReadLine();
			while(S != null)
			{
				if ( S.IndexOf("http://") > -1 )
				{
					spliter = S.Split(':', ' ');
					short i = 0;
					do
					{
						if ( spliter[i].IndexOf("http") > -1 )
						{
							imdbLink = "http:" + spliter[i+1];
							found = true;
						}
						i++;
					}
					while ( !found );
				}
				
				if ( found )
					break;

				S=SR.ReadLine();
			}
			SR.Close();
			return imdbLink;
		}


		/// <summary>
		/// get the imdb top 250 possition of the movie
		/// </summary>
		/// <param name="indeks">index where to start search</param>
		/// <param name="html">html text for search</param>
		/// <returns>top250 rank</returns>
		public static int GetImdbRank(int indeks, string html)
		{
			int rank = 0;
			string top250 = html.Substring(indeks+10, 3);
			top250 = top250.Replace('<', ' ');
			top250 = top250.Replace('>', ' ');
			top250 = top250.Replace('/', ' ');
			rank = Int32.Parse(top250);	
			return rank;
		}
	}
}
