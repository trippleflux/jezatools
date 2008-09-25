namespace Library
{
    public class Production
    {
        private int clay;
        private int clayPerHour;
        private int crop;
        private int cropPerHour;
        private int granaryKapacity;
        private int iron;
        private int ironPerHour;
        private int warehouseKapacity;
        private int wood;
        private int woodPerHour;

        public int WarehouseKapacity
        {
            get { return warehouseKapacity; }
            set { warehouseKapacity = value; }
        }

        public int GranaryKapacity
        {
            get { return granaryKapacity; }
            set { granaryKapacity = value; }
        }

        public int Wood
        {
            get { return wood; }
            set { wood = value; }
        }

        public int Clay
        {
            get { return clay; }
            set { clay = value; }
        }

        public int Iron
        {
            get { return iron; }
            set { iron = value; }
        }

        public int Crop
        {
            get { return crop; }
            set { crop = value; }
        }

        public int WoodPerHour
        {
            get { return woodPerHour; }
            set { woodPerHour = value; }
        }

        public int ClayPerHour
        {
            get { return clayPerHour; }
            set { clayPerHour = value; }
        }

        public int IronPerHour
        {
            get { return ironPerHour; }
            set { ironPerHour = value; }
        }

        public int CropPerHour
        {
            get { return cropPerHour; }
            set { cropPerHour = value; }
        }

        public override string ToString()
        {
            return
                string.Format(
                    "WarehouseKapacity: {0}, GranaryKapacity: {1}, Wood: {2}, Clay: {3}, Iron: {4}, Crop: {5}, WoodPerHour: {6}, ClayPerHour: {7}, IronPerHour: {8}, CropPerHour: {9}",
                    warehouseKapacity, granaryKapacity, wood, clay, iron, crop, woodPerHour, clayPerHour, ironPerHour,
                    cropPerHour);
        }
    }
}