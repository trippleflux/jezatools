namespace TravianBot.Framework
{
    public class SendResourcesParameters
    {
        public string Id { get; set; }
        public int Enabled { get; set; }
        public int SourceVillageId { get; set; }
        public int DestinationVillageX { get; set; }
        public int DestinationVillageY { get; set; }
        public int WoodAmount { get; set; }
        public int ClayAmount { get; set; }
        public int IronAmount { get; set; }
        public int CropAmount { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Enabled: {1}, SourceVillageId: {2}, DestinationVillageX: {3}, DestinationVillageY: {4}, WoodAmount: {5}, ClayAmount: {6}, IronAmount: {7}, CropAmount: {8}",
                    Id, Enabled, SourceVillageId, DestinationVillageX, DestinationVillageY, WoodAmount, ClayAmount,
                    IronAmount, CropAmount);
        }
    }
}