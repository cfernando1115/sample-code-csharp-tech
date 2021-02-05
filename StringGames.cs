using System.Text;
using System;

namespace SampleCodeTech
{
    public class StringGames
    {
        private ILogger _logger;
        private string _string1;
        private string _string2;

        public Action<string, string> StringAction;

        public StringGames(ILogger logger)
        {
            _logger = logger;
        }

        public void AssignStringSet(string set)
        {
            var results = set.Split(',');
            _string1 = results[0];
            _string2 = results[1];
        }

        public void PerformStringActions()
        {
            if (StringAction != null)
            {
                StringAction(_string1, _string2);
                return;
            }
            _logger.Log("No strings actions were assigned.");
        }

        public void Join(string first, string second)
        {
            var resultString = new StringBuilder();
            resultString.Append(first + second);

            _logger.Log(resultString.ToString());
        }

        public void Combine(string first, string second)
        {
            var resultString = new StringBuilder();
            var minLength = first.Length > second.Length?second.Length:first.Length;
            var totalLength = first.Length + second.Length;
            var rem = totalLength - minLength * 2;

            for (var i = 0; i < minLength; i++)
            {
                resultString.Append(first[i].ToString() + second[i].ToString());
            }
            if (first.Length <= minLength)
            {
                resultString.Append(second, minLength, rem);
            }
            if (second.Length <= minLength)
            {
                resultString.Append(first, minLength, rem);
            }

            _logger.Log(resultString.ToString());
        }
    }
}
