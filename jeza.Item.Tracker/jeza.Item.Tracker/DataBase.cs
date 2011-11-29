using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
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
                SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = commandText};
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
            SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = commandText};
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }

        public static string ExecuteScalar(string commandText)
        {
            Log.Debug("ExecuteScalar: '{0}'", commandText);
            SQLiteConnection cnn = new SQLiteConnection(Config.DataSource);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = commandText};
            object value = mycommand.ExecuteScalar();
            cnn.Close();
            return value != null ? value.ToString() : "";
        }

        public List<ItemType> GetItemTypes()
        {
            DataTable dataTable = GetDataTable(@"SELECT Id, Name, Description FROM ItemType");
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                return (from DataRow dataRow in dataRowCollection
                        select dataRow.ItemArray
                        into itemArray select new ItemType
                                              {
                                                  Id = Misc.String2Number(itemArray[0].ToString()),
                                                  Name = itemArray[1].ToString(),
                                                  Description = itemArray[2].ToString(),
                                              }).ToList();
            }
            return null;
        }

        public List<ItemStatus> GetItemStatus()
        {
            DataTable dataTable = GetDataTable(@"SELECT Id, Name, Description FROM ItemStatus");
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                return (from DataRow dataRow in dataRowCollection
                        select dataRow.ItemArray
                        into itemArray
                        select new ItemStatus
                               {
                                   Id = Misc.String2Number(itemArray[0].ToString()),
                                   Name = itemArray[1].ToString(),
                                   Description = itemArray[2].ToString(),
                               }).ToList();
            }
            return null;
        }

        public int InsertItem(Item item)
        {
            string insertCommand = String.Format(@"INSERT INTO Item (Name, Description, ItemType) VALUES('{0}', '{1}', {2})", item.Name, item.Description, item.ItemTypeId);
            return ExecuteNonQuery(insertCommand);
        }

        public int InsertItemStatus(string itemStatus)
        {
            string insertCommand = String.Format(@"INSERT INTO ItemStatus (Name, Description) VALUES('{0}', '{0}')", itemStatus);
            return ExecuteNonQuery(insertCommand);
        }

        public int InsertItemType(string itemTypeName)
        {
            string insertCommand = String.Format(@"INSERT INTO ItemType (Name, Description) VALUES('{0}', '{0}')", itemTypeName);
            return ExecuteNonQuery(insertCommand);
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

        public List<Item> GetItems()
        {
            DataTable dataTable = GetDataTable(@"SELECT Id, Name, Description, ItemType FROM Item");
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                return (from DataRow dataRow in dataRowCollection
                        select dataRow.ItemArray
                            into itemArray
                            select new Item
                            {
                                Id = Misc.String2Number(itemArray[0].ToString()),
                                Name = itemArray[1].ToString(),
                                Description = itemArray[2].ToString(),
                                ItemTypeId = Misc.String2Number(itemArray[3].ToString()),
                            }).ToList();
            }
            return null;
        }
    }
}