#region
using System;
using System.Text;
using jeza.ioFTPD.Framework;

#endregion

namespace jeza.ioFTPD.ZipScript
{
    public class ConsoleApp
    {
        public ConsoleApp(string[] args)
        {
            this.args = args;
            startTime = new DateTime(DateTime.Now.Ticks);
            Log.Debug("args: {0}", ArgsToString);
        }

        public void Parse()
        {
            int numberOfArguments = args.Length;
            switch (numberOfArguments)
            {
                case 1:
                {
                    if (args[0].ToLower().Equals("rescan"))
                    {
                        target = Target.Rescan;
                    }
                    break;
                }

                case 4:
                {
                    if (args [0].ToLower().Equals("upload"))
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
            bool returnValue;
            switch (target)
            {
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
                    race.Parse();
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
            DateTime endTime = new DateTime(DateTime.Now.Ticks);
            Console.WriteLine("Checked in {0}ms", (endTime - startTime).TotalMilliseconds);
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
        private readonly DateTime startTime;
    }
}