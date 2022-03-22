using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.ChargerClasses
{
   public interface IChargeControl
   {
      double CurrentValue { get; }
      bool Connected { get; set; }
      void StartCharge();
      void StopCharge();
   }
}
