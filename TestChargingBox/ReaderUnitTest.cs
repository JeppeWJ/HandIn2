using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryChargingBox.rfID;
using NUnit.Framework;

namespace TestChargingBox
{
    public class ReaderUnitTest
    {
        private RfidReader _uut;
        private RfidDetectedEventArgs _detectedEventArgs;

        [SetUp]
        public void SetUp()
        {
            _detectedEventArgs = null;

            _uut = new RfidReader();
            _uut.SetRfid("12");

            _uut.RfidDetectedEvent +=
                (o, args) =>
                {
                    _detectedEventArgs = args;
                };
        }

        [Test]
        public void SetRfid_RfidSet_EventFired()
        {
            _uut.SetRfid("12");
            Assert.That(_detectedEventArgs, Is.Not.Null);
        }

        [Test]
        public void SetRfid_RfidSet_CorrectIdReceived()
        {
            _uut.SetRfid("23");
            Assert.That(_detectedEventArgs.Rfid, Is.EqualTo("23"));
        }
    }
}
