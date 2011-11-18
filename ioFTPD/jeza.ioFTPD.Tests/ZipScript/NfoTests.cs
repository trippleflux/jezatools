using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class NfoTests : ZipScriptBase
    {
        [Test]
        public void UploadNfoFileWithImdbLink()
        {
            CleanTestFilesOutput();
            UploadNfoFile01();
        }

        [Test]
        public void UploadNfoFile()
        {
            CleanTestFilesOutput();
            UploadNfoFile02();
        }
    }
}