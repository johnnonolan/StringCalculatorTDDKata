using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorKata
{
    public class Calculator
    {
        //lets pu a comment in here just to test    
        private char _delimiter = ',';
        public decimal Add(string input)
        {
            if (input == String.Empty)
            {
                return 0;
            }
            else
            {
                decimal total = 0.00M;
                var inputs =input.Split(_delimiter);
                foreach (string s in inputs)
                {
                    Decimal decimalInput;
                    Decimal.TryParse(s, out decimalInput);
                    total += decimalInput;
                }
                return total;                                   
            }
        }

        public decimal Add(decimal input)
        {
            return input;
        }

        public void ChangeDelimiter(char delimimeter)
        {
            _delimiter = delimimeter;
        }
    }
}
