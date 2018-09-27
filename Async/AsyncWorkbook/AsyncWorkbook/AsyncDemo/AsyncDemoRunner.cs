using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWorkbook.AsyncDemo
{
    public class AsyncDemoRunner
    {
        public static void Run()
        {
            //var task = GetStringAsync();
            //var response = task.Result;

            Console.WriteLine("======================================================");
            Console.WriteLine();
            Console.WriteLine("Beginning V1");

            //Console.WriteLine($"Main starting Thread: {Thread.CurrentThread.GetHashCode()}");

            var responseAR = BeginGetStringV1();

            Console.WriteLine("Trying to do other work");
            //Console.WriteLine($"Main middle Thread: {Thread.CurrentThread.GetHashCode()}");
            var response = TypedAsyncResult<string>.End(responseAR);

            //Console.WriteLine($"Main ending Thread: {Thread.CurrentThread.GetHashCode()}");
            Console.WriteLine(response);

            Console.WriteLine("Ending V1");
            Console.WriteLine();
            Console.WriteLine("======================================================");
            Console.WriteLine();

            Console.WriteLine("Beginning V2");

            //Console.WriteLine($"Main starting Thread: {Thread.CurrentThread.GetHashCode()}");

            var responseAR2 = BeginGetStringV2();
            Console.WriteLine("Trying to do other work");
            //Console.WriteLine($"Main middle Thread: {Thread.CurrentThread.GetHashCode()}");
            var response2 = TypedAsyncResult<string>.End(responseAR2);

            //Console.WriteLine($"Main ending Thread: {Thread.CurrentThread.GetHashCode()}");
            Console.WriteLine(response2);

            Console.WriteLine("Ending V2");
            Console.WriteLine();
            Console.WriteLine("======================================================");
            Console.WriteLine();
            //Console.ReadLine();
        }

        #region Task Version

        public static async Task<string> GetStringAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var name = await PersonService.GetPersonNameAsync();

            string result = string.Format("Getting {0} took {1} ms", name, sw.ElapsedMilliseconds);

            return result;
        }

        #endregion Task Version

        #region IAsyncResult Version - First Try

        public static IAsyncResult BeginGetStringV1()
        {
            Console.WriteLine($"BeginGetString Entry Thread: {Thread.CurrentThread.GetHashCode()}");

            Stopwatch sw = Stopwatch.StartNew();

            TypedAsyncResult<string> asyncResult = new TypedAsyncResult<string>(null);
            IAsyncResult ar = PersonService.BeginGetPersonName(); // Beginning of async operation

            /////////////////////////////////////////////////////////////////
            Console.WriteLine($"BeginGetString Middle Thread: {Thread.CurrentThread.GetHashCode()}");

            var name = PersonService.EndGetPersonName(ar); // blocking
            string result = string.Format("Getting {0} took {1} ms", name, sw.ElapsedMilliseconds);

            asyncResult.Complete(result, false);

            Console.WriteLine($"BeginGetString Ending Thread: {Thread.CurrentThread.GetHashCode()}");
            return asyncResult;
        }

        #endregion IAsyncResult Version - First Try

        #region IAsyncResult Version - Second Try

        public static IAsyncResult BeginGetStringV2()
        {
            //Console.WriteLine($"BeginGetStringV2 Entry Thread: {Thread.CurrentThread.GetHashCode()}");

            Stopwatch sw = Stopwatch.StartNew();

            TypedAsyncResult<string> asyncResult = new TypedAsyncResult<string>(null);
            var context = new Context() { Stopwatch = sw, AsyncResult = asyncResult };
            PersonService.BeginGetPersonName(ContinueWork, context); // Beginning of async operation

            //Console.WriteLine($"BeginGetStringV2 Exit Thread: {Thread.CurrentThread.GetHashCode()}");
            return asyncResult;
        }

        private static void ContinueWork(IAsyncResult ar)
        {
            //Console.WriteLine($"ContinueWork Entry Thread: {Thread.CurrentThread.GetHashCode()}");

            var name = PersonService.EndGetPersonName(ar);
            Context context = ar.AsyncState as Context;
            string result = string.Format("Getting {0} took {1} ms", name, context.Stopwatch.ElapsedMilliseconds);

           // Console.WriteLine($"ContinueWork Exit Thread: {Thread.CurrentThread.GetHashCode()}");
            context.AsyncResult.Complete(result, false);
        }

        private class Context
        {
            public Stopwatch Stopwatch { get; set; }
            public TypedAsyncResult<string> AsyncResult { get; set; }
        }

        #endregion IAsyncResult Version - Second Try
    }
}
