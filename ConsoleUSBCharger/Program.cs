using System;
using ClassLibraryChargingBox.ChargerClasses;
using ClassLibraryChargingBox.DoorClasses;
using ClassLibraryChargingBox.rfID;

namespace ConsoleUSBCharger
{
   class Program
   {
      static void Main(string[] args)
      {
          Door door = new Door();

          RfidReader rfidReader = new RfidReader();
          StationControl stationControl = new StationControl(door, rfidReader);

          

          rfidReader.SetRfid(Console.ReadLine());
      }
   }
}
