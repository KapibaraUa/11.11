using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemHw
{
    public class NumberFileGenerator
    {
        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        private bool IsFibonacci(int number)
        {
            if (number < 0)
                return false;

            int a = 0;
            int b = 1;

            if (number == a || number == b)
                return true;

            int next = a + b;
            while (next <= number)
            {
                if (next == number)
                    return true;

                a = b;
                b = next;
                next = a + b;
            }

            return false;
        }

        public void GenerateAndSave(string primesPath, string fibonacciPath)
        {
            Random random = new Random();
            List<int> primes = new List<int>();
            List<int> fibonacci = new List<int>();

            int totalCount = 100;

            for (int i = 0; i < totalCount; i++)
            {
                int number = random.Next(0, 1000);

                if (IsPrime(number))
                    primes.Add(number);

                if (IsFibonacci(number))
                    fibonacci.Add(number);
            }

            using (StreamWriter writer = new StreamWriter(primesPath))
            {
                foreach (int num in primes)
                {
                    writer.WriteLine(num);
                }
            }

            using (StreamWriter writer = new StreamWriter(fibonacciPath))
            {
                foreach (int num in fibonacci)
                {
                    writer.WriteLine(num);
                }
            }

            Console.WriteLine($"Total numbers generated: {totalCount}");
            Console.WriteLine($"Prime numbers found and saved: {primes.Count}");
            Console.WriteLine($"Fibonacci numbers found and saved: {fibonacci.Count}");
        }
    }
}