using System;
using WatiN.Core;

namespace jcTBLib
{
	public class Browser
	{
		/// <summary>
		/// Login to travian
		/// </summary>
		/// <param name="ie"><see cref="IE"/></param>
		/// <param name="loginPage">url of login page</param>
		/// <param name="userName">username</param>
		/// <param name="password">password</param>
		/// <returns><c>true</c>on sucesselse false</returns>
		/// 
		public static bool Login(IE ie, String loginPage, String userName, String password)
		{
			ie.GoTo(loginPage);
			//ie.WaitForComplete();
			ie.TextField(Find.By("type", "text")).TypeText(userName);
			ie.TextField(Find.By("type", "password")).TypeText(password);
			ie.CheckBox(Find.ByName("autologin")).Checked = false;
			ie.Button(Find.ByValue("login")).Click();

			if (ie.Link(Find.ByUrl(jcTBL.GetConfig("urlServerName") + "logout.php")).Exists)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Logout from travian
		/// </summary>
		/// <param name="ie"><see cref="IE"/></param>
		/// <param name="serverName">server url</param>
		/// <returns>allwasy <c>true</c>?</returns>
		/// 
		public static bool Logout(IE ie, String serverName)
		{
			ie.Link(Find.ByUrl(serverName + "logout.php")).Click();
			return true;
		}
	}
}