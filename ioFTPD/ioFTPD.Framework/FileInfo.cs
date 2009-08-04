#region
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

#endregion

namespace ioFTPD.Framework
{
    public class FileInfo
    {
        public void ParseRaceFile (Race race)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo (Path.Combine (race.DirectoryPath, Config.FileNameRace));
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
                    for (int i = 0; i < totalFiles; i++)
                    {
                        stream.Seek (256 * i, SeekOrigin.Begin);
                        sfvData.Add (reader.ReadString (), reader.ReadString ());
                        if (reader.ReadBoolean ())
                        {
                            uploadedFiles++;
                        }
                    }
                    race.TotalFilesExpected = totalFiles;
                    race.TotalFilesUploaded = uploadedFiles;
                }
            }
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
            System.IO.FileInfo fileInfo = new System.IO.FileInfo (fileName);
            fileInfo.Open (FileMode.Create, FileAccess.ReadWrite, FileShare.Delete);
        }

        public void CreateSfvRaceDataFile (Race race)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo (Path.Combine (race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.OpenOrCreate,
                                                       FileAccess.ReadWrite,
                                                       FileShare.None))
            {
                using (BinaryWriter writer = new BinaryWriter (stream))
                {
                    stream.Seek (0, SeekOrigin.Begin);
                    writer.Write (race.TotalFilesExpected);
                    int count = 1;
                    foreach (KeyValuePair<string, string> keyValuePair in race.SfvData)
                    {
                        stream.Seek (count * 256, SeekOrigin.Begin);
                        writer.Write (keyValuePair.Key);    //file name
                        writer.Write (keyValuePair.Value);  //CRC32
                        writer.Write (false); //was file already uploaded
                        writer.Write (0); //file Size
                        writer.Write (0); //upload speed
                        writer.Write (String.Empty); //username
                        writer.Write (String.Empty); //groupname
                        count++;
                    }
                }
            }
        }

        public void DeleteFiles
            (string path,
             string extension)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo (path);
            System.IO.FileInfo[] files = directoryInfo.GetFiles ("*" + extension);
            foreach (var file in files)
            {
                file.Delete ();
            }
        }

        private static bool IsHex (string crc32)
        {
            int output;
            return Int32.TryParse (crc32, NumberStyles.HexNumber, null, out output);
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

        public void UpdateRaceData (Race race)
        {
            throw new NotImplementedException ();
        }
    }
}