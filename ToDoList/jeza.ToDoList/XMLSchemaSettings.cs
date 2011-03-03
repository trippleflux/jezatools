namespace jeza.ToDoList
{
    [System.SerializableAttribute]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = XmlSchemaNamespace)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "settings", Namespace = XmlSchemaNamespace, IsNullable = false)]
    public class Settings
    {
        private const string XmlSchemaNamespace = "http://tempuri.org/XMLSchemaSettings.xsd";

        [System.Xml.Serialization.XmlElementAttribute("googleAccount")]
        public GoogleAccountInfo[] GoogleAccount { get; set; }
    }

    [System.SerializableAttribute]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/XMLSchemaSettings.xsd")]
    public class GoogleAccountInfo
    {
        [System.Xml.Serialization.XmlElementAttribute("title")]
        public string Title { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("username")]
        public string Username { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("password")]
        public string Password { get; set; }
    }
}