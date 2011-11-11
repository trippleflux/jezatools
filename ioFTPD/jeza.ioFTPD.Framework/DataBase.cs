using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace jeza.ioFTPD.Framework
{
    public class DataBase
    {
        public static DataTable GetDataTable(string commandText)
        {
            Log.Debug("GetDataTable: '{0}'", commandText);
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(Config.DataSourceDupe);
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = commandText};
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception exception)
            {
                Log.Debug(exception.ToString());
            }

            return dt;
        }

        public static int ExecuteNonQuery(string commandText)
        {
            Log.Debug("ExecuteNonQuery: '{0}'", commandText);
            SQLiteConnection cnn = new SQLiteConnection(Config.DataSourceDupe);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = commandText};
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }

        public static string ExecuteScalar(string commandText)
        {
            Log.Debug("ExecuteScalar: '{0}'", commandText);
            SQLiteConnection cnn = new SQLiteConnection(Config.DataSourceDupe);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = commandText};
            object value = mycommand.ExecuteScalar();
            cnn.Close();
            return value != null ? value.ToString() : "";
        }

        public static int Insert(string commandText)
        {
            return ExecuteNonQuery(commandText);
        }

        public static int Update(string commandText)
        {
            return ExecuteNonQuery(commandText);
        }

        /// <summary>
        /// Returns first record from dupe data base.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns><c>null</c> if record not found, else <see cref="DataBaseDupe"/></returns>
        public static DataBaseDupe SelectFromDupe(string commandText)
        {
            Log.Debug("SelectFromDupe: '{0}'", commandText);
            DataTable dataTable = GetDataTable(commandText);
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                object[] itemArray = dataRowCollection[0].ItemArray;

                DataBaseDupe dataBaseDupe = new DataBaseDupe
                                            {
                                                Id = Misc.String2Number(itemArray [0].ToString()),
                                                UserName = itemArray [1].ToString(),
                                                GroupName = itemArray[2].ToString(),
                                                DateTime = itemArray[3].ToString(),
                                                PathReal = itemArray [4].ToString(),
                                                PathVirtual = itemArray [5].ToString(),
                                                ReleaseName = itemArray [6].ToString(),
                                                Nuked = Misc.String2Number(itemArray [7].ToString()) > 0 ? true : false,
                                                NukedReason = itemArray [8].ToString(),
                                                Wiped = Misc.String2Number(itemArray[9].ToString()) > 0 ? true : false,
                                                WipedReason = itemArray [10].ToString(),
                                            };
                return dataBaseDupe;
            }
            return null;
        }

        /// <summary>
        /// Returns all record from dupe data base.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns><c>null</c> if record not found, else <see cref="DataBaseDupe"/></returns>
        public static List<DataBaseDupe> SelectFromDupeAll(string commandText)
        {
            Log.Debug("SelectFromDupeAll: '{0}'", commandText);
            DataTable dataTable = GetDataTable(commandText);
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                List<DataBaseDupe> list = new List<DataBaseDupe>();
                foreach (DataRow dataRow in dataRowCollection)
                {
                    object[] itemArray = dataRow.ItemArray;
                    DataBaseDupe dataBaseDupe = new DataBaseDupe
                    {
                        Id = Misc.String2Number(itemArray[0].ToString()),
                        UserName = itemArray[1].ToString(),
                        GroupName = itemArray[2].ToString(),
                        DateTime = itemArray[3].ToString(),
                        PathReal = itemArray[4].ToString(),
                        PathVirtual = itemArray[5].ToString(),
                        ReleaseName = itemArray[6].ToString(),
                        Nuked = Misc.String2Number(itemArray[7].ToString()) > 0 ? true : false,
                        NukedReason = itemArray[8].ToString(),
                        Wiped = Misc.String2Number(itemArray[9].ToString()) > 0 ? true : false,
                        WipedReason = itemArray[10].ToString(),
                    };
                    list.Add(dataBaseDupe);
                }
                return list;
            }
            return null;
        }
    }
}