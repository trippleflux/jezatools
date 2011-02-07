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
            this.ReadRaceData(race);
        }

        public void Process()
        {
            Log.Debug("DataParserDelete.Process()");
            this.UpdateRaceData(race);
            Parse();
            this.ProcessRaceData(race);
        }

        private readonly Race race;
    }
}