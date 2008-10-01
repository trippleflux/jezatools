namespace Library
{
	public class Upgrade
	{
		private string upgradeUrl;
		private int upgradeLevel;
		private string upgradeFullName;
		private string upgradeName;
		private bool upgradeAvailable;

		public string UpgradeUrl
		{
			get { return upgradeUrl; }
			set { upgradeUrl = value; }
		}

		public int UpgradeLevel
		{
			get { return upgradeLevel; }
			set { upgradeLevel = value; }
		}

		public string UpgradeFullName
		{
			get { return upgradeFullName; }
			set { upgradeFullName = value; }
		}

		public string UpgradeName
		{
			get { return upgradeName; }
			set { upgradeName = value; }
		}

		public bool UpgradeAVAILABLE
		{
			get { return upgradeAvailable; }
			set { upgradeAvailable = value; }
		}



		public override string ToString()
		{
			return
				string.Format("UpgradeUrl: {0}, UpgradeLevel: {1}, UpgradeFullName: {2}, UpgradeName: {3}, UpgradeAvailable: {4}",
				              upgradeUrl, upgradeLevel, upgradeFullName, upgradeName, upgradeAvailable);
		}
	}
}