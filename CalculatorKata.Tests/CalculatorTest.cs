using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CalculatorKata.Tests
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            var numberString = "";

            var calculator = new Calculator();
            var result = calculator.Add(numberString);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_OneNumber_ReturnNumber()
        {
            var numberString = "1";

            var calculator = new Calculator();
            var result = calculator.Add(numberString);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_TwoNumber_ReturnSum()
        {
            var numberString = "1,2";

            var calculator = new Calculator();
            var result = calculator.Add(numberString);

            Assert.AreEqual(3, result);
       }


        [Test]
        public void Add_UknownNumbers_ReturnSum()
        {
            var numberString = "1,2,3";

            var calculator = new Calculator();
            var result = calculator.Add(numberString);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_NumbersWithNewLinesAndDelims_ReturnSum()
        {
            var numberString = "1\n2,3";

            var calculator = new Calculator();
            var result = calculator.Add(numberString);

            Assert.AreEqual(6, result);
        }

        [Test]
        [ExpectedException(typeof(System.FormatException))]
        public void Add_NumbersWithNewLinesAndTrailingDelims_ThrowFormatException()
        {
            var numberString = "1,\n";

            var calculator = new Calculator();
            var result = calculator.Add(numberString);

            Assert.Fail();
        }
        [Test]
        public void Add_NumbersWithDelimiterChange_ReturnsSum()
        {
            var numberString = "//|\n1|2";

            var calculator = new Calculator();
            var result = calculator.Add(numberString);

            Assert.AreEqual(3, result);
        }


    }


}
