namespace jeza.Travian.Framework
{
    public class MarketPlaceQueue
    {
        //id=33&r1=750&r2=750&r3=750&r4=750&dname=02&x=&y=&s1.x=30&s1.y=12&s1=ok
        //id=33&a=75579&sz=5258&kid=271057&r1=750&r2=750&r3=750&r4=750&s1.x=30&s1.y=14&s1=ok

        //id=33&r1=750&r2=750&r3=750&r4=750&dname=&x=-82&y=62&s1.x=29&s1.y=8&s1=ok
        //id=33&a=75579&sz=5259&kid=271057&r1=750&r2=750&r3=750&r4=750&s1.x=35&s1.y=4&s1=ok

        //public int DestinationVillageId { get; set; }
        //public string DestinationVillageName { get; set; }
        //public int SourceVillageId { get; set; }
        //public string SourceVillageName { get; set; }
        public Village DestinationVillage { get; set; }
        public Village SourceVillage { get; set; }
        public SendGoodsType SendGoodsType { get; set; }
        public bool SendWood { get; set; }
        public bool SendClay { get; set; }
        public bool SendIron { get; set; }
        public bool SendCrop { get; set; }
        public int Goods { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "{1} -> {0} : {2} < {7}% send [Wood({3}), Clay({4}), Iron({5}), Crop({6})]",
                    DestinationVillage, SourceVillage, SendGoodsType, SendWood, SendClay, SendIron, SendCrop, Goods);
        }
    }
}