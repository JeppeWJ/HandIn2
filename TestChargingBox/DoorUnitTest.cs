using ClassLibraryChargingBox.DoorClasses;
using NUnit.Framework;

namespace TestChargingBox
{
   public class Tests
   {
      private IDoor _uut;
      private DoorStateChangedEventArgs _receivedEventArgs;

      [SetUp]
      public void Setup()
      {
         _receivedEventArgs = null;

         _uut = new Door();
         _uut.SetDoorState(true);

         _uut.DoorStateChangedEvent +=
            (o, args) =>
            {
               _receivedEventArgs = args;   
            };
      }

      [Test]
      public void SetDoorState_StateSet_EventFired()
      {
         _uut.SetDoorState(false);
         Assert.That(_receivedEventArgs, Is.Not.Null);
      }

      [Test]
      public void SetDoorState_StateSet_CorrectStateReceived()
      {
         _uut.SetDoorState(false);
         Assert.That(_receivedEventArgs.IsDoorOpen, Is.False);
      }

      [Test]
      public void LockDoor_EventFired()
      {
         _uut.LockDoor();
         Assert.That(_receivedEventArgs, Is.Not.Null);
      }
      [Test]
      public void LockDoor_CorrectEventRecevied()
      {
         _uut.LockDoor();
         Assert.That(_receivedEventArgs.IsDoorLocked, Is.True);
      }
      [Test]
      public void UnlockDoor_EventFired()
      {
         _uut.UnlockDoor();
         Assert.That(_receivedEventArgs, Is.Not.Null);
      }
      [Test]
      public void UnlockDoor_CorrectEventReceived()
      {
         _uut.UnlockDoor();
         Assert.That(_receivedEventArgs.IsDoorLocked, Is.False);
      }
   }
}