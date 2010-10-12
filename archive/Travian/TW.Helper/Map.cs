#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using log4net;
using WatiN.Core;

#endregion

namespace TW.Helper
{
    public class Map : DefaultPage
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Map));

        public Map(Browser browser) : base(browser)
        {
            this.browser = browser;
        }

        public Map
            (Browser browser,
             string server,
             string username,
             string password,
             int defaultVillageId)
            : base(browser, server, username, password, defaultVillageId)
        {
            this.browser = browser;
            Server = server;
            DefaultVillageId = defaultVillageId;
        }

        private void AddVillagesFromMap()
        {
            Log.Debug("AddVillagesFromMap");
            foreach (Area area in browser.Areas)
            {
                string title = area.Title;
                if (title.Length > 0)
                {
                    string destination = area.Url;
                    if (destination.IndexOf("&c=") > -1)
                    {
                        MapCoordinates mapCoordinates = new MapCoordinates(title, destination);
                        if (!villages.Contains(mapCoordinates))
                        {
                            villages.Add(mapCoordinates);
                            Log.DebugFormat("Added {0}", mapCoordinates.VillageName);
                        }
                    }
                }
            }
        }

        public void AddVillagesFromMapAt
            (int x,
             int y)
        {
            Log.InfoFormat("Get villages around {0,4}|{1,-4}", x, y);
            string url = String.Format(CultureInfo.InvariantCulture, "{0}karte.php?xp={1}&yp={2}&s1.x=32&s1.y=11&s1=ok",
                                       Server, x, y);
            browser.GoTo(url);
            AddVillagesFromMap();
        }

        public void CollectVillagesInfo()
        {
            Log.Debug("CollectVillagesInfo");
            CollectVillagesInfo(true);
        }

        public void CollectVillagesInfo(bool removeOazis)
        {
            foreach (MapCoordinates village in villages)
            {
                GetVillageDetails(village);
            }
            if (removeOazis)
            {
                foreach (MapCoordinates mapCoordinate in oasis)
                {
                    Log.DebugFormat("Removing Oazis : {0}", mapCoordinate.VillageName);
                    villages.Remove(mapCoordinate);
                }
            }
            foreach (MapCoordinates mapCoordinate in abandoned)
            {
                Log.DebugFormat("Removing Abandoned : {0}", mapCoordinate.VillageName);
                villages.Remove(mapCoordinate);
            }
        }

        public bool GetVillageDetails(MapCoordinates village)
        {
            Log.Debug("GetVillageDetails");
            browser.GoTo(village.VillageLink);
            Table tableVillageInfo = browser.Table(Find.ById("village_info"));
            if (tableVillageInfo.Exists)
            {
                Log.Debug(village.VillageName);
                if (!browser.Link(Find.ByUrl(new Regex("build.php.z=*"))).Exists)
                {
                    oasis.Add(village);
                    Log.Debug("Oazis : Merchants link not found");
                    return false;
                }
                if (tableVillageInfo.TableRows.Count == 4)
                {
                    oasis.Add(village);
                    Log.Debug("Oazis : 4 TableRows");
                    return false;
                }
                string nameAndCoordinates = tableVillageInfo.TableRows[0].Text;
                int lastIndexOf = nameAndCoordinates.LastIndexOf('(');
                if (lastIndexOf == -1)
                {
                    oasis.Add(village);
                    Log.DebugFormat("Oazis : {0}", nameAndCoordinates);
                    return false;
                }
                village.VillageName = nameAndCoordinates.Substring(0, lastIndexOf - 1);
                string coordinates = nameAndCoordinates.Substring(lastIndexOf).Trim();
                if (coordinates.IndexOf('|') == -1)
                {
                    Log.Warn("Failed to parse coordinates");
                    return false;
                }
                village.Coordinates = coordinates;
                string[] strings = coordinates.Split('|', '(', ')');
                village.CoordinateX = Misc.String2Number(strings[1]);
                village.CoordinateY = Misc.String2Number(strings[2]);
                village.Tribe = tableVillageInfo.TableRows[1].TableCells[0].Text;
                village.AllianceId = 0;
                village.AllianceName = tableVillageInfo.TableRows[2].TableCells[0].Text;
                village.AllianceLink =
                    tableVillageInfo.TableRows[2].TableCells[0].Link(Find.ByUrl(new Regex("allianz.php*"))).Url;
                Regex regAllianceId = new Regex(@"allianz.php.aid=([0-9]{0,8})");
                if (regAllianceId.IsMatch(village.AllianceLink))
                {
                    Match mc = regAllianceId.Matches(village.AllianceLink)[0];
                    village.AllianceId = Misc.String2Number(mc.Groups[1].Value.Trim());
                }
                village.PlayerId = -1;
                village.PlayerName = tableVillageInfo.TableRows[3].TableCells[0].Text;
                village.PlayerNameLink =
                    tableVillageInfo.TableRows[3].TableCells[0].Link(Find.ByUrl(new Regex("spieler.php*"))).Url;
                Regex regPlayerId = new Regex(@"spieler.php.uid=([0-9]{0,6})");
                if (regPlayerId.IsMatch(village.PlayerNameLink))
                {
                    Match mc = regPlayerId.Matches(village.PlayerNameLink)[0];
                    village.PlayerId = Misc.String2Number(mc.Groups[1].Value.Trim());
                }
                village.Population = Misc.String2Number(tableVillageInfo.TableRows[4].TableCells[0].Text);
                village.PlayerStatus = "Available";
                village.PlayerStatusLink = String.Format(CultureInfo.InvariantCulture, "{0}a2b.php?z={1}", Server, village.VillageId);
                Table tableOptions = browser.Table(Find.ById("options"));
                if (tableOptions.Exists)
                {
                    TableCell tableCell = tableOptions.TableBodies[0].TableRows[1].TableCells[0];
                    if (tableCell.Exists)
                    {
                        village.PlayerStatus = tableCell.Title;
                        if (tableCell.Links.Count>0)
                        {
                            Link link = tableCell.Links[0];
                            village.PlayerStatus = link.Text;
                            village.PlayerStatusLink = link.Url;
                            village.PlayerEnabled = true;
                        }
                        else
                        {
                            village.PlayerEnabled = false;
                        }
                    }
                }
                Log.InfoFormat("Village : {0}", village.ToString());
/*
<table cellspacing="1" cellpadding="1" class="tableNone" id="options">
    <thead>
        <tr>
            <th>Options</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><a href="karte.php?z=348625">» Centre map.</a></td>
        </tr>
        <tr>
            <td title="Beginners protection till 28.11.09 17:32." class="none">» Send troops. (Player is in beginner's protection.)</td>
        </tr>
        <tr>
            <td><a href="build.php?z=348625&amp;gid=17" class="">» Send merchant(s).</a></td>
        </tr>
    </tbody>
</table>

<table cellspacing="1" cellpadding="1" class="tableNone" id="options">
    <thead>
        <tr>
            <th>Options</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><a href="karte.php?z=347834">» Centre map.</a></td>
        </tr>
        <tr>
            <td><a href="a2b.php?z=347834">» Send troops.</a></td>
        </tr>
        <tr>
            <td><a href="build.php?z=347834&amp;gid=17" class="">» Send merchant(s).</a></td>
        </tr>
    </tbody>
</table>
*/
                return true;
            }
            if (browser.Table(Find.ById("distribution")).Exists)
            {
                abandoned.Add(village);
                Log.DebugFormat("Abandoned : {0}", village.VillageName);
                return false;
            }
            oasis.Add(village);
            Log.DebugFormat("Oazis : {0}", village.VillageName);
            return false;
        }

        public void SaveVillagesToDb(IList<MapCoordinates> coordinateses)
        {
            Log.Debug("SaveVillagesToDb");
            DataBase dataBase = new DataBase();
            dataBase.SaveVillages(coordinateses);
        }

        public void SaveVillagesToXml()
        {
            Log.Debug("SaveVillagesToXml");
            XmlSerializer serializer = new XmlSerializer(typeof (List<MapCoordinates>));
            TextWriter textWriter = new StreamWriter(fileNeighbours);
            serializer.Serialize(textWriter, villages);
            textWriter.Close();
        }

        public void SaveVillagesToXmlWithStyleSheet()
        {
            Log.Debug("SaveVillagesToXmlWithStyleSheet");
            XmlSerializer xSer = new XmlSerializer(typeof(List<MapCoordinates>));
            using (StreamWriter streamWriter = new StreamWriter(fileNeighbours))
            {
                using (XmlTextWriter xmlWriter = new XmlTextWriter(streamWriter))
                {
                    xmlWriter.WriteProcessingInstruction(
                    "xml-stylesheet",
                    "type=\"text/xsl\" href=\"Neighbours.xslt\"");
                    xSer.Serialize(xmlWriter, villages);
                }
            }
        }

        public IList<MapCoordinates> MapVillages
        {
            get { return villages; }
        }

        private readonly Browser browser;
        private readonly List<MapCoordinates> villages = new List<MapCoordinates>();
        private readonly List<MapCoordinates> oasis = new List<MapCoordinates>();
        private readonly List<MapCoordinates> abandoned = new List<MapCoordinates>();
        private const string fileNeighbours = "Neighbours.xml";
    }
}