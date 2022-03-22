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
        public void WriteToDisplay(string text)
        {
            Console.WriteLine(text);
        }

    }
}
