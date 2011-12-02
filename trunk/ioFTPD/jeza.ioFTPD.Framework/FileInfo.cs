#region
using System;
using System.IO;
using System.Threading;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class FileInfo
    {
        /// <summary>
        /// Creates new empty file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static void Create0ByteFile(string fileName)
        {
            Log.Debug("Create0ByteFile: {0}", fileName);
            try
            {
                using (FileStream stream = File.Open(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                {
                    stream.Flush();
                }
            }
            catch (Exception exception)
            {
                Log.Debug(exception.ToString());
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of the current file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>File size or 0.</returns>
        public UInt64 GetFileSize(string fileName)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
            return File.Exists(fileName) ? (UInt64) fileInfo.Length : 0;
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
            string file = Misc.PathCombine(path, fileName);
            DeleteFile(file);
        }

        public static void DeleteFile(string fileName)
        {
            Log.Debug("DeleteFile: '{0}'", fileName);
            if (File.Exists(fileName))
            {
                do
                {
                    Thread.Sleep(100);
                } while (IsFileOpen(fileName));
                File.Delete(fileName);
            }
            else
            {
                Log.Debug("File not found! '{0}'", fileName);
            }
        }

        private static bool IsFileOpen(string fileName)
        {
            FileStream s = null;
            try
            {
                s = File.Open(fileName,
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
                    s.Close();
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
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            System.IO.FileInfo[] files = directoryInfo.GetFiles("*" + extension);
            foreach (System.IO.FileInfo file in files)
            {
                DeleteFile(file.FullName);
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
            OByteMutex.WaitOne();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            System.IO.FileInfo[] files = directoryInfo.GetFiles(prefix + "*");
            foreach (System.IO.FileInfo file in files)
            {
                DeleteFile(file.FullName);
            }
            OByteMutex.ReleaseMutex();
        }

        public void DeleteFoldersThatStartsWith
            (string path,
             string prefix)
        {
            FolderMutex.WaitOne();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            DirectoryInfo[] directoriesToRemove = directoryInfo.GetDirectories(prefix + "*", SearchOption.TopDirectoryOnly);
            foreach (DirectoryInfo folder in directoriesToRemove)
            {
                folder.FullName.RemoveFolder();
            }
            FolderMutex.ReleaseMutex();
        }

        /// <summary>
        /// Creates the folder.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void CreateFolder(string path)
        {
            Log.Debug("CreateFolder '{0}'", path);
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception exception)
            {
                Log.Debug(exception.ToString());
            }
        }

        private static readonly Mutex OByteMutex = new Mutex(false, "OByteMutex");
        private static readonly Mutex FolderMutex = new Mutex(false, "FolderMutex");
    }
}