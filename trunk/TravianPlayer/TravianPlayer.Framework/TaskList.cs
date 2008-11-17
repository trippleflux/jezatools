using System.Collections.Generic;

namespace TravianPlayer.Framework
{
    public class TaskList
    {
        public void AddAction(int id, Action action)
        {
            actionList.Add(id, action);
        }

    	public Dictionary<int, Action> ActionList
    	{
			get { return actionList; }
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

    	private readonly Dictionary<int, Action> actionList = new Dictionary<int, Action>();
    }
}