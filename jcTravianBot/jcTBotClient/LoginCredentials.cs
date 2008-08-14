using System.IO;

namespace jcTBotClient
{
	public class LoginCredentials
	{
		private string loginName;

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

		private string passwordName;

		public LoginCredentials(StreamReader pageContent)
		{
			LoginName = "";
			PasswordName = "";
		}
	}
}