#region

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using log4net;
using TW.Helper;
using WatiN.Core;
using WatiN.Core.Native.Windows;
using Settings=WatiN.Core.Settings;

#endregion

namespace TW.Player
{
    public class ConsoleApp
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConsoleApp));
        
        public ConsoleApp()
        {
            Settings.CloseExistingBrowserInstances = false;
            browser = new IE(server);
            browser.ShowWindow(NativeMethods.WindowShowStyle.Show);
            playerTribe = GetTribe();
            playerFarmUnits = SetPlayerFarmUnits(playerTribe);
        }

        public void PlayGame()
        {
            using (browser)
            {
                Log.InfoFormat("Report reader : {0}, Raid : {1}", report, raid);
                DefaultPage browserPage = new DefaultPage(browser, server, username, password, defaultVillageId);
                browserPage.LoginPage().LoginToGame();
                isLoggedIn = browserPage.IsLogedIn;
                if (isLoggedIn)
                {
                    int repeatCount = 0;
                    int loginCount = 0;

                    Village village = new Village(0, "00");
                    gameData.AddVillage(village);
                    gameData.GameSettings(language);
                    browserPage.DefaultVillageId = 0;
                    Dorf1 dorf1Page = browserPage.Dorf1Page(gameData);
                    dorf1Page.Village = village;
                    dorf1Page.ClickDorf1Link();

                    do
                    {
                        if (isLoggedIn)
                        {
                            loginCount = 0;
                            farmList = LoadVillagesFromXml();
                            if (farmList.Count == 0)
                            {
                                Log.Info("Getting new farm list...");
                                farmList = dataBase.GetFarmList();
                            }
                            if (raid)
                            {
                                dorf1Page.ClickDorf1Link();
                                Raid(browserPage);
                            }
                            //if (dorf1Page.RemoveTroops)
                            //{
                            //    //remove troops
                            //}
                            //else
                            //{
                            //    Raid(browserPage);
                            //}
                            if (report)
                            {
                                IReportReader reportReader = browserPage.AttackReport(gameData);
                                reportReader.Collect();
                                reportReader.Parse();
                                reportReader.Save();
                                if (!raid)
                                {
                                    int count = 0;
                                    foreach (MapCoordinates mapCoordinate in farmList)
                                    {
                                        Map map = browserPage.MapPage();
                                        if (!map.GetVillageDetails(mapCoordinate))
                                        {
                                            dataBase.DeleteVillage(mapCoordinate.VillageId);
                                            Log.InfoFormat("Removed village : {0}", mapCoordinate);
                                        }
                                        else
                                        {
                                            dataBase.SaveVillageToDb(mapCoordinate);
                                        }
                                        raidedFarms.Add(mapCoordinate);
                                        if (count++ > 5)
                                        {
                                            break;
                                        }
                                    }
                                    RemoveRaidedFarms();
                                }
                            }
                            dorf1Page.ClickDorf1Link();
                        }
                        else
                        {
                            loginCount++;
                            if (!isLoggedIn)
                            {
                                Log.Warn("Not loged in. Sleep for 60 seconds...");
                                Thread.Sleep(60000);
                                if (loginCount > 3)
                                {
                                    Log.Warn("Failed to login!");
                                    break;
                                }
                            }
                        }
                        repeatCount++;
                        if (repeatCount > 100)
                        {
                            repeatCount = 0;
                        }
                        Log.InfoFormat("Sleep for {0}", dorf1Page.NextCheck);
                        Thread.Sleep(dorf1Page.NextCheck);
                    } while (repeatCount < 1000);
                }
                else
                {
                    Log.Warn("Login failed!!!");
                }
            }
            browser.Dispose();
        }

        private string SetPlayerFarmUnits(Tribes playersTribe)
        {
            string[] list = farmUnits.Split(',');
            string farmUnitList;
            switch (playersTribe)
            {
                case Tribes.Teutons:
                    {
                        Teutons teutons = new Teutons();
                        farmUnitList = teutons.GetClassNames(list);
                        break;
                    }
                case Tribes.Gauls:
                    {
                        Gauls gauls = new Gauls();
                        farmUnitList = gauls.GetClassNames(list);
                        break;
                    }
                case Tribes.Romans:
                    {
                        Romans romans = new Romans();
                        farmUnitList = romans.GetClassNames(list);
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Unknown Tribe specified!!!");
                    }
            }
            return farmUnitList;
        }

        private Tribes GetTribe()
        {
            switch (tribe)
            {
                case 1:
                    {
                        playerTribe = Tribes.Teutons;
                        break;
                    }
                case 2:
                    {
                        playerTribe = Tribes.Gauls;
                        break;
                    }
                case 3:
                    {
                        playerTribe = Tribes.Romans;
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Unknown Tribe specified!!!");
                    }
            }
            return playerTribe;
        }

        private void SaveVillagesToXml(IList<MapCoordinates> farms)
        {
            Log.Debug("SaveVillagesToXml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<MapCoordinates>));
            TextWriter textWriter = new StreamWriter(fileFarms);
            serializer.Serialize(textWriter, farms);
            textWriter.Close();
            raidedFarms.Clear();
        }

        private IList<MapCoordinates> LoadVillagesFromXml()
        {
            Log.Debug("LoadVillagesFromXml");
            if (!File.Exists(fileFarms))
            {
                Log.Info("Getting new farm list...");
                return dataBase.GetFarmList();
            }
            XmlSerializer serializer = new XmlSerializer(typeof (List<MapCoordinates>));
            TextReader textReader = new StreamReader(fileFarms);
            List<MapCoordinates> mapCoordinateses = (List<MapCoordinates>) serializer.Deserialize(textReader);
            textReader.Close();
            return mapCoordinateses;
        }

        private void Raid(DefaultPage browserPage)
        {
            Log.DebugFormat("Raid : [{0} troops available]", gameData.TroopList4Village.Count);
            foreach (
                KeyValuePair<Village, List<TroopList>> unitInVillage in gameData.TroopList4Village)

            {
                GetAvailableUnits(unitInVillage, browserPage);
            }
            RemoveRaidedFarms();
        }

        private void RemoveRaidedFarms()
        {
            foreach (MapCoordinates mapCoordinate in raidedFarms)
            {
                farmList.Remove(mapCoordinate);
                Log.DebugFormat("Removing {0} from farmList", mapCoordinate.VillageName);
            }
            SaveVillagesToXml(farmList);
        }

        private void GetAvailableUnits
            (KeyValuePair<Village, List<TroopList>> unitInVillage,
             DefaultPage browserPage)
        {
            Log.Debug("GetAvailableUnits");
            List<TroopList> troopLists = unitInVillage.Value;
            foreach (TroopList troopList in troopLists)
            {
                Log.DebugFormat("Class of troop : '{0}'", troopList.TroopClass);
                if (playerFarmUnits.IndexOf(troopList.TroopClass) > -1)
                {
                    if (troopList.Count >= minUnits4Send)
                    {
                        RaidFarms(troopList, browserPage, unitInVillage);
                    }
                }
            }
        }

        private void RaidFarms
            (TroopList troopList,
             DefaultPage browserPage,
             KeyValuePair<Village, List<TroopList>> unitInVillage)
        {
            Log.Debug("RaidFarms");
            int availableUnits = troopList.Count;
            foreach (MapCoordinates mapCoordinate in farmList)
            {
                Map map = browserPage.MapPage();
                if (!map.GetVillageDetails(mapCoordinate))
                {
                    dataBase.DeleteVillage(mapCoordinate.VillageId);
                    Log.InfoFormat("Removed village : {0}", mapCoordinate);
                    raidedFarms.Add(mapCoordinate);
                }
                else
                {
                    dataBase.SaveVillageToDb(mapCoordinate);
                    Log.DebugFormat("Updated village : {0}", mapCoordinate);
                    if (mapCoordinate.PlayerEnabled)
                    {
                        Log.InfoFormat("availableUnits : {0}", availableUnits);
                        if (availableUnits >= minUnits4Send)
                        {
                            Random random = new Random();
                            int randomUnitCount = random.Next(minUnits4Send,
                                                              maxUnits4Send);
                            if (randomUnitCount > availableUnits)
                            {
                                randomUnitCount = availableUnits;
                            }
                            SendTroops sendTroops = browserPage.SendTroopsPage();
                            if (sendTroops.Attack(new AttackSettings(mapCoordinate.VillageId, AttackType.Raid, "t1",
                                                                     randomUnitCount.ToString())))
                            {
                                availableUnits -= randomUnitCount;
                                raidedFarms.Add(mapCoordinate);
                                Log.InfoFormat(
                                    "Attacked '{3}' from '{0}' with {1} '{2}'",
                                    unitInVillage.Key.Name, randomUnitCount, troopList.TroopClass,
                                    mapCoordinate.VillageName);
                            }
                            else
                            {
                                Log.WarnFormat("Attack to '{0}' failed.", mapCoordinate.VillageName);
                            }
                        }
                        else
                        {
                            Log.Info("No more units for farming...");
                            return;
                        }
                    }
                    else
                    {
                        raidedFarms.Add(mapCoordinate);
                    }
                }
            }
        }

        private readonly Browser browser;
        private bool isLoggedIn;

        private readonly string server = ConfigurationManager.AppSettings["server"];
        private readonly string username = ConfigurationManager.AppSettings["username"];
        private readonly string password = ConfigurationManager.AppSettings["password"];
        private readonly int minUnits4Send = Misc.String2Number(ConfigurationManager.AppSettings["minUnits4Send"]);
        private readonly int maxUnits4Send = Misc.String2Number(ConfigurationManager.AppSettings["maxUnits4Send"]);
        private readonly int tribe = Misc.String2Number(ConfigurationManager.AppSettings["tribe"]);
        private readonly string farmUnits = ConfigurationManager.AppSettings["farmUnits"];
        private const int defaultVillageId = 0;
        private readonly DataBase dataBase = new DataBase();
        private readonly GameData gameData = new GameData();
        private IList<MapCoordinates> farmList = new List<MapCoordinates>();
        private readonly IList<MapCoordinates> raidedFarms = new List<MapCoordinates>();
        private const string fileFarms = "Farms.xml";
        private Tribes playerTribe;
        private readonly string playerFarmUnits;
        private readonly string language = ConfigurationManager.AppSettings["language"];
        private readonly bool raid = Misc.String2Bool(ConfigurationManager.AppSettings["raid"]);
        private readonly bool report = Misc.String2Bool(ConfigurationManager.AppSettings["report"]);
    }
}