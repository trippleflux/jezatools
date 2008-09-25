using System.Collections;

namespace Library
{
    public class VillageData
    {
        private ArrayList resourcesForVillage = new ArrayList();
        private ArrayList buildingsForVillage = new ArrayList();

        public ArrayList BuildingsForVillage
        {
            get { return buildingsForVillage; }
            set { buildingsForVillage = value; }
        }

        public ArrayList ResourcesForVillage
        {
            get { return resourcesForVillage; }
            set { resourcesForVillage = value; }
        }
    }
}