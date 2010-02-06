#region
using System.IO;
using System.Threading;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class FileInfo
    {
        public static void Create0ByteFile (string fileName)
        {
            using (FileStream stream = File.Open (fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                stream.Flush ();
            }
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="fileName">Name of the file.</param>
        public void DeleteFile
            (string path,
             string fileName)
        {
            string file = Path.Combine (path, fileName);
            DeleteFile (file);
        }

        private static void DeleteFile (string file)
        {
            if (File.Exists (file))
            {
                do
                {
                    Thread.Sleep (100);
                } while (IsFileOpen (file));
                File.Delete (file);
            }
        }

        private static bool IsFileOpen (string fileName)
        {
            FileStream s = null;
            try
            {
                s = File.Open (fileName,
                               FileMode.Open,
                               FileAccess.ReadWrite,
                               FileShare.None);
                return false;
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (s != null)
                {
                    s.Close ();
                }
            }
        }

        /// <summary>
        /// Deletes all files with specified extension.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="extension">The extension.</param>
        public void DeleteFiles
            (string path,
             string extension)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo (path);
            System.IO.FileInfo[] files = directoryInfo.GetFiles ("*" + extension);
            foreach (System.IO.FileInfo file in files)
            {
                DeleteFile (file.FullName);
            }
        }

        /// <summary>
        /// Deletes the files that starts with specified string.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="prefix">The prefix.</param>
        public void DeleteFilesThatStartsWith
            (string path,
             string prefix)
        {
            OByteMutex.WaitOne ();
            DirectoryInfo directoryInfo = new DirectoryInfo (path);
            System.IO.FileInfo[] files = directoryInfo.GetFiles (prefix + "*");
            foreach (System.IO.FileInfo file in files)
            {
                DeleteFile (file.FullName);
            }
            OByteMutex.ReleaseMutex ();
        }

        private static readonly Mutex OByteMutex = new Mutex (false, "OByteMutex");
    }
}