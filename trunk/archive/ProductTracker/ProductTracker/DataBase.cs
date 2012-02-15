#region

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Globalization;
using System.Text;
using log4net;

#endregion

namespace ProductTracker
{
    public class DataBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (DataBase));

        public DataBase()
        {
            dbConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            dbConnection = new SQLiteConnection(dbConnectionString);
            Log.DebugFormat("dbConnectionString='{0}'", dbConnectionString);
        }

        /// <summary>
        /// Deletes all items.
        /// </summary>
        public void DeleteAllItems()
        {
            Log.Debug("DeleteAllItems");
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    const string commandText = "DELETE FROM Items";
                    dbCommand.CommandText = commandText;
                    dbCommand.ExecuteNonQuery();
                    Log.Debug(commandText);
                }
            }
        }

        /// <summary>
        /// Deletes all item types.
        /// </summary>
        public void DeleteAllItemTypes()
        {
            Log.Debug("DeleteAllItemTypes");
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    const string commandText = "DELETE FROM ItemType";
                    dbCommand.CommandText = commandText;
                    dbCommand.ExecuteNonQuery();
                    Log.Debug(commandText);
                }
            }
        }

        /// <summary>
        /// Deletes all shops.
        /// </summary>
        public void DeleteAllShops()
        {
            Log.Debug("DeleteAllShops");
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    const string commandText = "DELETE FROM Shops";
                    dbCommand.CommandText = commandText;
                    dbCommand.ExecuteNonQuery();
                    Log.Debug(commandText);
                }
            }
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteItem(string id)
        {
            Log.DebugFormat("DeleteItem: '{0}'", id);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "DELETE FROM Price WHERE Item='{0}'", id);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    dbCommand.ExecuteNonQuery();
                    commandText = String.Format(CultureInfo.InvariantCulture,
                                                "DELETE FROM ShopItems WHERE Item='{0}'", id);
                    dbCommand.CommandText = commandText;
                    dbCommand.ExecuteNonQuery();
                    Log.Debug(commandText);
                    commandText = String.Format(CultureInfo.InvariantCulture,
                                                "DELETE FROM Items WHERE UniqueId='{0}'", id);
                    dbCommand.CommandText = commandText;
                    dbCommand.ExecuteNonQuery();
                    Log.Debug(commandText);
                }
            }
        }

        /// <summary>
        /// Deletes the specified shop.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteShop(string id)
        {
            Log.DebugFormat("DeleteShop: '{0}'", id);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "DELETE FROM Price WHERE Shop='{0}'", id);
                    dbCommand.CommandText = commandText;
                    dbCommand.ExecuteNonQuery();
                    Log.Debug(commandText);
                    commandText = String.Format(CultureInfo.InvariantCulture,
                                                "DELETE FROM ShopItems WHERE Shop='{0}'", id);
                    dbCommand.CommandText = commandText;
                    dbCommand.ExecuteNonQuery();
                    Log.Debug(commandText);
                    commandText = String.Format(CultureInfo.InvariantCulture,
                                                "DELETE FROM Shops WHERE Id='{0}'", id);
                    dbCommand.CommandText = commandText;
                    dbCommand.ExecuteNonQuery();
                    Log.Debug(commandText);
                }
            }
        }

        /// <summary>
        /// Deletes the shop item.
        /// </summary>
        /// <param name="id">The <see cref="ShopItem"/> id.</param>
        public void DeleteShopItem(Guid id)
        {
            Log.DebugFormat("DeleteShopItem: '{0}'", id);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                  "DELETE FROM ShopItems WHERE Id='{0}'", id);
                    dbCommand.CommandText = commandText;
                    dbCommand.ExecuteNonQuery();
                    Log.Debug(commandText);
                }
            }
        }

        /// <summary>
        /// Gets the item types.
        /// </summary>
        /// <returns></returns>
        public IList<ItemType> GetItemTypes()
        {
            Log.Debug("GetItemTypes");
            IList<ItemType> itemTypes = new List<ItemType>();
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    const string commandText = "SELECT * FROM ItemType";
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ItemType itemType = new ItemType
                                {
                                    Id = Int32.Parse(reader[0].ToString()),
                                    Name = reader[1].ToString(),
                                };
                            itemTypes.Add(itemType);
                            Log.InfoFormat("Adding ItemType [{0}]", itemType);
                        }
                    }
                }
            }
            return itemTypes;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The unique id of the item.</param>
        /// <returns><see cref="Item"/> if found; else <c>null</c></returns>
        public Item GetItem(Guid id)
        {
            Log.DebugFormat("GetItem. UniqueId='{0}'", id);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                  "SELECT * FROM Items WHERE UniqueId='{0}'", id);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item
                                {
                                    Id = reader[0].ToString(),
                                    UniqueId = new Guid(reader[1].ToString()),
                                    Name = reader[2].ToString(),
                                    Notes = reader[3].ToString(),
                                    ItemType = Int32.Parse(reader[4].ToString()),
                                };
                            Log.InfoFormat("Have Item [{0}]", item);
                            return item;
                        }
                    }
                }
            }
            Log.WarnFormat("Item with UniqueId='{0}' not found!", id);
            return null;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The id if the item.</param>
        /// <returns><see cref="Item"/> if found; else <c>null</c></returns>
        public Item GetItem(string id)
        {
            Log.DebugFormat("GetItem. Id='{0}'", id);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                  "SELECT * FROM Items WHERE Id='{0}'", id);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item
                                {
                                    Id = reader[0].ToString(),
                                    UniqueId = new Guid(reader[1].ToString()),
                                    Name = reader[2].ToString(),
                                    Notes = reader[3].ToString(),
                                    ItemType = Int32.Parse(reader[4].ToString()),
                                };
                            Log.InfoFormat("Have Item [{0}]", item);
                            return item;
                        }
                    }
                }
            }
            Log.WarnFormat("Item with Id='{0}' not found!", id);
            return null;
        }

        /// <summary>
        /// Gets the available items.
        /// </summary>
        /// <returns><see cref="DataSet"/></returns>
        public DataSet GetItems()
        {
            Log.Debug("GetItems");
            DataSet items = new DataSet();
            using (dbConnection)
            {
                dbConnection.Open();
                const string commandText =
                    "SELECT Id, Name, Notes, (Select Name from ItemType where ItemType.Id=Items.ItemType) AS ItemTypeName, UniqueId FROM Items";
                Log.Debug(commandText);
                DbDataAdapter dataAdapter = new SQLiteDataAdapter(commandText, dbConnection.ConnectionString);
                dataAdapter.Fill(items, Misc.DataTableNameOfItems);
                dbConnection.Close();
            }
            LogDataSet(items);
            return items;
        }

        /// <summary>
        /// Gets all items in specified shop.
        /// </summary>
        /// <param name="shopId">The shop id.</param>
        /// <returns></returns>
        public DataSet GetItemsInShop(Guid shopId)
        {
            Log.DebugFormat("GetItemsInShop. shopId='{0}'", shopId);
            DataSet shopItems = new DataSet();
            using (dbConnection)
            {
                dbConnection.Open();
                string commandText = String.Format(CultureInfo.InvariantCulture,
                                                   "SELECT DateTime, NumberOfItems, (SELECT Gross FROM Price WHERE Price.Id = ShopItems.Price) AS PriceGross, (SELECT Net FROM Price WHERE Price.Id = ShopItems.Price) AS PriceNet, (SELECT Name FROM Items WHERE Items.UniqueId = ShopItems.Item) AS Item, (SELECT Name FROM Shops WHERE Shops.Id = ShopItems.Shop) AS Shop, Price FROM ShopItems WHERE Shop='{0}'",
                                                   shopId);
                Log.Debug(commandText);
                DbDataAdapter dataAdapter = new SQLiteDataAdapter(commandText, dbConnection.ConnectionString);
                dataAdapter.Fill(shopItems, Misc.DataTableNameOfShopItems);
                dbConnection.Close();
            }
            LogDataSet(shopItems);
            return shopItems;
        }

        /// <summary>
        /// Gets the price for specified item in specified shop.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="shop">The shop.</param>
        /// <returns></returns>
        public Price GetPrice(Item item, Shop shop)
        {
            Log.DebugFormat("GetPrice. Item='{0}', Shop='{1}'", item, shop);
            Price price = null;
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                  "SELECT * FROM Price WHERE Item='{0}' AND Shop='{1}'",
                                                  item.UniqueId, shop.Id);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            price = new Price
                                {
                                    Gross = Double.Parse(reader[1].ToString()),
                                    Net = Double.Parse(reader[2].ToString()),
                                    Id = new Guid(reader[4].ToString()),
                                };
                            Log.InfoFormat("Price={0}", price);
                            break;
                        }
                    }
                }
            }
            Log.Warn("Price not found!");
            return price;
        }

        /// <summary>
        /// Gets all shop items.
        /// </summary>
        /// <returns></returns>
        public DataSet GetShopItems()
        {
            Log.Debug("GetShopItems");
            DataSet shopItems = new DataSet();
            using (dbConnection)
            {
                dbConnection.Open();
                const string commandText =
                    "SELECT DateTime, NumberOfItems, (SELECT Gross FROM Price WHERE Price.Id = ShopItems.Price) AS PriceGross, (SELECT Net FROM Price WHERE Price.Id = ShopItems.Price) AS PriceNet, (SELECT Name FROM Items WHERE Items.UniqueId = ShopItems.Item) AS Item, (SELECT Name FROM Shops WHERE Shops.Id = ShopItems.Shop) AS Shop, Price, Shop AS ShopId, Item AS ItemId, Id FROM ShopItems";
                Log.Debug(commandText);
                DbDataAdapter dataAdapter = new SQLiteDataAdapter(commandText, dbConnection.ConnectionString);
                dataAdapter.Fill(shopItems, Misc.DataTableNameOfShopItems);
                dbConnection.Close();
            }
            LogDataSet(shopItems);
            return shopItems;
        }

        /// <summary>
        /// Gets the shop.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><c>null</c> if not found.</returns>
        public Shop GetShop(string id)
        {
            Log.DebugFormat("GetShop with id='{0}'", id);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                  "SELECT * FROM Shops WHERE Id='{0}'", id);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
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
                            Log.InfoFormat("Found shop: [{0}]", shop);
                            return shop;
                        }
                    }
                }
            }
            Log.WarnFormat("Shop with id={0} not found!", id);
            return null;
        }

        /// <summary>
        /// Gets the shop.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>null</c> if not found.</returns>
        public Shop GetShopByName(string name)
        {
            Log.DebugFormat("GetShopByName with name='{0}'", name);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                  "SELECT * FROM Shops WHERE Name='{0}'", name);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
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
                            Log.InfoFormat("Found shop: [{0}]", shop);
                            return shop;
                        }
                    }
                }
            }
            Log.WarnFormat("Shop with name={0} not found!", name);
            return null;
        }

        /// <summary>
        /// Gets the available shops.
        /// </summary>
        /// <returns><see cref="DataSet"/></returns>
        public DataSet GetShops()
        {
            Log.Debug("GetShops");
            DataSet shops = new DataSet();
            using (dbConnection)
            {
                dbConnection.Open();
                const string commandText = "SELECT Name, Address, Owner, PostalCode, City, IsCompany, Id FROM Shops";
                Log.Debug(commandText);
                DbDataAdapter dataAdapter = new SQLiteDataAdapter(commandText, dbConnection.ConnectionString);
                dataAdapter.Fill(shops, Misc.DataTableNameOfShops);
                dbConnection.Close();
            }
            LogDataSet(shops);
            return shops;
        }

        /// <summary>
        /// Gets the tracker for specified shop item.
        /// </summary>
        /// <param name="shopItemId">The shop item id.</param>
        /// <returns></returns>
        public DataSet GetTrackers(Guid shopItemId)
        {
            Log.DebugFormat("GetTrackers for shopItemId='{0}'", shopItemId);
            DataSet trackers = new DataSet();
            using (dbConnection)
            {
                dbConnection.Open();
                string commandText = String.Format(CultureInfo.InvariantCulture,
                                                   "SELECT DateTime, SoldCount FROM Tracker WHERE ShopItem='{0}'",
                                                   shopItemId);
                Log.Debug(commandText);
                DbDataAdapter dataAdapter = new SQLiteDataAdapter(commandText, dbConnection.ConnectionString);
                dataAdapter.Fill(trackers, Misc.DataTableNameOfTrackers);
                dbConnection.Close();
            }
            LogDataSet(trackers);
            return trackers;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            Log.DebugFormat("GetUser '{0}'", username);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                  "SELECT * FROM Users WHERE Name='{0}'", username);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
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
                            Log.DebugFormat("Have user : [{0}]", user);
                            return user;
                        }
                    }
                }
            }
            Log.WarnFormat("User '{0}' not found!", username);
            return null;
        }

        /// <summary>
        /// Gets the list of users.
        /// </summary>
        /// <returns><see cref="IList{T}"/></returns>
        public IList<User> GetUsers()
        {
            Log.Debug("GetUsers");
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
                    const string commandText = "SELECT * FROM Users";
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
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
                            Log.DebugFormat("Adding user : [{0}]", user);
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
            Log.DebugFormat("InsertItem '{0}'", item);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Items (Id, UniqueId, Name, Notes, ItemType) VALUES('{0}', '{1}', '{2}', '{3}', {4})",
                                                       item.Id, item.UniqueId, item.Name, item.Notes,
                                                       item.ItemType);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    Log.ErrorFormat("Failed to insert item [{0}]", item);
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserts new item type.
        /// </summary>
        /// <param name="itemType">The item type.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool InsertItemType(ItemType itemType)
        {
            Log.DebugFormat("InsertItemType '{0}'", itemType);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO ItemType (Name) VALUES('{0}')",
                                                       itemType.Name);
                    Log.Debug(commandText);
                    dbCommand.CommandText = commandText;
                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    Log.ErrorFormat("Failed to insert itemType [{0}]", itemType);
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserts the price for specified item in shop.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool InsertPrice(Price price)
        {
            Log.DebugFormat("InsertPrice '{0}'", price);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Price (Item, Gross, Net, Shop, Id) VALUES('{0}', {1}, {2}, '{3}', '{4}')",
                                                       price.ItemId, price.Gross, price.Net, price.ShopId, price.Id);
                    Log.Debug(commandText);
                    dbCommand.CommandText = commandText;
                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    Log.ErrorFormat("Failed to insert price [{0}]", price);
                    return false;
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
            Log.DebugFormat("InsertShop '{0}'", shop);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string guid = shop.Id.ToString();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Shops (Id, Name, Address, Owner, PostalCode, City, IsCompany) VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}', {6})",
                                                       guid, shop.Name, shop.Address, shop.Owner, shop.PostalCode,
                                                       shop.City, shop.IsCompany ? 1 : 0);
                    Log.Debug(commandText);
                    dbCommand.CommandText = commandText;
                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    Log.ErrorFormat("Failed to insert shop [{0}]", shop);
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserts the shop item.
        /// </summary>
        /// <param name="shopItem">The shop item.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool InsertShopItem(ShopItem shopItem)
        {
            Log.DebugFormat("InsertShopItem '{0}'", shopItem);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO ShopItems (Item, Shop, DateTime, Price, NumberOfItems, Id) VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}')",
                                                       shopItem.ItemId, shopItem.ShopId,
                                                       shopItem.DateTime.ToString(DateTimeFormatProvider),
                                                       shopItem.PriceId, shopItem.NumberOfItems, shopItem.Id);
                    Log.Debug(commandText);
                    dbCommand.CommandText = commandText;
                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    Log.ErrorFormat("Failed to insert shopItem [{0}]", shopItem);
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserts the tracker.
        /// </summary>
        /// <param name="tracker">The tracker.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool InsertTracker(Tracker tracker)
        {
            Log.DebugFormat("InsertTracker '{0}'", tracker);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Tracker (Id, ShopItem, DateTime, SoldCount) VALUES('{0}', '{1}', '{2}', {3})",
                                                       tracker.Id, tracker.ShopItemId,
                                                       tracker.DateTime.ToString(DateTimeFormatProvider),
                                                       tracker.SoldCount);
                    Log.Debug(commandText);
                    dbCommand.CommandText = commandText;
                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    Log.ErrorFormat("Failed to insert tracker [{0}]", tracker);
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool InsertUser(User user)
        {
            Log.DebugFormat("InsertUser '{0}'", user);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Users (Name, Password, Level) VALUES('{0}', '{1}', {2})",
                                                       user.Name, user.Password, user.Level);
                    Log.Debug(commandText);
                    dbCommand.CommandText = commandText;
                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    Log.ErrorFormat("Failed to insert user [{0}]", user);
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates existing item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool UpdateItem(Item item)
        {
            Log.DebugFormat("UpdateItem '{0}'", item);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "UPDATE Items SET Id='{0}', Name='{1}', Notes='{2}', ItemType={3} WHERE UniqueId='{4}'",
                                                       item.Id, item.Name, item.Notes,
                                                       item.ItemType, item.UniqueId);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    Log.ErrorFormat("Failed to update item [{0}]", item);
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates the existing shop.
        /// </summary>
        /// <param name="shop">The shop.</param>
        public bool UpdateShop(Shop shop)
        {
            Log.DebugFormat("UpdateShop '{0}'", shop);
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "UPDATE Shops SET Name='{1}', Address='{2}', Owner='{3}', PostalCode='{4}', City='{5}', IsCompany={6} WHERE Id='{0}'",
                                                       shop.Id, shop.Name, shop.Address, shop.Owner, shop.PostalCode,
                                                       shop.City, shop.IsCompany ? 1 : 0);
                    dbCommand.CommandText = commandText;
                    Log.Debug(commandText);
                    if (dbCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    Log.ErrorFormat("Failed to update shop [{0}]", shop);
                    return false;
                }
            }
        }

        private static void LogDataSet(DataSet dataSet)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                StringBuilder sb = new StringBuilder();
                foreach (object itemArray in row.ItemArray)
                {
                    sb.AppendFormat("[{0}] ", itemArray);
                }
                Log.DebugFormat("Row: {0}", sb.ToString());
            }
        }

        private readonly string dbConnectionString;
        private readonly DbConnection dbConnection;
        private const string DateTimeFormatProvider = "yyyy-MM-dd HH:mm:ss";
    }
}