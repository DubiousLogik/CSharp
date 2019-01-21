using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxRunner.String
{
    public class StringParser
    {
        public string GetLastElement(string input, char delimiter)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                return result;
            }

            var tokens = input.Split(delimiter);

            if (tokens != null && tokens.Length > 0)
            {
                result = tokens[tokens.Length - 1];
            }
            else
            {
                result = input;
            }

            return result;
        }
    }
}
