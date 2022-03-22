using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryChargingBox.ChargerClasses;
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
      [SetUp]
      public void Setup()
      {
         _doorSource = Substitute.For<IDoor>();
         _rfidSource = Substitute.For<IReader>();
         _chargeControl = Substitute.For<IChargeControl>();

         _uut = new StationControl(_doorSource, _rfidSource, _chargeControl);
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



   }
}
