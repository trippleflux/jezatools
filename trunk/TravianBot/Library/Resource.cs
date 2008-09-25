namespace Library
{
    public class Resource
    {
        private string resourceFullName;
        private int resourceId;
        private string resourceName;
        private int resourceLevel;

        public string ResourceFullName
        {
            get { return resourceFullName; }
            set { resourceFullName = value; }
        }

        public int ResourceId
        {
            get { return resourceId; }
            set { resourceId = value; }
        }

        public string ResourceName
        {
            get { return resourceName; }
            set { resourceName = value; }
        }

        public int ResourceLevel
        {
            get { return resourceLevel; }
            set { resourceLevel = value; }
        }
    }
}