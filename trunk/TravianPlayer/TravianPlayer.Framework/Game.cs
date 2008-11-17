#region

using System;
using System.Collections.Generic;

#endregion

namespace TravianPlayer.Framework
{
	public class Game
	{
		public Game()
		{
		}

		public Game(LoginInfo loginInfo)
		{
			this.loginInfo = loginInfo;
		}

		public int UserId { get; set; }

		public string VillageName { get; set; }

		public void AddVillage(Village village)
		{
			villages.Add(village.Id, village);
		}

		public void AddLoginInfo(LoginInfo info)
		{
			loginInfo = info;
		}

		public int GetVillagesCount
		{
			get { return villages.Count; }
		}

		public int GetVillageId(string villageName)
		{
			foreach (KeyValuePair<int, Village> village in villages)
			{
				if (village.Value.Name == villageName)
				{
					return village.Value.Id;
				}
			}
			return 0;
		}

		public string GetVillageName(int villageId)
		{
			foreach (KeyValuePair<int, Village> village in villages)
			{
				if (village.Key == villageId)
				{
					return village.Value.Name;
				}
			}
			return String.Empty;
		}

		public Village GetVillageData(int villageId)
		{
			foreach (KeyValuePair<int, Village> village in villages)
			{
				if (village.Key == villageId)
				{
					return village.Value;
				}
			}
			return null;
		}

		public Dictionary<int, Village> Villages
		{
			get { return villages; }
		}

		public LoginInfo GetLoginInfo()
		{
			return loginInfo;
		}

		public void AddUrl(string key, string url)
		{
			urls.Add(key, url);
		}

		public string GetUrl(string key)
		{
			foreach (KeyValuePair<string, string> url in urls)
			{
				if (url.Key.Equals(key))
				{
					return url.Value;
				}
			}
			return String.Empty;
		}

		private readonly Dictionary<int, Village> villages = new Dictionary<int, Village>();

		private LoginInfo loginInfo;
		private readonly Dictionary<string, string> urls = new Dictionary<string, string>();
	}
}