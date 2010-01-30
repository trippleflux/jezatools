
using System;

namespace jcMp3Sort
{
	class Program
	{
		static int Main(string[] args)
		{
			try
			{
				if (args.Length > 0)
				{
					if (args[0].ToLower().Equals("manualsort"))
					{
						Manual.CreateJunctions();
					}
					else
					{
						Test.Check(args);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine(e);
			}
			return 0;
		}
	}
}
