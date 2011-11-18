using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class NfoTests : ZipScriptBase
    {
        public void UploadNfoFile()
        {
            CleanTestFilesOutput();
            UploadNfoFile01();
        }
    }
}