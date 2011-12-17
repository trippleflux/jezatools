using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace jeza.Item.Tracker.Tests
{
    [TestFixture]
    public class OrdersTest
    {
        [Test]
        public void OrderInsert()
        {
            DataBase dataBase = new DataBase();

            Order order = new Order
                          {
                              ItemId = 1,
                              Count = 1,
                              ItemStatusId = 1,
                              LegalEntity = true,
                              PersonInfoId = 1,
                              Postage = 0M.DecimalToString(),
                              Price = 1M.DecimalToString(),
                          };
            int rowsInserted = dataBase.OrderInsert(order);
            Assert.AreEqual(1, rowsInserted);
        }

        [Test]
        public void OrderUpdate()
        {
            DataBase dataBase = new DataBase();

            Order order = new Order
                          {
                              ItemId = 555,
                              Count = 1,
                              ItemStatusId = 1,
                              LegalEntity = true,
                              PersonInfoId = 1,
                              Postage = 0M.DecimalToString(),
                              Price = 1M.DecimalToString(),
                          };
            int rowsInserted = dataBase.OrderInsert(order);
            Assert.AreEqual(1, rowsInserted);
            List<Order> list = dataBase.OrderGetByItemId(555);
            Assert.IsNotNull(list);
            Assert.AreEqual(555, list[0].ItemId);
            order.ItemId = 666;
            order.Id = list[0].Id;
            int rowsUpdated = dataBase.OrderUpdate(order);
            Assert.AreEqual(1, rowsUpdated);
            list = dataBase.OrderGetByItemId(666);
            Assert.IsNotNull(list);
            Assert.AreEqual(666, list[0].ItemId);
        }

        [Test]
        public void OrderDelete()
        {
            DataBase dataBase = new DataBase();

            Order order = new Order
                          {
                              ItemId = 555,
                              Count = 1,
                              ItemStatusId = 1,
                              LegalEntity = true,
                              PersonInfoId = 1,
                              Postage = 0M.DecimalToString(),
                              Price = 1M.DecimalToString(),
                          };
            int rowsInserted = dataBase.OrderInsert(order);
            Assert.AreEqual(1, rowsInserted);
            List<Order> list = dataBase.OrderGetByItemId(555);
            Assert.IsNotNull(list);
            Assert.AreEqual(555, list[0].ItemId);
            int rowsDeleted = dataBase.OrderDelete(list[0].Id);
            Assert.AreEqual(1, rowsDeleted);
            list = dataBase.OrderGetByItemId(555);
            Assert.IsNull(list);
        }

        [Test]
        public void OrderGetAll()
        {
            DataBase dataBase = new DataBase();
            string itemTypeName = Guid.NewGuid().ToString();
            ItemType itemType = new ItemType {Name = itemTypeName,};
            dataBase.ItemTypeInsert(itemType);
            ItemType itemTypeGet = dataBase.ItemTypeGet(itemTypeName);
            Assert.IsNotNull(itemTypeGet);
            string itemName = Guid.NewGuid().ToString();
            Item item = new Item
                        {
                            Name = itemName,
                            ItemTypeId = itemTypeGet.Id,
                        };
            dataBase.ItemInsert(item);
            Item itemGet = dataBase.ItemGet(itemName);
            Assert.IsNotNull(itemGet);
            string itemStatusName = Guid.NewGuid().ToString();
            ItemStatus itemStatus = new ItemStatus {Name = itemStatusName};
            dataBase.ItemStatusInsert(itemStatus);
            ItemStatus itemStatusGet = dataBase.ItemStatusGet(itemStatusName);
            Assert.IsNotNull(itemStatusGet);
            string personInfoName = Guid.NewGuid().ToString();
            string personInfoSurName = Guid.NewGuid().ToString();
            PersonInfo personInfo = new PersonInfo {Name = personInfoName, SurName = personInfoSurName,};
            dataBase.PersonInfoInsert(personInfo);
            PersonInfo personInfoGet = dataBase.PersonInfoGet(personInfoName, personInfoSurName);
            Assert.IsNotNull(personInfoGet);
            Order order = new Order
                          {
                              ItemId = itemGet.Id,
                              Count = 1,
                              ItemStatusId = itemStatusGet.Id,
                              LegalEntity = true,
                              PersonInfoId = personInfoGet.Id,
                              Postage = 0M.DecimalToString(),
                              Price = 1M.DecimalToString(),
                              BankId = -1,
                          };
            int rowsInserted = dataBase.OrderInsert(order);
            Assert.AreEqual(1, rowsInserted);
            List<Order> orders = dataBase.OrderGetAll();
            Assert.IsNotNull(orders);
            Order find = orders.Find(o => o.ItemId == itemGet.Id);
            Assert.IsNotNull(find);
        }

        [Test]
        public void OrderGetById()
        {
            DataBase dataBase = new DataBase();
            List<Order> orderGetByItemId = dataBase.OrderGetByItemId(1);
            int rowsInserted = dataBase.OrderInsert(new Order
                                                    {
                                                        ItemId = 1,
                                                        Count = 1,
                                                        ItemStatusId = 1,
                                                        LegalEntity = true,
                                                        PersonInfoId = 1,
                                                        Postage = 0M.DecimalToString(),
                                                        Price = 1.00M.DecimalToString(),
                                                    });
            Assert.AreEqual(1, rowsInserted);
            List<Order> orders = dataBase.OrderGetByItemId(1);
            Assert.IsNotNull(orders);
            Assert.AreEqual(orderGetByItemId == null ? 1 : orderGetByItemId.Count + 1, orders.Count);
        }

        [Test]
        public void OrderGetByItemId()
        {
            DataBase dataBase = new DataBase();
            const int itemId = 1;
            int rowsInserted = dataBase.OrderInsert(new Order
                                                    {
                                                        ItemId = itemId,
                                                        Count = 1,
                                                        ItemStatusId = 1,
                                                        LegalEntity = true,
                                                        PersonInfoId = 1,
                                                        Postage = 0M.DecimalToString(),
                                                        Price = 1.00M.DecimalToString(),
                                                    });
            Assert.AreEqual(1, rowsInserted);
            rowsInserted = dataBase.OrderInsert(new Order
                                                {
                                                    ItemId = itemId,
                                                    Count = 2,
                                                    ItemStatusId = 1,
                                                    LegalEntity = true,
                                                    PersonInfoId = 1,
                                                    Postage = 0M.DecimalToString(),
                                                    Price = 2.99M.DecimalToString(),
                                                });
            Assert.AreEqual(1, rowsInserted);
            rowsInserted = dataBase.OrderInsert(new Order
                                                {
                                                    ItemId = 2,
                                                    Count = 3,
                                                    ItemStatusId = 4,
                                                    LegalEntity = false,
                                                    PersonInfoId = 5,
                                                    Postage = 6M.DecimalToString(),
                                                    Price = 7.123M.DecimalToString(),
                                                });
            Assert.AreEqual(1, rowsInserted);
            List<Order> orders = dataBase.OrderGetByItemId(itemId);
            Assert.IsNotNull(orders);
            orders = dataBase.OrderGetByItemId(2);
            Assert.IsNotNull(orders);
        }

        [Test]
        public void OrderGetByItemStatus()
        {
            DataBase dataBase = new DataBase();

            const int itemStatusId = 3;
            int rowsInserted = dataBase.OrderInsert(new Order
                                                    {
                                                        ItemId = 1,
                                                        Count = 2,
                                                        ItemStatusId = itemStatusId,
                                                        LegalEntity = true,
                                                        PersonInfoId = 4,
                                                        Postage = 5M.DecimalToString(),
                                                        Price = 6.00M.DecimalToString(),
                                                    });
            Assert.AreEqual(1, rowsInserted);
            rowsInserted = dataBase.OrderInsert(new Order
                                                {
                                                    ItemId = 10,
                                                    Count = 20,
                                                    ItemStatusId = itemStatusId,
                                                    LegalEntity = false,
                                                    PersonInfoId = 5,
                                                    Postage = 10M.DecimalToString(),
                                                    Price = 2.99M.DecimalToString(),
                                                });
            Assert.AreEqual(1, rowsInserted);
            const decimal price = 7.123M;
            rowsInserted = dataBase.OrderInsert(new Order
                                                {
                                                    ItemId = 2,
                                                    Count = itemStatusId,
                                                    ItemStatusId = 4,
                                                    LegalEntity = false,
                                                    PersonInfoId = 5,
                                                    Postage = 6M.DecimalToString(),
                                                    Price = price.DecimalToString(),
                                                });
            Assert.AreEqual(1, rowsInserted);
            List<Order> orders = dataBase.OrderGetByItemStatus(itemStatusId);
            Assert.IsNotNull(orders);
            orders = dataBase.OrderGetByItemStatus(4);
            Assert.IsNotNull(orders);
            Order findLast = orders.FindLast(o => o.Price == price.DecimalToString());
            Assert.IsNotNull(findLast);
            Assert.AreEqual(price, findLast.Price.String2Decimal());
        }

        [Test]
        public void OrderGetByPersonId()
        {
            DataBase dataBase = new DataBase();
            const int personInfoId = 5;
            int rowsInserted = dataBase.OrderInsert(new Order
                                                    {
                                                        ItemId = 1,
                                                        Count = 2,
                                                        ItemStatusId = 3,
                                                        LegalEntity = true,
                                                        PersonInfoId = 4,
                                                        Postage = 5M.DecimalToString(),
                                                        Price = 6.00M.DecimalToString(),
                                                    });
            Assert.AreEqual(1, rowsInserted);
            rowsInserted = dataBase.OrderInsert(new Order
                                                {
                                                    ItemId = 10,
                                                    Count = 20,
                                                    ItemStatusId = 3,
                                                    LegalEntity = false,
                                                    PersonInfoId = personInfoId,
                                                    Postage = 10M.DecimalToString(),
                                                    Price = 2.99M.DecimalToString(),
                                                });
            Assert.AreEqual(1, rowsInserted);
            const decimal price = 7.123M;
            rowsInserted = dataBase.OrderInsert(new Order
                                                {
                                                    ItemId = 2,
                                                    Count = 3,
                                                    ItemStatusId = 4,
                                                    LegalEntity = false,
                                                    PersonInfoId = personInfoId,
                                                    Postage = 6M.DecimalToString(),
                                                    Price = price.DecimalToString(),
                                                });
            Assert.AreEqual(1, rowsInserted);
            List<Order> orders = dataBase.OrderGetByPersonInfo(personInfoId);
            Assert.IsNotNull(orders);
            orders = dataBase.OrderGetByItemStatus(4);
            Assert.IsNotNull(orders);
            Order findLast = orders.FindLast(o => o.Price == price.DecimalToString());
            Assert.IsNotNull(findLast);
            Assert.AreEqual(price.DecimalToString(), findLast.Price);
        }

        [Test]
        public void OrderGetByLegalEntity()
        {
            DataBase dataBase = new DataBase();
            const decimal @decimal = 6.00M;
            int rowsInserted = dataBase.OrderInsert(new Order
                                                    {
                                                        ItemId = 1,
                                                        Count = 2,
                                                        ItemStatusId = 3,
                                                        LegalEntity = true,
                                                        PersonInfoId = 4,
                                                        Postage = 5M.DecimalToString(),
                                                        Price = @decimal.DecimalToString(),
                                                    });
            Assert.AreEqual(1, rowsInserted);
            rowsInserted = dataBase.OrderInsert(new Order
                                                {
                                                    ItemId = 10,
                                                    Count = 20,
                                                    ItemStatusId = 3,
                                                    LegalEntity = false,
                                                    PersonInfoId = 5,
                                                    Postage = 10M.DecimalToString(),
                                                    Price = 2.99M.DecimalToString(),
                                                });
            Assert.AreEqual(1, rowsInserted);
            const decimal price = 7.123M;
            rowsInserted = dataBase.OrderInsert(new Order
                                                {
                                                    ItemId = 2,
                                                    Count = 3,
                                                    ItemStatusId = 4,
                                                    LegalEntity = false,
                                                    PersonInfoId = 5,
                                                    Postage = 6M.DecimalToString(),
                                                    Price = price.DecimalToString(),
                                                });
            Assert.AreEqual(1, rowsInserted);
            List<Order> orders = dataBase.OrderGetByLegalEntity();
            Assert.IsNotNull(orders);
            Assert.AreEqual(true, orders[0].LegalEntity);
            List<Order> list = orders.FindAll(o => o.Price == @decimal.DecimalToString());
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void DecimalToString()
        {
            Assert.AreEqual("1.000", 1M.DecimalToString());
            Assert.AreEqual("1.000", 1.00M.DecimalToString());
            Assert.AreEqual("1.234", 1.234M.DecimalToString());
            Assert.AreEqual("1000.000", 1000.000M.DecimalToString());
            Assert.AreEqual("1.000", 1.0M.DecimalToString());
        }
    }
}