using System;
using System.Threading;

namespace jcTBLib
{
	public class Build
	{
		public Thread[] build;

		public Build(String buildName, Int32 threadIndex)
		{
			build[threadIndex] = new Thread(new ThreadStart(this.Run));
			build[threadIndex].Name = buildName;
			build[threadIndex].Start();
		}

		void Run()
		{
			do
			{
				Thread.Sleep(5000);
			} while (true);
		}

		/// <summary>
		/// Checks If The Correct Command WasSend.
		/// </summary>
		/// <param name="command">userInput</param>
		/// <returns>Console Message For User</returns>
		/// 
		public static Int32 CheckCommand(String command)
		{
			Int32 unknownCMD = 255;
			String[] cmdSplit = command.Split(' ');
			if (cmdSplit[0].Equals("build"))
			{
				if (cmdSplit[1].Equals("woodland"))
				{
					return 0;
				}
				else
				{
					return unknownCMD;
				}
			}
			else
			{
				return unknownCMD;
			}
		}
	}
}