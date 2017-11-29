using System.Collections.Generic;

namespace Calc2
{
    class Operations
    {
        // class contains all mathematical operation-related functions

        public static string getFinalAns(List<string> input)
        {
            // loop through final formatted list
            // pass numbers and operator into calculate function 

            List<string> formattedList = ProcessInput.formatInput(input);

            for (int i = 0; i < formattedList.Count; i++)
            {
                if (CheckInput.timesDivOrMod(formattedList[i]))
                {
                    formattedList = calculate(formattedList, i);
                    --i;
                }
            }

            for (int i = 0; i < formattedList.Count; i++)
            {
                if (CheckInput.plusOrMinus(formattedList[i]))
                {
                    formattedList = calculate(formattedList, i);
                    --i;
                }
            }
            return "" + long.Parse(formattedList[0]);
        }

        private static List<string> calculate(List<string> formattedList, int i)
        {
            // perform mathematical operation based on sign / calculate answers

            long prevNum = long.Parse(formattedList[i - 1]);
            long nextNum = long.Parse(formattedList[i + 1]);

            switch (formattedList[i])
            { 
                case "*": formattedList[i] = multiply(prevNum, nextNum); break;
                case "/": formattedList[i] = divide(prevNum, nextNum); break;
                case "%": formattedList[i] = mod(prevNum, nextNum); break;
                case "+": formattedList[i] = add(prevNum, nextNum); break;
                case "-": formattedList[i] = subtract(prevNum, nextNum); break;
            }

            formattedList[i - 1] = "";
            formattedList[i + 1] = "";
            formattedList.RemoveAll(string.IsNullOrEmpty);
            return formattedList;
        }

        private static string add(long number1, long number2)
        {
            long sum = number1 + number2;
            return "" + sum;
        }

        private static string subtract(long number1, long number2)
        {
            long difference = number1 - number2;
            return "" + difference;
        }

        private static string multiply(long number1, long number2)
        {
            long product = number1 * number2;
            return "" + product;
        }

        private static string divide(long number1, long number2)
        {
            long quotient = number1 / number2;
            return "" + quotient;
        }

        private static string mod(long number1, long number2)
        {
            long remainder = number1 % number2;
            return "" + remainder;
        }
    }
}
