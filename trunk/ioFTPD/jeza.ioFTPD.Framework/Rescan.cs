#region
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class Rescan : IoEnvironment, IData
    {
        public Rescan(string[] args)
        {
            this.args = args;
            SourceFolder = GetRealPath();
            rescanFolder = args.Length < 2;
        }

        public void Parse()
        {
            Log.Debug("SourceFolder: '{0}'", SourceFolder);
            Log.Debug("args: '{0}'", this.FormatArgs(args));
            Log.Debug("rescanFolder: '{0}'", rescanFolder);
            directoryInfo = new DirectoryInfo(SourceFolder);
            System.IO.FileInfo[] sfvFiles = directoryInfo.GetFiles("*.sfv");
            if (sfvFiles.Length >= 1)
            {
                string sfvFile = sfvFiles [0].FullName;
                dataParserSfv = new DataParserSfv(sfvFile);
                dataParserSfv.Parse();
            }
        }

        public void Process()
        {
            if (dataParserSfv != null)
            {
                if (dataParserSfv.SfvData != null)
                {
                    if (dataParserSfv.SfvData.Count > 0)
                    {
                        Output outputHead = new Output(new Race(null));
                        outputHead.Client(Config.ClientCrc32Head);
                        rescanStats.TotalFiles = dataParserSfv.SfvData.Count;
                        foreach (KeyValuePair<string, string> keyValuePair in dataParserSfv.SfvData)
                        {
                            if (!rescanFolder && !(keyValuePair.Key.ToLowerInvariant().Equals(args [1].ToLowerInvariant())))
                            {
                                continue;
                            }
                            RescanStatsData rescanStatsData = new RescanStatsData
                                                              {
                                                                  FileName = keyValuePair.Key,
                                                                  ExpectedCrc32Value = keyValuePair.Value,
                                                                  ReleaseName = directoryInfo.Name,
                                                              };
                            string fileName = Misc.PathCombine(SourceFolder, keyValuePair.Key);
                            FileInfo fileInfo = new FileInfo();
                            if (File.Exists(fileName))
                            {
                                uint crc32 = Crc32.GetFileCrc32(fileName);
                                string actualCrc32Value = String.Format(CultureInfo.InvariantCulture, "{0:X8}", crc32);
                                rescanStatsData.ActualCrc32Value = actualCrc32Value;
                                if (actualCrc32Value.ToLower().Equals(keyValuePair.Value.ToLower()))
                                {
                                    rescanStats.OkFiles++;
                                    rescanStats.TotalBytesUploaded += fileInfo.GetFileSize(fileName);
                                    rescanStatsData.Status = "OK";
                                    fileInfo.DeleteFile(SourceFolder, fileName + Config.FileExtensionMissing);
                                }
                                else
                                {
                                    rescanStats.FailedFiles++;
                                    rescanStatsData.Status = "FAILED";
                                    if (Config.DeleteCrc32FailedFiles)
                                    {
                                        fileInfo.DeleteFile(SourceFolder, keyValuePair.Key);
                                    }
                                    else
                                    {
                                        FileInfo.Create0ByteFile(fileName + Config.FileExtensionCrc32Failed);
                                    }
                                }
                            }
                            else
                            {
                                rescanStats.MissingFiles++;
                                rescanStatsData.ActualCrc32Value = "00000000";
                                rescanStatsData.Status = "MISSING";
                                FileInfo.Create0ByteFile(fileName + Config.FileExtensionMissing);
                            }
                            rescanStats.RescanStatsData.Add(rescanStatsData);
                            Output output = new Output(rescanStatsData, rescanStats);
                            output.ClientRescan(Config.ClientCrc32Body);
                        }
                        Output outputFoot = new Output(rescanStats);
                        outputFoot.ClientRescan(Config.ClientCrc32Foot);
                        new FileInfo().DeleteFilesThatStartsWith(SourceFolder, Config.TagCleanUpStringCrc32);
                        FileInfo.Create0ByteFile(Misc.PathCombine(SourceFolder,
                                                                  outputFoot.FormatCrc32(rescanStats.TotalFiles == rescanStats.OkFiles
                                                                                             ? Config.TagCompleteCrc32
                                                                                             : Config.TagIncompleteCrc32)));
                    }
                }
            }
        }

        public string SourceFolder { get; set; }

        public RescanStats RescanStats
        {
            get { return rescanStats; }
        }

        public DataParserSfv DataParserSfv
        {
            get { return dataParserSfv; }
        }

        private readonly string[] args;
        private readonly bool rescanFolder;
        private DirectoryInfo directoryInfo;
        private readonly RescanStats rescanStats = new RescanStats();
        private DataParserSfv dataParserSfv;
    }
}