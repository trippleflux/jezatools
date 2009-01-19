using System.Collections.Generic;

namespace TravianBot.Framework
{
    /// <summary>
    /// Holds collectionof all actions parsedfrom specified file.
    /// </summary>
    public class ActionList
    {
        public Dictionary<string, Action> ActionsList
        {
            get { return actionsList; }
        }

        public IList<Action> TroopSenderList
        {
            get { return troopSenderList; }
        }

        public void AddAction(string id, Action sendAction)
        {
            actionsList.Add(id, sendAction);
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

        public void AddTroopSenderAction(Action troopSenderAction)
        {
            troopSenderList.Add(troopSenderAction);
        }

        public Action GetTroopSenderAction(string actionId)
        {
            foreach (Action troopSenderAction in troopSenderList)
            {
                if (troopSenderAction.Id == actionId)
                {
                    return troopSenderAction;
                }
            }
            return null;
        }

        private readonly Dictionary<string, Action> actionsList = new Dictionary<string, Action>();

        private readonly List<Action> troopSenderList = new List<Action>();
    }
}