using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jeza.Item.Tracker.Tests
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void SerializeSettings()
        {
            Settings settings = new Settings
                                    {
                                        Languages = new List<Language> {Misc.GetLanguageSlovenian()},
                                    };
            Misc.Serialize(settings, FileName);
        }

        [TestMethod]
        public void DeserializeSettings()
        {
            Settings settings = Misc.Deserialize(new Settings(), FileName);
            Assert.IsNotNull(settings);
        }

        [TestMethod]
        public void InsertBlob()
        {
            //get the path to your image file. openImage is an open file dialog.
            string ImagePath = @"C:\Documents and Settings\jeza\My Documents\klicaj.jpeg";

            //using BinaryReader load your image through a file stream
            BinaryReader binaryData = new BinaryReader(new FileStream(ImagePath, FileMode.Open, FileAccess.Read));

            //create a byte array to store the data
            byte[] imageData = new byte[binaryData.BaseStream.Length];

            //read the data into the array.
            binaryData.BaseStream.Read(imageData, 0, Convert.ToInt32(binaryData.BaseStream.Length));

            //insert the data into a blob record. In database image.db there is a table called images and a blob row called pictures
            //string DatabasePath = MediaTypeNames.Application.StartupPath.ToString() + "\\image.db";
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = @"E:\svn\jezatools\trunk\jeza.Item.Tracker\jeza.Item.Tracker.s3db";

            using (SQLiteConnection connection = new SQLiteConnection(builder.ToString()))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    string commandText = String.Format(
                    @"INSERT INTO Item (Name, Description, ItemType, Image) VALUES('{0}', '{1}', {2}, @image)",
                    "name", "item.Description", 1);
                    using (SQLiteCommand command = new SQLiteCommand(commandText, connection, transaction))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@image", imageData);
                            command.ExecuteNonQuery();
                        }
                        catch (Exception error)
                        {
                            Debug.WriteLine(error.ToString());
                        }

                        finally
                        {
                            transaction.Commit();
                            connection.Close();
                        }
                    }
                }
            }
        }

        

        private const string FileName = "..\\..\\..\\..\\..\\..\\settings.xml";
    }
}