using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace jeza.Item.Tracker
{
    public static class Misc
    {
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
        public static T Deserialize<T>(T xmlObject,
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

        public static void Serialize<T>(T xmlObject,
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
    }
}