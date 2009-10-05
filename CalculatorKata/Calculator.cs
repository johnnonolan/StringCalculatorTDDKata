using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorKata
{
    public class Calculator
    {
        private const char _delimiter = ',';

        public Calculator()
        {

        }
        public int Add(string numbers)
        {
            if (numbers.Contains(_delimiter))
            {
                var result = 0;
                var numbersCollection = numbers.Split(_delimiter);
                foreach (var number in numbersCollection)
                {
                    result += ParseNumber(number);
                }
                return result;
            } 

            return ParseNumber(numbers);
        }

        private static int ParseNumber(string numbers)
        {
            const int DEFAULTVALUE = 0;
            int returnInt = 0;
            Int32.TryParse(numbers, out returnInt);


            return String.IsNullOrEmpty(numbers) ? DEFAULTVALUE : returnInt;
        }
    }
}
