using System;
using System.Xml.Serialization;

namespace jeza.ToDoList
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = XmlSchemaNamespace)]
    [XmlRoot(ElementName = "settings", Namespace = XmlSchemaNamespace, IsNullable = false)]
    public class Settings
    {
        private const string XmlSchemaNamespace = "http://tempuri.org/XMLSchemaSettings.xsd";

        [XmlElement("account")]
        public AccountInfo[] Account { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/XMLSchemaSettings.xsd")]
    public class AccountInfo : IAccountInfo
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("username")]
        public string Username { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("provider")]
        public AccountProvider Provider { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0}, Username: {1}, Password: {2}, Provider: {3}",
                                 Title, Username, Password, Provider);
        }
    }
}