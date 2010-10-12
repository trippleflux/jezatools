#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using log4net;
using WatiN.Core;

#endregion

namespace TW.Helper
{
    public class Dorf1 : DefaultPage
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Dorf1));

        public Dorf1
            (Browser browser,
             GameData gameData)
            : base(browser)
        {
            this.browser = browser;
            this.gameData = gameData;
            RemoveTroopsTimeSpan = defaultRemoveTroopsTimeSpan;
        }

        public Dorf1
            (Browser browser,
             string server,
             string username,
             string password,
             int defaultVillageId) : base(browser, server, username, password, defaultVillageId)
        {
            this.browser = browser;
            Server = server;
            DefaultVillageId = defaultVillageId;
            RemoveTroopsTimeSpan = defaultRemoveTroopsTimeSpan;
        }

        #region Page Elements

        private Table Movements
        {
            get { return browser.Table("movements"); }
        }

        private Table BuildingContract
        {
            get { return browser.Table("building_contract"); }
        }

        private TableRowCollection TableRowsMovements
        {
            get { return Movements.TableRows; }
        }

        private TableRowCollection TableRowsBuildingContract
        {
            get { return BuildingContract.TableRows; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the building contract time span.
        /// </summary>
        /// <returns><see cref="TimeSpan"/></returns> 
        private TimeSpan GetBuildingContractTimeSpan()
        {
            foreach (TableRow tableRow in TableRowsBuildingContract)
            {
                TableCellCollection tableCells = tableRow.TableCells;
                foreach (TableCell tableCell in tableCells)
                {
                    Span timeToEnd = tableCell.Span(Find.ById(new Regex("timer[0-9]")));
                    if (timeToEnd.Exists)
                    {
                        Log.DebugFormat(" BuildingContract timeToEnd='{0}'", timeToEnd);
                        return TimeSpan.Parse(timeToEnd.Text);
                    }
                }
            }
            return nextContractTimeSpan;
        }

        private List<TroopMovements> GetTroopMovements()
        {
            TimeSpan nextCheck = nextCheckTimeSpan;
            List<TroopMovements> troopMovements = new List<TroopMovements>();
            foreach (TableRow tableRow in TableRowsMovements)
            {
                if (tableRow.TableCells.Count == 2)
                {
                    TableCellCollection tableCells = tableRow.TableCells;
                    if (tableCells[0].Images.Count > 0)
                    {
                        //<img src="img/x.gif" class="att1" alt="Arriving attacking Troops" title="Arriving attacking Troops" />
                        Image image = tableCells[0].Images[0];
                        //<div class="mov"><span class="a1">1&nbsp;Attack</span></div>
                        Div divMov = tableCells[1].Div(Find.ByClass("mov"));
                        //<div class="dur_r">in&nbsp;<span id="timer1">0:32:28</span>
                        Div divDur = tableCells[1].Div(Find.ByClass("dur_r"));
                        string durration = divDur.Spans[0].Text;
                        string name = image.Title;
                        TroopMovementType type = MovementType(image.ClassName);
                        int number = Misc.String2Number(divMov.Text.Split(' ')[0]);
                        TimeSpan arrivalTime = TimeSpan.Parse(durration);
                        Log.DebugFormat("name = '{0}'", name);
                        Log.DebugFormat("type = '{0}'", type);
                        Log.DebugFormat("number = '{0}'", number);
                        Log.DebugFormat("durration = '{0}'", durration);
                        TroopMovements movements = new TroopMovements
                                                   {
                                                       Name = name,
                                                       Number = number,
                                                       Type = type,
                                                       ArrivalTime = arrivalTime,
                                                   };
                        troopMovements.Add(movements);
                        if (type == TroopMovementType.AttackIncoming)
                        {
                            if (arrivalTime <= RemoveTroopsTimeSpan)
                            {
                                RemoveTroops = true;
                            }
                            nextCheck = arrivalTime > RemoveTroopsTimeSpan.Add(RemoveTroopsTimeSpan)
                                            ? arrivalTime - RemoveTroopsTimeSpan
                                            : arrivalTime < RemoveTroopsTimeSpan
                                                  ? arrivalTime
                                                  : RemoveTroopsTimeSpan;
                        }
                        else
                        {
                            if (arrivalTime < nextCheck)
                            {
                                nextCheck = arrivalTime.Add(defaultTimeSpan);
                            }
                        }
                    }
                }
            }
            TimeSpan contractTimeSpan = GetBuildingContractTimeSpan();
            NextCheck = RemoveTroops
                            ? nextCheck
                            : contractTimeSpan < nextCheck
                                  ? contractTimeSpan
                                  : nextCheck;
            return troopMovements;
        }

        private static TroopMovementType MovementType(string type)
        {
            switch (type)
            {
                case "def1":
                    return TroopMovementType.ReinforcementIncomming;
                case "def2":
                    return TroopMovementType.ReinforcementOutgoing;
                case "att1":
                    return TroopMovementType.AttackIncoming;
                case "att2":
                    return TroopMovementType.AttackOutgoing;
                default:
                    return TroopMovementType.None;
            }
        }

        private Production GetProduction()
        {
            TableCell cellWood = browser.TableCell(Find.ById("l4"));
            TableCell cellClay = browser.TableCell(Find.ById("l3"));
            TableCell cellIron = browser.TableCell(Find.ById("l2"));
            TableCell cellCrop = browser.TableCell(Find.ById("l1"));
            const char separator = '/';
            Production production = new Production
                                    {
                                        WoodPerHour = Int32.Parse(cellWood.Title),
                                        Wood = Int32.Parse(cellWood.Text.Split(separator)[0]),
                                        ClayPerHour = Int32.Parse(cellClay.Title),
                                        Clay = Int32.Parse(cellClay.Text.Split(separator)[0]),
                                        IronPerHour = Int32.Parse(cellIron.Title),
                                        Iron = Int32.Parse(cellIron.Text.Split(separator)[0]),
                                        CropPerHour = Int32.Parse(cellCrop.Title),
                                        Crop = Int32.Parse(cellCrop.Text.Split(separator)[0]),
                                        WarehouseCapacity = Int32.Parse(cellWood.Text.Split(separator)[1]),
                                        GranaryCapacity = Int32.Parse(cellCrop.Text.Split(separator)[1])
                                    };
            Log.Debug(production.ToString());
            return production;
        }

        private TroopList GetTroopList()
        {
            TroopList troopList = new TroopList();
            Table tableTroops = browser.Table(Find.ById("troops"));
            if (tableTroops.Exists)
            {
                foreach (TableRow tableRow in tableTroops.TableRows)
                {
                    TableCell tableCell = tableRow.TableCell(Find.ByClass("ico"));
                    if (tableCell.Exists)
                    {
                        Link unitLink = tableCell.Link(Find.ByUrl(new Regex("build.php.gid=16")));
                        string troopClass = unitLink.Image(Find.BySrc(new Regex("img.x.gif"))).ClassName;
                        int troopCount = Int32.Parse(tableRow.TableCell(Find.ByClass("num")).Text);
                        troopList.AddTroop(new TroopList(troopClass, troopCount));
                    }
                }
            }
            return troopList;
        }

        #endregion

        public TimeSpan NextCheck { get; set; }
        public List<TroopMovements> TroopMovements { get; set; }
        public bool RemoveTroops { get; set; }

        public void ClickDorf1Link()
        {
            Log.DebugFormat("Navigating to Village overview in Village '{0}'", Village.Name);
            string url = String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php?newdid={1}", Server, Village.Id);
            browser.GoTo(url);
            ParseProduction();
            ParseTroops();
            ParseTroopMovements();
        }

        /// <summary>
        /// Gets the production for village.
        /// </summary>
        public void ParseProduction()
        {
            gameData.AddProductionForVillage(Village, GetProduction());
        }

        /// <summary>
        /// Gets the list of troops available in village.
        /// </summary>
        public void ParseTroops()
        {
            gameData.AddTroopsForVillage(Village, GetTroopList());
        }

        /// <summary>
        /// Gets the info of moving troops.
        /// </summary>
        public void ParseTroopMovements()
        {
            gameData.AddTroopMovementsForVillage(Village, GetTroopMovements());
        }

        private readonly Browser browser;
        private readonly GameData gameData;
        public Village Village { get; set; }
        public TimeSpan RemoveTroopsTimeSpan { get; set; }
        private readonly TimeSpan defaultTimeSpan = new TimeSpan(0, 0, 4);
        private readonly TimeSpan defaultRemoveTroopsTimeSpan = new TimeSpan(0, 0, 10);
        private readonly TimeSpan nextCheckTimeSpan = new TimeSpan(0, 5, 0);
        private readonly TimeSpan nextContractTimeSpan = new TimeSpan(1, 0, 0, 0);
    }
}