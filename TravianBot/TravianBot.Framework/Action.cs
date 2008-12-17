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

        private readonly List<ActionParameters> ActionParameters = new List<ActionParameters>();
    }
}