namespace jeza.ioFTPD.Framework
{
    public class DataParserDelete : IDataParser
    {
        public DataParserDelete(Race race)
        {
            this.race = race;
        }

        public void Parse()
        {
            Extensions.ReadRaceData(race);
        }

        public void Process()
        {
            Log.Debug("DataParserDelete.Process()");
            Extensions.UpdateRaceData(race);
            Parse();
            Extensions.ProcessRaceData(race);
        }

        private readonly Race race;
    }
}