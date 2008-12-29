using System.Collections.Generic;

namespace TravianBot.Framework
{
    /// <summary>
    /// Holds the collection ofall files with actions.
    /// </summary>
    public class ActionContainer
    {
        public Dictionary<string, ActionList> ActionsContainer
        {
            get { return actionsContainer; }
        }

        public void AddActionList(string fileName, ActionList actionList)
        {
            actionsContainer.Add(fileName, actionList);
        }

        public ActionList GetActionList(string filename)
        {
            foreach (KeyValuePair<string, ActionList> keyValuePair in actionsContainer)
            {
                if (keyValuePair.Key == filename)
                {
                    return keyValuePair.Value;
                }
            }
            return null;
        }

        private readonly Dictionary<string, ActionList> actionsContainer = new Dictionary<string, ActionList>();
    }
}