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

        public IList<TroopSenderParamaters> TroopSenderParameters
        {
            get { return troopSenderParameters; }
        }

        public void AddActionParameters(ActionParameters parameters)
        {
            actionParameters.Add(parameters);
        }

        public void AddTroopSenderParameters(TroopSenderParamaters parameters)
        {
            troopSenderParameters.Add(parameters);
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

        public TroopSenderParamaters GetTroopSenderParameters(string parameterId)
        {
            foreach (TroopSenderParamaters parameters in troopSenderParameters)
            {
                if (parameters.Id == parameterId)
                {
                    return parameters;
                }
            }
            return null;
        }

        public void AddFakeParameters(FakeParamaters fakeParamaters)
        {
            fakeActionParamaters.Add(fakeParamaters);
        }

        private readonly List<ActionParameters> actionParameters = new List<ActionParameters>();

        private readonly List<TroopSenderParamaters> troopSenderParameters = new List<TroopSenderParamaters>();

        private readonly List<FakeParamaters> fakeActionParamaters = new List<FakeParamaters>();

        private readonly string id;

        public FakeParamaters GetFakeActionParameters(string id)
        {
            foreach (FakeParamaters fakeParamaters in fakeActionParamaters)
            {
                if (fakeParamaters.Id == id)
                {
                    return fakeParamaters;
                }
            }
            return null;
        }
    }
}