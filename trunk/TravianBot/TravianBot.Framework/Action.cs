using System.Collections.Generic;

namespace TravianBot.Framework
{
    public class Action : IAction
    {
        public Action(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get { return id; }
        }

        public IList<ActionParameters> ActionParameters
        {
            get { return actionParameters; }
        }

        public void AddActionParameters(ActionParameters parameters)
        {
            actionParameters.Add(parameters);
        }

        public ActionParameters GetActionParameters(string parameterId)
        {
            foreach (ActionParameters parameters in actionParameters)
            {
                if (parameters.Id == parameterId)
                {
                    return parameters;
                }
            }
            return null;
        }

        private readonly List<ActionParameters> actionParameters = new List<ActionParameters>();
        private readonly string id;
    }
}