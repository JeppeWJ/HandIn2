using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.DoorClasses
{
   public class DoorStateChangedEventArgs : EventArgs
   {
      public bool DoorState { get; set; }
   }
}
