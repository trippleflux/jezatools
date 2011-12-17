using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using jeza.Item.Tracker.Settings;
using NLog;

namespace jeza.Item.Tracker
{
    public static class Misc
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private const string NumberDecimalSeparator = ".";

        public static string DecimalToString(this decimal number)
        {
            NumberFormatInfo numberFormatInfo = GetNumberFormatInfo();
            string decimalToString = String.Format(numberFormatInfo, "{0:0.000}", number);
            return decimalToString;
        }

        public static Language GetLanguageSlovenian()
        {
            Language languageSlovenian = new Language
                                         {
                                             Culture = "sl-SI",
                                             TabOrders = new TabOrders
                                                         {
                                                             Name = "Narocila",
                                                             LabelOrdersPersonInfo = "Naročnik",
                                                             LabelOrdersItemType = "Tip izdelka",
                                                             LabelOrdersItem = "Izdelek",
                                                             LabelOrdersItemStatus = "Status naročila",
                                                             LabelOrdersItemCount = "Število izdelkov",
                                                             LabelOrdersPrice = "Cena izdelka",
                                                             LabelOrdersPostage = "Poštnina",
                                                             LabelOrdersTax = "Davek",
                                                             LabelOrdersLegalEntity = "Pravna oseba",
                                                             LabelOrdersPicture = "Slika",
                                                             LabelOrdersList = "Seznam",
                                                             ButtonOrdersSum = "Vsota",
                                                             ButtonOrdersSelect = "Izberi",
                                                             ButtonOrdersSave = "Shrani",
                                                             ButtonOrdersNew = "Nov",
                                                             ButtonOrdersUpdate = "Posodobi",
                                                             ButtonOrdersDelete = "Izbriši",
                                                         },
                                             TabItems = new TabItems
                                                        {
                                                            Name = "Izdelki",
                                                            GroupBoxItems = "Izdelki",
                                                            LabelItemsName = "Ime",
                                                            LabelItemsDescription = "Opis",
                                                            LabelItemsType = "Tip",
                                                            LabelItemsImage = "Slika",
                                                            LabelItemsList = "Seznam",
                                                            ButtonItemsPictureBoxSelect = "Izberi sliko",
                                                            ButtonItemsSelect = "Izberi",
                                                            ButtonItemsSave = "Shrani",
                                                            ButtonItemsNew = "Nov",
                                                            ButtonItemsUpdate = "Posodobi",
                                                            ButtonItemsDelete = "Izbriši",
                                                        },
                                             TabItemTypes = new TabItemTypes
                                                            {
                                                                Name = "Tipi izdelkov",
                                                                GroupBoxItemType = "Tipi izdelkov",
                                                                LabelItemTypeName = "Ime",
                                                                LabelItemTypeDescription = "Opis",
                                                                LabelItemTypeList = "Seznam",
                                                                ButtonItemTypeListSelect = "Izberi",
                                                                ButtonItemTypeListSave = "Shrani",
                                                                ButtonItemTypeListNew = "Nov",
                                                                ButtonItemTypeListUpdate = "Posodobi",
                                                                ButtonItemTypeListDelete = "Izbriši",
                                                            },
                                             TabItemStatus = new TabItemStatus
                                                             {
                                                                 Name = "Status naročila",
                                                                 GroupBoxItemsStatus = "Status naročila",
                                                                 LabelItemsStatusName = "Ime",
                                                                 LabelItemStatusDescription = "Opis",
                                                                 LabelItemStatusList = "Seznam",
                                                                 ButtonItemStatusSelect = "Izberi",
                                                                 ButtonItemStatusSave = "Shrani",
                                                                 ButtonItemStatusNew = "Nov",
                                                                 ButtonItemStatusUpdate = "Posodobi",
                                                                 ButtonItemStatusDelete = "Izbriši",
                                                             },
                                             TabPersonInfo = new TabPersonInfo
                                                             {
                                                                 Name = "Naročniki",
                                                                 LabelPersonInfoName = "Ime",
                                                                 LabelPersonInfoSurName = "Priimek",
                                                                 LabelPersonInfoNickName = "Vzdevek",
                                                                 LabelPersonInfoDescription = "Opis",
                                                                 LabelPersonInfoAddress = "Naslov",
                                                                 LabelPersonInfoPostNumber = "Poštna številka",
                                                                 LabelPersonInfoCity = "Mesto/Kraj",
                                                                 LabelPersonInfoEmail = "Email",
                                                                 LabelPersonInfoFax = "Telefaks",
                                                                 LabelPersonInfoTelephone = "Telefon",
                                                                 LabelPersonInfoTelephoneMobile = "Mobilni telefon",
                                                                 LabelPersonInfoList = "Seznam",
                                                                 ButtonPersonInfoSelect = "Izberi",
                                                                 ButtonPersonInfoSave = "Shrani",
                                                                 ButtonPersonInfoNew = "Nov",
                                                                 ButtonPersonInfoUpdate = "Posodobi",
                                                                 ButtonPersonInfoDelete = "Izbriši",
                                                             },
                                             TabReports = new TabReports
                                                          {
                                                              Name = "Statistika",
                                                          },
                                             TabBank = new TabBank
                                                       {
                                                           Name = "Banka",
                                                           LabelBankName = "Ime",
                                                           LabelBankAccountNumber = "Račun",
                                                           LabelBankOwner = "Lastnik",
                                                           LabelBankList = "Seznam",
                                                           ButtonBankNew = "Nov",
                                                           ButtonBankSave = "Shrani",
                                                           ButtonBankUpdate = "Posodobi",
                                                           ButtonBankDelete = "Zbriši",
                                                       }
                                         };
            return languageSlovenian;
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
        public static decimal String2Decimal(this string input)
        {
            Logger.Debug("String2Decimal: '{0}'", input);
            try
            {
                NumberFormatInfo numberFormatInfo = GetNumberFormatInfo();
                Logger.Debug("String2Decimal: '{0}', NumberDecimalSeparator='{1}'", input,
                             numberFormatInfo.NumberDecimalSeparator);
                int length = input.Length;
                if (length < 1)
                {
                    return 0M;
                }
                input = input.Replace(",", NumberDecimalSeparator);
                Logger.Debug("String2Decimal: input='{0}'", input);
                decimal parsedValue;
                bool tryParse = decimal.TryParse(input, NumberStyles.Any, numberFormatInfo, out parsedValue);
                Logger.Debug("parsedValue='{0}'", parsedValue);
                return tryParse ? parsedValue : 0;
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return 0M;
            }
        }

        private static NumberFormatInfo GetNumberFormatInfo()
        {
            NumberFormatInfo numberFormatInfo = (NumberFormatInfo) CultureInfo.CurrentCulture.NumberFormat.Clone();
            numberFormatInfo.NumberDecimalSeparator = NumberDecimalSeparator;
            return numberFormatInfo;
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