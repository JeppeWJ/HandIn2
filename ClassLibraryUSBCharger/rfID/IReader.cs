using System;

namespace ClassLibraryChargingBox.rfID
{
    public interface IReader
    {
        event EventHandler<RfidDetectedEventArgs> RfidDetectedEvent;
        public void SetRfid(string newRfid);
    }
}
