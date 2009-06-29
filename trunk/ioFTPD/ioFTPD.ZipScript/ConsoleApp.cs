using ioFTPD.Framework;

namespace ioFTPD.ZipScript
{
    public class ConsoleApp
    {
        public ConsoleApp(string[] args)
        {
            this.args = args;
        }

        public void Parse()
        {
            int numberOfArguments = args.Length;
            switch(numberOfArguments)
            {
                case 4:
                {
                    if (args[0].ToLower().Equals("upload"))
                    {
                        target = Target.Upload;
                    }
                    break;
                }

                default:
                {
                    target = Target.Unknown;
                    break;
                }
            }
        }

        public bool Process()
        {
            bool returnValue = false;
            switch(target)
            {
                case Target.Upload:
                {
                    Race race = new Race(args);
                    race.Parse();
                    race.Process();
                    returnValue = race.IsValid;
                    break;
                }

                default:
                {
                    return returnValue;
                }
            }
            return returnValue;
        }

        private readonly string[] args;
        private Target target;
    }
}