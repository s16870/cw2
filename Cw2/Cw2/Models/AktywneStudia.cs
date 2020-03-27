using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw2.Models
{
    [Serializable]
    public class AktywneStudia
    {
        [XmlElement(elementName: "name")] public string Kierunek { get; set; }
        [XmlElement(elementName: "numberOfStudents")] public int LiczbaStudentow { get; set; }

        public AktywneStudia(string name, int num)
        {
            Kierunek = name;
            LiczbaStudentow = num;
        }
        public AktywneStudia()
        {

        }

    }
}
