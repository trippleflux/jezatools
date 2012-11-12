using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace jeza.ioFTPD.Framework
{
    public class DataParserNfo : IDataParser
    {
        public DataParserNfo(Race race)
        {
            this.race = race;
        }

        public void Parse()
        {
            RaceMutex.WaitOne();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(race.CurrentRaceData.UploadFile);
            Log.Debug("Parsing: '{0}'", fileInfo.FullName);
            using (StreamReader streamReader = new StreamReader(fileInfo.FullName))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    if (line != null)
                    {
                        if (line.Length < 1)
                        {
                            continue;
                        }
                        Log.Debug("line: '{0}'", line);
                        if (IsImdbUrl(line))
                        {
                            line = Regex.Replace(line, @"\[|\]|\(|\)|\<|\>|\$|\""|\'|\!|\#", " ");
                            string[] split = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                            bool found = false;
                            foreach (string s in split)
                            {
                                if (IsImdbUrl(s))
                                {
                                    imdbUrl = s;
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            RaceMutex.ReleaseMutex();
        }

        public void Process()
        {
            Output output = new Output(race);
            output
                .Client(Config.ClientHead)
                .Client(Config.ClientFileName)
                .Client(Config.ClientFoot);

            if (String.IsNullOrEmpty(imdbUrl))
            {
                return;
            }
            Log.Debug("Process IMDB info");
            race.CurrentRaceData.LinkImdb = imdbUrl;
            if (Config.LogToIoFtpdUpdateNfo)
            {
                Log.IoFtpd(output.Format(Config.LogLineIoFtpdUpdateNfo));
            }
            if (Config.LogToInternalUpdateNfo)
            {
                Log.Internal(output.Format(Config.LogLineInternalUpdateNfo));
            }
            string imdbId = Extensions.GetImdbId(imdbUrl);
            if (String.IsNullOrEmpty(imdbId))
            {
                return;
            }
            Dictionary<string, object> imdbResponse = Extensions.GetImdbResponseForEventId(imdbId);
            if (Config.LogToIoFtpdUpdateImdb)
            {
                Log.IoFtpd(output.FormatImdb(Config.LogLineIoFtpdUpdateImdb, imdbResponse));
            }
            if (Config.LogToInternalUpdateImdb)
            {
                Log.Internal(output.FormatImdb(Config.LogLineInternalUpdateImdb, imdbResponse));
            }
        }

        private static bool IsImdbUrl(string line)
        {
            return line.IndexOf(".imdb.", StringComparison.InvariantCultureIgnoreCase) > -1;
        }

        private readonly Race race;
        private static readonly Mutex RaceMutex = new Mutex(false, "nfoMutex");
        private string imdbUrl;

        public string ImdbUrl
        {
            get { return imdbUrl; }
        }
    }
}