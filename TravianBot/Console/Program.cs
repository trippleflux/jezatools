using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Library;
using log4net;

namespace Console
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        private static CookieCollection cookieCollection;

        private static void Main()
        {
            Log.Debug("Console started...");
            try
            {
            	ServerData sd = new ServerData();
				Parser p = new Parser();
                
				Login(sd, p);
				if (LogedIn(sd, p))
				{
                    sd = new ServerData();
					p = new Parser();
					UpdateData(sd, p);
                    SQL.InsertPlayer(sd);

					int loopCount = 0;
					do
					{
					    #region Login check

					    if (!LogedIn(sd, p))
					    {
					        Login(sd, p);
					    }

					    #endregion

					    #region Check Tasks every minute

					    if (loopCount%1 == 0)
					    {

					    }

					    #endregion
                        
                        #region Update every 10 minutes
                        if (loopCount%10 == 0)
						{
							sd = new ServerData();
							p = new Parser();
							UpdateData(sd, p);
						}
                        #endregion

                        #region Sleep for 1 minute
                        loopCount++;
						if (loopCount > 90)
						{
							loopCount = 0;
						}
						Thread.Sleep(60000);
                        #endregion

                    } while (loopCount < 100);
				}
            	else
				{
					System.Console.WriteLine("Failed to login!!!");
				}
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(ex.Message);
                Log.ErrorFormat(ex.StackTrace);
				System.Console.WriteLine(ex.ToString());
            }
        }



    	private static bool LogedIn(ServerData sd, Parser p)
    	{
			String pageContent = GetPageSource(sd.Servername + "dorf1.php");
			p.PlayerUid(sd, pageContent);
			if (sd.PlayerUID > -1)
			{
				return true;
			}
    		return false;
    	}



    	private static void Login(ServerData sd,
    	                          Parser p)
    	{
            System.Console.WriteLine("Login");
            Browser b = new Browser();
    		String pageSource;
    		cookieCollection = b.GetPageSource(sd.Servername + "login.php", out pageSource);
    		p.LoginData(sd, pageSource);
    		Log.DebugFormat("ServerData={0}", sd.ToString());

    		cookieCollection = b.Login(sd.Servername + "dorf1.php", sd, out pageSource);
    		Log.DebugFormat("pageSource:\r\n{0}\r\n", pageSource);
    		Log.Info("Cookies:");
    		for (int i = 0; i < cookieCollection.Count; i++)
    		{
    			Log.InfoFormat("{1}='{0}' Expires on '{2}'", cookieCollection[i], i,
    			               cookieCollection[i].Expires.ToLocalTime());
    		}
    	}



    	private static void UpdateData(ServerData sd,
    	                               Parser p)
    	{
            System.Console.WriteLine("Update...");
            String pageContent = GetPageSource(sd.Servername + "dorf1.php");
    		p.PlayerUid(sd, pageContent);
    	    //SQL.InsertPlayer(sd);
    		p.VillageIDs(sd, pageContent);
    		Log.InfoFormat("PlayerUid={0}", sd.PlayerUID);
    		for (int vill = 0; vill < sd.VillagesList.Count; vill++)
    		{
    			Village v = sd.VillagesList[vill] as Village;
    		    SQL.InsertVillages(sd, v);
    			if (v != null)
    			{
    				pageContent = GetPageSource(String.Format("{0}dorf1.php?newdid={1}", sd.Servername, v.VillageId));
    				Log.DebugFormat("pageSource:\r\n{0}\r\n", pageContent);
    				//Village production
    				p.Production(sd, pageContent);
    			    SQL.InsertProduction(sd, v, vill);
    				//Village resources
    				p.Resources(sd, v, pageContent);
    				//Village buildings
    				pageContent = GetPageSource(sd.Servername + "dorf2.php?newdid=" + v.VillageId);
    				Log.DebugFormat("pageSource:\r\n{0}\r\n", pageContent);
                    p.Buildings(sd, v, pageContent);
    			}
    		}
            SQL.InsertResources(sd);
            LogBuildings(sd);
        }

        private static void LogBuildings(ServerData sd)
        {
            for (int i = 0; i < sd.BuildingsList.Count; i++)
            {
                VillageData villageBuildings = sd.BuildingsList[i] as VillageData;
                if (villageBuildings != null)
                {
                    Building villBuildings = villageBuildings.BuildingsForVillage[0] as Building;
                    if (villBuildings != null)
                    {
                        Log.DebugFormat("Buildings: {0}", villBuildings.ToString());
                    }
                }
            }
        }


        private static string GetPageSource(string pageUrl)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(pageUrl);
            httpWebRequest.Method = "GET";
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.CookieContainer.Add(new Uri(pageUrl), cookieCollection);
            HttpWebResponse webResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            StreamReader loginReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
            return loginReader.ReadToEnd();
        }
    }
}