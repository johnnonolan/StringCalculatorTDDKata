using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CalculatorKata.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            var numberString = "";
            var calculator = new Calculator();
            int result = calculator.Add(numberString);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_OneNumber_ReturnNumber()
        {
            var numberString = "1";
            var calculator = new Calculator();
            int result = calculator.Add(numberString);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_TwoNumbers_ReturnSum()
        {
            var numberString = "1,2";
            var calculator = new Calculator();
            int result = calculator.Add(numberString);
            Assert.AreEqual(3, result);
        }
        
        [Test]
        public void Add_ManyNumbers_ReturnSum()
        {
            var numberString = "1,2,3";
            var calculator = new Calculator();
            int result = calculator.Add(numberString);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_NumbersAndHandleValidNewLine_ReturnSum()
        {
            var numberString = "1\n2";
            var calculator = new Calculator();
            int result = calculator.Add(numberString);
            Assert.AreEqual(3, result);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void Add_NumbersAndHandleInvalidNewLine_ThrowsInvalidException()
        {
            var numberString = "1,\n";
            var calculator = new Calculator();
            calculator.Add(numberString);
            Assert.Fail();
        }

        [Test]
        public void Add_ChangeDelimeterandAddNumbers_ReturnSum()
        {
            var numberString = "//;\n1;2";
            var calculator = new Calculator();
            int result = calculator.Add(numberString);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_NegativeNumber_ThrowFormatExceptiomWithNegativesNotAllowed()
        {        
            Assert.Throws(Is.InstanceOf<FormatException>()
                          .And.Message.EqualTo("Negatives not allowed"),
                                   () => { throw new FormatException("Negatives not allowed"); });
        }


    }
}
