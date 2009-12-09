#region

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

#endregion

namespace TW.Helper
{
    public class GameData
    {
        public IList<Village> Villages
        {
            get { return villages; }
        }

        public IDictionary<Village, List<TroopList>> TroopList4Village
        {
            get { return troopList4Village; }
        }

        public IDictionary<Village, Production> Production4Village
        {
            get { return production4Village; }
        }

        public Settings Settings
        {
            get { return settings; }
        }

        public void GameSettings(string language)
        {
            XmlSettings settingsFromXml = LoadSettingsFromXml();
            Settings[] xmlSettings = settingsFromXml.Language;
            for (int i = 0; i < xmlSettings.Length; i++)
            {
                if (xmlSettings[i].Id.Equals(language))
                {
                    settings = xmlSettings[i];
                }
            }
        }

        private static XmlSettings LoadSettingsFromXml()
        {
            const string settingsXml = "Settings.xml";
            if (!File.Exists(settingsXml))
            {
                throw new FileNotFoundException("Settings file was not found!");
            }
            XmlSerializer serializer = new XmlSerializer(typeof (XmlSettings));
            TextReader textReader = new StreamReader(settingsXml);
            XmlSettings settingsFromXml = (XmlSettings) serializer.Deserialize(textReader);
            textReader.Close();
            return settingsFromXml;
        }

        public void AddVillage(Village village)
        {
            if (!villages.Contains(village))
            {
                villages.Add(village);
            }
        }

        public void AddTroopsForVillage
            (Village village,
             TroopList troops)
        {
            if (troopList4Village.ContainsKey(village))
            {
                troopList4Village.Remove(village);
            }
            troopList4Village.Add(village, troops.TroopsForVillage as List<TroopList>);
        }

        public void AddProductionForVillage
            (Village village,
             Production production)
        {
            if (production4Village.ContainsKey(village))
            {
                production4Village.Remove(village);
            }
            production4Village.Add(village, production);
        }

        public void AddTroopMovementsForVillage
            (Village village,
             List<TroopMovements> troopMovements)
        {
            if (troopMovements4Village.ContainsKey(village))
            {
                troopMovements4Village.Remove(village);
            }
            troopMovements4Village.Add(village, troopMovements);
        }

        public List<TroopMovements> GetTroopMovements4Village(Village village)
        {
            foreach (KeyValuePair<Village, List<TroopMovements>> keyValuePair in troopMovements4Village)
            {
                if (keyValuePair.Key.Equals(village))
                {
                    return keyValuePair.Value;
                }
            }
            return null;
        }

        public Production GetProduction4Village(Village village)
        {
            foreach (KeyValuePair<Village, Production> keyValuePair in production4Village)
            {
                if (keyValuePair.Key.Equals(village))
                {
                    return keyValuePair.Value;
                }
            }
            return null;
        }

        public List<TroopList> GetTroopList4Village(Village village)
        {
            foreach (KeyValuePair<Village, List<TroopList>> keyValuePair in troopList4Village)
            {
                if (keyValuePair.Key.Equals(village))
                {
                    return keyValuePair.Value;
                }
            }
            return null;
        }

        private Settings settings;
        private readonly List<Village> villages = new List<Village>();

        private readonly Dictionary<Village, List<TroopList>> troopList4Village =
            new Dictionary<Village, List<TroopList>>();

        private readonly Dictionary<Village, Production> production4Village = new Dictionary<Village, Production>();

        private readonly Dictionary<Village, List<TroopMovements>> troopMovements4Village =
            new Dictionary<Village, List<TroopMovements>>();
    }
}