using System;
using System.Globalization;
using System.Text;
using System.Threading;
using TravianBot.Framework;

namespace TravianBot.TroopSender
{
    public class Send
    {
        public Send(ServerInfo serverInfo, TroopSenderParamaters parameters)
        {
            this.serverInfo = serverInfo;
            this.parameters = parameters;
            thread = new Thread(SendTroops);
            thread.Name = parameters.Id;
            thread.Start();
        }

        private void SendTroops(object obj)
        {
            //kata=15&kata2=11&id=39&a=15822&c=3&kid=395278&t1=0&t2=0&t3=0&t4=0&t5=0&t6=22&t7=0&t8=158&t9=0&t10=0&t11=0&s1.x=33&s1.y=5&s1=ok
            StringBuilder troops = new StringBuilder();
            string[] units = parameters.TroopList.Split(' ');
            for (int t = 0; t < 11; t++)
            {
                troops.AppendFormat("&t{0}={1}", (t + 1), units[t]);
            }
            Random rnd = new Random();
            String postData = String.Format(CultureInfo.InvariantCulture,
                                            "{5}id=39&a={0}&c={1}&kid={2}{3}{4}",
                                            rnd.Next(10001, 99999),
                                            parameters.AttackType,
                                            Misc.ConvertXY(parameters.DestX, parameters.DestY),
                                            troops,
                                            String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19)),
                                            parameters.UseKatas == 1 ? String.Format("kata={0}&kata2={1}&", parameters.KataDest1, parameters.KataDest2) : "");

            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", serverInfo.SendUnitsUrl, parameters.VillageId);
            Http.SendData(url, postData, serverInfo.CookieContainer, serverInfo.CookieCollection);
            Thread.Sleep(1000);
        }

        public Thread thread;
        private readonly ServerInfo serverInfo;
        private readonly TroopSenderParamaters parameters;
    }
}