using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeTech
{
    class LoggerAssigner
    {
        public ILogger AssignLogger()
        {
            while (true)
            {
                Console.WriteLine("Where would you like to log your results? Enter 'c' for console, or 'f' for file:");
                var logInput = Console.ReadLine().ToLower().Trim(' ');
                if (logInput == "c")
                {
                    return new ConsoleLogger();
                }
                if (logInput == "f")
                {
                    Console.WriteLine("Enter your file path:");
                    var path = Console.ReadLine();
                    return new FileLogger(path);
                }
                Console.WriteLine("Invalid logger input.");
            }
        }
    }
}
