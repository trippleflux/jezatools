using System.IO;
using System.Text;
using System.Threading;

namespace jeza.ioFTPD.Framework
{
    public static class Extensions
    {
        public static string FormatArgs(this IData data, string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in args)
            {
                sb.AppendFormat("{0} ", s);
            }
            return sb.ToString().Trim();
        }

        public static void WriteStatsToMesasageFile(this IDataParser dataParser, Race race, bool isMp3Race)
        {
            MessageMutex.WaitOne();
            Log.Debug("WriteStatsToMesasageFile");
            System.IO.FileInfo fileInfo =
                new System.IO.FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameIoFtpdMessage));
            using (FileStream fileStream = new FileStream(fileInfo.FullName,
                                                          FileMode.OpenOrCreate,
                                                          FileAccess.ReadWrite,
                                                          FileShare.None))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream))
                {
                    Output output = new Output(race);
                    if (isMp3Race)
                    {
                        textWriter.WriteLine(output.FormatMp3(Config.MessageMp3InfoHead));
                        textWriter.WriteLine(output.FormatMp3(Config.MessageMp3Info));
                    }
                    textWriter.WriteLine(output.Format(Config.MessageStatsUsersHead));
                    textWriter.Write(output.MessageStatsUsers(Config.MessageStatsUsers, Config.MaxNumberOfUserStats));
                    textWriter.WriteLine(output.Format(Config.MessageStatsGroupsHead));
                    textWriter.Write(output.MessageStatsGroups(Config.MessageStatsGroups, Config.MaxNumberOfGroupStats));
                    textWriter.WriteLine(output.Format(Config.MessageFoot));
                }
            }
            MessageMutex.ReleaseMutex();
        }

        private static readonly Mutex MessageMutex = new Mutex(false, "messageMutex");
    }
}