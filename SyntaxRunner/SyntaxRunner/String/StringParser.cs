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

        public string EmailToPlainText(string input)
        {
             var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(input))
            {
                input = input.Replace("SMTP", "s");
                input = input.Replace(":", "_");
                input = input.Replace("@", "_");
                input = input.Replace(".", "_");
                input = input.Replace("%40", "_");
                input = input.Replace("#", "_");

                foreach (var token in input.Split('_'))
                {
                    sb.Append($" element {token} ");
                }
            }

            return sb.ToString();
        }

        public string RemoveBracketsAndToLower(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if(input.StartsWith("{") && input.EndsWith("}"))
                {
                    return input.Substring(1, input.Length - 2).ToLower();
                }
                else
                {
                    return input.ToLower();
                }
            }

            return input;
        }
    }
}
