using System.Text.RegularExpressions;

namespace jcTBotConsole
{
	public class LoginFields
	{
		private string hiddenLoginValue;
		private string textLoginName;
		private string textPasswordName;
		private string hiddenName;
		private string hiddenValue;

		public string HiddenLoginValue
		{
			get { return hiddenLoginValue; }
			set { hiddenLoginValue = value; }
		}

		public string TextLoginName
		{
			get { return textLoginName; }
			set { textLoginName = value; }
		}

		public string TextPasswordName
		{
			get { return textPasswordName; }
			set { textPasswordName = value; }
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



		public LoginFields(string pageSource)
		{
			Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\">");
			if (regHiddenLoginValue.IsMatch(pageSource))
			{
				Match Mc = regHiddenLoginValue.Matches(pageSource)[0];
				hiddenLoginValue = Mc.Groups[1].Value;
			}

			Regex regLoginName = new Regex("<input class=\"fm fm110\" type=\"text\" name=\"(.*)\" value=");
			if (regLoginName.IsMatch(pageSource))
			{
				Match Mc = regLoginName.Matches(pageSource)[0];
				textLoginName = Mc.Groups[1].Value;
			}

			Regex regPasswordName = new Regex("<input class=\"fm fm110\" type=\"password\" name=\"(.*)\" value=");
			if (regPasswordName.IsMatch(pageSource))
			{
				Match Mc = regPasswordName.Matches(pageSource)[0];
				textPasswordName = Mc.Groups[1].Value;
			}

			Regex regHiddenName = new Regex("<p align=\"center\"><input type=\"hidden\" name=\"(.*)\" value=\"(.*)\">");
			if (regHiddenName.IsMatch(pageSource))
			{
				Match Mc = regHiddenName.Matches(pageSource)[0];
				hiddenName = Mc.Groups[1].Value;
				hiddenValue = Mc.Groups[2].Value;
			}

		}
	}
}