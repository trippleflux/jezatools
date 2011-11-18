using System;
using System.Text.RegularExpressions;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Framework.Json;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests
{
    [TestFixture]
    public class MiscTests
    {
        [Test]
        public void ImdbId()
        {
            string imdbUrl = "http://www.imdb.com/title/tt123456789/";
            string imdbId = Extensions.GetImdbId(imdbUrl);
            Assert.AreEqual("tt123456789", imdbId);

            imdbUrl = "http://www.imdb.com/title/as123456789/";
            imdbId = Extensions.GetImdbId(imdbUrl);
            Assert.AreEqual(String.Empty, imdbId);
        }

        [Test]
        public void Json()
        {
            JsonParser jsonParser = new JsonParser {CamelizeProperties = true}; 
            const string input = @"{""title"":""True Grit"",""Year"":""1969"",""Rated"":""G"",""Released"":""11 Jun 1969"",""Genre"":""Adventure, Western, Drama"",""Director"":""Henry Hathaway"",""Writer"":""Charles Portis, Marguerite Roberts"",""Actors"":""John Wayne, Kim Darby, Glen Campbell, Jeremy Slate"",""Plot"":""A drunken, hard-nosed U.S. Marshal and a Texas Ranger help a stubborn young woman track down her father's murderer in Indian territory."",""Poster"":""http://ia.media-imdb.com/images/M/MV5BMTYwNTE3NDYzOV5BMl5BanBnXkFtZTcwNTU5MzY0MQ@@._V1._SX320.jpg"",""Runtime"":""2 hrs 8 mins"",""Rating"":""7.3"",""Votes"":""10654"",""ID"":""tt0065126"",""Response"":""True""}";
            dynamic output = jsonParser.Parse(input);
            dynamic title = output.Title;
            Assert.IsNotNull(title);
            string titleOfTheMovie = title.ToString();
            Assert.AreEqual("True Grit", titleOfTheMovie);
        }

        [Test]
        public void JsonGet()
        {
            dynamic output = Extensions.GetImdbResponseForEventName("true grit");
            Assert.IsNotNull(output);
            dynamic title = output.Title;
            string titleOfTheMovie = title.ToString();
            Assert.AreEqual("True Grit", titleOfTheMovie);

            output = Extensions.GetImdbResponseForEventName(Guid.NewGuid().ToString());
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Response);
        }

        [Test]
        public void Split()
        {
            string list = "asd";
            char[] separator = new[] { ' ', ',' };
            string[] strings = list.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Assert.IsNotNull(strings);
            Assert.AreEqual(1, strings.Length);
            list = "asd, dsa";
            strings = list.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Assert.IsNotNull(strings);
            Assert.AreEqual(2, strings.Length);

            list = "asd, dsa tre";
            strings = list.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Assert.IsNotNull(strings);
            Assert.AreEqual(3, strings.Length);

            list = "";
            strings = list.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Assert.IsNotNull(strings);
            Assert.AreEqual(0, strings.Length);
        }

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