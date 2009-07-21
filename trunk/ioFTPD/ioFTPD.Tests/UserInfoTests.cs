using ioFTPD.Framework;
using MbUnit.Framework;

namespace ioFTPD.Tests
{
    [TestFixture]
    public class UserInfoTests
    {
        [Test]
        public void Status()
        {
            UserInfo userInfo = new UserInfo ();
            userInfo.Status ();
            IoFtpd ioFtpd = new IoFtpd();
            ioFtpd.AllocateSharedMemory(24);
        }
    }
}