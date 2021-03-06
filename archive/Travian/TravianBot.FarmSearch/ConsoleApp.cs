#region

using System;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using TravianBot.Framework;

#endregion

namespace TravianBot.FarmSearch
{
    public class ConsoleApp
    {
        public ConsoleApp(string[] args)
        {
            this.args = args;
        }

        public void Parse()
        {
            //foreach (string arg in args)
            //{
            //    Console.WriteLine(arg);
            //}

            if (args.Length < 3)
            {
                ShowHelp();
                Console.WriteLine();
                Console.WriteLine("Using default values...");
                return;
            }

            distance = !Misc.IsNumber(args[0]) ? 10 : Int32.Parse(args[0]);
            xCenter = !Misc.IsNumber(args[1]) ? -100 : Int32.Parse(args[1]);
            yCenter = !Misc.IsNumber(args[2]) ? -100 : Int32.Parse(args[2]);
        }

        public void Process()
        {
            Console.WriteLine("Get all villages within {0} clicks around ({1}|{2})", distance, xCenter, yCenter);

            string sql =
                string.Format(
                    @"
SELECT [x], [y], [tid], [village], [player], [aliance], [population], [uid], [id], [aid], ( SQRT(({5}-[x])*({5}-[x]) + ({6}-[y])*({6}-[y])) ) AS Distance FROM [TravianMap].[dbo].[{4}] 
WHERE (([x] > {0}) AND ([x] < {1}) AND ([y] > {2}) AND ([y] < {3}))
ORDER BY Distance ASC",
                    xCenter - distance, xCenter + distance, yCenter - distance, yCenter + distance, "si_s6", xCenter,
                    yCenter);
            SqlConnection conn = new SqlConnection(connString);

            DateTime now = DateTime.Now;
            string fileName = String.Format(CultureInfo.InvariantCulture, "{0}_FarmList.xml",
                                            now.ToString("yyyyMMdd_HHmmss"));
            StringBuilder farmList = new StringBuilder();
            farmList.AppendLine(@"<?xml-stylesheet type=""text/xsl"" href=""FarmListTransform.xslt""?>");
            farmList.AppendLine("<actions>");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int id = 0;
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Int32 xCor = Int32.Parse(reader[0].ToString().Trim());
                        Int32 yCor = Int32.Parse(reader[1].ToString().Trim());
                        String villageName = reader[3].ToString().Trim();
                        String playerName = reader[4].ToString().Trim();
                        String alianceName = reader[5].ToString().Trim();
                        Int32 population = Int32.Parse(reader[6].ToString().Trim());
                        Int32 uid = Int32.Parse(reader[7].ToString().Trim());
                        String aid = reader[9].ToString().Trim();
                        Double sqlDistance = Math.Round(Double.Parse(reader[10].ToString().Trim()));
                        if (!ExcludeAliance(aid))
                        {
                            Console.WriteLine("{0}[{1}]", reader[4], reader[3]);
                            string line = String.Format(CultureInfo.InvariantCulture,
                                                        @"	<attackAction id=""{0}"" enabled=""0"" playername=""{1}"" playerlink=""http://s1.travian.si/spieler.php?uid={8}"" villagename=""{2}"" villagelink=""http://s1.travian.si/a2b.php?z={9}"" population=""{3}"" aliance=""{4}"" aliancelink=""http://s1.travian.si/allianz.php?aid={10}"" comment=""[distance={5}][uid={8}]"" coordinateX=""{6}"" coordinateY=""{7}"" unitId=""5"" sendTroopType=""4"" unitCount=""50"" unitName=""Paladinov"" villageId=""90602""/>"
                                                        , id, playerName, villageName, population, alianceName,
                                                        sqlDistance, xCor, yCor, uid, Misc.ConvertXY(xCor, yCor), aid);
                            farmList.AppendLine(line.Replace('&', ' '));
                            id++;
                        }
                    }
                    reader.Close();
                }
                farmList.AppendLine("</actions>");
                WriteLine(fileName, farmList.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                conn.Close();
            }
        }

        private static bool ExcludeAliance(string aid)
        {
            string excludedList = Misc.GetConfigValue("alinceIdExcludedList");
            if (aid=="0")
            {
                return false;
            }
            return excludedList.IndexOf(aid) > -1;
        }

        private static void ShowHelp()
        {
            Console.WriteLine("TravianBot.FarmSearch.exe [distance] [XCoordinate] [YCoordinate]");
            Console.WriteLine("Example:");
            Console.WriteLine("TravianBot.FarmSearch.exe 10 -1 -5");
        }

        private static void WriteLine
            (string fileName,
             string line)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                sw.WriteLine(line);
                sw.Close();
                sw.Dispose();
            }
        }

        private readonly string[] args;
        private int distance;
        private int xCenter;
        private int yCenter;
        private const string connString = "Data Source=.;Initial Catalog=TravianMap;Integrated Security=True";
    }
}