using NUnit.Framework;
using jeza.ioFTPD.Framework.ioFTPD;

namespace jeza.ioFTPD.Tests.Manager
{
    [TestFixture]
    public class SharedMemoryManagerTests
    {
        private static SharedMemoryManager sharedMemoryManager;
        private const string IoftpdMessagewindow = "ioFTPD::MessageWindow";

        private static void FindWindowForTest()
        {
            sharedMemoryManager = new SharedMemoryManager(IoftpdMessagewindow);
            bool isWindowThere = sharedMemoryManager.IsWindowThere;
            Assert.IsTrue(isWindowThere, string.Format("'{0}' was not found!", IoftpdMessagewindow));
        }

        [Test]
        [Ignore]
        public void SharedAllocate()
        {
            FindWindowForTest();
            LPALLOCATION lpallocation = sharedMemoryManager.SharedAllocate(4096);
            Assert.IsNotNull(lpallocation);
        }

        [Test]
        [Ignore]
        public void UID2Name()
        {
            FindWindowForTest();
            string uid2Name = sharedMemoryManager.UID2Name(0);
            Assert.IsNotNull(uid2Name);
        }
    }
}