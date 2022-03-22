using System;
using ClassLibraryChargingBox.ChargerClasses;
using ClassLibraryChargingBox.Display;
using ClassLibraryChargingBox.DoorClasses;
using ClassLibraryChargingBox.Logging;

namespace ClassLibraryChargingBox.rfID
{
   public class StationControl
   {
      private enum LadeskabState
      {
         DoorClosed,
         DoorLocked,
         Dooropen
      };
      public bool CurrentDoorState { get; set; }
      public string CurrentRfid { get; set; }

      private LadeskabState _state;

      private IDoor _door;
      private IDisplay display = new Display.Display();
      private ILogging _log = new FileLogging();
      private IChargeControl _charger;
      private IDisplay _display;

      public StationControl(IDoor door, IReader reader, IChargeControl charger)
      {
         door.DoorStateChangedEvent += HandleDoorStateChangedEvent;
         reader.RfidDetectedEvent += HandleRfidChangedEvent;
         _state = LadeskabState.DoorClosed;

         _display = new Display.Display();

         _charger = charger;
         _door = door;
      }

      private void HandleDoorStateChangedEvent(object sender, DoorStateChangedEventArgs e)
      {
         CurrentDoorState = e.DoorState;

         if (e.DoorState)
         {
            display.WriteToDisplay("Tilslut oplader");
            _state = LadeskabState.Dooropen;
         }
         else
         {
            display.WriteToDisplay("Indlæs RFID");
            _state = LadeskabState.DoorClosed;
         }
      }

      public void HandleRfidChangedEvent(object s, RfidDetectedEventArgs e)
      {
         switch (_state)
         {
            case LadeskabState.DoorClosed:
               if (_charger.Connected)
               {
                  _door.LockDoor();
                  _charger.StartCharge();
                  CurrentRfid = e.Rfid;

                  _display.WriteToDisplay("Skabet er nu låst og din telefon lader op.");

                  _state = LadeskabState.DoorLocked;
               }
               else
               {
                  _display.WriteToDisplay("Telefonen er ikke ordentlig tilsluttet.");
               }
               break;
            case LadeskabState.DoorLocked:
               if (e.Rfid == CurrentRfid) 
               {
                  _door.UnlockDoor();
                  _charger.StopCharge();

                  _display.WriteToDisplay("Skabet er nu åbent. Tag din telefon.");

                  _state = LadeskabState.DoorClosed;
               }
               else
               {
                  _display.WriteToDisplay("Forkert Rfid");
               }
               break;
            case LadeskabState.Dooropen:
               break;
         }
        
      }



   }

}

