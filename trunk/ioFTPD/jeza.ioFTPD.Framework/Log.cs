#region
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

#endregion

namespace jeza.ioFTPD.Framework
{
    public static class Log
    {
        //[Conditional("DEBUG")]
        public static void Debug(string line)
        {
            Debug(line, null);
        }

        //[Conditional("DEBUG")]
        public static void Debug(string line,
                                 params object[] args)
        {
            string path = Environment.GetEnvironmentVariable("PATH");
            if ((path == null) || (path.IndexOf(';') > -1))
            {
                path = "";
            }
            string fileNameDebug = Config.FileNameDebug;
            if (string.IsNullOrEmpty(fileNameDebug))
            {
                return;
            }
            string fileName = Misc.PathCombine(path, fileNameDebug);
            WriteToFile(fileName, line, args);
        }

        private static void WriteToFile(string fileName,
                                        string line,
                                        object[] args)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    return;
                }
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
                LogMutex.WaitOne();
                using (FileStream stream = new FileStream(fileInfo.FullName,
                                                          FileMode.Append,
                                                          FileAccess.Write,
                                                          FileShare.None))
                {
                    using (StreamWriter streamWriter = new StreamWriter(stream))
                    {
                        DateTime dt = new DateTime(DateTime.Now.Ticks);
                        line = dt.ToString("[yyyy-MM-dd HH:mm:ss] ") + line;
                        if (args != null)
                        {
                            streamWriter.WriteLine(line, args);
                            if(Config.LogToConsole)
                            {
                                Console.WriteLine(line, args);
                            }
                        }
                        else
                        {
                            streamWriter.WriteLine(line);
                            if (Config.LogToConsole)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                }
                LogMutex.ReleaseMutex();
            }
            catch (Exception exception)
            {
                Output output = new Output();
                output.Client(fileName);
                output.Client(args != null ? String.Format(line, args) : line);
                output.Client(exception.ToString());
            }
        }

        /// <summary>
        /// Writes a message to ioFTPD log file (ioFTPD\logs\ioFTPD.log).
        /// </summary>
        /// <param name="message">The message.</param>
        public static void IoFtpd(string message)
        {
            Debug("Log to ioFTPD: '{0}'", message);
            Console.Write("!putlog {0}\n", message);
        }

        /// <summary>
        /// Writes a message to internal (scripts) log file <see cref="Config.FileNameInternalLog"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Internal(string message)
        {
            Debug("Log to Internal: '{0}'", message);
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(Config.FileNameInternalLog);
                LogInternal.WaitOne();
                using (FileStream stream = new FileStream(fileInfo.FullName,
                                                          FileMode.Append,
                                                          FileAccess.Write,
                                                          FileShare.None))
                {
                    using (StreamWriter streamWriter = new StreamWriter(stream))
                    {
                        DateTime dt = new DateTime(DateTime.Now.Ticks);
                        string line = dt.ToString("[yyyy-MM-dd HH:mm:ss] ") + message;
                        streamWriter.WriteLine(line);
                    }
                }
                LogInternal.ReleaseMutex();
            }
            catch (Exception exception)
            {
                Debug("Failed to write to internal log file because of '{0}'!\r\n{1}", exception.Message, exception.StackTrace);
            }
        }

        private static readonly Mutex LogMutex = new Mutex(false, "logMutex");
        private static readonly Mutex LogInternal = new Mutex(false, "logInternal");
    }
}