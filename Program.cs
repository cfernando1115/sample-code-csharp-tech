using System;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace SampleCodeTech
{
    class Program
    {
        static void Main(string[] args)
        {
            //RANDOMADMONISHMENT USES RANDOM() TO ADMONISH YOU
            var randomAdmonishment = new RandomAdmonishment();
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
                
                //CUSTOMER CLASS INHERITS FROM PERSON CLASS

                var customer = new Customer(logMethod);

                Console.WriteLine("Hey, there! What's your name?");
                customer.Name = Console.ReadLine();

                Console.WriteLine("Enter your birthdate in MM/DD/YYYY format:");
                customer.Birthdate = DateTime.ParseExact(Console.ReadLine(), "M/d/yyyy", CultureInfo.InvariantCulture);
                
                //PERSON METHOD 
                customer.CalculateAge();

                //CUSTOMER METHOD BASED ON PROTECTED PERSON PROPERTY AGE
                customer.CalculateRewardStatus();

                //EXTENSION METHOD RemoveReverse() REMOVES LETTER AT SPECIFIED INDEX AND REVERSES IT
                Console.WriteLine("Enter a string and I'll mess it all up for you: ");
                var stringEx = Console.ReadLine();
                Console.WriteLine("Enter a whole number between 0 and {0}:", stringEx.Length-1);
                var index = Convert.ToInt32(Console.ReadLine());
                logMethod.Log(stringEx.RemoveReverse(index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(randomAdmonishment.GetAdmonishment());
                Console.WriteLine("An error occurred: {0}", ex.ToString());
            }
        }
    }
}
