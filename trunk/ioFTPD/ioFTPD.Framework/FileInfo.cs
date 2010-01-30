#region
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;

#endregion

namespace ioFTPD.Framework
{
    public class FileInfo
    {
        public void ParseRaceFile (Race race)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(race.RaceData.DirectoryPath, Config.FileNameRace));
            RaceMutex.WaitOne ();
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.OpenOrCreate,
                                                       FileAccess.ReadWrite,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    stream.Seek (0, SeekOrigin.Begin);
                    int totalFiles = reader.ReadInt32 ();
                    int uploadedFiles = 0;
                    UInt64 totalBytes = 0;
                    //UInt64 totalSpeed= 0;
                    for (int i = 1; i <= totalFiles; i++)
                    {
                        stream.Seek (256 * i, SeekOrigin.Begin);
                        string fileNmae = reader.ReadString ();
                        string crc32 = reader.ReadString ();
                        sfvData.Add (fileNmae, crc32);
                        if (reader.ReadBoolean ())
                        {
                            uploadedFiles++;
                        }
                        UInt64 size = reader.ReadUInt64 ();
                        totalBytes += size;
                        //UInt64 speed = reader.ReadUInt64 ();
                        //totalSpeed += speed;
                        //string username = reader.ReadString();
                        //string groupname = reader.ReadString();
                    }
                    race.RaceData.TotalFilesExpected = totalFiles;
                    race.RaceData.TotalFilesUploaded = uploadedFiles;
                    race.RaceData.TotalBytesUploaded = totalBytes;
                }
            }
            RaceMutex.ReleaseMutex ();
        }

        public void UpdateRaceData (Race race)
        {
            int position = 0;
            string fileName = "", fileCrc = "";
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(race.RaceData.DirectoryPath, Config.FileNameRace));
            RaceMutex.WaitOne ();
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    for (int i = 1; i <= race.RaceData.TotalFilesExpected; i++)
                    {
                        stream.Seek (256 * i, SeekOrigin.Begin);
                        fileName = reader.ReadString ();
                        if (fileName.Equals(race.RaceData.FileName))
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
                        writer.Write(race.RaceData.FileSize); //file Size
                        writer.Write(race.RaceData.Speed); //upload speed
                        writer.Write(race.RaceData.UserName); //username
                        writer.Write(race.RaceData.GroupName); //groupname
                    }
                }
                race.RaceData.TotalFilesUploaded++;
                race.RaceData.TotalBytesUploaded += (UInt64)race.RaceData.FileSize;
            }
            RaceMutex.ReleaseMutex ();
        }

        /// <summary>
        /// Parse CRC32 values for filenames.
        /// </summary>
        /// <param name="fileName">Filename with full path.</param>
        /// <remarks>Spaces in filename are not supported.</remarks>
        /// 
        public void ParseSfv (string fileName)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo (fileName);
            using (StreamReader streamReader = new StreamReader (fileInfo.FullName))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine ();
                    if ((line [0].Equals (';')) || (line.Length < 10))
                    {
                        continue;
                    }
                    if (line.IndexOf (' ') == -1)
                    {
                        throw new ArgumentOutOfRangeException (String.Format (CultureInfo.InvariantCulture,
                                                                              "Line in SFV file should be separated with [SPACE]. Line '{0}'",
                                                                              line));
                    }
                    //[FILENAME][SPACE][CRC32]
                    string[] data = line.Split (' ');
                    string key = data [0];
                    string crc32 = data [1];
                    if (sfvData.ContainsKey (key))
                    {
                        throw new ArgumentException (String.Format (CultureInfo.InvariantCulture,
                                                                    "Duplicated entry in SFV file [{0}]",
                                                                    key));
                    }
                    if (!IsHex (crc32))
                    {
                        throw new ArgumentException (String.Format (CultureInfo.InvariantCulture,
                                                                    "Incorrect CRC32 [{0}]. Line '{1}'",
                                                                    crc32,
                                                                    line));
                    }
                    sfvData.Add (key, crc32);
                }
            }
        }

        public void Create0ByteFile (string fileName)
        {
            using(FileStream stream = File.Open (fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                stream.Flush();
            }
        }

        public void CreateSfvRaceDataFile (Race race)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(race.RaceData.DirectoryPath, Config.FileNameRace));
            RaceMutex.WaitOne ();
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.OpenOrCreate,
                                                       FileAccess.ReadWrite,
                                                       FileShare.None))
            {
                using (BinaryWriter writer = new BinaryWriter (stream))
                {
                    stream.Seek (0, SeekOrigin.Begin);
                    writer.Write(race.RaceData.TotalFilesExpected);
                    int count = 1;
                    foreach (KeyValuePair<string, string> keyValuePair in race.SfvData)
                    {
                        stream.Seek (count * 256, SeekOrigin.Begin);
                        writer.Write (keyValuePair.Key); //file name
                        writer.Write (keyValuePair.Value); //CRC32
                        writer.Write (false); //was file already uploaded
                        writer.Write (0); //file Size
                        writer.Write (0); //upload speed
                        writer.Write (String.Empty); //username
                        writer.Write (String.Empty); //groupname
                        count++;
                    }
                }
            }
            RaceMutex.ReleaseMutex ();
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

        private static bool IsHex (string crc32)
        {
            int output;
            return Int32.TryParse (crc32, NumberStyles.HexNumber, null, out output);
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