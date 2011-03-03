using System;

namespace jeza.ToDoList
{
    [Serializable]
    public class Task
    {
        [System.Xml.Serialization.XmlElementAttribute("id")]
        public string Id { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("starDate")]
        public DateTime StartDate { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("stopDate")]
        public DateTime StopDate { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("head")]
        public string Head { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("description")]
        public string Description { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("notes")]
        public string Notes { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, StartDate: {1}, StopDate: {2}, Head: {3}, Description: {4}, Notes: {5}", Id,
                                 StartDate, StopDate, Head, Description, Notes);
        }
    }
}