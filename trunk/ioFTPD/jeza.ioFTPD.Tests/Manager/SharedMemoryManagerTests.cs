using NUnit.Framework;
using jeza.ioFTPD.Framework.ioFTPD;

namespace jeza.ioFTPD.Tests.Manager
{
    [TestFixture]
    public class SharedMemoryManagerTests
    {
        [Test]
        [Ignore]
        public void FindWindow()
        {
            const string ioftpdMessagewindow = "ioFTPD::MessageWindow";
            SharedMemoryManager sharedMemoryManager = new SharedMemoryManager(ioftpdMessagewindow);
            bool isWindowThere = sharedMemoryManager.IsWindowThere;
            Assert.IsTrue(isWindowThere, string.Format("'{0}' was not found!", ioftpdMessagewindow));
        }
    }
}