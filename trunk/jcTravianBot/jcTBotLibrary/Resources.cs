using System.Collections;

namespace jcTBotLibrary
{
	public class Resources
	{
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

		private int resourceId;
		private string resourceName;
		private int resourceLevel;
	}
}
