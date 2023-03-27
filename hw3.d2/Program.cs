using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int[] array = new int[100];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            var res = from e in array
                      orderby e descending
                      select e;
            Console.WriteLine("Sorting result: ");
            foreach (int e in res)
                Console.Write(e+" ");
            Console.WriteLine();

            var avg = array.Average();
            Console.WriteLine("Average: ");
            Console.WriteLine(avg);

            var sum = array.Sum();
            Console.WriteLine("Sum: ");
            Console.WriteLine(sum);
        }
    }
}