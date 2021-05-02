using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0 || args.Length > 1)
            {
                ShowHelp();
                return;
            }

            string input = args[0];

            if (input.Trim() == "")
            {
                ShowHelp();
                return;
            }


            try
            {
                BinaryNode rootNode = Parser.Parse(input);

                Console.WriteLine(rootNode.Eval());
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error. {e.Message}");
            }
            
        }

        static void ShowHelp()
        {
            Console.WriteLine("Usage: SimpleCalculator \"<expression to evaluate>\"");
            Console.WriteLine("Expression to evalute can be: add(1,2) or more complex like: div(mult(add(5, 2), sub(4,2)), add(1, 1))");
            Console.WriteLine("Expression must be enclosed in double quotes.");
        }

    }
}
