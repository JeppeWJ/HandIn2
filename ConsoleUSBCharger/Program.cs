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
         IDoor door = new Door();
         IReader rfidReader = new RfidReader();
         StationControl stationControl = new StationControl(door, rfidReader);

         IUsbCharger usbCharger = new UsbChargerSimulator();
         ChargeControl chargeControl = new ChargeControl(usbCharger);

         //Man har mulighed for at interagere med 3 ting. Skabsdøren, Rfidlæseren og usb laderen.

         //Skabsdøren kan åbnes ('o') og lukkes ('c').
         //Rfidlæseren kan læse et nyt Rfid ('r' efterfulgt af tal id)
         //Usb laderen kan tilsluttes en telefon ('l'), afbrydes fra en telefon ('k') og der kan simuleres et overload ('f').

         //Til sidst kan programmet afsluttes ('e').

         bool finish = false;

         Console.WriteLine("Kontrol af dør.\n[o] - Åben dør\n[c] - Luk dør\n");
         Console.WriteLine("Kontrol af Rfid læser\n[r] - Indlæs nyt rfid\n");
         Console.WriteLine("Kontrol af opladeren\n[l] - Tilslut mobil\n[k] - Afbryd mobil\n[f] - Simuler overload.\n[g] - Fjern overload\n");
         Console.WriteLine("Tryk [e] for afslutte programmet.");

         while (!finish)
         {
            string input;
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
               case 'e':
                  finish = true;
                  break;
               case 'o':
                  door.SetDoorState(true);
                  break;
               case 'c':
                  door.SetDoorState(false);
                  break;
               case 'r':
                  System.Console.WriteLine("Indtast RFID id: ");
                  string id = System.Console.ReadLine();

                  rfidReader.SetRfid(id);
                  break;
               case 'l':
                  usbCharger.SimulateConnected(true);
                  break;
               case 'k':
                  usbCharger.SimulateConnected(false);
                  break;
               case 'f':
                  usbCharger.SimulateOverload(true);
                  break;
               case 'g':
                  usbCharger.SimulateOverload(false);
                  break;
            }
         }

      }
   }
}
