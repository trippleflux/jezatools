using System.Collections.Generic;

namespace TravianBot.Framework
{
    public class AlianceData
    {
        public AlianceData()
        {
            players.Clear();
        }

        public IList<PlayerData> Players
        {
            get { return players; }
        }

        public void AddPlayerData(PlayerData playerData)
        {
            players.Add(playerData);
        }

        private readonly List<PlayerData> players = new List<PlayerData>();
    }
}