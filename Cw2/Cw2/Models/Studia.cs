using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw2.Models
{
    [Serializable]
    public class Studia
    {
        [XmlElement(elementName: "name")] public string Kierunek { get; set; }
        [XmlElement(elementName: "mode")] public string Tryb { get; set; }

        public Studia(string name, string mode)
        {
            Kierunek = name;
            Tryb = mode;
        }
        public Studia()
        {

        }

    }
}
