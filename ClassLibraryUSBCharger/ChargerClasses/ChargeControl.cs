﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.ChargerClasses
{
   public class ChargeControl
   {
      public double CurrentValue { get; set; }
      public ChargeControl(IUsbCharger usbCharger)
      {
         usbCharger.CurrentValueEvent += CurrentChangedEvent;
      }

      private void CurrentChangedEvent(object sender, CurrentEventArgs e)
      {
         CurrentValue = e.Current;

         Console.WriteLine(CurrentValue);
      }
   }
}