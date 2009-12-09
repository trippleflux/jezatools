#region

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using log4net;

#endregion

namespace TW.Helper
{
    public class DataBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (DataBase));

        /// <summary>
        /// Saves the <see cref="MapCoordinates"/> to db.
        /// </summary>
        /// <param name="mapCoordinate">The map coordinate.</param>
        public void SaveVillageToDb(MapCoordinates mapCoordinate)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "UpdateMap";
                    sqlCommand.Parameters.Add(new SqlParameter("@VillageId", SqlDbType.Int)).Value =
                        mapCoordinate.VillageId;
                    sqlCommand.Parameters.Add(new SqlParameter("@VillageName", SqlDbType.NVarChar)).Value =
                        mapCoordinate.VillageName;
                    sqlCommand.Parameters.Add(new SqlParameter("@VillageLink", SqlDbType.NVarChar)).Value =
                        mapCoordinate.VillageLink;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int)).Value = mapCoordinate.PlayerId;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar)).Value =
                        mapCoordinate.PlayerName;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserLink", SqlDbType.NVarChar)).Value =
                        mapCoordinate.PlayerNameLink;
                    sqlCommand.Parameters.Add(new SqlParameter("@AllianceId", SqlDbType.Int)).Value =
                        mapCoordinate.AllianceId;
                    sqlCommand.Parameters.Add(new SqlParameter("@AllianceName", SqlDbType.NVarChar)).Value =
                        mapCoordinate.AllianceName;
                    sqlCommand.Parameters.Add(new SqlParameter("@AllianceLink", SqlDbType.NVarChar)).Value =
                        mapCoordinate.AllianceLink;
                    sqlCommand.Parameters.Add(new SqlParameter("@Population", SqlDbType.Int)).Value =
                        mapCoordinate.Population;
                    sqlCommand.Parameters.Add(new SqlParameter("@CoordinateX", SqlDbType.Int)).Value =
                        mapCoordinate.CoordinateX;
                    sqlCommand.Parameters.Add(new SqlParameter("@CoordinateY", SqlDbType.Int)).Value =
                        mapCoordinate.CoordinateY;
                    sqlCommand.Parameters.Add(new SqlParameter("@TribeName", SqlDbType.NVarChar)).Value =
                        mapCoordinate.Tribe;
                    sqlCommand.Parameters.Add(new SqlParameter("@PlayerStatus", SqlDbType.NVarChar)).Value =
                        mapCoordinate.PlayerStatus;
                    sqlCommand.Parameters.Add(new SqlParameter("@PlayerStatusLink", SqlDbType.NVarChar)).Value =
                        mapCoordinate.PlayerStatusLink;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets the farm list.
        /// </summary>
        /// <returns></returns>
        public IList<MapCoordinates> GetFarmList()
        {
            WebGuiSettings webGuiSettings = GetSettings();
            if (webGuiSettings == null)
            {
                return null;
            }
            List<MapCoordinates> farmList = new List<MapCoordinates>();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SelectMap";
                    sqlCommand.Parameters.Add(new SqlParameter("@CoordinateX", SqlDbType.Int)).Value =
                        webGuiSettings.CoordinatesX;
                    sqlCommand.Parameters.Add(new SqlParameter("@CoordinateY", SqlDbType.Int)).Value =
                        webGuiSettings.CoordinatesY;
                    sqlCommand.Parameters.Add(new SqlParameter("@DistanceX", SqlDbType.Int)).Value =
                        webGuiSettings.DistanceX;
                    sqlCommand.Parameters.Add(new SqlParameter("@DistanceY", SqlDbType.Int)).Value =
                        webGuiSettings.DistanceY;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader != null)
                    {
                        while (sqlDataReader.Read())
                        {
                            MapCoordinates mapCoordinates = new MapCoordinates
                                                            {
                                                                VillageId =
                                                                    Int32.Parse(sqlDataReader["VillageId"].ToString()),
                                                                VillageLink = sqlDataReader["VillageLink"].ToString(),
                                                                VillageName = sqlDataReader["VillageName"].ToString()
                                                            };
                            farmList.Add(mapCoordinates);
                        }
                        sqlDataReader.Close();
                    }
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return farmList;
        }

        /// <summary>
        /// Populates the grid view with reports.
        /// </summary>
        /// <param name="srcTable">The SRC table.</param>
        /// <returns><see cref="DataSet"/></returns>
        public DataSet PopulateGridViewReports(string srcTable)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (sqlConnection =
                       new SqlConnection(ConfigurationManager.ConnectionStrings["Coordinator"].ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SelectLast100Reports";
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(dataSet, srcTable);
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataSet;
        }

        /// <summary>
        /// Fills the <see cref="DataSet"/> with <see cref="MapCoordinates"/>.
        /// </summary>
        /// <param name="srcTable">The SRC table.</param>
        /// <returns>
        ///     <c>null</c> if failed.
        /// </returns>
        public DataSet PopulateGridView(string srcTable)
        {
            WebGuiSettings webGuiSettings = GetSettings();
            if (webGuiSettings == null)
            {
                return null;
            }
            DataSet dataSet = new DataSet();
            try
            {
                using (sqlConnection =
                       new SqlConnection(ConfigurationManager.ConnectionStrings["Coordinator"].ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SelectMap";
                    sqlCommand.Parameters.Add(new SqlParameter("@CoordinateX", SqlDbType.Int)).Value =
                        webGuiSettings.CoordinatesX;
                    sqlCommand.Parameters.Add(new SqlParameter("@CoordinateY", SqlDbType.Int)).Value =
                        webGuiSettings.CoordinatesY;
                    sqlCommand.Parameters.Add(new SqlParameter("@DistanceX", SqlDbType.Int)).Value =
                        webGuiSettings.DistanceX;
                    sqlCommand.Parameters.Add(new SqlParameter("@DistanceY", SqlDbType.Int)).Value =
                        webGuiSettings.DistanceY;
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(dataSet, srcTable);
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataSet;
        }

        /// <summary>
        /// Gets the saved settings (Coordinates, distance and NextFarm).
        /// </summary>
        /// <returns>
        ///     <c>null</c> if failed.
        /// </returns>
        public WebGuiSettings GetSettings()
        {
            WebGuiSettings webGuiSettings = new WebGuiSettings();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SelectSettings";
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            webGuiSettings.CoordinatesX = Int32.Parse(reader["CoordinatesX"].ToString());
                            webGuiSettings.CoordinatesY = Int32.Parse(reader["CoordinatesY"].ToString());
                            webGuiSettings.NextFarm = (reader["NextFarm"].ToString());
                            webGuiSettings.DistanceX = Int32.Parse(reader["DistanceX"].ToString());
                            webGuiSettings.DistanceY = Int32.Parse(reader["DistanceY"].ToString());
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return webGuiSettings;
        }

        /// <summary>
        /// Gets the excluded alliances.
        /// </summary>
        /// <param name="srcTable">The SRC table.</param>
        /// <param name="type">The alliance type.</param>
        /// <returns><c>null</c> if failed; else new <see cref="DataSet"/></returns>
        public DataSet GetExcludedAlliances
            (string srcTable,
             int type)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SelectExcludedAlliances";
                    sqlCommand.Parameters.Add(new SqlParameter("@ExludedType", SqlDbType.Int)).Value = type;
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(dataSet, srcTable);
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataSet;
        }

        /// <summary>
        /// Gets the excluded players.
        /// </summary>
        /// <param name="srcTable">The SRC table.</param>
        /// <returns><c>null</c> if failed; else new <see cref="DataSet"/></returns>
        public DataSet GetExcludedPlayers(string srcTable)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SelectExcludedPlayers";
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(dataSet, srcTable);
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataSet;
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="webGuiSettings">The web GUI settings.</param>
        /// <returns><c>false</c> on fail.</returns>
        public bool SaveSettings(WebGuiSettings webGuiSettings)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "UpdateSettings";
                    sqlCommand.Parameters.Add(new SqlParameter("@CoordinatesX", SqlDbType.Int)).Value =
                        webGuiSettings.CoordinatesX;
                    sqlCommand.Parameters.Add(new SqlParameter("@CoordinatesY", SqlDbType.Int)).Value =
                        webGuiSettings.CoordinatesY;
                    sqlCommand.Parameters.Add(new SqlParameter("@NextFarm", SqlDbType.NVarChar)).Value =
                        webGuiSettings.NextFarm;
                    sqlCommand.Parameters.Add(new SqlParameter("@DistanceX", SqlDbType.Int)).Value =
                        webGuiSettings.DistanceX;
                    sqlCommand.Parameters.Add(new SqlParameter("@DistanceY", SqlDbType.Int)).Value =
                        webGuiSettings.DistanceY;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        /// <summary>
        /// Deletes the <see cref="MapCoordinates"/>.
        /// </summary>
        /// <param name="villageId">The village id.</param>
        /// <returns><c>true</c> on success; else <c>false</c>.</returns>
        public bool DeleteVillage(int villageId)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "DeleteVillage";
                    sqlCommand.Parameters.Add(new SqlParameter("@VillageId", SqlDbType.Int)).Value = villageId;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        /// <summary>
        /// Saves the reports to DB.
        /// </summary>
        /// <param name="reports">The reports.</param>
        /// <returns><c>true</c> on success; else <c>false</c>.</returns>
        public bool SaveReports(List<Report> reports)
        {
            return SaveReportInfo(reports) && SaveReportUnits(reports);
        }

        private bool SaveReportUnits
            (IEnumerable<Report> reports)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                        {
                            sqlCommand.Transaction = sqlTransaction;
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.CommandText = "UpdateReportUnits";
                            SqlParameter reportId = new SqlParameter("@ReportId", SqlDbType.Int);
                            SqlParameter tribeId = new SqlParameter("@TribeId", SqlDbType.Int);
                            SqlParameter type = new SqlParameter("@Type", SqlDbType.Int);
                            SqlParameter unit1 = new SqlParameter("@Unit1", SqlDbType.Int);
                            SqlParameter unit2 = new SqlParameter("@Unit2", SqlDbType.Int);
                            SqlParameter unit3 = new SqlParameter("@Unit3", SqlDbType.Int);
                            SqlParameter unit4 = new SqlParameter("@Unit4", SqlDbType.Int);
                            SqlParameter unit5 = new SqlParameter("@Unit5", SqlDbType.Int);
                            SqlParameter unit6 = new SqlParameter("@Unit6", SqlDbType.Int);
                            SqlParameter unit7 = new SqlParameter("@Unit7", SqlDbType.Int);
                            SqlParameter unit8 = new SqlParameter("@Unit8", SqlDbType.Int);
                            SqlParameter unit9 = new SqlParameter("@Unit9", SqlDbType.Int);
                            SqlParameter unit10 = new SqlParameter("@Unit10", SqlDbType.Int);
                            SqlParameter unitHero = new SqlParameter("@UnitHero", SqlDbType.Int);
                            sqlCommand.Parameters.Insert(0, unit1);
                            sqlCommand.Parameters.Insert(1, unit2);
                            sqlCommand.Parameters.Insert(2, unit3);
                            sqlCommand.Parameters.Insert(3, unit4);
                            sqlCommand.Parameters.Insert(4, unit5);
                            sqlCommand.Parameters.Insert(5, unit6);
                            sqlCommand.Parameters.Insert(6, unit7);
                            sqlCommand.Parameters.Insert(7, unit8);
                            sqlCommand.Parameters.Insert(8, unit9);
                            sqlCommand.Parameters.Insert(9, unit10);
                            sqlCommand.Parameters.Insert(10, unitHero);
                            sqlCommand.Parameters.Insert(11, reportId);
                            sqlCommand.Parameters.Insert(12, tribeId);
                            sqlCommand.Parameters.Insert(13, type);

                            foreach (Report report in reports)
                            {
                                reportId.Value = report.Id;
                                AddTroops(sqlCommand, ReportUnitType.AttackerTropps, report.TribeAttacker, report.Troops);
                                AddTroops(sqlCommand, ReportUnitType.AttackerCausalties, report.TribeAttacker,
                                          report.Casualties);
                                AddTroops(sqlCommand, ReportUnitType.AttackerPrisoners, report.TribeAttacker,
                                          report.Prisoners);
                                AddTroops(sqlCommand, ReportUnitType.DefenderTroops, report.TribeDefender,
                                          report.TroopsDefender);
                                AddTroops(sqlCommand, ReportUnitType.DefenderCasaulties, report.TribeDefender,
                                          report.CasualtiesDefender);
                            }
                        }
                        sqlTransaction.Commit();
                    }
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        private static void AddTroops
            (SqlCommand sqlCommand,
             ReportUnitType unitType,
             Tribes tribe,
             int[] troops)
        {
            SqlParameterCollection parameters = sqlCommand.Parameters;
            for (int i = 0; i < troops.Length; i++)
            {
                parameters[i].Value = troops[i];
            }
            parameters[12].Value = tribe;
            parameters[13].Value = unitType;
            sqlCommand.ExecuteNonQuery();
        }

        private bool SaveReportInfo
            (IEnumerable<Report> reports)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                        {
                            sqlCommand.Transaction = sqlTransaction;
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.CommandText = "UpdateReports";
                            SqlParameter reportId = new SqlParameter("@ReportId", SqlDbType.Int);
                            SqlParameter reportLink = new SqlParameter("@ReportLink", SqlDbType.NVarChar);
                            SqlParameter reportText = new SqlParameter("@ReportText", SqlDbType.NVarChar);
                            SqlParameter reportDate = new SqlParameter("@ReportDate", SqlDbType.DateTime);
                            SqlParameter attackerId = new SqlParameter("@AttackerId", SqlDbType.Int);
                            SqlParameter attackerName = new SqlParameter("@AttackerName", SqlDbType.NVarChar);
                            SqlParameter attackerVillageId = new SqlParameter("@AttackerVillageId", SqlDbType.Int);
                            SqlParameter attackerVillageName = new SqlParameter("@AttackerVillageName",
                                                                                SqlDbType.NVarChar);
                            SqlParameter defenderId = new SqlParameter("@DefenderId", SqlDbType.Int);
                            SqlParameter defenderName = new SqlParameter("@DefenderName", SqlDbType.NVarChar);
                            SqlParameter defenderVillageId = new SqlParameter("@DefenderVillageId", SqlDbType.Int);
                            SqlParameter defenderVillageName = new SqlParameter("@DefenderVillageName",
                                                                                SqlDbType.NVarChar);
                            SqlParameter goodsWood = new SqlParameter("@GoodsWood", SqlDbType.Int);
                            SqlParameter goodsClay = new SqlParameter("@GoodsClay", SqlDbType.Int);
                            SqlParameter goodsIron = new SqlParameter("@GoodsIron", SqlDbType.Int);
                            SqlParameter goodsCrop = new SqlParameter("@GoodsCrop", SqlDbType.Int);
                            sqlCommand.Parameters.Add(reportId);
                            sqlCommand.Parameters.Add(reportLink);
                            sqlCommand.Parameters.Add(reportText);
                            sqlCommand.Parameters.Add(reportDate);
                            sqlCommand.Parameters.Add(attackerId);
                            sqlCommand.Parameters.Add(attackerName);
                            sqlCommand.Parameters.Add(defenderId);
                            sqlCommand.Parameters.Add(defenderName);
                            sqlCommand.Parameters.Add(attackerVillageId);
                            sqlCommand.Parameters.Add(attackerVillageName);
                            sqlCommand.Parameters.Add(defenderVillageId);
                            sqlCommand.Parameters.Add(defenderVillageName);
                            sqlCommand.Parameters.Add(goodsWood);
                            sqlCommand.Parameters.Add(goodsClay);
                            sqlCommand.Parameters.Add(goodsIron);
                            sqlCommand.Parameters.Add(goodsCrop);

                            foreach (Report report in reports)
                            {
                                reportId.Value = report.Id;
                                reportLink.Value = report.Url;
                                reportText.Value = report.Text;
                                reportDate.Value = report.Date;
                                attackerId.Value = report.AttackerId;
                                attackerName.Value = report.AttackerName;
                                defenderId.Value = report.DefenderId;
                                defenderName.Value = report.DefenderName;
                                attackerVillageId.Value = report.AttackerVillageId;
                                attackerVillageName.Value = report.AttackerVillageName;
                                defenderVillageId.Value = report.DefenderVillageId;
                                defenderVillageName.Value = report.DefenderVillageName;
                                goodsWood.Value = report.Goods[0];
                                goodsClay.Value = report.Goods[1];
                                goodsIron.Value = report.Goods[2];
                                goodsCrop.Value = report.Goods[3];
                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                        sqlTransaction.Commit();
                    }
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        /// <summary>
        /// Saves the <see cref="MapCoordinates"/> to DB.
        /// </summary>
        /// <param name="coordinateses">The coordinateses <see cref="MapCoordinates"/>.</param>
        /// <returns><c>true</c> on success; else <c>false</c>.</returns>
        public bool SaveVillages(IList<MapCoordinates> coordinateses)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                        {
                            sqlCommand.Transaction = sqlTransaction;
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.CommandText = "UpdateMap";
                            SqlParameter villageId = new SqlParameter("@VillageId", SqlDbType.Int);
                            SqlParameter villageName = new SqlParameter("@VillageName", SqlDbType.NVarChar);
                            SqlParameter villageLink = new SqlParameter("@VillageLink", SqlDbType.NVarChar);
                            SqlParameter userId = new SqlParameter("@UserId", SqlDbType.Int);
                            SqlParameter userName = new SqlParameter("@UserName", SqlDbType.NVarChar);
                            SqlParameter userLink = new SqlParameter("@UserLink", SqlDbType.NVarChar);
                            SqlParameter allianceId = new SqlParameter("@AllianceId", SqlDbType.Int);
                            SqlParameter allianceName = new SqlParameter("@AllianceName", SqlDbType.NVarChar);
                            SqlParameter allianceLink = new SqlParameter("@AllianceLink", SqlDbType.NVarChar);
                            SqlParameter population = new SqlParameter("@Population", SqlDbType.Int);
                            SqlParameter coordinateX = new SqlParameter("@CoordinateX", SqlDbType.Int);
                            SqlParameter coordinateY = new SqlParameter("@CoordinateY", SqlDbType.Int);
                            SqlParameter tribeName = new SqlParameter("@TribeName", SqlDbType.NVarChar);
                            SqlParameter playerStatus = new SqlParameter("@PlayerStatus", SqlDbType.NVarChar);
                            SqlParameter playerStatusLink = new SqlParameter("@PlayerStatusLink", SqlDbType.NVarChar);
                            sqlCommand.Parameters.Add(villageId);
                            sqlCommand.Parameters.Add(villageName);
                            sqlCommand.Parameters.Add(villageLink);
                            sqlCommand.Parameters.Add(userId);
                            sqlCommand.Parameters.Add(userName);
                            sqlCommand.Parameters.Add(userLink);
                            sqlCommand.Parameters.Add(allianceId);
                            sqlCommand.Parameters.Add(allianceName);
                            sqlCommand.Parameters.Add(allianceLink);
                            sqlCommand.Parameters.Add(population);
                            sqlCommand.Parameters.Add(coordinateX);
                            sqlCommand.Parameters.Add(coordinateY);
                            sqlCommand.Parameters.Add(tribeName);
                            sqlCommand.Parameters.Add(playerStatus);
                            sqlCommand.Parameters.Add(playerStatusLink);
                            foreach (MapCoordinates mapCoordinate in coordinateses)
                            {
                                villageId.Value = mapCoordinate.VillageId;
                                villageName.Value = mapCoordinate.VillageName;
                                villageLink.Value = mapCoordinate.VillageLink;
                                userId.Value = mapCoordinate.PlayerId;
                                userName.Value = mapCoordinate.PlayerName;
                                userLink.Value = mapCoordinate.PlayerNameLink;
                                allianceId.Value = mapCoordinate.AllianceId;
                                allianceName.Value = mapCoordinate.AllianceId > 0
                                                         ? mapCoordinate.AllianceName
                                                         : String.Empty;
                                allianceLink.Value = mapCoordinate.AllianceLink;
                                population.Value = mapCoordinate.Population;
                                coordinateX.Value = mapCoordinate.CoordinateX;
                                coordinateY.Value = mapCoordinate.CoordinateY;
                                tribeName.Value = mapCoordinate.Tribe;
                                playerStatus.Value = mapCoordinate.PlayerStatus;
                                playerStatusLink.Value = mapCoordinate.PlayerStatusLink;
                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                        sqlTransaction.Commit();
                    }
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        /// <summary>
        /// Updates the notes for specified <see cref="MapCoordinates.VillageId"/>.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <param name="notes">The notes.</param>
        /// <returns><c>true</c> on success; else <c>false</c>.</returns>
        public bool UpdateNotes
            (int coordinates,
             string notes)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = sqlConnection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateNotes";
                    cmd.Parameters.Add("@VillageCoordinates", SqlDbType.Int).Value = coordinates;
                    cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        /// <summary>
        /// Adds the excluded player to the list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> on success; else <c>false</c>.</returns>
        public bool AddExcludedPlayer
            (string id,
             string name)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "UpdateExcludedPlayer";
                    sqlCommand.Parameters.Add(new SqlParameter("@PlayerId", SqlDbType.Int)).Value = id;
                    sqlCommand.Parameters.Add(new SqlParameter("@PlayerName", SqlDbType.NVarChar)).Value = name;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        /// <summary>
        /// Adds the excluded player to the list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="type">Type of Alliance (Ally, Nap, Friend).</param>
        /// <returns><c>true</c> on success; else <c>false</c>.</returns>
        public bool AddExcludedAlliance
            (string id,
             string name,
             int type)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "UpdateExcludedAlliance";
                    sqlCommand.Parameters.Add(new SqlParameter("@AllianceId", SqlDbType.Int)).Value = id;
                    sqlCommand.Parameters.Add(new SqlParameter("@AllianceName", SqlDbType.NVarChar)).Value = name;
                    sqlCommand.Parameters.Add(new SqlParameter("@ExludedType", SqlDbType.Int)).Value = type;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool RemoveExcludedPlayer(string selectedValue)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "DeleteExcludedPlayer";
                    sqlCommand.Parameters.Add(new SqlParameter("@PlayerId", SqlDbType.Int)).Value =
                        Misc.String2Number(selectedValue);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool RemoveExcludedAlliance(string selectedValue)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "DeleteExcludedAlliance";
                    sqlCommand.Parameters.Add(new SqlParameter("@AllianceId", SqlDbType.Int)).Value =
                        Misc.String2Number(selectedValue);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public DataSet GetGoods(string srcTable,
                                int villageId)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = String.Format(CultureInfo.InvariantCulture, @"
SELECT SUM([Wood]) AS Wood, SUM([Clay]) AS Clay, SUM([Iron]) AS Iron, SUM([Crop]) AS Crop FROM [ReportGoods]
WHERE [DefenderVillageId] = {0}", villageId);
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(dataSet, srcTable);
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataSet;
        }

        public DataSet UpdateGoodsInfo(string srcTable)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = @"
SELECT ReportId,
    (SELECT AttackerId FROM  ReportInfo WHERE ReportInfo.ReportId = [ReportGoods].ReportId) AS AttackerId,
    (SELECT DefenderVillageId FROM  ReportInfo WHERE ReportInfo.ReportId = [ReportGoods].ReportId) AS DefenderVillageId,
    (SELECT ReportDate FROM  Reports WHERE Reports.ReportId = [ReportGoods].ReportId) AS ReportDate
  FROM [Coordinator].[dbo].[ReportGoods]";
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(dataSet, srcTable);

                    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                    sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.Transaction = sqlTransaction;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = @"
UPDATE [Coordinator].[dbo].[ReportGoods]
   SET [ReportDate] = @ReportDate
      ,[AttackerId] = @AttackerId
      ,[DefenderVillageId] = @DefenderVillageId
 WHERE [ReportId] = @ReportId";
                    SqlParameter reportId = new SqlParameter("@ReportId", SqlDbType.Int);
                    SqlParameter reportDate = new SqlParameter("@ReportDate", SqlDbType.DateTime);
                    SqlParameter attackerId = new SqlParameter("@AttackerId", SqlDbType.Int);
                    SqlParameter defenderVillageId = new SqlParameter("@DefenderVillageId", SqlDbType.Int);
                    sqlCommand.Parameters.Add(reportId);
                    sqlCommand.Parameters.Add(reportDate);
                    sqlCommand.Parameters.Add(attackerId);
                    sqlCommand.Parameters.Add(defenderVillageId);
                    DataRowCollection dataRowCollection = dataSet.Tables[srcTable].Rows;
                    for (int i = 0; i <= dataRowCollection.Count - 1; i++)
                    {
                        reportId.Value = dataRowCollection[i]["ReportId"].ToString().Trim();
                        reportDate.Value = dataRowCollection[i]["ReportDate"].ToString().Trim();
                        attackerId.Value = dataRowCollection[i]["AttackerId"].ToString().Trim();
                        defenderVillageId.Value = dataRowCollection[i]["DefenderVillageId"].ToString().Trim();
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlTransaction.Commit();
                }
            }
            catch (SqlException exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataSet;
        }

        private SqlConnection sqlConnection;

        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["Coordinator"].ConnectionString;
    }
}