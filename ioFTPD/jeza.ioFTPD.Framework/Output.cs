#region
using System;

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
                    default:
                    {
                        break;
                    }
                }
            }
            text = String.Format (new MyFormat (), text, args);
            return text;
        }

        private readonly Race race;
    }
}