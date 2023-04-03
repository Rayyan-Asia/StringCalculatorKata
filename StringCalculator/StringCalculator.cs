using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbersString)
        {
            int sum = 0;
            var numbers = ToArray(numbersString);
            if (numbers == null)
                return 0;
            foreach (int number in numbers)
                sum += number;

            return sum;
        }

        private int[]? ToArray(string numbersString)
        {
            numbersString = numbersString.Trim();
            numbersString = numbersString.Replace(" ", "");
            if (numbersString == "")
                return null;
            char[] delimiters = { ',', '\n' };
            string[] numbersStringArray = numbersString.Split(delimiters);
            int[] numbers = new int[numbersStringArray.Length];
            for (int i = 0; i < numbersStringArray.Length; i++)
            {
                if (numbersStringArray[i] != "")
                {
                    numbers[i] = int.Parse(numbersStringArray[i]);
                }
                else
                    numbers[i] = 0;
            }
            return numbers;
        }
    }
}
