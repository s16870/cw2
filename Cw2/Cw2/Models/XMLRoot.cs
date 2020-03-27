using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Cw2.Utilities;

namespace Cw2.Models
{
    [Serializable, XmlRoot("uczelnia")]
    public class XMLRoot
    {
        [XmlAttribute(AttributeName = "createdAt")] public string DataUtworzenia { get; set; }
        [XmlElement(elementName: "author")] public string Autor { get; set; }
        [XmlArray("studenci"),XmlArrayItem("student")] public List<Student> Studenci { get; set; }
        [XmlArray("activeStudies"), XmlArrayItem("studies")] public List<AktywneStudia> Studia { get; set; }

        public XMLRoot()
        {
            DataUtworzenia = DateTime.Today.ToString("dd.MM.yyyy");
            Autor = Properties.author;
        }

    }
}
