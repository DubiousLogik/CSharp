using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Enums;
using SyntaxRunner.Interfaces;
using SyntaxRunner.Models;

namespace SyntaxRunner.Lists
{
    public class ListExamples : IExampleRunner
    {
        public void RunExamples()
        {
            //RunEnums();
            //DictionaryTester();
            //RunLists();
            //GetMinMaxInOnePass();
            DictionaryObjectTester();
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

            bool removed = tester.Remove("key2");
            bool notfound = tester.Remove("nonExistentKey");

            Console.WriteLine($"removed valid key: {removed}");
            Console.WriteLine($"invalid key found: {notfound}");

            Console.WriteLine($"removal of empty string {tester.Remove(string.Empty)}");

            try
            {
                bool error = tester.Remove(null);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Caught error: {e.Message}");
            }
        }

        public static void RunEnums()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Cars)).Length; i++)
            {
                Console.WriteLine($"Cars [{i}] = {((Cars)i).ToString()}");
            }

            int sampleValueFromUserInput = 2;
            int valueOutOfRange = 1001;

            var car1 = (Cars)1;
            var car2 = (Cars)sampleValueFromUserInput;
            var car3 = (Cars)valueOutOfRange;

            bool exists = Enum.IsDefined(typeof(Cars), sampleValueFromUserInput);
            bool existsOutOfRange = Enum.IsDefined(typeof(Cars), valueOutOfRange);

            Console.WriteLine($"Car1 resolved to {car1.ToString()}");
            Console.WriteLine($"Car2 resolved to {car2.ToString()}, exists = {exists}");
            Console.WriteLine($"Car3 resolved to {car3.ToString()}, exists = {existsOutOfRange}");
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

        public static void GetMinMaxInOnePass()
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            var personList = new List<Person>()
            {
                new Person() { Age = 22 },
                new Person() { Age = 34 },
                new Person() { Age = 19 }
            };

            foreach (var p in personList)
            {
                if (p.Age < min) { min = p.Age; }
                if (p.Age > max) { max = p.Age; }
            }

            Console.WriteLine($"min {min} max {max}");
        }

        public static void DictionaryObjectTester()
        {
            var one = new Dictionary<string, int>();
            one.Add("a", 1);
            one.Add("b", 2);

            var two = new Dictionary<string, int>(one);

            Console.WriteLine($"one obj id {one.GetHashCode()}");
            Console.WriteLine($"two obj id {two.GetHashCode()}");

            two["b"] = 3;

            Console.WriteLine($"one[b] = {one["b"]}, two[b] {two["b"]}");
        }
    }
}
