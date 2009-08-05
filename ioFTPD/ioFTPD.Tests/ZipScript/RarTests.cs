#region
using System.IO;
using ioFTPD.Framework;
using MbUnit.Framework;
using FileInfo=System.IO.FileInfo;

#endregion

namespace ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class RarTests : ZipScriptBase
    {
        /// <summary>
        /// Uploads the first file. Delete file with missing extension, update RACE file.
        /// </summary>
        [Test]
        public void RaceRar ()
        {
            Race race = new Race (argsRar);
            race.Parse ();
            race.Process ();
            FileInfo fileInfo = new FileInfo (Path.Combine (race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    stream.Seek (0, SeekOrigin.Begin);
                    Assert.AreEqual (4, reader.ReadInt32 ());
                    stream.Seek (256 * 1, SeekOrigin.Begin);
                    Assert.AreEqual ("infected.part1.rar", reader.ReadString ());
                    Assert.AreEqual ("2e04944c", reader.ReadString ());
                    Assert.AreEqual (true, reader.ReadBoolean ());
                }
            }
        }
    }
}