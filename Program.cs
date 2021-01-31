using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeTech
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //FILELOGGER AND CONSOLELOGGER CLASSES IMPLEMENT ILOGGER INTERFACE

                var logMethod = new LoggerAssigner().AssignLogger();

                //CALCULATOR METHODS Add() AND Multiply() USE PARAMS MODIFIER

                var calculator = new Calculator(logMethod);

                Console.WriteLine("Enter a series of integers separated by commas:");
                var calculatorInput = Console.ReadLine();
                var numberSet = calculatorInput
                    .Split(',')
                    .Select(i => Convert.ToInt32(i))
                    .ToArray();
                calculator.Add(numberSet);
                calculator.Multiply(numberSet);

                //CALCULATOR METHOD AbsoluteDifference() USES TERNARY

                Console.WriteLine("Enter first number:");
                var x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number:");
                var y = Convert.ToInt32(Console.ReadLine());
                calculator.AbsoluteDifference(x, y);

                //CALCULATOR METHOD Divide() USES OUT MODIFIER
                
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred.");
            }
        }
    }
}
