namespace Library
{
    public class Building
    {
        private string buildingFullName;
        private int buildingId;
        private string buildingName;
        private int buildingLevel;

        public string BuildingFullName
        {
            get { return buildingFullName; }
            set { buildingFullName = value; }
        }

        public int BuildingId
        {
            get { return buildingId; }
            set { buildingId = value; }
        }

        public string BuildingName
        {
            get { return buildingName; }
            set { buildingName = value; }
        }

        public int BuildingLevel
        {
            get { return buildingLevel; }
            set { buildingLevel = value; }
        }
    }
}