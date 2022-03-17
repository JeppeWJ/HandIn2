﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.ChargerClasses
{
   public interface IUsbCharger
   {
      // Event triggered on new current value
      event EventHandler<CurrentEventArgs> CurrentValueEvent;

      // Direct access to the current current value
      double CurrentValue { get; }

      // Require connection status of the phone
      bool Connected { get; }

      // Start charging
      void StartCharge();
      // Stop charging
      void StopCharge();
      void SimulateConnected(bool connected);
      void SimulateOverload(bool overload);
   }
}
