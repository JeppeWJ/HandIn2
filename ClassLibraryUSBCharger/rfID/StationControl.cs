using System;
using ClassLibraryChargingBox.Display;
using ClassLibraryChargingBox.DoorClasses;

namespace ClassLibraryChargingBox.rfID
{
    public class StationControl
    {
        public bool CurrentDoorState { get; set; }
        public string CurrentRfid { get; set; }

        private IDoor _door = new Door();
        private IDisplay display = new Display.Display(); 

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
                display.TilslutOplader();
            }
            else
            {
                display.ReadRFID();
            }

           
        }

        public void HandleRfidChangedEvent(object s, RfidDetectedEventArgs e)
        {
            CurrentRfid = e.Rfid;
            Console.WriteLine("CurrentRFID " + CurrentRfid);

            if (CurrentRfid == "12")
            {
                CurrentDoorState = true;
                
                display.LadeskabOptaget();
                _door.LockDoor();
            }
            else
            {
                CurrentDoorState = false;

            }
        }



    }

}

