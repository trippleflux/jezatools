using System;
using System.Text.RegularExpressions;

namespace jcTBotClient
{
	/// <summary>
	/// Gets login,password textbox names and sets their content.
	/// </summary>
	/// 
	public class LoginCredentials
	{
		//<input class="fm fm110" type="text" name="e528e90" value="jezonsky" maxlength="15">
		//<input class="fm fm110" type="password" name="e4519e5" value="******" maxlength="20">
		//<input type="hidden" name="eea0521" value="fd59291e82">
		//w=1280%3A1024&login=1218703254&e528e90=Vladika&e4519e5=******&eea0521=fd59291e82&s1.x=60&s1.y=6&s1=login
		//w=1280%3A1024&login=1218703254&e528e90=Vladika&e4519e5=******&eea0521=fd59291e82&s1.x=60&s1.y=6&s1=login
		/*
		 * <input type="hidden" name="w" value="">
		 * <input type="hidden" name="login" value="1218716929">
		 * 
		 * <input class="fm fm110" type="text" name="e528e90" value="" maxlength="15">
		 * <input class="fm fm110" type="password" name="e4519e5" value="" maxlength="20">
		 * 
		 * <input type="hidden" name="eea0521" value="">
		 * 
		 * http://www.cnblogs.com/minbear/archive/2007/07/13/816879.html
		 * http://www.cnblogs.com/qufo/archive/2007/11/05/949725.html
		 * http://www.netcsharp.cn/archiver/showtopic-755.aspx
		 * 
		 */

		private string loginName;
		private string passwordName;
		private string hiddenLoginValue;
		private string hiddenName;
		private string hiddenValue;

		/// <summary>
		/// Gets login,password textbox names and sets their content.
		/// </summary>
		///
		public LoginCredentials(String pageContent)
		{
			//Console.WriteLine(pageContent);

			Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\">");
			if (regHiddenLoginValue.IsMatch(pageContent))
			{
				Match Mc = regHiddenLoginValue.Matches(pageContent)[0];
				hiddenLoginValue = Mc.Groups[1].Value;
			}

			Regex regLoginName = new Regex("<input class=\"fm fm110\" type=\"text\" name=\"(.*)\" value=");
			if (regLoginName.IsMatch(pageContent))
			{
				Match Mc = regLoginName.Matches(pageContent)[0];
				loginName = Mc.Groups[1].Value;
			}

			Regex regPasswordName = new Regex("<input class=\"fm fm110\" type=\"password\" name=\"(.*)\" value=");
			if (regPasswordName.IsMatch(pageContent))
			{
				Match Mc = regPasswordName.Matches(pageContent)[0];
				passwordName = Mc.Groups[1].Value;
			}

			Regex regHiddenName = new Regex("<p align=\"center\"><input type=\"hidden\" name=\"(.*)\" value=\"(.*)\">");
			if (regHiddenName.IsMatch(pageContent))
			{
				Match Mc = regHiddenName.Matches(pageContent)[0];
				//Console.WriteLine(Mc.Groups[0].Value);
				hiddenName = Mc.Groups[1].Value;
				hiddenValue = Mc.Groups[2].Value;
				//for (int i=0;i<Mc.Length;i++)
				//{
				//    Console.WriteLine(i + "=" + Mc.Groups[i].Value);
				//}
			}
		}

		/// <summary>
		/// <c>value</c> of hidden input tag.
		/// </summary>
		/// <example>
		/// <p align="center"><input type="hidden" name="e1fe1de" value="">
		/// </example>
		public string HiddenValue
		{
			get { return hiddenValue; }
			set { hiddenValue = value; }
		}

		/// <summary>
		/// <c>name</c> of hidden input tag.
		/// </summary>
		/// <example>
		/// <p align="center"><input type="hidden" name="e1fe1de" value="">
		/// </example>
		public string HiddenName
		{
			get { return hiddenName; }
			set { hiddenName = value; }
		}

		/// <summary>
		/// <c>name</c> of hidden input tag for login.
		/// </summary>
		/// <example>
		/// <input type="hidden" name="login" value="1220768457">
		/// </example>
		public string HiddenLoginValue
		{
			get { return hiddenLoginValue; }
			set { hiddenLoginValue = value; }
		}

		/// <summary>
		/// <c>name</c> of input tag for login.
		/// </summary>
		/// <example>
		/// <input class="fm fm110" type="text" name="e4a33c4" value="" maxlength="15">
		/// </example>
		public string LoginName
		{
			get { return loginName; }
			set { loginName = value; }
		}

		/// <summary>
		/// <c>name</c> of input tag for password.
		/// </summary>
		/// <example>
		/// <input class="fm fm110" type="password" name="eb43098" value="" maxlength="20">
		/// </example>
		public string PasswordName
		{
			get { return passwordName; }
			set { passwordName = value; }
		}
	}
}