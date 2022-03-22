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
      private bool _locked;
      public event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEvent;

      public void SetDoorState(bool newState)
      {
         if (!_locked)
         {
            if (newState != oldState)
            {
               OnDoorStateChanged(new DoorStateChangedEventArgs { DoorState = newState });
               oldState = newState;
            }

            if (newState == true)
            {
               Console.WriteLine("Døren er åben.");
            }
            else
            {
               Console.WriteLine("Døren er lukket.");
            }
         }
         else
         {
            Console.WriteLine("Skabet er låst.");
         }

      }

      public void LockDoor()
      {
         _locked = true;
         OnDoorStateChanged(new DoorStateChangedEventArgs { IsDoorLocked = true });
         Console.WriteLine("Døren er låst");
      }

      public void UnlockDoor()
      {
         _locked = false;
         OnDoorStateChanged(new DoorStateChangedEventArgs { IsDoorLocked = false });
         Console.WriteLine("Døren er ikke låst");
      }

      protected virtual void OnDoorStateChanged(DoorStateChangedEventArgs e)
      {
         DoorStateChangedEvent?.Invoke(this, e);
      }
   }
}
