using System;

using log4net;
using log4net.Config;

namespace jcScripts.jcHelper
{
	/// <summary>
	/// Summary description for Compare.
	/// </summary>
	public class Compare
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// Compares the input string if matches with <c>what</c>
		/// </summary>
		/// <param name="input">Input String</param>
		/// <param name="what">String To Search For</param>
		/// <param name="separators">Separator Char</param>
		/// <param name="caseSens"><c>true</c> if Compare should be CaseSensiTiVE</param>
		/// <returns><c>true</c> if match found</returns>
		public static bool StrngCompare(string input, string what, char separators, bool caseSens)
		{
			Log.DebugFormat("- StrngCompare");
			Log.DebugFormat("  what={0}", what);

			string[] args = input.Split(separators);
			for ( int i=0;i<args.Length;i++ )
			{
				Log.DebugFormat("  args[{0}]={1}", i, args[i]);

				if (caseSens)
				{
					if ( String.Compare(args[i], what, false) == 0)
					{
						Log.Debug("<- Match ");
						return true;
					}
				}
				else
				{
					if ( String.Compare(args[i], what, true) == 0)
					{
						Log.Debug("<- Match ");
						return true;
					}
				}
			}
			return false;
		}

	
		/// <summary>
		/// Compares the input string if matches with <c>what</c>. it compares what.length chars.
		/// </summary>
		/// <param name="input">Input String</param>
		/// <param name="what">String To Search For</param>
		/// <param name="separators">Separator Char</param>
		/// <param name="caseSens"><c>true</c> if Compare should be CaseSensiTiVE</param>
		/// <returns><c>true</c> if match found</returns>
		/// <remarks>Same as <c>StrngCompare</c></remarks>
		public static bool StrngLengthCompareWhat(string input, string what, char separators, bool caseSens)
		{
			Log.DebugFormat("- StrngLengthCompareWhat");
			Log.DebugFormat("  what={0}", what);

			/*
			 * split the input string
			 * */
			string[] args = input.Split(separators);
			for ( int i=0;i<args.Length;i++ )
			{
				Log.DebugFormat("  args[{0}]={1}", i, args[i]);

				int whatLength = what.Length;
				Log.DebugFormat("    whatLength={0}", whatLength);
				int argsLength = args[i].Length;
				Log.DebugFormat("    argsLength={0}", argsLength);

				if (argsLength < whatLength)
				{
					Log.DebugFormat("    argsLength<whatLength ({0}<{1})", argsLength, whatLength);
					continue;
				}

				string tempArgs = args[i].Substring(0, whatLength);
				Log.DebugFormat("  tempArgs={0}", tempArgs);

				if (caseSens)
				{
					if ( String.Compare(tempArgs, what, false) == 0)
					{
						Log.Debug("<- Match ");
						return true;
					}
				}
				else
				{
					if ( String.Compare(tempArgs, what, true) == 0)
					{
						Log.Debug("<- Match ");
						return true;
					}
				}
			}
			return false;
		}
		
		
		/// <summary>
		/// Compares the input string if matches with <c>what</c>. it compares args.length chars.
		/// </summary>
		/// <param name="input">Input String</param>
		/// <param name="what">String To Search For</param>
		/// <param name="separators">Separator Char</param>
		/// <param name="caseSens"><c>true</c> if Compare should be CaseSensiTiVE</param>
		/// <returns><c>true</c> if match found</returns>
		public static bool StrngLengthCompare(string input, string what, char separators, bool caseSens)
		{
			Log.DebugFormat("- StrngLengthCompare");
			Log.DebugFormat("  what={0}", what);

			/*
			 * split the input string
			 * */
			string[] args = input.Split(separators);
			for ( int i=0;i<args.Length;i++ )
			{
				Log.DebugFormat("  args[{0}]={1}", i, args[i]);

				int argsLength = args[i].Length;
				Log.DebugFormat("    argsLength={0}", argsLength);

				if (argsLength > what.Length)
				{
					Log.DebugFormat("    argsLength>what.Length ({0}>{1})", argsLength, what.Length);
					continue;
				}

				string tempWhat = what.Substring(0, argsLength);
				Log.DebugFormat("    tempWhat={0}", tempWhat);

				if (caseSens)
				{
					if ( String.Compare(args[i], tempWhat, false) == 0)
					{
						Log.Debug("<- Match ");
						return true;
					}
				}
				else
				{
					if ( String.Compare(args[i], tempWhat, true) == 0)
					{
						Log.Debug("<- Match ");
						return true;
					}
				}
			}
			return false;
		}
	}
}
