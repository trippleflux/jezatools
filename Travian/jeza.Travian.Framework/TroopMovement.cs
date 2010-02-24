#region

using System;
using System.Collections.Generic;

#endregion

namespace jeza.Travian.Framework
{
    public class TroopMovement
    {
        private TroopMovementType type;
        private readonly List<Troops> troops = new List<Troops>();
        private DateTime dateTime;
        private string source;
        private string destination;
    }
}