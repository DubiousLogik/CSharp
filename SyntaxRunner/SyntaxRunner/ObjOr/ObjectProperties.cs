using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntaxRunner.Utils;

namespace SyntaxRunner.ObjOr
{
    public static class ObjectProperties
    {
        public static void CompareSizes()
        {
            CharVsStringArray("0123456789");
            CharVsStringArray("abcdefghijklmnopqrstuvwxyz1234567890");
        }

        public static void CharVsStringArray(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            char[] chars = input.ToCharArray();
            var stringChars = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                stringChars[i] = input.ElementAt(i).ToString();
            }

            Console.WriteLine("------ Char[] vs String[] ----------");
            Console.WriteLine($"Input: {input}");
            Console.WriteLine($"Size char[] {TestSize<char[]>.SizeOf(chars)}");
            Console.WriteLine($"Size string[] {TestSize<string[]>.SizeOf(stringChars)}");
            Console.WriteLine();
        }

        public static void StringObjectsComparison()
        {
            int limit = 10;
            var sb = new StringBuilder(limit);

            for (int i=0; i<limit; i++)
            {
                sb.Append(i);
            }

            string tenDigits = "0123456789";

            char[] tenChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            Console.WriteLine("------ String Objects ----------");
            Console.WriteLine($"StringBuilder(10) {TestSize<StringBuilder>.SizeOf(sb)}");
            Console.WriteLine($"Size string len 10 {TestSize<string>.SizeOf(tenDigits)}");
            Console.WriteLine($"Size char[10] {TestSize<char[]>.SizeOf(tenChars)}");
            Console.WriteLine();
        }
    }
}
