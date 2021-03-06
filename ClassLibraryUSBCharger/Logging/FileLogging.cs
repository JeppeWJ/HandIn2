using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.Logging
{
    public class FileLogging : ILogging
    {
        public List<string> logList { get; set; }
        public FileLogging()
        {
            logList = new List<string>();
        }

        public void LogDoorLocked(string Id)
        {
            logList.Add(Id);
        }

        public void LogDoorUnlocked(string Id)
        {
            logList.Add(Id);
        }


    }
}
