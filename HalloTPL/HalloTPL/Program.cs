using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Hallo TPL ***");

            //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle);
            //Parallel.For(0, 100_000, i => Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]: {i}"));

            var text = new List<string>(new[] { "Dies", "ist", "ein", "Text" });
            text.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-------------------------");
            Parallel.ForEach(text, x => Console.WriteLine(x));

            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void Zähle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]: {i}");
                if (i > 7) Console.ReadKey();
            }
        }
    }
}
