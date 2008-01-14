using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace jcTBLib
{
	public class Log
	{
		private String traceName = "C:\\jcTB.log";

		public Log(string traceName)
		{
			this.traceName = traceName;
		}


		public Log()
		{

		}

		public void Write(String text)
		{
			using(StreamWriter sw = new StreamWriter(traceName, true))
			{
				sw.WriteLine(text);
			}
		}
	}
}
