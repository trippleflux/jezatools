#region

using System;
using System.Text;

#endregion

namespace jeza.Travian.Framework
{
    /// <summary>
    /// Various helper methods 
    /// </summary>
    public class Misc
    {
        /// <summary>
        /// Converts the coordinates to mapNumber attribute (?d=).
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns></returns>
        public static Int32 ConvertCoordinates(Int32 x, Int32 y)
        {
            return ((x + 401) + ((400 - y)*801));
        }

        /// <summary>
        /// Converts the specified string representation of a logical value to its System.Boolean equivalent.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns><c>true</c> or <c>false</c></returns>
        public static bool String2Bool(string input)
        {
            if (input != null)
            {
                if (input.Equals(Boolean.TrueString, StringComparison.InvariantCultureIgnoreCase) ||
                    input.Equals(Boolean.FalseString, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Boolean.Parse(input);
                }
            }
            return false;
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

        /// <summary>
        /// Comma delimited listto array.
        /// </summary>
        /// <param name="appSetting">The app setting.</param>
        /// <returns></returns>
        public static string[] StringFromCommaDelimited(string appSetting)
        {
            return appSetting.Split(',');
        }

        /// <summary>
        /// Converts string to TimeSpan format.
        /// </summary>
        /// <param name="text">The text informat dd:mm:ss.</param>
        /// <returns></returns>
        public static TimeSpan String2TimeSpan(string text)
        {
            TimeSpan timeSpan = new TimeSpan(1, 1, 1);
            if (text.IndexOf(':') > -1)
            {
                string[] sep = text.Split(':');
                int hours = String2Number(sep[0]);
                int miutes = String2Number(sep[1]);
                int seconds = String2Number(sep[2]);
                timeSpan = new TimeSpan(hours, miutes, seconds);
            }
            return timeSpan;
        }
    }
}