using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace ProductTracker.Web
{
    public class SettingsManager
    {
        public string GetSettingValue(string value, IEnumerable<Setting> settings)
        {
            foreach (Setting setting in settings)
            {
                if (setting.Id == value)
                {
                    return setting.Value;
                }
            }
            return "NOT SET";
        }
        /*
        private static void SerializeToXml()
        {
            Settings settings = new Settings
                {
                    Page = new List<Page>
                        {
                            new Page
                                {
                                    Id = "DefaultPage",
                                    Setting = new List<Setting>
                                        {
                                            new Setting
                                                {
                                                    Id = "ButtonASD",
                                                    Value = "jebi se",
                                                }
                                        },
                                }
                        },
                };
            XmlSerializer serializer = new XmlSerializer(typeof (Settings));
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Language.xml");
            using (TextWriter textWriter = new StreamWriter(path))
            {
                serializer.Serialize(textWriter, settings);
                textWriter.Close();
            }
        }
        */

        public Settings DeserializeFromXml()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Settings));
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Language.xml");
            TextReader textReader = new StreamReader(path);
            Settings settings = (Settings)deserializer.Deserialize(textReader);
            textReader.Close();
            return settings;
        }

    }
}