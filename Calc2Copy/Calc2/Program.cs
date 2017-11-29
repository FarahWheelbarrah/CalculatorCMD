using System;
using System.Collections.Generic;

namespace Calc2
{
    // a simple calculator for integer values

    class Program
    {
        // Main class

        static void Main(string[] args)
        {
            // print output based on invalidity tests

            if (args.Length != 0)
            {
                string input = args[0];
                input = input.Trim();
                List<string> inputList = ProcessInput.splitInput(input);

                if (CheckInput.isInvalid(input, inputList) || args.Length != 1) 
                    Console.WriteLine("Invalid Input");
                else if (CheckInput.divZero(inputList))
                    Console.WriteLine("Division by zero");
                else if (!CheckInput.isInt(Operations.getFinalAns(inputList))) 
                    Console.WriteLine("Out of Range");
                else
                    Console.WriteLine("Result = " + Operations.getFinalAns(inputList)); 
            }
            else
                Console.WriteLine("Invalid Input"); 
            Console.ReadLine();
        }
    }
}
