#region

using System;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace TW.Helper
{
    public class MapCoordinates
    {
        public MapCoordinates()
        {
            DefaultSettings();
        }

        public MapCoordinates
            (string title,
             string url)
        {
            DefaultSettings();
            VillageId = 0;
            VillageLink = url;
            VillageName = title;
            Regex regVillageId = new Regex(@"karte.php.d=([0-9]{0,6})&c=");
            if (regVillageId.IsMatch(url))
            {
                Match mc = regVillageId.Matches(url)[0];
                VillageId = Int32.Parse(mc.Groups[1].Value.Trim());
            }
        }

        private void DefaultSettings()
        {
            AllianceName = "-= Not In Alliance =-";
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerNameLink { get; set; }
        public int VillageId { get; set; }
        public string VillageName { get; set; }
        public string VillageLink { get; set; }
        public int AllianceId { get; set; }
        public string AllianceName { get; set; }
        public string AllianceLink { get; set; }
        public int Population { get; set; }
        public string Coordinates { get; set; }
        public string Tribe { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string PlayerStatus { get; set; }
        public bool PlayerEnabled { get; set; }
        public string PlayerStatusLink { get; set; }

        public override string ToString()
        {
            return
                String.Format(CultureInfo.InvariantCulture, 
                    "PlayerId: {0}, PlayerName: {1}, PlayerNameLink: {2}, VillageId: {3}, VillageName: {4}, VillageLink: {5}, AllianceId: {6}, AllianceName: {7}, AllianceLink: {8}, Population: {9}, Coordinates: {10}, Tribe: {11}, CoordinateX: {12}, CoordinateY: {13}",
                    PlayerId, PlayerName, PlayerNameLink, VillageId, VillageName, VillageLink, AllianceId, AllianceName,
                    AllianceLink, Population, Coordinates, Tribe, CoordinateX, CoordinateY);
        }

        public string VillageInfo()
        {
            return String.Format(CultureInfo.InvariantCulture, "[{2}] '{1}' '{0}'", VillageName, VillageLink, VillageId);
        }
    }
}