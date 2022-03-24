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
      public bool IsDoorLocked { get; set; }
      public string CurrentRfid { get; set; }

      private LadeskabState _state;

      private IDoor _door;
      private IDisplay display = new Display.Display();
      private ILogging _log;
      private IChargeControl _chargeControl;
      private IDisplay _display;

      public StationControl(IDoor door, IReader reader, IChargeControl chargeControl, IDisplay display, ILogging log)
      {
         door.DoorStateChangedEvent += HandleDoorStateChangedEvent;
         reader.RfidDetectedEvent += HandleRfidChangedEvent;
         _state = LadeskabState.DoorClosed;

         _display = display;
         _chargeControl = chargeControl;
         _door = door;
         _log = log;
      }

      private void HandleDoorStateChangedEvent(object sender, DoorStateChangedEventArgs e)
      {

         if (e.IsDoorOpen && !e.IsDoorLocked)
         {
            _state = LadeskabState.Dooropen;
            _display.WriteToDisplay("Tilslut telefon");
         }
         else if (!e.IsDoorOpen && !e.IsDoorLocked)
         {
            _state = LadeskabState.DoorClosed;
            if (e.IsDoorOpen != CurrentDoorState)
            {
               _display.WriteToDisplay("Indlæs RFID");
            }
         }
         CurrentDoorState = e.IsDoorOpen;
         IsDoorLocked = e.IsDoorLocked;
      }

      public void HandleRfidChangedEvent(object s, RfidDetectedEventArgs e)
      {
         switch (_state)
         {
            case LadeskabState.DoorClosed:
               if (_chargeControl.Connected)
               {
                  _door.LockDoor();
                  _log.LogDoorLocked(e.Rfid);

                  _chargeControl.StartCharge();
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
                  _log.LogDoorUnlocked(e.Rfid);
                  _chargeControl.StopCharge();

                  _display.WriteToDisplay("Skabet er nu åbent. Tag din telefon.");

                  _state = LadeskabState.DoorClosed;
               }
               else
               {
                  // _door.UnlockDoor();
                   _display.WriteToDisplay("Forkert Rfid");
               }
               break;
            case LadeskabState.Dooropen:
               break;
         }
        
      }



   }

}

