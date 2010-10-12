#region

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Threading;
using HtmlAgilityPack;

#endregion

namespace jeza.Travian.Framework
{
    public class MarketPlaceCalculator
    {
        public MarketPlaceCalculator()
        {
            parseSucceeded = true;
        }

        public MarketPlaceCalculator(Account account, HtmlDocument htmlDocument, HtmlWeb htmlWeb, MarketPlaceQueue queue,
                                     Settings settings, Languages languages)
        {
            this.account = account;
            this.htmlDocument = htmlDocument;
            this.htmlWeb = htmlWeb;
            this.queue = queue;
            this.settings = settings;
            language = languages.GetLanguage(settings.LanguageId);
        }

        public MarketPlaceQueue Queue
        {
            get { return queue; }
            set { queue = value; }
        }

        public Village Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public Village Source
        {
            get { return source; }
            set { source = value; }
        }

        public MarketPlace MarketPlaceDestination
        {
            get { return marketPlaceDestination; }
            set { marketPlaceDestination = value; }
        }

        public MarketPlace MarketPlaceSource
        {
            get { return marketPlaceSource; }
            set { marketPlaceSource = value; }
        }

        public string PostParameters
        {
            get { return postParameters; }
        }

        public Dictionary<string, string> HiddenValues
        {
            get { return hiddenValues; }
        }

        public void Parse()
        {
            parseSucceeded = false;
            if (language == null) return;
            destination = account.GetVillage(queue.DestinationVillage.Id);
            if (destination == null) return;
            source = account.GetVillage(queue.SourceVillage.Id);
            if (source == null) return;
            string url = String.Format(CultureInfo.InvariantCulture,
                                       "{0}build.php?newdid={1}&gid=17",
                                       settings.LoginData.Servername, destination.Id);
            htmlDocument = htmlWeb.Load(url);
            if (htmlDocument == null) return;
            HtmlParser htmlParser = new HtmlParser(htmlDocument, language);
            marketPlaceDestination = htmlParser.MarketPlace();
            if (marketPlaceDestination == null) return;
            url = String.Format(CultureInfo.InvariantCulture,
                                "{0}build.php?newdid={1}&gid=17",
                                settings.LoginData.Servername, source.Id);
            htmlDocument = htmlWeb.Load(url);
            if (htmlDocument == null) return;
            htmlParser = new HtmlParser(htmlDocument, language);
            marketPlaceSource = htmlParser.MarketPlace();
            if (marketPlaceSource == null) return;
            parseSucceeded = true;
        }


        public void ParseUnknownDestination()
        {
            parseSucceeded = false;
            if (language == null) return;
            source = account.GetVillage(queue.SourceVillage.Id);
            if (source == null) return;
            string url = String.Format(CultureInfo.InvariantCulture,
                                       "{0}build.php?newdid={1}&gid=17",
                                       settings.LoginData.Servername, source.Id);
            htmlDocument = htmlWeb.Load(url);
            if (htmlDocument == null) return;
            HtmlParser htmlParser = new HtmlParser(htmlDocument, language);
            marketPlaceSource = htmlParser.MarketPlace();
            if (marketPlaceSource == null) return;
            destination = queue.DestinationVillage;
            parseSucceeded = true;
        }

        public void Calculate()
        {
            if (!parseSucceeded)
            {
                postParameters = null;
                return;
            }
            if (marketPlaceSource.AvailableMerchants < 1)
            {
                postParameters = null;
                return;
            }
            bool send = false;
            int totalGoodsCarry = marketPlaceSource.AvailableMerchants*marketPlaceSource.TotalCarry;
            StringBuilder sb = new StringBuilder();
            if (queue.SendWood)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(1));
                }
                else
                {
                    int wanted = destination.Production.Warehouse*queue.Goods/100;
                    int incomming = destination.Production.WoodTotal + marketPlaceDestination.TotalIncommingWood;
                    int toSend = (wanted - incomming);
                    if (toSend > 0)
                    {
                        int available = source.Production.WoodTotal;
                        totalGoodsCarry = GetTotalGoodsCarry(totalGoodsCarry, sb, toSend, available, 1);
                        send = true;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(1));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(1));
            }
            if (queue.SendClay)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(2));
                }
                else
                {
                    int wanted = destination.Production.Warehouse*queue.Goods/100;
                    int incomming = destination.Production.ClayTotal + marketPlaceDestination.TotalIncommingClay;
                    int toSend = (wanted - incomming);
                    if (toSend > 0)
                    {
                        int available = source.Production.ClayTotal;
                        totalGoodsCarry = GetTotalGoodsCarry(totalGoodsCarry, sb, toSend, available, 2);
                        send = true;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(2));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(2));
            }
            if (queue.SendIron)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(3));
                }
                else
                {
                    int wanted = destination.Production.Warehouse*queue.Goods/100;
                    int incomming = destination.Production.IronTotal + marketPlaceDestination.TotalIncommingIron;
                    int toSend = (wanted - incomming);
                    if (toSend > 0)
                    {
                        int available = source.Production.IronTotal;
                        totalGoodsCarry = GetTotalGoodsCarry(totalGoodsCarry, sb, toSend, available, 3);
                        send = true;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(3));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(3));
            }
            if (queue.SendCrop)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(4));
                }
                else
                {
                    int wanted = destination.Production.Granary*queue.Goods/100;
                    int incomming = destination.Production.CropTotal + marketPlaceDestination.TotalIncommingCrop;
                    int toSend = (wanted - incomming);
                    if (toSend > 0)
                    {
                        int available = source.Production.CropTotal;
                        GetTotalGoodsCarry(totalGoodsCarry, sb, toSend, available, 4);
                        send = true;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(4));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(4));
            }
            postParameters = send ? sb.ToString() : null;
        }

        public void CalculateSourceOver()
        {
            if (!parseSucceeded)
            {
                postParameters = null;
                return;
            }
            if (marketPlaceSource.AvailableMerchants < 1)
            {
                postParameters = null;
                return;
            }
            int totalGoodsCarry = marketPlaceSource.AvailableMerchants * marketPlaceSource.TotalCarry;
            if (totalGoodsCarry < 1)
            {
                postParameters = null;
                return;
            }
            bool send = false;
            StringBuilder sb = new StringBuilder();
            if (queue.SendWood)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(1));
                }
                else
                {
                    int goodsToKeep = source.Production.Warehouse * queue.Goods / 100;
                    if (goodsToKeep < source.Production.WoodTotal)
                    {
                        sb.Append(SetAmount(1, queue.GoodsToSend));
                        parameterValues[0] = queue.GoodsToSend;
                        send = true;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(1));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(1));
            }
            if (queue.SendClay)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(2));
                }
                else
                {
                    int goodsToKeep = source.Production.Warehouse * queue.Goods / 100;
                    if (goodsToKeep < source.Production.ClayTotal)
                    {
                        sb.Append(SetAmount(2, queue.GoodsToSend));
                        parameterValues[1] = queue.GoodsToSend;
                        send = true;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(2));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(2));
            }
            if (queue.SendIron)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(3));
                }
                else
                {
                    int goodsToKeep = source.Production.Warehouse * queue.Goods / 100;
                    if (goodsToKeep < source.Production.IronTotal)
                    {
                        sb.Append(SetAmount(3, queue.GoodsToSend));
                        parameterValues[2] = queue.GoodsToSend;
                        send = true;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(3));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(3));
            }
            if (queue.SendCrop)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(4));
                }
                else
                {
                    int goodsToKeep = source.Production.Granary * queue.Goods / 100;
                    if (goodsToKeep < source.Production.CropTotal)
                    {
                        sb.Append(SetAmount(4, queue.GoodsToSend));
                        parameterValues[3] = queue.GoodsToSend;
                        send = true;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(4));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(4));
            }
            postParameters = send ? sb.ToString() : null;
        }

        public void CalculateUnknownDestination()
        {
            if (!parseSucceeded)
            {
                postParameters = null;
                return;
            }
            if (marketPlaceSource.AvailableMerchants < 1)
            {
                postParameters = null;
                return;
            }
            int totalGoodsCarry = marketPlaceSource.AvailableMerchants * marketPlaceSource.TotalCarry;
            if (totalGoodsCarry < 1)
            {
                postParameters = null;
                return;
            }
            bool send = false;
            StringBuilder sb = new StringBuilder();
            if (queue.SendWood)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(1));
                }
                else
                {
                    if(source.Production.WoodTotal > queue.Goods)
                    {
                        send = true;
                        sb.Append(SetAmount(1, queue.Goods));
                        parameterValues[0] = queue.Goods;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(1));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(1));
            }
            if (queue.SendClay)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(2));
                }
                else
                {
                    if (source.Production.ClayTotal > queue.Goods)
                    {
                        send = true;
                        sb.Append(SetAmount(2, queue.Goods));
                        parameterValues[1] = queue.Goods;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(2));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(2));
            }
            if (queue.SendIron)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(3));
                }
                else
                {
                    if (source.Production.IronTotal > queue.Goods)
                    {
                        send = true;
                        sb.Append(SetAmount(3, queue.Goods));
                        parameterValues[2] = queue.Goods;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(3));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(3));
            }
            if (queue.SendCrop)
            {
                if (totalGoodsCarry < 1)
                {
                    sb.Append(ZeroAmount(4));
                }
                else
                {
                    if (source.Production.CropTotal > queue.Goods)
                    {
                        send = true;
                        sb.Append(SetAmount(4, queue.Goods));
                        parameterValues[3] = queue.Goods;
                    }
                    else
                    {
                        sb.Append(ZeroAmount(4));
                    }
                }
            }
            else
            {
                sb.Append(ZeroAmount(4));
            }
            postParameters = send ? sb.ToString() : null;
        }

        public string Process()
        {
            if (postParameters == null)
            {
                return "";
            }
            string url = String.Format(CultureInfo.InvariantCulture,
                                       "{0}build.php?newdid={1}&gid=17",
                                       settings.LoginData.Servername, source.Id);
            htmlDocument = htmlWeb.Load(url);
            //<input type="hidden" name="id" value="33">
            HtmlNode node = htmlDocument.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='id']");
            if (node != null)
            {
                //wait 2-5 seconds before processing with the next action
                Thread.Sleep(new Random().Next(2000, 5000));
                string id = node.Attributes["value"].Value;
                //id=33&r1=750&r2=750&r3=750&r4=750&dname= &x=-82&y=62&s1.x=29&s1.y=8&s1=ok
                //id=33&r1=750&r2750=&r3=750&r4=750&dname=.&x=   &y=  &s1.x=25&s1.y=14
                NameValueCollection postData = new NameValueCollection(1)
                    {
                        {"id", id},
                        {"r1", parameterValues[0].ToString()},
                        {"r2", parameterValues[1].ToString()},
                        {"r3", parameterValues[2].ToString()},
                        {"r4", parameterValues[3].ToString()},
                        {"dname", ""},
                        {"x", destination.CoordinateX.ToString()},
                        {"y", destination.CoordinateY.ToString()},
                        {"s1.x", RandomNumber(0,35)},
                        {"s1.y", RandomNumber(0,10)},
                        {"s1", "ok"}
                    };
                htmlDocument = htmlWeb.SubmitFormValues(postData, url);
                //wait 2-5 seconds before processing with the next action
                Thread.Sleep(new Random().Next(2000, 5000));
                if (htmlDocument != null)
                {
                    /*
                <input type="hidden" name="id" value="33">
                <input type="hidden" name="a" value="89449">
                <input type="hidden" name="sz" value="5287">
                <input type="hidden" name="kid" value="269455">
                 */
                    //HtmlNode nodeId = htmlDocument.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='id']");
                    //id = nodeId.Attributes["value"].Value;
                    //HtmlNode nodeSz = htmlDocument.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='sz']");
                    //string sz = nodeSz.Attributes["value"].Value;
                    //HtmlNode nodeA = htmlDocument.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='a']");
                    //string a = nodeA.Attributes["value"].Value;
                    //HtmlNode nodeKid = htmlDocument.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='kid']");
                    //string kid = nodeKid.Attributes["value"].Value;
                    //HtmlNode nodeC = htmlDocument.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='c']");
                    //string c = nodeC.Attributes["value"].Value;
                    GetHiddenValues(htmlDocument);
                    //id=33&a=75579&sz=5259&kid=271057         &r1=750&r2=750&r3=750&r4=750&s1.x=35&s1.y=4&s1=ok
                    //id=33&a=75579&sz=7394&kid=271057&c=a5260a&r1=750&r2=750&r3=750&r4=750&s1.x=30&s1.y=8
                    postData = new NameValueCollection(1);
                    //postData.Add("id", id);
                    //postData.Add("a", a);
                    //postData.Add("sz", sz);
                    //postData.Add("kid", kid);
                    //postData.Add("c", c);
                    foreach (KeyValuePair<string, string> keyValuePair in hiddenValues)
                    {
                        postData.Add(keyValuePair.Key, keyValuePair.Value);
                    }
                    postData.Add("r1", parameterValues[0].ToString());
                    postData.Add("r2", parameterValues[1].ToString());
                    postData.Add("r3", parameterValues[2].ToString());
                    postData.Add("r4", parameterValues[3].ToString());
                    postData.Add("s1.x", RandomNumber(0, 35));
                    postData.Add("s1.y", RandomNumber(0, 10));
                    postData.Add("s1", "ok");
                    htmlDocument = htmlWeb.SubmitFormValues(postData, url);
                    if (htmlDocument != null)
                    {
                        return String.Format(CultureInfo.InvariantCulture, "Sending [{2}, {3}, {4}, {5}] from {0} to {1}",
                                             source.Name, destination.Name, parameterValues[0], parameterValues[1],
                                             parameterValues[2], parameterValues[3]);
                    }
                }
            }
            return "";
        }

        public void GetHiddenValues(HtmlDocument htmlDoc)
        {
            HtmlNodeCollection htmlNodeCollection = htmlDoc.DocumentNode.SelectNodes("//input[@type='hidden']");
            if (htmlNodeCollection!=null)
            {
                foreach (HtmlNode htmlNode in htmlNodeCollection)
                {
                    if (htmlNode!=null)
                    {
                        hiddenValues.Add(htmlNode.Attributes["name"].Value, htmlNode.Attributes["value"].Value);
                    }
                }
                
            }
        }

        public bool TimeToSend(DateTime dateTime)
        {
            return (dateTime.AddMinutes(queue.RepeatMinutes) - queue.LastSend).TotalMinutes > queue.RepeatMinutes;
        }

        public bool TimeToSendRepeat(DateTime dateTime)
        {
            return TimeToSend(dateTime);
        }

        private int GetTotalGoodsCarry(int totalGoodsCarry, StringBuilder sb, int toSend, int available, int i)
        {
            if (toSend < available)
            {
                int sending = toSend > totalGoodsCarry ? totalGoodsCarry : toSend;
                sb.AppendFormat("&r{1}={0}", sending, i);
                parameterValues[i - 1] = sending;
                totalGoodsCarry -= sending;
            }
            else
            {
                int sending = available > totalGoodsCarry ? totalGoodsCarry : available;
                sb.AppendFormat("&r{1}={0}", sending, i);
                parameterValues[i - 1] = sending;
                totalGoodsCarry -= sending;
            }
            return totalGoodsCarry;
        }

        private string RandomNumber(int min, int max)
        {
            return random.Next(min, max).ToString(CultureInfo.InvariantCulture);
        }

        private static string SetAmount(int i, int amount)
        {
            return String.Format(CultureInfo.InvariantCulture, "&r{0}={1}", i, amount);
        }
        
        private static string ZeroAmount(int i)
        {
            return String.Format(CultureInfo.InvariantCulture, "&r{0}=0", i);
        }

        private readonly Account account;
        private HtmlDocument htmlDocument;
        private readonly HtmlWeb htmlWeb;
        private MarketPlaceQueue queue;
        private readonly Settings settings;
        private Village destination;
        private Village source;
        private MarketPlace marketPlaceDestination;
        private MarketPlace marketPlaceSource;
        private string postParameters;
        private readonly int[] parameterValues = new[] {0, 0, 0, 0};
        private readonly Dictionary<string, string> hiddenValues = new Dictionary<string, string>();
        private bool parseSucceeded;
        private readonly Language language;
        readonly Random random = new Random(999999999);
    }
}