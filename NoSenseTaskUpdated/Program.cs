using NoSenseTask.Extensions;
using NoSenseTask.Helpers;
using System;
using System.Linq;
using System.Threading;

namespace TestingShit
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[1];
            Console.Write("Enter coma separated numbers: ");
            args[0] = Console.ReadLine();
            Console.WriteLine();
            var collection = HelperTools.StringToIntEnumerable(args[0]);
            Console.Write($"For the first and second calls arguments for 'ThisDoesntMakeAnySense' are: ");
            collection.ToList().ForEach(a =>
            {
                Thread.Sleep(500);
                Console.Write($"{a} ");
            });
            Console.WriteLine();

            //predicate is always true here;
            var newNum = collection.ThisDoesntMakeAnySense(p => p <= int.MaxValue, l =>
            {
                return default;
            });
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.Write($"1) Output result is: '{newNum}', because the first member in the array --> '{newNum}', is smaller than {int.MaxValue}");

            Console.WriteLine();
            Thread.Sleep(1000);
            //predicate is always false here;
            var newNum2 = collection.ThisDoesntMakeAnySense(p => p > int.MaxValue, l =>
            {
                return l.IsNotInAnArray();
            });
            Console.WriteLine();
            Console.Write($"2) Output result is: '{newNum2}', because none of the members in the array can be greater than {int.MaxValue}, also '{newNum2}' is not member of an array");
            Console.WriteLine();

            collection = null;
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine($"3) This is the third call, where array itself is null.");
            Thread.Sleep(1000);
            Console.WriteLine();
            var newNum3 = 0;
            try
            {
                newNum3 = collection.ThisDoesntMakeAnySense(p => p <= int.MaxValue, l =>
                {
                    return default;
                });
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Output Result is: {ex.Message}");
            }
        }
    }
}
