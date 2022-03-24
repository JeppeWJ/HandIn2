﻿using System;
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

      //case LadeskabState.DoorClosed:
      //if (_chargeControl.Connected)
      //{
      //    _door.LockDoor();
      //    _chargeControl.StartCharge();
      //    CurrentRfid = e.Rfid;

      //    _display.WriteToDisplay("Skabet er nu låst og din telefon lader op.");

      //    _state = LadeskabState.DoorLocked;
      //}
      //else
      //{
      //    _display.WriteToDisplay("Telefonen er ikke ordentlig tilsluttet.");
      //}

      [TestCase(true, true, "Skabet er nu låst og din telefon lader op.", "123")]
      public void LadeskabLukket_ChargeControlConnected_test(bool charge, bool isDoorLocked, string text, string Rfid  )
      {
          _uut.IsDoorLocked = isDoorLocked;
          _chargeControl.Connected = charge;
            _rfidSource.RfidDetectedEvent += 
                Raise.EventWith(new RfidDetectedEventArgs() { Rfid = Rfid });


            Assert.That(_uut.CurrentRfid, Is.EqualTo(Rfid));
            _doorSource.Received(1).LockDoor();
            _chargeControl.Received(1).StartCharge();
            _displaySource.WriteToDisplay(text);
      }

      [TestCase()]

      public void LadeskabLukket_ChargeControlNotConnected_test()
      {

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