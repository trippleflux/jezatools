using System;
using log4net;

namespace Library
{
    public class Task
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Task));

        public void CheckTasks(ServerData sd)
        {
            const tbLibrary.Tasks task = tbLibrary.Tasks.BuildResourcesNoCrop;
            for (int i = 0; i < sd.ProductionList.Count; i++)
            {
                Production p = sd.ProductionList[i] as Production;
                if (p != null) Log.InfoFormat("p[{1}]={0}", p.ToString(), i);
            }

            if (!ExecuteTask(sd, task))
            {
                Log.ErrorFormat("Task '{0}' Failed", task);
            }
        }

        private static bool ExecuteTask(ServerData sd, tbLibrary.Tasks task)
        {
            bool foundIdForUpgrade = false;

            switch (task)
            {
                case tbLibrary.Tasks.BuildResourcesNoCrop:
                    {
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Task not implemented!");
                    }
            }
            return false;
        }
    }
}