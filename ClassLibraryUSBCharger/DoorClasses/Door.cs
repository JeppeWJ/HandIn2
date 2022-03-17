using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.DoorClasses
{
   public class Door : IDoor
   {
      private bool oldState;
      public event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEvent;

      public void SetDoorState(bool newState)
      {
         if (newState != oldState)
         {
            OnDoorStateChanged(new DoorStateChangedEventArgs{DoorState = newState});
            oldState = newState;
         }
      }

      public void LockDoor(string ID)
      { 
          OnDoorStateChanged(new DoorStateChangedEventArgs {IsDoorLocked = true});
      }

      public void UnlockDoor(string ID)
      {
          if (ID == "123456")
          {
              OnDoorStateChanged(new DoorStateChangedEventArgs { IsDoorLocked = false });
          }
          else
          {
              OnDoorStateChanged(new DoorStateChangedEventArgs { IsDoorLocked = true });
          }

      }

        protected virtual void OnDoorStateChanged(DoorStateChangedEventArgs e)
      {
         DoorStateChangedEvent?.Invoke(this, e);
      }
   }
}
