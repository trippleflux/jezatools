#region
using System;
using System.Collections.Generic;
using System.Globalization;
using TagLib;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class Output
    {
        public Output (Race race)
        {
            this.race = race;
        }

        public Output Client (string line)
        {
            Console.WriteLine (Format (line));
            return this;
        }

        public Output ClientMp3 (string line)
        {
            Console.WriteLine (FormatMp3 (line));
            return this;
        }

        public Output ClientStatsUsers (string line)
        {
            List<RaceStatsUsers> stats = race.GetUserStats ();
            int possition = 1;
            foreach (RaceStatsUsers item in stats)
            {
                Console.WriteLine (FormatUserStats (possition, item, line));
                possition++;
            }
            return this;
        }

        public Output ClientStatsGroups (string line)
        {
            List<RaceStatsGroups> stats = race.GetGroupStats ();
            int possition = 1;
            foreach (RaceStatsGroups item in stats)
            {
                Console.WriteLine (FormatGroupStats (possition, item, line));
                possition++;
            }
            return this;
        }

        private string FormatMp3 (string line)
        {
            if (line.Length < 2)
            {
                return "";
            }
            const char splitChar = '¤';
            if (line.IndexOf (splitChar) == -1)
            {
                return line;
            }
            string[] sections = line.Split (splitChar);
            string text = sections [0];
            string[] args = sections [1].Split (' ');
            int count = args.Length;
            try
            {
                File file = File.Create (race.CurrentUploadData.UploadFile);
                for (int i = 0; i < count; i++)
                {
                    switch (args [i].ToLower ())
                    {
                        case "artist":
                        {
                            args [i] = file.Tag.FirstAlbumArtist;
                            break;
                        }
                        case "album":
                        {
                            args [i] = file.Tag.Album;
                            break;
                        }
                        case "genre":
                        {
                            args [i] = file.Tag.FirstGenre;
                            break;
                        }
                        case "year":
                        {
                            args [i] = file.Tag.Year.ToString ();
                            break;
                        }
                        case "title":
                        {
                            args [i] = file.Tag.Title;
                            break;
                        }
                        case "tracknumber":
                        {
                            args [i] = file.Tag.Track.ToString ();
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                }
            }
            catch (CorruptFileException)
            {
            }
            text = String.Format (new MyFormat (), text, args);
            return text;
        }

        public string FormatUserStats
            (int possition,
             RaceStatsUsers stats,
             string line)
        {
            if (line.Length < 2)
            {
                return "";
            }
            const char splitChar = '¤';
            if (line.IndexOf (splitChar) == -1)
            {
                return line;
            }
            string[] sections = line.Split (splitChar);
            string text = sections [0];
            string[] args = sections [1].Split (' ');
            int count = args.Length;
            for (int i = 0; i < count; i++)
            {
                switch (args [i].ToLower ())
                {
                    case "possition":
                    {
                        args [i] = possition.ToString ();
                        break;
                    }
                    case "username":
                    {
                        args [i] = stats.UserName;
                        break;
                    }
                    case "groupname":
                    {
                        args [i] = stats.GroupName;
                        break;
                    }
                    case "kilobytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1000).ToString ();
                        break;
                    }
                    case "megabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1000000).ToString ();
                        break;
                    }
                    case "gigabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1000000000).ToString ();
                        break;
                    }
                    case "formatbytesuploaded":
                    {
                        args[i] = FormatSize(stats.BytesUplaoded);
                        break;
                    }
                    case "averagespeed":
                    {
                        args [i] = stats.Speed.ToString ();
                        break;
                    }
                    case "filesuploaded":
                    {
                        args [i] = stats.FilesUplaoded.ToString ();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            text = String.Format (new MyFormat (), text, args);
            return text;
        }

        public string FormatGroupStats
            (int possition,
             RaceStatsGroups stats,
             string line)
        {
            if (line.Length < 2)
            {
                return "";
            }
            const char splitChar = '¤';
            if (line.IndexOf (splitChar) == -1)
            {
                return line;
            }
            string[] sections = line.Split (splitChar);
            string text = sections [0];
            string[] args = sections [1].Split (' ');
            int count = args.Length;
            for (int i = 0; i < count; i++)
            {
                switch (args [i].ToLower ())
                {
                    case "possition":
                    {
                        args [i] = possition.ToString ();
                        break;
                    }
                    case "groupname":
                    {
                        args [i] = stats.GroupName;
                        break;
                    }
                    case "kilobytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1000).ToString ();
                        break;
                    }
                    case "megabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1000000).ToString ();
                        break;
                    }
                    case "gigabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1000000000).ToString ();
                        break;
                    }
                    case "formatbytesuploaded":
                    {
                        args[i] = FormatSize(stats.BytesUplaoded);
                        break;
                    }
                    case "averagespeed":
                    {
                        args [i] = stats.Speed.ToString ();
                        break;
                    }
                    case "filesuploaded":
                    {
                        args [i] = stats.FilesUplaoded.ToString ();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            text = String.Format (new MyFormat (), text, args);
            return text;
        }

        public string Format (string line)
        {
            if (line.Length < 2)
            {
                return "";
            }
            const char splitChar = '¤';
            if (line.IndexOf (splitChar) == -1)
            {
                return line;
            }
            string[] sections = line.Split (splitChar);
            string text = sections [0];
            string[] args = sections [1].Split (' ');
            int count = args.Length;
            for (int i = 0; i < count; i++)
            {
                switch (args [i].ToLower ())
                {
                    case "filename":
                    {
                        args [i] = race.CurrentUploadData.FileName;
                        break;
                    }
                    case "totalfilesexpected":
                    {
                        args [i] = race.TotalFilesExpected.ToString ();
                        break;
                    }
                    case "totalfilesuploaded":
                    {
                        args [i] = race.TotalFilesUploaded.ToString ();
                        break;
                    }
                    case "totalbytesuploaded":
                    {
                        args [i] = race.TotalBytesUploaded.ToString ();
                        break;
                    }
                    case "totalmegabytesuploaded":
                    {
                        args [i] = race.TotalMegaBytesUploaded.ToString ();
                        break;
                    }
                    case "formatbytesuploaded":
                    {
                        args [i] = FormatSize (race.TotalBytesUploaded);
                        break;
                    }
                    case "progressbar":
                    {
                        args[i] = race.ProgressBar;
                        break;
                    }
                    case "percentcomplete":
                    {
                        args[i] = race.PercentComplete.ToString();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            text = String.Format (new MyFormat (), text, args);
            return text;
        }

        public string FormatSize(UInt64 bytes)
        {
            UInt64 formatedSize = bytes;
            string[] postFix = new string[] { "B", "kB", "MB", "GB", "TB" };
            int count = 0;
            while (formatedSize > 1000)
            {
                formatedSize = formatedSize / 1000;
                count++;
            }
            return String.Format(CultureInfo.InvariantCulture, "{0}{1}", formatedSize, postFix[count]);
        }

        private readonly Race race;
    }
}