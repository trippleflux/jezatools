using System;

using jcScripts.jcHelper;

using log4net;
using log4net.Config;

namespace jcScripts.jcDupe
{
	/// <summary>
	/// Summary description for SkipDupe.
	/// </summary>
	public class SkipDupe
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static bool CheckSkipDupe(string[] args)
		{
			Global.dupe_pwd = args[2];
			string skipUser = ConfigReader.GetConfig("skipUserDupe");
			if (skipUser != null)
			{
				string userName = Global.user;
				if (userName != null)
				{
					if ( Compare.StrngCompare(skipUser, userName, ' ', true) )
					{
						Log.InfoFormat("Skip Dupe Check Because Of Skip UserName '{0}' - '{1}'", userName, skipUser);
						return false;
					}
				}
				else
				{
					Log.WarnFormat("'userName' Was NULL!");
				}
			}
			else
			{
				Log.WarnFormat("'skipUserDupe' Was Not Found!");
			}

			string skipGroup = ConfigReader.GetConfig("skipGroupDupe");
			if (skipGroup != null)
			{
				string groupName = Global.group;
				if (groupName != null)
				{
					if ( Compare.StrngCompare(skipGroup, groupName, ' ', true) )
					{
						Log.InfoFormat("Skip Dupe Check Because Of Skip UserName '{0}' - '{1}'", groupName, skipGroup);
						return false;
					}
				}
				else
				{
					Log.WarnFormat("'groupName' Was NULL!");
				}
			}
			else
			{
				Log.WarnFormat("'skipGroupDupe' Was Not Found!");
			}

			string skipDupeInPres = ConfigReader.GetConfig("skipDupeInPreDirs");
			if (skipDupeInPres != null)
			{
				if ( String.Compare(skipDupeInPres, "true", true) == 0 )
				{
					string prePwd = ConfigReader.GetConfig("preDirs");
					if (prePwd != null)
					{
						if ( Compare.StrngLengthCompare(prePwd, Global.dupe_pwd, ' ', true) )
						{
							Log.InfoFormat("Skip Dupe Check Because Of Pre Dir '{0}' - '{1}'", Global.dupe_pwd, prePwd);
							return false;
						}
					}
					else
					{
						Log.WarnFormat("'preDirs' Was Not Found!");
					}
				}
			}
			else
			{
				Log.WarnFormat("'skipDupeInPreDirs' Was Not Found!");
			}

			string skipPwd = ConfigReader.GetConfig("skipPwdDupe");
			if (skipPwd != null)
			{
				if ( Compare.StrngLengthCompare(skipPwd, Global.dupe_pwd, ' ', true) )
				{
					Log.InfoFormat("Skip Dupe Check Because Of Skip Pwd '{0}' - '{1}'", Global.dupe_pwd, skipPwd);
					return false;
				}
			}
			else
			{
				Log.WarnFormat("'skipPwdDupe' Was Not Found!");
			}

			string skipDir = ConfigReader.GetConfig("skipDirDupe");
			Global.dupe_name = IO.GetDirNameFromPwd(Global.dupe_pwd);
			if (skipDir != null)
			{
				if (Global.dupe_name != null)
				{
					if ( Compare.StrngCompare(skipDir, Global.dupe_name, ' ', false) )
					{
						Log.InfoFormat("Skip Dupe Check Because Of Skip Dir '{0}' - '{1}'", Global.dupe_name, skipDir);
						return false;
					}
				}
				else
				{
					Log.WarnFormat("'dirName' Was Not Found!");
				}
			}
			else
			{
				Log.WarnFormat("'skipDirDupe' Was Not Found!");
			}

			return true;
		}
		
		public static bool CheckSkipDirName(string[] args)
		{
			Log.Info("->");

			string skipDir = ConfigReader.GetConfig("skipDirDupe");
			Global.dupe_name = args[1];
			if (skipDir != null)
			{
				if (Global.dupe_name != null)
				{
					if ( Compare.StrngCompare(skipDir, Global.dupe_name, ' ', false) )
					{
						Log.InfoFormat("Skip Dupe Check Because Of Skip Dir '{0}' - '{1}'", Global.dupe_name, skipDir);
						return false;
					}
				}
				else
				{
					Log.WarnFormat("'dirName' Was Not Found!");
				}
			}
			else
			{
				Log.WarnFormat("'skipDirDupe' Was Not Found!");
			}
			
			return true;
		}

	}
}
