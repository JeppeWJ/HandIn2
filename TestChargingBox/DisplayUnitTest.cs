using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Channels;
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

        [TestCase("Indlæs RFID")]
        [TestCase("Tilslut oplader")]
        [TestCase("Tilslutningsfejl")]
        public void WriteToDisplayTest(string text)
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);
            _uut.WriteToDisplay(text);
            Assert.AreEqual(text + "\r\n", stringwriter.ToString());
            Assert.Pass();
        }


    }
}
