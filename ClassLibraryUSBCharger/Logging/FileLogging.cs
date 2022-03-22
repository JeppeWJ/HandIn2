using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.Logging
{
    public class FileLogging : ILogging
    {
        private StringBuilder _sb;

        public void LogDoorLocked(string Id)
        {
            _sb = new StringBuilder();
            _sb.Append(Id);
            File.AppendAllText("Log.txt", _sb+" ");
            _sb.Clear();
        }
        public void LogDoorUnlocked(string Id)
        {
            _sb.Append(Id);
            File.AppendAllText("Log.txt", _sb+" ");
            _sb.Clear();
        }

    }
}
