using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CalculatorKata
{
    public class Calculator
    {
        private const string DELIMITERCOMMAND = "//";
        private char _Delimiter = ',';
        public int Add(string numberString)
        {
            numberString = ChangeDelimiterAndRemoveCommand(numberString);         
            numberString= SanitiseInput(numberString);
            if (numberString == String.Empty)
            {
                return 0;
            }
            if (numberString.Contains(_Delimiter))
            {
                return HandleDelimitedString(numberString, _Delimiter);
            }
            return HandleSingleNumberString(numberString);
        }

        private string ChangeDelimiterAndRemoveCommand(string numberString)
        {
            if (numberString.StartsWith(DELIMITERCOMMAND))
            {
                _Delimiter = numberString[2];
                return numberString.Substring(4);
            }
            return numberString;
        }
        private string SanitiseInput(string numberString)
        {
            return numberString.Replace("\n", _Delimiter.ToString());
        }
        private static int HandleDelimitedString(string numberString, char delimiter)
        {
            var total = 0;
            foreach (var item in numberString.Split(delimiter))
            {
                total += HandleSingleNumberString(item);
            }
            return total;
        }

        private static int HandleSingleNumberString(string numberString)
        {
            int result;
            if (int.TryParse(numberString, out result))
            {
                return result;
            }

            throw new FormatException(String.Format("Error processing single number for {0}",numberString));
        }
    }
}
