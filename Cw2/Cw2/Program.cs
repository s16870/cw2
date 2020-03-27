using Cw2.Utilities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;


namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists(Properties.loggerPath))
            {
                File.Create(Properties.loggerPath);
            }
            string inputFilePath; 
            string outputFilePath; 
            string outputType;
            if(args.Length < 1)
            {
                inputFilePath = @"Data\dane.csv";
            }
            else
            {
                Regex r = new Regex(@"^(([a-zA-Z]:)|(\))(\{1}|((\{1})[^\]([^/:*?<>""|]*))+)$");
                if (!r.IsMatch(args[0])){
                    var exc = new ArgumentException("Podana ścieżka " + args[0] + " jest niepoprawna");
                    Logger.Log(exc.ToString());
                    throw exc;
                }
                else
                {
                    inputFilePath = args[0];
                }
            }
            if(args.Length < 2)
            {
                outputFilePath = @"Data\result.xml";
            }
            else
            {
                outputFilePath = args[1];
            }
            if (args.Length < 3)
            {
                outputType = "xml";
            }
            else
            {
                outputType = args[2];
            }
            var serializer = new Serializer();
            serializer.startSerialization(inputFilePath, outputFilePath, outputType);

        }
    }
}
