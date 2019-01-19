using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyntaxRunner.String
{
    public static class StringCommon
    {
        public static readonly Regex EmailRegex = new Regex(@"(\.|-|_|#|[a-z]|[A-Z]|[0-9])+@(\.|-|_|#|[a-z]|[A-Z]|[0-9])+", RegexOptions.Compiled);
    }
}
