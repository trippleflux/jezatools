namespace Library
{
	public class BuildCost
	{
		private int availableWood;
		private int availableClay;
		private int availableIron;
		private int availableCrop;

		private int neededWood;
		private int neededClay;
		private int neededIron;
		private int neededCrop;

		private int woodPerHour;
		private int clayPerHour;
		private int ironPerHour;
		private int cropPerHour;

		public int AvailableWood
		{
			get { return availableWood; }
			set { availableWood = value; }
		}

		public int AvailableClay
		{
			get { return availableClay; }
			set { availableClay = value; }
		}

		public int AvailableIron
		{
			get { return availableIron; }
			set { availableIron = value; }
		}

		public int AvailableCrop
		{
			get { return availableCrop; }
			set { availableCrop = value; }
		}

		public int NeededWood
		{
			get { return neededWood; }
			set { neededWood = value; }
		}

		public int NeededClay
		{
			get { return neededClay; }
			set { neededClay = value; }
		}

		public int NeededIron
		{
			get { return neededIron; }
			set { neededIron = value; }
		}

		public int NeededCrop
		{
			get { return neededCrop; }
			set { neededCrop = value; }
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
					"AvailableWood: {0}, AvailableClay: {1}, AvailableIron: {2}, AvailableCrop: {3}, NeededWood: {4}, NeededClay: {5}, NeededIron: {6}, NeededCrop: {7}, WoodPerHour: {8}, ClayPerHour: {9}, IronPerHour: {10}, CropPerHour: {11}",
					availableWood, availableClay, availableIron, availableCrop, neededWood, neededClay, neededIron, neededCrop,
					woodPerHour, clayPerHour, ironPerHour, cropPerHour);
		}
	}
}