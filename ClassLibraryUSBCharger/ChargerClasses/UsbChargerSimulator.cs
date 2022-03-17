using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.ChargerClasses
{
   public class UsbChargerSimulator : IUsbCharger
   {
      public event EventHandler<CurrentEventArgs> CurrentValueEvent;
      public double CurrentValue { get; private set; }
      public bool Connected { get; private set; }
      private bool _overload;
      private bool _charging;

      public UsbChargerSimulator()
      {
         CurrentValue = 0.0;
         Connected = false;
         _overload = false;
         _charging = false;
      }
      public void StartCharge()
      {
         if (!_charging)
         {
            if (Connected && !_overload)
            {
               CurrentValue = 500;
            }
            else if (Connected && _overload)
            {
               CurrentValue = 700;
            }
            else if (!Connected)
            {
               CurrentValue = 0.0;
            }
            OnNewCurrent();
            _charging = true;
         }
      }

      public void StopCharge()
      {
         CurrentValue = 0.0;
         OnNewCurrent();

         _charging = false;
      }

      public void SimulateConnected(bool connected)
      {
         Connected = connected;
      }

      public void SimulateOverload(bool overload)
      {
         _overload = overload;
      }

      private void OnNewCurrent()
      {
         CurrentValueEvent?.Invoke(this, new CurrentEventArgs() {Current = this.CurrentValue});
      }
   }
}
