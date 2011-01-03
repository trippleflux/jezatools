#region
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TagLib;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class Output
    {
        public Output(RescanStatsData rescanStatsData)
        {
            Console.WriteLine("!buffer off\n");
            this.rescanStatsData = rescanStatsData;
        }

        public Output (Race race)
        {
            this.race = race;
        }

        public Output ClientRescan(string line)
        {
            Console.WriteLine(FormatCrc32(line));
            return this;
        }

        public Output Client(string line)
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
            if (MinimumLength(line))
            {
                return "";
            }
            if (NotFormated(line))
            {
                return line;
            }
            string[] sections = line.Split (SplitChar);
            string text = sections [0];
            string[] args = sections [1].Split (' ');
            int count = args.Length;
            try
            {
                if (race != null)
                {
                    if (race.CurrentUploadData != null)
                    {
                        string uploadFile = race.CurrentUploadData.UploadFile;
                        if (!System.IO.File.Exists(uploadFile) || String.IsNullOrEmpty(uploadFile))
                        {
                            return line;
                        }
                        File file = File.Create (uploadFile);
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
                }
            }
            catch (CorruptFileException)
            {
            }
            text = String.Format (new MyFormat (), text, args);
            return text;
        }

        private static bool MinimumLength(string line)
        {
            if (line.Length < 2)
            {
                return true;
            }
            return false;
        }

        private static bool NotFormated(string line)
        {
            if (line.IndexOf(SplitChar) == -1)
            {
                return true;
            }
            return false;
        }

        public string FormatUserStats
            (int possition,
             RaceStatsUsers stats,
             string line)
        {
            if (MinimumLength(line))
            {
                return "";
            }
            if (NotFormated(line))
            {
                return line;
            }
            string[] sections = line.Split (SplitChar);
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
                        args [i] = (stats.BytesUplaoded / 1024).ToString ();
                        break;
                    }
                    case "megabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024*1024).ToString ();
                        break;
                    }
                    case "gigabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024*1024*1204).ToString ();
                        break;
                    }
                    case "formatbytesuploaded":
                    {
                        args [i] = FormatSize (stats.BytesUplaoded);
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
            if (MinimumLength(line))
            {
                return "";
            }
            if (NotFormated(line))
            {
                return line;
            }
            string[] sections = line.Split (SplitChar);
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
                        args [i] = (stats.BytesUplaoded / 1024).ToString ();
                        break;
                    }
                    case "megabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024*1024).ToString ();
                        break;
                    }
                    case "gigabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024*1024*1024).ToString ();
                        break;
                    }
                    case "formatbytesuploaded":
                    {
                        args [i] = FormatSize (stats.BytesUplaoded);
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
            if (MinimumLength(line))
            {
                return "";
            }
            if (NotFormated(line))
            {
                return line;
            }
            string[] sections = line.Split (SplitChar);
            string text = sections [0];
            string[] args = sections [1].Split (' ');
            ArrayList unknownArgs = new ArrayList();
            int count = args.Length;
            for (int i = 0; i < count; i++)
            {
                string arg = args [i].ToLowerInvariant();
                switch (arg)
                {
                    case "filename":
                    {
                        args [i] = race.CurrentUploadData.FileName;
                        break;
                    }
                    case "releasename":
                    {
                        args[i] = race.CurrentUploadData.DirectoryName;
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
                        args [i] = race.ProgressBar;
                        break;
                    }
                    case "percentcomplete":
                    {
                        args [i] = race.PercentComplete.ToString ();
                        break;
                    }
                    default:
                    {
                        unknownArgs.Add(arg);
                        break;
                    }
                }
            }
            if (unknownArgs.Count > 0)
            {
                //text = FormatMp3(text + SplitChar + String.Join(" ", args) +" " + String.Join(" ", unknownArgs.ToArray(typeof(string)) as string[]));
                text = FormatMp3(text + SplitChar + String.Join(" ", args));
            }
            text = String.Format(new MyFormat(), text, args);
            return text;
        }

        public string FormatCrc32(string line)
        {
            if (MinimumLength(line))
            {
                return "";
            }
            if (NotFormated(line))
            {
                return line;
            }
            string[] sections = line.Split(SplitChar);
            string text = sections[0];
            string[] args = sections[1].Split(' ');
            int count = args.Length;
            for (int i = 0; i < count; i++)
            {
                switch (args[i].ToLower())
                {
                    case "filename":
                        {
                            args[i] = rescanStatsData.FileName;
                            break;
                        }
                    case "expectedcrc32":
                        {
                            args[i] = rescanStatsData.ExpectedCrc32Value;
                            break;
                        }
                    case "actualcrc32":
                        {
                            args[i] = rescanStatsData.ActualCrc32Value;
                            break;
                        }
                    case "status":
                        {
                            args[i] = rescanStatsData.Status;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            text = String.Format(new MyFormat(), text, args);
            return text;
        }

        public string FormatSize (UInt64 bytes)
        {
            UInt64 formatedSize = bytes;
            string[] postFix = new string[] {"B", "kB", "MB", "GB", "TB"};
            int count = 0;
            while (formatedSize > 1024)
            {
                formatedSize = formatedSize / 1024;
                count++;
            }
            return String.Format (CultureInfo.InvariantCulture, "{0}{1}", formatedSize, postFix [count]);
        }

        private readonly Race race;
        private const char SplitChar = '¤';
        private readonly RescanStatsData rescanStatsData;
    }
}