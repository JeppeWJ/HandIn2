using System;

namespace ClassLibraryChargingBox.rfID
{
    public class RfidReader : IReader
    {
        private string rfid;

        public event EventHandler<RfidDetectedEventArgs> RfidDetectedEvent;

        public void SetRfid(string id)
        {}

        protected virtual void OnRfidChanged(RfidDetectedEventArgs e)
        {
            RfidDetectedEvent?.Invoke(this, e);
        }
    }
}
