using System;

namespace ClassLibraryChargingBox.rfID
{
    public class RfidReader : IReader
    {
        private string _oldRfid;

        public event EventHandler<RfidDetectedEventArgs> RfidDetectedEvent;

        public void SetRfid(string newRfid)
        {
            OnRfidChanged(new RfidDetectedEventArgs{ Rfid = newRfid});
        }

        protected virtual void OnRfidChanged(RfidDetectedEventArgs e)
        {
            RfidDetectedEvent?.Invoke(this, e);
            Console.WriteLine("Invoke");
        }
    }
}
