using System.Collections.Generic;

namespace TravianBot.Framework
{
    public class TroopSendAction : IAction
    {
        public TroopSendAction(string actionId)
        {
            this.actionId = actionId;
        }

        public string ActionId
        {
            get { return actionId; }
        }

        public void AddTroopSendActionParameters(TroopSendActionParameters actionParameters)
        {
            troopSendActionParameters.Add(actionParameters);
        }

        public List<TroopSendActionParameters> TroopSendActionParameters
        {
            get { return troopSendActionParameters; }
        }

        private readonly List<TroopSendActionParameters> troopSendActionParameters =
            new List<TroopSendActionParameters>();

        private readonly string actionId;
    }
}