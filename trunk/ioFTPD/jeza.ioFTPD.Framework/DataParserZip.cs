namespace jeza.ioFTPD.Framework
{
    public class DataParserZip : IDataParser
    {
        public DataParserZip(Race race)
        {
            this.race = race;
        }

        public void Parse()
        {
            ExtractDiz();
            if (!race.IsValid)
            {
                return;
            }
            Extensions.ReadRaceData(race);
        }

        public void Process()
        {
            if (!race.IsValid)
            {
                return;
            }
            Log.Debug("DataParserZip.Process()");
            race.LeadUser = race.GetLeadUser();
            race.LeadGroup = race.GetLeadGroup();
            Extensions.UpdateRaceData(race);
            Parse();
            Extensions.ProcessRaceData(race);
        }

        private void ExtractDiz()
        {
            Log.Debug("ExtractDiz");
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(race.RaceFile);
            if (fileInfo.Exists)
            {
                Log.Debug("Race file exists...");
                return;
            }
            bool dizFound = race.CurrentRaceData.UploadFile.ExtractFromArchive(".diz");
            if (Config.ExtractNfoFromZip)
            {
                race.CurrentRaceData.UploadFile.ExtractFromArchive(".nfo");
            }
            if (dizFound)
            {
                DataParserDiz dataParserDiz = new DataParserDiz(race);
                dataParserDiz.Parse();
                dataParserDiz.Process();
                return;
            }
            Log.Debug("DIZ file not found in ZIP");
            race.IsValid = false;
            Output output = new Output(race);
            output
                .Client(Config.ClientHead)
                .Client(Config.ClientFileNameNoDiz)
                .Client(Config.ClientFoot);
        }

        private readonly Race race;
    }
}