using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw2.Models
{
    [Serializable]
    public class Student
    {
        [XmlAttribute(AttributeName = "indexNumber")] public string NumerIndeksu { get; set; }
        [XmlElement(elementName: "fname")]public string Imie { get; set; }
        [XmlElement(elementName: "lname")]public string Nazwisko { get; set; }
        [XmlElement(elementName: "birthdate")]public string DataUrodzenia { get; set; }
        [XmlElement(elementName: "email")] public string Email { get; set; }
        [XmlElement(elementName: "mothersName")] public string ImieMatki { get; set; }
        [XmlElement(elementName: "fathersName")] public string ImieOjca { get; set; }
        [XmlElement(elementName: "studies")] public Studia Studies { get; set; }

        public Student()
        {

        }
        public Student(string idx, string name, string surname, string bDate, string mail, string mName, string fName, string studiesName, string studiesMode)
        {
            NumerIndeksu = idx;
            Imie = name;
            Nazwisko = surname;
            DataUrodzenia = bDate;
            Email = mail;
            ImieMatki = mName;
            ImieOjca = fName;
            Studies = new Studia(studiesName, studiesMode);
        }
        public Student(string[] row)
        {
            NumerIndeksu = 's' + row[4];
            Imie = row[0];
            Nazwisko = row[1];
            DataUrodzenia = row[5];
            Email = row[6];
            ImieMatki = row[7];
            ImieOjca = row[8];
            Studies = new Studia(row[2], row[3]);
        }
    }
}
