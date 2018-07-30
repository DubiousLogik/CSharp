using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWorkbook.AsyncDemo
{
    public static class PersonService
    {
        private const int DelayTime = 5000;

        private const string PersonName = "test user";

        public static IAsyncResult BeginGetPersonName(AsyncCallback callback = null, object state = null)
        {
            Console.WriteLine($"BeginGetPersonName Entry Thread: {Thread.CurrentThread.GetHashCode()}");
            TypedAsyncResult<string> asyncResult = new TypedAsyncResult<string>(callback, state);
            Thread thread = new Thread(() =>
            {
                Console.WriteLine($"BeginGetPersonName inner Thread: {Thread.CurrentThread.GetHashCode()}");
                Thread.Sleep(DelayTime);
                asyncResult.Complete(PersonName, false);
                return;
            });

            thread.Start();

            Console.WriteLine($"BeginGetPersonName Exit Thread: {Thread.CurrentThread.GetHashCode()}");
            return asyncResult;
        }

        public static string EndGetPersonName(IAsyncResult asyncResult)
        {
            Console.WriteLine($"EndGetPersonName Thread: {Thread.CurrentThread.GetHashCode()}");
            return TypedAsyncResult<string>.End(asyncResult);
        }

        public static async Task<string> GetPersonNameAsync()
        {
            await Task.Delay(DelayTime);

            return PersonName;
        }
    }
}
