using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using jcScripts.jcHelper;

using log4net;

namespace jcScripts.jcIMDB
{
	/// <summary>
	/// Summary description for ImdbInfo.
	/// </summary>
	public class ImdbInfo
	{
		public static readonly ILog Log = LogManager.GetLogger(typeof(ImdbInfo));

		public static bool ImdbInfos(string imdbLink)
		{
			string html = GetIMDB.GetHTMLFromURL(imdbLink);

			Match imdbTitle = Regex.Match(html, @"<title>.*");
			Match imdbDirector = Regex.Match(html, @"<h5>Directed by</h5>\n<a href.*");
			Match imdbGenre = Regex.Match(html, @"/Sections/Genres/.*<a class");
			Match imdbTagline = Regex.Match(html, @"<h5>Tagline:</h5>\n.*");
			Match imdbPlot = Regex.Match(html, @"<h5>Plot Outline:</h5>.\n.* <a class");
			//Match imdbRating = Regex.Match(html, @"<b>User Rating:</b>.\n.*votes</a>");
/*
<b>User Rating:</b> 
<b>6.8/10</b> 
  <small>(<a href="ratings">23,002 votes</a>
 * */
			Match imdbRating = Regex.Match(html, @"<b>User Rating:</b>.\n<b>*.*</b>.\n..*votes");
			Match imdbRuntime = Regex.Match(html, @"<h5>Runtime:</h5>\n.*");
			Match imdbCountry = Regex.Match(html, @"/Sections/Countries/.*</a>");
			Match imdbLanguage = Regex.Match(html, @"/Sections/Languages/.*</a>");
//			Match imdbColor = Regex.Match(html, @"/Sections/Countries/.*</a>");
//			Match imdbSoundMix = Regex.Match(html, @"/Sections/Countries/.*</a>");
//			Match imdbAwards = Regex.Match(html, @"/Sections/Languages/.*</a>");
			
			#region director
			if ( imdbDirector.ToString().Length > 20 )
			{
				string[] splitDirector = imdbDirector.ToString().Split('>', '<');
				int lengthDirector = splitDirector.Length;
				Global.imdbinfo_director = splitDirector[lengthDirector-5];
			}
			#endregion

			#region genre
			string genre = imdbGenre.ToString();
			Log.Info(genre);
			if ( genre.Length > 20 )
			{
				genre = genre.Replace("/Sections/Genres/", "");
				genre = genre.Replace(@"/"">", " ");
				genre = genre.Replace("</a>", "");
				genre = genre.Replace(@"<a href=""", "");
				//genre = genre.Replace(@"href=""/rg/title-tease/keywords/title/*/keywords"">more / ", "");
				genre = genre.Replace(@"<a class", "");
				string[] splitGenre = genre.Split(' ');
				int lengthGenre = splitGenre.Length;
				StringBuilder genreBuilder = new StringBuilder();
				if ( lengthGenre < 3 )
				{
					genreBuilder.Append(splitGenre[1]);
				}
				else if ( lengthGenre < 7 )
				{
					genreBuilder.Append(splitGenre[1] + " / ");
					genreBuilder.Append(splitGenre[4] + " ");
				}
				else
				{
					genreBuilder.Append(splitGenre[1] + " / ");
					genreBuilder.Append(splitGenre[4] + " / ");
					genreBuilder.Append(splitGenre[7] + " / ");
				}
				Global.imdbinfo_genre = genreBuilder.ToString();
			}
			#endregion

			#region country
			string country = imdbCountry.ToString();
			if ( country.Length > 20 )
			{
				country = country.Replace("/Sections/Countries/", "");
				country = country.Replace(@"/"">", " ");
				country = country.Replace("</a>", "");
				country = country.Replace(@"<a href=""", "");
				string[] splitCountry = country.Split(' ');
				int lengthCountry = splitCountry.Length;
				StringBuilder countryBuilder = new StringBuilder();
				if ( lengthCountry < 3 )
				{
					countryBuilder.Append(splitCountry[1]);
				}
				else if ( lengthCountry < 7 )
				{
					countryBuilder.Append(splitCountry[1] + " / ");
					countryBuilder.Append(splitCountry[4] + " ");
				}
				else
				{
					countryBuilder.Append(splitCountry[1] + " / ");
					countryBuilder.Append(splitCountry[4] + " / ");
					countryBuilder.Append(splitCountry[7] + " / ");
				}
				Global.imdbinfo_country = countryBuilder.ToString();
			}
			#endregion

			#region language
			string language = imdbLanguage.ToString();
			if ( language.Length > 20 )
			{
				language = language.Replace("/Sections/Languages/", "");
				language = language.Replace(@"/"">", " ");
				language = language.Replace("</a>", "");
				language = language.Replace(@"<a href=""", "");
				string[] splitLanguage = language.Split(' ');
				int lengthLanguage = splitLanguage.Length;
				StringBuilder languageBuilder = new StringBuilder();
				if ( lengthLanguage < 3 )
				{
					languageBuilder.Append(splitLanguage[1]);
				}
				else if ( lengthLanguage < 7 )
				{
					languageBuilder.Append(splitLanguage[1] + " / ");
					languageBuilder.Append(splitLanguage[4] + " ");
				}
				else
				{
					languageBuilder.Append(splitLanguage[1] + " / ");
					languageBuilder.Append(splitLanguage[4] + " / ");
					languageBuilder.Append(splitLanguage[7] + " / ");
				}
				Global.imdbinfo_language = languageBuilder.ToString();
			}
			#endregion

			//Console.WriteLine("'"+imdbGenre.ToString()+"'");

			Global.imdbinfo_link = imdbLink;
			Global.imdbinfo_title = imdbTitle.ToString().Split('>', '<')[2];
			Global.imdbinfo_title = Global.imdbinfo_title.Replace("&#34;", "");
			if ( imdbTagline.ToString().Length > 20 )
			{
				Global.imdbinfo_tagline = imdbTagline.ToString().Split('>', '<', '\n')[5];
			}
			if ( imdbPlot.ToString().Length > 20 )
			{
				Global.imdbinfo_plot = imdbPlot.ToString().Split('>', '<', '\n')[5];
			}
			if ( imdbRating.Length > 20 )
			{
				Global.imdbinfo_rating = imdbRating.ToString().Split('>', '<')[6];
			}
			if ( imdbRating.Length > 20 )
			{
				Global.imdbinfo_votes = imdbRating.ToString().Split('>', '<')[12];
			}
			if ( imdbRuntime.Length > 20 )
			{
				Global.imdbinfo_runtime = imdbRuntime.ToString().Split('>', '<', '\n')[5];
			}

//			Global.imdbinfo_color = countryBuilder.ToString();
//			Global.imdbinfo_soundmix = countryBuilder.ToString();
//			Global.imdbinfo_awards = countryBuilder.ToString();

//			Console.WriteLine("imdbTitle.Value.....='"+Global.imdbinfo_title+"'");
//			Console.WriteLine("imdbDirector.Value..='"+Global.imdbinfo_director+"'");
//			Console.WriteLine("imdbGenre.Value.....='"+Global.imdbinfo_genre+"'");
//			Console.WriteLine("imdbRating.Value....='"+Global.imdbinfo_rating+"'");
//			Console.WriteLine("imdbVotes.Value.....='"+Global.imdbinfo_votes+"'");
//			Console.WriteLine("imdbTop250.Value....='"+Global.imdbinfo_top250+"'");
//			Console.WriteLine("imdbTagline.Value...='"+Global.imdbinfo_tagline+"'");
//			Console.WriteLine("imdbPlot.Value......='"+Global.imdbinfo_plot+"'");
//			Console.WriteLine("imdbRuntime.Value...='"+Global.imdbinfo_runtime+"'");
//			Console.WriteLine("imdbCountry.Value...='"+Global.imdbinfo_country+"'");
//			Console.WriteLine("imdbLanguage.Value..='"+Global.imdbinfo_language+"'");
//			Console.WriteLine("imdbColor.Value.....='"+Global.imdbinfo_color+"'");
//			Console.WriteLine("imdbSoundMix.Value..='"+Global.imdbinfo_soundmix+"'");
//			Console.WriteLine("imdbAwards.Value....='"+Global.imdbinfo_awards+"'");

			bool anounceImdbInfo = 
				Convert.ToBoolean(ConfigReader.GetConfig("anounceImdbInfo"));
			if ( anounceImdbInfo )
			{
				Console.WriteLine(
					Format.FormatStr1ng( 
					ConfigReader.GetConfig("mircImdbInfo"), 0, null
					));
			}

			return true;

		}


		public static int CheckIMDB(DirectoryInfo dri, FileInfo fi, bool manualCommand, bool upload)
		{
			string imdbLink = NfoReader.GetImdbLink(fi.FullName);
			string folderName = dri.Name;
			Global.imdbtop250_dirname = folderName;
			if ( (String.Compare(imdbLink, "empty") == 0) || 
				!(imdbLink.StartsWith(Global.imdbLinkHead)) )
			{
				Log.WarnFormat("imdbLink Not Found, '{0}' '{1}'", folderName, imdbLink);
				if ( manualCommand )
				{
					Console.WriteLine(
						Format.FormatStr1ng( 
						ConfigReader.GetConfig("msgImdbLinkNotFound"), 0, null
						));
				}
				//IO.CheckNoImdb(dri);
				if ( upload )
				{
					bool anounceImdbLinkNotFound = 
						Convert.ToBoolean(ConfigReader.GetConfig("anounceimdbTop250NoImdb"));
					if ( anounceImdbLinkNotFound )
					{
						Console.WriteLine(
							Format.FormatStr1ng( 
							ConfigReader.GetConfig("mircimdbTop250NoImdb"), 0, null
							));
					}
				}
				return (int)ImdbCodes.imdbLinkNotFound;
			}
			else
			{
				Log.InfoFormat("imdbLink Found '{0}', '{1}'", imdbLink, folderName);
				string html = GetIMDB.GetHTMLFromURL(imdbLink);
				
				if ( html.Equals("-1") )
				{
					Log.WarnFormat("IMDB Rank Not Found! html='{0}', '{1}' '{2}'", 
						html, folderName, imdbLink);
					return (int)ImdbCodes.imdbRankNotFound;
				}

				string topText = ConfigReader.GetConfig("imdbTop250toptekst");
				int indeks = html.IndexOf(topText);
				Log.DebugFormat("html '{0}'", html);
				Log.DebugFormat("topText '{0}'", topText);
				Log.DebugFormat("indeks '{0}'", indeks);
				if ( indeks > -1 )
				{
					int rank = NfoReader.GetImdbRank(indeks, html);
					Global.imdbtop250_rank = rank.ToString();
					Log.InfoFormat("IMDB Rank Found '{0}', '{1}'", rank, folderName);
					if ( manualCommand )
					{
						Console.WriteLine(
							Format.FormatStr1ng( 
							ConfigReader.GetConfig("msgImdbRankFound"), 0, null
							));
					}
					IO.CheckImdbTop250(dri, rank);
					if ( upload )
					{
						bool anounceRank = 
							Convert.ToBoolean(ConfigReader.GetConfig("anounceimdbTop250"));
						if ( anounceRank )
						{
							Console.WriteLine(
								Format.FormatStr1ng( 
								ConfigReader.GetConfig("mircimdbTop250"), 0, null
								));
						}
					}
					return (int)ImdbCodes.imdbOK;
				}
				else
				{
					Log.WarnFormat("IMDB Rank Not Found '{0}', '{1}'", indeks, folderName);
					if ( manualCommand )
					{
						Console.WriteLine(
							Format.FormatStr1ng( 
							ConfigReader.GetConfig("msgImdbRankNotFound"), 0, null
							));
					}
					//IO.CheckNotInImdbTop250(dri);
					if ( upload )
					{
						bool anounceNotInImdbTop250 = 
							Convert.ToBoolean(ConfigReader.GetConfig("anounceimdbTop250NotInTop250"));
						if ( anounceNotInImdbTop250 )
						{
							Console.WriteLine(
								Format.FormatStr1ng( 
								ConfigReader.GetConfig("mircimdbTop250NotInTop250"), 0, null
								));
						}
					}
					return (int)ImdbCodes.imdbRankNotFound;
				}
			}
			//return (int)ImdbCodes.imdbOK;
		}
	}
}
