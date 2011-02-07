using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

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
            if(!race.IsValid)
            {
                return;
            }
            this.ReadRaceData(race);
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
            this.UpdateRaceData(race);
            Parse();
            this.ProcessRaceData(race);
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
            bool dizFound = false;
            using (ZipInputStream zipInputStream = new ZipInputStream(File.OpenRead(race.CurrentRaceData.UploadFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = zipInputStream.GetNextEntry()) != null)
                {
                    if (theEntry.IsFile)
                    {
                        Log.Debug("ZipEntry: '{0}'", theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);
                        if (fileName != String.Empty)
                        {
                            if (IsCorrectExtesion(fileName, ".diz"))
                            {
                                dizFound = true;
                                ExtractFile(zipInputStream, theEntry);
                            }
                            if (IsCorrectExtesion(fileName, ".nfo") && Config.ExtractNfoFromZip)
                            {
                                ExtractFile(zipInputStream, theEntry);
                            }
                        }
                    }
                }
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

        private void ExtractFile(Stream zipInputStream, ZipEntry theEntry)
        {
            Log.Debug("Extracting File : {0}", theEntry.Name);
            using (FileStream streamWriter = File.Create(Path.Combine(race.CurrentRaceData.DirectoryPath, theEntry.Name)))
            {
                byte[] data = new byte[2048];
                while (true)
                {
                    int size = zipInputStream.Read(data, 0, data.Length);
                    if (size > 0)
                    {
                        streamWriter.Write(data, 0, size);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static bool IsCorrectExtesion(string fileName, string extension)
        {
            return fileName.ToLowerInvariant().EndsWith(extension);
        }

        private readonly Race race;
    }
}