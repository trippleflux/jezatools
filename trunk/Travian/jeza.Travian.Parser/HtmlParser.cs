#region

using System;
using System.Collections.Generic;
using System.Globalization;
using HtmlAgilityPack;
using jeza.Travian.Framework;

#endregion

namespace jeza.Travian.Parser
{
    public class HtmlParser
    {
        public HtmlParser(HtmlDocument htmlDocument)
        {
            this.htmlDocument = htmlDocument;
            language = null;
        }

        public HtmlParser(HtmlDocument htmlDocument, Language language)
        {
            this.htmlDocument = htmlDocument;
            this.language = language;
        }

        /// <summary>
        /// Gets the available troops in village.
        /// </summary>
        /// <returns></returns>
        public Troops GetAvailableTroops()
        {
            Troops troops = new Troops();
            HtmlNode tableTroops = htmlDocument.DocumentNode.SelectSingleNode("//table[@id='troops']");
            if (tableTroops != null)
            {
                HtmlNodeCollection htmlNodeCollection = tableTroops.SelectNodes("./tbody//tr");
                if (htmlNodeCollection != null)
                {
                    foreach (HtmlNode htmlNode in htmlNodeCollection)
                    {
                        if (htmlNode != null)
                        {
                            HtmlNode element = htmlNode.Element("td").Element("a");
                            if (element != null)
                            {
                                string classAttribute = element.Element("img").Attributes["class"].Value;
                                int unitCount = Misc.String2Number(htmlNode.SelectSingleNode("./td[2]").InnerText);
                                string titleAttribute = htmlNode.SelectSingleNode("./td[3]").InnerText;
                                troops.AddTroopUnit(
                                    new TroopUnit(titleAttribute, unitCount).AddHtmlClassName(classAttribute));
                            }
                        }
                    }
                }
            }
            return troops;
        }

        /// <summary>
        /// Gets the available villages.
        /// </summary>
        /// <returns></returns>
        public List<Village> GetAvailableVillages()
        {
            List<Village> villages = new List<Village>();
            HtmlNode tableVillages = htmlDocument.DocumentNode.SelectSingleNode("//table[@id='vlist']");
            if (tableVillages == null)
            {
                HtmlNode nodeVillage = htmlDocument.DocumentNode.SelectSingleNode("//h1");
                Village village = new Village();
                village.AddName(nodeVillage.InnerText.Trim());
                villages.Add(village);
            }
            else
            {
                foreach (HtmlNode htmlNodeVillage in tableVillages.SelectNodes("./tbody//tr"))
                {
                    //<td class="link"><a href="?newdid=75579" >01</a></td>
                    HtmlNode htmlNode = htmlNodeVillage.SelectSingleNode("./td[@class='link']/a");
                    string villageName = htmlNode.InnerText.Trim();
                    string villageId = htmlNode.Attributes["href"].Value.Trim();
                    //<div class="cox">(-82</div>
                    HtmlNode nodeCoordsX = htmlNodeVillage.SelectSingleNode(".//div[@class='cox']");
                    string x = nodeCoordsX.InnerText.Trim().Substring(1);
                    //<div class="coy">64)</div>
                    HtmlNode nodeCoordsY = htmlNodeVillage.SelectSingleNode(".//div[@class='coy']");
                    string trimY = nodeCoordsY.InnerText.Trim();
                    string y = trimY.Substring(0, trimY.Length - 1);
                    Village village = new Village();
                    village
                        .AddName(villageName)
                        .AddId(Misc.String2Number(villageId.Substring(8)))
                        .UpdateCoordinates(Misc.String2Number(x), Misc.String2Number(y));
                    villages.Add(village);
                }
            }
            return villages;
        }

        public List<Valley> GetOasesFromMap()
        {
            return GetValleys('o', ValleyType.UnoccupiedOasis);
        }

        /// <summary>
        /// Gets the oases details.
        /// </summary>
        /// <returns><see cref="Valley"/></returns>
        public Valley GetOasesDetails()
        {
            Valley valley = new Valley();
            HtmlNode nodeHead = htmlDocument.DocumentNode.SelectSingleNode("//h1");
            if (nodeHead != null)
            {
                string innerText = nodeHead.InnerText.Trim();
                int indexOf = innerText.LastIndexOf('(');
                if (indexOf > -1)
                {
                    string name = innerText.Substring(0, indexOf - 1);
                    string coordinates = innerText.Substring(indexOf).Trim();
                    string[] strings = coordinates.Split('|', '(', ')');
                    int coordinateX = Misc.String2Number(strings[1]);
                    int coordinateY = Misc.String2Number(strings[2]);
                    valley
                        .AddName(name)
                        .AddCoordinates(coordinateX, coordinateY)
                        .AddAlliance(name, "")
                        .AddPlayer(name, "")
                        .AddPopulation(0)
                        .AddType(ValleyType.UnoccupiedOasis);
                }
            }
            //<img src="img/x.gif" id="detailed_map" class="w8" alt="+25% železa na uro" title="+25% železa na uro" />
            HtmlNode nodeInfo = htmlDocument.DocumentNode.SelectSingleNode("//img[@id='detailed_map']");
            if (nodeInfo != null)
            {
                valley.AddName(nodeInfo.Attributes["title"].Value.Trim());
            }
            //<table cellpadding="1" cellspacing="1" id="village_info" class="tableNone">
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//table[@id='village_info']");
            if (nodes != null)
            {
                HtmlNode alliance = nodes[0].SelectSingleNode("./tr[1]/td/a");
                string allianceUrl = alliance.Attributes["href"].Value;
                string allianceName = alliance.InnerText.Trim();
                HtmlNode player = nodes[0].SelectSingleNode("./tr[2]/td/a");
                string playerUrl = player.Attributes["href"].Value;
                string playerName = player.InnerText.Trim();
                HtmlNode village = nodes[0].SelectSingleNode("./tr[3]/td/a");
                string villageName = String.Format(CultureInfo.InvariantCulture, "{0}[{1}]", village.InnerText.Trim(),
                                                   valley.Name);
                valley
                    .AddName(villageName)
                    .AddAlliance(allianceName, allianceUrl)
                    .AddPlayer(playerName, playerUrl)
                    .AddType(ValleyType.OccupiedOasis);
            }
            return valley;
        }

        /// <summary>
        /// Gets the center village buildings levels.
        /// </summary>
        /// <param name="village">The village.</param>
        /// <returns></returns>
        public List<Buildings> GetCenterBuildings(Village village)
        {
            List<Buildings> resources = new List<Buildings>();
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//map[@id='map2']//area");
            if (nodes != null)
            {
                bool wallAdded = false;
                foreach (HtmlNode htmlNode in nodes)
                {
                    if (htmlNode != null)
                    {
                        //<area href="build.php?id=19" title="Žitnica Stopnja 10" alt="Žitnica Stopnja 10" coords="53,91,53,37,128,37,128,91,91,112" shape="poly"/>
                        string url = htmlNode.Attributes["href"].Value;
                        if (url.StartsWith("build.php"))
                        {
                            int id = Misc.String2Number(url.Substring(13));
                            string name = htmlNode.Attributes["title"].Value;
                            int index = name.LastIndexOf(' ');
                            int level = Misc.String2Number(name.Substring(index + 1));
                            if (!wallAdded)
                            {
                                if (id == 40)
                                {
                                    wallAdded = true;
                                }
                                resources.Add(
                                    new Buildings
                                        {
                                            Id = id,
                                            Name = name,
                                            Url = url,
                                            Level = level,
                                        });
                            }
                        }
                    }
                }
            }
            return resources;
        }

        /// <summary>
        /// Gets the village production.
        /// </summary>
        /// <returns></returns>
        public Production GetProduction()
        {
            Production production = new Production();
            //<td id="l4" title="575">4675/14400</td>
            //<td id="l3" title="590">3343/14400</td>
            //<td id="l2" title="525">4463/14400</td>
            //<td id="l1" title="359">5236/11800</td>
            int perHourWood = 0, perHourClay = 0, perHourIron = 0, perHourCrop = 0;
            int totalWood = 0, totalClay = 0, totalIron = 0, totalCrop = 0;
            int wareHouse = 0;
            int granary = 0;
            HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//td[@id='l4']");
            if (htmlNode != null)
            {
                perHourWood = Misc.String2Number(htmlNode.Attributes["title"].Value);
                string[] values = htmlNode.InnerText.Trim().Split('/');
                totalWood = Misc.String2Number(values[0]);
                wareHouse = Misc.String2Number(values[1]);
            }
            htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//td[@id='l3']");
            if (htmlNode != null)
            {
                perHourClay = Misc.String2Number(htmlNode.Attributes["title"].Value);
                string[] values = htmlNode.InnerText.Trim().Split('/');
                totalClay = Misc.String2Number(values[0]);
                wareHouse = Misc.String2Number(values[1]);
            }
            htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//td[@id='l2']");
            if (htmlNode != null)
            {
                perHourIron = Misc.String2Number(htmlNode.Attributes["title"].Value);
                string[] values = htmlNode.InnerText.Trim().Split('/');
                totalIron = Misc.String2Number(values[0]);
                wareHouse = Misc.String2Number(values[1]);
            }
            htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//td[@id='l1']");
            if (htmlNode != null)
            {
                perHourCrop = Misc.String2Number(htmlNode.Attributes["title"].Value);
                string[] values = htmlNode.InnerText.Trim().Split('/');
                totalCrop = Misc.String2Number(values[0]);
                granary = Misc.String2Number(values[1]);
            }
            production
                .UpdatePerHour(perHourWood, perHourClay, perHourIron, perHourCrop)
                .UpdateTotals(totalWood, totalClay, totalIron, totalCrop)
                .UpdateWarehouse(wareHouse)
                .UpdateGranary(granary);
            return production;
        }

        /// <summary>
        /// Gets the resource buildings levels.
        /// </summary>
        /// <returns></returns>
        public List<Buildings> GetResourceBuildings()
        {
            List<Buildings> resources = new List<Buildings>();
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//map[@id='rx']//area");
            if (nodes != null)
            {
                foreach (HtmlNode htmlNode in nodes)
                {
                    if (htmlNode != null)
                    {
                        //<area href="build.php?id=1" coords="101,33,28" shape="circle" title="Gozdar Stopnja 10" alt="Gozdar Stopnja 10"/>
                        string url = htmlNode.Attributes["href"].Value;
                        if (url.StartsWith("build.php"))
                        {
                            int id = Misc.String2Number(url.Substring(13));
                            string name = htmlNode.Attributes["title"].Value;
                            int index = name.LastIndexOf(' ');
                            int level = Misc.String2Number(name.Substring(index + 1));
                            resources.Add(
                                new Buildings
                                    {
                                        Id = id,
                                        Name = name,
                                        Url = url,
                                        Level = level,
                                    });
                        }
                    }
                }
            }
            return resources;
        }

        public ResourcesForUpgrade GetResourcesForNextLevel()
        {
            ResourcesForUpgrade resourcesForUpgrade = new ResourcesForUpgrade();
            //<h1>Herojeva rezidenca <span class="level">Stopnja 4</span></h1>
            HtmlNode head = htmlDocument.DocumentNode.SelectSingleNode("//h1");
            if (head != null)
            {
                string title = head.InnerText.Trim();
                int index = title.LastIndexOf(' ');
                if (index > -1)
                {
                    resourcesForUpgrade.CurrentLevel = Misc.String2Number(title.Substring(index + 1));
                }
            }
            HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//p[@id='contract']");
            if (htmlNode != null)
            {
                string[] values = htmlNode.InnerText.Split('|', ':');
                resourcesForUpgrade.Wood = Misc.String2Number(values[1].Trim());
                resourcesForUpgrade.Clay = Misc.String2Number(values[2].Trim());
                resourcesForUpgrade.Iron = Misc.String2Number(values[3].Trim());
                resourcesForUpgrade.Crop = Misc.String2Number(values[4].Trim());
                HtmlNode node = htmlNode.SelectSingleNode("./a");
                //dorf2.php?a=30&c=093667
                if (node != null)
                {
                    string upgradeUrl = node.Attributes["href"].Value.Trim();
                    //build.php?gid=17&t=3&bid=35&r1=2190&r2=2095&r3=2190&r4=750
                    if (upgradeUrl.IndexOf("gid=17") < 0)
                    {
                        resourcesForUpgrade.UpgradeUrl = upgradeUrl.Replace("&amp;", "&");
                        string[] spliter = upgradeUrl.Split(new[] {"?", "&amp;"}, StringSplitOptions.RemoveEmptyEntries);
                        resourcesForUpgrade.UrlParameters = spliter;
                    }
                    else
                    {
                        resourcesForUpgrade.UpgradeUrl = null;
                    }
                }
                else
                {
                    resourcesForUpgrade.UpgradeUrl = null;
                }
            }
            return resourcesForUpgrade;
        }

        private List<Valley> GetValleys(char prefix, ValleyType valleyType)
        {
            //o1 : +25%wood
            //o2 : +25%wood
            //o3 : +25%wood, +25%crop
            //o4 : +25%clay
            //o5 : +25%clay
            //o6 : +25%clay, +25%crop
            //o7 : +25%iron
            //o8 : +25%iron
            //o9 : +25%iron, +25%crop
            //o10 : +25%crop
            //o11 : +25%crop
            //o12 : +50%crop

            List<Valley> valleys = new List<Valley>();
            List<string> table = new List<string>();
            FillTable(table, prefix);
            foreach (string list in table)
            {
                //<area id="a_0_0" shape="poly" coords="53, 137, 90, 157, 53, 177, 16, 157" title="Nezasedena pokrajina" href="karte.php?d=273457&c=e4" />
                HtmlNodeCollection areaNode =
                    htmlDocument.DocumentNode.SelectNodes(String.Format(CultureInfo.InvariantCulture,
                                                                        "//area[@id='{0}']", list));
                Valley oases = new Valley();
                oases
                    .AddName(areaNode[0].Attributes["title"].Value)
                    .AddUrl(areaNode[0].Attributes["href"].Value)
                    .AddType(valleyType);
                valleys.Add(oases);
            }
            return valleys;
        }

        /// <summary>
        /// Gets the village details.
        /// </summary>
        /// <returns><see cref="Valley"/></returns>
        public Valley GetVillageDetails()
        {
            Valley valley = new Valley();
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//table[@id='village_info']");
            if (nodes != null)
            {
                HtmlNode head = nodes[0].SelectSingleNode("./thead/tr/th");
                HtmlNode nodeVillageName = head.SelectSingleNode("./div");
                string villageName = nodeVillageName.InnerText;
                HtmlNode nodeVillageCoords = head.SelectSingleNode(".");
                string coordinates =
                    nodeVillageCoords.InnerText.Substring(nodeVillageCoords.InnerText.LastIndexOf('(')).Trim();
                string[] strings = coordinates.Split('|', '(', ')');
                int coordinateX = Misc.String2Number(strings[1]);
                int coordinateY = Misc.String2Number(strings[2]);
                HtmlNode alliance = nodes[0].SelectSingleNode("./tbody/tr[2]/td/a");
                string allianceUrl = alliance.Attributes["href"].Value;
                string allianceName = alliance.InnerText.Trim();
                HtmlNode player = nodes[0].SelectSingleNode("./tbody/tr[3]/td/a");
                string playerUrl = player.Attributes["href"].Value;
                string playerName = player.InnerText.Trim();
                HtmlNode population = nodes[0].SelectSingleNode("./tbody/tr[4]/td");
                int villagePopulation = Misc.String2Number(population.InnerText.Trim());
                valley
                    .AddName(villageName)
                    .AddCoordinates(coordinateX, coordinateY)
                    .AddAlliance(allianceName, allianceUrl)
                    .AddPlayer(playerName, playerUrl)
                    .AddPopulation(villagePopulation)
                    .AddType(ValleyType.FarmLowRisk);
            }
            return valley;
        }

        /// <summary>
        /// Parse villages from map field.
        /// </summary>
        public List<Valley> GetVillagesFromMap()
        {
            return GetValleys('b', ValleyType.FarmLowRisk);
        }

        /// <summary>
        /// Parse market place.
        /// </summary>
        /// <returns><see cref="MarketPlace"/></returns>
        public MarketPlace MarketPlace()
        {
            MarketPlace marketPlace = new MarketPlace();
            HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//table[@id='target_select']");
            if (htmlNode != null)
            {
                HtmlNode node = htmlNode.SelectSingleNode("./tr/td");
                if (node != null)
                {
                    string innerText = node.InnerText;
                    int indexOf = innerText.LastIndexOf(' ');
                    if (indexOf > -1)
                    {
                        string[] merchanst = innerText.Substring(indexOf).Trim().Split('/');
                        marketPlace.AvailableMerchants = Misc.String2Number(merchanst[0]);
                        marketPlace.TotalMerchants = Misc.String2Number(merchanst[1]);
                    }
                }
            }
            htmlNode =
                htmlDocument.DocumentNode.SelectSingleNode(String.Format(CultureInfo.InvariantCulture,
                                                                         "//p[starts-with(text(), '{0}')]",
                                                                         language.MarketPlace.TotalCarry));
            if (htmlNode != null)
            {
                string text = htmlNode.InnerHtml;
                string[] spliter = text.Split(new string[]{"<b>", "</b>"}, StringSplitOptions.RemoveEmptyEntries);
                marketPlace.TotalCarry = Misc.String2Number(spliter[1].Trim());
            }
            return marketPlace;
        }

        /// <summary>
        /// Gets troop movements from rally point.
        /// </summary>
        /// <returns><see cref="List{T}"/></returns>
        public List<TroopMovement> TroopMovements(Village village)
        {
            List<TroopMovement> troopMovement = new List<TroopMovement>();
            DateTime dt = new DateTime(DateTime.Now.Ticks);
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//table[@class='troop_details']");
            if (nodes != null)
            {
                foreach (HtmlNode tableNode in nodes)
                {
                    TroopMovement movement = new TroopMovement();
                    //source and destination
                    HtmlNodeCollection htmlNodeCollection = tableNode.SelectNodes(".//thead/tr/td//a");
                    if (htmlNodeCollection != null)
                    {
                        HtmlNode nodeSource = htmlNodeCollection[0];
                        movement.SetSource(nodeSource.InnerText,
                                           nodeSource.Attributes["href"].Value);
                        HtmlNode nodeDestination = htmlNodeCollection[1];
                        movement.SetDestination(nodeDestination.InnerText,
                                                nodeDestination.Attributes["href"].Value);
                    }
                    //units
                    HtmlNodeCollection nodeCollection = tableNode.SelectNodes(".//tbody[@class='units']//td");
                    if (nodeCollection != null)
                    {
                        Troops troops = new Troops();
                        int totalUnits = nodeCollection.Count/2;
                        for (int i = 0; i < totalUnits; i++)
                        {
                            string classAttribute = nodeCollection[i].Element("img").Attributes["class"].Value;
                            string titleAttribute = nodeCollection[i].Element("img").Attributes["title"].Value;
                            int unitCount = Misc.String2Number(nodeCollection[i + totalUnits].InnerText);
                            troops.AddTroopUnit(new TroopUnit(titleAttribute, unitCount).AddHtmlClassName(classAttribute));
                        }
                        movement.AddTroops(troops);
                    }
                    //resoures
                    HtmlNodeCollection arrivalSpan =
                        tableNode.SelectNodes(".//tbody[@class='infos']//span[starts-with(@id, 'timer')]");
                    if (arrivalSpan != null)
                    {
                        TimeSpan timeSpan = Misc.String2TimeSpan(arrivalSpan[0].InnerText);
                        movement.SetDate(dt + timeSpan);
                        if (movement.SourceVillageName.Equals(village.Name))
                        {
                            //own troops
                            string destinationVillageName = movement.DestinationVillageName;
                            if ((destinationVillageName.StartsWith(language.RallyPoint.AttackOut)) ||
                                (destinationVillageName.StartsWith(language.RallyPoint.RaidOut)))
                            {
                                movement.SetType(TroopMovementType.AttackOutgoing);
                            }
                            else if (destinationVillageName.StartsWith(language.RallyPoint.ReinforcementBack))
                            {
                                movement.SetType(TroopMovementType.ReinforcementIncomming);
                            }
                            else if (destinationVillageName.StartsWith(language.RallyPoint.Scout))
                            {
                                movement.SetType(TroopMovementType.Scouting);
                            }
                            else
                            {
                                movement.SetType(TroopMovementType.ReinforcementOutgoing);
                            }
                        }
                        else
                        {
                            string destinationVillageName = movement.DestinationVillageName;
                            if ((destinationVillageName.StartsWith(language.RallyPoint.AttackIn)) ||
                                (destinationVillageName.StartsWith(language.RallyPoint.RaidIn)))
                            {
                                movement.SetType(TroopMovementType.AttackIncomming);
                            }
                            else
                            {
                                movement.SetType(TroopMovementType.ReinforcementIncomming);
                            }
                        }
                    }
                    else
                    {
                        movement.SetType(TroopMovementType.Idle);
                        movement.SetDestination("", "");
                    }
                    troopMovement.Add(movement);
                }
            }
            return troopMovement;
        }

        private void FillTable(ICollection<string> table, char prefix)
        {
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//div[@id='map_content']");
            if (nodes != null)
            {
                foreach (HtmlNode mapContentNode in nodes)
                {
                    if (mapContentNode != null)
                    {
                        HtmlNodeCollection htmlNodeCollection =
                            mapContentNode.SelectNodes(".//div[starts-with(@class, '" + prefix + "')]");
                        if (htmlNodeCollection != null)
                        {
                            foreach (HtmlNode htmlNode in htmlNodeCollection)
                            {
                                if (htmlNode != null) table.Add("a" + htmlNode.Attributes["id"].Value.Substring(1));
                            }
                        }
                    }
                }
            }
        }

        private readonly HtmlDocument htmlDocument;
        private readonly Language language;
    }
}