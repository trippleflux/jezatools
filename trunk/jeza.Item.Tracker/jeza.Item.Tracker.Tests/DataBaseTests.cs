using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jeza.Item.Tracker.Tests
{
    [TestClass]
    public class DataBaseTests
    {
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
            int rowsInserted = dataBase.InsertItem(item);
            Assert.AreEqual(1, rowsInserted);
            List<Item> items = dataBase.GetItems();
            Assert.IsNotNull(items);
            Item find = items.Find(i => i.Name == name);
            Assert.IsNotNull(find);
        }

        [TestMethod]
        public void InsertItemWitPicture()
        {
            DataBase dataBase = new DataBase();
            string name = Guid.NewGuid().ToString();
            const string imagePath = "D:\\svn\\jezatools\\trunk\\jeza.Item.Tracker\\jeza.Item.Tracker.Tests\\Untitled.png";
            byte[] imageData = Misc.GetImageData(imagePath);
            Item item = new Item
            {
                Name = name,
                Description = Guid.NewGuid().ToString(),
                ItemTypeId = 0,
                Image = imageData,
            };
            int rowsInserted = dataBase.InsertItem(item);
            Assert.AreEqual(1, rowsInserted);
            List<Item> items = dataBase.GetItems();
            Assert.IsNotNull(items);
            Item find = items.Find(i => i.Name == name);
            Assert.IsNotNull(find);
            Assert.AreEqual(imageData.Length, find.Image.Length, "Wrong Image!");
        }
    }
}