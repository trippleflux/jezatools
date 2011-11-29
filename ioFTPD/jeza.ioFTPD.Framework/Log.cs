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
        [Conditional("DEBUG")]
        public static void Debug(string line)
        {
            Debug(line, null);
        }

        /// <summary>
        /// Write debug message to spedified file.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="fileName">Name of the file.</param>
        [Conditional("DEBUG")]
        public static void DebugToFile(string line,
                                       string fileName)
        {
            WriteToFile(line, fileName, null);
        }

        [Conditional("DEBUG")]
        public static void Debug(string line,
                                 params object[] args)
        {
            string path = Environment.GetEnvironmentVariable("PATH");
            if ((path == null) || (path.IndexOf(';') > -1))
            {
                path = "";
            }
            string fileName = Misc.PathCombine(path, Config.FileNameDebug);
            WriteToFile(fileName, line, args);
        }

        private static void WriteToFile(string fileName,
                                        string line,
                                        object[] args)
        {
            try
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
            Log.Debug("Log to ioFTPD: '{0}'", message);
            Console.Write("!putlog {0}\n", message);
        }

        /// <summary>
        /// Writes a message to internal (scripts) log file <see cref="Config.FileNameInternalLog"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Internal(string message)
        {
            Log.Debug("Log to Internal: '{0}'", message);
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