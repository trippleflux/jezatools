#region

using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace jeza.Travian.Framework
{
    [XmlRoot(ElementName = "settings", IsNullable = false)]
    public class Settings
    {
        public Settings()
        {
            Ally = new List<Ally>();
            Excluded = new List<Excluded>();
        }

        [XmlElement(ElementName = "login")]
        public Login LoginData { get; set; }

        [XmlElement(ElementName = "languageId")]
        public string LanguageId { get; set; }

        //[XmlElement(ElementName = "ally")]
        public List<Ally> Ally { get; set; }

        //[XmlElement(ElementName = "excluded")]
        public List<Excluded> Excluded { get; set; }
    }

    public class Excluded
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ExcludedType Type { get; set; }
    }

    public class Login
    {
        [XmlElement(ElementName = "server")]
        public string Servername { get; set; }

        [XmlElement(ElementName = "username")]
        public string Username { get; set; }

        [XmlElement(ElementName = "password")]
        public string Password { get; set; }
    }

    public class Ally
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AllyType Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0,5}, {1}", Id, Name);
        }
    }

    public enum AllyType
    {
        Ally,
        Nap,
        War,
    }

    public enum ExcludedType
    {
        Ally,
        User,
    }
}