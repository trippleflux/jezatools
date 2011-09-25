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
#if DEBUG
            Debug(line, null);
#endif
        }

        /// <summary>
        /// Write debug message to spedified file.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void DebugToFile(string line,
                                 string fileName)
        {
#if DEBUG
            WriteToFile(line, fileName, null);
#endif
        }

        public static void Debug(string line,
                                 params object[] args)
        {
#if DEBUG
            string path = Environment.GetEnvironmentVariable("PATH");
            if ((path == null) || (path.IndexOf(';') > -1))
            {
                path = "";
            }
            string fileName = Path.Combine(path, Config.FileNameDebug);
            WriteToFile(fileName, line, args);
#endif
        }

        private static void WriteToFile(string fileName,
                                        string line,
                                        object[] args)
        {
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
                    }
                    else
                    {
                        streamWriter.WriteLine(line);
                    }
                }
            }
            LogMutex.ReleaseMutex();
        }

        /// <summary>
        /// Writes a message to ioFTPD log file (ioFTPD\logs\ioFTPD.log).
        /// </summary>
        /// <param name="message">The message.</param>
        public static void IoFtpd(string message)
        {
            Console.Write("!putlog {0}\n", message);
        }

        /// <summary>
        /// Writes a message to internal (scripts) log file <see cref="Config.FileNameInternalLog"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Internal(string message)
        {
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