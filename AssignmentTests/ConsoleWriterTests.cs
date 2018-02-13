using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass()]
    public class ConsoleWriterTests
    {
        [TestMethod()]
        public void TestParseDoubleToDifferentCulture_valid_value()
        {
            //arrange
            double value = 234.523;
            string expected = "234.523";
            
            //act
            string actual = ConsoleWriter.ParseDoubleToDifferentCulture(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestFormatDateTime_valid_value()
        {
            //arrange
            DateTime value = new DateTime(2000,1,1,2,2,2,333);
            string expected = "2000-01-01 02:02:02.333";

            //act
            string actual = ConsoleWriter.FormatDateTime(value);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}