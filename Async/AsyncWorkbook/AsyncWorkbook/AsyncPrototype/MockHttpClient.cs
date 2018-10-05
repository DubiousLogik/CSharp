using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AsyncWorkbook.AsyncPrototype
{
    public class MockHttpClient
    {
        public string Get(string url)
        {
            Console.WriteLine($"MockHttpClient Get: start, url {url}");

            string reply = $"Received response from {url} : OK";

            int length = url.Length;
            int delayInMillis = length * 100;
            Thread.Sleep(delayInMillis);

            Console.WriteLine($"MockHttpClient Get: end, url {url}"); 
            return reply;
        }
    }
}
