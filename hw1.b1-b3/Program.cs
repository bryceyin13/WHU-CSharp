using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prime
{
    class prime
    {
        static void Main(string[] args)
        {
            // hw1.b1
            Console.WriteLine("b1: ");
            Console.WriteLine("Please input an integer that you want to find prime divisors: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Prime_print(num);
            Console.WriteLine();
            Console.WriteLine();

            // hw1.b2
            Console.WriteLine("b2: ");
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };// an example array
            Array_feat(array);
            Console.WriteLine();

            // hw1.b3
            Console.WriteLine("b3: ");
            int[] prime = new int[99];
            for (int i = 0; i < prime.Length; i++) 
            {
                prime[i] = i + 2;
            }
            Prime_set(prime);
            for (int i = 0;i < prime.Length; i++) 
            {
                if (prime[i] != -1) 
                {
                    Console.Write(prime[i] + " ");
                }
            }
            Console.WriteLine();
        }
        static void Prime_print(int num)
        {
            for (int i = 2; i <= num; i++) 
            {
                if (num % i == 0 && Isprime(i)) 
                {
                    Console.Write(i + " ");
                }
            }
        }
        static bool Isprime(int num)
        {
            bool res = true;
            for (int i = 2; i < num; i++) 
            {
                if (num % i == 0) res = false;
            }
            return res;
        }
        static void Array_feat(int[] array)
        {
            int max = array[0];
            int min = array[0];
            int sum = 0;
            double mean = 0.0;
            for (int i = 0; i < array.Length; i++ )
            {
                sum += array[i];
                if (array[i] > max) { max = array[i]; }
                if (array[i] < min) { min = array[i]; }
            }
            mean = Convert.ToDouble(sum) / array.Length;
            Console.WriteLine("The maximum number in array is: " + max);
            Console.WriteLine("The minimum number in array is: " + min);
            Console.WriteLine("The mean of array is: " + mean);
            Console.WriteLine("The summary of array is: " + sum);
        }
        static void Prime_set(int[] array)
        {
            for (int j = 2; j < 10; j++)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % j == 0 && array[i] / j != 1) 
                    {
                        array[i] = -1;
                    }
                }
            }
        }
    }
}