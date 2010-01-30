using System;
using log4net;

namespace jcScripts.jcReqStats
{
	/// <summary>
	/// Summary description for ListStats.
	/// </summary>
	public class ListStats
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(typeof(ListStats));

		/// <summary>
		/// List stats for given username
		/// </summary>
		/// <param name="UserName">UserName</param>
		/// <returns>List of requests made or <c>null</c> if empty</returns>
		public static string GetStats(string UserName)
		{
			return null;
		}
	}
}
