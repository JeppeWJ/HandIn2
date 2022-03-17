using System;
using ClassLibraryChargingBox.DoorClasses;

namespace ClassLibraryChargingBox.rfID
{
    public class StationControl
    {
        public bool CurrentDoorState { get; set; }

        public StationControl(IDoor door)
        {
            door.DoorStateChangedEvent += HandleDoorStateChangedEvent;
        }

        private void HandleDoorStateChangedEvent(object sender, DoorStateChangedEventArgs e)
        {
            CurrentDoorState = e.DoorState;
            if (e.DoorState)
            {
                Console.WriteLine("Døren er nu åben.");
            }
            else
            {
                Console.WriteLine("Døren er nu lukket.");
            }
        }


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

