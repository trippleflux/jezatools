using System;
using System.Globalization;
using System.IO;
using System.Text;
using SimpleFTP;

namespace jcReleaseCollector
{
	internal class Program
	{
		private static int Main(string[] args)
		{
			//foreach (string arg in args)
			//{
			//    Log("c:\\ioFTPD\\logs\\ReleaseCollectorArgs.log", arg);
			//}
			if (args[0] == "scheduler")
			{
				outDebug = false;
			}
			WriteClientResponse("!buffer off\n");

			//first delete everything under LocalPaths
			int j = 0;
			do
			{
				String localPath = Settings.GetConfig(String.Format(CultureInfo.InvariantCulture, "ftp[{0}].LocalPath", j));
				if (localPath.Equals(String.Empty))
				{
					break;
				}
				Directory.Delete(localPath, true);
				Directory.CreateDirectory(localPath);
				j++;
			} while (true);

			int i = 0;
			do
			{
				String siteName = Settings.GetConfig(String.Format(CultureInfo.InvariantCulture, "ftp[{0}].SiteName", i));
				if (siteName.Equals(String.Empty))
				{
					break;
				}
				WriteClientResponse(String.Format(CultureInfo.InvariantCulture, "\n\rResponse: Trying {0}...", siteName));

				String hostName = Settings.GetConfig(String.Format(CultureInfo.InvariantCulture, "ftp[{0}].HostName", i));
				String portName = Settings.GetConfig(String.Format(CultureInfo.InvariantCulture, "ftp[{0}].Port", i));
				String userName = Settings.GetConfig(String.Format(CultureInfo.InvariantCulture, "ftp[{0}].UserName", i));
				String password = Settings.GetConfig(String.Format(CultureInfo.InvariantCulture, "ftp[{0}].Password", i));
				String localPath = Settings.GetConfig(String.Format(CultureInfo.InvariantCulture, "ftp[{0}].LocalPath", i));
				String remotePath = Settings.GetConfig(String.Format(CultureInfo.InvariantCulture, "ftp[{0}].RemotePath", i));

				//Connect to FTP
				FtpClient ftpClient = new FtpClient();
				try
				{
					WriteClientResponse(String.Format(CultureInfo.InvariantCulture, "hostName: {0}", hostName));
					WriteClientResponse(String.Format(CultureInfo.InvariantCulture, "portName: {0}", portName));
					WriteClientResponse(String.Format(CultureInfo.InvariantCulture, "userName: {0}", userName));
					WriteClientResponse(String.Format(CultureInfo.InvariantCulture, "password: {0}\r\n", password));

					ftpClient.Connect(hostName, Int32.Parse(portName));
					ftpClient.Login(userName, password);
                    if (ftpClient.LoggedIn)
                    {
                        string[] ftpFolders = ftpClient.GetDir (remotePath, FtpClient.DirMode.NamesOnly);
                        foreach (String folder in ftpFolders)
                        {
                            String releaseName;
                            if (folder.IndexOf ('/') > -1)
                            {
                                String[] splitFolder = folder.Split ('/');
                                releaseName = splitFolder [splitFolder.Length - 1];
                            }
                            else
                            {
                                releaseName = folder;
                            }
                            WriteClientResponse (String.Format (CultureInfo.InvariantCulture,
                                                                "releaseName: '{0}'",
                                                                releaseName));
                            Directory.CreateDirectory (
                                String.Format (CultureInfo.InvariantCulture, "{0}\\{1}", localPath, releaseName));
                        }
                        ftpClient.Disconnect ();
                        ftpClient.Close ();
                    }
                    else
                    {
                        WriteClientResponse("Login failed...");
                    }
				}
				catch (Exception ex)
				{
					//Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "ERROR:\r\n{0}", ex.Message));
					Log("c:\\ioFTPD\\logs\\ReleaseCollectorErrors.log", ex.ToString());
					if (ftpClient.Connected)
					{
						//ftpClient.Disconnect();
						ftpClient.Close();
					}
					return 1;
				}
				i++;
			} while (true);

			return 0;
		}

		private static void WriteClientResponse(String ftpResponse)
		{
			if (outDebug)
			{
				Console.WriteLine(ftpResponse);
			}
		}

		private static void Log(string fileName, string message)
		{
			using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
			{
				sw.WriteLine(message);
				sw.Close();
				sw.Dispose();
			}
		}



		private static bool outDebug = true;
	}
}
