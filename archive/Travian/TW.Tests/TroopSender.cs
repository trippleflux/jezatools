using System;
using MbUnit.Framework;
using TW.Helper.Http;

namespace TW.Tests
{
    [TestFixture]
    public class TroopSender
    {
        [Test]
        public void ParseLoginPage()
        {
            Login login = new Login(@"..\..\TestFiles\login.php.html");
            Assert.IsNotNull(login.PageSource);
            Assert.AreEqual("w=1680%3A1050&login=1261915108&eeb9e98=asd&e0db265=dsa&e4bf548=832fb24b10&s1.x=66&s1.y=9&s1=login", login.PostData);
        }

        [Test]
        public void Asd()
        {
            DateTime dt = new DateTime(DateTime.Now.Ticks);
            Console.WriteLine(dt);
            Console.WriteLine(dt.Ticks);
            dt = new DateTime(2009, 12, 27, 15, 37, 05);
            int epoch = (int)(dt - new DateTime(1970, 1, 1)).TotalSeconds;
            Console.WriteLine("1261924625");
            Console.WriteLine(epoch);
            //15:37:05
        }
    }
}