using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Enums;
using SyntaxRunner.Interfaces;

namespace SyntaxRunner.Lists
{
    public class ListExamples : IExampleRunner
    {
        public void RunExamples()
        {
            RunEnums();
            DictionaryTester();
            RunLists();
        }

        public static void DictionaryTester()
        {
            // various ways to add elements

            Console.WriteLine("DictionaryTester");

            Dictionary<string, string> tester = new Dictionary<string, string>();

            tester["key2"] = "bar";
            tester["key1"] = "newvalue";

            //tester.Add("key1", "foo");

            foreach (var kvp in tester)
            {
                Console.WriteLine($"key {kvp.Key}, value {kvp.Value}");
            }
        }

        public static void RunEnums()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Cars)).Length; i++)
            {
                Console.WriteLine($"Cars [{i}] = {((Cars)i).ToString()}");
            }
        }

        public static void RunLists()
        {
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Accept", "application/json"),
                new KeyValuePair<string, string>("Prefer", "mySystem.behavior=something")
            };

            Console.WriteLine("Original Headers");
            foreach (var kvp in headers)
            {
                Console.WriteLine($"header = {kvp.Key}: {kvp.Value}");
            }

            List<KeyValuePair<string, string>> newHeaders = new List<KeyValuePair<string, string>>();

            // Replace the 'Accept' header, while retaining the original order of the headers,  
            foreach (var kvp in headers)
            {
                if (kvp.Key == "Accept")
                {
                    newHeaders.Add(new KeyValuePair<string, string>("Accept", "text/plain"));
                }
                else
                {
                    newHeaders.Add(kvp);
                }
            }

            Console.WriteLine();
            Console.WriteLine("New Headers");
            foreach (var kvp in newHeaders)
            {
                Console.WriteLine($"header = {kvp.Key}: {kvp.Value}");
            }
        }
    }
}
