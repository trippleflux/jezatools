namespace Library
{
    public class Resource
    {
        private string resourceFullName;
        private int resourceId;
        private int resourceLevel;
        private string resourceName;

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

        public override string ToString()
        {
            return string.Format("ResourceFullName: {0}, ResourceId: {1}, ResourceName: {2}, ResourceLevel: {3}",
                                 resourceFullName, resourceId, resourceName, resourceLevel);
        }
    }
}