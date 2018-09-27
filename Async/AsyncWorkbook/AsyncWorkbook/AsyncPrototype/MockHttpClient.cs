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
        public HttpResponseMessage Get(string url)
        {
            Console.WriteLine($"MockHttpClient Get: start, url {url}");

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            var response = new HttpResponseMessage();

            string reply = $"Received response from {url} : OK";
            var content = new StringContent(reply);

            response.Content = content;
            response.StatusCode = HttpStatusCode.OK;

            int length = url.Length;
            int delayInMillis = length * 100;
            Thread.Sleep(delayInMillis);

            Console.WriteLine($"MockHttpClient Get: end, url {url}"); 
            return response;
        }
    }
}
