using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxRunner.String
{
    public class StringMatcher
    {

        public bool MatchViaRegEx(string input)
        {
            var match = StringCommon.EmailRegex.Match(input);
            return match.Success;
        }

        public bool MatchViaStringIndex(string input)
        {
            if (input.IndexOf("SMTP:") >= 0 &&
                input.IndexOf("@") >= 0)
            {
                return true;
            }

            return false;
        }

        public string ReplaceViaRegEx(string input)
        {
            return StringCommon.EmailRegex.Replace(input, "");
        }

        public string ReplaceViaStringIndex(string input)
        {
            var tokens = input.Split('/');
            var result = new StringBuilder();
            int counter = 0;

            foreach (var token in tokens)
            {
                if (token.IndexOf("SMTP:") >= 0 &&
                    token.IndexOf("@") >= 0)
                {
                    result.Append(string.Empty);
                }
                else
                {
                    result.Append(token);
                }

                if (counter < tokens.Length - 1)
                {
                    result.Append("/");
                }

                counter++;
            }

            return result.ToString();
        }
    }
}
