#region
using System;
using System.IO;
using System.Threading;

#endregion

namespace jeza.ioFTPD.Framework
{
    public static class Log
    {
        public static void Debug(string line)
        {
// ReSharper disable ConditionIsAlwaysTrueOrFalse
            if (Config.Debug)
            {
                Debug(line, null);
            }
// ReSharper restore ConditionIsAlwaysTrueOrFalse
        }

        public static void Debug(string line,
                                 params object[] args)
        {
// ReSharper disable ConditionIsAlwaysTrueOrFalse
            if (Config.Debug)
            {
                string path = Environment.GetEnvironmentVariable("PATH");
                if ((path == null) || (path.IndexOf(';') > -1))
                {
                    path = "";
                }
                string fileName = Path.Combine(path, Config.FileNameDebug);
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
                LogMutex.WaitOne();
                using (FileStream stream = new FileStream(fileInfo.FullName,
                                                          FileMode.Append,
                                                          FileAccess.Write,
                                                          FileShare.None))
                {
                    using (StreamWriter streamWriter = new StreamWriter(stream))
                    {
                        if (args != null)
                        {
                            streamWriter.WriteLine(line, args);
                        }
                        else
                        {
                            streamWriter.WriteLine(line);
                        }
                    }
                }
                LogMutex.ReleaseMutex();
            }
// ReSharper restore ConditionIsAlwaysTrueOrFalse
        }

        private static readonly Mutex LogMutex = new Mutex(false, "logMutex");
    }
}