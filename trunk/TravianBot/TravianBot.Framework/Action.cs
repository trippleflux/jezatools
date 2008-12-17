using System.Collections.Generic;

namespace TravianBot.Framework
{
    public class Action : IAction
    {
        public void AddActionParameters(ActionParameters actionParameters)
        {
            ActionParameters.Add(actionParameters);
        }

        public List<ActionParameters> SendActionParameters
        {
            get { return ActionParameters; }
        }

        public ActionParameters GetActionParameters(string actionId)
        {
            foreach (ActionParameters actionParameter in ActionParameters)
            {
                if (actionParameter.Id == actionId)
                {
                    return actionParameter;
                }
            }
            return null;
        }

        private readonly List<ActionParameters> ActionParameters = new List<ActionParameters>();
    }
}