using System.Collections.Generic;

namespace TravianPlayer.Framework
{
    public class Action
    {
        public void AddActionParameters(ActionParameters newActionParameters)
        {
            actionParameters.Add(newActionParameters);
        }

        public IList<ActionParameters> ActionParameters
        {
            get { return actionParameters; }
        }

        public ActionParameters GetActionParameters(int actionId)
        {
            foreach (ActionParameters parameter in actionParameters)
            {
                if (parameter.Id == actionId)
                {
                    return parameter;
                }
            }
            return null;
        }

        private List<ActionParameters> actionParameters = new List<ActionParameters>();
    }
}