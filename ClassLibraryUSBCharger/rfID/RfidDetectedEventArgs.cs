using System;

namespace ClassLibraryChargingBox.rfID
{
    public class RfidDetectedEventArgs : EventArgs
    {
        public string Rfid { get; set; }

    }
}
