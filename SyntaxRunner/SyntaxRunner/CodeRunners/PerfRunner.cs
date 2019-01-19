using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.String;

namespace SyntaxRunner.CodeRunners
{
    public static class PerfRunner
    {
        public static void Run()
        {
            RunPerfMatching();
        }

        public static void RunPerfMatching()
        {
            StringMatcher s = new StringMatcher();

            int loopCountLimit = 100000;

            //string url = "https://www.test.com/library/BobTheEwok_@endor#org#gov/?method=getStuff";
            string url = "https://localhost/api/beta/books/SMTP:bob.ewok_endoranalytics.com#ext#@endorsoft.onendorsoft.com/Collections('EwokHorticulture')/Items('PN-bob.ewok_endoranalytics.com#ext#@endorsoft.onendorsoft.com')";

            Console.WriteLine("Matching =====================");

            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < loopCountLimit; i++)
            {
                bool success = s.MatchViaRegEx(url);
            }

            s1.Stop();

            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < loopCountLimit; i++)
            {
                bool success = s.MatchViaStringIndex(url);
            }

            s2.Stop();

            Console.WriteLine();
            Console.WriteLine($"RegEx elapsed millis: {s1.ElapsedMilliseconds}");
            Console.WriteLine($"Index elapsed millis: {s2.ElapsedMilliseconds}");

            Console.WriteLine();
            Console.WriteLine("Replacement =====================");
            Console.WriteLine();
            Console.WriteLine($"output RegEx: {s.ReplaceViaRegEx(url)}");
            Console.WriteLine($"output Index: {s.ReplaceViaStringIndex(url)}");

            s1 = Stopwatch.StartNew();
            for (int i = 0; i < loopCountLimit; i++)
            {
                string result = s.ReplaceViaRegEx(url);
            }

            s1.Stop();

            s2 = Stopwatch.StartNew();
            for (int i = 0; i < loopCountLimit; i++)
            {
                string result = s.ReplaceViaStringIndex(url);
            }

            s2.Stop();

            Console.WriteLine();
            Console.WriteLine($"RegEx elapsed millis: {s1.ElapsedMilliseconds}");
            Console.WriteLine($"Index elapsed millis: {s2.ElapsedMilliseconds}");
        }
    }
}
