using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.ChargerClasses
{
   public class CurrentEventArgs : EventArgs
   {
      // Value in mA (milliAmpere)
      public double Current { set; get; }
      public bool Connected { set; get; }
   }
}
