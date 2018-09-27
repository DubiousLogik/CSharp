using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWorkbook.AsyncPrototype
{
    public class HttpGetService
    {
         public static IEnumerable<TypedAsyncResult<string>> BeginHttpGetAsync(AsyncCallback callback, object state)
        {
            Console.WriteLine("HttpGetService BeginHttpGet: start");
            TypedAsyncResult<string> asyncResult = new TypedAsyncResult<string>(callback, state);
            Console.WriteLine($"BeginHttpGetAsync: AsyncResponse Id {asyncResult.GetHashCode()}");
            ContextForGet context = asyncResult.AsyncState as ContextForGet;

            //yield return asyncResult;

            Thread thread = new Thread(() =>
            {
                var httpClient = new MockHttpClient();
                var response = httpClient.Get(context.Url);
                string reply = response.Content.ReadAsStringAsync().Result;
                asyncResult.Complete(reply, true);
                Console.WriteLine($"HttpGetService BeginHttpGet: end, reply: {reply}");
                return;
            });

            thread.Start();

            //var httpClient = new MockHttpClient();
            //var response = httpClient.Get(context.Url);
            //string reply = response.Content.ReadAsStringAsync().Result;
            //asyncResult.Complete(reply, true);
            //Console.WriteLine($"HttpGetService BeginHttpGet: end, reply: {reply}");

            yield return asyncResult;
        }

        public static string EndHttpGet(IAsyncResult asyncResult)
        {
            Console.WriteLine($"EndHttpGet: AsyncResponse Id {asyncResult.GetHashCode()}");
            ContextForGet context = asyncResult.AsyncState as ContextForGet;
            Console.WriteLine("HttpGetService EndHttpGet");
            return TypedAsyncResult<string>.End(asyncResult);
        }
    }
}
