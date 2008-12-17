using System.Collections.Generic;

namespace TravianBot.Framework
{
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

        private readonly Dictionary<string, Action> actionsList = new Dictionary<string, Action>();
    }
}