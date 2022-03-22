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
      public bool Connected { get; set; }
      private IUsbCharger _charger;

      public ChargeControl(IUsbCharger usbCharger)
      {
         usbCharger.CurrentValueEvent += HandleCurrentChangedEvent;
         _charger = usbCharger;
      }

      public void StartCharge()
      {
        _charger.StartCharge();
      }

      public void StopCharge()
      {
         _charger.StopCharge();
      }

      private void HandleCurrentChangedEvent(object sender, CurrentEventArgs e)
      {
         CurrentValue = e.Current;
         Connected = e.Connected;
      }
   }
}
