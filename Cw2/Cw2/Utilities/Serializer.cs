using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Cw2.Models;

namespace Cw2.Utilities
{
    class Serializer
    {
        public void startSerialization(string inputFilePath, string outputFilePath, string outputType)
        {
            var inputFile = new FileInfo(inputFilePath);
            if (!inputFile.Exists)
            {
                var e = new FileNotFoundException("Plik " + inputFilePath + " nie istnieje");
                Logger.Log(e.ToString());
                throw e;
            }
            var stream = new StreamReader(inputFile.OpenRead());
            string line = null;
            List<Student> students = new List<Student>();
            List<AktywneStudia> studies = new List<AktywneStudia>();
            while ((line = stream.ReadLine()) != null)
            {
                string[] row = line.Split(',');
                if(row.Length != 9)
                {
                    Logger.Log("Invalid row: " + line);
                    continue;
                }
                else
                {
                    Boolean isDataValid = true;
                    foreach(string val in row)
                    {
                        if(val.Trim() == "")
                        {
                            Logger.Log("Invalid row: " + line);
                            isDataValid = false;
                            break; 
                        }
                    }
                    if (!isDataValid)
                    {
                        continue;
                    }
                }
                Boolean isDupli = false;
                foreach (var stud in students)
                {
                    if (stud.NumerIndeksu == row[4] && stud.Imie == row[0] && stud.Nazwisko == row[1])
                    {
                        isDupli = true;
                        break;
                    }
                }
                if (!isDupli)
                {
                    students.Add(new Student(row));
                    if (studies.Count < 1)
                    {
                        studies.Add(new AktywneStudia(row[2], 1));
                    }
                    else
                    {
                        Boolean found = false;
                        foreach (var study in studies)
                        {
                            if (study.Kierunek == row[2])
                            {
                                study.LiczbaStudentow++;
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            studies.Add(new AktywneStudia(row[2], 1));
                        }
                    }
                }
            }
            stream.Dispose();
            createXml(students, studies, outputFilePath);
        }
        private void createXml(List<Student> students, List<AktywneStudia> studies, string path)
        {
            FileStream writer = new FileStream(path, FileMode.OpenOrCreate);
            XmlSerializer serializer = new XmlSerializer(typeof(XMLRoot));
            XMLRoot root = new XMLRoot();
            root.Studenci = students;
            root.Studia = studies;
            serializer.Serialize(writer,root);
            writer.Dispose();
        }
    }
}
