using System;
using System.Collections.Generic;
using jeza.ioFTPD.Framework.ioFTPD;

namespace jeza.ioFTPD.Framework
{
    public class ConsoleAppTrial
    {
        public ConsoleAppTrial(string[] args)
        {
            this.args = args;
            Log.Debug("args: '{0}'", Misc.ArgsToString(args));
        }

        public void Parse()
        {
            int numberOfArguments = args.Length;
            target = Trial.TargetTrial.List;
            if (numberOfArguments > 0)
            {
                string firstArgument = args [0].ToLowerInvariant();
                if (firstArgument.Equals("trial"))
                {
                    if (args.Length == 3)
                    {
                        if (firstArgument.Equals("add"))
                        {
                            target = Trial.TargetTrial.Add;
                        }
                        if (firstArgument.Equals("remove"))
                        {
                            target = Trial.TargetTrial.Remove;
                        }
                    }
                }
                trials = DeserializeTrials();
            }
        }

        private static List<TrialQuota.Trial> DeserializeTrials()
        {
            return Extensions.Deserialize(new List<TrialQuota.Trial>(), FileName, Config.DefaultNamespaceTrialQuota);
        }

        private void ShowTrials()
        {
            Output output = new Output();
            output.Client(output.FormatNone(Config.ClientTrialListHead));
            foreach (TrialQuota.Trial trial in trials)
            {
                output.Client(output.FormatTrial(Config.ClientTrialListBody, trial));
            }
            output.Client(output.FormatNone(Config.ClientTrialListFoot));
            //DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
        }

        public void Process()
        {
            Output output = new Output();
            switch (target)
            {
                case Trial.TargetTrial.Add:
                {
                    int userId = UserManager.UsernameToUid(args[2]);
                    if (userId < 0)
                    {
                        output.Client(String.Format(Config.ClientTrialUserNotFound, args[2]));
                        return;
                    }
                    TrialQuota.Trial trial = new TrialQuota.Trial
                                             {
                                                 Uid = userId,
                                                 DateAdded = new DateTime(DateTime.UtcNow.Ticks),
                                                 Period = Config.TrialDefaultTime,
                                                 QuotaToPass = Config.TrialDefaultQuota,
                                                 StartAllUp = UserManager.GetStats(userId, UploadStats.AllUp),
                                             };
                    bool exists = trials.Exists(t => t.Uid == userId);
                    if (!exists)
                    {
                        trials.Add(trial);
                        SaveTrials();
                        output.Client(String.Format(Config.ClientTrialUserAdd, args[2]));
                    }
                    else
                    {
                        output.Client(String.Format(Config.ClientTrialUserExists, args[2]));
                    }
                    ShowTrials();
                    break;
                }
                case Trial.TargetTrial.Remove:
                {
                    int userId = UserManager.UsernameToUid(args [2]);
                    if (userId < 0)
                    {
                        output.Client(String.Format(Config.ClientTrialUserNotFound, args[2]));
                        return;
                    }
                    bool removed = trials.Remove(new TrialQuota.Trial {Uid = userId});
                    if (removed)
                    {
                        output.Client(String.Format(Config.ClientTrialUserRemove, args[2]));
                        SaveTrials();
                    }
                    else
                    {
                        output.Client(String.Format(Config.ClientTrialUserRemoveFail, args[2]));
                    }
                    ShowTrials();
                    break;
                }
                default:
                {
                    ShowTrials();
                    break;
                }
            }
        }

        private void SaveTrials()
        {
            Extensions.Serialize(trials, FileName, DefaultNamespace);
        }

        private readonly string[] args;
        private Trial.TargetTrial target;
        private const string FileName = "trials.xml";
        private const string DefaultNamespace = Config.DefaultNamespace;
        private List<TrialQuota.Trial> trials = new List<TrialQuota.Trial>();

        public List<TrialQuota.Trial> Trials
        {
            get { return trials; }
        }
    }
}