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

        public IList<Action> FakeActionList
        {
            get { return fakeAttackList; }
        }

        public IList<Action> SendResourcesList
        {
            get { return sendResourcesList; }
        }

        public IList<Action> TroopSenderList
        {
            get { return troopSenderList; }
        }

        public void AddAction(string id, Action sendAction)
        {
            actionsList.Add(id, sendAction);
        }

        public void AddFakeAction(Action action)
        {
            fakeAttackList.Add(action);
        }

        public void AddSendResourcesAction(Action sendAction)
        {
            sendResourcesList.Add(sendAction);
        }

        public void AddTroopSenderAction(Action troopSenderAction)
        {
            troopSenderList.Add(troopSenderAction);
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

        public Action GetFakeAction(string actionId)
        {
            foreach (Action action in fakeAttackList)
            {
                if (action.Id == actionId)
                {
                    return action;
                }
            }
            return null;
        }

        public Action GetSendResourcesAction(string actionId)
        {
            foreach (Action action in sendResourcesList)
            {
                if (action.Id == actionId)
                {
                    return action;
                }
            }
            return null;
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
        private readonly List<Action> fakeAttackList = new List<Action>();
        private readonly List<Action> sendResourcesList = new List<Action>();
        private readonly List<Action> troopSenderList = new List<Action>();
    }
}