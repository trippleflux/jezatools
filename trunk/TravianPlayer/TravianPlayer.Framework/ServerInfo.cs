using System.Collections.Generic;

namespace TravianPlayer.Framework
{
	public class ServerInfo
	{
		private string serverUrl;
		private string loginUrl;
		private string resourcesUrl;
		private string buildingsUrl;
		private string sendUnitsUrl;
		private string upgradeBuildingUrl;
		private string loginCredentials;

		public string ServerUrl
		{
			get { return serverUrl; }
			set { serverUrl = value; }
		}

		public string LoginUrl
		{
			get { return loginUrl; }
			set { loginUrl = value; }
		}

		public string ResourcesUrl
		{
			get { return resourcesUrl; }
			set { resourcesUrl = value; }
		}

		public string BuildingsUrl
		{
			get { return buildingsUrl; }
			set { buildingsUrl = value; }
		}

		public string SendUnitsUrl
		{
			get { return sendUnitsUrl; }
			set { sendUnitsUrl = value; }
		}

		public string UpgradeBuildingUrl
		{
			get { return upgradeBuildingUrl; }
			set { upgradeBuildingUrl = value; }
		}

		public string LoginCredentials
		{
			get { return loginCredentials; }
			set { loginCredentials = value; }
		}

	    public int GetVillageId(string villageName)
	    {
	        foreach (VillageInfo villageInfo in villageList)
	        {
	            if (villageInfo.Name.Equals(villageName))
	            {
	                return villageInfo.Id;
	            }
	        }
	        return 0;
	    }

	    public void AddVillage(VillageInfo villageInfo)
	    {
            villageList.Add(villageInfo);
	    }

	    public int VillagesCount()
	    {
	        return villageList.Count;
	    }

	    private List<VillageInfo> villageList = new List<VillageInfo>();


		public override string ToString()
		{
			return
				string.Format(
					"ServerInfo=[ServerUrl: {0}, LoginUrl: {1}, ResourcesUrl: {2}, BuildingsUrl: {3}, SendUnitsUrl: {4}, UpgradeBuildingUrl: {5}, LoginCredentials: {6}]",
					serverUrl, loginUrl, resourcesUrl, buildingsUrl, sendUnitsUrl, upgradeBuildingUrl, loginCredentials);
		}
	}
}