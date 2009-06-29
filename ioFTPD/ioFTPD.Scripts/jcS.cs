using System;

using jcScripts.jcHelper;
using jcScripts.jcDupe;

using log4net;

namespace jcScripts
{
	/// <summary>
	/// Summary description for jcS.
	/// </summary>
	class jcS
	{
		private static readonly ILog mLog = LogManager.GetLogger(typeof(jcS));

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static int Main(string[] args)
		{
			const short SUCCESS = 0;
			const short FAILURE = 1;
			short RETURN = SUCCESS;
			
			mLog.Info("--------------------------------------------------------");

			try
			{

//				string html = jcHelper.GetIMDB.GetHTMLFromURL("http://www.imdb.com/title/tt0062622/   ?");
			
				if ( !ArgCheck.CheckArgs(args))
				{
					RETURN = FAILURE;
				}

				mLog.InfoFormat("Exit With Code {0}", RETURN);

				return RETURN;
			}
			catch (Exception e)
			{
				mLog.InfoFormat("Exit With Code {0}", RETURN);
				mLog.ErrorFormat("\n{0}", e.ToString());
				return RETURN;
			}
		}
	}
}
