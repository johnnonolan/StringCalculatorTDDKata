using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace CalculatorKata
{

    public class Calculator
    {
        public Calculator()
        {
        }
        
        private char _Delimiter = ',';

        private string ChangeDelimterAndRemoveCommand(string numberString)
        {
            var changeDelimiterCommand = @"//";
            if (numberString.Contains(changeDelimiterCommand))
            {
                _Delimiter = numberString.Substring(3, 1).ToCharArray()[0];
                numberString = numberString.Remove(0, 3);              
            }
            return numberString;

        }
        public int Add(string numberString)
        {
            if (String.IsNullOrEmpty(numberString))
                return 0;
            numberString = ChangeDelimterAndRemoveCommand(numberString);
            
            if (numberString.Contains(_Delimiter))
            {
                return AddManyNumbers(numberString, _Delimiter);
            }
            return ExtractNumberFromString(numberString);
        }

        private static int AddManyNumbers(string numberString, char delimiter)
        {

            numberString = ReplaceNewLinesWithDelimiter(numberString, delimiter);
            var speraratedNumbers = numberString.Split(delimiter);
            var total = 0;
            foreach (var number in speraratedNumbers)
            {
                total += ExtractNumberFromString(number);
	        }
            return total;
        }

        private static string ReplaceNewLinesWithDelimiter(string numberString, char delimiter)
        {
            numberString = numberString.Replace('\n', delimiter);
            return numberString;
        }

        private static int ExtractNumberFromString(string numberString)
        {
            var resultInt = 0;
            if (Int32.TryParse(numberString, out resultInt))
                return resultInt;
            throw new FormatException(numberString);
        }
    }
}
