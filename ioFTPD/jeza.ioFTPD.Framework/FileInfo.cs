#region
using System.Collections.Generic;
using System.IO;
using System.Threading;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class FileInfo
    {
        public void UpdateRaceData (Race race)
        {
            int position = 0;
            string fileName = "", fileCrc = "";
            System.IO.FileInfo fileInfo =
                new System.IO.FileInfo (Path.Combine (race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
            RaceMutex.WaitOne ();
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    for (int i = 1; i <= race.TotalFilesExpected; i++)
                    {
                        stream.Seek (256 * i, SeekOrigin.Begin);
                        fileName = reader.ReadString ();
                        if (fileName.Equals (race.CurrentUploadData.FileName))
                        {
                            position = i;
                            fileCrc = reader.ReadString ();
                            break;
                        }
                    }
                }
            }
            if (position > 0)
            {
                using (FileStream stream = new FileStream (fileInfo.FullName,
                                                           FileMode.Open,
                                                           FileAccess.Write,
                                                           FileShare.None))
                {
                    using (BinaryWriter writer = new BinaryWriter (stream))
                    {
                        stream.Seek (position * 256, SeekOrigin.Begin);
                        writer.Write (fileName);
                        writer.Write (fileCrc);
                        writer.Write (true);
                        writer.Write (race.CurrentUploadData.FileSize); //file Size
                        writer.Write (race.CurrentUploadData.Speed); //upload speed
                        writer.Write (race.CurrentUploadData.UserName); //username
                        writer.Write (race.CurrentUploadData.GroupName); //groupname
                    }
                }
                //race.TotalBytesUploaded += (UInt64) race.CurrentUploadData.FileSize;
            }
            RaceMutex.ReleaseMutex ();
        }

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

        public string GetCrc32ForFile (string fileName)
        {
            foreach (KeyValuePair<string, string> keyValuePair in sfvData)
            {
                if (keyValuePair.Key.Equals (fileName))
                {
                    return keyValuePair.Value;
                }
            }
            return null;
        }

        public Dictionary<string, string> SfvData
        {
            get { return sfvData; }
        }

        private readonly Dictionary<string, string> sfvData = new Dictionary<string, string> ();
        private static readonly Mutex RaceMutex = new Mutex (false, "raceMutex");
        private static readonly Mutex OByteMutex = new Mutex (false, "OByteMutex");
    }
}