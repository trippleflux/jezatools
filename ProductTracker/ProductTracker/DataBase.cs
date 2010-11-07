#region

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        /// Deletes all item types.
        /// </summary>
        public void DeleteAllItemTypes()
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = "DELETE FROM ItemType";
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
        /// Deletes the item.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteItem(string id)
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "DELETE FROM Price WHERE Item='{0}'", id);
                    dbCommand.ExecuteNonQuery();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "DELETE FROM ShopItems WHERE Item='{0}'", id);
                    dbCommand.ExecuteNonQuery();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "DELETE FROM Items WHERE UniqueId='{0}'", id);
                    dbCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes the specified shop.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteShop(string id)
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "DELETE FROM Price WHERE Shop='{0}'", id);
                    dbCommand.ExecuteNonQuery();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "DELETE FROM ShopItems WHERE Shop='{0}'", id);
                    dbCommand.ExecuteNonQuery();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "DELETE FROM Shops WHERE Id='{0}'", id);
                    dbCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets the item types.
        /// </summary>
        /// <returns></returns>
        public IList<ItemType> GetItemTypes()
        {
            IList<ItemType> itemTypes = new List<ItemType>();
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = "SELECT * FROM ItemType";
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
                        }
                    }
                }
            }
            return itemTypes;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="Item"/> if found; else <c>null</c></returns>
        public Item GetItem(Guid value)
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "SELECT * FROM Items WHERE UniqueId='{0}'", value);
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
                            return item;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the available items.
        /// </summary>
        /// <returns><see cref="DataSet"/></returns>
        public DataSet GetItems()
        {
            DataSet items = new DataSet();
            using (dbConnection)
            {
                dbConnection.Open();
                const string commandText = "SELECT Id, Name, Notes, (Select Name from ItemType where ItemType.Id=Items.ItemType) AS ItemTypeName FROM Items";
                DbDataAdapter dataAdapter = new SQLiteDataAdapter(commandText, dbConnection.ConnectionString);
                dataAdapter.Fill(items, Misc.DataTableNameOfItems);
                dbConnection.Close();
            }
            return items;
        }

        /// <summary>
        /// Gets the price for specified item in specified shop.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="shop">The shop.</param>
        /// <returns></returns>
        public Price GetPrice(Item item, Shop shop)
        {
            Price price = null;
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "SELECT * FROM Price WHERE Item='{0}' AND Shop='{1}'",
                                                          item.UniqueId, shop.Id);
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
                            break;
                        }
                    }
                }
            }
            return price;
        }

        /// <summary>
        /// Gets the shop item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="shop">The shop.</param>
        /// <returns></returns>
        public ShopItem GetShopItem(Item item, Shop shop)
        {
            ShopItem shopItem = null;
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "SELECT * FROM ShopItems WHERE Item='{0}' AND Shop='{1}'",
                                                          item.UniqueId, shop.Id);
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shopItem = new ShopItem
                                {
                                    Item = item,
                                    ItemId = new Guid(reader[0].ToString()),
                                    Shop = shop,
                                    ShopId = new Guid(reader[1].ToString()),
                                    DateTime = DateTime.Parse(reader[2].ToString(), CultureInfo.InvariantCulture),
                                    PriceId = new Guid(reader[3].ToString()),
                                    NumberOfItems = Int32.Parse(reader[4].ToString()),
                                    Id = new Guid(reader[5].ToString()),
                                };
                            break;
                        }
                    }
                }
            }
            return shopItem;
        }

        /// <summary>
        /// Gets all shop items.
        /// </summary>
        /// <returns></returns>
        public List<ShopItem> GetShopItems()
        {
            List<ShopItem> shopItems = new List<ShopItem>();
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = "SELECT * FROM ShopItems";
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ShopItem shopItem = new ShopItem
                            {
                                ItemId = new Guid(reader[0].ToString()),
                                ShopId = new Guid(reader[1].ToString()),
                                DateTime = DateTime.Parse(reader[2].ToString(), CultureInfo.InvariantCulture),
                                PriceId = new Guid(reader[3].ToString()),
                                NumberOfItems = Int32.Parse(reader[4].ToString()),
                                Id = new Guid(reader[5].ToString()),
                            };
                            shopItems.Add(shopItem);
                        }
                    }
                }
            }
            return shopItems;
        }

        /// <summary>
        /// Gets the shop.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><c>null</c> if not found.</returns>
        public Shop GetShop(string id)
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "SELECT * FROM Shops WHERE Id='{0}'", id);
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
                            return shop;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the available shops.
        /// </summary>
        /// <returns><see cref="DataSet"/></returns>
        public DataSet GetShops()
        {
            DataSet shops = new DataSet();
            using (dbConnection)
            {
                dbConnection.Open();
                const string commandText = "SELECT Name, Address, Owner, PostalCode, City, IsCompany FROM Shops";
                DbDataAdapter dataAdapter = new SQLiteDataAdapter(commandText, dbConnection.ConnectionString);
                dataAdapter.Fill(shops, Misc.DataTableNameOfShops);
                dbConnection.Close();
            }
            return shops;
        }

        /// <summary>
        /// Gets the tracker for specified shop item.
        /// </summary>
        /// <param name="shopItem">The shop item.</param>
        /// <returns></returns>
        public IList<Tracker> GetTrackers(ShopItem shopItem)
        {
            IList<Tracker> trackers = new List<Tracker>();
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "SELECT * FROM Tracker WHERE ShopItem='{0}'", shopItem.Id);
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tracker tracker = new Tracker
                                {
                                    Id = new Guid(reader[0].ToString()),
                                    ShopItemId = new Guid(reader[1].ToString()),
                                    DateTime = DateTime.Parse(reader[2].ToString(), CultureInfo.InvariantCulture),
                                    SoldCount = Int32.Parse(reader[3].ToString()),
                                };
                            trackers.Add(tracker);
                        }
                    }
                }
            }
            return trackers;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    dbCommand.CommandText = String.Format(CultureInfo.InvariantCulture,
                                                          "SELECT * FROM Users WHERE Name='{0}'", username);
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new User
                                {
                                    Id = Int32.Parse(reader[0].ToString()),
                                    Name = reader[1].ToString(),
                                    Password = reader[2].ToString(),
                                    Level = Int32.Parse(reader[3].ToString())
                                };
                        }
                    }
                }
            }
            return null;
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
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Items (Id, UniqueId, Name, Notes, ItemType) VALUES('{0}', '{1}', '{2}', '{3}', {4})",
                                                       item.Id, item.UniqueId, item.Name, item.Notes,
                                                       item.ItemType);
                    dbCommand.CommandText = commandText;
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
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
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO ItemType (Name) VALUES('{0}')",
                                                       itemType.Name);
                    dbCommand.CommandText = commandText;
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
                }
            }
        }

        /// <summary>
        /// Inserts the price for specified item in shop.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="shop">The shop.</param>
        /// <param name="price">The price.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool InsertPrice(Item item, Shop shop, Price price)
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Price (Item, Gross, Net, Shop, Id) VALUES('{0}', {1}, {2}, '{3}', '{4}')",
                                                       item.UniqueId, price.Gross, price.Net, shop.Id, price.Id);
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

        /// <summary>
        /// Inserts the shop item.
        /// </summary>
        /// <param name="shopItem">The shop item.</param>
        /// <returns><c>true</c> on success.</returns>
        public bool InsertShopItem(ShopItem shopItem)
        {
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO ShopItems (Item, Shop, DateTime, Price, NumberOfItems, Id) VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}')",
                                                       shopItem.Item.UniqueId, shopItem.Shop.Id,
                                                       shopItem.DateTime.ToString(DateTimeFormatProvider),
                                                       shopItem.Price.Id, shopItem.NumberOfItems, shopItem.Id);
                    dbCommand.CommandText = commandText;
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
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
                    dbCommand.CommandText = commandText;
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
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
            using (dbConnection)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string commandText = String.Format(CultureInfo.InvariantCulture,
                                                       "INSERT INTO Users (Name, Password, Level) VALUES('{0}', '{1}', {2})",
                                                       user.Name, user.Password, user.Level);
                    dbCommand.CommandText = commandText;
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
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
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
                }
            }
        }

        /// <summary>
        /// Updates the existing shop.
        /// </summary>
        /// <param name="shop">The shop.</param>
        public bool UpdateShop(Shop shop)
        {
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
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
                }
            }
        }

        private readonly string dbConnectionString;
        private readonly DbConnection dbConnection;
        private const string DateTimeFormatProvider = "yyyy-MM-dd HH:mm:ss";
    }
}