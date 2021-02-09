using System;
using System.Linq;

namespace SampleCodeTech
{
    public static class StringExtensions
    {
        public static String RemoveReverse(this string str, int index)
        {
            return new String(str
               .Remove(index, 1)
               .Reverse()
               .ToArray());              
        }
    }
}
