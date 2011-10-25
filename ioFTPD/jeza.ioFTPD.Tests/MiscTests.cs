using System.Text.RegularExpressions;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests
{
    [TestFixture]
    public class MiscTests
    {
        [Test]
        public void ArgsToString()
        {
            string[] args = new[] {"arg0", "arg1"};
            string argsToString = Misc.ArgsToString(args);
            Assert.AreEqual("args[0]='arg0', args[1]='arg1'", argsToString);
        }

        [Test]
        public void GetMatches()
        {
            MatchCollection matchCollection = Misc.GetMatches("some stupid text!", "some");
            Assert.IsTrue(matchCollection.Count == 1);
        }

        [Test]
        public void IsMatch()
        {
            Assert.IsTrue(Misc.IsMatch("some stupid text!", "some"), "some stupid text missmatch!");
            Assert.IsTrue(Misc.IsMatch("stargate fringe!", @"\S*([Ss]targate|[Ss]tar[Tt]rek)\S*"), "StarTrek, StarGate missmatch!");
        }

        [Test]
        public void String2Boolean()
        {
            Assert.IsTrue(Misc.String2Boolean("true"), "true");
            Assert.IsTrue(Misc.String2Boolean("True"), "True");
            Assert.IsTrue(Misc.String2Boolean("TRUE"), "TRUE");

            Assert.IsFalse(Misc.String2Boolean("FALSE"), "FALSE");
            Assert.IsFalse(Misc.String2Boolean("false"), "false");
            Assert.IsFalse(Misc.String2Boolean("False"), "False");

            Assert.IsFalse(Misc.String2Boolean("Flase"), "Flase");
        }

        [Test]
        public void String2Number()
        {
            Assert.AreEqual(123, Misc.String2Number("123"), "123");
            Assert.AreEqual(123, Misc.String2Number("0123"), "0123");
            Assert.AreEqual(1230, Misc.String2Number("01230"), "01230");
            Assert.AreEqual(123, Misc.String2Number("123asd"), "123asd");
            Assert.AreEqual(1, Misc.String2Number("1d2a3"), "1s2a3");
            Assert.AreEqual(0, Misc.String2Number("asddsa"), "asddsa");
        }

        [Test]
        public void IsNumber()
        {
            Assert.IsFalse(Misc.IsNumber("asddsa"), "asddsa");
            Assert.IsTrue(Misc.IsNumber("123"), "123");
            Assert.IsTrue(Misc.IsNumber("0"), "0");
            Assert.IsTrue(Misc.IsNumber("-123"), "-123");
            Assert.IsTrue(Misc.IsNumber("+123"), "+123");
            Assert.IsTrue(Misc.IsNumber('1'), "1");
            Assert.IsFalse(Misc.IsNumber('a'), "a");
        }
    }
}