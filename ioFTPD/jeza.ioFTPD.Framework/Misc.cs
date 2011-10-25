#region
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace jeza.ioFTPD.Framework
{
    public static class Misc
    {
        public static string ArgsToString(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (string arg in args)
            {
                sb.AppendFormat("args[{0}]='{1}', ", i++, arg);
            }
            return sb.ToString().TrimEnd(',', ' ');
        }

        /// <summary>
        /// Creates the symlink between realpath and virtual path.
        /// </summary>
        /// <param name="realPath">The real path.</param>
        /// <param name="virtualPath">The virtual path.</param>
        /// <example>CreateSymlink("C:\ftp-root\today-mp3", "/mp3/1231/")</example>
        public static void CreateSymlink(string realPath,
                                         string virtualPath)
        {
            Console.Write("!vfs:chattr 1 \"{0}\" \"{1}\"\n", realPath, virtualPath);
        }

        /// <summary>
        /// Changes the VFS attributes of a directory.
        /// </summary>
        /// <param name="realPath">The real path.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="uid">The uid.</param>
        /// <param name="gid">The gid.</param>
        /// <example>ChangeVfs("C:\ftp-root\today-mp3", 777, 0, 0)</example>
        public static void ChangeVfs(string realPath,
                                     int mode,
                                     int uid,
                                     int gid)
        {
            Console.Write("!vfs:add {3} {1}:{2} {0}\n", realPath, uid, gid, mode);
        }

        public static MatchCollection GetMatches(string text,
                                                  string regularExpressionString)
        {
            Log.Debug("Check '{0}' for '{1}'", text, regularExpressionString);
            return Regex.Matches(text, regularExpressionString);
        }

        /// <summary>
        /// Determines whether the specified input is match.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="regularExpressionString">The regular expression string.</param>
        /// <returns>
        ///   <c>true</c> if the specified input is match; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMatch(string input,
                                   string regularExpressionString)
        {
            Regex regex = new Regex(regularExpressionString, RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
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
                if (IsNumber(input [c]))
                {
                    sb.Append(input [c]);
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
                if (!IsNumber(input [c]))
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
                stringBuilder.Append(opBytes [i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public static string ConvertToSha1(string password)
        {
            return
                Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}