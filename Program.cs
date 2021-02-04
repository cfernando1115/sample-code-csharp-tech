﻿using System;
using System.Collections.Generic;
using System.Linq;
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

                calculator.Divide(x, y, out double quotient);
                logMethod.Log("The quotient of your numbers: " + quotient);

                //CALCULATOR METHOD Power() USES REF MODIFIER

                logMethod.Log(x+" to the power of "+y+": ");
                calculator.Power(ref x, y);
                logMethod.Log(x.ToString());

                //INITIALIZE STRINGGAMES CLASS

                var stringGames = new StringGames(logMethod);
                Console.WriteLine("Enter two strings separated by a comma: ");
                stringGames.AssignStringSet(Console.ReadLine());

                //STRINGGAMES METHODS ASSIGNED TO DELEGATE

                stringGames.StringAction = stringGames.Join;
                stringGames.StringAction += stringGames.Combine;
                stringGames.PerformStringActions();



            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: {0}", ex.ToString());
            }
        }
    }
}
