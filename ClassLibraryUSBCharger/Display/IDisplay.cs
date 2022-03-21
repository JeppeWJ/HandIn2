using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryChargingBox.Display
{
    interface IDisplay
    { 
        void TilslutOplader();
        void ReadRFID();
        void Tilslutningsfejl();
        void LadeskabOptaget();
        void RFIDFejl();
        void FjernTelefon();


    }
}
