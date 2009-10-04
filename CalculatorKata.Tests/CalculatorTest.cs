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
        public void Add_EmptyString_ReturnsZero()
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var result= calc.Add("");
            //Assert
            Assert.AreEqual(0, result);
        }
        [Test]
        public void Add_Number_ReturnsNumber()
        {
            
            //Arrange
            var input = 4.01m;             
            //Act
            var calc = new Calculator();
            var result = calc.Add(input);
            //Assert
            Assert.AreEqual(input, result);
        }

        //Takes 2 numbers separated by delimeter (',') and returns sum
        [Test]
        public void Add_2NumbersSeperatedByCommaDelimiter_ReturnsSum()
        {
            //Arrange
            var input = "3,2";
            //Act
            var calc = new Calculator();
            var result = calc.Add(input);
            //Assert
            Assert.AreEqual(5, result);            
        }
        
  
        [Test]
        public void Add_MulitpleNumbers_ReturnSum()
        {
            //Arrange
            var input = "3,2,8.5";
            //Act
            var calc = new Calculator();
            var result = calc.Add(input);
            //Assert
            Assert.AreEqual(3+2+8.5, result);            

        }

        [Test]
        public void Add_When_ChangeDelimiter()
        {
            var input = "3,2,8.5";
            //Act
            var calc = new Calculator();
            var result1 = calc.Add(input);
            calc.ChangeDelimiter('/');
            var input2 = "3/2/8.5";
            var result2 = calc.Add(input2);
            Assert.AreEqual(result1,result2);
        }

    }
}
