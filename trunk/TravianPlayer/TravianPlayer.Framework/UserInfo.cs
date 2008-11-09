namespace TravianPlayer.Framework
{
	public class UserInfo
	{
		private string username;
		private string password;

		/*
		<input type="hidden" name="w" value="">
		<input type="hidden" name="login" value="1226249860">
		 */
		private string hiddenWValue;
		private string hiddenLoginValue;

		/*
		<input class="fm fm110" type="text" name="eb4b613" value="jeza1" maxlength="15"> <span class="e f7"></span>
		<input class="fm fm110" type="password" name="eb77f54" value="*****" maxlength="20"> <span class="e f7"></span>
		 */
		private string textBoxUserame;
		private string textBoxPassword;

		/*
		<p align="center"><input type="hidden" name="ebb412a" value="e697604783">
		 */
		private string hiddenName;
		private string hiddenValue;

		/*
		<form method="post" name="snd" action="dorf1.php">
		 */

		private int userId;

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		public string HiddenWValue
		{
			get { return hiddenWValue; }
			set { hiddenWValue = value; }
		}

		public string HiddenLoginValue
		{
			get { return hiddenLoginValue; }
			set { hiddenLoginValue = value; }
		}

		public string TextBoxUserame
		{
			get { return textBoxUserame; }
			set { textBoxUserame = value; }
		}

		public string TextBoxPassword
		{
			get { return textBoxPassword; }
			set { textBoxPassword = value; }
		}

		public string HiddenName
		{
			get { return hiddenName; }
			set { hiddenName = value; }
		}

		public string HiddenValue
		{
			get { return hiddenValue; }
			set { hiddenValue = value; }
		}

		public int UserId
		{
			get { return userId; }
			set { userId = value; }
		}



		public override string ToString()
		{
			return
				string.Format(
					"UserInfo=[Username: {0}, Password: {1}, HiddenWValue: {2}, HiddenLoginValue: {3}, TextBoxUserame: {4}, TextBoxPassword: {5}, HiddenName: {6}, HiddenValue: {7}, UserId: {8}]",
					username, password, hiddenWValue, hiddenLoginValue, textBoxUserame, textBoxPassword, hiddenName, hiddenValue,
					userId);
		}
	}
}