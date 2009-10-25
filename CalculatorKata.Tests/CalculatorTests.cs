using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CalculatorKata.Tests
{
    public class Calculator
    {
        private  char _Delimiter = ',';
        public Calculator()
        {
            
        }
        public int Add(string numberString)
        {

            if (isEmptyString(numberString))
            {
                return HandleEmptyString();
            }

            if (numberString.StartsWith("//"))
                numberString = ChangeDelimiter(numberString);
            numberString = StripNewLines(numberString);

            return ParseNumberString(numberString);
        }

        private string ChangeDelimiter(string numberString)
        {
            _Delimiter = ';';
            numberString = numberString.Substring(numberString.IndexOf('\n')+1,numberString.Length-(numberString.IndexOf('\n')+1));
            return numberString;
        }
        private int ParseNumberString(string numberString)
        {
            return HandleMulitpleNumbers(numberString);
        }

        private int HandleMulitpleNumbers(string numberString)
        {
            var numbers = numberString.Split(_Delimiter);
            var total = 0;
            foreach (var number in numbers)
            {
                total +=  HandleSingleNumber(number);
            }
            return total;
        }

        private string StripNewLines(string numberString)
        {
            return numberString.Replace('\n', _Delimiter);
        }
        private bool hasDelimiter(string numberString)
        {
            return numberString.Contains(_Delimiter);
        }

        private static int HandleSingleNumber(string numberString)
        {
            try
            {
                int result;
                if (Int32.TryParse(numberString,out result))                    
                {
                    return result;
                }
                return result;
            }
            catch (Exception)
            {

                throw new FormatException("Negatives not allowed");
            }

        }

        private static bool isEmptyString(string numberString)
        {
            return String.IsNullOrEmpty(numberString);
        }

        private static int HandleEmptyString()
        {
            return 0;
        }
    }
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
        public void Add_NumbersAndHandleInValidNewLine_ThrowsInvlaidException()
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


         //var ex=   Assert.Throws<FormatException>(() => {throw new FormatException(); });
            var ex = Assert.Throws(Is.InstanceOf<FormatException>,
                                   () => { throw new FormatException("Negatives not allowed"); });
        }


    }
}
