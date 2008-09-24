using System;
using System.Text.RegularExpressions;

namespace Library
{
    public class Parser
    {
        /// <summary>
        /// Parses values from login page.
        /// </summary>
        /// <param name="sd"><see cref="ServerData"/></param>
        /// <param name="pageSource">page source</param>
        /// 
        public void LoginData(ServerData sd, string pageSource)
        {
            Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\">");
            if (regHiddenLoginValue.IsMatch(pageSource))
            {
                Match Mc = regHiddenLoginValue.Matches(pageSource)[0];
                sd.HiddenLoginValue = Mc.Groups[1].Value;
            }

            Regex regLoginName = new Regex("<input class=\"fm fm110\" type=\"text\" name=\"(.*)\" value=");
            if (regLoginName.IsMatch(pageSource))
            {
                Match Mc = regLoginName.Matches(pageSource)[0];
                sd.TextboxLoginName = Mc.Groups[1].Value;
            }

            Regex regPasswordName = new Regex("<input class=\"fm fm110\" type=\"password\" name=\"(.*)\" value=");
            if (regPasswordName.IsMatch(pageSource))
            {
                Match Mc = regPasswordName.Matches(pageSource)[0];
                sd.TextboxPasswordName = Mc.Groups[1].Value;
            }

            Regex regHiddenName = new Regex("<p align=\"center\"><input type=\"hidden\" name=\"(.*)\" value=\"(.*)\">");
            if (regHiddenName.IsMatch(pageSource))
            {
                Match Mc = regHiddenName.Matches(pageSource)[0];
                sd.HiddenName = Mc.Groups[1].Value;
                sd.HiddenValue = Mc.Groups[2].Value;
            }
        }

        /// <summary>
        /// Gets production of the village.
        /// </summary>
        /// <param name="sd"><see cref="ServerData"/></param>
        /// <param name="p"><see cref="Production"/></param>
        /// <param name="pageSource">Page source</param>
        /// 
        public void Production(ServerData sd, Production p, String pageSource)
        {
            /*
<table align="center" cellspacing="0" cellpadding="0"><tr valign="top">
<td><img class="res" src="img/un/r/1.gif" title="Les"></td>
<td id=l4 title=132>3766/7800</td>

<td class="s7"> <img class="res" src="img/un/r/2.gif" title="Glina"></td>
<td id=l3 title=127>3541/7800</td>
<td class="s7"> <img class="res" src="img/un/r/3.gif" title="Železo"></td>
<td id=l2 title=121>4032/7800</td><td class="s7"> <img class="res" src="img/un/r/4.gif" title="Žito"></td>
<td id=l1 title=93>2095/2300</td>
<td class="s7"> &nbsp;<img class="res" src="img/un/r/5.gif" title="Poraba žita">&nbsp;122/215</td></tr></table>
 */
                
            //wood
            Regex wood = new Regex(@"id=l4 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
            if (wood.IsMatch(pageSource))
            {
                Match Mc = wood.Matches(pageSource)[0];
                p.Wood = Int32.Parse(Mc.Groups[2].Value.Trim());
                p.WoodPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
            //string reg = ;
            //MatchCollection resourcesKapacity = Regex.Matches(pageSource, reg);
            //p.Wood = Int32.Parse(resourcesKapacity[0].Groups[2].Value.Trim());
            //p.WoodPerHour = Int32.Parse(resourcesKapacity[0].Groups[1].Value.Trim());
            //clay
            //reg = @"id=l3 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<";
            //resourcesKapacity = Regex.Matches(pageSource, reg);
            //p.Clay = Int32.Parse(resourcesKapacity[0].Groups[2].Value.Trim());
            //p.ClayPerHour = Int32.Parse(resourcesKapacity[0].Groups[1].Value.Trim());
            ////iron
            //reg = @"id=l2 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<";
            //resourcesKapacity = Regex.Matches(pageSource, reg);
            //p.Iron = Int32.Parse(resourcesKapacity[0].Groups[2].Value.Trim());
            //p.IronPerHour = Int32.Parse(resourcesKapacity[0].Groups[1].Value.Trim());
            //p.WarehouseKapacity = Int32.Parse(resourcesKapacity[0].Groups[3].Value.Trim());
            ////crop
            //reg = @"id=l1 title=(.*)>([0-9]{1,7}).([0-9]{1,7})<";
            //resourcesKapacity = Regex.Matches(pageSource, reg);
            //p.Crop = Int32.Parse(resourcesKapacity[0].Groups[2].Value.Trim());
            //p.CropPerHour = Int32.Parse(resourcesKapacity[0].Groups[1].Value.Trim());
            //p.GranaryKapacity = Int32.Parse(resourcesKapacity[0].Groups[3].Value.Trim());

            sd.ProductionList.Add(p);
        }
    }
}