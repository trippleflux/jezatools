using System.Text;

namespace jeza.ioFTPD.Framework
{
    public class ConsoleApp
    {
        public ConsoleApp(string[] args)
        {
            this.args = args;
            Log.Debug("args: '{0}'", ArgsToString);
        }

        public void Parse()
        {
            int numberOfArguments = args.Length;
            target = Target.Unknown;
            if (numberOfArguments > 0)
            {
                string firstArgument = args [0].ToLowerInvariant();
                //args: 'args[0]='rescan' '
                if (firstArgument.Equals("rescan"))
                {
                    target = Target.Rescan;
                }
                //args: 'args[0]='delete' args[1]='DELE' args[2]='tmvc714a.zip' '
                if (firstArgument.Equals("delete"))
                {
                    target = Target.Delete;
                }
                //args: 'args[0]='upload' args[1]='E:\temp\asd.jpg' args[2]='DEF35133' args[3]='/temp/asd.jpg' '
                if (firstArgument.Equals("upload"))
                {
                    target = Target.Upload;
                }
            }
        }

        public bool Process()
        {
            bool returnValue;
            switch (target)
            {
                case Target.Delete:
                {
                    Race race = new Race(args);
                    race.ParseDelete();
                    race.ProcessDelete();
                    returnValue = race.IsValid;
                    break;
                }

                case Target.Rescan:
                    {
                        Rescan rescan = new Rescan(args);
                        rescan.Parse();
                        rescan.Process();
                        returnValue = true;
                        break;
                    }

                case Target.Upload:
                {
                    Race race = new Race(args);
                    race.ParseUpload();
                    race.Process();
                    returnValue = race.IsValid;
                    break;
                }

                default:
                {
                    return false;
                }
            }
            Log.Debug("Script returned code {0}", returnValue);
            return returnValue;
        }

        private string ArgsToString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;
                foreach (string arg in args)
                {
                    sb.AppendFormat("args[{0}]='{1}' ", i++, arg);
                }
                return sb.ToString();
            }
        }

        private readonly string[] args;
        private Target target;
    }
}