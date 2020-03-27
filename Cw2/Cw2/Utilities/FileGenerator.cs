using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Xml.Serialization;
using Cw2.Models;

namespace Cw2.Utilities
{
    public static class FileGenerator
    {
        public static void createXml(List<Student> students, List<AktywneStudia> studies, string path)
        {
            FileStream writer = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(XMLRoot));
            XMLRoot root = new XMLRoot();
            root.Studenci = students;
            root.Studia = studies;
            serializer.Serialize(writer, root);
            writer.Dispose();
        }
        public static void createJSON(List<Student> students, List<AktywneStudia> studies, string path)
        {
            FileStream writer = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(XMLRoot));
            XMLRoot root = new XMLRoot();
            root.Studenci = students;
            root.Studia = studies;
            var jsonString = JsonSerializer.Serialize(root);
            File.WriteAllText(path, jsonString);
        }
    }
}
