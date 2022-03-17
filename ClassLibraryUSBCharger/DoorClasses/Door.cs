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

      public void LockDoor()
      { 
          OnDoorStateChanged(new DoorStateChangedEventArgs {IsDoorLocked = true});
          Console.WriteLine("locked");
      }

      public void UnlockDoor()
      {
          OnDoorStateChanged(new DoorStateChangedEventArgs { IsDoorLocked = false });
          Console.WriteLine("Unlocked");
      }

        protected virtual void OnDoorStateChanged(DoorStateChangedEventArgs e)
      {
         DoorStateChangedEvent?.Invoke(this, e);
      }
   }
}
