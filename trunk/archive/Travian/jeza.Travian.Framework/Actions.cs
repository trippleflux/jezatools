using System.Collections.Generic;

namespace jeza.Travian.Framework
{
    public class Actions
    {
        public Actions()
        {
            BuildQueue = new List<BuildQueue>();
            MarketPlaceQueue = new List<MarketPlaceQueue>();
        }

        public List<BuildQueue> BuildQueue { get; set; }
        public List<MarketPlaceQueue> MarketPlaceQueue { get; set; }
    }
}