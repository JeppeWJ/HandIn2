using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.DoorClasses
{
   public interface IDoor
   {
      event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEvent;
      void SetDoorState(bool newState);

      void LockDoor(string iD);

      void UnlockDoor(string iD);
   }
}
