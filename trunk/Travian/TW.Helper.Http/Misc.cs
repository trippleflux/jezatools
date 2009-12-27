#region

using System;
using System.IO;

#endregion

namespace TW.Helper.Http
{
    /// <summary>
    /// Various helper methods 
    /// </summary>
    public class Misc
    {
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
            if (IsNumber(input))
            {
                return Int32.Parse(input);
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
        /// Reads the contentof the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>File content.</returns>
        public static string ReadContent(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(fileName);
            }
        }

        public static string SendHttpFake(string url)
        {
            return ReadContent(url);
        }
    }
}