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
        
        private ILogging _uut;
        //private List<string> _testLogList;

        [SetUp]
        public void SetUp()
        {
            //_testLogList = new List<string>();
            _uut = new FileLogging();
        }

        [Test]

        [TestCase("12345")]
        public void TestLogDoorLocked(string toLog)
        {
            

            _uut.LogDoorLocked(toLog);
            var result = _uut.logList.Last();
            

            Assert.AreEqual(toLog,result);


            //Tidligere kode...
            //_logging.LogDoorLocked("");
            //_logging.Received(1).LogDoorLocked("");


        }
        [TestCase("123456")]
        public void TestLogDoorUnlocked(string toLog)
        {
            _uut.LogDoorUnlocked(toLog);
            var result = _uut.logList.Last();

            Assert.AreEqual(toLog,result);

        }
    }
}
