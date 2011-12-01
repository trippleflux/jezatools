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
        public void GetPersonInfoNonExisting()
        {
            DataBase dataBase = new DataBase();
            PersonInfo personInfo = dataBase.PersonInfoGet(-1);
            Assert.IsNull(personInfo);
        }

        [TestMethod]
        public void InsertIPersonOnlyName()
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
        public void InsertIPersonAll()
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
            List<Item> items = dataBase.ItemGetAll();
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
            List<Item> items = dataBase.ItemGetAll();
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
            List<Item> items = dataBase.ItemGetAll();
            Assert.IsNotNull(items, "Ites is null");
            Item find = items.Find(i => i.Name == name);
            Assert.IsNotNull(find, "Item {0} not found!", name);
            Assert.AreEqual(imageData.Length, find.Image.Length, "Wrong Image!");
        }
    }
}