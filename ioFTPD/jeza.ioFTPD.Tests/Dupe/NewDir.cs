using jeza.ioFTPD.Framework;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Dupe
{
    [TestFixture]
    public class NewDir
    {
        /// <summary>
        /// Create new dir and add it to dupe DB.
        /// </summary>
        [Test]
        public void AddNew()
        {
            ConsoleAppTasks task = new ConsoleAppTasks(new[] {"newdir", @"..\..\TestFiles", "/test/TestFiles"});
            task.Execute(TaskType.DupeNewDir);
        }
    }
}