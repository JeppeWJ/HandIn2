namespace ClassLibraryChargingBox.rfID
{
    public class StationControl
    {
       

        public string CurrentRfid { get; set; }

        public StationControl(IReader reader)
        {
            reader.RfidDetectedEvent += HandleRfidChangedEvent;
        }

        public void HandleRfidChangedEvent(object s, RfidDetectedEventArgs e)
        {
            CurrentRfid = e.Rfid;
        }
    }
}
