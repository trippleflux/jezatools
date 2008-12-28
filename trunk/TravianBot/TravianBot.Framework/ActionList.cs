using System.Collections.Generic;

namespace TravianBot.Framework
{
    /// <summary>
    /// Holds collectionof all actions parsedfrom specified file.
    /// </summary>
    public class ActionList
    {
        public void AddAction(string id, Action sendAction)
        {
            actionsList.Add(id, sendAction);
        }

        public Dictionary<string, Action> ActionsList
        {
            get { return actionsList; }
        }

        public Action GetAction(string actionId)
        {
            foreach (KeyValuePair<string, Action> keyValuePair in actionsList)
            {
                if (keyValuePair.Key == actionId)
                {
                    return keyValuePair.Value;
                }
            }
            return null;
        }

        private readonly Dictionary<string, Action> actionsList = new Dictionary<string, Action>();
    }
}