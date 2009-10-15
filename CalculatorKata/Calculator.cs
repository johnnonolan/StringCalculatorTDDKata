using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CalculatorKata
{
    public class Calculator
    {
        private char _Delimiter = ',';
        
        public Calculator()
        {
        }
        private void ChangeDelimeter(string numberString)
        {

            const int POSAFTERDELIMITER = 2;
            _Delimiter = numberString[POSAFTERDELIMITER] ;
        }
        public int Add(string numberString)
        {
            if (String.IsNullOrEmpty(numberString))
                return HandleEmptyString();
            if (HasChangeDelimiterCommand(numberString))
            {
                ChangeDelimeter(numberString);
                numberString = StripDelimiterCommand(numberString);
            }
            if (HasNewLines(numberString))
                numberString = StripNewLines(numberString);

            if (numberString.Contains(_Delimiter))
            {
                return HandlesMultipleNumbers(numberString);
            }
            return HandleSingleNumber(numberString);
        }

        private string StripDelimiterCommand(string numberString)
        {
            return numberString.Remove(0,numberString.IndexOf('\n')+1);

        }
        private bool HasChangeDelimiterCommand(string numberString)
        {
            return numberString.StartsWith("//");
        }
        private string StripNewLines(string numberString)
        {
            return numberString.Replace('\n', _Delimiter);
        }
        private bool HasNewLines(string numberString)
        {
            return numberString.Contains('\n');
        }
        private int HandlesMultipleNumbers(string numberString)
        {
            var total = 0;
            var numbersinString = numberString.Split(_Delimiter);

            foreach (var item in numbersinString)
            {
                total += HandleSingleNumber(item);
            }
            return total;
        }

        private static int HandleSingleNumber(string numberString)
        {
            return int.Parse(numberString);
        }

        private static int HandleEmptyString()
        {
            return 0;
        }
    }
}
