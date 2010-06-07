using System.Data;
using jeza.Travian.Framework;
using MbUnit.Framework;

namespace jeza.Travian.Tests
{
    [TestFixture]
    public class SqLiteTests
    {
        /// <summary>
        /// Select from DB.
        /// </summary>
        [Test]
        public void GetReports()
        {
            Sql sql = new Sql();
            DataTable dataTable = sql.GetReports();
            Assert.IsNotNull(dataTable);
            Assert.IsTrue(dataTable.Rows.Count > 1, "Rows count!");
        }

        /// <summary>
        /// Select from DB.
        /// </summary>
        [Test]
        public void InsertReport()
        {
            Sql sql = new Sql();
            int rowsUpdated = sql.InsertReport(new Report(123));
            Assert.IsTrue(rowsUpdated > 0);
            
        }
    }
}