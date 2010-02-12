#region
using System;
using jeza.ioFTPD.Framework;

#endregion

namespace jeza.ioFTPD.ZipScript
{
    public class ConsoleApp
    {
        public ConsoleApp (string[] args)
        {
            this.args = args;
        }

        public void Parse ()
        {
            int numberOfArguments = args.Length;
            switch (numberOfArguments)
            {
                case 4:
                {
                    if (args [0].ToLower ().Equals ("upload"))
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

        public bool Process ()
        {
            bool returnValue;
            switch (target)
            {
                case Target.Upload:
                {
                    Race race = new Race (args);
                    race.Parse ();
                    race.Process ();
                    returnValue = race.IsValid;
                    break;
                }

                default:
                {
                    return false;
                }
            }
            Console.WriteLine ("Script returned code {0}", returnValue);
            DateTime endTime = new DateTime(DateTime.Now.Ticks);
            Console.WriteLine("Checked in {0}ms", (endTime - startTime).TotalMilliseconds);
            return returnValue;
        }

        private readonly string[] args;
        private Target target;
        readonly DateTime startTime = new DateTime(DateTime.Now.Ticks);
    }
}