using System.Linq;

namespace jeza.ioFTPD.Framework
{
    public class DataParser : IDataParser
    {
        public DataParser(Race race)
        {
            this.race = race;
        }

        public void Parse()
        {
            this.ReadRaceData(race);
        }

        public void Process()
        {
            Log.Debug("DataParser.Process()");
            if (GetCrc32ForFile(race.CurrentRaceData.FileName) != null)
            {
                race.LeadUser = race.GetLeadUser();
                race.LeadGroup = race.GetLeadGroup();
                this.UpdateRaceData(race);
                Parse();
                this.ProcessRaceData(race);
            }
            else
            {
                Log.Debug("CRC not found!");
                Output output = new Output(race);
                output
                    .Client(Config.ClientHead)
                    .Client(Config.ClientFileNameBadCrc)
                    .Client(Config.ClientFoot);
                race.IsValid = false;
            }
        }

        private string GetCrc32ForFile(string fileName)
        {
            return (from raceStats in race.RaceStats
                    where raceStats.FileName.Equals(fileName)
                    select raceStats.Crc32).FirstOrDefault();
        }

        private readonly Race race;
    }
}