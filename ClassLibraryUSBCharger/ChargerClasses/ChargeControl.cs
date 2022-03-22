using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.ChargerClasses
{
   public class ChargeControl : IChargeControl
   {
      public double CurrentValue { get; set; }
      public ChargeControl(IUsbCharger usbCharger)
      {
         usbCharger.CurrentValueEvent += HandleCurrentChangedEvent;
      }

      private void HandleCurrentChangedEvent(object sender, CurrentEventArgs e)
      {
         CurrentValue = e.Current;

         Console.WriteLine(CurrentValue);
      }
   }
}
