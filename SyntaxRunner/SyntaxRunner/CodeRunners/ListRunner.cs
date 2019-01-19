using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Interfaces;
using SyntaxRunner.Enums;

namespace SyntaxRunner.CodeRunners
{
    public class ListRunner : IRunnable
    {
        public void Run()
        {
            RunEnums();
            RunLists();
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
