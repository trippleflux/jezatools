using System;
using System.Collections.Generic;
using System.Text;

namespace jcTBotLibrary
{
	public class Production
	{
		private int warehouseKapacity;
		private int granaryKapacity;
		private int wood;
		private int clay;
		private int iron;
		private int crop;
		private int woodPerHour;
		private int clayPerHour;
		private int ironPerHour;
		private int cropPerHour;

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

	}
}
