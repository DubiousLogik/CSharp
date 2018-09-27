using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWorkbook.AsyncPrototype
{
    public class AsyncProtoRunner
    {
        public IEnumerable<TypedAsyncResult<string>> BeginAsyncOperation(string input)
        {
            var context = new ContextForGet()
            {
                Url = input,
                AsyncResult = new TypedAsyncResult<string>(null)
            };

            Console.WriteLine($"Beginning Async operation for input {input}");

            var result = HttpGetService.BeginHttpGetAsync(ContinueWork, context);
            var iterator = result.GetEnumerator();
            iterator.MoveNext();
            var response = iterator.Current;
            iterator.MoveNext();
            Console.WriteLine($"BeginAsyncOperation {input}: AsyncResponse Id {response.GetHashCode()}");
            yield return response;
        }

        private void ContinueWork(IAsyncResult ar)
        {
            Console.WriteLine($"ContinueWork: AsyncResponse Id {ar.GetHashCode()}");
            ContextForGet context = ar.AsyncState as ContextForGet;
            var result = HttpGetService.EndHttpGet(ar);
            context.AsyncResult.Complete(result, false);
        }

        public string EndAsyncOperation(IEnumerable<TypedAsyncResult<string>> op)
        {
            var iterator = op.GetEnumerator();
            iterator.MoveNext();
            var asyncResult = iterator.Current;
            Console.WriteLine($"EndAsyncOperation: AsyncResponse Id {asyncResult.GetHashCode()}");
            return asyncResult.Result;
        }
    }
}
