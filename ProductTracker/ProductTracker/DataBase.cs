#region

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.Globalization;

#endregion

namespace ProductTracker
{
    public class DataBase
    {
        public DataBase()
        {
            dbConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            dbConnection = new SQLiteConnection(dbConnectionString);
        }

        /// <summary>
        /// Deletes all items.
        /// </summary>
        public void DeleteAllItems()
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = "DELETE FROM Items";
                    dbCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes all shops.
        /// </summary>
        public void DeleteAllShops()
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = "DELETE FROM Shops";
                    dbCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets the available shops.
        /// </summary>
        /// <returns><see cref="IList{T}"/></returns>
        public IList<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = "SELECT * FROM Items";
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item()
                            {
                                Id = reader[0].ToString(),
                                UniqueId= new Guid(reader[1].ToString()),
                                Name = reader[2].ToString(),
                                Notes = reader[3].ToString(),
                                ItemTypeNumber = Int32.Parse(reader[4].ToString()),
                            };
                            item.ItemType = item.ConvertIntToItemType(item.ItemTypeNumber);
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        /// <summary>
        /// Gets the available shops.
        /// </summary>
        /// <returns><see cref="IList{T}"/></returns>
        public IList<Shop> GetShops()
        {
            List<Shop> shops = new List<Shop>();
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = "SELECT * FROM Shops";
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //var asd = reader[0];
                            Shop shop = new Shop
                                {
                                    Id = new Guid(reader[0].ToString()),
                                    Name = reader[1].ToString(),
                                    Address = reader[2].ToString(),
                                    Owner = reader[3].ToString(),
                                    PostalCode = Int32.Parse(reader[4].ToString()),
                                    City = reader[5].ToString(),
                                    IsCompany = Boolean.Parse(reader[6].ToString()),
                                };
                            shops.Add(shop);
                        }
                    }
                }
            }
            return shops;
        }

        /// <summary>
        /// Gets the list of users.
        /// </summary>
        /// <returns><see cref="IList{T}"/></returns>
        public IList<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    // Create a table in the database
                    //dbCommand.CommandText = "CREATE TABLE FOO (ID INTEGER PRIMARY KEY, MYVALUE VARCHAR(50))";
                    //dbCommand.ExecuteNonQuery();
                    // Create a parameterized insert command
                    //dbCommand.CommandText = "INSERT INTO FOO (MYVALUE) VALUES(?)";
                    //dbCommand.Parameters.Add(dbCommand.CreateParameter());
                    // Insert 10 rows into the database
                    //for (int n = 0; n < 10; n++)
                    //{
                    //    dbCommand.Parameters[0].Value = "Value " + n;
                    //    dbCommand.ExecuteNonQuery();
                    //}
                    // Now read them back
                    dbCommand.CommandText = "SELECT * FROM Users";
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                                {
                                    Id = Int32.Parse(reader[0].ToString()),
                                    Name = reader[1].ToString(),
                                    Password = reader[2].ToString(),
                                    Level = Int32.Parse(reader[3].ToString())
                                };
                            users.Add(user);
                        }
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// Inserts new item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool InsertItem(Item item)
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    // Create a parameterized insert command
                    string guid = item.UniqueId.ToString();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Items (Id, UniqueId, Name, Notes, ItemType) VALUES('{0}', '{1}', '{2}', '{3}', {4})",
                                                       item.Id, guid, item.Name, item.Notes, (int)item.ItemType);
                    dbCommand.CommandText = commandText;
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
                }
            }
        }

        /// <summary>
        /// Inserts new shop.
        /// </summary>
        /// <param name="shop">The shop.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool InsertShop(Shop shop)
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    // Create a parameterized insert command
                    string guid = shop.Id.ToString();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Shops (Id, Name, Address, Owner, PostalCode, City, IsCompany) VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}', {6})",
                                                       guid, shop.Name, shop.Address, shop.Owner, shop.PostalCode,
                                                       shop.City, shop.IsCompany ? 1 : 0);
                    dbCommand.CommandText = commandText;
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
                }
            }
        }

        private readonly string dbConnectionString;
        private readonly DbConnection dbConnection;
    }
}