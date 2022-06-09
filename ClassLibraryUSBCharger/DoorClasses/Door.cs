using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.DoorClasses
{
   public class Door : IDoor
   {
      private bool oldState;
      private bool IsDoorLocked;
      public event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEvent;

      public Door()
      {
         IsDoorLocked = false;
      }

      public void SetDoorState(bool newState)
      {
        
            if (newState != oldState )
            {
               OnDoorStateChanged(new DoorStateChangedEventArgs { IsDoorOpen = newState, IsDoorLocked = IsDoorLocked});
               oldState = newState;
            }

            //if (newState == true && !IsDoorLocked)
            //{
            //   Console.WriteLine("Døren er åben.");
            //}
            //else if (newState == false && !IsDoorLocked)
            //{
            //   Console.WriteLine("Døren er lukket.");
            //}
        

      }

      public void LockDoor()
      {
         OnDoorStateChanged(new DoorStateChangedEventArgs { IsDoorLocked = true });
         IsDoorLocked = true;
      }

      public void UnlockDoor()
      {
         OnDoorStateChanged(new DoorStateChangedEventArgs { IsDoorLocked = false });
         IsDoorLocked = false;

      }

      protected virtual void OnDoorStateChanged(DoorStateChangedEventArgs e)
      {
         DoorStateChangedEvent?.Invoke(this, e);
      }
   }
}
