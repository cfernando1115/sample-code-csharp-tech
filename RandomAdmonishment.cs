using System;
using System.Collections.Generic;

namespace SampleCodeTech
{
    public class RandomAdmonishment
    {
        private List<string> _admonishments;
        private System.Random _randomNumber;

        public RandomAdmonishment()
        {
            _randomNumber = new Random();
            _admonishments = new List<string>()
            {
                "Don't make me turn this car around.",
                "This is why we can't have nice things.",
                "Am I the only one here who gives a s*** about the rules?",
                "Nice try, you rebel.",
                "That's it, you're on a timeout.",
                "Don't mess with the bull, you'll get the horns."
            };
        }

        public string GetAdmonishment()
        {
            return _admonishments[_randomNumber.Next(0, 5)];
        }
    }
}
