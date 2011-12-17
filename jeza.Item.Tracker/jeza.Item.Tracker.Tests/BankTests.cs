using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace jeza.Item.Tracker.Tests
{
    [TestFixture]
    public class BankTests
    {
        [Test]
        public void Insert()
        {
            DataBase dataBase = new DataBase();
            Bank bank = new Bank
                        {
                            Name = Guid.NewGuid().ToString(),
                            Owner = Guid.NewGuid().ToString(),
                            AccountNumber = Guid.NewGuid().ToString(),
                        };
            int rowsInserted = dataBase.BankInsert(bank);
            Assert.IsTrue(rowsInserted == 1);
        }

        [Test]
        public void Update()
        {
            DataBase dataBase = new DataBase();
            string bankName = Guid.NewGuid().ToString();
            string newBankName = Guid.NewGuid().ToString();
            string owner = Guid.NewGuid().ToString();
            Bank bank = new Bank
            {
                Name = bankName,
                Owner = owner,
                AccountNumber = Guid.NewGuid().ToString(),
            };
            int rowsInserted = dataBase.BankInsert(bank);
            Assert.IsTrue(rowsInserted == 1);
            List<Bank> bankGet = dataBase.BankGet(owner);
            Assert.IsNotNull(bankGet);
            bank.Id = bankGet[0].Id;
            bank.Name = newBankName;
            int rowsUpdated = dataBase.BankUpdate(bank);
            Assert.IsTrue(rowsUpdated == 1);
            bankGet = dataBase.BankGet(owner);
            Assert.IsNotNull(bankGet);
            Assert.AreEqual(newBankName, bankGet[0].Name);
        }

        [Test]
        public void Delete()
        {
            DataBase dataBase = new DataBase();
            string bankName = Guid.NewGuid().ToString();
            string owner = Guid.NewGuid().ToString();
            Bank bank = new Bank
                        {
                            Name = bankName,
                            Owner = owner,
                            AccountNumber = Guid.NewGuid().ToString(),
                        };
            int rowsInserted = dataBase.BankInsert(bank);
            Assert.IsTrue(rowsInserted == 1);
            List<Bank> bankGet = dataBase.BankGet(owner);
            Assert.IsNotNull(bankGet);
            int bankId = bankGet[0].Id;
            int rowsDeleted = dataBase.BankDelete(bankId);
            Assert.IsTrue(rowsDeleted == 1);
            bankGet = dataBase.BankGet(owner);
            Assert.IsNull(bankGet);
            Bank bankDeleted = dataBase.BankGet(bankId);
            Assert.IsNull(bankDeleted);
        }
    }
}