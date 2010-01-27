using MbUnit.Framework;

namespace ioFTPD.Tests.ZipScript
{
    public class ZipScriptBase
    {
        protected readonly string[] ArgsRar = new[]
            {
                "upload"
                , @"..\..\TestFiles\Rar\infected.part1.rar"
                , "2e04944c"
                , "/TestFiles/Rar/infected.part1.rar"
            };

        protected readonly string[] ArgsSfv = new[]
            {
                "upload"
                , @"..\..\TestFiles\Rar\infected.sfv"
                , "aabbccdd"
                , "/TestFiles/Rar/infected.sfv"
            };

        protected void AssertIsFalse
            (bool value,
             string message)
        {
            Assert.IsFalse (value, message);
        }

        protected void AssertIsTrue
            (bool value,
             string message)
        {
            Assert.IsTrue (value, message);
        }

        protected void AssertAreEqual
            (object expectedValue,
             object actualValue,
             string message)
        {
            Assert.AreEqual (expectedValue, actualValue, message);
        }

        protected void AssertIsNotNull(object actualValue, string message)
        {
            Assert.IsNotNull (actualValue, message);
        }
    }
}