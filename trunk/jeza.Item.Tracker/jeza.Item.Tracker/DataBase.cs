using System;
using System.Data;
using System.Data.SQLite;
using NLog;

namespace jeza.Item.Tracker
{
    public class DataBase
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static DataTable GetDataTable(string commandText)
        {
            Log.Debug("GetDataTable: '{0}'", commandText);
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(Config.DataSource);
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn) { CommandText = commandText };
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }

            return dt;
        }

        public static int ExecuteNonQuery(string commandText)
        {
            Log.Debug("ExecuteNonQuery: '{0}'", commandText);
            SQLiteConnection cnn = new SQLiteConnection(Config.DataSource);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn) { CommandText = commandText };
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }

        public static string ExecuteScalar(string commandText)
        {
            Log.Debug("ExecuteScalar: '{0}'", commandText);
            SQLiteConnection cnn = new SQLiteConnection(Config.DataSource);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn) { CommandText = commandText };
            object value = mycommand.ExecuteScalar();
            cnn.Close();
            return value != null ? value.ToString() : "";
        }
        public int InsertItem()
        {
            throw new NotImplementedException();
        }

        public int InsertItemStatus()
        {
            throw new NotImplementedException();
        }

        public int InsertItemType()
        {
            throw new NotImplementedException();
        }

        public int InsertOrderPerson()
        {
            throw new NotImplementedException();
        }

        public int InsertOrderStore()
        {
            throw new NotImplementedException();
        }

        public int InsertPerson()
        {
            throw new NotImplementedException();
        }

        public int InsertStore()
        {
            throw new NotImplementedException();
        }
    }
}