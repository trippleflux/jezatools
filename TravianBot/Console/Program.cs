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

						#region Attacks

						if (loopCount%1 == 0)
						{
							//Muta06	(-194 	| 	-225) -->  Muta05	(-193 	| 	-224)
							//b=1&t1=&t4=374&t7=&t9=&t2=&t5=&t8=&t10=&t3=&t6=&c=3&dname=&x=-193&y=-224&s1.x=31&s1.y=12&s1=ok
							//id=39&a=30375&c=3&kid=500032&t1=0&t2=0&t3=0&t4=374&t5=0&t6=0&t7=0&t8=0&t9=0&t10=0&t11=0&s1.x=35&s1.y=14&s1=ok
							//http://s3.travian.si/a2b.php?newdid=123788
							System.Console.WriteLine("Checking farms...");
							Attack attack = new Attack();
							attack.CheckFarmList(sd);
						}

						#endregion

						#region Check Tasks every minute

						if (loopCount%1 == 0)
					    {
                            System.Console.WriteLine("Checking tasks...");
                            Task task = new Task();
                            task.CheckTasks(sd);
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
    	    SQL.InsertPlayer(sd);
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
    				p.Production(sd, v, pageContent);
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
			tbLibrary.LogResources(sd);
			tbLibrary.LogBuildings(sd);
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