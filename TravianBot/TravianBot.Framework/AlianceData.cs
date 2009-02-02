using System.Collections.Generic;
using System.Linq;

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
            get
            {
                //players.Sort(new PlayerCompare());
                //players = players.OrderBy(player => player.AttackPoints).ToList();
                return players;
            }
        }

        public void AddPlayerData(PlayerData playerData)
        {
            players.Add(playerData);
        }

        private readonly List<PlayerData> players = new List<PlayerData>();
    }

    internal class PlayerCompare : IComparer<PlayerData>
    {
        public int Compare(PlayerData x, PlayerData y)
        {
            return x.AttackPoints.CompareTo(y.AttackPoints);
        }
    }
}