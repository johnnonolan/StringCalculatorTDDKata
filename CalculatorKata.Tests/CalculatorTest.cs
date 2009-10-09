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
            //arrange 
            //act          
            var calculator = new Calculator();
            var result = calculator.Add("");
            //assert
            Assert.That(0 == result, result.ToString());
        }

        [Test]
        public void Add_OneNumber_ReturnsNumber()
        {
            //arrange 
            //act
            var calculator = new Calculator();
            var result = calculator.Add("2");
            //assert
            Assert.That(2 == result, result.ToString());
        }

        [Test]
        public void Add_TwoNumbers_ReturnsSumOfNumbers()
        {
            //arrange 
            var numberString = "1,2";
            //act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //assert
            Assert.That(3 == result, result.ToString());
        }

        [Test]
        public void Add_ManyNumbers_ReturnsSumOfNumbers()
        {
            //arrange 
            var numberString = "1,2,3";
            //act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //assert
            Assert.That(6 == result, result.ToString());
        }
        [Test]
        public void Add_HandleNewLinesInInputWithManyNumbers_ReturnSumOfNumbers()
        {
            //arrange 
            var numberString = "1\n2,3";
            //act
            var calculator = new Calculator();
            var result = calculator.Add(numberString);
            //assert
            Assert.That(6 == result, result.ToString());

        }


    }


}
