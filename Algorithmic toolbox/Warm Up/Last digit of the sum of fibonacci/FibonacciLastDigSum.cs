using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaxPairWise
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            int[] pisano = PisanoPeriod();
            n = (n+2) % 60 
            int result = pisano[n]-1;
            if (pisano[n] - 1 < 0) result = 9;
            Console.WriteLine(result);
            Console.ReadKey();
        }

        // module 10
        static int[] PisanoPeriod()
        {
            int[] fibonacci = new int[61];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = (fibonacci[i - 1] + fibonacci[i - 2]) % 10;
            }
            return fibonacci;
        }
    }
}