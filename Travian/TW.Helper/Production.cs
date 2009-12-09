namespace TW.Helper
{
    public class Production
    {
        public int WoodPerHour { get; set; }
        public int ClayPerHour { get; set; }
        public int IronPerHour { get; set; }
        public int CropPerHour { get; set; }

        public int Wood { get; set; }
        public int Clay { get; set; }
        public int Iron { get; set; }
        public int Crop { get; set; }

        public int WarehouseCapacity { get; set; }
        public int GranaryCapacity { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Wood: {4} ({0}/h), Clay: {5} ({1}/h), Iron: {6} ({2}/h), Crop: {7} ({3}/h), WarehouseCapacity: {8}, GranaryCapacity: {9}",
                    WoodPerHour, ClayPerHour, IronPerHour, CropPerHour, Wood, Clay, Iron, Crop, WarehouseCapacity,
                    GranaryCapacity);
        }
    }
}