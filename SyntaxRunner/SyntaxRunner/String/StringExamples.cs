using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Interfaces;

namespace SyntaxRunner.String
{
    public class StringExamples : IExampleRunner
    {
        public void RunExamples()
        {
            RunParsing();
            GuidParsing();
        }

        public static void RunParsing()
        {
            string url = "http://somedomain.org/firstFolder/secondFolder/lastFolder";

            var sp = new StringParser();

            Console.WriteLine($"Last token in {url} is {sp.GetLastElement(url, '/')}");

            string email = "SMTP:joe.smith@outlook.com";
            Console.WriteLine($"Email to plain text {email} = {sp.EmailToPlainText(email)}");

            email = "SMTP:harvey_J_jones-smith%40outlook#com";
            Console.WriteLine($"Email to plain text {email} = {sp.EmailToPlainText(email)}");

            string data = "{2DA4934B-8B67-604B-8CC5-467045D39FAC}";
            Console.WriteLine($"Remove first and last: input = {data}, output = {sp.RemoveBracketsAndToLower(data)}");
            data = "2DA4934B-8B67-604B-8CC5-467045D39FAC";
            Console.WriteLine($"Remove first and last: input = {data}, output = {sp.RemoveBracketsAndToLower(data)}");
            data = null;
            Console.WriteLine($"Remove first and last: input = {data}, output = {sp.RemoveBracketsAndToLower(data)}");
        }

        public static void GuidParsing()
        {
            string guid = "ede30d57-2936-46a2-8b95-42bc53c39221";
            string guidNoHyphens = "ede30d57293646a28b9542bc53c39221";

            string guidSmaller = "ede30d57-2936-46a2-8b95-42bc53c39220";
            string guidBigger = "ede30d57-2936-46a2-8b95-42bc53c39222";

            Guid g;
            bool parseOk = Guid.TryParse(guidNoHyphens, out g);

            Guid g2;
            bool parseOk2 = Guid.TryParse(guid, out g2);

            Guid gSmaller;
            bool parseSmall = Guid.TryParse(guidSmaller, out gSmaller);

            Guid gBigger;
            bool parseBig = Guid.TryParse(guidBigger, out gBigger);
            
            if (parseOk)
            {
                Console.WriteLine($"Guid no hyph parsed as {g.ToString()}");
                Console.WriteLine($"Guid with hyph parsed as {g2.ToString()}");
                Console.WriteLine($"IsMatch (via string) with original = {guid == g.ToString()}");
                Console.WriteLine();
                Console.WriteLine($"IsMatch with smaller (via Guid.CompareTo) = {g2.CompareTo(gSmaller)}");
                Console.WriteLine($"IsMatch with same (via Guid.CompareTo) = {g2.CompareTo(g)}");
                Console.WriteLine($"IsMatch with bigger (via Guid.CompareTo) = {g2.CompareTo(gBigger)}");
            }
            else
            {
                Console.WriteLine("Parse failed");
            }
        }
    }
}
