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
            if (numbers.Length > 3)
                throw new Exception("Input should be from 0 to 3 numbers");
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        private int[]? ToArray(string numbersString)
        {
            if (numbersString.Replace(" ", "") == "")
                return null;
            string[] numbersStringArray = numbersString.Split(',');
            int[] numbers = new int[numbersStringArray.Length];
            for (int i = 0; i < numbersStringArray.Length; i++)
                numbers[i] = int.Parse(numbersStringArray[i]);
            return numbers;
        }
    }
}
