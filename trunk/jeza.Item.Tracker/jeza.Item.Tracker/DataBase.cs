using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
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
                using (SQLiteConnection sqLiteConnection = new SQLiteConnection(Config.DataSource))
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    SQLiteDataReader reader = mycommand.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                    sqLiteConnection.Close();
                }
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
            try
            {
                using (SQLiteConnection sqLiteConnection = new SQLiteConnection(Config.DataSource))
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    int rowsUpdated = mycommand.ExecuteNonQuery();
                    sqLiteConnection.Close();
                    return rowsUpdated;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return 0;
            }
        }

        public static int ExecuteNonQuery(SQLiteCommand sqLiteCommand)
        {
            try
            {
                Log.Debug("ExecuteNonQuery: '{0}'", sqLiteCommand.CommandText);
                SQLiteConnection sqLiteConnection = new SQLiteConnection(Config.DataSource);
                {
                    using (SQLiteCommand command = new SQLiteCommand(sqLiteCommand.CommandText, sqLiteConnection))
                    {
                        sqLiteConnection.Open();
                        command.Parameters.Add(sqLiteCommand.Parameters[0]);
                        int rowsUpdated = command.ExecuteNonQuery();
                        sqLiteConnection.Close();
                        return rowsUpdated;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return 0;
            }
        }

        public static string ExecuteScalar(string commandText)
        {
            Log.Debug("ExecuteScalar: '{0}'", commandText);
            try
            {
                using (SQLiteConnection sqLiteConnection = new SQLiteConnection(Config.DataSource))
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    object value = mycommand.ExecuteScalar();
                    sqLiteConnection.Close();
                    return value != null ? value.ToString() : "";
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return String.Empty;
            }
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
            try
            {
                const string commandText =
                    @"INSERT INTO Item (Name, Description, ItemType, Image) VALUES(@name, @description, @itemType, @image)";
                Log.Debug("InsertItem: '{0}'", commandText);
                using (SQLiteConnection sqLiteConnection = new SQLiteConnection(Config.DataSource))
                {
                    using (SQLiteCommand sqLiteCommand = new SQLiteCommand(commandText, sqLiteConnection))
                    {
                        sqLiteConnection.Open();
                        sqLiteCommand.Parameters.AddWithValue("@name", item.Name);
                        sqLiteCommand.Parameters.AddWithValue("@description", item.Description);
                        sqLiteCommand.Parameters.AddWithValue("@itemType", item.ItemTypeId);
                        sqLiteCommand.Parameters.AddWithValue("@image", item.Image);
                        int rowsUpdated = sqLiteCommand.ExecuteNonQuery();
                        sqLiteConnection.Close();
                        return rowsUpdated;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return 0;
            }
        }

        public int InsertItemType(string itemTypeName)
        {
            string insertCommand = String.Format(@"INSERT INTO ItemType (Name, Description) VALUES('{0}', '{0}')",
                                                 itemTypeName);
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

        public int InsertPerson(PersonInfo personInfo)
        {
            string insertCommand =
                String.Format(
                    @"INSERT INTO PersonInfo ( Name, SurName, NickName, Description, Address, PostNumber, City, Email, Telephone, TelephoneMobile, Fax) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', '{8}', '{9}', '{10}')",
                    personInfo.Name,
                    personInfo.SurName,
                    personInfo.NickName,
                    personInfo.Description,
                    personInfo.Address,
                    personInfo.PostNumber,
                    personInfo.City,
                    personInfo.Email,
                    personInfo.Telephone,
                    personInfo.TelephoneMobile,
                    personInfo.Fax);
            return ExecuteNonQuery(insertCommand);
        }

        public int InsertStore()
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int itemId)
        {
            string commandText = @"SELECT Id, Name, Description, ItemType, Image FROM Item WHERE Id = " + itemId;
            try
            {
                using (SQLiteConnection sqLiteConnection = new SQLiteConnection(Config.DataSource))
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    SQLiteDataReader reader = mycommand.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        int itemTypeId = reader.GetInt32(3);
                        byte[] bytes = GetBytes(reader);
                        Item item = new Item
                                    {
                                        Id = id,
                                        Name = name,
                                        Description = description,
                                        ItemTypeId = itemTypeId,
                                        Image = bytes
                                    };
                        return item;
                    }
                    reader.Close();
                    sqLiteConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
            return null;
        }

        public List<Item> GetItems()
        {
            const string commandText = @"SELECT Id, Name, Description, ItemType, Image FROM Item";
            List<Item> items = new List<Item>();
            try
            {
                using (SQLiteConnection sqLiteConnection = new SQLiteConnection(Config.DataSource))
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    SQLiteDataReader reader = mycommand.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        int itemTypeId = reader.GetInt32(3);
                        byte[] bytes = GetBytes(reader);
                        Item item = new Item
                                    {
                                        Id = id,
                                        Name = name,
                                        Description = description,
                                        ItemTypeId = itemTypeId,
                                        Image = bytes
                                    };
                        items.Add(item);
                    }
                    reader.Close();
                    sqLiteConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
            return items;
        }

        private static byte[] GetBytes(SQLiteDataReader reader)
        {
            byte[] bytes;
            const int chunkSize = 2*1024;
            byte[] buffer = new byte[chunkSize];
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                long bytesRead;
                while ((bytesRead = reader.GetBytes(4, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    byte[] actualRead = new byte[bytesRead];
                    Buffer.BlockCopy(buffer, 0, actualRead, 0, (int) bytesRead);
                    stream.Write(actualRead, 0, actualRead.Length);
                    fieldOffset += bytesRead;
                }
                bytes = stream.ToArray();
            }
            return bytes;
        }

        public int InsertItemStatus(string itemStatusName)
        {
            string insertCommand = String.Format(@"INSERT INTO ItemStatus (Name, Description) VALUES('{0}', '{0}')",
                                                 itemStatusName);
            return ExecuteNonQuery(insertCommand);
        }

        public List<PersonInfo> GetPersonInfo()
        {
            const string commandText =
                @"SELECT Id, Name, SurName, NickName, Description, Address, PostNumber, City, Email, Telephone, TelephoneMobile, Fax FROM PersonInfo";
            DataTable dataTable = GetDataTable(commandText);
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                return (from DataRow dataRow in dataRowCollection
                        select dataRow.ItemArray
                        into itemArray
                        select new PersonInfo
                               {
                                   Id = Misc.String2Number(itemArray[0].ToString()),
                                   Name = itemArray[1].ToString(),
                                   SurName = itemArray[2].ToString(),
                                   NickName = itemArray[3].ToString(),
                                   Description = itemArray[4].ToString(),
                                   Address = itemArray[5].ToString(),
                                   PostNumber = Misc.String2Number(itemArray[6].ToString()),
                                   City = itemArray[7].ToString(),
                                   Email = itemArray[8].ToString(),
                                   Telephone = itemArray[9].ToString(),
                                   TelephoneMobile = itemArray[10].ToString(),
                                   Fax = itemArray[11].ToString(),
                               }).ToList();
            }
            return null;
        }

        public PersonInfo GetPersonInfo(int personInfoId)
        {
            string commandText =
                @"SELECT Id, Name, SurName, NickName, Description, Address, PostNumber, City, Email, Telephone, TelephoneMobile, Fax FROM PersonInfo WHERE Id = " +
                personInfoId;
            DataTable dataTable = GetDataTable(commandText);
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                object[] itemArray = dataRowCollection[0].ItemArray;
                PersonInfo personInfo = new PersonInfo
                                        {
                                            Id = Misc.String2Number(itemArray[0].ToString()),
                                            Name = itemArray[1].ToString(),
                                            SurName = itemArray[2].ToString(),
                                            NickName = itemArray[3].ToString(),
                                            Description = itemArray[4].ToString(),
                                            Address = itemArray[5].ToString(),
                                            PostNumber = Misc.String2Number(itemArray[6].ToString()),
                                            City = itemArray[7].ToString(),
                                            Email = itemArray[8].ToString(),
                                            Telephone = itemArray[9].ToString(),
                                            TelephoneMobile = itemArray[10].ToString(),
                                            Fax = itemArray[11].ToString(),
                                        };
                return personInfo;
            }
            return null;
        }
    }
}