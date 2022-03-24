using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryChargingBox.Display;

namespace ClassLibraryChargingBox.ChargerClasses
{
   public class ChargeControl : IChargeControl
   {
      public double CurrentValue { get; set; }
      public bool Connected { get; set; }
      private IUsbCharger _charger;
      private IDisplay _display;

      public ChargeControl(IUsbCharger usbCharger, IDisplay display)
      {
         usbCharger.CurrentValueEvent += HandleCurrentChangedEvent;
         _charger = usbCharger;
         _display = display;
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

         if (CurrentValue > 500)
         {
            _display.WriteToDisplay("Ladefejl! Stop straks opladning!");
         }
      }
   }
}
