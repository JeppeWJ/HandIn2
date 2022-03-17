using System;
using ClassLibraryChargingBox.DoorClasses;

namespace ClassLibraryChargingBox.rfID
{
    public class StationControl
    {
        public bool CurrentDoorState { get; set; }
        public string CurrentRfid { get; set; }

        private IDoor _door = new Door();

        public StationControl(IDoor door, IReader reader)
        {
            door.DoorStateChangedEvent += HandleDoorStateChangedEvent;
            reader.RfidDetectedEvent += HandleRfidChangedEvent;
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
                Console.WriteLine("Døren er nu lukket. Indlæs RFID");
            }

           
        }

        public void HandleRfidChangedEvent(object s, RfidDetectedEventArgs e)
        {
            CurrentRfid = e.Rfid;
            Console.WriteLine("CurrentRFID" + CurrentRfid);

            if (CurrentRfid == "12")
            {
                CurrentDoorState = true;
                
                Console.WriteLine("Skabet er optaget");
                _door.LockDoor();
            }
            else
            {
                CurrentDoorState = false;
            }
        }



    }

}

