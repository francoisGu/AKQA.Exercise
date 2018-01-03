using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKQA.Exercise.AppLogic.Configuration;

namespace AKQA.Exercise.AppLogic.Services
{
    public class NumToWords : INumToWords
    {
        private NumberWordConfig _numberWordConfig;
        public NumToWords(NumberWordConfig numberWordConfig)
        {
            _numberWordConfig = numberWordConfig;
        }

        /// <summary>
        ///     This function is concrate function of INumberToWords interface 
        ///     It will convert number into words
        /// </summary>
        /// <param name="number">number in double</param>
        /// <returns>a string of number of words</returns>
        public string ConvertNumToWords(double number)
        {
            if (number < NumberDetails.MinNumber || number > NumberDetails.MaxNumber)
                return NumberDetails.OutOfRange;

            var numberStrings = number.ToString("F2").Split('.');
            var integerStr = ConvertIntegerNum(numberStrings[0]);
            var decimalStr = ConvertIntegerNum(numberStrings[1]);

            var result = ((integerStr.Length > 0 ? integerStr + " dollar " : "") +
                        (decimalStr.Length > 0 ? decimalStr + " cent " : ""))
                        .Trim().ToUpper();

            return result.Length == 0 ? NumberDetails.ZeroString : result;
        }

        /// <summary>
        ///     This private function will convert interger into words
        /// </summary>
        private string ConvertIntegerNum(string str)
        {
            // Check if the number only contain the digit
            string numberStr = string.Empty;
            foreach (char c in str)
            {
                if (Char.IsDigit(c)) numberStr += c;
            }

            var padded = numberStr.PadLeft(NumberDetails.MaxLength, '0');
            // XXXnnnnnnnnn
            int billions = Convert.ToInt32(padded.Substring(0, 3));
            // nnnXXXnnnnnn
            int millions = Convert.ToInt32(padded.Substring(3, 3));
            // nnnnnnXXXnnn
            int thousands = Convert.ToInt32(padded.Substring(6, 3));
            // nnnnnnnnnXXX
            int hundredsTens = Convert.ToInt32(padded.Substring(9, 3));

            var result = (billions > 0 ? ConvertHundredsAndTens(billions) + "billion" : "") +
                        (millions > 0 ? ConvertHundredsAndTens(millions) + "million" : "") +
                        (thousands > 0 ? ConvertHundredsAndTens(thousands) + "thousand" : "") +
                        (hundredsTens > 0 ? ConvertHundredsAndTens(hundredsTens) : "");

            return result.Trim();
        }

        /// <summary>
        ///     This function will a number which is less than 1000 into words
        /// </summary>
        private string ConvertHundredsAndTens(int number)
        {
            // Initial String
            var numberWords = " ";
            // Get Hundred String
            var hundred = number / 100;
            numberWords = numberWords +  (_numberWordConfig.NumberWords.ContainsKey(hundred) ?
                            _numberWordConfig.NumberWords[hundred] + " hundred " : "");

            //Get Tens String
            var lessThanHundred = number % 100;
            // Return the word directly if the number can be found directly in the config
            if (_numberWordConfig.NumberWords.ContainsKey(lessThanHundred))
                return numberWords + _numberWordConfig.NumberWords[lessThanHundred] + " ";
            var tens = (lessThanHundred / 10) * 10;
            numberWords = numberWords + (_numberWordConfig.NumberWords.ContainsKey(tens) ?
                            _numberWordConfig.NumberWords[tens] + "-" : "");

            var lessThanTen = number % 10;
            numberWords = numberWords + (_numberWordConfig.NumberWords.ContainsKey(lessThanTen) ?
                            _numberWordConfig.NumberWords[lessThanTen] + " " : "");

            return numberWords;
        }

        private string FindNumInConfig(int number)
        {
            return _numberWordConfig.NumberWords.ContainsKey(number) ?
                    _numberWordConfig.NumberWords[number] : null;
        }

        /// <summary>
        ///     Number boundary
        /// </summary>
        private static class NumberDetails
        {
            internal const double MinNumber = 0;
            internal const double MaxNumber = 999999999999.99;
            internal const int MaxLength = 12;
            internal const string OutOfRange = "OUT OFF RANGE";
            internal const string ZeroString = "ZERO DOLLAR";
        }
    }
}
