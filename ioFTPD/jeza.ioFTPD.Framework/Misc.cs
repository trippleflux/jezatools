#region
using System;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace jeza.ioFTPD.Framework
{
    public static class Misc
    {
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

        [Obsolete]
        public static string GetSha1(string password)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] ipBytes = Encoding.UTF8.GetBytes(password.ToCharArray());
            byte[] opBytes = sha1.ComputeHash(ipBytes);

            StringBuilder stringBuilder = new StringBuilder(40);
            for (int i = 0; i < opBytes.Length; i++)
            {
                stringBuilder.Append(opBytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public static string ConvertToSha1(string password)
        {
            return
                Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public const string DataTableNameOfItems = "Items";
        public const string DataTableNameOfShops = "Shops";
        public const string DataTableNameOfShopItems = "ShopItems";
        public const string DataTableNameOfTrackers = "Trackers";
    }
}