using System;
using System.Data;
using MbUnit.Framework;
using TW.Helper;

namespace TW.Tests
{
    [TestFixture]
    public class Graph
    {
        [Test]
        public void DataSet()
        {
            const string srcTable = "Goods";
            Helper.DataBase dataBase = new Helper.DataBase();
            DataSet dataSet = dataBase.GetGoods(srcTable, 0);
            DataRow dataRow = dataSet.Tables[srcTable].Rows[0];
            int wood = Misc.String2Number(dataRow.ItemArray[0].ToString());
            int clay = Misc.String2Number(dataRow.ItemArray[1].ToString());
            int iron = Misc.String2Number(dataRow.ItemArray[2].ToString());
            int crop = Misc.String2Number(dataRow.ItemArray[3].ToString());
        }
    }
}