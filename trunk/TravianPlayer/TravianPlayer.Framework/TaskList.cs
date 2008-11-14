using System.Collections.Generic;

namespace TravianPlayer.Framework
{
    public class TaskList
    {
        public void AddAction(int id, Action action)
        {
            actionList.Add(id, action);
        }

        public Action GetAction(int actionId)
        {
            foreach (KeyValuePair<int, Action> action in actionList)
            {
                if (action.Key == actionId)
                {
                    return action.Value;
                }
            }
            return null;
        }

        public int GetActionCount
        {
            get { return actionList.Count; }
        }

        private Dictionary<int, Action> actionList = new Dictionary<int, Action>();
    }
}