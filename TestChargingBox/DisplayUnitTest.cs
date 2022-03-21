using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ClassLibraryChargingBox.Display;

namespace TestChargingBox
{
   public class DisplayUnitTest
   {
       private IDisplay _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        [TestCase("Indlæs RFID", "Indlæs RFID")]
        [TestCase("Tilslut oplader", "Tilslut oplader")]
        [TestCase("Tilslutningsfejl", "Tilslutningsfejl")]
        public void WriteToDisplayTest(string exp, string text)
        {
            string _textTrue = _uut.WriteToDisplay(text);
            Assert.That(exp, Is.EqualTo(_textTrue));
        }

        [TestCase("Indlæs RFID", "Indlæs RFI")]
        [TestCase("Tilslut oplader", "Tilslut oplades")]
        [TestCase("Tilslutningsfelj", "Tilslutningsfejl")]
        public void WriteToDisplayTes(string exp, string text)
        {
            string _textFalse = _uut.WriteToDisplay(text);
            Assert.That(exp, Is.Not.EqualTo(_textFalse));
        }
    }
}
