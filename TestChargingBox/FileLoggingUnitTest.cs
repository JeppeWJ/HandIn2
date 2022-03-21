using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryChargingBox.DoorClasses;
using ClassLibraryChargingBox.Logging;
using ClassLibraryChargingBox.rfID;
using NSubstitute;
using NUnit.Framework;

namespace TestChargingBox
{
    public class FileLoggingUnitTest
    {
        
        private ILogging _logging;

        [SetUp]
        public void SetUp()
        {
            
            _logging = Substitute.For<ILogging>();
        }

        [Test]
        public void TestFileLoggingIsCalled()
        {
            //Jeg ved ikke hvordan vi skal teste det her med logging
            //korrekt/bedst. Jeg har fundet et løsningsforslag til en
            //doorControl, hvor Frank tester på nedenstående måde om
            //en metode er kaldt med Substitude

            _logging.LogDoorLocked("");
            _logging.Received(1).LogDoorLocked("");
            
        }
    }
}
