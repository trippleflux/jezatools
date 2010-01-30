using System;
using System.IO;
using Monitor.Core.Utilities;
using HundredMilesSoftware.UltraID3Lib;

namespace jcMp3Sort
{
	internal class Test
	{
		//<!--
		//<add key="enable.Sorting.Mp3.Artist" value="true" />
		//<add key="enable.Sorting.Mp3.Genre" value="true" />
		//<add key="enable.Sorting.Mp3.Year" value="true" />
		//-->

		public static void Check(string[] args)
		{
			string targetFolder = @"E:\server\index\test\asd-iND";
			string junctionPoint = @"E:\server\index\sortby.Artist";
			Console.WriteLine("targetFolder='{0}'", targetFolder);
			Console.WriteLine("junctionPoint='{0}'", junctionPoint);
			
			// Create junction point and confirm its properties.
			JunctionPoint.Create(junctionPoint, targetFolder, true /*overwrite*/);
			if (JunctionPoint.Exists(junctionPoint))
			{
				Console.WriteLine("Junction point exists.");
			}
			else
			{
				Console.WriteLine("Junction point doesnt exists.");
			}
			Console.WriteLine(args[0]);
			if (args.Length < 1)
			{
				Console.WriteLine("Give me an Media file as argument!");
			}
			else
			{
				UltraID3 mp3Info = new UltraID3();
				FileInfo fi = new FileInfo(args[0]);
				mp3Info.Read(fi.FullName);
				if (mp3Info.ID3v23Tag.FoundFlag || mp3Info.ID3v1Tag.FoundFlag)
				{
					Console.WriteLine("Mp3 Info For '{0}':\n{1}", fi.FullName, mp3Info.ToString());
				}
			}
		}
	}
}