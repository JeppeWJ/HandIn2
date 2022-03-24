using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryChargingBox.ChargerClasses;
using ClassLibraryChargingBox.Display;
using ClassLibraryChargingBox.DoorClasses;
using ClassLibraryChargingBox.rfID;
using NSubstitute;
using NUnit.Framework;

namespace TestChargingBox
{
   public class StationControlUnitTest
   {
      private StationControl _uut;
      private IDoor _doorSource;
      private IReader _rfidSource;
      private IChargeControl _chargeControl;
      private IDisplay _displaySource;
      [SetUp]
      public void Setup()
      {
         _doorSource = Substitute.For<IDoor>();
         _rfidSource = Substitute.For<IReader>();
         _chargeControl = Substitute.For<IChargeControl>();
         _displaySource = Substitute.For<IDisplay>();

         _uut = new StationControl(_doorSource, _rfidSource, _chargeControl, _displaySource);
      }

      [TestCase(true)]
      [TestCase(false)]
      public void DoorStateChanged_CorrectStateReceived(bool IsDoorOpen)
      {
         _doorSource.DoorStateChangedEvent +=
            Raise.EventWith(new DoorStateChangedEventArgs() {IsDoorOpen = IsDoorOpen});
         Assert.That(_uut.CurrentDoorState, Is.EqualTo(IsDoorOpen));
      }
      [TestCase(true)]
      [TestCase(false)]
      public void DoorLockedandUnlocked_CorrectStateReceived(bool IsDoorLocked)
      {
         _doorSource.DoorStateChangedEvent +=
            Raise.EventWith(new DoorStateChangedEventArgs() { IsDoorLocked = IsDoorLocked });
         Assert.That(_uut.IsDoorLocked, Is.EqualTo(IsDoorLocked));
      }

     
      [TestCase("123", "123", true, "Skabet er nu åbent. Tag din telefon.")]
      public void UnLockDoor_Test(string oldId, string newId, bool charge, string text)
      {
          _chargeControl.Connected = charge;
          _rfidSource.RfidDetectedEvent +=
              Raise.EventWith(new RfidDetectedEventArgs() { Rfid = oldId});
          _rfidSource.RfidDetectedEvent +=
              Raise.EventWith(new RfidDetectedEventArgs() { Rfid = newId });


            _doorSource.Received(1).UnlockDoor();
          _chargeControl.Received(1).StopCharge();
          _displaySource.Received(1).WriteToDisplay(text);

        }

      [TestCase("123", "234", true, "Forkert Rfid")]
      public void UnLockDoorWrongId_Test(string oldId, string newId, bool charge, string text)
      {
          _chargeControl.Connected = charge;
          _rfidSource.RfidDetectedEvent +=
              Raise.EventWith(new RfidDetectedEventArgs() { Rfid = oldId });
          _rfidSource.RfidDetectedEvent +=
              Raise.EventWith(new RfidDetectedEventArgs() { Rfid = newId });

           
            _displaySource.Received(1).WriteToDisplay(text);

      }
    }
}
