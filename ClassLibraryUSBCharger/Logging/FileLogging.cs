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

        //Gem i en lokal container og tjek at denne indeholder det der  bliver placeret i den.
        //Assert input lig container.contains.


        //private StringBuilder _sb;
        //public void LogDoorLocked(string Id)
        //{
        //    _sb = new StringBuilder();
        //    _sb.Append(Id);
        //    File.AppendAllText("Log.txt", _sb+" ");
        //    _sb.Clear();
        //}
        //public void LogDoorUnlocked(string Id)
        //{
        //    _sb.Append(Id);
        //    File.AppendAllText("Log.txt", _sb+" ");
        //    _sb.Clear();
        //}




    }
}
