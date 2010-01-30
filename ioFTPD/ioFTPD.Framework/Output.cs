#region
using System;

#endregion

namespace ioFTPD.Framework
{
    public class Output
    {
        public Output (Race race)
        {
            raceData = race.RaceData;
        }

        public Output Client (string line)
        {
            Console.WriteLine (Format (line));
            return this;
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
                        args [i] = raceData.FileName;
                        break;
                    }
                    case "totalfilesexpected":
                    {
                        args [i] = raceData.TotalFilesExpected.ToString ();
                        break;
                    }
                    case "totalfilesuploaded":
                    {
                        args [i] = raceData.TotalFilesUploaded.ToString ();
                        break;
                    }
                    case "totalbytesuploaded":
                    {
                        args [i] = raceData.TotalBytesUploaded.ToString ();
                        break;
                    }
                    case "totalmbytesuploaded":
                    {
                        args [i] = raceData.TotalMBytesUploaded.ToString ();
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

        private readonly RaceData raceData;
    }
}