using System;
using System.Net;
using System.IO;
using System.Text;

using log4net;

namespace jcScripts.jcHelper
{
	/// <summary>
	/// Summary description for HTML.
	/// </summary>
	public class GetIMDB
	{
		private static readonly ILog mLog = LogManager.GetLogger(typeof(GetIMDB));

		/// <summary>
		/// searches imdb.com for movie and get the top250 rank of the movie
		/// </summary>
		/// <param name="url">URL of imdb location</param>
		/// <returns>top 250 rank for the movie or -1 if not found</returns>
		public static string GetHTMLFromURL(string url)
		{
			if(url.Length == 0)
			{
				return "-1";
			}

			string html = "";
			HttpWebRequest request = GenerateGetOrPostRequest(url,"GET",null);
			if (!request.HaveResponse)
			{
				return "-1";
			}
			HttpWebResponse response = (HttpWebResponse)request.GetResponse( );
			
			mLog.InfoFormat("response.StatusCode={0}", response.StatusCode.ToString());

			if ( response.StatusCode == HttpStatusCode.OK )
			{
				Stream responseStream = response.GetResponseStream( );
				StreamReader reader = new StreamReader(responseStream,Encoding.UTF8);
					
				html = reader.ReadToEnd( );
				reader.Close( );

			}
			else
			{
				response.Close( );
				return "-1";
			}
			response.Close( );
			return html;
		}


		/// <summary>
		/// Generate HttpWebRequest
		/// </summary>
		/// <param name="uriString"></param>
		/// <param name="method">GET or POST</param>
		/// <param name="postData">can be <c>null</c></param>
		/// <remarks>Only <c>POST</c> works</remarks>
		/// <returns>HttpWebRequest</returns>
		public static HttpWebRequest GenerateGetOrPostRequest(
			string uriString,
			string method,
			string postData)
		{
			HttpWebRequest httpRequest = null;
			if((method.ToUpper() != "GET") && (method.ToUpper() != "POST"))
			{
				//throw new ArgumentException(method +
				//	" is not a valid method.  Use GET or POST.","method");
				return httpRequest;
			}

			try
			{
				Uri uri = new Uri(uriString);
				httpRequest = (HttpWebRequest)WebRequest.Create(uri);
			}
			catch
			{
				return httpRequest;
			}
			
			if( method.ToUpper() == "POST" )
			{
				byte[] bytes = Encoding.UTF8.GetBytes(postData);
				httpRequest.ContentType=
					"application/x-www-form-urlencoded";
				httpRequest.ContentLength=postData.Length;
				Stream requestStream = httpRequest.GetRequestStream();
				requestStream.Write(bytes,0,bytes.Length);
				requestStream.Close();
			}
			return httpRequest;
		}
	}
}
