using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Cw2.Utilities
{
    public static class Logger
    {
        public static void Log(string msg)
        {
            File.AppendAllText(Properties.loggerPath, DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss") + " " + msg + "\n");
        }
    }
}
