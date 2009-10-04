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
        public void Add_OneNumber_ReturnNumber()
        {
            //arrange
            var numbers = "0";
            //act 
            var calc = new Calculator();
            var result = calc.Add(numbers);
            //assert
            Assert.That(result==0,"One number returned incorrectly");
        }

        [Test]
        public void Add_TwoNumbers_ReturnNumber()
        {
            //arrange
            var numbers = "1,2";
            //act 
            var calc = new Calculator();
            var result = calc.Add(numbers);
            //assert
            Assert.That(result == 3, "2 numbers summed returned incorrectly");
        }

        [Test]
        public void Add_ThreeNumbers_ReturnNumber()
        {
            //arrange
            var numbers = "1,2,1";
            //act 
            var calc = new Calculator();
            var result = calc.Add(numbers);
            //assert
            Assert.That(result == 4, "3 numbers summed returned incorrectly");
        }
        
        [Test]
        public void Add_EmpyString_Return_Zero()
        {
            //arrange
            var numbers = "";
            //act 
            var calc = new Calculator();
            var result = calc.Add(numbers);
            //assert
            Assert.That(result == 0, "Zero string returned incorrectly");
        }

        [Test]
        public void Add_IntMaxAndOne_ExpectError()
        {
            //arrange
            var thrown = false;
            var numbers = "2147483647,1";
            //act 
            var calc = new Calculator();
            try
            {
                var result = calc.Add(numbers);
            }
            catch
            {
                thrown = true;
            }
            //assert
            Assert.IsTrue(thrown, "Exception should be thrown");
        }
    }


}
