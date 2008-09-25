using System;
using System.IO;
using System.Net;
using System.Text;
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
                sd.Servername = "http://s4.travian.si/";
                sd.Username = "jezonsky";
                sd.Password = "kepek";

//USE [TravianBot]
//GO
///****** Object:  StoredProcedure [dbo].[InsertVillage]    Script Date: 09/25/2008 14:59:27 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//ALTER PROCEDURE [dbo].[InsertVillage] 
//    (@VillageId int
//    ,@VillageName nvarchar(50)
//    ,@PlayerId int)
//AS
//BEGIN
//    SET NOCOUNT ON;
//    DECLARE @VillId int;
//    SET @VillId = (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE @VillageId = [dbo].[Villages].[VillageId]);
//    DECLARE @PlayerVillageId int;
//    SET @PlayerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE @PlayerId = [dbo].[Villages].[PlayerId]);
//IF @VillId > 0 AND @PlayerVillageId > 0
//INSERT INTO [TravianBot].[dbo].[Villages]
//           ([VillageId]
//           ,[VillageName]
//           ,[PlayerId])
//     VALUES
//           (@VillageId
//           ,@VillageName
//           ,@PlayerVillageId)
//ELSE
//UPDATE [jcTBot].[dbo].[Villages]
//   SET [VillageName] = @VillageName
// WHERE [VillageId] = @VillageId AND [PlayerId] = @PlayerVillageId
//END

                String pageSource;
                Browser b = new Browser();
                cookieCollection = b.GetPageSource(sd.Servername + "login.php", out pageSource);

                Parser p = new Parser();
                p.LoginData(sd, pageSource);

                Log.DebugFormat("ServerData={0}", sd.ToString());
                //Log.DebugFormat("{0}", b.PageSource);
                Log.Debug("Cookies:");
                for (int i = 0; i < cookieCollection.Count; i++)
                {
                    Log.DebugFormat("{1}='{0}'", cookieCollection[i], i);
                }

                //http://s3.travian.si/dorf1.php
                //http://s3.travian.si/dorf2.php
                //http://s3.travian.si/karte.php
                //http://s3.travian.si/statistiken.php
                //http://s3.travian.si/berichte.php
                //http://s3.travian.si/nachrichten.php
                cookieCollection = b.Login(sd.Servername + "dorf1.php", sd, out pageSource);
                Log.DebugFormat("pageSource:\r\n{0}\r\n", pageSource);
                Log.Info("Cookies:");
                for (int i = 0; i < cookieCollection.Count; i++)
                {
                    Log.InfoFormat("{1}='{0}' Expires on '{2}'", cookieCollection[i], i,
                                   cookieCollection[i].Expires.ToLocalTime());
                }

                p.PlayerUid(sd, pageSource);
                p.VillageIDs(sd, pageSource);
                Log.InfoFormat("PlayerUid={0}", sd.PlayerUID);
                foreach (Village v in sd.VillagesList)
                {
                    Log.InfoFormat("Village=[{0}]:[{1}]", v.VillageName, v.VillageId);
                    String pageContent = GetPageSource(sd.Servername + "dorf1.php?newdid=" + v.VillageId);
                    Log.DebugFormat("pageSource:\r\n{0}\r\n", pageContent);
                    //Village production
                    p.Production(sd, pageContent);
                    Log.InfoFormat("Production for Village [{0}]: {1}", v.VillageName, sd.ProductionList[0]);
                    //Village resources
                    p.Resources(sd, pageContent);
                    for (int i = 0; i < sd.ResourcesList.Count; i++)
                    {
                        VillageData villageResource = sd.ResourcesList[i] as VillageData;
                        if (villageResource != null)
                        {
                            Resource villResource = villageResource.ResourcesForVillage[0] as Resource;
                            if (villResource != null)
                                Log.InfoFormat("Village [{0}] Resources: {1}", v.VillageName, villResource.ToString());
                        }
                    }
                    //Village buildings
                    pageContent = GetPageSource(sd.Servername + "dorf2.php?newdid=" + v.VillageId);
                    Log.DebugFormat("pageSource:\r\n{0}\r\n", pageContent);
                    p.Buildings(sd, pageContent);
                    for (int i = 0; i < sd.BuildingsList.Count; i++)
                    {
                        VillageData villageBuildings = sd.BuildingsList[i] as VillageData;
                        if (villageBuildings != null)
                        {
                            Resource villBuildings = villageBuildings.ResourcesForVillage[0] as Resource;
                            if (villBuildings != null)
                                Log.InfoFormat("Village [{0}] Buildings: {1}", v.VillageName, villBuildings.ToString());
                        }
                    }
                }

                //int loopCount = 0;
                //do
                //{
                //    loopCount++;
                //    if (loopCount > 90)
                //    {
                //        loopCount = 0;
                //    }
                //} while (loopCount < 100);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(ex.Message);
                Log.ErrorFormat(ex.StackTrace);
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