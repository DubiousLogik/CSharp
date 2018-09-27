using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AsyncWorkbook.AsyncDemo;
using AsyncWorkbook.AsyncPrototype;

namespace AsyncWorkbook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("======== AsyncDemoRunner ==============");
            //AsyncDemoRunner.Run();

            Console.WriteLine("========== AsyncProtoRunner =============");
            var sw = Stopwatch.StartNew();
            
            Console.WriteLine();
            Console.WriteLine("Beginning Async operation");

            var as1 = new AsyncProtoRunner();
            var as2 = new AsyncProtoRunner();

            var op1 = as1.BeginAsyncOperation("https://bing.com/?param=12312312312312132342342342");
            var op2 = as2.BeginAsyncOperation("https://google.com/?param=12312312312312132342342342");
            Console.Write("Doing other work: ");
            PrintDots(10);

            var result1 = as1.EndAsyncOperation(op1);
            var result2 = as2.EndAsyncOperation(op2);

            Console.Write("Doing other work a 2nd time: ");
            PrintDots(10);

            Console.WriteLine($"Reply from http get 1 {result1}");
            Console.WriteLine($"Reply from http get 2 {result2}");
            Console.WriteLine($"Elapsed time {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }

        public static void PrintDots(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine();
        }
    }
}
