using System;
using System.Data;
using System.Data.SQLite;

namespace jeza.ioFTPD.Framework
{
    public class DataBase
    {
        public static DataTable GetDataTable(string commandText)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(Constants.DataSource);
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
            SQLiteConnection cnn = new SQLiteConnection(Constants.DataSource);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = commandText};
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }

        public static string ExecuteScalar(string commandText)
        {
            SQLiteConnection cnn = new SQLiteConnection(Constants.DataSource);
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
        /// Selects from dupe data base.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns><c>null</c> if record not found, else <see cref="DataBaseDupe"/></returns>
        public static DataBaseDupe SelectFromDupe(string commandText)
        {
            DataTable dataTable = GetDataTable(commandText);
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                object[] itemArray = dataRowCollection[0].ItemArray;

                DataBaseDupe dataBaseDupe = new DataBaseDupe
                                            {
                                                Id = Misc.String2Number(itemArray [0].ToString()),
                                                UserName = itemArray [1].ToString(),
                                                DateTime = itemArray[2].ToString(),
                                                PathReal = itemArray [3].ToString(),
                                                PathVirtual = itemArray [4].ToString(),
                                                ReleaseName = itemArray [5].ToString(),
                                                Nuked = Misc.String2Number(itemArray [6].ToString()) > 0 ? true : false,
                                                NukedReason = itemArray [7].ToString(),
                                                Wiped = Misc.String2Number(itemArray[8].ToString()) > 0 ? true : false,
                                                WipedReason = itemArray [9].ToString(),
                                            };
                return dataBaseDupe;
            }
            return null;
        }
    }
}