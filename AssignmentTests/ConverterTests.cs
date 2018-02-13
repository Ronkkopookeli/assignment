using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass()]
    public class ConverterTests
    {
        [TestMethod()]
        public void TestCheckComplexity_valid_value()
        {
            //arrange
            string value = "Simple";
            string expected = "Simple";

            //act
            string actual = Converter.CheckComplexityValue(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestParseDateTimeValue_valid_value()
        {
            //arrange
            string value = "2000-05-11 04:58:34.456";
            DateTime expected = new DateTime(2000, 5, 11, 4, 58, 34, 456);

            //act
            DateTime actual = new DateTime();
            actual = Converter.ParseDateTimeValue(value);

            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        public void TestCheckMoneyValidity_valid_value()
        {
            //arrange
            string value = "654321.98765";
            double expected = 654321.98765;

            //act
            double? result = Converter.CheckMoneyValidity(value);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}