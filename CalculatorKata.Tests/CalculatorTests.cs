using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CalculatorKata;

namespace CalculatorKata.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        
        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            //Arrange
            var numberString = "";
            //Act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //Assert
            Assert.AreEqual(0, result);

        }

        [Test]
        public void Add_OneNumber_ReturnNumber()
        {
            //Arrange
            var numberString = "1";
            //Act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //Assert
            Assert.AreEqual(1, result);

        }

        
        [Test]
        public void Add_TwoNumbers_ReturnSum()
        {
            //Arrange
            var numberString = "1,2";
            //Act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //Assert
            Assert.AreEqual(3, result);
        }


        [Test]
        public void Add_ThreeNumbers_ReturnSum()
        {
            //Arrange
            var numberString = "1,2,3";
            //Act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_ThreeNumbersWithValidNewLine_ReturnSum()
        {
            //Arrange
            var numberString = "1\n2,3";
            //Act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void Add_OneNumberWithInvalidNewLine_ThrowFormatException()
        {
            //Arrange
            var numberString = "1,\n";
            //Act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //Assert
            Assert.Fail();
        }

        [Test]
        public void Add_DelimeterChangeAndTwoNumbers_ReturnSum()
        {
            //Arrange
            var numberString = "//;\n1,2";
            //Act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //Assert
            Assert.AreEqual(3, result);
        }

    }
}
