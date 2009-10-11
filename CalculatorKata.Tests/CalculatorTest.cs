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

            var calc = new Calculator();
            var result =calc.Add(numberString);
            Assert.AreEqual(0, result);

        }

        [Test]
        public void Add_OneNumber_ReturnNumber()
        {
            var numberString = "1";

            var calc = new Calculator();
            var result =calc.Add(numberString);
            Assert.AreEqual(1, result);

        }

        [Test]
        public void Add_TwoNumbers_ReturnSumOfNumbers()
        {
            var numberString = "1,2";

            var calc = new Calculator();
            var result = calc.Add(numberString);
            Assert.AreEqual(3, result);

        }

        [Test]
        public void Add_ThreeNumbers_ReturnSumOfNumbers()
        {
            var numberString = "1,2,3";

            var calc = new Calculator();
            var result = calc.Add(numberString);
            Assert.AreEqual(6, result);

        }

        [Test]
        public void Add_FourNumbers_ReturnSumOfNumbers()
        {
            var numberString = "1,1,1,1";

            var calc = new Calculator();
            var result = calc.Add(numberString);
            Assert.AreEqual(4, result);

        }

        [Test]
        public void Add_NumbersWithNewLineActingAsADelimieter_ReturnSumOfNumbers()
        {
            var numberString = "1\n2";

            var calc = new Calculator();
            var result = calc.Add(numberString);
            Assert.AreEqual(3, result);

        }


        [Test]
        [ExpectedException(typeof(FormatException))]
        public void Add_NumbersWithNewLineActingAsADelimieterAtEnd_ThrowsFormatExeption()
        {
            var numberString = "1,\n";

            var calc = new Calculator();
            var result = calc.Add(numberString);
            Assert.Fail();

        }

        [Test]
        public void Add_NumbersWithChangeDelimieter_ReturnSumOfNumbers()
        {
            var numberString = "//|\n1|2";

            var calc = new Calculator();
            var result = calc.Add(numberString);
            Assert.AreEqual(3, result);

        }



    }


}
