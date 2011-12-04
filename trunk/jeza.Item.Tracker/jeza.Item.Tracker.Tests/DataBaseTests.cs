using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jeza.Item.Tracker.Tests
{
    [TestClass]
    public class DataBaseTests
    {
        [TestMethod]
        public void GetItemNonExisting()
        {
            DataBase dataBase = new DataBase();
            Item item = dataBase.ItemGet(-1);
            Assert.IsNull(item);
        }

        [TestMethod]
        public void GetItemByType()
        {
            DataBase dataBase = new DataBase();
            string itemTypeName1 = Guid.NewGuid().ToString();
            string itemTypeName2 = Guid.NewGuid().ToString();
            string itemTypeName3 = Guid.NewGuid().ToString();
            int rowsInserted =
                dataBase.ItemTypeInsert(new ItemType {Name = itemTypeName1, Description = "item type description 1",});
            Assert.AreEqual(1, rowsInserted);
            rowsInserted =
                dataBase.ItemTypeInsert(new ItemType {Name = itemTypeName2, Description = "item type description 2",});
            Assert.AreEqual(1, rowsInserted);
            rowsInserted =
                dataBase.ItemTypeInsert(new ItemType {Name = itemTypeName3, Description = "item type description 3",});
            Assert.AreEqual(1, rowsInserted);
            List<ItemType> itemTypes = dataBase.ItemTypeGetAll();
            string itemName1 = Guid.NewGuid().ToString();
            string itemName2 = Guid.NewGuid().ToString();
            string itemName3 = Guid.NewGuid().ToString();

            int itemTypeId1 = itemTypes.Find(n => n.Name == itemTypeName1).Id;
            int itemTypeId2 = itemTypes.Find(n => n.Name == itemTypeName2).Id;
            int itemTypeId3 = itemTypes.Find(n => n.Name == itemTypeName3).Id;
            rowsInserted =
                dataBase.ItemInsert(new Item
                                    {
                                        Name = itemName1,
                                        Description = "item description 1",
                                        ItemTypeId = itemTypeId1,
                                    });
            Assert.AreEqual(1, rowsInserted);
            rowsInserted =
                dataBase.ItemInsert(new Item
                                    {
                                        Name = itemName2,
                                        Description = "item description 2",
                                        ItemTypeId = itemTypeId2,
                                    });
            Assert.AreEqual(1, rowsInserted);
            rowsInserted =
                dataBase.ItemInsert(new Item
                                    {
                                        Name = itemName3,
                                        Description = "item description 3",
                                        ItemTypeId = itemTypeId2,
                                    });
            Assert.AreEqual(1, rowsInserted);
            List<Item> items = dataBase.ItemGetByType(itemTypeId1);
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count == 1, "Expected: {0}, Actual:{1}", 1, items.Count);
            items = dataBase.ItemGetByType(itemTypeId2);
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count == 2, "Expected: {0}, Actual:{1}", 2, items.Count);
            items = dataBase.ItemGetByType(itemTypeId3);
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count == 0, "Expected: {0}, Actual:{1}", 0, items.Count);
        }

        [TestMethod]
        public void GetPersonInfoNonExisting()
        {
            DataBase dataBase = new DataBase();
            PersonInfo personInfo = dataBase.PersonInfoGet(-1);
            Assert.IsNull(personInfo);
        }

        [TestMethod]
        public void InsertPersonOnlyName()
        {
            DataBase dataBase = new DataBase();
            string name = Guid.NewGuid().ToString();
            PersonInfo personInfo = new PersonInfo {Name = name};
            int rowsInserted = dataBase.PersonInfoInsert(personInfo);
            Assert.AreEqual(1, rowsInserted, "Person not inserted!");
            List<PersonInfo> list = dataBase.PersonInfoGetAll();
            Assert.IsNotNull(list, "At least one person info was expected!");
            PersonInfo info = list.Find(p => p.Name == name);
            Assert.AreEqual(name, info.Name, "PersonInfo not found! '{0}'", name);
        }

        [TestMethod]
        public void DeletePersonOnlyName()
        {
            DataBase dataBase = new DataBase();
            string name = Guid.NewGuid().ToString();
            PersonInfo personInfo = new PersonInfo {Name = name};
            int rowsInserted = dataBase.PersonInfoInsert(personInfo);
            Assert.AreEqual(1, rowsInserted, "Person not inserted!");
            List<PersonInfo> list = dataBase.PersonInfoGetAll();
            Assert.IsNotNull(list, "At least one person info was expected!");
            PersonInfo info = list.Find(p => p.Name == name);
            Assert.AreEqual(name, info.Name, "PersonInfo not found! '{0}'", name);
            int rowsDeleted = dataBase.PersonInfoDelete(info.Id);
            Assert.AreEqual(1, rowsDeleted, "Person not deleted!");
        }

        [TestMethod]
        public void InsertPersonAll()
        {
            DataBase dataBase = new DataBase();
            string name = Guid.NewGuid().ToString();
            PersonInfo personInfo = new PersonInfo
                                    {
                                        Name = name,
                                        SurName = "surname",
                                        NickName = "nickname",
                                        Description = "description",
                                        Address = "adddress",
                                        PostNumber = 123,
                                        City = "city",
                                        Email = "email@dot.com",
                                        Telephone = "00386 2 876 1234",
                                        TelephoneMobile = "++386 40 123 456",
                                        Fax = "+386 2 8761 211"
                                    };
            int rowsInserted = dataBase.PersonInfoInsert(personInfo);
            Assert.AreEqual(1, rowsInserted, "Person not inserted!");
        }

        [TestMethod]
        public void InsertItemType()
        {
            DataBase dataBase = new DataBase();
            string itemTypeName = Guid.NewGuid().ToString();
            ItemType itemType = new ItemType {Name = itemTypeName, Description = "hula bula...",};
            int rowsInserted = dataBase.ItemTypeInsert(itemType);
            Assert.AreEqual(1, rowsInserted, "Item type not inserted!");
        }

        [TestMethod]
        public void InsertItemStatus()
        {
            DataBase dataBase = new DataBase();
            string itemStatusName = Guid.NewGuid().ToString();
            ItemStatus itemStatus = new ItemStatus {Name = itemStatusName, Description = "Description",};
            int rowsInserted = dataBase.ItemStatusInsert(itemStatus);
            Assert.AreEqual(1, rowsInserted, "Item status not inserted!");
        }

        [TestMethod]
        public void InsertItem()
        {
            DataBase dataBase = new DataBase();
            string name = Guid.NewGuid().ToString();
            Item item = new Item
                        {
                            Name = name,
                            Description = Guid.NewGuid().ToString(),
                            ItemTypeId = 0,
                            Image = new byte[] {1, 2, 3, 4, 5},
                        };
            int rowsInserted = dataBase.ItemInsert(item);
            Assert.AreEqual(1, rowsInserted);
            List<Item> items = dataBase.ItemGetAll(@"SELECT Id, Name, Description, ItemType, Image FROM Item");
            Assert.IsNotNull(items);
            Item find = items.Find(i => i.Name == name);
            Assert.IsNotNull(find);
        }

        [TestMethod]
        public void UpdateItem()
        {
            DataBase dataBase = new DataBase();
            string name = Guid.NewGuid().ToString();
            Item item = new Item
                        {
                            Name = name,
                            Description = Guid.NewGuid().ToString(),
                            ItemTypeId = 0,
                            Image = new byte[] {1, 2, 3, 4, 5},
                        };
            int rowsInserted = dataBase.ItemInsert(item);
            Assert.AreEqual(1, rowsInserted);
            List<Item> items = dataBase.ItemGetAll(@"SELECT Id, Name, Description, ItemType, Image FROM Item");
            Assert.IsNotNull(items);
            Item find = items.Find(i => i.Name == name);
            Assert.IsNotNull(find);
            string newName = Guid.NewGuid().ToString();
            find.Name = newName;
            int rowsUpdated = dataBase.ItemUpdate(find);
            Assert.AreEqual(1, rowsUpdated);
            Item updatedItem = dataBase.ItemGet(find.Id);
            Assert.AreEqual(newName, updatedItem.Name);
            Assert.AreEqual(item.Description, updatedItem.Description);
            Assert.AreEqual(item.ItemTypeId, updatedItem.ItemTypeId);
        }

        [TestMethod]
        public void UpdateItemStatus()
        {
            DataBase dataBase = new DataBase();
            string name = Guid.NewGuid().ToString();
            ItemStatus itemStatus = new ItemStatus
                                    {
                                        Name = name,
                                        Description = Guid.NewGuid().ToString(),
                                    };
            int rowsInserted = dataBase.ItemStatusInsert(itemStatus);
            Assert.AreEqual(1, rowsInserted);
            List<ItemStatus> list = dataBase.ItemStatusGetAll();
            Assert.IsNotNull(list);
            ItemStatus find = list.Find(i => i.Name == name);
            Assert.IsNotNull(find);
            string newName = Guid.NewGuid().ToString();
            find.Name = newName;
            int rowsUpdated = dataBase.ItemStatusUpdate(find);
            Assert.AreEqual(1, rowsUpdated);
            ItemStatus updatedItemStatus = dataBase.ItemStatusGet(find.Id);
            Assert.AreEqual(newName, updatedItemStatus.Name);
            Assert.AreEqual(itemStatus.Description, updatedItemStatus.Description);
        }

        [TestMethod]
        public void UpdateItemType()
        {
            DataBase dataBase = new DataBase();
            string itemTypeName = Guid.NewGuid().ToString();
            ItemType itemType = new ItemType {Name = itemTypeName, Description = "hula bula...",};
            int rowsInserted = dataBase.ItemTypeInsert(itemType);
            Assert.AreEqual(1, rowsInserted, "Item type not inserted!");
            List<ItemType> list = dataBase.ItemTypeGetAll();
            Assert.IsNotNull(list);
            ItemType find = list.Find(i => i.Name == itemTypeName);
            Assert.IsNotNull(find);
            string newName = Guid.NewGuid().ToString();
            find.Name = newName;
            int rowsUpdated = dataBase.ItemTypeUpdate(find);
            Assert.AreEqual(1, rowsUpdated);
            ItemType updatedItemType = dataBase.ItemTypeGet(find.Id);
            Assert.AreEqual(newName, updatedItemType.Name);
            Assert.AreEqual(itemType.Description, updatedItemType.Description);
        }

        [TestMethod]
        public void UpdatePersonInfo()
        {
            DataBase dataBase = new DataBase();
            string name = Guid.NewGuid().ToString();
            PersonInfo personInfo = new PersonInfo
                                    {
                                        Name = name,
                                        SurName = "surname",
                                        NickName = "nickname",
                                        Description = "description",
                                        Address = "adddress",
                                        PostNumber = 123,
                                        City = "city",
                                        Email = "email@dot.com",
                                        Telephone = "00386 2 876 1234",
                                        TelephoneMobile = "++386 40 123 456",
                                        Fax = "+386 2 8761 211"
                                    };
            int rowsInserted = dataBase.PersonInfoInsert(personInfo);
            Assert.AreEqual(1, rowsInserted, "Person not inserted!");
            List<PersonInfo> list = dataBase.PersonInfoGetAll();
            Assert.IsNotNull(list);
            PersonInfo find = list.Find(p => p.Name == name);
            Assert.IsNotNull(find);
            string newName = Guid.NewGuid().ToString();
            find.Name = newName;
            int rowsUpdated = dataBase.PersonInfoUpdate(find);
            Assert.AreEqual(1, rowsUpdated);
            PersonInfo updatedPersonInfo = dataBase.PersonInfoGet(find.Id);
            Assert.AreEqual(newName, updatedPersonInfo.Name);
            Assert.AreEqual(personInfo.SurName, updatedPersonInfo.SurName);
            Assert.AreEqual(personInfo.NickName, updatedPersonInfo.NickName);
            Assert.AreEqual(personInfo.Description, updatedPersonInfo.Description);
            Assert.AreEqual(personInfo.Address, updatedPersonInfo.Address);
            Assert.AreEqual(personInfo.PostNumber, updatedPersonInfo.PostNumber);
            Assert.AreEqual(personInfo.City, updatedPersonInfo.City);
            Assert.AreEqual(personInfo.Email, updatedPersonInfo.Email);
            Assert.AreEqual(personInfo.Telephone, updatedPersonInfo.Telephone);
            Assert.AreEqual(personInfo.TelephoneMobile, updatedPersonInfo.TelephoneMobile);
            Assert.AreEqual(personInfo.Fax, updatedPersonInfo.Fax);
        }

        [TestMethod]
        public void InsertItemWitPicture()
        {
            DataBase dataBase = new DataBase();
            string name = Guid.NewGuid().ToString();
            string[] directories = Directory.GetDirectories("..\\..\\..\\..\\");
            string imagePath = Path.Combine(directories[0], "Untitled.png");
            byte[] imageData = Misc.GetImageData(imagePath);
            Assert.IsNotNull(imageData, "No image '{0}'!", imagePath);
            Item item = new Item
                        {
                            Name = name,
                            Description = Guid.NewGuid().ToString(),
                            ItemTypeId = 0,
                            Image = imageData,
                        };
            int rowsInserted = dataBase.ItemInsert(item);
            Assert.AreEqual(1, rowsInserted);
            List<Item> items = dataBase.ItemGetAll(@"SELECT Id, Name, Description, ItemType, Image FROM Item");
            Assert.IsNotNull(items, "Ites is null");
            Item find = items.Find(i => i.Name == name);
            Assert.IsNotNull(find, "Item {0} not found!", name);
            Assert.AreEqual(imageData.Length, find.Image.Length, "Wrong Image!");
        }
    }
}