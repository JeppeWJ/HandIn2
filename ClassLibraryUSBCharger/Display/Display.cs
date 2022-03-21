using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClassLibraryChargingBox.Display
{
   public class Display : IDisplay
    {
        
        public void TilslutOplader()
        {
            Console.WriteLine("Tilslut oplader");
        }

        public void ReadRFID()
        {
            Console.WriteLine("Indlæs RFID");
        }

        public void Tilslutningsfejl()
        {
            Console.WriteLine("Tilslutningsfejl");
        }

        public void LadeskabOptaget()
        {
            Console.WriteLine("Ladeskabet er optaget");
        }

        public void RFIDFejl()
        {
            Console.WriteLine("RFID fejl");
        }

        public void FjernTelefon()
        {
            Console.WriteLine("Fjern telefon");
        }
    }
}
