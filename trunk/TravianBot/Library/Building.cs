namespace Library
{
    public class Building
    {
        private string buildingFullName;
        private int buildingId;
        private int buildingLevel;
        private string buildingName;

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

        public override string ToString()
        {
            return string.Format("BuildingFullName: {0}, BuildingId: {1}, BuildingName: {2}, BuildingLevel: {3}",
                                 buildingFullName, buildingId, buildingName, buildingLevel);
        }
    }
}