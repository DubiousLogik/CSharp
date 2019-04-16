using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxRunner.ObjOr
{
    class NullChecking
    {
        public void TestForNulls()
        {
            string input = "one,two,three";
            string isNull = string.Empty;
            isNull = null;

            bool containsOne = input?.IndexOf("one", StringComparison.OrdinalIgnoreCase) >= 0;
            Console.WriteLine($"input = {input}, result = {containsOne}");
            Console.WriteLine($"index is {input?.IndexOf("one", StringComparison.OrdinalIgnoreCase)}");

            containsOne = isNull?.IndexOf("one", StringComparison.OrdinalIgnoreCase) >= 0;
            Console.WriteLine($"input = {isNull}, result = {containsOne}");
            Console.WriteLine($"index is {isNull?.IndexOf("one", StringComparison.OrdinalIgnoreCase)}");

            string flights = "one,two,three,recommendedApi";
            string result = "NotPresent";

            if (!string.IsNullOrEmpty(flights))
            {
                if (flights.IndexOf("recommend", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result = "RecommendPresent";
                }
            }

            Console.WriteLine($"result = {result}");
        }

        public void ConditionalNulls()
        {
            var list = new List<int>();
            List<int> nullList = null;

            this.ProcessNullableList(list);
            this.ProcessNullableList(nullList);

            var element = nullList?.First();
            
            if (element == null)
            {
                Console.WriteLine("element is null");
            }
            else
            {
                Console.WriteLine($"element is of type {element.GetType()}");
            }
        }

        public void ProcessNullableList(List<int> list)
        {
            Console.WriteLine($"List length = {list?.Count}");
        }
    }
}
