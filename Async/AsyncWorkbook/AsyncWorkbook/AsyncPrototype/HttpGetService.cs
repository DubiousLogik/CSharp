using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWorkbook.AsyncPrototype
{
    public class HttpGetService
    {
        public static IAsyncResult BeginHttpGet(AsyncCallback callback, object state)
        {
            Console.WriteLine("HttpGetService BeginHttpGet: start");
            TypedAsyncResult<string> asyncResult = new TypedAsyncResult<string>(callback, state);

            ContextForGet context = asyncResult.AsyncState as ContextForGet;

            var httpClient = new MockHttpClient();
            var response = httpClient.Get(context.Url);
            string reply = response.Content.ReadAsStringAsync().Result;

            asyncResult.Complete(reply, true);

            Console.WriteLine("HttpGetService BeginHttpGet: end");
            return asyncResult;
        }

        public static void ContinueHttpGet(IAsyncResult asyncResult)
        {
            Console.WriteLine($"HttpGetService ContinueHttpGet: start, asyncResult.IsCompleted {asyncResult.IsCompleted}");

            ContextForGet context = asyncResult.AsyncState as ContextForGet;

            Console.WriteLine("HttpGetService ContinueHttpGet: end");
            
            //asyncResult.Complete(result, false);
        }

        public static string EndHttpGet(IAsyncResult asyncResult)
        {
            ContextForGet context = asyncResult.AsyncState as ContextForGet;
            Console.WriteLine("HttpGetService EndHttpGet");
            return TypedAsyncResult<string>.End(asyncResult);
        }
    }
}
