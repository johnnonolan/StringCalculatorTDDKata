using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorKata
{
    public class Calculator
    {
        private char _delimiter = ',';
        public int Add(string numbers)
        {
            int sum ;
            if (!numbers.Contains(_delimiter))
            {
                Int32.TryParse(numbers, out sum);
                return sum;
            }
            else
            {
                return SplitStringAndAdd(numbers);
            }

        }

        private int SplitStringAndAdd(string numbers)
        {
            const uint MAXplus1 = 2147483648;
            var nums= numbers.Split(_delimiter);
            int total = 0;
            foreach (var num in nums)
            {
                int addition;
                if (num != (MAXplus1).ToString())
                    throw new Exception();
                int.TryParse(num, out addition);
                
                total += addition;
            }
            return total;
        }
    }
}
