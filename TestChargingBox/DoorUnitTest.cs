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
         Assert.That(_receivedEventArgs.DoorState, Is.False);
      }
   }
}