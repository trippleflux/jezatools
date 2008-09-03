using System.IO;

namespace jcTBotClient
{
	/// <summary>
	/// Gets login,password textbox names and sets their content.
	/// </summary>
	/// 
	public class LoginCredentials
	{
		private string loginName;

		private string passwordName;

		public LoginCredentials(StreamReader pageContent)
		{
			LoginName = "";
			PasswordName = "";
		}

		public string LoginName
		{
			get { return loginName; }
			set { loginName = value; }
		}

		public string PasswordName
		{
			get { return passwordName; }
			set { passwordName = value; }
		}

	}
}