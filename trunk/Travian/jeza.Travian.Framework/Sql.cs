#region

using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Globalization;

#endregion

namespace jeza.Travian.Framework
{
    public class Sql
    {
        public Sql()
        {
            connectionString = ConfigurationManager.AppSettings["SqLiteConnection"] ??
                               "Data Source=|DataDirectory|testDB.s3db";
            sqlConnection = new SQLiteConnection(connectionString);
        }

        public DataTable GetReportList()
        {
            return GetDataTable("Select * from ReportList;");
        }

        public DataTable GetReports()
        {
            return GetDataTable("Select * from Reports;");
        }

        public int InsertReport(Report report)
        {
            return ExecuteNonQuery(String.Format(CultureInfo.InvariantCulture, 
                "INSERT INTO Reports (Id) VALUES ({0});", report.Id));
        }

        private int ExecuteNonQuery(string commandText)
        {
            sqlConnection.Open();
            SQLiteCommand sqLiteCommand = new SQLiteCommand(sqlConnection) {CommandText = commandText};
            int rowsUpdated = sqLiteCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsUpdated;
        }

        private DataTable GetDataTable(string commandText)
        {
            using (DataTable dataTable = new DataTable())
            {
                try
                {
                    sqlConnection.Open();
                    SQLiteCommand sqLiteCommand = new SQLiteCommand(sqlConnection) {CommandText = commandText};
                    SQLiteDataReader reader = sqLiteCommand.ExecuteReader();
                    dataTable.Load(reader);
                    reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception exception)
                {
                    return null;
                }
                return dataTable;
            }
        }

        private readonly string connectionString;
        private readonly SQLiteConnection sqlConnection;
    }
}