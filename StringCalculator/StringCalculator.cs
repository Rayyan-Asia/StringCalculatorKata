using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbersString)
        {
            int sum = 0;
            var numbers = ToArrayOfNumbers(numbersString);
            if (numbers == null)
                return 0;
            foreach (int number in numbers)
                sum += number;

            return sum;
        }

        private int[]? ToArrayOfNumbers(string numbersString)
        {
            numbersString = numbersString.Trim();
            numbersString = numbersString.Replace(" ", "");
            if (numbersString == "")
                return null;
            var delimeter = ',';
            ParseCustomDelimiter(ref numbersString, ref delimeter);
            char[] delimiters = { delimeter, '\n' };
            string[] numbersStringArray = numbersString.Split(delimiters);
            return ParseNumbersFromString(numbersStringArray);

        }

        private static int[] ParseNumbersFromString(string[] numbersStringArray)
        {
            int[] numbers = new int[numbersStringArray.Length];
            for (int i = 0; i < numbersStringArray.Length; i++)
            {
                if (numbersStringArray[i] != "")
                {
                    var parsedNumber = int.Parse(numbersStringArray[i]);
                    if (parsedNumber < 0)
                        throw new ArgumentOutOfRangeException("Cannot have negative numbers.");
                    numbers[i] = parsedNumber;
                }
                else
                    numbers[i] = 0;
            }
            return numbers;
        }

        private static void ParseCustomDelimiter(ref string numbersString, ref char delimeter)
        {
            if (numbersString.StartsWith("//"))
            {
                numbersString = numbersString.Replace("//", "");
                int index = numbersString.IndexOf("\n");
                var delimeterString = numbersString[..index];
                if (delimeterString.Length == 1 && !Regex.IsMatch(delimeterString, @"^[0-9]+$"))
                {
                    delimeter = delimeterString[0];
                    numbersString = numbersString[1..];
                }
                else
                {
                    throw new ArgumentException("Forgot to give custom Delimiter");
                }
            }
        }
    }
}
