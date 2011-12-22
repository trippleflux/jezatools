using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Tests.ZipScript;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests
{
    [TestFixture]
    public class SharpComressTests : ZipScriptBase
    {
        [Test]
        public void ExtractFromZip()
        {
            string[] correctZipFile = ArgsCorrectZipFile1;
            correctZipFile[1].ExtractArchive();
        }

        [Test]
        public void ExtractFromRar()
        {
            string[] argsRarParts = ArgsRarPart1;
            argsRarParts[1].ExtractArchive();
        }

        [Test]
        public void ExtractDiz()
        {
            string[] correctZipFile = ArgsCorrectZipFile1;
            Assert.IsTrue(correctZipFile[1].ExtractFromArchive(".diz"));
        }
    }
}