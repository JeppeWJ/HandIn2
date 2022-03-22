using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryChargingBox.ChargerClasses;
using NSubstitute;
using NUnit.Framework;

namespace TestChargingBox
{
   public class ChargeControlUnitTest
   {
      private ChargeControl _uut;
      private IUsbCharger _currentSource;
      [SetUp]
      public void Setup()
      {
         _currentSource = Substitute.For<IUsbCharger>();
         _uut = new ChargeControl(_currentSource);
      }

      [TestCase(0)]
      [TestCase(100)]
      [TestCase(200)]
      public void CurrentChanged_DifferentCurrents_CurrentIsCorrect(double newCurrent)
      {
         _currentSource.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs {Current = newCurrent});

         Assert.That(_uut.CurrentValue, Is.EqualTo(newCurrent));
      }

      [Test]
      public void StartCharge_CorrectNumberofCallsOnStartChargeCurrentSource()
      {
         _uut.StartCharge();
         _currentSource.Received(1).StartCharge();
      }
      [Test]
      public void StopCharge_CorrectNumberofCallsOnStopChargeCurrentSource()
      {
         _uut.StopCharge();
         _currentSource.Received(1).StopCharge();
      }
   }
}
