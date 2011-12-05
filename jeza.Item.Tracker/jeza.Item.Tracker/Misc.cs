using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Xml.Serialization;
using NLog;

namespace jeza.Item.Tracker
{
    public static class Misc
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static string DecimalToString(this decimal number)
        {
            return String.Format("{0:0.000}", number);
        }

        public static Language GetLanguageSlovenian()
        {
            Language languageSlovenian = new Language
                                         {
                                             Culture = "sl-SI",
                                             TabItems = new TabItems
                                                        {
                                                            TabPageItems = "Izdelki",
                                                            GroupBoxItemsType = "Tip",
                                                            LabelItemsTypeExisting = "Obstojeci",
                                                            ButtonItemsTypeSelect = "Izberi",
                                                            LabelItemsTypeNew = "Nov",
                                                            ButtonItemsTypeSave = "Shrani",
                                                            GroupBoxItemsStatus = "Status",
                                                            LabelItemsStatusExisting = "Obsotjeci",
                                                            LabelItemsStatusNew = "Nov",
                                                            ButtonItemsStatusSelect = "Izberi",
                                                            ButtonItemsStatusSave = "Shrani",
                                                            GroupBoxItems = "Izdelki",
                                                            LabelItemsList = "Izdelki",
                                                            ButtonItemsSelect = "Izberi",
                                                            LabelItemsNew = "Izdelek",
                                                            ButtonItemsSave = "Shrani",
                                                            LabelItemsItemType = "Tip",
                                                            ButtonItemsPictureBoxSelect = "Izberi",
                                                            LabelItemsImage = "Slika",
                                                        },
                                             TabOrders = new TabOrders
                                                         {
                                                             Name = "Narocila",
                                                         },
                                             TabReports = new TabReports
                                                          {
                                                              Name = "Statistika",
                                                          },
                                         };
            return languageSlovenian;
        }

        /// <summary>
        /// Deserializes the specified XML object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlObject">The XML object.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static T Deserialize<T>
            (T xmlObject,
             string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
                    return (T) xmlSerializer.Deserialize(fileStream);
                }
            }
            throw new Exception("Failed to deserialize configuration!");
        }

        public static void Serialize<T>
            (T xmlObject,
             string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(textWriter, xmlObject);
            }
        }

        /// <summary>
        /// Converts string to boolean.
        /// </summary>
        /// <param name="keyValue">The key value.</param>
        /// <returns></returns>
        public static bool String2Boolean(string keyValue)
        {
            try
            {
                return Boolean.Parse(keyValue);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Converts string to number.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns><c>0</c> if input string was not a number.</returns>
        public static int String2Number(string input)
        {
            int length = input.Length;
            if (length < 1)
            {
                return 0;
            }
            StringBuilder sb = new StringBuilder();
            for (int c = 0; c < length; c++)
            {
                if (IsNumber(input[c]))
                {
                    sb.Append(input[c]);
                }
                else
                {
                    break;
                }
            }
            if (IsNumber(sb.ToString()))
            {
                return Int32.Parse(sb.ToString());
            }
            return 0;
        }

        /// <summary>
        /// Converts string to decimal.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns><c>0</c> if input string was not a number.</returns>
        public static decimal String2Decimal(string input)
        {
            int length = input.Length;
            if (length < 1)
            {
                return 0;
            }
            StringBuilder sb = new StringBuilder();
            const char dot = '.';
            if (input[0] == dot)
            {
                sb.Append("0");
            }
            for (int c = 0; c < length; c++)
            {
                if (input[c] == dot)
                {
                    sb.Append(input[c]);
                }
                else if (Char.IsNumber(input[c]))
                {
                    sb.Append(input[c]);
                }
            }
            return Decimal.Parse(sb.ToString());
        }

        /// <summary>
        /// Determines whether the specified input string is number.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input string is number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumber(string input)
        {
            int length = input.Length;
            if (length < 1)
            {
                return false;
            }
            for (int c = 0; c < length; c++)
            {
                if (!IsNumber(input[c]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether the specified character is number.
        /// </summary>
        /// <param name="c">The character.</param>
        /// <returns>
        /// 	<c>true</c> if the specified character is number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumber(char c)
        {
            if (c.Equals('+') || c.Equals('-'))
            {
                return true;
            }
            return Char.IsNumber(c);
        }

        /// <summary>
        /// Gets the image data (bytes).
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <returns></returns>
        public static byte[] GetImageData(string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    BinaryReader binaryData = new BinaryReader(new FileStream(imagePath, FileMode.Open, FileAccess.Read));
                    byte[] imageData = new byte[binaryData.BaseStream.Length];
                    binaryData.BaseStream.Read(imageData, 0, Convert.ToInt32(binaryData.BaseStream.Length));
                    return imageData;
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.ToString);
            }
            return null;
        }

        /// <summary>
        /// Returns a thumbnail 250x250 for this image.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <returns></returns>
        public static byte[] GetThumbNailImageData(string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    Bitmap bitmap = new Bitmap(imagePath);
                    using (Image thumb = bitmap.GetThumbnailImage(250, 250, null, new IntPtr()))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            thumb.Save(memoryStream, ImageFormat.Jpeg);
                            return memoryStream.ToArray();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.ToString);
            }
            return null;
        }
    }
}