using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryChargingBox.ChargerClasses;
using NUnit.Framework;

namespace TestChargingBox
{
   public class UsbChargerSimulatorUnitTest
   {
      private IUsbCharger _uut;
      private CurrentEventArgs _receivedCurrentEventArgs;
      [SetUp]
      public void Setup()
      {
         _receivedCurrentEventArgs = null;

         _uut = new UsbChargerSimulator();
         _uut.StopCharge();

         _uut.CurrentValueEvent +=
            (o, args) =>
            {
               _receivedCurrentEventArgs = args;
            };
      }
      #region StartCharge Not Connected and Not Overload
      [Test]
      public void StartCharge_NotConnected_EventFired()
      {
         _uut.StartCharge();
         Assert.That(_receivedCurrentEventArgs, Is.Not.Null);
      }

      [Test]
      public void StartCharge_NotConnected_CorrectCurrentReceived()
      {
         _uut.StartCharge();
         Assert.That(_receivedCurrentEventArgs.Current, Is.EqualTo(0));
      }
      #endregion
      #region StartCharge Connected and Not Overload
      [Test]
      public void StartCharge_ConnectedandNotOverload_EventFired()
      {
         _uut.SimulateConnected(true);
         _uut.StartCharge();
         Assert.That(_receivedCurrentEventArgs, Is.Not.Null);
      }

      [Test]
      public void StartCharge_ConnectedandNotOverload_CorrectCurrentReceived()
      {
         _uut.SimulateConnected(true);
         _uut.StartCharge();
         Assert.That(_receivedCurrentEventArgs.Current, Is.EqualTo(500));
      }
      #endregion
      #region StartCharge Connected and Overload
      [Test]
      public void StartCharge_ConnectedandOverload_EventFired()
      {
         _uut.SimulateConnected(true);
         _uut.SimulateOverload(true);

         _uut.StartCharge();
         Assert.That(_receivedCurrentEventArgs, Is.Not.Null);
      }

      [Test]
      public void StartCharge_ConnectedandOverload_CorrectCurrentReceived()
      {
         _uut.SimulateConnected(true);
         _uut.SimulateOverload(true);

         _uut.StartCharge();
         Assert.That(_receivedCurrentEventArgs.Current, Is.EqualTo(700));
      }
      #endregion
      #region StartCharge AlreadyCharging
      [Test]
      public void StartCharge_AlreadyCharging_NoEventFired()
      {
         _uut.StartCharge();
         _receivedCurrentEventArgs = null;

         _uut.StartCharge();

         Assert.That(_receivedCurrentEventArgs, Is.Null);
      }
      #endregion
      #region StopCharge
      [Test]
      public void StopCharge_EventFired()
      {
         _uut.StopCharge();
         Assert.That(_receivedCurrentEventArgs, Is.Not.Null);
      }

      [Test]
      public void StopCharge_CorrectCurrentReceived()
      {
         _uut.StopCharge();
         Assert.That(_receivedCurrentEventArgs.Current, Is.EqualTo(0));
      }
      #endregion
   }
}
