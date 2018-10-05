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

            //Thread thread = new Thread(() =>
            //{
            //    var httpClient = new MockHttpClient();
            //    var reply = httpClient.Get(context.Url);
            //    asyncResult.Complete(reply, true);
            //    Console.WriteLine($"HttpGetService BeginHttpGet: end, reply: {reply}");
            //    return;
            //});
            //thread.Start();

            yield return asyncResult;

            var httpClient = new MockHttpClient();
            var reply = httpClient.Get(context.Url);
            asyncResult.Complete(reply, true);
            Console.WriteLine($"HttpGetService BeginHttpGet: end, reply: {reply}");

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
