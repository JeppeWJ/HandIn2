﻿using System;
using ClassLibraryChargingBox.Display;
using ClassLibraryChargingBox.DoorClasses;
using ClassLibraryChargingBox.Logging;

namespace ClassLibraryChargingBox.rfID
{
    public class StationControl
    {
       private enum LadeskabState
       {
         Available,
         DoorLocked,
         Dooropen
       };
        public bool CurrentDoorState { get; set; }
        public string CurrentRfid { get; set; }

        private LadeskabState _state;

        private IDoor _door = new Door();
        private IDisplay display = new Display.Display();
        private ILogging _log = new FileLogging();

        public StationControl(IDoor door, IReader reader)
        {
            door.DoorStateChangedEvent += HandleDoorStateChangedEvent;
            reader.RfidDetectedEvent += HandleRfidChangedEvent;
            _state = LadeskabState.Available;
        }

        private void HandleDoorStateChangedEvent(object sender, DoorStateChangedEventArgs e)
        {
            CurrentDoorState = e.DoorState;

            if (e.DoorState)
            {
                display.WriteToDisplay("Tilslut oplader");
            }
            else
            {
                display.WriteToDisplay("Indlæs RFID");
            }

           
        }

        public void HandleRfidChangedEvent(object s, RfidDetectedEventArgs e)
        {

            CurrentRfid = e.Rfid;
            Console.WriteLine("CurrentRFID " + CurrentRfid);

            if (CurrentRfid == "12")
            {
                CurrentDoorState = true;
                
                display.WriteToDisplay("Ladeskabet er optaget");
                _door.LockDoor();
                _log.LogDoorLocked(CurrentRfid);
            }
            else
            {
                CurrentDoorState = false;

            }
        }



    }

}

