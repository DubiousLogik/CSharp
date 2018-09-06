using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWorkbook.AsyncPrototype
{
    public class AsyncProtoRunner
    {
        public static void Run()
        {
            TypedAsyncResult<string> asyncResult = new TypedAsyncResult<string>(null);
            var context = new ContextForGet() { Url = "http://bing.com" };

            var response = HttpGetService.BeginHttpGet(HttpGetService.ContinueHttpGet, context);
            var reply = TypedAsyncResult<string>.End(response);

            Console.WriteLine($"Reply = {reply}");
        }
    }
}
