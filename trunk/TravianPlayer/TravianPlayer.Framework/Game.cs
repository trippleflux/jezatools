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



		public Dictionary<int, Village> Villages
		{
			get { return villages; }
		}



		public LoginInfo GetLoginInfo()
		{
			return loginInfo;
		}



		private readonly Dictionary<int, Village> villages = new Dictionary<int, Village>();

		private LoginInfo loginInfo;
	}
}