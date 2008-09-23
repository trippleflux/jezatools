using System.Collections;

namespace jcTBotLibrary
{
	public class BuildingsId
	{
		public ArrayList BuildingsVillageId
		{
			get { return buildingsVillageId; }
			set { buildingsVillageId = value; }
		}

		private ArrayList buildingsVillageId = new ArrayList();
	}
}