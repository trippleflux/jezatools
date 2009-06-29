using System;
using System.IO;

namespace UidChanger
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class UidChanger
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string usersFile = ConfigReader.GetValue("LocationOfUserTable");

			if (File.Exists(usersFile))
			{
				Console.WriteLine("Process With File {0}...", usersFile);
				try 
				{
					using (StreamReader sr = new StreamReader(usersFile)) 
					{
						string newFile = ConfigReader.GetValue("NewLocationOfUserTable");
						using (StreamWriter sw = new StreamWriter(newFile)) 
						{
							String line;
							string defaultname = ConfigReader.GetValue("UserWithDefaultUid");
							if ( defaultname == null)
							{
								defaultname = "ioFTPD";
							}

							int count = 1;
							while ((line = sr.ReadLine()) != null) 
							{
								string name, uid, group;
								string[] spliter = line.Split(':');
								name = spliter[0];
								uid = spliter[1];
								group = spliter[2];

								string oldFile = ConfigReader.GetValue("LocationOfUserFiles")+uid;
								string renamedFile = ConfigReader.GetValue("NewLocationOfUserFiles");
								FileInfo oldFi = new FileInfo(oldFile);

								if (name == defaultname)
								{
									Console.WriteLine("Renaming {0} From {1} To 0", name, uid);
									sw.WriteLine(name+":0:"+group);
									renamedFile+="0";
								}
								else
								{
									Console.WriteLine("Renaming {0} From {1} To {2}", name, uid, count);
									sw.WriteLine(name+":"+count+":"+group);
									renamedFile+=count;
									count++;
								}
								
								if (File.Exists(oldFile))
								{
									oldFi.MoveTo(renamedFile);
								}
								else
								{
									Console.WriteLine(" --> File With UID {0} Doesnt Exists", uid);
								}
							}

						}
					}
				}
				catch (Exception e) 
				{
					Console.WriteLine(e.Message);
				}
			}
			else
			{
				Console.WriteLine("Cant find {0}", usersFile);
			}
		}
	}
}
