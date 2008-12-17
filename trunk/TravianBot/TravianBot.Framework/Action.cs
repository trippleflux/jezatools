using System.Collections.Generic;

namespace TravianBot.Framework
{
    public class Action : IAction
    {
        public List<ActionParameters> ActionParameters
        {
            get { return actionParameters; }
        }

        public void AddActionParameters(ActionParameters parameters)
        {
            actionParameters.Add(parameters);
        }

        public ActionParameters GetActionParameters(string actionId)
        {
            foreach (ActionParameters actionParameter in actionParameters)
            {
                if (actionParameter.Id == actionId)
                {
                    return actionParameter;
                }
            }
            return null;
        }

        private readonly List<ActionParameters> actionParameters = new List<ActionParameters>();
    }
}