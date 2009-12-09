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
    public class ReportAttack : DefaultPage, IReportReader
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (ReportAttack));

        public ReportAttack
            (Browser browser,
             GameData gameData) : base(browser)
        {
            this.browser = browser;
            this.gameData = gameData;
        }

        public ReportAttack
            (Browser browser,
             string server,
             string username,
             string password,
             int defaultVillageId) : base(browser, server, username, password, defaultVillageId)
        {
            this.browser = browser;
            Server = server;
            DefaultVillageId = defaultVillageId;
        }

        public void Collect()
        {
            browser.GoTo(String.Format(CultureInfo.InvariantCulture, "{0}berichte.php?t=3", Server));
            Table tableReports = browser.Table(Find.ById("overview"));
            if (tableReports.Exists)
            {
                foreach (TableRow tableRow in tableReports.TableRows)
                {
                    if (tableRow.TableCells.Count == 3)
                    {
                        Link link = tableRow.TableCells[1].Link(Find.ByUrl(new Regex("berichte.php.id=*")));
                        string reportUrl = link.Url;
                        int reportId = 0;
                        Regex regReportId = new Regex(@"berichte.php.id=([0-9]{0,16})");
                        if (regReportId.IsMatch(reportUrl))
                        {
                            Match mc = regReportId.Matches(reportUrl)[0];
                            reportId = Misc.String2Number(mc.Groups[1].Value.Trim());
                        }
                        string reportText = link.Text;
                        Log.DebugFormat("reportId={0}, reportText={1}, reportUrl={2}", reportId,
                                        reportText, reportUrl);
                        Report report = new Report(reportUrl, reportText)
                                        {
                                            Id = reportId,
                                        };
                        reports.Add(report);
                    }
                }
            }
        }

        public void Parse()
        {
            foreach (Report report in reports)
            {
                browser.GoTo(report.Url);
                ParseDate(report);
                ParseAttackerInfo(report);
                ParseDefenderInfo(report);
                Log.InfoFormat("Parsing report : {0}", report.Id);
            }
        }

        public void ParseDate(Report report)
        {
            Table reportsurround = browser.Table(Find.ById("report_surround"));
            if (reportsurround.Exists)
            {
                //on 22.11.09 at 09:35:37 
                string date = reportsurround.TableRows[1].TableCells[1].Text.Trim();
                Log.DebugFormat("date={0}", date);
                string[] reportDate = date.Split(' ');
                string currentDay = gameData.Settings.Reports.NameOfCurrentDay;
                Log.DebugFormat("settings={0}", currentDay);
                Log.DebugFormat("report={0}", reportDate[1]);
                string day = reportDate[1].Equals(currentDay) ? DateTime.Now.ToShortDateString() : reportDate[1];
                DateTime dateTime =
                    DateTime.Parse(String.Format(CultureInfo.InvariantCulture, "{0} {1}", day, reportDate[3]));
                report.Date = dateTime;
            }
            else
            {
                report.Date = DateTime.Now;
            }
        }

        public void ParseAttackerInfo(Report report)
        {
            Table attacker = browser.Table(Find.ById("attacker"));
            if (attacker.Exists)
            {
                TableInfo tableInfo = GetInfo(attacker, true);
                report.AttackerId = tableInfo.Id;
                report.AttackerName = tableInfo.Name;
                report.AttackerVillageId = tableInfo.VillageId;
                report.AttackerVillageName = tableInfo.VillageName;
                report.TribeAttacker = tableInfo.OwnTribe;
                report.TribeReinforcements = tableInfo.Tribe;
                report.Troops = tableInfo.Troops;
                report.Casualties = tableInfo.Casualties;
                report.Goods = tableInfo.Goods;
                report.Prisoners = tableInfo.Prisoners;
            }
        }

        public void ParseDefenderInfo(Report report)
        {
            List<Table> defender = GetDefender();
            foreach (Table table in defender)
            {
                TableInfo tableInfo = GetInfo(table, false);
                if (tableInfo.Reinforcements)
                {
                    Log.Debug("Reinforcement");
                }
                report.DefenderId = tableInfo.Id;
                report.DefenderName = tableInfo.Name;
                report.DefenderVillageId = tableInfo.VillageId;
                report.DefenderVillageName = tableInfo.VillageName;
                report.TribeDefender = tableInfo.OwnTribe;
                report.TribeReinforcements = tableInfo.Tribe;
                report.TroopsDefender = tableInfo.Troops;
                report.CasualtiesDefender = tableInfo.Casualties;
                report.TribeReinforcements = tableInfo.Tribe;
            }
        }

        private List<Table> GetDefender()
        {
            List<Table> defender = new List<Table>();
            TableCollection tableCollection = browser.Tables;
            foreach (Table table in tableCollection)
            {
                if (table.ClassName == null)
                {
                    continue;
                }
                if (table.ClassName.Equals("defender"))
                {
                    defender.Add(table);
                }
            }
            return defender;
        }

        private TableInfo GetInfo
            (IElementContainer table,
             bool isAttacker)
        {
            TableCell tableCell = table.TableRows[0].TableCells[1];
            TableInfo tableInfo = new TableInfo();
            if (tableCell.Links.Count == 2)
            {
                GetReportOwner(tableCell, tableInfo);
                GetUnitInfo(table, tableInfo, isAttacker);
                GetBounty(table, tableInfo);
            }
            else
            {
                tableInfo.Reinforcements = true;
                GetEmptyNames(tableInfo);
                GetTribe(false, table, tableInfo, 1);
                GetUnitInfo(table, tableInfo, isAttacker);
            }
            return tableInfo;
        }

        private static void GetBounty
            (IElementContainer table,
             TableInfo tableInfo)
        {
            TableBody tableBodyGoods = table.TableBody(Find.ByClass("goods"));
            int[] goods = new int[4];
            if (tableBodyGoods.Exists)
            {
                string[] resources = tableBodyGoods.TableRows[0].TableCells[0].Divs[0].Text.Split('|');
                for (int i = 0; i < 4; i++)
                {
                    goods[i] = Misc.String2Number(resources[i].Trim());
                }
            }
            tableInfo.Goods = goods;
        }

        private void GetUnitInfo
            (IElementContainer table,
             TableInfo tableInfo,
             bool isAttacker)
        {
            TableBody tableBodyUnits = table.TableBody(Find.ByClass("units"));
            const int total = 11;
            int[] troops = new int[total];
            int[] casualties = new int[total];
            int[] prisoners = new int[total];
            if (tableBodyUnits.Exists)
            {
                if (tableBodyUnits.TableRows.Count == 2)
                {
                    GetTribe(true, table, tableInfo, 0);
                }
                else
                {
                    GetTribe(true, table, tableInfo, 1);
                }
                foreach (TableRow tableRow in tableBodyUnits.TableRows)
                {
                    string header = tableRow.Text;
                    if (!(header.Length > 1))
                    {
                        continue;
                    }
                    if (isAttacker)
                    {
                        if (header.StartsWith(gameData.Settings.Reports.RowAttackerTroops))
                        {
                            troops = GetTroops(tableRow);
                        }
                        if (header.StartsWith(gameData.Settings.Reports.RowAttackerPrisoners))
                        {
                            prisoners = GetTroops(tableRow);
                        }
                        if (header.StartsWith(gameData.Settings.Reports.RowAttackerCasualties))
                        {
                            casualties = GetTroops(tableRow);
                        }
                    }
                    else
                    {
                        if (header.StartsWith(gameData.Settings.Reports.RowDefenderTroops))
                        {
                            troops = GetTroops(tableRow);
                        }
                        if (header.StartsWith(gameData.Settings.Reports.RowDefenderCasualties))
                        {
                            casualties = GetTroops(tableRow);
                        }
                    }
                }
                tableInfo.Troops = troops;
                tableInfo.Casualties = casualties;
                tableInfo.Prisoners = prisoners;
            }
        }

        private static int[] GetTroops
            (ElementContainer<TableRow> tableRow)
        {
            int[] troops = new int[11];
            if (tableRow.Exists)
            {
                for (int i = 0; i < 10; i++)
                {
                    troops[i] = Misc.String2Number(tableRow.TableCells[i].Text.Trim());
                }
                int count = tableRow.TableCells.Count;
                troops[10] = count == 11
                                 ? Misc.String2Number(tableRow.TableCells[10].Text.Trim())
                                 : 0;
            }
            return troops;
        }

        private static void GetReportOwner
            (IElementContainer tableCell,
             TableInfo tableInfo)
        {
            if (tableCell.Links.Count == 0)
            {
                GetEmptyNames(tableInfo);
                return;
            }
            tableInfo.Name = tableCell.Links[0].Text;
            string defenderIdLink = tableCell.Links[0].Url;
            Regex regDefenderId = new Regex(@"spieler.php.uid=([0-9]{0,9})");
            if (regDefenderId.IsMatch(defenderIdLink))
            {
                Match mc = regDefenderId.Matches(defenderIdLink)[0];
                tableInfo.Id = Misc.String2Number(mc.Groups[1].Value.Trim());
            }
            tableInfo.VillageName = tableCell.Links[1].Text;
            string defenderVillageIdLink = tableCell.Links[1].Url;
            Regex regDefenderVillageId = new Regex(@"karte.php.d=([0-9]{0,9})&c=");
            if (regDefenderVillageId.IsMatch(defenderVillageIdLink))
            {
                Match mc = regDefenderVillageId.Matches(defenderVillageIdLink)[0];
                tableInfo.VillageId = Misc.String2Number(mc.Groups[1].Value.Trim());
            }
        }

        private static void GetEmptyNames(TableInfo tableInfo)
        {
            const string empty = "???";
            tableInfo.Name = empty;
            tableInfo.VillageName = empty;
            tableInfo.Id = 0;
            tableInfo.VillageId = 0;
        }

        private static void GetTribe
            (bool ownTribe,
             IElementContainer table,
             TableInfo tableInfo,
             int index)
        {
            Image image = table.TableRows[1].TableCells[index].Images[0];
            if (image.Exists)
            {
                string className = image.ClassName;
                Tribes tribe;
                if (className.ToLowerInvariant().Equals("unit u1"))
                {
                    tribe = Tribes.Romans;
                }
                else if (className.ToLowerInvariant().Equals("unit u11"))
                {
                    tribe = Tribes.Teutons;
                }
                else if (className.ToLowerInvariant().Equals("unit u21"))
                {
                    tribe = Tribes.Gauls;
                }
                else if (className.ToLowerInvariant().Equals("unit u31"))
                {
                    tribe = Tribes.Nature;
                }
                else
                {
                    tribe = Tribes.Monsters;
                }
                if (ownTribe)
                {
                    tableInfo.OwnTribe = tribe;
                }
                else
                {
                    tableInfo.Tribe = tribe;
                }
            }
        }

        public void Save()
        {
            DataBase dataBase = new DataBase();
            if (dataBase.SaveReports(reports) && deleteReports)
            {
                browser.GoTo(String.Format(CultureInfo.InvariantCulture, "{0}berichte.php?t=3", Server));
                //CheckBoxCollection checkBoxes = browser.CheckBoxes;
                foreach (Report report in reports)
                {
                    CheckBox checkBox = browser.CheckBox(Find.ByValue(report.Id.ToString()));
                    if (checkBox.Exists)
                    {
                        checkBox.Checked = true;
                    }
                }
                //<input type="image" src="img/x.gif" class="dynamic_img " id="btn_delete" alt="delete" value="delete" name="del"/>
                Image image = browser.Image(Find.ById("btn_delete"));
                if (image.Exists)
                {
                    image.Click();
                }
            }
        }

        public void AddReport(Report report)
        {
            reports.Add(report);
        }

        private readonly Browser browser;
        private readonly GameData gameData;
        private readonly List<Report> reports = new List<Report>();
        //private readonly bool deleteReports = ConfigurationManager.AppSettings["deleteReports"];
        private readonly bool deleteReports = true;
    }

    internal class TableInfo
    {
        public bool Reinforcements { get; set; }
        public int Id { get; set; }
        public int VillageId { get; set; }
        public string Name { get; set; }
        public string VillageName { get; set; }
        public Tribes OwnTribe { get; set; }
        public Tribes Tribe { get; set; }
        public int[] Troops { get; set; }
        public int[] Casualties { get; set; }
        public int[] Goods { get; set; }
        public int[] Prisoners { get; set; }
    }
}