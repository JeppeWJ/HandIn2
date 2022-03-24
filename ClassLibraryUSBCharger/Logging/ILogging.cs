﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.Logging
{
    public interface ILogging
    {
        void LogDoorLocked(string Id);
        void LogDoorUnlocked(string Id);
        List<string> logList { get; set; }

    }
}
