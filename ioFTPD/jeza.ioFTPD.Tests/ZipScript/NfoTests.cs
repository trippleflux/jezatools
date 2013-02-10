using NUnit.Framework;

namespace jeza.ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class NfoTests : ZipScriptBase
    {
        [Test]
        public void UploadNfoFile()
        {
            CleanTestFilesOutput();
            UploadNfoFile02();
        }

        [Test]
        public void UploadNfoFileWithImdbLink()
        {
            CleanTestFilesOutput();
            UploadNfoFile01();
        }
    }
}