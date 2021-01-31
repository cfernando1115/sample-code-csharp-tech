using System;
namespace SampleCodeTech
{
    public class Calculator
    {
        private ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public void Add(params int[] numbers)
        {
            var sum = 0;
            foreach(var n in numbers)
            {
                sum += n;
            }
            _logger.Log("Your numbers added: " + sum);
        }

        public void Multiply(params int[] numbers)
        {
            var product = 1;
            foreach(var n in numbers)
            {
                product *= n;
            }
            _logger.Log("Your numbers multiplied: " + product);
        }

        public void AbsoluteDifference(int x, int y)
        {
            var absDiff=(x > y) ? x - y : y - x;
            _logger.Log("The absolute difference of your numbers: " + absDiff);
        }
    }
}
